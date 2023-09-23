using PortalEquador.Constants;
using PortalEquador.Domain.PersonalInformation.Repository;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Domain.ProfessionalCompetence.ViewModels;

namespace PortalEquador.Domain.ProfessionalCompetence.UseCases
{
    public class GetProfessionalCompetenceCreationUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;
        private readonly ProfessionalCompetenceRepository professionalCompetenceRepository;

        public GetProfessionalCompetenceCreationUseCase(ProfessionalCompetenceRepository professionalCompetenceRepository, PersonalInformationRepository personalInformationRepository)
        {
            this.professionalCompetenceRepository = professionalCompetenceRepository;
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<ProfessionalCompetenceViewModel> Invoke(int id)
        {

            var competences = professionalCompetenceRepository. GroupItems(Groups.COMPETENCES);
            var personalInformation = await personalInformationRepository.GetPersonalInformationAsync(id);

            return new ProfessionalCompetenceViewModel
            {
                PersonaInformationId = id,
                PersonalInformation = personalInformation,
                Competences = competences
            };
        }
    }
}