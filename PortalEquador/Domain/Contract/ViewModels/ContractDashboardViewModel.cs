using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractDashboardViewModel : ViewModel
    {
        public int Id { get; set; }
        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        public int TotalExams { get; set; }
        public int TotalTrainning { get; set; }
        public int TotalDisciplinaryNotification { get; set; }
        public int TotalAccidents { get; set; }

        public required string ProfileImagePath { get; set; }

        public int ContractId { get; internal set; }
        public int TotalContracts { get; set; }

        public GroupItemViewModel? Contract { get; set; } = null;

        public int ContractStateDescription()
        {
            if (Contract == null)
            {
                return ContractState.Unassigned;
            }
            else if (Contract.Id == GroupTypesConstants.ItemFromGroup.ContractStates.CONTRACTED)
            {
                return ContractState.Contracted;
            }
            else if (Contract.Id == GroupTypesConstants.ItemFromGroup.ContractStates.FIRED)
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