using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.GroupTypes.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.Security.Claims;

namespace PortalEquador.Data.GroupTypes.repository
{
    public class GroupRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<GroupEntity>(context, httpContextAccessor), GroupRepository
    {


        public async Task<List<GroupViewModel>> GetAllGroups()
        {
            var result = await context.GroupEntity
                .Include(d => d.ApplicationUserEntity)
                .ToListAsync();

            var models = mapper.Map<List<GroupViewModel>>(result);
            return models;
        }

        public async Task<GroupViewModel?> GetGroup(int? id)
        {
            var entity = await context.GroupEntity
                .Include(d => d.ApplicationUserEntity)
                .Where(item => item.Id == id)
                .FirstAsync();

            if (entity == null)
            {
                return null;
            }

            var model = mapper.Map<GroupViewModel>(entity);
            return model;
        }

        public async Task<bool> GroupExists(string description)
        {
            return await context.GroupEntity.AnyAsync(item => item.Description == description);
        }

        public async Task Save(GroupViewModel model)
        {
            GroupEntity entity = mapper.Map<GroupEntity>(model);
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
