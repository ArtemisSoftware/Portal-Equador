using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;

namespace PortalEquador.Domain.Document.ViewModels
{
    public class DocumentViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public string? Extension { get; set; }


        [Display(Name = StringConstants.Display.DOCUMENT)]
        [Required]
        public int DocumentTypeId { get; set; }

        public SelectList? DocumentTypes { get; set; }
        public GroupItemViewModel? DocumentType { get; set; }

        [Display(Name = StringConstants.Display.FILE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FILE)]
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int? SubTypeId { get; set; }
        public GroupItemViewModel? SubType { get; set; }
        public int? ParentId { get; set; }

        //public string PicturePath => ImagesUtil.GetFileFullPath(this);
        public string? PicturePath { get; set; }
    }
}
