using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Report.ViewModels.Uniforms
{
    public class UniformsReportFormViewModel : ViewModel
    {

        [Display(Name = StringConstants.Display.UNIFORM)]
        [Required]
        public int UniformId { get; set; }

        public SelectList? Uniforms { get; set; }


        [Display(Name = StringConstants.Display.CONTRACT)]
        [Required]
        public int ContractId { get; set; }

        public SelectList? Contracts { get; set; }

        public List<int> ContractIds { get; set; } = new List<int>();

        [Display(Name = StringConstants.Display.ADD_UNIFORM_RETURN)]
        [Required]
        public bool AddUniformReturn { get; set; }
    }
}