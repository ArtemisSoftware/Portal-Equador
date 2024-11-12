using Microsoft.IdentityModel.Tokens;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels
{
    public class CarWashSearchDayPlannerViewModel : ViewModel
    {
        [NotMapped]
        public string LicencePlatePosition0 { get; set; }

        [NotMapped]
        public string LicencePlatePosition1 { get; set; }

        [NotMapped]
        public string LicencePlatePosition2 { get; set; }

        [NotMapped]
        public string LicencePlatePosition3 { get; set; }


        private string _licencePlate = "";

        private bool IsLicencePlateValid()
        {
            if (LicencePlatePosition0.IsNullOrEmpty()
                ||
                LicencePlatePosition1.IsNullOrEmpty()
                ||
                LicencePlatePosition2.IsNullOrEmpty()
               ||
                LicencePlatePosition3.IsNullOrEmpty()
                )
            {
                return false;
            }

            return true;
        }


        [Display(Name = StringConstants.Display.LICENCE_PLATE)]
        public string LicencePlate
        {
            get
            {
                if (IsLicencePlateValid())
                {
                    return LicencePlatePosition0.ToUpper() + "-" + LicencePlatePosition1.ToUpper() + "-" + LicencePlatePosition2.ToUpper() + "-" + LicencePlatePosition3.ToUpper();
                }
                else
                {
                    return _licencePlate;
                }

            }
            set
            {
                _licencePlate = value;
                LicencePlatePosition0 = _licencePlate.Split("-")[0];
                LicencePlatePosition1 = _licencePlate.Split("-")[1];
                LicencePlatePosition2 = _licencePlate.Split("-")[2];
                try
                {
                    LicencePlatePosition3 = _licencePlate.Split("-")[3];
                }
                catch (IndexOutOfRangeException ex) { }

            }
        }


        public List<CarWashViewModel> Interventions { get; set; } = new List<CarWashViewModel>();

    }
}