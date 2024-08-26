namespace PortalEquador.Data.GroupTypes.entities
{
    public class GroupEntity : BaseEntity
    {
        public required string Description { get; set; }

        public string? Observation { get; set; }
    }
}
