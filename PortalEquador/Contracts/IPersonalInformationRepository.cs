using PortalEquador.Data.GroupTypes;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.PInformation;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Contracts
{
    public interface IPersonalInformationRepository : IGenericRepository<PersonalInformationEntity>
    {
        Task<bool> PersonalInformationExists(string identityCard);

        Task<ProfileInformation> GetProfileInformation(int curriculumId);
    }
}
