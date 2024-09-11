using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Profession.Competence.Entity
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