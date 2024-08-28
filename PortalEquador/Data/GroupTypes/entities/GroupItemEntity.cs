using PortalEquador.Data.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PortalEquador.Data.GroupTypes.entities
{
    public class GroupItemEntity : BaseEntity
    {
        public required string Description { get; set; }

        public string? Observation { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        public int GroupEntityId { get; set; }

        [ForeignKey("GroupEntityId")]
        public required GroupEntity GroupEntity { get; set; }
    }
}
