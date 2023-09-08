using PortalEquador.Contracts;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;

namespace PortalEquador.Domain.ProfessionalExperience.Repository
{
    public interface ProfessionalExperienceRepository : IGenericRepository<ProfessionalExperienceEntity>
    {

        Task<List<ProfessionalExperienceDetailViewModel>> GetAllProfessionalExperience(int personalInformationId);
    }
}
