using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels
{
    public class VehicleViewModel : ViewModel
    {
        public int Id { get; set; }


        [NotMapped]
        public string LicencePlatePosition0 { get; set; }

        [NotMapped]
        public string LicencePlatePosition1 { get; set; }

        [NotMapped]
        public string LicencePlatePosition2 { get; set; }


        public bool IsLicencePlateValid()
        {
            if (LicencePlatePosition0.IsNullOrEmpty() || LicencePlatePosition1.IsNullOrEmpty() || LicencePlatePosition2.IsNullOrEmpty())
            {
                return false;
            }

            return true;
        }

        private string _licencePlate = "";

        [Display(Name = StringConstants.Display.LICENCE_PLATE)]
        public string LicencePlate
        {
            get
            {
                if (IsLicencePlateValid()){
                    return LicencePlatePosition0.ToUpper() + "-" + LicencePlatePosition1.ToUpper() + "-" + LicencePlatePosition2.ToUpper();
                } else
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
            }
        }


        [Display(Name = StringConstants.Display.MODEL)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Model { get; set; }


        public bool Active { get; set; } = true;

        [Display(Name = StringConstants.Display.CONTRACT_IN_USE)]
        [Required]
        public int ContractId { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT_IN_USE)]
        public SelectList? Contracts { get; set; }




    }
}
