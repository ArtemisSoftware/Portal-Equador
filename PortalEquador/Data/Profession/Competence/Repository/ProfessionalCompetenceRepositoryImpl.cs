using AutoMapper;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Domain.Languages.Repository;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.Profession.Competence.Repository;
using PortalEquador.Domain.Profession.Competence.ViewModels;

namespace PortalEquador.Data.Profession.Competence.Repository
{
    public class ProfessionalCompetenceRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<ProfessionalCompetenceEntity>(context, httpContextAccessor), IProfessionalCompetenceRepository
    {
        Task<List<ProfessionalCompetenceDetailViewModel>> IProfessionalCompetenceRepository.GetAll(int personalInformationId)
        {
            throw new NotImplementedException();
        }

        Task<ProfessionalCompetenceViewModel> IProfessionalCompetenceRepository.GetCreateModel(int personalInformationId, string fullName)
        {
            throw new NotImplementedException();
        }

        Task<ProfessionalCompetenceViewModel> IProfessionalCompetenceRepository.GetCreateModel(LanguageViewModel model)
        {
            throw new NotImplementedException();
        }

        Task<ProfessionalCompetenceViewModel> IProfessionalCompetenceRepository.GetProfessionalCompetence(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProfessionalCompetenceRepository.ProfessionalCompetenceExists(int personalInformationId, int professionalCompetenceId)
        {
            throw new NotImplementedException();
        }

        Task IProfessionalCompetenceRepository.Save(ProfessionalCompetenceViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
