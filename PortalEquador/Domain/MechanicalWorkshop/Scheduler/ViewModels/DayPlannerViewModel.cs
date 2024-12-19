using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

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


        public void OrderAppointements()
        {
            var index = 1;

            foreach (var schedule in Schedules)
            {
                var registreisList = new List<SchedulerViewModel>();
                foreach (var mechanic in Mechanics)
                {
                    var res = Interventions
                         .Where(intervention => intervention.MechanicId == mechanic.Id && intervention.InterventionTimeId == schedule.Id)
                         .FirstOrDefault();

                    if (res != null)
                    {
                        registreisList.Add(res);
                    }
                    else
                    {
                        registreisList.Add(FreeSchedule(mechanic, schedule));
                    }
                }
                Appointements.Add(index, registreisList);
                ++index;
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

    }
}