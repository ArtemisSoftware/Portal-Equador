using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MedicalExam.ViewModels
{
    public class MedicalExamDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public required string Extension { get; set; }

        [Display(Name = StringConstants.Display.DOCUMENT)]
        public GroupItemViewModel Exam { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }


        //public string PicturePath => ImagesUtil.GetFilePath(this);
        public string PicturePath => ImagesUtil.GetFilePath(PersonaInformationId, Exam.Id, Extension + "?v=123456");

    }
}
