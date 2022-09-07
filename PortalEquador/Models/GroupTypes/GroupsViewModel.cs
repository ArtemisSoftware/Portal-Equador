using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PortalEquador.Models.GroupTypes
{
    public class GroupsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Observação")]
        public string? Observation { get; set; }
    }
}
