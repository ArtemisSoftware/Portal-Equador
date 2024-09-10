using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.Languages.ViewModels
{
    public class LanguageDetailViewModel : ViewModel
    {
        public int Id { get; set; }

        [Display(Name = StringConstants.Display.MATERNAL_LANGUANGE)]
        public bool IsMaternalLanguage { get; set; }

        [Display(Name = StringConstants.Display.LANGUANGE)]
        public GroupItemViewModel Language { get; set; }

        [Display(Name = StringConstants.Display.ORAL_LEVEL)]
        public GroupItemViewModel OralLevel { get; set; }

        [Display(Name = StringConstants.Display.WRITTEN_LEVEL)]
        public GroupItemViewModel WrittenLevel { get; set; }
    }
}