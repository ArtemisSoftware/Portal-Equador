using PortalEquador.Contracts;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Domain.GroupTypes.Repository
{
    public interface GroupRepository : IGenericRepository<GroupEntity>
    {
        public Task<List<GroupViewModel>> GetAll();
    }
}
