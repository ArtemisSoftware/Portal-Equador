using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Contracts
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        Task<List<DocumentsViewModel>> GetAllPersonalDocAsync();
        Task<List<Document>> GetAllDocumentsAsync(int curriculumId);
    }
}
