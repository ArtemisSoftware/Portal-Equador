using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Data
{
    public partial class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
