using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.DisciplinaryNotification.ViewModels
{
    public class DisciplinaryNotificationViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = StringConstants.Display.NOTIFICATION)]
        public GroupItemViewModel? Notification { get; set; }

        [Display(Name = StringConstants.Display.LOCAL)]
        public string? Local { get; set; }

        [Display(Name = StringConstants.Display.ACCIDENT_LEVEL)]
        public GroupItemViewModel? AccidentLevel { get; set; }

        [Display(Name = StringConstants.Display.DECISION)]
        public string? Decision { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        [Display(Name = StringConstants.Display.FILE)]
        public string? PicturePath { get; set; }
    }
}
