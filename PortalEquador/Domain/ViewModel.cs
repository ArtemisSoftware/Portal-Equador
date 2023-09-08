using PortalEquador.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain
{
    public class ViewModel
    {
        [Display(Name = StringConstants.Display.REGISTER_CREATION_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM)]
        public DateTime DateCreated { get; set; }

        [Display(Name = StringConstants.Display.REGISTER_LAST_UPDATE_DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY__HH_MM)]
        public DateTime? DateModified { get; set; }

        public string? Error { get; set; }
    }
}
