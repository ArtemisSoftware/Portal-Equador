using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.StringConstants;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Extensions;
using NuGet.Packaging.Signing;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceDetailViewModel : DriversLicenceBaseViewModel
    {

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public required GroupItemViewModel Licence { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }

        public bool IsProvisional()
        {
            return Status != LicenceStatusType.Updated && ProvisionalExpirationDate != null;
        }

        public bool ShowRenewalOptions()
        {
            if (Status == LicenceStatusType.No_Expiration_Date)
            {
                return false;
            }
            else if (Status != LicenceStatusType.Updated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override DateTime? GetProvisionalExpirationDate()
        {
            return ProvisionalExpirationDate;
        }
    }
}