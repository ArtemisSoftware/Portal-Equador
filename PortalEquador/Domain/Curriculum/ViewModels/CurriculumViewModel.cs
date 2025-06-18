using PortalEquador.Domain.Contract;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Curriculum.ViewModels
{
    public class CurriculumViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.FULL_NAME)]
        public required string FullName { get; set; }

        public required string ProfileImagePath { get; set; }

        public required int? ContractId { get; set; }
        public required string? ContractDescription { get; set; }

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
