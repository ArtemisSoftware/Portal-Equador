using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Profession.Competence.ViewModels
{
    public class ProfessionalCompetenceDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.PROFESSIONAL_COMPETENCE)]
        public GroupItemViewModel Competence { get; set; }
    }
}