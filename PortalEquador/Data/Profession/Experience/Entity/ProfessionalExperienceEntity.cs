using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Profession.Experience.Entity
{
    public class ProfessionalExperienceEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public GroupItemEntity CompanyGroupItemEntity { get; set; }

        public int WorkstationId { get; set; }

        [ForeignKey("WorkstationId")]
        public GroupItemEntity WorkstationGroupItemEntity { get; set; }

        public int Months { get; set; }

    }
}