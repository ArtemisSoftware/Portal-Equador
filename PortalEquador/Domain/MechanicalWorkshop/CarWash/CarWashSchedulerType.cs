namespace PortalEquador.Domain.MechanicalWorkshop.CarWash
{
    public enum CarWashSchedulerType
    {
        Free,
        BlockedFree,
        InSchedule,
        BlockedDateInThePast,

        Complete,
        NoShow,
        Blocked,
    }
}
