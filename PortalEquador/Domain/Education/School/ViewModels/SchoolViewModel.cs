using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Education.School.ViewModels
{
    public class SchoolViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }


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