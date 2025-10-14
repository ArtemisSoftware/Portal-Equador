using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Uniforms.ViewModels
{
    public class WorkerUniformViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        [Display(Name = StringConstants.Display.DELIVERY_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = StringConstants.Display.RETURN_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = StringConstants.Display.UNIFORM)]
        public UniformViewModel? Uniform { get; set; }

        [Display(Name = StringConstants.Display.QUANTITY)]
        public int Quantity { get; set; }

        [Display(Name = StringConstants.Display.SIZE)]
        public string Size { get; set; }
    }
}
