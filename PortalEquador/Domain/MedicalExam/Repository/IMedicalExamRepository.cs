using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Util.EnumTypes;

namespace PortalEquador.Domain.MedicalExam.Repository
{
    public interface IMedicalExamRepository : IGenericRepository<MedicalExamEntity>
    {
        Task<List<MedicalExamViewModel>> GetAll(int personalInformationId);
        Task<MedicalExamCreateViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<MedicalExamCreateViewModel> GetCreateModel(MedicalExamCreateViewModel model);
        Task <int> Save(MedicalExamCreateViewModel model);
        Task<MedicalExamViewModel> GetDetail(int id);
        Task<MedicalExamCreateViewModel> GetMedicalExam(int id);
    }
}
