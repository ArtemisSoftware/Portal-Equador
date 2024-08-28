using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupItemRepository : IGenericRepository<GroupItemEntity>
    {
        Task Save(GroupItemViewModel model);
        Task<List<GroupItemViewModel>> GetAll(int groupId);
        Task<GroupViewModel?> GetGroupItem(int id);
        Task<bool> GetGroupItemExists(int groupId, string description);
    }
}
