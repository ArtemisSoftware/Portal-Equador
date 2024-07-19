using Microsoft.AspNetCore.Http;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;

namespace PortalEquador.Preview
{
    public static class MechanicalWorkshopSchedulerPreview
    {
        public static LoloVml GetIndex()
        {
            var main = new LoloVml();
 
            main.registers = GetAppointements();
            main.Schedules = GetSchedules();
            main.Mechanics = GetMechanics();

            main.RegisteredDictionary = main.colab();
            main.RegisteredTime = main.colabTime();

            return main;
        }

        public static MechanicalWorkshopSchedulerViewModel GetCreate(string scheduleDate, int mechanicId, int scheduleId)
        {
            var model = new MechanicalWorkshopSchedulerViewModel{
                ScheduleDate = DateTime.Parse(scheduleDate),
                Mechanic = GetMechanics().Where(p => p.Id == mechanicId).First(),
                InterventionTime = GetSchedules().Where(p => p.Id == scheduleId).First(),
            };
            return model;
        }

        public static MechanicalWorkshopSchedulerViewModel GetEdit()
        {
          
            return GetAppointements()[2];
        }

        private static List<MechanicalWorkshopSchedulerViewModel> GetAppointements()
        {
            var lolo = new MechanicalWorkshopSchedulerViewModel();
            lolo.Id = 1;
            lolo.Contract = "Contract 1";
            lolo.LicencePlate = "AA-AA-AA";
            lolo.InterventionTime = GetSchedules()[0];
            lolo.Mechanic = GetMechanics()[0];


            var lolo2 = new MechanicalWorkshopSchedulerViewModel();
            lolo2.Id = 2;
            lolo2.Contract = "CVX";
            lolo2.LicencePlate = "BB-BB-BB";
            lolo2.InterventionTime = GetSchedules()[1];
            lolo2.Mechanic = GetMechanics()[1];

            var lolo3 = new MechanicalWorkshopSchedulerViewModel();
            lolo3.ScheduleDate = DateTime.Now;
            lolo3.Id = 3;
            lolo3.Contract = "ALGN";
            lolo3.LicencePlate = "CC-CC-CC";
            lolo3.Code = "11233421";
            lolo3.Telephone = "985673412";
            lolo3.Model = "Tesla mono rail";
            lolo3.Service = "Trabalho parcial";
            lolo3.InterventionTime = GetSchedules()[2];
            lolo3.Mechanic = GetMechanics()[2];

            var models = new List<MechanicalWorkshopSchedulerViewModel>();
            models.Add(lolo);
            models.Add(lolo2);
            models.Add(lolo3);

            return models;
        }

        private static List<GroupItemViewModel> GetMechanics()
        {
            var mechanics = new List<GroupItemViewModel>();
            mechanics.Add(
               new GroupItemViewModel
               {
                   Id = 1,
                   Description = "Mec 1"
               }
            );
            mechanics.Add(
               new GroupItemViewModel
               {
                   Id = 2,
                   Description = "Mec 2"
               }
            );
            mechanics.Add(
               new GroupItemViewModel
               {
                   Id = 3,
                   Description = "Mec 3"
               }
            );
            return mechanics;
        }

        private static List<GroupItemViewModel>  GetSchedules()
        {
            var schedules = new List<GroupItemViewModel>();
            schedules.Add(
               new GroupItemViewModel
               {
                   Id = 1,
                   Description = "08:00 - 09:30"
               }
            );
            schedules.Add(
               new GroupItemViewModel
               {
                   Id = 2,
                   Description = "10:00 - 11:30"
               }
            );
            schedules.Add(
               new GroupItemViewModel
               {
                   Id = 3,
                   Description = "12:00 - 13:30"
               }
            );

            return schedules;
        }
   
    }
}
