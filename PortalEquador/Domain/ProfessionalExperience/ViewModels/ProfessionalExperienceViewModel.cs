using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.ProfessionalExperience.ViewModels
{
    public class ProfessionalExperienceViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        public int Years { get; set; }

        public int Months { get; set; }

        [Display(Name = StringConstants.Display.COMPANY)]
        [Required]
        public int CompanyId { get; set; }

        public SelectList? Companies { get; set; }

        [Display(Name = StringConstants.Display.WORKSTATION)]
        [Required]
        public int WorkstationId { get; set; }

        public SelectList? Workstations { get; set; }

    }
}