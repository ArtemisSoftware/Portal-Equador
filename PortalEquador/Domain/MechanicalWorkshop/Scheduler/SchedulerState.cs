using PortalEquador.Util.Constants;
using System.ComponentModel;

namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler
{
    public class SchedulerState
    {
        [Description(StringConstants.SchedulerStatus.PERFORMED)]
        public const int Performed = 1;

        [Description(StringConstants.SchedulerStatus.NOT_PERFORMED)]
        public const int NotPerformed = 2;

        public const int Open = 3;
    }
}
