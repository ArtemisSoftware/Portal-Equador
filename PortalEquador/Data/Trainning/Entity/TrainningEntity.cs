using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Trainning.Entity
{
    public class TrainningEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public DateTime Date { get; set; }

        public int TrainningId { get; set; }

        [ForeignKey("TrainningId")]
        public GroupItemEntity TrainningGroupItemEntity { get; set; }

        public string? Nature { get; set; }

        public string? Observation { get; set; }

    }
}
