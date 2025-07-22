using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels
{
    public class AlchoolTestReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public List<AlcoholTestResultViewModel> AlcoholTests { get; set; }
    }
}
