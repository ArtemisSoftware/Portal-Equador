using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.Text.RegularExpressions;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.PersonalInformation.Repository
{
    public class PersonalInformationRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<PersonalInformationEntity>(context, httpContextAccessor), IPersonalInformationRepository
    {

        public async Task<PersonalInformationViewModel> GetCreateModel(PersonalInformationViewModel? model)
        {

            var nationalities =  GroupItems(GroupTypesConstants.Groups.NATIONALITY);
            var neighbourhoods = GroupItems(GroupTypesConstants.Groups.NEIGHBOURHOOD);
            var provinces = GroupItems(GroupTypesConstants.Groups.PROVINCE);

            if (model == null)
            {
                return new PersonalInformationViewModel
                {
                    Neighbourhoods = neighbourhoods,
                    Nationalities = nationalities,
                    Provinces = provinces
                };
            }
            else
            {
                model.Neighbourhoods = neighbourhoods;
                model.Nationalities = nationalities;
                model.Provinces = provinces;
                return model;
            }
        }

        public async Task<bool> ValidateIdentityCardNumber(string identityCardNumber)
        {
            return !await context.PersonalInformationEntity.AnyAsync(item => item.IdentityCard == identityCardNumber);
        }

        public async Task Save(PersonalInformationViewModel model)
        {
            PersonalInformationEntity entity = mapper.Map<PersonalInformationEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (entity.NationalityId != ItemFromGroup.Nationality.ANGOLAN)
            {
                entity.ProvinceId = null;
            }

            if (model.Id == 0)
            {
                await AddAsync(entity);
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }


        
        public async Task<PersonalInformationViewModel> GetPersonalInformation(int id)
        {
            var result = await context.PersonalInformationEntity
               .Include(item => item.NationalityGroupItemEntity)
                .Include(item => item.ProvinceGroupItemEntity)
               .Include(item => item.NeighbourhoodGroupItemEntity)
               .FirstOrDefaultAsync(m => m.Id == id);

            return mapper.Map<PersonalInformationViewModel>(result);
        }
        
        public async Task<List<PersonalInformationViewModel>> GetAll()
        {
            var result = await GetAllAsync();
            return mapper.Map<List<PersonalInformationViewModel>>(result);
        }


        public async Task<PersonalInformationDetailViewModel> GetPersonalInformationDetail(int id)
        {
            var result = await context.PersonalInformationEntity
               .Include(item => item.NationalityGroupItemEntity)
                .Include(item => item.ProvinceGroupItemEntity)
               .Include(item => item.NeighbourhoodGroupItemEntity)
               .Include(item => item.ApplicationUserEntity)
               .FirstOrDefaultAsync(m => m.Id == id);

            return mapper.Map<PersonalInformationDetailViewModel>(result);
        }
    }
}
