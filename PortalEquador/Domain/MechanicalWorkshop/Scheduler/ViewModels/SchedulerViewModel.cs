using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels
{
    public class SchedulerViewModel : ViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        public DateOnly ScheduleDate { get; set; }

        public SchedulerType ScheduleType { get; set; } = SchedulerType.InSchedule;

        [Required]
        public int MechanicId { get; set; }

        [Display(Name = StringConstants.Display.MECHANIC)]
        public GroupItemViewModel? Mechanic { get; set; }

        [Required]
        public int InterventionTimeId { get; set; }

        [Display(Name = StringConstants.Display.SCHEDULE)]
        public GroupItemViewModel? InterventionTime { get; set; }


        [Display(Name = StringConstants.Display.VEHICLE)]
        [Required]
        public int VehicleId { get; set; }

        public VehicleViewModel? Vehicle { get; set; }

        public SelectList? Vehicles { get; set; }








        [Display(Name = StringConstants.Display.CONTRACT)]
        public string? Contract { get; set; }


        [Display(Name = StringConstants.Display.MODEL)]
        public string? Model { get; set; }

        [Display(Name = StringConstants.Display.SERVICE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Service { get; set; }


        [Display(Name = StringConstants.Display.TELEPHONE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Telephone { get; set; }

        [Display(Name = StringConstants.Display.CODE)]
        public string? Code { get; set; }

    }
}