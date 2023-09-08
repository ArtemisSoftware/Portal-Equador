using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Data;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.PInformation;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Repositories;
using PortalEquador.Util;
using System.Collections.Generic;

namespace PortalEquador.Data.PersonalInformation.Repository
{
    public class PersonalInformationRepositoryImpl : GenericRepository<PersonalInformationEntity>, PersonalInformationRepository
    {
        private readonly IMapper _mapper;

        public PersonalInformationRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

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

        public async Task<List<PersonalInformationViewModel>> GetAll()
        {
            var result = await GetAllAsync();
            return _mapper.Map<List<PersonalInformationViewModel>>(result);
        }


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



    }
}
