using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.DisciplinaryNotification.Entity
{
    public class DisciplinaryNotificationEntity: BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public DateTime Date { get; set; }

        public int NotificationId { get; set; }

        [ForeignKey("NotificationId")]
        public GroupItemEntity NotificationGroupItemEntity { get; set; }

        public string? Local { get; set; }

        public int AccidentLevelId { get; set; }

        [ForeignKey("AccidentLevelId")]
        public GroupItemEntity AccidentLevelGroupItemEntity { get; set; }

        public string? Decision { get; set; }

        public string? Observation { get; set; }

    }
}
