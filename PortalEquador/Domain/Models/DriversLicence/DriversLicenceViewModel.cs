using PortalEquador.Constants;
using PortalEquador.Domain.Models;
using PortalEquador.Models.Documents;
using System.ComponentModel.DataAnnotations;


namespace PortalEquador.Domain.Models.DriversLicence
{
    public class DriversLicenceViewModel
    {
        public int? Id { get; set; }

        public int CurriculumId { get; set; }

        [Display(Name = StringConstants.Display.FULL_NAME)]
        public string FullName { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public string? Licence { get; set; }

        public string ProfilePicturePath { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatus? Status { get; set; }

        public string? StatusDescription
        {
            get
            {
                if (Status == null) {
                    return null; 
                } else {
                    return Status.ToName();
                }
            }
        }
    }
}
