using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Data.MechanicalWorkshop;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels
{
    public class DayPlannerViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime MainTime { get; set; } = DateTime.Now;
        public List<WorkshopMechanicViewModel> Mechanics { get; set; }
        public List<GroupItemViewModel> Schedules { get; set; }
        public Dictionary<int, GroupItemViewModel> InterventionTimes { get; set; }
        public List<SchedulerViewModel> Interventions { get; set; }
        public Dictionary<int, List<SchedulerViewModel>> Appointements { get; set; } = new Dictionary<int, List<SchedulerViewModel>>();
        
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
                var registreisList = new List<SchedulerViewModel>();
                foreach (var mechanic in Mechanics)
                {
                    var intervention = Interventions
                         .Where(intervention => intervention.MechanicId == mechanic.Id && intervention.InterventionTimeId == schedule.Id)
                         .FirstOrDefault();

                    if (hasFullAccess)
                    {
                        registreisList.Add(GetAdminIntervention(intervention, mechanic, schedule));
                    }
                    else
                    {
                        registreisList.Add(GetUserIntervention(intervention, mechanic, schedule));
                    }
                }
                Appointements.Add(index, registreisList);
                ++index;
            }
        }

        private SchedulerViewModel GetAdminIntervention(SchedulerViewModel? model, WorkshopMechanicViewModel mechanic, GroupItemViewModel schedule)
        {
            SchedulerViewModel result;

            if (model != null)
            {
                return model;
            }
            else
            {
                if (mechanic.Active == false)
                {
                    return InactiveSchedule(mechanic, schedule);
                }
                result = FreeSchedule(mechanic, schedule);
            }

            if (Workshop.Active == false)
            {
                return InactiveSchedule(mechanic, schedule);
            }

            return result;
        }

        private SchedulerViewModel GetUserIntervention(SchedulerViewModel? model, WorkshopMechanicViewModel mechanic, GroupItemViewModel schedule)
        {
            var result = model;

            switch (GetSchedulerType(model))
            {
                case SchedulerType.Free:
                    result = FreeSchedule(mechanic, schedule);
                    break;

                case SchedulerType.InSchedule:
                    result = model;
                    break;

                case SchedulerType.Blocked:
                    result = BlockedSchedule(mechanic, schedule);
                    break;

                default:
                    result = model;
                    break;
            }

            if(result.ScheduleType != SchedulerType.InSchedule && (mechanic.Active == false || Workshop.Active == false))
            {
                result = InactiveSchedule(mechanic, schedule);
            }

            return result;
        }

        private SchedulerType GetSchedulerType(SchedulerViewModel? model)
        {
            if (model == null)
            {
                return SchedulerType.Free;
            }
            else
            {
                if (AdminContracts.Any(item => model.Contract.Id == item.ContractId))
                {
                    return SchedulerType.InSchedule;
                }
                else
                {
                    return SchedulerType.Blocked;
                }
            }

        }

        private SchedulerViewModel FreeSchedule(WorkshopMechanicViewModel mechanic, GroupItemViewModel schedule)
        {
            return new SchedulerViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = SchedulerType.Free,
                Mechanic = mechanic,
                InterventionTime = schedule
            };
        }

        private SchedulerViewModel BlockedSchedule(WorkshopMechanicViewModel mechanic, GroupItemViewModel schedule)
        {
            return new SchedulerViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = SchedulerType.Blocked,
                Mechanic = mechanic,
                InterventionTime = schedule
            };
        }

        private SchedulerViewModel InactiveSchedule(WorkshopMechanicViewModel mechanic, GroupItemViewModel schedule)
        {
            return new SchedulerViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = SchedulerType.InactiveMechanic,
                Mechanic = mechanic,
                InterventionTime = schedule
            };
        }

    }
}