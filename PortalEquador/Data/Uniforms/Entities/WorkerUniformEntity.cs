using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Uniforms.Entities
{
    public class WorkerUniformEntity : BaseEntity
    {
        public int PersonalInformationId { get; set; }

        [ForeignKey("PersonalInformationId")]
        public PersonalInformationEntity PersonalInformationEntity { get; set; }

        public int UniformId { get; set; }

        [ForeignKey("UniformId")]
        public UniformEntity UniformItemEntity { get; set; }


        public int Quantity { get; set; }

        public string Size { get; set; }

        public DateTime Date { get; set; }

        public string? Observation { get; set; }
    }
}
