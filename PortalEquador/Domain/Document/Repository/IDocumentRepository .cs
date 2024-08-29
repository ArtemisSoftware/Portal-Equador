using PortalEquador.Data.Document.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Document.Repository
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<List<DocumentDetailViewModel>> GetAllDocuments(int personalInformationId);
        Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName);
        Task<bool> DocumentExists(int personaInformationId, int documentTypeId);
        Task Save(DocumentViewModel model);

        Task DeleteDocument(int personaInformationId, int documentTypeId);
        /*
        

        Task<DocumentViewModel> GetDocument(int id);



        

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, List<int> DocumentsGroupIds);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, int GroupItemId);
        */
    }
}
