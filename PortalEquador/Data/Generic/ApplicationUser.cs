using Microsoft.AspNetCore.Identity;

namespace PortalEquador.Data.Generic
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
