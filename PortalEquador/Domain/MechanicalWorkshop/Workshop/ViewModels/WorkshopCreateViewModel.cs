using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels
{
    public class WorkshopCreateViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.DESCRIPTION)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public required string Description { get; set; }

        [Display(Name = StringConstants.Display.NUMBER_OF_LANES)]
        public int NumberOfLanes { get; set; }
    }
}
