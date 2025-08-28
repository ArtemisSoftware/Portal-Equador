using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Profession.Competence
{
    public class ProfessionalExperienceReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public string Company { get; set; }

        public string Experience { get; set; }

        public int Months { get; set; }
    }
}