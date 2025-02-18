using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.Trainning.ViewModels
{
    public class TrainningCreateViewModel : ViewModel
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

        [Display(Name = StringConstants.Display.TRAINNING_NATURE)]
        public string? Nature { get; set; }

        [Display(Name = StringConstants.Display.TRAINNING)]
        [Required]
        public int TrainningId { get; set; }

        public SelectList? Trainnings { get; set; }





        public string? Extension { get; set; }

        [Display(Name = StringConstants.Display.OPTIONAL_FILE)]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? PicturePath { get; set; }
    }
}
