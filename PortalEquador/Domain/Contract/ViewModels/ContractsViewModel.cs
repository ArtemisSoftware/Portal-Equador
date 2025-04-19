using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Contract.ViewModels
{
    public class ContractsViewModel : ViewModel
    {
        public List<CurrentContractViewModel> Contracts { get; set; } = new List<CurrentContractViewModel>();

        [Display(Name = StringConstants.Display.FILTER)]
        public int ContractStatesId { get; set; }
        public SelectList? ContractStates { get; set; }

    }
}
