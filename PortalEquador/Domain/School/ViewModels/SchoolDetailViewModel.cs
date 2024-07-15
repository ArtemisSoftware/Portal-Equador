using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.School.ViewModels
{
    public class SchoolDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }


        [Display(Name = StringConstants.Display.INSTITUTION)]
        public GroupItemViewModel Institution { get; set; }

        [Display(Name = StringConstants.Display.DEGREE)]
        public GroupItemViewModel Degree { get; set; }
    }
}
