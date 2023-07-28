using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.Models.Document;
using PortalEquador.Models.Documents;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Models.DriversLicence
{
    public class DriversLicenceViewModel__
    {
        public int Id { get; set; }

        public int CurriculumId { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        [Required]
        public int GroupItemId { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }



        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public string Licence { get; set; }

        public SelectList? LicenceTypes { get; set; }

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


        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }



        public bool ExpirationDateAvailable { get; set; }

        public IFormFile? ImageFile { get; set; }

        public List<DocumentViewModel> Documents { get; set; } = new List<DocumentViewModel>();

        public DocumentViewModel? ProvisionalDocument { get; set; }
        
    }
}
