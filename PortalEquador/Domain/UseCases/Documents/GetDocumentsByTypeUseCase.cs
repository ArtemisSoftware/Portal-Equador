using Microsoft.Extensions.Hosting;
using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Domain.Models.Document;

namespace PortalEquador.Domain.UseCases.Documents
{
    public class GetDocumentsByTypeUseCase
    {
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentsByTypeUseCase(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentViewModel>> Invoke(int curriculumId, List<int> documentTypeIds)
        {
            return await _documentRepository.GetDocumentsByTypeAsync(curriculumId, documentTypeIds);
        }
    }
}
