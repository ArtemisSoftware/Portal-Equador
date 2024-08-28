using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.PersonalInformation
{
    public class PersonalInformationEntity : BaseEntity
    {

        /// <summary>
        /// Numero do bilhete de identidade
        /// </summary>
        public string IdentityCard { get; set; }

        public string Nif { get; set; }

        public DateTime IdentityCardExpirationDate { get; set; }

        public string? BeneficiaryNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Email { get; set; }

        public string Contacts { get; set; }

        public int NationalityId { get; set; }

        [ForeignKey("NationalityId")]
        public GroupItemEntity NationalityGroupItemEntity { get; set; }

        public int? ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public GroupItemEntity ProvinceGroupItemEntity { get; set; }

        public int NeighbourhoodId { get; set; }

        [ForeignKey("NeighbourhoodId")]
        public GroupItemEntity NeighbourhoodGroupItemEntity { get; set; }

        public string Address { get; set; }

        public int? MotherTongueId { get; set; }

        [ForeignKey("MotherTongueId")]
        public GroupItemEntity MotherTongueGroupItemEntity { get; set; }

        public int? MaritalStatusId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public GroupItemEntity MaritalStatusIdGroupItemEntity { get; set; }

    }
}
