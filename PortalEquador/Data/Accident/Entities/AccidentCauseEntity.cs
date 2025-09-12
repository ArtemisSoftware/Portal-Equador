using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Accident.Entities
{
    public class AccidentCauseEntity : BaseEntity
    {
        public int AccidentId { get; set; }

        [ForeignKey("AccidentId")]
        public AccidentEntity AccidentEntity { get; set; }


        public int CauseId { get; set; }

        [ForeignKey("CauseId")]
        public GroupItemEntity CauseGroupItemEntity { get; set; }
    }
}
