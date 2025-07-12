using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Report.ViewModels
{
    public class AgeReportViewModel : ViewModel
    {

        public List<AgeReportItemViewModel> report { get; set; } = new List<AgeReportItemViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public string FileName { get; set; } = "relatorio_idades";

        public static class Headers
        {
            public const string ReportName = StringConstants.Report.AGE;
            public const string Emission = StringConstants.Display.EMISSION;

            public static readonly IReadOnlyList<string> All = new List<string>
            {
                ReportName,
                Emission,
            };
        }

    }
}
