using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupItemRepository : IGenericRepository<GroupItemEntity>
    {
        Task Save(GroupItemViewModel model);
        Task<List<GroupItemViewModel>> GetAll(int groupId);
        Task<GroupItemViewModel?> GetGroupItem(int id);
        Task<bool> GroupItemExists(int groupId, string description);
        Task UpdateState(int groupItemId, bool active);
    }
}
