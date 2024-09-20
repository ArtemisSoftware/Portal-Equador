using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Education.School.Entity
{
    public class SchoolEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int InstitutionId { get; set; }

        [ForeignKey("InstitutionId")]
        public GroupItemEntity InstitutionGroupItemEntity { get; set; }

        public int MajorId { get; set; }

        [ForeignKey("MajorId")]
        public GroupItemEntity MajorGroupItemEntity { get; set; }


        public int DegreeId { get; set; }

        [ForeignKey("DegreeId")]
        public GroupItemEntity DegreeGroupItemEntity { get; set; }

    }
}