using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels
{
    public class AlcoholTestResultViewModel : ViewModel
    {
        public DateTime Date { get; set; }
        public int Result  { get; set; }
    }
}
