using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.ProfessionalCompetence.ViewModels
{
    public class ProfessionalCompetenceViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }


        [Display(Name = StringConstants.Display.COMPETENCE)]
        [Required]
        public int CompetenceId { get; set; }

        public SelectList? Competences { get; set; }

    }
}