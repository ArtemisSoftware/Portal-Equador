using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Constants;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.PInformation;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Util;

namespace PortalEquador.Repositories
{
    public class PersonalInformationRepository : GenericRepository<PersonalInformation>, IPersonalInformationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;

        public PersonalInformationRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<bool> PersonalInformationExists(string identityCard)
        {
            return await context.PersonalInformation.AnyAsync(item => item.IdentityCard == identityCard);
        }

        public async Task<PersonalInformationViewModel> GetPersonalInformationResume(int curriculumId)
        {
            var result = await GetAsync(curriculumId);
            return _mapper.Map<PersonalInformationViewModel>(result);
        }

        public async Task<ProfileInformation> GetProfileInformation(int curriculumId)
        {
            var query = from personal in context.PersonalInformation
                        join  documents in context.Documents
                            on personal.CurriculumId equals documents.CurriculumId 
                        where (documents. GroupItemId == ItemFromGroup.Documents.PROFILE_PICTURE) & personal.CurriculumId == curriculumId
                        select new ProfileInformation
                        {
                            FullName = personal.FirstName + " " + personal.LastName,
                            ProfilePicturePath = ImagesUtil.GetProfilePicturePath(personal.CurriculumId, documents.FileExtension),
                        };
            return await query.FirstAsync();
        }
    }
}
