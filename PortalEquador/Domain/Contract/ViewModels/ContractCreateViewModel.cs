using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractCreateViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        [Display(Name = StringConstants.Display.STATE_OF_HIRED)]
        public int ContractStateId { get; set; }

        public SelectList? ContractStates { get; set; }

        [Display(Name = StringConstants.Display.REASON_TO_BE_FIRED)]
        public int? ResignationReasonsId { get; set; }

        public SelectList? ResignationReasons { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }
    }
}
