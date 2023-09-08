using PortalEquador.Constants;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Domain.Documents.UseCases
{
    public class GetDocumentCreationModelUseCase
    {
        private readonly PersonalInformationRepository personalInformationRepository;

        public GetDocumentCreationModelUseCase(PersonalInformationRepository personalInformationRepository)
        {
            this.personalInformationRepository = personalInformationRepository;
        }

        public async Task<DocumentViewModel> Invoke(int id)
        {

            var documentsTypes = personalInformationRepository.GroupItems(Groups.DOCUMENTS);
            var personalInformation = await personalInformationRepository.GetPersonalInformationAsync(id);

            var model = new DocumentViewModel
            {
                DocumentTypes = documentsTypes,
                PersonaInformationId = id,
                PersonalInformation = personalInformation
            };

            return model;
        }
    }
}
