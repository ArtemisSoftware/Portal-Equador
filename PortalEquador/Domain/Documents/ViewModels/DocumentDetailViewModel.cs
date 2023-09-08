using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.Documents.ViewModels
{
    public class DocumentDetailViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public string Extension { get; set; }

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
