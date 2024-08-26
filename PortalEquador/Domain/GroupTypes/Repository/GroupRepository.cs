using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupRepository : IGenericRepository<GroupEntity>
    {
        public Task<List<GroupViewModel>> GetAll();
        public Task<bool> GroupExists(string description);
    }
}
