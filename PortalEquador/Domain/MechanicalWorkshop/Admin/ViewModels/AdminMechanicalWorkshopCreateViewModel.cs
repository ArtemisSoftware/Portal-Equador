using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels
{
    public class AdminMechanicalWorkshopCreateViewModel: ViewModel
    {
        [Required]
        public string UserId { get; set; }


        public List<GroupItemViewModel> Contracts { get; set; } = new List<GroupItemViewModel>();
        public List<bool> SelectedContracts { get; set; } = new List<bool>();
        public SelectList? Users { get; set; }
        public List<AdminUser> UserDetails { get; set; } = new List<AdminUser>();

        public bool HasSelectedContracts()
        {
            return SelectedContracts.Contains(true);
        }

        public List<GroupItemViewModel> ContractsToMonitor() {
            var contracts = new List<GroupItemViewModel>();

            for (int index = 0; index < Contracts.Count; index++){

                if (SelectedContracts[index] == true) {  contracts.Add(Contracts[index]); }
            }
            return contracts;
        }

    }
}
