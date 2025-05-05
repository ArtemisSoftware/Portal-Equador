using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractResignViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }


        [Display(Name = StringConstants.Display.DATE_OF_CONTRACT_CREATION)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? DateOfContract { get; set; }


        [Display(Name = StringConstants.Display.CONTRACT)]
        public int ContractId { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT_IN_USE)]
        public GroupItemViewModel? Contract { get; set; }


        [Display(Name = StringConstants.Display.STATE_OF_HIRED)]
        public int ContractStateId { get; set; }

        public SelectList? ContractStates { get; set; }

        [Display(Name = StringConstants.Display.REASON_TO_BE_FIRED)]
        public int? ResignationReasonsId { get; set; }

        public SelectList? ResignationReasons { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public string Origin { get; set; }

    }
}