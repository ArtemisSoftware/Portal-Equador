using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Data.PInformation;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Contracts
{
    public interface IPersonalInformationRepository : IGenericRepository<PersonalInformation>
    {
        Task<bool> PersonalInformationExists(string identityCard);

        Task<ProfileInformation> GetProfileInformation(int curriculumId);
    }
}
