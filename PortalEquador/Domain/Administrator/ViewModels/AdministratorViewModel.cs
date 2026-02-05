using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Administrator.ViewModels
{
    public class AdministratorViewModel
    {
        public string Id { get; set; }

        [Display(Name = StringConstants.Display.NAME)]
        public string UserName { get; set; }

        [Display(Name = StringConstants.Display.EMAIL)]
        public string Email { get; set; }

        [Display(Name = StringConstants.Display.ROLE)]
        public string Role { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public bool Active { get; set; }

        [Display(Name = StringConstants.Display.PASSWORD)]
        public string Password { get; set; }
    }
}
