using PortalEquador.Contracts;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupItemRepository : IGenericRepository<GroupItemEntity>
    {
        Task<bool> GroupItemExists(GroupItemViewModel model);

        Task<List<GroupItemViewModel>> GetAllAsync(int groupId);

        Task<GroupItemViewModel?> GetGroupItemAsync(int groupItemId);
    }
}
