using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using System.Security.Claims;

namespace PortalEquador.Data.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;
        protected readonly IHttpContextAccessor httpContextAccessor;

        public GenericRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }

        public string GetCurrentUserRole()
        {
            var role = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            return role;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if(entity != null) {
                context.Set<T>().Remove(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public SelectList GroupItems(int groupId, OrderType orderType = OrderType.No_order)
        {
            var result = context.GroupItemEntity.Where(x => x.GroupEntityId == groupId & x.Active == true);

            switch (orderType)
            {
                case OrderType.No_order:
                    break;

                case OrderType.Alphabetic:
                    result = result.OrderBy(x => x.Description);
                    break;

                default:
                break;
            }

            return new SelectList(result, "Id", "Description");
        }

        public async Task<List<GroupItemEntity>> GroupItemsList(int groupId)
        {
            var result = await context.GroupItemEntity.Where(x => x.GroupEntityId == groupId & x.Active == true).ToListAsync();
            return result;
        }

        public async Task<GroupItemEntity> GroupItem(int itemId)
        {
            var result = await context.GroupItemEntity.Where(x => x.Id == itemId).FirstAsync();
            return result;
        }
    }
}
