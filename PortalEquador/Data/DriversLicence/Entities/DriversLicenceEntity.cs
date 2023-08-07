using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.DriversLicence.Entities
{
    public class DriversLicenceEntity : BaseEntity
    {
        public int CurriculumId { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? ProvisionalRenewalNumber { get; set; }
        public DateTime? ProvisionalExpirationDate { get; set; }

        public int GroupItemId { get; set; }

        //[ForeignKey("GroupItemId")]
        public GroupItemEntity GroupItem { get; set; }
    }
}
