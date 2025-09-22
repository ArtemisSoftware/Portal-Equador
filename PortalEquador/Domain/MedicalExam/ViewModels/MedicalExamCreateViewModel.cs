using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MedicalExam.ViewModels
{
    public class MedicalExamCreateViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; } = DateTime.Now;

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }


        [Display(Name = StringConstants.Display.EXAM)]
        [Required]
        public int ExamId { get; set; }

        public SelectList? Exams { get; set; }

        [Display(Name = StringConstants.Display.RESULT)]
        [Required]
        public int ResultId { get; set; }

        public SelectList? Results { get; set; }



        [Display(Name = StringConstants.Display.OPTIONAL_FILE)]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? PicturePath { get; set; }

    }
}
