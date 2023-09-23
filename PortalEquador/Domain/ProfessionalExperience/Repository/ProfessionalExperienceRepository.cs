using PortalEquador.Contracts;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;

namespace PortalEquador.Domain.ProfessionalExperience.Repository
{
    public interface ProfessionalExperienceRepository : IGenericRepository<ProfessionalExperienceEntity>
    {

        Task<List<ProfessionalExperienceDetailViewModel>> GetAll(int personalInformationId);

        Task<ProfessionalExperienceDetailViewModel> GetDetail(int id);

        Task<bool> Exists(int personalInformationId, int companyId, int workstationId);

        Task Save(ProfessionalExperienceViewModel model);

        Task<ProfessionalExperienceViewModel> Get(int id);
    }
}
