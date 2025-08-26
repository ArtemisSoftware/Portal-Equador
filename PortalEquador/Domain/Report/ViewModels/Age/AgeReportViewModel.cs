using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Age
{
    public class AgeReportViewModel : ViewModel
    {
        public List<AgeReportItemViewModel> report { get; set; } = new List<AgeReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;
        public string FileName { get; set; } = "relatorio_idades";
    }
}
