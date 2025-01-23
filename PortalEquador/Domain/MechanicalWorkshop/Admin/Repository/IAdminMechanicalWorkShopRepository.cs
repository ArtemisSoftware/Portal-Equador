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
        Task<List<AdminMechanicalWorkshopViewModel>> GetAdmins();
        Task<AdminMechanicalWorkshopCreateViewModel> GetCreateModel();
        Task<AdminMechanicalWorkshopCreateViewModel> GetCreateModel(AdminMechanicalWorkshopCreateViewModel model);
        Task<AdminMechanicalWorkshopViewModel> RecoverModel(AdminMechanicalWorkshopViewModel model);

        Task Save(AdminMechanicalWorkshopCreateViewModel model);
        Task Save(AdminMechanicalWorkshopViewModel model);
        Task<AdminMechanicalWorkshopViewModel> GetAdmin(string userId);
        Task DeleteContracts(string userId);
    }
}