using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.Administrator.ViewModels
{
    public class AdministratorCreateViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.NAME)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = StringConstants.Display.SURNAME)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = StringConstants.Display.PASSWORD)]
        [Required]
        public string Password { get; set; }

        [Display(Name = StringConstants.Display.EMAIL)]
        [Required]
        public string Email { get; set; }

        [Display(Name = StringConstants.Display.ROLE)]
        public string RoleId { get; set; }


        public SelectList? Roles { get; set; }
    }
}
