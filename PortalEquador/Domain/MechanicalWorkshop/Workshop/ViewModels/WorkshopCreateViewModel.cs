using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels
{
    public class WorkshopCreateViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.WORKSHOP)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public required string Name { get; set; }

        [Display(Name = StringConstants.Display.NUMBER_OF_LANES)]
        public int NumberOfLanes { get; set; } = 1;

        [Display(Name = StringConstants.Display.NUMBER_OF_MECHANICS)]
        public int NumberOfMechanics { get; set; } = 1;
    }
}
