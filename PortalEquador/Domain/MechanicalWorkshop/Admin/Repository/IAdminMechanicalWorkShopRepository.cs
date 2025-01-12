using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.Repository
{
    public interface IAdminMechanicalWorkShopRepository : IGenericRepository<AdminMechanicalWorkShopContractEntity>
    {
        Task<AdminMechanicalWorkshopCreateViewModel> GetCreateModel();
        Task Save(AdminMechanicalWorkshopContractViewModel model);
        Task<List<AdminMechanicalWorkshopViewModel>> GetAdmins();
        Task DeleteContracts(int id);
    }
}