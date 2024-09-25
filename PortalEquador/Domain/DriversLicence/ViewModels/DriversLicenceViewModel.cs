using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.StringConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PortalEquador.Util;
using PortalEquador.Util.Extensions;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }


        [Display(Name = StringConstants.Display.DRIVERS_LICENCE_TYPE)]
        public int LicenceId { get; set; }

        public SelectList? LicenceTypes { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE)]
        public GroupItemViewModel? Licence { get; set; }

        public bool ExpirationDateAvailable { get { return DriverLicenceUtil.ExpirationDateAvailable(ExpirationDate); } }


        [Display(Name = StringConstants.Display.FILE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FILE)]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }



        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }

        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }


        public List<DocumentViewModel> Documents { get; set; } = new List<DocumentViewModel>();

        public DocumentViewModel? LicenceDocument => Documents.Find(doc => doc.DocumentTypeId == ItemFromGroup.Documents.DRIVERS_LICENCE && doc.ParentId == Id && doc.SubTypeId == LicenceId);

        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatusType? Status
        {
            get
            {
                return DriverLicenceUtil.GetLicenceStatus(false, ExpirationDate, ProvisionalExpirationDate);
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

        /*
        public PersonalInformationViewModel? PersonalInformation { get; set; }







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

        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatus Status
        {
            get
            {
                return DriverLicenceUtil.GetLicenceStatus(ExpirationDateAvailable, ExpirationDate, ProvisionalExpirationDate);
            }
        }






        public int? DriverLicenceDocumentId { get; set; }

        public DocumentDetailViewModel? DriverLicenceDocument
        {
            get
            {
                if (Documents != null)
                {
                    return Documents.Find(item => item.Id == DriverLicenceDocumentId);
                }
                else return null;
            }
        }


        public int? ProvisionalLicenceDocumentId { get; set; }




        */
    }
}