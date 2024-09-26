using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Util.Extensions;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceProvisionalViewModel : DriversLicenceBaseViewModel
    {

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }



        [Display(Name = StringConstants.Display.DRIVERS_LICENCE)]
        public GroupItemViewModel? Licence { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }


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