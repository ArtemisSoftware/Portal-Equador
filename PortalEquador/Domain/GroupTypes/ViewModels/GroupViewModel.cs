using PortalEquador.Domain.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.GroupTypes.ViewModels
{
    public class GroupViewModel : ViewModel
    {
        public int Id { get; set; }

        //[Display(Name = StringConstants.Display.DESCRIPTION)]
        //[Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public required string Description { get; set; }

        //[Display(Name = StringConstants.Display.OBSERVATION)]
        //[MaxLength(StringConstants.Lenght.LENGHT_140, ErrorMessage = StringConstants.Error.EXCEEDED_MAX_CHARACTERS_LENGHT)]
        public string? Observation { get; set; }

    }
}
