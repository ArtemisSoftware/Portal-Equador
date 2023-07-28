using AutoMapper;
using PortalEquador.Data.CurriculumVitae.Entities;
using PortalEquador.Domain.Models.CurriculumVitae;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Domain.Repositories;
using PortalEquador.Repositories;
using CurriculumRepository = PortalEquador.Domain.Repositories.CurriculumRepository;

namespace PortalEquador.Data.CurriculumVitae.Repository
{
    public class CurriculumRepositoryImpl : GenericRepository<CurriculumEntity>, CurriculumRepository
    {
        public CurriculumRepositoryImpl(ApplicationDbContext context) : base(context){ }

        public async Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int curriculumId)
        {
            /*
            var query = from personal in context.PersonalInformation
                        join driversLicence in context.DriversLicenceEntity
                            on personal.CurriculumId equals driversLicence.CurriculumId into result_table
                        from driversLicence in result_table.DefaultIfEmpty()
                        join groupItem in context.GroupItems
                            on driversLicence.GroupItemId equals groupItem.Id into group_result_table
                        from groupItem in group_result_table.DefaultIfEmpty()
                        where personal.CurriculumId == curriculumId

                        select new DriversLicenceViewModel__
                        {
                            CurriculumId = curriculumId,
                            Id = driversLicence.Id,
                            GroupItemId = groupItem.Id,
                            Licence = groupItem.Description,
                            Status = GetStatus(driversLicence.Id, driversLicence.ExpirationDate, driversLicence.ProvisionalExpirationDate),
                            ExpirationDate = driversLicence.ExpirationDate,
                            ProvisionalExpirationDate = driversLicence.ProvisionalExpirationDate,
                            ProvisionalRenewalNumber = driversLicence.ProvisionalRenewalNumber,
                            DateCreated = driversLicence.DateCreated,
                            DateModified = driversLicence.DateModified,
                        };
            return await query.FirstOrDefaultAsync();
            */
            var model = new CurriculumDashboardViewModel
            {
                IsDriversLicenceComplete = false
            };
            return model;
        }
    }
}
