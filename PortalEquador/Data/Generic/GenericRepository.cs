using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Util.Constants;
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

        public SelectList GroupItems(
            int groupId, 
            OrderType orderType = OrderType.No_order, 
            int idToExclude = -1, 
            string extraOption = "", 
            bool addExtraOptionOnTop = false
            )
        {
            IQueryable<GroupItemEntity> result = context.GroupItemEntity.Where(x => x.GroupEntityId == groupId & x.Active == true & x.Id != idToExclude);

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

            if(extraOption != "")
            {
                var items = result.ToList();

                var item = new GroupItemEntity
                {
                    ApplicationUserEntity = new ApplicationUser(),
                    EditorId = "",
                    Id = -1,
                    Description = extraOption,
                    GroupEntity = new GroupEntity
                    {
                        ApplicationUserEntity = new ApplicationUser(),
                        EditorId = "",
                        Description = "New Register"
                    }
                };

                // Add a new register
                if (addExtraOptionOnTop)
                {
                    items.Insert(0, item);
                } else
                {
                    items.Add(item);
                }

                return new SelectList(items, "Id", "Description");
            }
            else
            {
                return (new SelectList(result, "Id", "Description"));
            }
        }

        public SelectList GroupItems(
            int groupId,
            List<int> idsToInclude,
            OrderType orderType = OrderType.No_order
    )
        {
            IQueryable<GroupItemEntity> result = context.GroupItemEntity.Where(x => 
                x.GroupEntityId == groupId 
                & x.Active == true 
                & idsToInclude.Contains(x.Id)
             );

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

            return (new SelectList(result, "Id", "Description"));
        }

        public SelectList GroupItems(
            IQueryable<GroupItemEntity> result, 
            OrderType orderType = OrderType.No_order,  
            string extraOption = "", 
            bool addExtraOptionOnTop = false
            )
        {

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

            if (extraOption != "")
            {
                var items = result.ToList();

                var item = new GroupItemEntity
                {
                    ApplicationUserEntity = new ApplicationUser(),
                    EditorId = "",
                    Id = StringConstants.Report.ALL_ID,
                    Description = extraOption,
                    GroupEntity = new GroupEntity
                    {
                        ApplicationUserEntity = new ApplicationUser(),
                        EditorId = "",
                        Description = "New Register"
                    }
                };

                // Add a new register
                if (addExtraOptionOnTop)
                {
                    items.Insert(0, item);
                }
                else
                {
                    items.Add(item);
                }

                return new SelectList(items, "Id", "Description");
            }
            else
            {
                return (new SelectList(result, "Id", "Description"));
            }
        }

        public async Task<List<GroupItemEntity>> GroupItemsList(int groupId, OrderType orderType = OrderType.No_order)
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
            return await result.ToListAsync();
        }

        public async Task<GroupItemEntity?> GroupItem(int itemId)
        {
            var result = await context.GroupItemEntity.Where(x => x.Id == itemId).FirstOrDefaultAsync();
            return result;
        }
    }
}
