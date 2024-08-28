using PortalEquador.Data.Document.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Document.Repository
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<DocumentViewModel> GetCreateModel(int id);
        /*
        Task<List<DocumentDetailViewModel>> GetAllDocumentsAsync(int id);

        Task<DocumentViewModel> GetDocument(int id);

        Task<bool> DocumentExists(int curriculumId, int documentTypeId);

        Task Save(DocumentViewModel document);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, List<int> DocumentsGroupIds);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, int GroupItemId);
        */
    }
}
