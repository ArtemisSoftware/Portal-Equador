using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PortalEquador.Models.CurriculumVitae
{
    public class PersonalInformationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nº Bilhete de identidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string IdentityCard { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string FirstName { get; set; }

        [Display(Name = "Apelido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string LastName { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public string FullName { get {
                return FirstName + " " + LastName;
            }
        }

        public string? Occurred { get; set; }
    }
}
