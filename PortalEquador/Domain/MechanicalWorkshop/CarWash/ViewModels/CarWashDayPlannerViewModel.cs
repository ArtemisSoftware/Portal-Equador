using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.Collections.Generic;
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
        public Dictionary<int, List<GroupItemViewModel>> SchedulesPerDayPart() {

            int middleIndex = (Schedules.Count + 1) / 2;
            var dayParts =  new Dictionary<int, List<GroupItemViewModel>> ();

            List <GroupItemViewModel> firstHalf = Schedules.GetRange(0, middleIndex);
            List<GroupItemViewModel> secondHalf = Schedules.GetRange(middleIndex, Schedules.Count - middleIndex);
            dayParts.Add(0, firstHalf);
            dayParts.Add(1, secondHalf);
            return dayParts;
        }

        public Dictionary<int, GroupItemViewModel> InterventionTimes { get; set; }

        public Dictionary<int, List<CarWashViewModel>> Appointements { get; set; } = new Dictionary<int, List<CarWashViewModel>>();

        public void OrderAppointements()
        {
            if(Interventions == null)
            {
                NoSchedules();
                return;
            }

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
                OrganizeAppointements(registreisList);
            }
        }

        private List<CarWashViewModel> NoSchedules()
        {
            var interventions = new List<CarWashViewModel>();

            foreach (var schedule in Schedules)
            {
                interventions.Add(FreeSchedule(schedule));
            }
            OrganizeAppointements(interventions);

            return interventions;
        }

        private void OrganizeAppointements(List<CarWashViewModel> interventions)
        {
            int middleIndex = (interventions.Count + 1) / 2;

            List<CarWashViewModel> firstHalf = interventions.GetRange(0, middleIndex);
            List<CarWashViewModel> secondHalf = interventions.GetRange(middleIndex, interventions.Count - middleIndex);
            Appointements.Add(0, firstHalf);
            Appointements.Add(1, secondHalf);
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
