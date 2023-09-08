using NuGet.Packaging.Signing;
using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace PortalEquador.Domain.ProfessionalExperience.ViewModels
{
    public class ProfessionalExperienceDetailViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.PROFESSIONAL_EXPERIENCE)]
        public GroupItemViewModel ProfessionalExperience { get; set; }

        public int Months { get; set; }

        [Display(Name = StringConstants.Display.DURATION)]
        public string Duration
        {
            get
            {
                int years = Months / 12;
                int remainingMonths = Months % 12;
                var result = "";
                
              if(years ==  1)
                {
                    result = $"{years} ano ";
                }      
              if( years > 1)
                {
                    result = $"{years} anos ";
                }
                
                if (remainingMonths == 1)
                {
                    result += $" e {remainingMonths} mes";
                }
                if (years > 1)
                {
                    result += $" e {remainingMonths} meses ";
                }
                return result;
                
            }
        }
    }
}
