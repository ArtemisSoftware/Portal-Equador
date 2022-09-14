using PortalEquador.Data.GroupTypes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Models.GroupTypes
{
    public class GroupItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Description { get; set; }

        [Display(Name = "Observação")]
        [MaxLength(140, ErrorMessage = "Excedido o numero máximo de caractéres")]
        public string? Observation { get; set; }


        [Required]
        public int GroupId { get; set; }

        public string? Occurred { get; set; }
    }
}
