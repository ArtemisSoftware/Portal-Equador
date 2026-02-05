using PortalEquador.Util;

namespace PortalEquador.Data.Administrator
{
    public class AdministratorUtil
    {
        public static bool HasFullAccess(string role)
        {
            if (role == Roles.Administrator)
            {
                return true;
            }
            return false;
        }
    }
}
