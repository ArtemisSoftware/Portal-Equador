using PortalEquador.Data.Document.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.EnumTypes;

namespace PortalEquador.Domain.Document.Repository
{
    public interface IDocumentRepository : IGenericRepository<DocumentEntity>
    {
        Task<List<DocumentViewModel>> GetAllDocuments(int personalInformationId);
        Task<List<DocumentViewModel>> GetDocumentByParentId(int id, List<int> documentTypeIds);

        Task<DocumentViewModel?> GetDocumentByParentId(int id, int documentTypeId);
        Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName);
        Task<DocumentViewModel> GetCreateModel(DocumentViewModel model);
        Task<bool> DocumentExists(int personaInformationId, int documentTypeId);
        Task Save(DocumentViewModel model);

        Task Save(DocumentViewModel model, FolderType folder);

        Task DeleteDocument(int personaInformationId, int documentTypeId);
        Task DeleteDocument(int personaInformationId, DocumentViewModel model);
    }
}
