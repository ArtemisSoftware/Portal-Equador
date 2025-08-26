using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.MedicalExam
{
    public class MedicalExamReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public string WorkStation { get; set; }

        public DateTime Date { get; set; }

        public string Exam { get; set; }

        public string? Situation { get; set; }
    }
}