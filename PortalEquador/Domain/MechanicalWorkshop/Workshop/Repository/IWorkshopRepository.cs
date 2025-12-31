using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository
{
    public interface IWorkshopRepository: IGenericRepository<WorkshopEntity>
    {
        Task<List<WorkshopDetailViewModel>> GetDashboard();

        Task<List<WorkshopLaneViewModel>> GetLanes(int workshopId);
        Task<List<WorkshopMechanicViewModel>> GetMechanics(int workshopId);

        Task<bool> WorkshopExists(string name);
        Task<List<WorkshopDetailViewModel>> GetAllWorkshops();
        Task<WorkshopDetailViewModel> GetWorkshop(int id);

        Task Save(WorkshopCreateViewModel model);

        Task UpdateState(int id, bool active);
    }
}
