using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Profession.Experience.ViewModels
{
    public class ProfessionalExperienceDetailViewModel: ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.WORKSTATION)]
        public GroupItemViewModel Workstation { get; set; }

        [Display(Name = StringConstants.Display.COMPANY)]
        public GroupItemViewModel Company { get; set; }

        public int Months { get; set; }

        [Display(Name = StringConstants.Display.DURATION)]
        public string Duration
        {
            get
            {

                return TimeUtil.GetYearsAndMonthsFromMonths(Months);
            }
        }
    }
}