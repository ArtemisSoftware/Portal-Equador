using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes;

namespace PortalEquador.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}