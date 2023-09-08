using PortalEquador.Constants;
using PortalEquador.Data.GroupTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.GroupTypes.ViewModels
{
    public class GroupItemViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.DESCRIPTION)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Description { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        [MaxLength(StringConstants.Lenght.LENGHT_140, ErrorMessage = StringConstants.Error.EXCEEDED_MAX_CHARACTERS_LENGHT)]
        public string? Observation { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public bool Active { get; set; } = true;

        public int GroupId { get; set; }

        public GroupViewModel? Group { get; set; }


    }
}
