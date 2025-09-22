using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.Diagnostics.Contracts;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class CurrentContractViewModel : ViewModel
    {
        public int PersonalInformationId { get; set; }

        public string FullName { get; set; }

        public string ProfileImagePath { get; set; }



        public required int? ContractId { get; set; }
        public required string? ContractDescription { get; set; }

        public string? ContractName { get; set; }

        public int ContractStateDescription()
        {
            if (ContractId == null)
            {
                return ContractState.Unassigned;
            }
            else if (ContractId == GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED)
            {
                return ContractState.Contracted;
            }
            else if (ContractId == GroupTypesConstants.ItemFromGroup.ContractStates.FIRED)
            {
                return ContractState.Fired;
            }
            else
            {
                return -1;
            }
        }
    }
}
