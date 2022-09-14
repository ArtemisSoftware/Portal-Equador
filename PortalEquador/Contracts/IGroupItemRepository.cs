using PortalEquador.Data.GroupTypes;

namespace PortalEquador.Contracts
{
    public interface IGroupItemRepository : IGenericRepository<GroupItem>
    {
        Task<bool> GroupItemExists(int groupId, string description);

        Task<List<GroupItem>> GetAllAsync(int groupId);
    }
}
