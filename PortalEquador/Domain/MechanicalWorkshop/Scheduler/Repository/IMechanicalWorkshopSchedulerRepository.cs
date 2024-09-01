using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository
{
    public interface IMechanicalWorkshopSchedulerRepository : IGenericRepository<MechanicalWorkshopSchedulerEntity>
    {
        Task<DayPlannerViewModel> GetDayPlan(DateOnly date);
        Task<SchedulerViewModel> GetCreateModel(string scheduleDate, int mechanicId, int interventionTimeId);
        Task<SchedulerViewModel> GetCreateModel(SchedulerViewModel model);
        Task Save(SchedulerViewModel model);
        Task<SchedulerViewModel> GetSchedule(int id);
    }
}
