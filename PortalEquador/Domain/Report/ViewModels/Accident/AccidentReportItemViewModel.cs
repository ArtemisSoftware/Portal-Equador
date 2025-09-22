using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Accident
{
    public class AccidentReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }
        public string WorkStation { get; set; }
        public List<AccidentResultViewModel> Accidents { get; internal set; } = new List<AccidentResultViewModel>();
    }
}
