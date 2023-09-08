using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.Documents.ViewModels
{
    public class DocumentViewModel :ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        public string? Observation { get; set; }

        public string? Extension { get; set; }


        [Display(Name = StringConstants.Display.DOCUMENT)]
        [Required]
        public int DocumentTypeId { get; set; }

        public SelectList? DocumentTypes { get; set; }

        [Display(Name = StringConstants.Display.FILE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FILE)]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
