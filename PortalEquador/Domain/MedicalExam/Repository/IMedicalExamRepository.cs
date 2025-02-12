using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Util.EnumTypes;

namespace PortalEquador.Domain.MedicalExam.Repository
{
    public interface IMedicalExamRepository : IGenericRepository<MedicalExamEntity>
    {
        Task<List<MedicalExamViewModel>> GetAll(int personalInformationId);
        /*
        Task<DocumentViewModel> GetCreateModel(int personaInformationId, string fullName);
        Task<DocumentViewModel> GetCreateModel(DocumentViewModel model);

        Task Save(DocumentViewModel model);

        Task Save(DocumentViewModel model, FolderType folder);

        Task DeleteDocument(int personaInformationId, int documentTypeId);
        Task DeleteDocument(int personaInformationId, DocumentViewModel model);
        */
    }
}
