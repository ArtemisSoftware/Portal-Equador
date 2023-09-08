using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using PortalEquador.Contracts;
using PortalEquador.Data;

namespace PortalEquador.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
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
            context.Set<T>().Remove(entity);
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

        public SelectList GroupItems(int groupId)
        {
            var result =  context.GroupItemEntity.Where(x => x.GroupEntityId == groupId & x.Active == true);
            return  new SelectList(result, "Id", "Description");
        }
    }
}