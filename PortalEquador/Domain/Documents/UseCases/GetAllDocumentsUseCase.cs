using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;

namespace PortalEquador.Domain.Documents.UseCases
{
    public class GetAllDocumentsUseCase
    {
        private readonly DocumentRepository documentRepository;

        public GetAllDocumentsUseCase(DocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public async Task<List<DocumentDetailViewModel>> Invoke(int id)
        {
            var model = await documentRepository.GetAllDocumentsAsync(id);
            return model;
        }
    }
}
