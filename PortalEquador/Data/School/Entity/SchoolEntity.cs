using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.School.Entity
{
    public class SchoolEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int InstitutionId { get; set; }

        [ForeignKey("InstitutionId")]
        public GroupItemEntity InstitutionGroupItemEntity { get; set; }

        public int DegreeId { get; set; }

        [ForeignKey("DegreeId")]
        public GroupItemEntity DegreeGroupItemEntity { get; set; }

        public int LevelId { get; set; }
    }
}
