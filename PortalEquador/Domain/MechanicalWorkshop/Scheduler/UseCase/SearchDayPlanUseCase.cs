using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.UseCase
{
    public class SearchDayPlanUseCase(
        IMechanicalWorkshopSchedulerRepository mechanicalWorkshopSchedulerRepository,
        IAdminMechanicalWorkShopRepository adminRepository
        )
    {
        public async Task<SearchDayPlannerViewModel> Invoke(string licencePlate)
        {
            var model = await mechanicalWorkshopSchedulerRepository.SearchGetDayPlan(licencePlate);

            if (model.hasFullAccess == false)
            {
                var adminContracts = await adminRepository.GetUserContracts();
                var filtered = model.Interventions.Where(item => adminContracts.Any(contract => contract.ContractId == item.Contract.Id)).ToList();
                model.Interventions = filtered;
            }
            return model;
        }
    }
}
