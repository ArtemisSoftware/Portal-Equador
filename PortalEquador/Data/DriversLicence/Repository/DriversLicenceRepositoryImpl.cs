using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.DriversLicence.Repository;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Languages.Repository;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Data.DriversLicence.Repository
{
    public class DriversLicenceRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        : GenericRepository<DriversLicenceEntity>(context, httpContextAccessor), 
        IDriversLicenceRepository
    {
        public async Task<List<DriversLicenceDetailViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.DriversLicenceEntity
                           .Include(item => item.LicenceTypeGroupItemEntity)
                           .Include(item => item.PersonalInformationEntity)
                            .Where(item => item.PersonalInformationId == personalInformationId)
                            .ToListAsync();

            return mapper.Map< List<DriversLicenceDetailViewModel>>(result);
        }

        public async Task<DriversLicenceViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            List<int> documentsId = Documents.GetDriversLicenceDocuments(); 

            var licenceTypes = GroupItems(Groups.DRIVERS_LICENCE);

            return new DriversLicenceViewModel
            {
                LicenceTypes = licenceTypes,
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                //Documents = documents,
                //DriverLicenceDocumentId = driverLicenceDocumentId
            };
        }

        public async Task<DriversLicenceViewModel> GetCreateModel(DriversLicenceViewModel model)
        {
            var licenceTypes = GroupItems(Groups.DRIVERS_LICENCE);

            model.LicenceTypes = licenceTypes;
            return model;
        }

        public async Task<DriversLicenceDetailViewModel> GetDriversLicenceDetail(int id)
        {
            var result = await context.DriversLicenceEntity
                          .Include(item => item.LicenceTypeGroupItemEntity)
                          .Include(item => item.PersonalInformationEntity)
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            return mapper.Map<DriversLicenceDetailViewModel>(result);
        }
        
        public async Task<DriversLicenceRenewViewModel> GetDriversLicenceRenew(int id)
        {
            var result = await context.DriversLicenceEntity
                          .Include(item => item.LicenceTypeGroupItemEntity)
                          .Include(item => item.PersonalInformationEntity)
                            .Where(item => item.Id == id)
                            .FirstOrDefaultAsync();

            return mapper.Map<DriversLicenceRenewViewModel>(result);
        }

        public async Task<DriversLicenceProvisionalViewModel> GetDriversLicenceProvisional(int id)
        {
            var result = await context.DriversLicenceEntity
                    .Include(item => item.LicenceTypeGroupItemEntity)
                    .Include(item => item.PersonalInformationEntity)
                    .Where(item => item.Id == id)
                    .FirstOrDefaultAsync();

            return mapper.Map<DriversLicenceProvisionalViewModel>(result);
        }

        public async Task<DriversLicenceProvisionalRenewViewModel> GetDriversLicenceProvisionalRenew(int id)
        {
            var result = await context.DriversLicenceEntity
                    .Include(item => item.LicenceTypeGroupItemEntity)
                    .Include(item => item.PersonalInformationEntity)
                    .Where(item => item.Id == id)
                    .FirstOrDefaultAsync();

            return mapper.Map<DriversLicenceProvisionalRenewViewModel>(result);
        }

        public async Task<DriversLicenceViewModel> GetDriversLicence(int id)
        {
            var result = await context.DriversLicenceEntity
                    .Include(item => item.LicenceTypeGroupItemEntity)
                    .Include(item => item.PersonalInformationEntity)
                    .Where(item => item.Id == id)
                    .FirstOrDefaultAsync();

            return mapper.Map<DriversLicenceViewModel>(result);
        }

        public async Task<bool> LicenceExists(int personalInformationId, int licenceTypeId)
        {
            return await context.DriversLicenceEntity.AnyAsync(
                item => item.PersonalInformationId == personalInformationId
                & item.LicenceTypeId == licenceTypeId
                );
        }

        public async Task<int> Save(DriversLicenceViewModel model)
        {
            var entity = mapper.Map<DriversLicenceEntity>(model);
            entity.EditorId = GetCurrentUserId();
            var id = await Save(model.Id, entity);

            return id;
        }

        public async Task<int> Save(DriversLicenceRenewViewModel model)
        {
            var entity = mapper.Map<DriversLicenceEntity>(model);
            entity.EditorId = GetCurrentUserId();
            var id = await Save(model.Id, entity);

            return id;
        }

        public async Task<int> Save(DriversLicenceProvisionalViewModel model)
        {
            if (model.ProvisionalRenewalNumber != null)
            {
                model.ProvisionalRenewalNumber = (int)model.ProvisionalRenewalNumber + 1;
            }
            else
            {
                model.ProvisionalRenewalNumber = 1;
            }

            var entity = mapper.Map<DriversLicenceEntity>(model);
            var id = await Save(model.Id, entity);
            return id;
        }

        public async Task<int> Save(DriversLicenceProvisionalRenewViewModel model)
        {
            if (model.ProvisionalRenewalNumber != null)
            {
                model.ProvisionalRenewalNumber = (int)model.ProvisionalRenewalNumber + 1;
            }
            else
            {
                model.ProvisionalRenewalNumber = 1;
            }

            var entity = mapper.Map<DriversLicenceEntity>(model);
            var id = await Save(model.Id, entity);
            return id;
        }

        private async Task<int> Save(int id, DriversLicenceEntity entity)
        {
            entity.EditorId = GetCurrentUserId();
           
            if (id == 0)
            {
                var result = await AddAsync(entity);
                id = result.Id;
            }
            else
            {
                id = entity.Id;
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }

            return id;
        }


    }
}
