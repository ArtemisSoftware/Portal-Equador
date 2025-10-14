using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Uniforms.ViewModels
{
    public class WorkerUniformReturnDateViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.DELIVERY_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; } = DateTime.Now;

        [Display(Name = StringConstants.Display.RETURN_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; } = DateTime.Now;

        [Display(Name = StringConstants.Display.UNIFORM)]
        public UniformViewModel? Uniform { get; set; }


        [Display(Name = StringConstants.Display.MEASURE)]
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

    }
}
