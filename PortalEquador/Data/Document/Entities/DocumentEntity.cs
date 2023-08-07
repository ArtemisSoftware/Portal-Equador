using PortalEquador.Data.GroupTypes.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.Document.Entities
{
    public class DocumentEntity : BaseEntity
    {

        public string FileExtension { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int CurriculumId { get; set; }

        public int GroupItemId { get; set; }

        //[ForeignKey("GroupItemId")]
        public GroupItemEntity GroupItem { get; set; }

    }
}

