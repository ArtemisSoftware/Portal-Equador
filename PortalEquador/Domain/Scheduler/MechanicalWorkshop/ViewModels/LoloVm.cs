using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels
{
    public class LoloVml : ViewModel
    {
        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime MainTime { get; set; } =   DateTime.Now;

        public List<MechanicalWorkshopSchedulerViewModel> registers { get; set; }

        public List<GroupItemViewModel> Mechanics { get; set; }

        public List<GroupItemViewModel> Schedules { get; set; }


        public Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>> colab()
        {
            Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>> My_dict1 = new Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>>();

            //Monday
            var index = 1;

            foreach (var schedule in Schedules)
            {
                var registreisList = new List<MechanicalWorkshopSchedulerViewModel>();
                foreach (var mechanic in Mechanics)
            {
                var res = registers
                     .Where(p => p.Mechanic.Id == mechanic.Id && p.InterventionTime.Id == schedule.Id)
                     .FirstOrDefault();

                    if(res != null)
                    {
                        registreisList.Add(res);
                    } else
                    {
                        var noAppointement = new MechanicalWorkshopSchedulerViewModel();
                        noAppointement.Id = -1;
                        noAppointement.Mechanic = mechanic;
                        noAppointement.InterventionTime = schedule;
                        registreisList.Add(noAppointement);
                    }
            }
                My_dict1.Add(index, registreisList);
                ++index;
            }

            
            return My_dict1;
        }

        public Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>> RegisteredDictionary { get; set; }



        public Dictionary<int, GroupItemViewModel> colabTime()
        {
            Dictionary<int, GroupItemViewModel> My_dict1 = new Dictionary<int, GroupItemViewModel>();

            //Monday

            My_dict1.Add(1, new GroupItemViewModel
            {
                Id = 1,
                Description = "08:00 - 09:30"
            });
            My_dict1.Add(2, new GroupItemViewModel
            {
                Id = 2,
                Description = "10:00 - 11:30"
            });
            My_dict1.Add(3, new GroupItemViewModel
            {
                Id = 3,
                Description = "12:00 - 13:30"
            });
            return My_dict1;
        }

        public Dictionary<int, GroupItemViewModel> RegisteredTime { get; set; }

    }
}
