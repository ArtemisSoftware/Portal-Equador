using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.Models.DriversLicence
{
    public class DriversLicenceCreateViewModel
    {
        public int CurriculumId { get; set; }

        [Display(Name = "Carta de condução")]
        [Required]
        public int GroupItemId { get; set; }

        public SelectList? LicenceTypes { get; set; }

        [Display(Name = "Data de expiração")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
