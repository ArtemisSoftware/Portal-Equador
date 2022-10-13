using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Models.Documents
{
    public class DocumentCreateViewModel
    {

        public int CurriculumId { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required]
        public int GroupItemId { get; set; }

        public SelectList? DocumentTypes { get; set; }

        [Display(Name = "dfgdfgd")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }


        /*
        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        */

        /*
        [Display(Name = "Request Comments")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date Must Be Before End Date", new[] { nameof(StartDate), nameof(EndDate) });
            }

            if (RequestComments?.Length > 250)
            {
                yield return new ValidationResult("Comments are too long", new[] { nameof(RequestComments) });
            }
        }
        */
    }
}
