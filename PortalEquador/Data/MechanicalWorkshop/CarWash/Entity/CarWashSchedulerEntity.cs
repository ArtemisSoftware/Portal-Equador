﻿using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.MechanicalWorkshop.CarWash.Entity
{
    public class CarWashSchedulerEntity : BaseEntity
    {
        public DateOnly ScheduleDate { get; set; }

        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public MechanicalWorkshopVehicleEntity VehicleEntity { get; set; }

        public int LaneId { get; set; }

        [ForeignKey("LaneId")]
        public GroupItemEntity LaneGroupItemEntity { get; set; }

        public int ContractId { get; set; }

        [ForeignKey("ContractId")]
        public GroupItemEntity ContractGroupItemEntity { get; set; }


        public int InterventionTimeId { get; set; }

        [ForeignKey("InterventionTimeId")]
        public GroupItemEntity InterventionTimeGroupItemEntity { get; set; }

        public int CurrentState { get; set; }
    }
}
