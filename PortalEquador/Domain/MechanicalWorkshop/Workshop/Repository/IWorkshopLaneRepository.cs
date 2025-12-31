using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository
{
    public interface IWorkshopLaneRepository : IGenericRepository<WorkshopLaneEntity>
    {
        Task Save(int workshopId);
        Task UpdateState(int id, bool active);
    }
}
