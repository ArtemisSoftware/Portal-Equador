using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupRepository : IGenericRepository<GroupEntity>
    {
        public Task Save(GroupViewModel model);

        public Task<List<GroupViewModel>> GetAllGroups();
        public Task<GroupViewModel?> GetGroup(int? id);
        public Task<bool> GroupExists(string description);
    }
}
