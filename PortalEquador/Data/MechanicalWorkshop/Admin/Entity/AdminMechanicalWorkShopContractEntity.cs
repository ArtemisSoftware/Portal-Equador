using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.MechanicalWorkshop.Admin.Entity
{
    public class AdminMechanicalWorkShopContractEntity : BaseEntity
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        [ForeignKey("ContractId")]
        public GroupItemEntity ContractGroupItemEntity { get; set; }
    }
}
