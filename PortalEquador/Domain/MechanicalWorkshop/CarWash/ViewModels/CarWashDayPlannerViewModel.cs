using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
using System.ComponentModel.DataAnnotations;

namespace PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels
{
    public class CarWashDayPlannerViewModel : ViewModel
    {
        [Display(Name = StringConstants.Display.DATE)]
        [DisplayFormat(DataFormatString = StringConstants.Dates.DD_MM_YYYY)]
        [DataType(DataType.Date)]
        public DateTime MainTime { get; set; } = DateTime.Now;

        public List<GroupItemViewModel> Schedules { get; set; }
    }
}
