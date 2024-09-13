using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.Profession.Competence.ViewModels;
using PortalEquador.Domain.Profession.Experience.ViewModels;

namespace PortalEquador.Domain.Profession.Competence.Repository
{
    public interface IProfessionalCompetenceRepository : IGenericRepository<ProfessionalCompetenceEntity>
    {
        Task<List<ProfessionalCompetenceDetailViewModel>> GetAll(int personalInformationId);
        Task<ProfessionalCompetenceViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<ProfessionalCompetenceViewModel> GetCreateModel(ProfessionalCompetenceViewModel model);
        Task Save(ProfessionalCompetenceViewModel model);
        Task<bool> ProfessionalCompetenceExists(int personalInformationId, int professionalCompetenceId);
        Task<ProfessionalCompetenceViewModel> GetProfessionalCompetence(int id);
    }
}
