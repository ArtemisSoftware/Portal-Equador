using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Administrator.ViewModels
{
    public class AdministratorResetPasswordViewModel
    {
        public string Id { get; set; }

        [Display(Name = StringConstants.Display.NAME)]
        public string UserName { get; set; }

        [Display(Name = StringConstants.Display.EMAIL)]
        public string Email { get; set; }

        [Display(Name = StringConstants.Display.PASSWORD)]
        [Required]
        public string Password { get; set; }
    }
}
