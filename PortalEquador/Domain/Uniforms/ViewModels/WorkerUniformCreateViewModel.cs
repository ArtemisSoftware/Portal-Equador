using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Uniforms.ViewModels
{
    public class WorkerUniformCreateViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; } = DateTime.Now;

        [Display(Name = StringConstants.Display.UNIFORM)]
        [Required]
        public int UniformId { get; set; }

        public SelectList? Uniforms { get; set; }


        [Display(Name = StringConstants.Display.MEASURE)]
        [Required]
        public int? LabelSizeId { get; set; }

        public SelectList? LabelSizes { get; set; }

        [Display(Name = StringConstants.Display.MEASURE)]
        public string? Size { get; set; }


        [Display(Name = StringConstants.Display.QUANTITY)]
        [Range(1, int.MaxValue)]
        [Required(ErrorMessage = StringConstants.Error.MANDATORY_FIELD)]
        public int Quantity { get; set; }


        [Display(Name = StringConstants.Display.OBSERVATION)]
        public string? Observation { get; set; }

        public bool IsNumericSize { get; set; } = false;

    }
}
