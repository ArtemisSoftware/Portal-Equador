using PortalEquador.Contracts;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Domain.Documents.ViewModels;

namespace PortalEquador.Domain.Documents.Repository
{
    public interface DocumentRepository : IGenericRepository<DocumentEntity>
    {

        Task<List<DocumentDetailViewModel>> GetAllDocumentsAsync(int id);

        Task<DocumentViewModel> GetDocumentAsync(int id);

        Task<bool> DocumentExists(int curriculumId, int documentTypeId);

        Task SaveDocument(DocumentViewModel document);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, List<int> DocumentsGroupIds);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, int GroupItemId);

    }
}
