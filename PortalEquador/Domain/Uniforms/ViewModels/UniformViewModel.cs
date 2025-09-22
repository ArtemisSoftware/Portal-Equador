using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Uniforms.ViewModels
{
    public class UniformViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.DESCRIPTION)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public string Description { get; set; }

        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        [Display(Name = StringConstants.Display.STATE)]
        public bool Active { get; set; } = true;

        [Display(Name = StringConstants.Display.SIZE_IS_NUMERIC)]
        public bool isSizeNumeric { get; set; } = true;
    }
}
