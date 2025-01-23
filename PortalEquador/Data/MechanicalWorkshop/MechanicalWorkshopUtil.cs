using PortalEquador.Util;

namespace PortalEquador.Data.MechanicalWorkshop
{
    public class MechanicalWorkshopUtil
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
