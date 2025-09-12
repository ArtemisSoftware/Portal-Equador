using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.Accident.ViewModels
{
    public class AccidentCauseViewModel : ViewModel
    {
        public int Id { get; set; }

        public int CauseId { get; set; }

        public GroupItemViewModel Cause { get; set; }

        public string Description { get; set; }

        public bool Selected { get; set; } = false;
    }
}
