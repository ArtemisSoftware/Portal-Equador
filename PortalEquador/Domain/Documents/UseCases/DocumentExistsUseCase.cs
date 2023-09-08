using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.PersonalInformation.Repository;

namespace PortalEquador.Domain.Documents.UseCases
{
    public class DocumentExistsUseCase
    {
        private readonly DocumentRepository documentRepository;

        public DocumentExistsUseCase(DocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public async Task<bool> Invoke(DocumentViewModel model)
        {
            return await documentRepository.DocumentExists(model.Id, model.DocumentTypeId);
        }
    }
}
