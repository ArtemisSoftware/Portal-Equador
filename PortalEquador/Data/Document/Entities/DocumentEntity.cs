using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Document.Entities
{
    public class DocumentEntity : BaseEntity
    {

        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public string? Observation { get; set; }

        public int DocumentTypeId { get; set; }

        [ForeignKey("DocumentTypeId")]
        public GroupItemEntity DocumentTypeGroupItemEntity { get; set; }

        public string Extension { get; set; }

    }
}

