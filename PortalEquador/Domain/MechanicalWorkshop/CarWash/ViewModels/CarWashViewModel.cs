﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels
{
    public class CarWashViewModel : ViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        public DateOnly ScheduleDate { get; set; }


        [Required]
        public int LaneId { get; set; }

        [Display(Name = StringConstants.Display.LANE)]
        public GroupItemViewModel? Lane { get; set; }



        [Required]
        public int InterventionTimeId { get; set; }

        [Display(Name = StringConstants.Display.SCHEDULE)]
        public GroupItemViewModel? InterventionTime { get; set; }


        [Display(Name = StringConstants.Display.VEHICLE)]
        [Required]
        public int VehicleId { get; set; }
        public VehicleViewModel? Vehicle { get; set; }
        public SelectList? Vehicles { get; set; }



        private CarWashSchedulerType _scheduleType = CarWashSchedulerType.InSchedule;
        public CarWashSchedulerType ScheduleType
        {
            get
            {
                if (ScheduleDate < TimeUtil.DateOnlyCurrent() && _scheduleType == CarWashSchedulerType.Free)
                {
                    return CarWashSchedulerType.BlockedFree;
                }
                else if (ScheduleDate < TimeUtil.DateOnlyCurrent() && _scheduleType == CarWashSchedulerType.InSchedule)
                {
                    return CarWashSchedulerType.BlockedDateInThePast;
                }
                else
                {
                    return _scheduleType;
                }
            }
            set
            {
                _scheduleType = value;
            }
        }


        public GroupItemViewModel? Contract { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT)]
        public string? ContractDescription { get; set; }


        [Display(Name = StringConstants.Display.MODEL)]
        public string? Model { get; set; }


        public int CurrentState { get; set; } = CarWashState.Open;

        public string StatusDescription
        {
            get
            {
                var description = "";

                switch (CurrentState)
                {
                    case CarWashState.Open:
                        description = "";
                        break;

                    case CarWashState.NotPerformed:
                        description = StringConstants.CarWashStatus.NOT_PERFORMED;
                        break;

                    case CarWashState.Performed:
                        description = StringConstants.CarWashStatus.PERFORMED;
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
