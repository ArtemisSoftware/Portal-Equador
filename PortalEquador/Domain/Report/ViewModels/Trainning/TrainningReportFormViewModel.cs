using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Report.ViewModels.Trainning
{
    public class TrainningReportFormViewModel : ViewModel
    {

        [Display(Name = StringConstants.Display.YEAR)]
        [Required]
        public string Date { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [Required]
        public SelectList? Dates { get; set; }

        [Display(Name = StringConstants.Display.CONTRACT)]
        [Required]
        public int ContractId { get; set; }

        public SelectList? Contracts { get; set; }

        public List<int> ContractIds { get; set; } = new List<int>();

    }
}