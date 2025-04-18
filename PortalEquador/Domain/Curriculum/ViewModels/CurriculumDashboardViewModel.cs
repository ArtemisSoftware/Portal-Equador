using PortalEquador.Domain.Contract;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Curriculum.ViewModels
{
    public class CurriculumDashboardViewModel: ViewModel
    {
        public int Id { get; set; }

        public required string FullName { get; set; }

        public bool IsPersonalInformationComplete { get; set; }

        public int TotalDocuments { get; set; }
        public int TotalLanguages { get; set; }
        public int TotalProfessionalExperiences{ get; set; }
        public int TotalProfessionalCompetences { get; set; }
        public int TotalDriversLicence { get; set; }
        public int TotalSchoolEducation { get; set; }
        public int TotalUniversityEducation { get; set; }

        public int TotalContracts { get; set; }
        public GroupItemViewModel? Contract { get; set; } = null;

        public int ContractStateDescription()
        {
            if(Contract == null)
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


        public required string ProfileImagePath { get; set; }
        public int ContractId { get; internal set; }
    }
}
