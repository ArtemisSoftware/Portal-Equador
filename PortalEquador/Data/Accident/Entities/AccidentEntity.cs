using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Accident.Entities
{
    public class AccidentEntity
    {

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public MechanicalWorkshopVehicleEntity VehicleEntity { get; set; }


        public string Address { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public GroupItemEntity CityGroupItemEntity { get; set; }


        public int CauseId { get; set; }

        [ForeignKey("CauseId")]
        public GroupItemEntity CauseGroupItemEntity { get; set; }

        public int EstimatedValueId { get; set; }

        [ForeignKey("EstimatedValueId")]
        public GroupItemEntity EstimatedValueGroupItemEntity { get; set; }

        public int HumanDamage { get; set; } = 0;


        public int LevelId { get; set; }

        [ForeignKey("LevelId")]
        public GroupItemEntity LevelGroupItemEntity { get; set; }

    }
}
