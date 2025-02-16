using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;

namespace PortalEquador.Domain.Trainning.Repository
{
    public interface ITrainningRepository : IGenericRepository<TrainningEntity>
    {
        Task<List<TrainningViewModel>> GetAll(int personalInformationId);
        Task<TrainningCreateViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<TrainningCreateViewModel> GetCreateModel(TrainningCreateViewModel model);
        Task<int> Save(TrainningCreateViewModel model);
        Task<TrainningViewModel> GetDetail(int id);
        Task<TrainningCreateViewModel> GetTrainning(int id);
    }
}
