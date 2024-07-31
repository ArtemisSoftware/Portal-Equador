using PortalEquador.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.Scheduler.MechanicalWorkshop.ViewModels.vehicle
{
    public class MechanicalWorkshopVehicleViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.LICENCE_PLATE)]
        public string LicencePlate { get; set; }

        [Display(Name = StringConstants.Display.MODEL)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Model { get; set; }


        public string LicencePlatePosition0 { get; set; }

        public string LicencePlatePosition1 { get; set; }

        public string LicencePlatePosition2 { get; set; }

        public void FormatLicencePlate()
        {
            LicencePlatePosition0 = LicencePlate.Split("-")[0];
            LicencePlatePosition1 = LicencePlate.Split("-")[1];
            LicencePlatePosition2 = LicencePlate.Split("-")[2];
        }

        public bool Active { get; set; }
    }
}
