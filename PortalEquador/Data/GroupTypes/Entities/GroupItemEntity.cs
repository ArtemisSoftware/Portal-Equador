using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.GroupTypes.Entities
{
    public class GroupItemEntity : BaseEntity
    {

        public string Description { get; set; }

        public string? Observation { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

        [ForeignKey("GroupEntityId")]
        public GroupEntity GroupEntity { get; set; }

        public int GroupEntityId { get; set; }
    }
}
