using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalEquador.Domain.MedicalExam.ViewModels
{
    public class MedicalExamEditViewModel : ViewModel
    {
        public int Id { get; set; }
        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.EXAM)]
        [Required]
        public int ExamId { get; set; }

        public SelectList? Exams { get; set; }

        [Display(Name = StringConstants.Display.RESULT)]
        [Required]
        public int ResultId { get; set; }

        public SelectList? Results { get; set; }
    }
}