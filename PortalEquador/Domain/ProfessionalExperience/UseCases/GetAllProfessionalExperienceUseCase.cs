using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;

namespace PortalEquador.Domain.ProfessionalExperience.UseCases
{
    public class GetAllProfessionalExperienceUseCase
    {
        private readonly ProfessionalExperienceRepository professionalExperienceRepository;

        public GetAllProfessionalExperienceUseCase(ProfessionalExperienceRepository professionalExperienceRepository)
        {
            this.professionalExperienceRepository = professionalExperienceRepository;
        }

        public async Task<List<ProfessionalExperienceDetailViewModel>> Invoke(int personalInformationId)
        {
            var model = await professionalExperienceRepository.GetAllProfessionalExperience(personalInformationId);
            return model;
        }
    }
}
