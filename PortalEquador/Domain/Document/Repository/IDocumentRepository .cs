using PortalEquador.Data.Document.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Document.Repository
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName);

        Task<bool> DocumentExists(int personaInformationId, int documentTypeId);
        Task Save(DocumentViewModel model);

        /*
        Task<List<DocumentDetailViewModel>> GetAllDocumentsAsync(int id);

        Task<DocumentViewModel> GetDocument(int id);



        

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, List<int> DocumentsGroupIds);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, int GroupItemId);
        */
    }
}
