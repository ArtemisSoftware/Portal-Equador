using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;

namespace PortalEquador.Domain.Report.ViewModels.Trainning
{
    public class TrainningReportViewModel : ViewModel
    {
        public List<TrainningReportItemViewModel> report { get; set; } = new List<TrainningReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public int Date { get; set; }
        public string FileName { get; set; } = "relatorio_conducao_defensiva";
    }
}