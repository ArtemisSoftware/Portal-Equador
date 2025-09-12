using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;

namespace PortalEquador.Domain.Report.ViewModels.Education
{
    public class EducationReportViewModel : ViewModel
    {
        public List<EducationReportItemViewModel> report { get; set; } = new List<EducationReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;
        public string FileName { get; set; } = "relatorio_habilitacoes_academicas";
    }
}
