using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.MedicalExam
{
    public class MedicalExamInfoViewModel : ViewModel
    {
        public int Id { get; set; }
        public string? Situation { get; set; }
        public int? SituationId { get; set; }
    }
}
