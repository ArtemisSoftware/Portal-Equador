using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.DriversLicence.ViewModels
{
    public class DriversLicenceProvisionalRenewViewModel : DriversLicenceBaseViewModel
    {

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }



        [Display(Name = StringConstants.Display.DRIVERS_LICENCE)]
        public GroupItemViewModel? Licence { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DataType(DataType.Date)]
        public DateTime? ProvisionalExpirationDate { get; set; }

        [Display(Name = StringConstants.Display.PROVISIONAL_UPDATE_NUMBER)]
        public int? ProvisionalRenewalNumber { get; set; }


        [Display(Name = StringConstants.Display.FILE)]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }



        public bool HasProvisionalLicence => ProvisionalExpirationDate != null;

        public override DateTime? GetProvisionalExpirationDate()
        {
            return ProvisionalExpirationDate;
        }
    }
}