using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.UseCase
{
    public class SearchCarWashDayPlanUseCase(
        ICarWashSchedulerRepository carWashSchedulerRepository,
        IAdminMechanicalWorkShopRepository adminRepository
        )
    {
        public async Task<CarWashSearchDayPlannerViewModel> Invoke(string licencePlate)
        {
            var model = await carWashSchedulerRepository.SearchGetDayPlan(licencePlate);
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
