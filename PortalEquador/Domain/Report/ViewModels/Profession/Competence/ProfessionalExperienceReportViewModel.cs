using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;

namespace PortalEquador.Domain.Report.ViewModels.Profession.Competence
{
    public class ProfessionalExperienceReportViewModel : ViewModel
    {
        public List<ProfessionalExperienceReportItemViewModel> report { get; set; } = new List<ProfessionalExperienceReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public string FileName { get; set; } = "relatorio_experiência_profissional";
    }
}
