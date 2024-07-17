using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels
{
    public class MechanicalWorkshopSchedulerViewModel : ViewModel
    {
        public int Id { get; set; } = -1;

        [Display(Name = StringConstants.Display.MECHANIC)]
        public GroupItemViewModel Mechanic { get; set; }

        public GroupItemViewModel InterventionTime { get; set; }

        public string LicencePlate { get; set; }

        public string Contract { get; set; }

        public string Service { get; set; }

        public string Model { get; set; }

        public string Telephone { get; set; }

        public string? Code { get; set; }


        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM)]
        public DateTime ScheduleDate { get; set; }

    }
}
