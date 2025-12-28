using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository
{
    public interface ICarWashSchedulerRepository : IGenericRepository<CarWashSchedulerEntity>
    {
        Task<CarWashDayPlannerViewModel> GetDayPlan(DateOnly date, int workshopid, string workshopname);
        Task<CarWashViewModel> GetCreateModel(string scheduleDate, int laneId, int interventionTimeId, int workshopid, string workshopname);
        Task<CarWashViewModel> GetCreateModel(CarWashViewModel model);
        Task Save(CarWashViewModel model);

        Task ConfirmWash(int id);
        Task NotPerformed(int id);
        Task<CarWashViewModel> GetSchedule(int id);
        Task<CarWashSearchDayPlannerViewModel> SearchGetDayPlan(string? licencePlate, int workshopid, string workshopname);
    }
}
