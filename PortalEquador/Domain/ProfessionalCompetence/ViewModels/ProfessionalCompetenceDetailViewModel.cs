using PortalEquador.Constants;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Domain.ProfessionalCompetence.ViewModels
{
    public class ProfessionalCompetenceDetailViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public PersonalInformationViewModel? PersonalInformation { get; set; }

        [Display(Name = StringConstants.Display.PROFESSIONAL_COMPETENCE)]
        public GroupItemViewModel ProfessionalCompetence { get; set; }
    }
}
