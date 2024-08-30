using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels
{
    public class VehicleDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.LICENCE_PLATE)]
        public string LicencePlate { get; set; }

        [Display(Name = StringConstants.Display.MODEL)]
        public string Model { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public bool Active { get; set; }


        [Display(Name = StringConstants.Display.CONTRACT_IN_USE)]
        public GroupItemViewModel Contract { get; set; }
    }
}
