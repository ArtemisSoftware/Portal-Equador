using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Languages.entity
{
    public class LanguageEntity : BaseEntity
    {
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public GroupItemEntity LanguageGroupItemEntity { get; set; }

        public bool IsMaternalLanguage { get; set; } = false;

        public int OralLevelId { get; set; }

        [ForeignKey("OralLevelId")]
        public GroupItemEntity OralLevelGroupItemEntity { get; set; }

        public int WrittenLevelId { get; set; }

        [ForeignKey("WrittenLevelId")]
        public GroupItemEntity WrittenLevelGroupItemEntity { get; set; }

        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }
    }
}