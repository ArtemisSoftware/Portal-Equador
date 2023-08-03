using PortalEquador.Data.Document.Entities;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Contracts
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<List<DocumentsViewModel>> GetAllPersonalDocAsync();
        Task<List<DocumentEntity>> GetAllDocumentsAsync(int curriculumId);

        Task<List<DocumentViewModel>> GetDocumentsByTypeAsync(int curriculumId, List<int> documentTypeIds);
    }
}
