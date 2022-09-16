using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;

namespace PortalEquador.Contracts
{
    public interface IPersonalInformationRepository : IGenericRepository<PersonalInformation>
    {
        Task<bool> PersonalInformationExists(string identityCard);
    }
}
