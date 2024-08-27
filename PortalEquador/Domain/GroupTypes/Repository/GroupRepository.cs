using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupRepository : IGenericRepository<GroupEntity>
    {
        public Task Save(GroupViewModel model/*, OperationType operationType*/);

        public Task<List<GroupViewModel>> GetAllGroups();
        public Task<bool> GroupExists(string description);
    }
}
