using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.Report.ViewModels.Trainning
{
    public class TrainningReportViewModel : ViewModel
    {
        public List<GroupItemViewModel> Trainnings { get; set; } = new List<GroupItemViewModel>();

        public List<TrainningPerDayViewModel> report { get; set; } = new List<TrainningPerDayViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public int Date { get; set; }
        public string FileName { get; set; } = "relatorio_formacao";
    }
}