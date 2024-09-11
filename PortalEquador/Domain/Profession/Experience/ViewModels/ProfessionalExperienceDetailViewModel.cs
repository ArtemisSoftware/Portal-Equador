using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Profession.Experience.ViewModels
{
    public class ProfessionalExperienceDetailViewModel: ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.PROFESSIONAL_EXPERIENCE)]
        public GroupItemViewModel ProfessionalExperience { get; set; }

        [Display(Name = StringConstants.Display.WORKSTATION)]
        public GroupItemViewModel Workstation { get; set; }

        public int Months { get; set; }

        [Display(Name = StringConstants.Display.DURATION)]
        public string Duration
        {
            get
            {
                int years = Months / 12;
                int remainingMonths = Months % 12;
                var result = "";

                if (years == 1)
                {
                    result = $"{years} ano ";
                }
                else if (years > 1)
                {
                    result = $"{years} anos ";
                }
                else { }

                if (remainingMonths == 1 && years == 0)
                {
                    result += $" {remainingMonths} mes";
                }
                else if (remainingMonths > 1 && years == 0)
                {
                    result += $"{remainingMonths} meses ";
                }
                else if (remainingMonths == 1)
                {
                    result += $" e {remainingMonths} mes";
                }
                else if (remainingMonths > 1)
                {
                    result += $" e {remainingMonths} meses ";
                }
                return result;

            }
        }
    }
}