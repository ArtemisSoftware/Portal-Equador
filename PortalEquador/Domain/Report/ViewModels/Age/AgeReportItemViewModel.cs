using PortalEquador.Domain.Generic;
using PortalEquador.Util;

namespace PortalEquador.Domain.Report.ViewModels.Age
{
    public class AgeReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string WorkStation { get; set; }

        public string? Agency { get; set; }

        public int Age()
        {
            return TimeUtil.GetAge(DateOfBirth);
        }
    }
}
