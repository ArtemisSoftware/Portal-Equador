using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.GroupTypes.Entities
{
    public class GroupItemEntity : BaseEntity
    {

        public string Description { get; set; }

        public string? Observation { get; set; }


        [ForeignKey("GroupId")]
        public GroupEntity Group { get; set; }

        public int GroupId { get; set; }
    }
}
