using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Languages.ViewModels
{
    public class LanguageViewModel : ViewModel
    {
        public int Id { get; set; }

        public int PersonaInformationId { get; set; }

        public required string FullName { get; set; }

        [Display(Name = StringConstants.Display.MATERNAL_LANGUANGE)]
        public bool IsMaternalLanguage { get; set; }

        [Display(Name = StringConstants.Display.LANGUANGE)]
        [Required]
        public int LanguageId { get; set; }
        public GroupItemViewModel? Language { get; set; }

        public SelectList? Languages { get; set; }

        [Display(Name = StringConstants.Display.ORAL_LEVEL)]
        [Required]
        public int OralLevelId { get; set; }

        public SelectList? OralLevels { get; set; }

        [Display(Name = StringConstants.Display.WRITTEN_LEVEL)]
        [Required]
        public int WrittenLevelId { get; set; }

        public SelectList? WrittenLevels { get; set; }
    }
}
