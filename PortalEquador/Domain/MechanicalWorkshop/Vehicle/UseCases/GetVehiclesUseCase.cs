using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;

namespace PortalEquador.Domain.MechanicalWorkshop.Vehicle.UseCases
{
    public class GetVehiclesUseCase(
        IMechanicalWorkshopVehicleRepository vehicleRepository
     )
    {
        public SelectList Invoke()
        {
            return vehicleRepository.GetVehiclesSelectList();
        }
    }
}
