using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Report.ViewModels.Age;

namespace PortalEquador.Domain.Report.ViewModels.Accident
{
    public class AccidentReportViewModel : ViewModel
    {
        public List<GroupItemViewModel> Causes { get; set; } = new List<GroupItemViewModel>();
        public List<GroupItemViewModel> EstimatedValues { get; set; } = new List<GroupItemViewModel>();
        public List<AccidentReportItemViewModel> Report { get; set; } = new List<AccidentReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;
        public string FileName { get; set; } = "relatorio_acidentes";
    }
}
