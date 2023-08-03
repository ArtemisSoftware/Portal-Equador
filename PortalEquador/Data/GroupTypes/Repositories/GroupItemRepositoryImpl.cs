using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Repositories;

namespace PortalEquador.Data.GroupTypes.Repositories
{
    public class GroupItemRepositoryImpl : GenericRepository<GroupItemEntity>, IGroupItemRepository
    {
        private readonly ApplicationDbContext context;

        public GroupItemRepositoryImpl(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> GroupItemExists(int groupId, string description)
        {
            return true;
            /*
            return await context.GroupItems.AnyAsync(
                item => item.GroupId == groupId
                && item.Description == description
                );
            */
        }


        public async Task<List<GroupItemEntity>> GetAllAsync(int groupId)
        {
            return new List<GroupItemEntity>();
            /*
            return await context.GroupItems
                .Include(item => item.Group)
                .Where(item => item.GroupId == groupId).ToListAsync();
            */
        }
    }

}
