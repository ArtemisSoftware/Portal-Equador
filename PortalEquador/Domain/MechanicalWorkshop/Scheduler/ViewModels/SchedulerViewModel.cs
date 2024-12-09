using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels
{
    public class SchedulerViewModel : ViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        public DateOnly ScheduleDate { get; set; }


        private SchedulerType _scheduleType = SchedulerType.InSchedule;
        public SchedulerType ScheduleType
        {
            get
            {
                if (ScheduleDate < TimeUtil.DateOnlyCurrent() && _scheduleType == SchedulerType.Free)
                {
                    return SchedulerType.BlockedFree;
                }
                else if (ScheduleDate < TimeUtil.DateOnlyCurrent() && _scheduleType == SchedulerType.InSchedule)
                {
                    return SchedulerType.BlockedDateInThePast;
                }
                else
                {
                    return _scheduleType;
                }

            }
            set
            {
                _scheduleType  = value;
            }
        }

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

        public GroupItemViewModel? Contract { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT)]
        public string? ContractDescription { get; set; }


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

        public int CurrentState { get; set; } = SchedulerState.Open;

        public string StatusDescription
        {
            get
            {
                var description = "";

                switch (CurrentState)
                {
                    case SchedulerState.Open:
                        description = "";
                        break;

                    case SchedulerState.NotPerformed:
                        description = StringConstants.SchedulerStatus.NOT_PERFORMED;
                        break;

                    case SchedulerState.Performed:
                        description = StringConstants.SchedulerStatus.PERFORMED;
                        break;

                    default:
                        description = "";
                        break;
                }

                return description;
            }
        }
    }
}