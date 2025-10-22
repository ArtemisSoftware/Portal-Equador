using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Domain.Uniforms.ViewModels;

namespace PortalEquador.Domain.Report.ViewModels.Trainning
{
    public class TrainningReportViewModel : ViewModel
    {
        public List<GroupItemViewModel> Trainnings { get; set; } = new List<GroupItemViewModel>();

        public List<TrainningReportItemViewModel> report { get; set; } = new List<TrainningReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public int Date { get; set; }
        public string FileName { get; set; } = "relatorio_conducao_defensiva";
    }
}