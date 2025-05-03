using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractCreate__ViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }
        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT)]
        public int ContractId { get; set; }

        public SelectList? Contracts { get; set; }

        [Display(Name = StringConstants.Display.DATE_OF_CONTRACT_CREATION)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? DateOfContract { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }
    }
}
