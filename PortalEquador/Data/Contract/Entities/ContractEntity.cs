using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Contract.Entities
{
    public class ContractEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }


        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public bool UndeterminateDuration { get; set; }
        public DateTime? EndDate { get; set; } = null;
        
        
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public GroupItemEntity LocationGroupItemEntity { get; set; }

        public DateTime LocationDate { get; set; }

        public int RegimentId { get; set; }

        [ForeignKey("RegimentId")]
        public GroupItemEntity RegimentGroupItemEntity { get; set; }


        public string? Observation { get; set; }
    }
}
