using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Domain.Document.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using PortalEquador.Util.Extensions;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public partial class DriversLicenceBaseViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public int LicenceId { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }


        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }


        public List<DocumentViewModel> Documents { get; set; } = new List<DocumentViewModel>();
        public DocumentViewModel? LicenceDocument => Documents.Find(doc => doc.DocumentTypeId == ItemFromGroup.Documents.DRIVERS_LICENCE && doc.ParentId == Id && doc.SubTypeId == LicenceId);
        public DocumentViewModel? ProvisionalDocument => Documents.Find(doc => doc.DocumentTypeId == ItemFromGroup.Documents.DRIVERS_LICENCE_PROVISIONAL && doc.ParentId == Id && doc.SubTypeId == LicenceId);




        public virtual DateTime? GetProvisionalExpirationDate()
        {
            return null;
        }


        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatusType? Status
        {
            get
            {
                return DriverLicenceUtil.GetLicenceStatus(false, ExpirationDate, GetProvisionalExpirationDate());
            }
        }

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
