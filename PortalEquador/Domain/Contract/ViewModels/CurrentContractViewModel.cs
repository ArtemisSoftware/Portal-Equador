using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class CurrentContractViewModel : ViewModel
    {
        public int PersonalInformationId { get; set; }

        public string FullName { get; set; }

        public string ProfileImagePath { get; set; }

        public GroupItemViewModel? ContractState { get; set; }
    }
}
