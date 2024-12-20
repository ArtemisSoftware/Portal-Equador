﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Data.Generic
{
    public partial class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        public required string EditorId { get; set; }

        [ForeignKey("EditorId")]
        public required ApplicationUser ApplicationUserEntity { get; set; }

        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
