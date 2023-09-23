using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.ProfessionalCompetence.Entities
{
    public class ProfessionalCompetenceEntity : BaseEntity
    {

        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int CompetenceId { get; set; }

        [ForeignKey("CompetenceId")]
        public GroupItemEntity CompetenceGroupItemEntity { get; set; }

    }
}
