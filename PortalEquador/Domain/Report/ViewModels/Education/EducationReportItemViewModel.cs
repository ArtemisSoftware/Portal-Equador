using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Education
{
    public class EducationReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public string Institution { get; set; }

        public string Degree { get; set; }

        public string? Major { get; set; }
    }
}