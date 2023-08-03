using PortalEquador.Data.GroupTypes.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Models.Documents
{
    public class DocumentDetailViewModel
    {
        public int CurriculumId { get; set; }

        public string FileExtension { get; set; }

        public GroupItemEntity GroupItem { get; set; }

        public int GroupItemId { get; set; }

        [Display(Name = "Documento")]
        public string FileName
        {
            get { return GroupItem.Description; }
        }


        public string FilePath
        {
            get { return "~/images/" + CurriculumId + "/" + GroupItemId + FileExtension; }
        }
    }
}
