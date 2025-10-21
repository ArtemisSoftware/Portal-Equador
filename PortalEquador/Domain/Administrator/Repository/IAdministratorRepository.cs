using Microsoft.AspNetCore.Identity;
using PortalEquador.Domain.Administrator.ViewModels;
using PortalEquador.Domain.Document.ViewModels;

namespace PortalEquador.Domain.Administrator.Repository
{
    public interface IAdministratorRepository
    {
        Task<List<AdministratorViewModel>> GetAll();
        Task<AdministratorCreateViewModel> GetCreateModel();
        Task<bool> EmailExistsAsync(string email);
        Task<IdentityResult> Save(AdministratorCreateViewModel model);
        Task<AdministratorResetPasswordViewModel> GetResetPasswordAdmin(string userId);
        Task<IdentityResult> ResetPasswordAsync(string userId, string newPassword);
        Task<AdministratorEditViewModel> GetAdmin(string userId);
        Task<IdentityResult> Update(AdministratorEditViewModel model);
        Task<IdentityResult> SetUserActiveStatus(string userId, bool isActive);
    }
}
