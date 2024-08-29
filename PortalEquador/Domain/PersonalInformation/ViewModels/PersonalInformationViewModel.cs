using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.PersonalInformation.ViewModels
{
    public class PersonalInformationViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.IDENTITY_CARD_NUMBER)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string IdentityCard { get; set; }

        [Display(Name = StringConstants.Display.IDENTITY_CARD_EXPIRATION_DATE)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? IdentityCardExpirationDate { get; set; }


        [Display(Name = StringConstants.Display.FINANTIAL_IDENTITY)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Nif { get; set; }

        [Display(Name = StringConstants.Display.NAME)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string FirstName { get; set; }

        [Display(Name = StringConstants.Display.SURNAME)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string LastName { get; set; }

        [Display(Name = StringConstants.Display.DATE_OF_BIRTH)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }


        [Display(Name = StringConstants.Display.CONTACTS)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Contacts { get; set; }

        [Display(Name = StringConstants.Display.BENIFICIARY_NUMBER)]
        public string? BeneficiaryNumber { get; set; }

        [Display(Name = StringConstants.Display.EMAIL)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = StringConstants.Display.ADRESS)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Address { get; set; }


        [Display(Name = StringConstants.Display.NATIONALITY)]
        [Required]
        public int NationalityId { get; set; }

        public SelectList? Nationalities { get; set; }

        [Display(Name = StringConstants.Display.NEIGHBOURHOOD)]
        [Required]
        public int NeighbourhoodId { get; set; }

        public SelectList? Neighbourhoods { get; set; }


        [Display(Name = StringConstants.Display.PROVINCE)]
        public int? ProvinceId { get; set; }

        public SelectList? Provinces { get; set; }


        [NotMapped]
        public bool ValidatedIdentityCard { get; set; } = false;

        [NotMapped]
        public string ProfileImagePath { get; set; }

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
