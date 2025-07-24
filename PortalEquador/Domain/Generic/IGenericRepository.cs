using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;

namespace PortalEquador.Domain.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> Exists(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        SelectList GroupItems(int groupId, OrderType orderType, int idToExclude, string extraOption, bool addExtraOptionOnTop);
        SelectList GroupItems(IQueryable<GroupItemEntity> result, OrderType orderType, string extraOption, bool addExtraOptionOnTop);
    }
}
