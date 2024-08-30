using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository
{
    public interface IMechanicalWorkshopVehicleRepository : IGenericRepository<MechanicalWorkshopVehicleEntity>
    {
        Task<List<VehicleDetailViewModel>> GetVehicles();
        Task<VehicleViewModel> GetCreateModel(VehicleViewModel? model);
        Task<bool> LicencePlateExists(string licencePlate);
        Task Save(VehicleViewModel item);

        Task<VehicleViewModel> GetVehicle(int id);
        Task<VehicleDetailViewModel> GetVehicleDetail(int id);

        Task UpdateState(int vehicleId, bool isActive);
    }
}
