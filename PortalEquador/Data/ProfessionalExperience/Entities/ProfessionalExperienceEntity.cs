using PortalEquador.Data.CurriculumVitae.Entities;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.ProfessionalExperience.Entities
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
