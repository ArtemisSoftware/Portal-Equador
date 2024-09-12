using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.Profession.Experience.ViewModels;

namespace PortalEquador.Domain.Profession.Experience.Repository
{
    public interface IProfessionalExperienceRepository : IGenericRepository<ProfessionalExperienceEntity>
    {
        Task<List<ProfessionalExperienceDetailViewModel>> GetAll(int personalInformationId);
        Task<ProfessionalExperienceViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<ProfessionalExperienceViewModel> GetCreateModel(LanguageViewModel model);
        Task Save(ProfessionalExperienceViewModel model);
        Task<bool> ProfessionalExperienceExists(int personalInformationId, int companyId, int professionalExperienceId);
        Task<ProfessionalExperienceViewModel> GetProfessionalExperience(int id);
    }
}
