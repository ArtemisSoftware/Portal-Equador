using PortalEquador.Data.GroupTypes.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Scheduler.Entities
{
    public class MechanicalWorkshopSchedulerEntity : BaseEntity
    {
        public int InterventionTimeId { get; set; }

        [ForeignKey("InterventionTimeId")]
        public GroupItemEntity InterventionTimeGroupItemEntity { get; set; }

        public int MechanicId { get; set; }

        [ForeignKey("MechanicId")]
        public GroupItemEntity MechanicGroupItemEntity { get; set; }

        public string LicencePlate { get; set; }


        public DateTime ScheduleDate { get; set; }

        //public string? Observation { get; set; }

        //public string? Observation { get; set; }

        //HORARIO  CONTRATO    CODIGO SERVIÇO MODELO TELEFONE
    }
}
