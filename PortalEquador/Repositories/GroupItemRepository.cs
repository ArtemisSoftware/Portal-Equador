using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes;

namespace PortalEquador.Repositories
{
    public class GroupItemRepository : GenericRepository<GroupItem>, IGroupItemRepository
    {
        private readonly ApplicationDbContext context;

        public GroupItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> GroupItemExists(int groupId, string description)
        {
            return await context.GroupItems.AnyAsync(
                item => item.GroupId == groupId
                && item.Description == description
                );
        }


        public async Task<List<GroupItem>> GetAllAsync(int groupId)
        {
            return await context.GroupItems
                .Include(item => item.Group)
                .Where(item => item.GroupId == groupId).ToListAsync();
        }
    }
    
}
