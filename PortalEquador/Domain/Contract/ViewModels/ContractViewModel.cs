using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.STATE_OF_HIRED)]
        public GroupItemViewModel ContractState { get; set; }

        [Display(Name = StringConstants.Display.REASON_TO_BE_FIRED)]
        public GroupItemViewModel? ResignationReasons{ get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public int ContractStateDescription()
        {
            if (ContractState.Id == GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED)
            {
                return PortalEquador.Domain.Contract.ContractState.Contracted;
            }
            else if (ContractState.Id == GroupTypesConstants.ItemFromGroup.ContractStates.FIRED)
            {
                return PortalEquador.Domain.Contract.ContractState.Fired;
            }
            else
            {
                return -1;
            }
        }

    }
}
