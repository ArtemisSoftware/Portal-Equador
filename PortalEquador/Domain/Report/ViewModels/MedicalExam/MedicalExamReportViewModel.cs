using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;

namespace PortalEquador.Domain.Report.ViewModels.MedicalExam
{
    public class MedicalExamReportViewModel : ViewModel
    {
        public List<MedicalExamReportItemViewModel> report { get; set; } = new List<MedicalExamReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public int Date { get; set; }
        public string FileName { get; set; } = "relatorio_exames_medicos";
    }
}
