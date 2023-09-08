using Microsoft.Extensions.Hosting;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain.Documents.Repository;
using PortalEquador.Domain.Documents.ViewModels;

namespace PortalEquador.Domain.UseCases.Documents
{
    public class GetDocumentsByTypeUseCase
    {
        private readonly DocumentRepository _documentRepository;

        public GetDocumentsByTypeUseCase(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentViewModel>> Invoke(int curriculumId, List<int> documentTypeIds)
        {
            return /*await _documentRepository.GetDocumentsByTypeAsync(curriculumId, documentTypeIds)*/ new List<DocumentViewModel>();
        }
    }
}
