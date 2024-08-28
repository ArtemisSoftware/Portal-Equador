using AutoMapper;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Data.GroupTypes.repository
{
    public class GroupItemRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<GroupItemEntity>(context, httpContextAccessor), GroupItemRepository
    {

        public async Task<List<GroupItemViewModel>> GetAll(int groupId)
        {
            return new List<GroupItemViewModel>();
            /*
            var result = await context.GroupItemEntity
                .Include(item => item.GroupEntity)
                .Include(item => item.ApplicationUserEntity)
                .Where(item => item.GroupEntityId == groupId)
                .ToListAsync();

            return mapper.Map<List<GroupItemViewModel>>(result);
            */
        }

        public async Task<GroupViewModel?> GetGroupItem(int id)
        {
            return null;
            /*
            var result = await context.GroupItemEntity
                           .Include(item => item.GroupEntity)
                           .Where(item => item.Id == id)
                           .FirstOrDefaultAsync();

            return mapper.Map<GroupItemViewModel>(result);
            */
        }

        public async Task<bool> GetGroupItemExists(int groupId, string description)
        {
            return false;
            //return await context.GroupItemEntity.AnyAsync(item => item.GroupEntityId == groupId && item.Description == description);
        }

        public async Task Save(GroupItemViewModel model)
        {
            GroupItemEntity entity = mapper.Map<GroupItemEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (model.Id == 0)
            {
                await AddAsync(entity);
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }
    }
}
