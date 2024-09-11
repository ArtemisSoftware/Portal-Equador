using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Profession.Experience.ViewModels
{
    public class ProfessionalExperienceViewModel : ViewModel
    {
        public int Id { get; set; }

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