using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels
{
    public class AdminMechanicalWorkshopContractViewModel : ViewModel
    {
        public int Id { get; set; }

        [Required]
        public int ContractId { get; set; }
    }
}
