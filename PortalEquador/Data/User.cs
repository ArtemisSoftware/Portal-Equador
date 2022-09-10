using Microsoft.AspNetCore.Identity;

namespace PortalEquador.Data
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
