using NuGet.Packaging.Signing;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Trainning.ViewModels
{
    public class TrainningDetailViewModel : ViewModel
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

        [Display(Name = StringConstants.Display.TRAINNING)]
        public GroupItemViewModel? Trainning { get; set; }


        public string PicturePath => ImagesUtil.GetFilePath(PersonaInformationId, Trainning.Id, Extension, true);
    }
}