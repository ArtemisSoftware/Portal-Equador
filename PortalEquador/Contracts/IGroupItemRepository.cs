using PortalEquador.Data.GroupTypes.Entities;

namespace PortalEquador.Contracts
{
    public interface IGroupItemRepository : IGenericRepository<GroupItemEntity>
    {
        Task<bool> GroupItemExists(int groupId, string description);

        Task<List<GroupItemEntity>> GetAllAsync(int groupId);
    }
}
