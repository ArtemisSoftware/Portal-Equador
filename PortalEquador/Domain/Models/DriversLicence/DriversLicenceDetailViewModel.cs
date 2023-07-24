using PortalEquador.Constants;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Models.Documents;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.Models.DriversLicence
{
    public class DriversLicenceDetailViewModel
    {

        public int CurriculumId { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ProvisionalExpirationDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }


        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public string Licence { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatus? Status { get; set; }

        public string? StatusDescription
        {
            get
            {
                if (Status == null)
                {
                    return null;
                }
                else
                {
                    return Status.ToName();
                }
            }
        }

        public List<DocumentViewModel> Documents { get; set; } = new List<DocumentViewModel>();
    }
}
