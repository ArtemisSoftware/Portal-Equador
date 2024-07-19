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

        [Display(Name = StringConstants.Display.SCHEDULE)]
        public GroupItemViewModel InterventionTime { get; set; }

        [Display(Name = StringConstants.Display.LICENCE_PLATE)]
        public string LicencePlate { get; set; }

        public string GetLicencePlatePosition0 { get; set; }

        public string GetLicencePlatePosition1 { get; set; }

        public string GetLicencePlatePosition2 { get; set; }

        public void FormatLicencePlate() {
            GetLicencePlatePosition0 = LicencePlate.Split("-")[0];
            GetLicencePlatePosition1 = LicencePlate.Split("-")[1];
            GetLicencePlatePosition2 = LicencePlate.Split("-")[2];
        }

        [Display(Name = StringConstants.Display.CONTRACT)]
        public string Contract { get; set; }

        [Display(Name = StringConstants.Display.SERVICE)]
        public string Service { get; set; }

        [Display(Name = StringConstants.Display.MODEL)]
        public string Model { get; set; }

        [Display(Name = StringConstants.Display.TELEPHONE)]
        public string Telephone { get; set; }

        [Display(Name = StringConstants.Display.CODE)]
        public string? Code { get; set; }


        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        public DateTime ScheduleDate { get; set; }

    }
}
