using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Report.ViewModels.DriversLicence
{
    public class DriversLicenceReportFormViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.CONTRACT)]
        [Required]
        public int ContractId { get; set; }

        public SelectList? Contracts { get; set; }

        public List<int> ContractIds { get; set; } = new List<int>();
    }
}
