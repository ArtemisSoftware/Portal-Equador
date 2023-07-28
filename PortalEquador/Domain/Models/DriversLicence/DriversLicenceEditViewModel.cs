using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.Models.DriversLicence
{
    public class DriversLicenceEditViewModel
    {
        public int CurriculumId { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        public DateTime? ExpirationDate { get; set; }

        [NotMapped]
        public bool ExpirationDateAvailable { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        [Required]
        public int GroupItemId { get; set; }

        public SelectList? LicenceTypes { get; set; }

    }
}
