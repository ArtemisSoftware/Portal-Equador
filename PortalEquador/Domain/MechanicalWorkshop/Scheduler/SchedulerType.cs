namespace PortalEquador.Domain.MechanicalWorkshop.Scheduler
{
    public enum SchedulerType
    {
        Free,
        BlockedFree,
        InSchedule,
        BlockedDateInThePast,

        Complete,
        Blocked,
    }
}
