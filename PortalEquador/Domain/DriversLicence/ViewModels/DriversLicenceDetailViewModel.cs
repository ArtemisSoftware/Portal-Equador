using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.StringConstants;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Extensions;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public required GroupItemViewModel Licence { get; set; }



        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ProvisionalExpirationDate { get; set; }

        public List<DocumentViewModel> Documents { get; set; } = new List<DocumentViewModel>();



        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatusType? Status { get; set; }

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

      
    }
}