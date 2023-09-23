using PortalEquador.Contracts;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Domain.ProfessionalCompetence.ViewModels;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;

namespace PortalEquador.Domain.ProfessionalCompetence.Repository
{
    public interface ProfessionalCompetenceRepository : IGenericRepository<ProfessionalCompetenceEntity>
    {
        Task<List<ProfessionalCompetenceResumeViewModel>> GetAll();

        Task<List<ProfessionalCompetenceDetailViewModel>> GetAll(int personalInformationId);

        Task<ProfessionalCompetenceDetailViewModel> GetDetail(int id);

        Task<bool> Exists(int personalInformationId, int competenceId);

        Task Save(ProfessionalCompetenceViewModel model);

    }
}
