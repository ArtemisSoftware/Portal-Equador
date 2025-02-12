using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractDashboardViewModel : ViewModel
    {
        public int Id { get; set; }

        public required string FullName { get; set; }
        /*
        public bool IsPersonalInformationComplete { get; set; }

        public int TotalDocuments { get; set; }
        public int TotalLanguages { get; set; }
        public int TotalProfessionalExperiences { get; set; }
        public int TotalProfessionalCompetences { get; set; }
        public int TotalDriversLicence { get; set; }
        public int TotalSchoolEducation { get; set; }
        public int TotalUniversityEducation { get; set; }
        */

        public int TotalExams { get; set; }

        public required string ProfileImagePath { get; set; }

    }
}