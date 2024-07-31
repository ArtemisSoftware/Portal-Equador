using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels.vehicle;

namespace PortalEquador.Preview
{
    public static class MechanicalWorkshopVehiclePreview
    {
        public static List<MechanicalWorkshopVehicleViewModel> GetIndex()
        {

            var list = new List<MechanicalWorkshopVehicleViewModel>();
            list.Add(
               new MechanicalWorkshopVehicleViewModel
               {
                   Id = 1,
                   LicencePlate = "AA-BB-CC",
                   Active = true
               }
            );
            list.Add(
                new MechanicalWorkshopVehicleViewModel
                {
                    Id = 2,
                    LicencePlate = "DD-EE-FF",
                    Active = true
                }
            );
            list.Add(
               new MechanicalWorkshopVehicleViewModel
               {
                   Id = 3,
                   LicencePlate = "GG-HH-VV",
                   Active = false
               }
            );


            return list;
        }

        public static MechanicalWorkshopVehicleViewModel GetItem()
        {

            return new MechanicalWorkshopVehicleViewModel
            {
                Id = 1,
                LicencePlate = "AA-BB-CC",
                Model = "Super carro",
                Active = true
            };
        }




    }
}
