using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Accident.ViewModels
{
    public class AccidentDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.NUMBER)]
        public int Number { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM, ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = StringConstants.Display.LICENCE_PLATE)]
        public VehicleDetailViewModel Vehicle { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT)]
        public GroupItemViewModel Contract { get; set; }

        public string Address { get; set; }

        [Display(Name = StringConstants.Display.CITY)]
        public GroupItemViewModel City { get; set; }

        [Display(Name = StringConstants.Display.ESTIMATED_VALUE)]
        public GroupItemViewModel EstimatedValue { get; set; }

        [Display(Name = StringConstants.Display.HUMAN_DAMAGE)]
        public int HumanDamage { get; set; }

        [Display(Name = StringConstants.Display.ACCIDENT_LEVEL)]
        public GroupItemViewModel Level { get; set; }

        public List<AccidentCauseViewModel> Causes { get; set; } = new List<AccidentCauseViewModel>();
    }
}