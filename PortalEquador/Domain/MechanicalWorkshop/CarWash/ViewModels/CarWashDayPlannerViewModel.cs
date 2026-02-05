using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels
{
    public class CarWashDayPlannerViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime MainTime { get; set; } = DateTime.Now;
        public List<CarWashViewModel> Interventions { get; set; }
        public List<WorkshopLaneViewModel> Lanes { get; set; }
        public List<GroupItemViewModel> Schedules { get; set; }
        public Dictionary<int, GroupItemViewModel> InterventionTimes { get; set; }
        public Dictionary<int, List<CarWashViewModel>> Appointements { get; set; } = new Dictionary<int, List<CarWashViewModel>>();

        public List<AdminMechanicalWorkshopContractViewModel> AdminContracts { get; set; } = new List<AdminMechanicalWorkshopContractViewModel>();
        public bool hasFullAccess { get; set; } = false;

        public int WorkshopId { get; set; } 
        public string WorkshopName { get; set; }

        public WorkshopViewModel Workshop { get; set; }

        public void OrderAppointements()
        {

            var index = 1;

            foreach (var schedule in Schedules)
            {
                var registreisList = new List<CarWashViewModel>();
                foreach (var lane in Lanes)
                {
                    var intervention = Interventions
                         .Where(intervention => intervention.LaneId == lane.Id && intervention.InterventionTimeId == schedule.Id)
                         .FirstOrDefault();

                    if (hasFullAccess)
                    {
                        registreisList.Add(GetAdminIntervention(intervention, lane, schedule));
                    }
                    else
                    {
                        registreisList.Add(GetUserIntervention(intervention, lane, schedule));
                    }

                }
                Appointements.Add(index, registreisList);
                ++index;
            }

        }

        private CarWashViewModel GetAdminIntervention(CarWashViewModel? model, WorkshopLaneViewModel lane, GroupItemViewModel schedule)
        {
            CarWashViewModel result;

            if (model != null)
            {
                return model;
            }
            else
            {
                if (lane.Active == false)
                {
                    return InactiveSchedule(lane, schedule);
                }
                result =  FreeSchedule(lane, schedule);
            }

            if (Workshop.Active == false)
            {
                return InactiveSchedule(lane, schedule);
            }

            return result;
        }

        private CarWashViewModel GetUserIntervention(CarWashViewModel? model, WorkshopLaneViewModel lane, GroupItemViewModel schedule)
        {
            var result = model;

            switch (GetSchedulerType(model))
            {
                case CarWashSchedulerType.Free:
                    result = FreeSchedule(lane, schedule);
                    break;

                case CarWashSchedulerType.InSchedule:
                    result = model;
                    break;

                case CarWashSchedulerType.Blocked:
                    result = BlockSchedule(lane, schedule);
                    break;

                default:
                    result = model;
                    break;
            }

            if(model.ScheduleType != CarWashSchedulerType.InSchedule && (lane.Active == false || Workshop.Active == false))
            {
                result = InactiveSchedule(lane, schedule);
            }

            return result;
        }



        private CarWashSchedulerType GetSchedulerType(CarWashViewModel? model)
        {
            if (model == null)
            {
                return CarWashSchedulerType.Free;
            }
            else
            {
                if (AdminContracts.Any(item => model.Contract.Id == item.ContractId))
                {
                    return CarWashSchedulerType.InSchedule;
                }
                else
                {
                    return CarWashSchedulerType.Blocked;
                }
            }

        }

        private CarWashViewModel FreeSchedule(WorkshopLaneViewModel lane, GroupItemViewModel schedule)
        {
            return new CarWashViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = CarWashSchedulerType.Free,
                InterventionTime = schedule,
                InterventionTimeId = schedule.Id,
                Lane = lane,
            };
        }

        private CarWashViewModel BlockSchedule(WorkshopLaneViewModel lane, GroupItemViewModel schedule)
        {
            return new CarWashViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = CarWashSchedulerType.Blocked,
                InterventionTime = schedule,
                InterventionTimeId = schedule.Id,
                Lane = lane,
            };
        }

        private CarWashViewModel InactiveSchedule(WorkshopLaneViewModel lane, GroupItemViewModel schedule)
        {
            return new CarWashViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = CarWashSchedulerType.InactiveLane,
                InterventionTime = schedule,
                InterventionTimeId = schedule.Id,
                Lane = lane,
            };
        }


        private List<CarWashViewModel> NoSchedules()
        {
            var interventions = new List<CarWashViewModel>();

            foreach (var schedule in Schedules)
            {
                foreach (var lane in Lanes)
                {
                    interventions.Add(FreeSchedule(lane, schedule));
                }
            }

            return interventions;
        }

    }
}
