using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Profession.Experience.ViewModels
{
    public class ProfessionalExperienceViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.YEARS)]
        public int Years { get; set; }

        [Display(Name = StringConstants.Display.MONTHS)]
        public int Months { get; set; }

        [Display(Name = StringConstants.Display.COMPANY)]
        [Required]
        public int CompanyId { get; set; }

        public SelectList? Companies { get; set; }

        [Display(Name = StringConstants.Display.WORKSTATION)]
        [Required]
        public int WorkstationId { get; set; }

        public SelectList? Workstations { get; set; }


        [Display(Name = StringConstants.Display.COMPANY)]
        public GroupItemViewModel? Company { get; set; }

        [Display(Name = StringConstants.Display.WORKSTATION)]
        public GroupItemViewModel? Workstation { get; set; }

        public bool IsValidDuration()
        {
            if (Years <= 0 && Months <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int NumberOfMonths()
        {
            return Years * 12 + Months;
        }

        public int WorkYears()
        {
            return Months / 12;
        }

        public int WorkMonths()
        {
            return Months % 12;
        }
    }
}