using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Models.GroupTypes
{
    public class GroupsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Description { get; set; }

        [Display(Name = "Observação")]
        [MaxLength(140, ErrorMessage ="Excedido o numero máximo de caractéres")]
        public string? Observation { get; set; }
    }
}
