using PortalEquador.Data.Document.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.EnumTypes;

namespace PortalEquador.Domain.Document.Repository
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<List<DocumentDetailViewModel>> GetAllDocuments(int personalInformationId);
        Task<List<DocumentViewModel>> GetDocumentByParentId(int id, List<int> documentTypeIds);
        Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName);
        Task<DocumentViewModel> GetCreateModel(DocumentViewModel model);
        Task<bool> DocumentExists(int personaInformationId, int documentTypeId);
        Task Save(DocumentViewModel model);

        Task Save(DocumentViewModel model, FolderType folder);

        Task DeleteDocument(int personaInformationId, int documentTypeId);
        /*
       
        Task<DocumentViewModel> GetDocument(int id);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, List<int> DocumentsGroupIds);

        Task<List<DocumentDetailViewModel>> GetDocumentsDetails(int personalInformationId, int GroupItemId);
        */
    }
}
