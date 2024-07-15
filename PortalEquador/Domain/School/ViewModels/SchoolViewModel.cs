using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.School.ViewModels
{
    public class SchoolViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.INSTITUTION)]
        [Required]
        public int InstitutionId { get; set; }

        public SelectList? Institutions { get; set; }


        [Display(Name = StringConstants.Display.DEGREE)]
        [Required]
        public int DegreeId { get; set; }

        public SelectList? Degrees { get; set; }
    }
}
