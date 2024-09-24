using PortalEquador.Util.Constants;
using System.ComponentModel;

namespace PortalEquador.Util
{
    public enum LicenceStatusType
    {
        [Description(StringConstants.LicenceStatus.NO_EXPIRATION_DATE)]
        No_Expiration_Date,

        [Description(StringConstants.LicenceStatus.UPDATED)]
        Updated,

        [Description(StringConstants.LicenceStatus.EXPIRED)]
        Expired,

        [Description(StringConstants.LicenceStatus.PROVISIONAL_UPDATED)]
        Provisional_Renewal_Updated,

        [Description(StringConstants.LicenceStatus.PROVISIONAL_EXPIRED)]
        Provisional_Renewal_Expired,
    }
}
