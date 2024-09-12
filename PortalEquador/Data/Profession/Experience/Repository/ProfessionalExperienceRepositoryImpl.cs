using AutoMapper;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.Profession.Experience.Repository;
using PortalEquador.Domain.Profession.Experience.ViewModels;

namespace PortalEquador.Data.Profession.Experience.Repository
{
    public class ProfessionalExperienceRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<ProfessionalExperienceEntity>(context, httpContextAccessor), IProfessionalExperienceRepository
    {
        Task<List<ProfessionalExperienceDetailViewModel>> IProfessionalExperienceRepository.GetAll(int personalInformationId)
        {
            throw new NotImplementedException();
        }

        Task<ProfessionalExperienceViewModel> IProfessionalExperienceRepository.GetCreateModel(int personalInformationId, string fullName)
        {
            throw new NotImplementedException();
        }

        Task<ProfessionalExperienceViewModel> IProfessionalExperienceRepository.GetCreateModel(LanguageViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<ProfessionalExperienceViewModel> IProfessionalExperienceRepository.GetProfessionalExperience(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProfessionalExperienceRepository.ProfessionalExperienceExists(int personalInformationId, int companyId, int professionalExperienceId)
        {
            throw new NotImplementedException();
        }

        Task IProfessionalExperienceRepository.Save(ProfessionalExperienceViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
