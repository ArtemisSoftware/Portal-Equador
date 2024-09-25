namespace PortalEquador.Util
{
    public static class DriverLicenceUtil
    {

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

        public static LicenceStatusType GetLicenceStatus(bool expirationDateAvailable, DateTime? expirationDate, DateTime? provisionalExpirationDate)
        {
            if (expirationDate  == null)
            //if (expirationDateAvailable == false)
            {
                return LicenceStatusType.No_Expiration_Date;
            }
            else if (expirationDate < DateTime.Now && provisionalExpirationDate == null)
            {
                return LicenceStatusType.Expired;
            }
            else if (expirationDate < DateTime.Now && provisionalExpirationDate < DateTime.Now)
            {
                return LicenceStatusType.Provisional_Renewal_Expired;
            }
            else if (expirationDate < DateTime.Now && provisionalExpirationDate > DateTime.Now)
            {
                return LicenceStatusType.Provisional_Renewal_Updated;
            }
            else if (expirationDate > DateTime.Now)
            {
                return LicenceStatusType.Updated;
            }
            return LicenceStatusType.Expired;
        }
    }
}
