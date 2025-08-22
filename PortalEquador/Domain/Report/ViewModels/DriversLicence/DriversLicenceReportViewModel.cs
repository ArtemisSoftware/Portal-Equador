using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.DriversLicence
{
    public class DriversLicenceReportViewModel : ViewModel
    {
        public List<DriversLicenceReportItemViewModel> report { get; set; } = new List<DriversLicenceReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;
        public string FileName { get; set; } = "relatorio_cartas_conducao";
    }
}
