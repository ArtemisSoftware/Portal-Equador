using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Domain.PersonalInformation.ViewModels
{
    public class PersonalInformationDetailViewModel : ViewModel
    {

        public int Id { get; set; }

        [Display(Name =StringConstants.Display.IDENTITY_CARD_NUMBER)]
        public string IdentityCard { get; set; }

        [Display(Name = StringConstants.Display.IDENTITY_CARD_EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? IdentityCardExpirationDate { get; set; }


        [Display(Name = StringConstants.Display.FINANTIAL_IDENTITY)]
        public string Nif { get; set; }

        [Display(Name = StringConstants.Display.NAME)]
        public string FirstName { get; set; }

        [Display(Name = StringConstants.Display.SURNAME)]
        public string LastName { get; set; }

        [Display(Name = StringConstants.Display.DATE_OF_BIRTH)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }


        [Display(Name = StringConstants.Display.CONTACTS)]
        public string Contacts { get; set; }

        [Display(Name = StringConstants.Display.BENIFICIARY_NUMBER)]
        public string? BeneficiaryNumber { get; set; }

        [Display(Name = StringConstants.Display.EMAIL)]
        public string? Email { get; set; }

        [Display(Name = StringConstants.Display.ADRESS)]
        public string Address { get; set; }




        [Display(Name = StringConstants.Display.NEIGHBOURHOOD)]
        public GroupItemViewModel Neighbourhood { get; set; }

        [Display(Name = StringConstants.Display.PROVINCE)]
        public GroupItemViewModel? Province { get; set; }

        [Display(Name = StringConstants.Display.NATIONALITY)]
        public GroupItemViewModel Nationality { get; set; }




        [NotMapped]
        [Display(Name = StringConstants.Display.FULL_NAME)]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        
    }
}
