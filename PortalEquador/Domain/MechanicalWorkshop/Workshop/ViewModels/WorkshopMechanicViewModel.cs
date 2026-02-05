using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels
{
    public class WorkshopMechanicViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.NAME)]
        public string Name { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public bool Active { get; set; } = true;
    }
}
