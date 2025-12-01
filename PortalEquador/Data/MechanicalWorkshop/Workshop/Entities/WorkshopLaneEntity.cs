using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.MechanicalWorkshop.Workshop.Entities
{
    public class WorkshopLaneEntity : BaseEntity
    {
        public int WorkshopId { get; set; }

        [ForeignKey("WorkshopId")]
        public WorkshopEntity WorkshopEntity { get; set; }


        public required string Name { get; set; }

        public bool Active { get; set; }
    }
}
