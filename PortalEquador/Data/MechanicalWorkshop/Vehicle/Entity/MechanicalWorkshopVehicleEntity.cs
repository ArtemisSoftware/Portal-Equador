using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity
{
    public class MechanicalWorkshopVehicleEntity : BaseEntity
    {
        public required string LicencePlate { get; set; }
        public required string Model { get; set; }

        public int ContractId { get; set; }

        [ForeignKey("ContractId")]
        public GroupItemEntity ContractGroupItemEntity { get; set; }

        public bool Active { get; set; }
    }
}
