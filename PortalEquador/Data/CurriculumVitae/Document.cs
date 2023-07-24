using PortalEquador.Data.GroupTypes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalEquador.Data.CurriculumVitae
{
    public class Document : BaseEntity
    {

        public string FileExtension { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        public int CurriculumId { get; set; }


        [ForeignKey("GroupItemId")]
        public GroupItem GroupItem { get; set; }

        public int GroupItemId { get; set; }
    }
}

