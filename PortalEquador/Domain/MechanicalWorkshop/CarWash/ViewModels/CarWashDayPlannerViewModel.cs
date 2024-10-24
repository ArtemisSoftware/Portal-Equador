using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels
{
    public class CarWashDayPlannerViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime MainTime { get; set; } = DateTime.Now;

        public List<CarWashViewModel> Interventions { get; set; }

        public List<GroupItemViewModel> Schedules { get; set; }

        public Dictionary<int, GroupItemViewModel> InterventionTimes { get; set; }

        public Dictionary<int, List<CarWashViewModel>> Appointements { get; set; } = new Dictionary<int, List<CarWashViewModel>>();

        public void OrderAppointements()
        {
            var index = 0;

            foreach (var schedule in Schedules)
            {
                var registreisList = new List<CarWashViewModel>();

                var res = Interventions
                         .Where(intervention => intervention.InterventionTimeId == schedule.Id)
                         .FirstOrDefault();

                if (res != null)
                {
                    registreisList.Add(res);
                }
                else
                {
                    registreisList.Add(FreeSchedule(schedule));
                }

                Appointements.Add(index, registreisList);
                ++index;
            }
        }

        private CarWashViewModel FreeSchedule(GroupItemViewModel schedule)
        {
            return new CarWashViewModel
            {
                Id = -1,
                ScheduleDate = TimeUtil.ToDateOnly(MainTime),
                ScheduleType = CarWashSchedulerType.Free,
                InterventionTime = schedule,
                InterventionTimeId = schedule.Id
            };
        }
    }
}
