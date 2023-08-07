using PortalEquador.Constants;
using PortalEquador.Data.GroupTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.GroupTypes.ViewModels
{
    public class GroupItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.DESCRIPTION)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Description { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        [MaxLength(StringConstants.Lenght.LENGHT_140, ErrorMessage = StringConstants.Error.EXCEEDED_MAX_CHARACTERS_LENGHT)]
        public string? Observation { get; set; }

        public int GroupId { get; set; }

        public GroupViewModel? Group { get; set; }


        [Display(Name = StringConstants.Display.REGISTER_CREATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM)]
        public DateTime DateCreated { get; set; }

        [Display(Name = StringConstants.Display.REGISTER_LAST_UPDATE_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM)]
        public DateTime? DateModified { get; set; }

        public string? Error { get; set; }
    }
}
