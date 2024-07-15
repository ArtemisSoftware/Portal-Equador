using PortalEquador.Contracts;
using PortalEquador.Data.Scheduler.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;

namespace PortalEquador.Domain.Scheduler.MechanicalWorkshop.Repository
{
    public interface MechanicalWorkshopSchedulerRepository : IGenericRepository<MechanicalWorkshopSchedulerEntity>
    {
        Task<List<MechanicalWorkshopSchedulerViewModel>> GetAll(DateTime date);

        Task<DocumentViewModel> GetAsync(int id);

        Task Save(MechanicalWorkshopSchedulerViewModel item);
    }
}
