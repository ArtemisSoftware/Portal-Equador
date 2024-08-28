using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.Text.RegularExpressions;

namespace PortalEquador.Data.GroupTypes.repository
{
    public class GroupItemRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<GroupItemEntity>(context, httpContextAccessor), GroupItemRepository
    {

        public async Task<List<GroupItemViewModel>> GetAll(int groupId)
        {
            var result = await context.GroupItemEntity
                .Include(item => item.GroupEntity)
                .Include(item => item.ApplicationUserEntity)
                .Where(item => item.GroupEntityId == groupId)
                .ToListAsync();

            return mapper.Map<List<GroupItemViewModel>>(result);
        }

        public async Task<GroupItemViewModel?> GetGroupItem(int id)
        {
            var result = await context.GroupItemEntity
                .Include(item => item.GroupEntity)
                .Include(item => item.ApplicationUserEntity)
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();

            return mapper.Map<GroupItemViewModel>(result);
            
        }

        public async Task<bool> GroupItemExists(int groupId, string description)
        {
            return await context.GroupItemEntity.AnyAsync(item => item.GroupEntityId == groupId && item.Description == description);
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

        public async Task UpdateState(int groupItemId, bool active)
        {
            GroupItemEntity? entity = await GetAsync(groupItemId);

            if(entity != null) { 
                entity.Active = active;
                entity.EditorId = GetCurrentUserId();
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }

    }
}
