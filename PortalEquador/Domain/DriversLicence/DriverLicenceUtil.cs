using PortalEquador.Constants;

namespace PortalEquador.Domain.DriversLicence
{
    public class DriverLicenceUtil
    {

        public static List<int> DocumentIds()
        {
            List<int> documentsId = new List<int>();
            documentsId.Add(ItemFromGroup.Documents.DRIVERS_LICENCE);
            documentsId.Add(ItemFromGroup.Documents.PROVISIONAL_DRIVERS_LICENCE);

            return documentsId;
        }

        public static bool ExpirationDateAvailable(DateTime? expirationDate)
        {
                if (expirationDate == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }

        public static LicenceStatus GetLicenceStatus(bool expirationDateAvailable, DateTime? expirationDate, DateTime? provisionalExpirationDate)
        {

            if (expirationDateAvailable == false)
            {
                return LicenceStatus.No_Expiration_Date;
            }
            else if (expirationDate < DateTime.Now && provisionalExpirationDate == null)
            {
                return LicenceStatus.Expired;
            }
            else if (expirationDate < DateTime.Now && provisionalExpirationDate < DateTime.Now)
            {
                return LicenceStatus.Provisional_Renewal_Expired;
            }
            else if (expirationDate < DateTime.Now && provisionalExpirationDate > DateTime.Now)
            {
                return LicenceStatus.Provisional_Renewal_Updated;
            }
            else if (expirationDate > DateTime.Now)
            {
                return LicenceStatus.Updated;
            }
            return LicenceStatus.Expired;
        }

    }
}
