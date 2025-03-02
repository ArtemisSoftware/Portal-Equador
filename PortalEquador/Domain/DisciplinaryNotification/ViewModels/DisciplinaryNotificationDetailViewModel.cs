using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.DisciplinaryNotification.ViewModels
{
    public class DisciplinaryNotificationDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }


        public required string Extension { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = StringConstants.Display.NOTIFICATION)]
        public GroupItemViewModel? Notification { get; set; }

        [Display(Name = StringConstants.Display.ACCIDENT_LEVEL)]
        public GroupItemViewModel? AccidentLevel { get; set; }

        [Display(Name = StringConstants.Display.TRAINNING_NATURE)]
        public string? Nature { get; set; }

        [Display(Name = StringConstants.Display.TEST_RESULT)]
        public GroupItemViewModel? AlcoolTestResult { get; set; }


        public string PicturePath => ImagesUtil.GetFilePath(PersonaInformationId, Notification.Id, Extension + "?v=123456");
    }
}