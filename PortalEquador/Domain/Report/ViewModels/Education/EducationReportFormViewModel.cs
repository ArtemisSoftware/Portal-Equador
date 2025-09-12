using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Report.ViewModels.Education
{
    public class EducationReportFormViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.ACADEMIC_HABILITATION)]
        [Required]
        public int EducationId { get; set; }

        public SelectList? Educations { get; set; }
    }
}