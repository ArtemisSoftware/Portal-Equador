using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Report.ViewModels.AlchoolTest
{
    public class AlchoolTestViewModel : ViewModel
    { 

        [Display(Name = StringConstants.Display.DATE)]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [Required]
        public SelectList? Dates { get; set; }
    

        [Display(Name = StringConstants.Display.CONTRACT)]
        [Required]
        public int ContractId { get; set; }

        public SelectList? Contracts { get; set; }
    }
}
