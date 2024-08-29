using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Document.ViewModels
{
    public class DocumentDetailViewModel: ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public required string Extension { get; set; }

        [Display(Name = StringConstants.Display.DOCUMENT)]
        public GroupItemViewModel Document { get; set; }

        public string PicturePath
        {
            get
            {
                return ImagesUtil.GetFilePath(PersonaInformationId, Document.Id, Extension + "?v=123456");
            }
        }
    }
}
