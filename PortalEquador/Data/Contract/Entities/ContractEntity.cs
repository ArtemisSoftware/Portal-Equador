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

        public int? ContractId { get; set; }

        [ForeignKey("ContractId")]
        public GroupItemEntity? ContractGroupItemEntity { get; set; }


        public int? ResignationReasonId { get; set; }

        [ForeignKey("ResignationReasonId")]
        public GroupItemEntity? ResignationReasonGroupItemEntity { get; set; }

        public int ContractStateId { get; set; }

        [ForeignKey("ContractStateId")]
        public GroupItemEntity ContractStateGroupItemEntity { get; set; }

        public string? Observation { get; set; }
    }
}
