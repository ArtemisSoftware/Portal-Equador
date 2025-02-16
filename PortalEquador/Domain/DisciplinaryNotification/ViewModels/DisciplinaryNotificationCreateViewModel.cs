using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.DisciplinaryNotification.ViewModels
{
    public class DisciplinaryNotificationCreateViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        [Display(Name = StringConstants.Display.LOCAL)]
        public string? Local { get; set; }

        [Display(Name = StringConstants.Display.DECISION)]
        public string? Decision { get; set; }

        [Display(Name = StringConstants.Display.NOTIFICATION)]
        [Required]
        public int NotificationId { get; set; }

        public SelectList? Notifications { get; set; }

        [Display(Name = StringConstants.Display.ACCIDENT_LEVEL)]
        [Required]
        public int AccidentLevelId { get; set; }

        public SelectList? AccidentLevels { get; set; }





        public string? Extension { get; set; }

        [Display(Name = StringConstants.Display.FILE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FILE)]
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string? PicturePath { get; set; }
    }
}
