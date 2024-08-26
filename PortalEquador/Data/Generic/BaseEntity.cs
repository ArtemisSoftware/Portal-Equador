using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Data.Generic
{
    public partial class BaseEntity
    {
        //[Key]
        public int Id { get; set; }

        public int EditorId { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
