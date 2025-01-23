using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.UseCase
{
    public class GetDayPlanUseCase(
        IMechanicalWorkshopSchedulerRepository mechanicalWorkshopSchedulerRepository, 
        IAdminMechanicalWorkShopRepository adminRepository
        )
    {
        public async Task<DayPlannerViewModel> Invoke(DateOnly date)
        {
            var model = await mechanicalWorkshopSchedulerRepository.GetDayPlan(date);
            model.AdminContracts = await adminRepository.GetUserContracts();
            model.OrderAppointements();
            return model;
        }
    }
}
