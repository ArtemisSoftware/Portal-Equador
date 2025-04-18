using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractsViewModel : ViewModel
    {
        public List<ContractViewModel> Contracts { get; set; } = new List<ContractViewModel>();
       
        public List<GroupItemViewModel> States { get; set; } = new List<GroupItemViewModel>();
    }
}
