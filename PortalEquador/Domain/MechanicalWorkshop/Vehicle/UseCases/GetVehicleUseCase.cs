using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Vehicle.UseCases
{
    public class GetVehicleUseCase(
        IMechanicalWorkshopVehicleRepository vehicleRepository
     )
    {
        public async Task<VehicleDetailViewModel> Invoke(int vehicleId)
        {
            return await vehicleRepository.GetVehicleDetail(vehicleId);
        }
    }
}