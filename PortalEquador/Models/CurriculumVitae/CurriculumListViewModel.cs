using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Models.CurriculumVitae
{
    public class CurriculumListViewModel
    {
        public string Id { get; set; }

        public int CurriculumId { get; set; }

        [Display(Name = "Bilhete de Identidade")]
        public string IdentityCard { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateModified { get; set; }

        /*
        [Required]
        public int PersonalInformationId { get; set; }
        */

        [Display(Name = "Nome")]
        public string FullName { 
            get
            {
                return FirstName + " " + LastName;
            } 
        }
    }
}
