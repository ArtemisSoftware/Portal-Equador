using PortalEquador.Domain.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels
{
    public class AdminMechanicalWorkshopViewModel: ViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public List<AdminMechanicalWorkshopContractViewModel> Contracts { get; set; } = new List<AdminMechanicalWorkshopContractViewModel>();
    }
}
