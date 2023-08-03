using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.PInformation;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Repositories;
using PortalEquador.Util;

namespace PortalEquador.Data.PersonalInformation.Repository
{
    public class PersonalInformationRepositoryImpl : GenericRepository<PersonalInformationEntity>, IPersonalInformationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public PersonalInformationRepositoryImpl(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<bool> PersonalInformationExists(string identityCard)
        {
            return true;
            //return await context.PersonalInformationEntity.AnyAsync(item => item.IdentityCard == identityCard);
        }

        public async Task<PersonalInformationViewModel> GetPersonalInformationResume(int curriculumId)
        {
            return new PersonalInformationViewModel();
            /*
            var result = await GetAsync(curriculumId);
            return _mapper.Map<PersonalInformationViewModel>(result);
            */
        }

        public async Task<ProfileInformation> GetProfileInformation(int curriculumId)
        {
            return new ProfileInformation();
            /*
            var query = from personal in context.PersonalInformation
                        join documents in context.Documents
                            on personal.CurriculumId equals documents.CurriculumId
                        where documents.GroupItemId == ItemFromGroup.Documents.PROFILE_PICTURE & personal.CurriculumId == curriculumId
                        select new ProfileInformation
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfilePicturePath = ImagesUtil.GetProfilePicturePath(personal.CurriculumId, documents.FileExtension),
                        };
            return await query.FirstAsync();
            */
        }
    }
}
