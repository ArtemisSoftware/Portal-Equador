using PortalEquador.Data.Generic;

namespace PortalEquador.Data.MechanicalWorkshop.Workshop.Entities
{
    public class WorkshopEntity : BaseEntity
    {
        public required string Name { get; set; }
        public bool Active { get; set; }
        public List<WorkshopLaneEntity> Lanes { get; set; } = new();
        public List<WorkshopMechanicEntity> Mechanics { get; set; } = new();
    }
}
