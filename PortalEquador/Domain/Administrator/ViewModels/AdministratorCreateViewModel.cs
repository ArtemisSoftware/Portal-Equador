using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Administrator.ViewModels
{
    public class AdministratorCreateViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.NAME)]
        public string FirstName { get; set; }

        [Display(Name = StringConstants.Display.SURNAME)]
        public string LastName { get; set; }

        [Display(Name = StringConstants.Display.PASSWORD)]
        public string Password { get; set; }

        [Display(Name = StringConstants.Display.EMAIL)]
        public string Email { get; set; }

        public string RoleId { get; set; }

        [Display(Name = StringConstants.Display.ROLE)]
        public SelectList Roles { get; set; }
    }
}
