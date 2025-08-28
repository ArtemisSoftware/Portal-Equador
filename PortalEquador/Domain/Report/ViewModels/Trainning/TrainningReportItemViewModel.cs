using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Trainning
{
    public class TrainningReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public string WorkStation { get; set; }

        public DateTime Date { get; set; }

        public string Trainning { get; set; }

    }
}