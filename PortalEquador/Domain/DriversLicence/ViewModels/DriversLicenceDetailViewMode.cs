using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Models;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceDetailViewModel
    {

        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.DRIVERS_LICENCE)]
        public GroupItemViewModel Licence { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }


        [Display(Name = StringConstants.Display.STATE)]
        public LicenceStatus? Status { get { return DriverLicenceUtil.GetLicenceStatus(ExpirationDateAvailable, ExpirationDate, ProvisionalExpirationDate); } }

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

        public bool ExpirationDateAvailable { get { return DriverLicenceUtil.ExpirationDateAvailable(ExpirationDate); } }


        public List<DocumentDetailViewModel> Documents { get; set; } = new List<DocumentDetailViewModel>();


        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }



        public DocumentViewModel? ProvisionalDocument { get; set; }

        public DocumentDetailViewModel? DriverLicenceDocument
        {
            get
            {
                if (Documents != null)
                {
                    return Documents.Find(item => item.Id == ItemFromGroup.Documents.DRIVERS_LICENCE);
                }
                else return null;
            }
        }

    }
}
