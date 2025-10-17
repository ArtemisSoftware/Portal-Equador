using Microsoft.AspNetCore.Identity;
using PortalEquador.Domain.Administrator.ViewModels;
using PortalEquador.Domain.Document.ViewModels;

namespace PortalEquador.Domain.Administrator.Repository
{
    public interface IAdministratorRepository
    {
        Task<List<AdministratorViewModel>> GetAll();
        Task<IdentityResult> Save(AdministratorCreateViewModel model);
        Task<AdministratorEditViewModel> GetAdmin(string userId);
        Task<IdentityResult> Update(AdministratorEditViewModel model);
        Task<IdentityResult> SetUserActiveStatus(string userId, bool isActive);
    }
}
