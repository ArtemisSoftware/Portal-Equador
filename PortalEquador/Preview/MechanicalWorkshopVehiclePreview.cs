using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels;
using PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels.vehicle;
using System.Diagnostics.Contracts;

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
                   Model = "Super car SGJC",
                   Active = true,
                   Contract = new GroupItemViewModel
                   {
                       Id = 1,
                       Description = "Sem Contrato"
                   },
                   ContractId = 1,
                   Contracts = GetContracts()
               }
            );
            list.Add(
                new MechanicalWorkshopVehicleViewModel
                {
                    Id = 2,
                    LicencePlate = "DD-EE-FF",
                    Active = true,
                    Contract = new GroupItemViewModel
                    {
                        Id = 2,
                        Description = "Contrato 1"
                    },
                    ContractId = 2,
                    Contracts = GetContracts()
                }
            );
            list.Add(
               new MechanicalWorkshopVehicleViewModel
               {
                   Id = 3,
                   LicencePlate = "GG-HH-VV",
                   Active = false,
                   Contract = new GroupItemViewModel
                   {
                       Id = 4,
                       Description = "Contrato Empresa"
                   },
                   ContractId = 4,
                   Contracts = GetContracts()
               }
            );


            return list;
        }

        public static MechanicalWorkshopVehicleViewModel GetItem()
        {
            return GetIndex()[0];
        }

        public static MechanicalWorkshopVehicleViewModel GetEmpty()
        {
            return new MechanicalWorkshopVehicleViewModel
            {
                Id = 2,
                LicencePlate = "DD-EE-FF",
                Active = true,
                Contracts = GetContracts()
            };
        }

        public static SelectList GetContracts()
        {
            List<SelectListItem> Contracts = new List<SelectListItem>();
            Contracts.Add(new SelectListItem() { Text = "Sem Contrato", Value = "1" });
            Contracts.Add(new SelectListItem() { Text = "Contrato 1", Value = "2" });
            Contracts.Add(new SelectListItem() { Text = "Contrato Novo", Value = "3" });
            Contracts.Add(new SelectListItem() { Text = "Contrato Empresa", Value = "4" });

            return new SelectList(Contracts, "Value", "Text"); ;
        }

        public static IEnumerable<SelectListItem> GetProvincesList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "California", Value = "B"},
                new SelectListItem{Text = "Alaska", Value = "B"},
                new SelectListItem{Text = "Illinois", Value = "B"},
                new SelectListItem{Text = "Texas", Value = "B"},
                new SelectListItem{Text = "Washington", Value = "B"}

            };
            return items;
        }


    }
}
