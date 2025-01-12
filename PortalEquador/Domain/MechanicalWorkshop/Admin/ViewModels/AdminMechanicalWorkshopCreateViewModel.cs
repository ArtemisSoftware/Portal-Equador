using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels
{
    public class AdminMechanicalWorkshopCreateViewModel: ViewModel
    {
        public List<GroupItemViewModel> Contracts { get; set; }
        public SelectList Users { get; internal set; }
        public List<AdminUser> UserDetails { get; internal set; }
    }
}
