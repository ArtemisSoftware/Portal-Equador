﻿using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.CurriculumVitae.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace PortalEquador.Data.PInformation.Entities
{
    public class PersonalInformationEntity : BaseEntity
    {
        public int CurriculumId { get; set; }

        /// <summary>
        /// Numero do bilhete de identidade
        /// </summary>
        public string IdentityCard { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Email { get; set; }

        public string Contacts { get; set; }

        public int NationalityId { get; set; }

        public int NeighbourhoodId { get; set; }

        public string Address { get; set; }

        public int MaritalStatusId { get; set; }



        [ForeignKey("CurriculumId")]
        public CurriculumEntity Curriculum { get; set; }
    }
}
