using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Data.PInformation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.Models.DriversLicence
{
    public class DriversLicenceCreateViewModel
    {
        public int CurriculumId { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        [Required]
        public int GroupItemId { get; set; }

        public SelectList? LicenceTypes { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [NotMapped]
        public bool ExpirationDateAvailable { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [NotMapped]
        public ProfileInformation? Profile { get; set; }
    }
}
