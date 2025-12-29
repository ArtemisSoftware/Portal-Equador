using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository
{
    public interface IMechanicalWorkshopSchedulerRepository : IGenericRepository<MechanicalWorkshopSchedulerEntity>
    {
        Task<DayPlannerViewModel> GetDayPlan(DateOnly date, int workshopid, string workshopname);
        Task<SchedulerViewModel> GetCreateModel(string scheduleDate, int mechanicId, int interventionTimeId, int workshopid, string workshopname);
        Task<SchedulerViewModel> GetCreateModel(SchedulerViewModel model);
        Task Save(SchedulerViewModel model);
        Task<SchedulerDetailViewModel> GetSchedule(int id);

        Task ConfirmRevision(int id);
        Task NotPerformed(int id);

        Task<SearchDayPlannerViewModel> SearchGetDayPlan(string? vehicleId, int workshopid);
    }
}
