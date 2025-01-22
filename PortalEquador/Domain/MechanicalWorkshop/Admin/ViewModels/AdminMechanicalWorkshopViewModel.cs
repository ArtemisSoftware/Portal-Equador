using PortalEquador.Data.Generic;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels
{
    public class AdminMechanicalWorkshopViewModel: ViewModel
    {
        public AdminUser user { get; set; }

        [Display(Name = StringConstants.Display.CONTRACTS)]
        public List<AdminMechanicalWorkshopContractViewModel> Contracts { get; set; } = new List<AdminMechanicalWorkshopContractViewModel>();

        public List<GroupItemViewModel> AllContracts { get; set; } = new List<GroupItemViewModel>();
        public List<bool> SelectedContracts { get; set; } = new List<bool>();

        public bool HasSelectedContracts()
        {
            return SelectedContracts.Contains(true);
        }

        public List<GroupItemViewModel> MarkedContracts()
        {
            var contracts = new List<GroupItemViewModel>();

            foreach (var contract in Contracts)
            {
                var position = AllContracts.FindIndex(i => i.Id == contract.ContractId);

                if (position != -1)
                {
                    contracts.Add(AllContracts[position]);
                }
            }

            return contracts;
        }

        public List<GroupItemViewModel> ContractsToMonitor()
        {
            var contracts = new List<GroupItemViewModel>();

            for (int index = 0; index < AllContracts.Count; index++)
            {

                if (SelectedContracts[index] == true) { contracts.Add(AllContracts[index]); }
            }
            return contracts;
        }
    }
}
