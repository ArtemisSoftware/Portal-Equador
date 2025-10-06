using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Data.Uniforms.Entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Domain.Uniforms.ViewModels;

namespace PortalEquador.Domain.Uniforms.Repository
{
    public interface IWorkerUniformRepository : IGenericRepository<WorkerUniformEntity>
    {
        Task<List<WorkerUniformViewModel>> GetAll(int personalInformationId);
        Task<WorkerUniformCreateViewModel> GetCreateModel(int personalInformationId, string fullName);
        Task<WorkerUniformCreateViewModel> GetCreateModel(WorkerUniformCreateViewModel model);
        Task<int> Save(WorkerUniformCreateViewModel model);
        Task<int> Save(WorkerUniformEditViewModel model);
        Task<WorkerUniformEditViewModel> GetEdit(int id);
        Task<WorkerUniformEditViewModel> RecoverForEdit(WorkerUniformEditViewModel model);
    }
}
