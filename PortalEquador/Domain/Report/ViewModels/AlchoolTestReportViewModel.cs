namespace PortalEquador.Domain.Report.ViewModels
{
    public class AlchoolTestReportViewModel
    {
        public List<AlchoolTestReportItemViewModel> report { get; set; } = new List<AlchoolTestReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;
        public DateTime ReferenceDate { get; set; } = DateTime.Now;

        public string WorkStation { get; set; }
        public string FileName { get; set; } = "relatorio_testes_alcool";
    }
}
