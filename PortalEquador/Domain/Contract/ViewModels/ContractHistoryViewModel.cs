using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractHistoryViewModel : ViewModel
    {
        public List<ContractViewModel> Current { get; set; }

        public List<ContractViewModel> History { get; set; }
    }
}
