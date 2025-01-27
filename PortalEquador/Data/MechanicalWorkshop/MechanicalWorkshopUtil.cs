using PortalEquador.Util;

namespace PortalEquador.Data.MechanicalWorkshop
{
    public class MechanicalWorkshopUtil
    {
        public static bool HasFullAccess(string role)
        {
            if (role == Roles.Administrator || role == Roles.DataManager)
            {
                return true;
            }
            return false;
        }
    }
}
