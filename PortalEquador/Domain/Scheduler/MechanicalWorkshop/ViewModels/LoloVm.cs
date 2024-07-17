using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels
{
    public class LoloVml : ViewModel
    {
        public DateTime MainTime { get; set; } =   DateTime.Now;

        public List<MechanicalWorkshopSchedulerViewModel> registers { get; set; }

        public List<GroupItemViewModel> Mechanics { get; set; }

        public List<GroupItemViewModel> Schedules { get; set; }


        public Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>> colab()
        {
            Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>> My_dict1 = new Dictionary<int, List<MechanicalWorkshopSchedulerViewModel>>();

            //Monday
            var index = 1;

            foreach (var item1 in Schedules)
            {
                var registreisList = new List<MechanicalWorkshopSchedulerViewModel>();
                foreach (var item2 in Mechanics)
            {
                var res = registers
                     .Where(p => p.Mechanic.Id == item2.Id && p.InterventionTime.Id == item1.Id)
                     .FirstOrDefault();

                    if(res != null)
                    {
                        registreisList.Add(res);
                    } else
                    {
                        var dd = new MechanicalWorkshopSchedulerViewModel();
                        dd.Id = -1;
                        registreisList.Add(dd);
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
