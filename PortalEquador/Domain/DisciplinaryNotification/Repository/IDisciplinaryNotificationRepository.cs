using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;

namespace PortalEquador.Domain.DisciplinaryNotification.Repository
{
    public interface IDisciplinaryNotificationRepository : IGenericRepository<DisciplinaryNotificationEntity>
    {
        Task<List<DisciplinaryNotificationViewModel>> GetAll(int personalInformationId);
        Task<DisciplinaryNotificationCreateViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<DisciplinaryNotificationCreateViewModel> GetCreateModel(DisciplinaryNotificationCreateViewModel model);
        Task<int> Save(DisciplinaryNotificationCreateViewModel model);
        Task<DisciplinaryNotificationViewModel> GetDetail(int id);
        Task<DisciplinaryNotificationCreateViewModel> GetDisciplinaryNotification(int id);
    }
}
