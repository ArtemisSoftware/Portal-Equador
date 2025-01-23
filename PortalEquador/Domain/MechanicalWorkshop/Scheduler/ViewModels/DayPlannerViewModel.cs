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

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels
{
    public class DayPlannerViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime MainTime { get; set; } = DateTime.Now;
        public List<GroupItemViewModel> Mechanics { get; set; }
        public List<GroupItemViewModel> Schedules { get; set; }
        public Dictionary<int, GroupItemViewModel> InterventionTimes { get; set; }
        public List<SchedulerViewModel> Interventions { get; set; }
        public Dictionary<int, List<SchedulerViewModel>> Appointements { get; set; } = new Dictionary<int, List<SchedulerViewModel>>();
        
        public List<AdminMechanicalWorkshopContractViewModel> AdminContracts { get; set; } = new List<AdminMechanicalWorkshopContractViewModel>();
        public bool hasFullAccess { get; set; } = false;

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

        private SchedulerViewModel GetAdminIntervention(SchedulerViewModel? model, GroupItemViewModel mechanic, GroupItemViewModel schedule)
        {
            if (model != null)
            {
                return model;
            }
            else
            {
                return FreeSchedule(mechanic, schedule);
            }
        }

        private SchedulerViewModel GetUserIntervention(SchedulerViewModel? model, GroupItemViewModel mechanic, GroupItemViewModel schedule)
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

        private SchedulerViewModel FreeSchedule(GroupItemViewModel mechanic, GroupItemViewModel schedule)
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

        private SchedulerViewModel BlockedSchedule(GroupItemViewModel mechanic, GroupItemViewModel schedule)
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

    }
}