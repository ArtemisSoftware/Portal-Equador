using PortalEquador.Data.Generic;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels
{
    public class AdminMechanicalWorkshopViewModel: ViewModel
    {
        public AdminUser user { get; set; }

        public List<GroupItemViewModel> Contracts { get; set; } = new List<GroupItemViewModel>();

        public List<GroupItemViewModel> AllContracts { get; set; } = new List<GroupItemViewModel>();
        public List<bool> SelectedContracts { get; set; } = new List<bool>();
    }
}
