using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels
{
    public class WorkshopDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.WORKSHOP)]
        public string Name { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public bool Active { get; set; } = true;

        [Display(Name = StringConstants.Display.NUMBER_OF_LANES)]
        public List<WorkshopLaneViewModel> Lanes { get; set; } = new List<WorkshopLaneViewModel>();

        [Display(Name = StringConstants.Display.NUMBER_OF_MECHANICS)]
        public List<WorkshopMechanicViewModel> Mechanics { get; set; } = new List<WorkshopMechanicViewModel>();
    }
}
