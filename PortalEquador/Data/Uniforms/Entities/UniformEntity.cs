using PortalEquador.Data.Generic;
using System.ComponentModel;

namespace PortalEquador.Data.Uniforms.Entities
{
    public class UniformEntity : BaseEntity
    {
        public required string Description { get; set; }

        public string? Observation { get; set; }

        [DefaultValue(true)]
        public bool isSizeNumeric { get; set; } = true;

        [DefaultValue(true)]
        public bool Active { get; set; } = true;
    }
}
