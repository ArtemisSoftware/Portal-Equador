using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository
{
    public interface ICarWashSchedulerRepository : IGenericRepository<CarWashSchedulerEntity>
    {
        Task<CarWashDayPlannerViewModel> GetDayPlan(DateOnly date);
        Task<CarWashViewModel> GetCreateModel(string scheduleDate, int interventionTimeId);
        Task<CarWashViewModel> GetCreateModel(CarWashViewModel model);
        Task Save(CarWashViewModel model);

        Task ConfirmWash(int id);
        Task NotPerformed(int id);
        Task<CarWashViewModel> GetSchedule(int id);
        Task<CarWashSearchDayPlannerViewModel> SearchGetDayPlan(string? licencePlate);
    }
}
