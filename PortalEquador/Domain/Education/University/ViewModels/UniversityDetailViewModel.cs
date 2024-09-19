using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Education.University.ViewModels
{
    public class UniversityDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.INSTITUTION)]
        public GroupItemViewModel Institution { get; set; }

        [Display(Name = StringConstants.Display.DEGREE)]
        public GroupItemViewModel Degree { get; set; }
    }
}