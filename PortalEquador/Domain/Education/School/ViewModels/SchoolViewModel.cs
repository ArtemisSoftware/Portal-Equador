using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
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
        public GroupItemViewModel? Institution { get; set; }

        [Display(Name = StringConstants.Display.COURSE)]
        public GroupItemViewModel? Major { get; set; }
        
        [Display(Name = StringConstants.Display.DEGREE)]
        public GroupItemViewModel? Degree { get; set; }




        [Display(Name = StringConstants.Display.INSTITUTION)]
        [Required]
        public int InstitutionId { get; set; }

        public SelectList? Institutions { get; set; }

        [Display(Name = StringConstants.Display.COURSE)]
        [Required]
        public int? MajorId { get; set; }

        public SelectList? Majors { get; set; }

        [Display(Name = StringConstants.Display.MAJOR_UNVAILABLE)]
        public bool MajorNotDeclared { get; set; } = false;


        [Display(Name = StringConstants.Display.DEGREE)]
        [Required]
        public int DegreeId { get; set; }

        public SelectList? Degrees { get; set; }
    }
}