using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceRenewViewModel : DriversLicenceBaseViewModel
    {
        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE)]
        public required GroupItemViewModel Licence { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }

        public override DateTime? GetProvisionalExpirationDate()
        {
            return ProvisionalExpirationDate;
        }
    }
}
