using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;

namespace PortalEquador.Domain.Documents.UseCases
{
    public class SaveDocumentUseCase
    {
        private readonly DocumentRepository _documentRepository;
      
        public SaveDocumentUseCase(
            DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task Invoke(DocumentViewModel document)
        {
            await _documentRepository.SaveDocument(document);
        }
    }
}
