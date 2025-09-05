using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Accident
{
    public class AccidentResultViewModel: ViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Level { get; set; }
        public int EstimatedValueId { get; set; }
        public int HumanDamage { get; set; }

        public string Address { get; set; }
        public List<AccidentCauseResultViewModel> Causes { get; set; } = new List<AccidentCauseResultViewModel>();  
    }
}
