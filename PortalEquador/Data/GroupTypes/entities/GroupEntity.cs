using PortalEquador.Data.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.GroupTypes.entities
{
    public class GroupEntity : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public required string Description { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? Observation { get; set; }
    }
}
