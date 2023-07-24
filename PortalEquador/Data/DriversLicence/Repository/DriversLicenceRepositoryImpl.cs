using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Data.Migrations;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Models.Documents;
using PortalEquador.Repositories;
using PortalEquador.Util;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PortalEquador.Data.DriversLicence.Repository
{
    public class DriversLicenceRepositoryImpl : GenericRepository<DriversLicenceEntity>, DriversLicenceRepository
    {
        private readonly ApplicationDbContext context;

        public DriversLicenceRepositoryImpl(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<DriversLicenceViewModel>> GetAllDriversLicenceAsync()
        {
            var query = from personal in context.PersonalInformation
                        join driversLicence in context.DriversLicenceEntity
                            on personal.CurriculumId equals driversLicence.CurriculumId into result_table
                        from driversLicence in result_table.DefaultIfEmpty()
                        join groupItem in context.GroupItems
                            on driversLicence.GroupItemId equals groupItem.Id into group_result_table
                        from groupItem in group_result_table.DefaultIfEmpty()

                        select new DriversLicenceViewModel
                        {
                            Id = driversLicence.Id,
                            CurriculumId = personal.CurriculumId,
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfilePicturePath = ImagesUtil.GetProfilePicturePath(personal.CurriculumId, ".jpg"), // TODO: mudar isto + está incompleto
                             Licence = groupItem.Description,
                            Status = GetStatus(driversLicence.Id, driversLicence.ExpirationDate, driversLicence.ProvisionalExpirationDate) 
                        };
            return await query.ToListAsync();
        }

        public async Task<DriversLicenceDetailViewModel?> GetDriversLicenceAsync(int curriculumId)
        {
            var query = from personal in context.PersonalInformation
                        join driversLicence in context.DriversLicenceEntity
                            on personal.CurriculumId equals driversLicence.CurriculumId into result_table
                        from driversLicence in result_table.DefaultIfEmpty()
                        join groupItem in context.GroupItems
                            on driversLicence.GroupItemId equals groupItem.Id into group_result_table
                        from groupItem in group_result_table.DefaultIfEmpty()
                        where personal.CurriculumId == curriculumId

                        select new DriversLicenceDetailViewModel
                        {
                            CurriculumId = curriculumId,
                            ExpirationDate = driversLicence.ExpirationDate,
                            ProvisionalExpirationDate = driversLicence.ProvisionalExpirationDate,
                            ProvisionalRenewalNumber = driversLicence.ProvisionalRenewalNumber,
                            Licence = groupItem.Description,
                            Status = GetStatus(driversLicence.Id, driversLicence.ExpirationDate, driversLicence.ProvisionalExpirationDate),
                            DateCreated = driversLicence.DateCreated,
                            DateModified = driversLicence.DateModified,
                        };
            return await query.FirstOrDefaultAsync();
        }

        private static LicenceStatus? GetStatus(int? id, DateTime? expirationDate, DateTime? provisionalExpirationDate)
        {

            if (id == null) return null;

            if(expirationDate == null)
            {
                return LicenceStatus.No_Expiration_Date;
            }
            
            if(expirationDate < DateTime.Now && provisionalExpirationDate == null)
            {
                return LicenceStatus.Expired;
            }

            if (expirationDate < DateTime.Now && provisionalExpirationDate < DateTime.Now)
            {
                return LicenceStatus.Provisional_Renewal_Expired;
            }

            if (expirationDate < DateTime.Now && provisionalExpirationDate > DateTime.Now)
            {
                return LicenceStatus.Provisional_Renewal_Updated;
            }

            return LicenceStatus.Updated;
        }

    }
}
