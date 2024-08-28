using AutoMapper;
using PortalEquador.Data.Generic;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;

namespace PortalEquador.Data.PersonalInformation.Repository
{
    public class PersonalInformationRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<PersonalInformationEntity>(context, httpContextAccessor), IPersonalInformationRepository
    {

        /*
        public async Task<PersonalInformationViewModel> GetPersonalInformationAsync(int id)
        {

            var result = await context.PersonalInformationEntity
               .Include(item => item.NationalityGroupItemEntity)
                .Include(item => item.ProvinceGroupItemEntity)
               .Include(item => item.NeighbourhoodGroupItemEntity)
               .FirstOrDefaultAsync(m => m.Id == id);

            return _mapper.Map<PersonalInformationViewModel>(result);


            //return new PersonalInformationViewModel();
        }

        public async Task<bool> PersonalInformationExists(string identityCard)
        {
            return !await context.PersonalInformationEntity.AnyAsync(item => item.IdentityCard == identityCard);
            //return false;
        }
        */
        public async Task<List<PersonalInformationViewModel>> GetAll()
        {
            var result = await GetAllAsync();
            return mapper.Map<List<PersonalInformationViewModel>>(result);
        }
        /*

        public async Task<PersonalInformationDetailViewModel?> GetPersonalInformationDetailAsync(int id)
        {

            var result = await context.PersonalInformationEntity
               .Include(item => item.NationalityGroupItemEntity)
                .Include(item => item.ProvinceGroupItemEntity)
               .Include(item => item.NeighbourhoodGroupItemEntity)
               .FirstOrDefaultAsync(m => m.Id == id);

            return _mapper.Map<PersonalInformationDetailViewModel>(result);

            //return new PersonalInformationDetailViewModel();
        }
*/


    }
}
