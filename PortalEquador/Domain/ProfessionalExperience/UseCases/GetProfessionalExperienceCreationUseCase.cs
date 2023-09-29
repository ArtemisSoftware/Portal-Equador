using PortalEquador.Constants;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.ProfessionalExperience.Repository;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;

namespace PortalEquador.Domain.ProfessionalExperience.UseCases
{
    public class GetProfessionalExperienceCreationUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;
        private readonly ProfessionalExperienceRepository professionalExperienceRepository;

        public GetProfessionalExperienceCreationUseCase(ProfessionalExperienceRepository professionalExperienceRepository, PersonalInformationRepository personalInformationRepository)
        {
            this.professionalExperienceRepository = professionalExperienceRepository;
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<ProfessionalExperienceViewModel> Invoke(int id)
        {

            var companies = professionalExperienceRepository.GroupItems(Groups.COMPANIES);
            var workstations = professionalExperienceRepository.GroupItems(Groups.WORKSTATIONS);

            var personalInformation = await personalInformationRepository.GetPersonalInformationAsync(id);

            return new ProfessionalExperienceViewModel
            {
                PersonaInformationId = id,
                PersonalInformation = personalInformation,
                Companies = companies,
                Workstations = workstations
            };
        }
    }
}