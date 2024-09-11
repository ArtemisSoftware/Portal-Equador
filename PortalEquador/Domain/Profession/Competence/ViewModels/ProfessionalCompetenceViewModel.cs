using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Profession.Competence.ViewModels
{
    public class ProfessionalCompetenceViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.COMPETENCE)]
        [Required]
        public int CompetenceId { get; set; }

        public SelectList? Competences { get; set; }

    }
}