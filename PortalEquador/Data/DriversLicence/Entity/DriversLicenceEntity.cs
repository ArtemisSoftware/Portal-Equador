using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.DriversLicence.Entity
{
    public class DriversLicenceEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int LicenceTypeId { get; set; }

        [ForeignKey("LicenceTypeId")]
        public GroupItemEntity LicenceTypeGroupItemEntity { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? ProvisionalRenewalNumber { get; set; }
        public DateTime? ProvisionalExpirationDate { get; set; }
    }
}