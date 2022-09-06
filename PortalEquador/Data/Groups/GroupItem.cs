using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Groups
{
    public class GroupItem : BaseEntity
    {

        public string Description { get; set; }

        public string? Observation { get; set; }


        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public int GroupId { get; set; }
    }
}
