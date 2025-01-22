using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Data.Generic
{
    public class AdminUser
    {
        public string UserId { get; set; }

        [Display(Name = StringConstants.Display.FULL_NAME)]
        public string UserName { get; set; }

        [Display(Name = StringConstants.Display.ROLE)]
        public string Role { get; set; }
    }
}
