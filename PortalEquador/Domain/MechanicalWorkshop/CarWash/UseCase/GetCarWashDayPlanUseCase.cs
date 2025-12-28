using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.UseCase
{
    public class GetCarWashDayPlanUseCase(
        ICarWashSchedulerRepository carWashSchedulerRepository, 
        IAdminMechanicalWorkShopRepository adminRepository
        )
    {
        public async Task<CarWashDayPlannerViewModel> Invoke(DateOnly date, int workshopid, string workshopname)
        {
            var model = await carWashSchedulerRepository.GetDayPlan(date, workshopid, workshopname);
            model.AdminContracts = await adminRepository.GetUserContracts();
            model.OrderAppointements();
            return model;
        }
    }
}
