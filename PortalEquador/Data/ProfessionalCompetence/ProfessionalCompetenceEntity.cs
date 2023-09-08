using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.ProfessionalCompetence
{
    public class ProfessionalCompetenceEntity : BaseEntity
    {

        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int ExperienceId { get; set; }

        [ForeignKey("ExperienceId")]
        public GroupItemEntity ExperienceGroupItemEntity { get; set; }

    }
}
