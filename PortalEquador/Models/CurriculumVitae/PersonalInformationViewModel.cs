using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Models.CurriculumVitae
{
    public class PersonalInformationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string FirstName { get; set; }
    }
}
