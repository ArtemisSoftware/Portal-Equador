using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Contracts
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        Task<List<DocumentsViewModel>> GetAllPersonalDocAsync();
        Task<List<Document>> GetAllDocumentsAsync(int curriculumId);

        Task<List<DocumentViewModel>> GetDocumentsByTypeAsync(int curriculumId, List<int> documentTypeIds);
    }
}
