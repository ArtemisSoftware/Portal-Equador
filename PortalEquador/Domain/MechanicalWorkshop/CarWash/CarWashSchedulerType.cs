namespace PortalEquador.Domain.MechanicalWorkshop.CarWash
{
    public enum CarWashSchedulerType
    {
        
        Free, // slot is available 
        BlockedFree,
        InSchedule,
        BlockedDateInThePast,

        Complete,
        NoShow,
        Blocked, // slot has filled but user cannot have access to it
    }
}
