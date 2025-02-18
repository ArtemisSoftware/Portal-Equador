using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        [Display(Name = StringConstants.Display.FULL_NAME)]
        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.EXPIRATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }


        [NotMapped]
        public string? ProfileImagePath { get; set; }


        [Display(Name = StringConstants.Display.STATE)]
        public int State()
        {
            return ContractState.Valid;
        }
    }
}
