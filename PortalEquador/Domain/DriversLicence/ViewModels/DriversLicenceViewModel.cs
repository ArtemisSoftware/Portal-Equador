using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.StringConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Util;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceViewModel : DriversLicenceBaseViewModel
    {

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }



        public SelectList? LicenceTypes { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE)]
        public GroupItemViewModel? Licence { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }

        public bool ExpirationDateSelection { get; set; } = false;

        public bool ExpirationDateAvailable { get { return DriverLicenceUtil.ExpirationDateAvailable(ExpirationDate); } }


        [Display(Name = StringConstants.Display.FILE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FILE)]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }



        public bool HasProvisionalLicence => ProvisionalExpirationDate != null;

        public override DateTime? GetProvisionalExpirationDate()
        {
            return ProvisionalExpirationDate;
        }

    }
}