using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;

namespace PortalEquador.Util
{
    public static class DbUtil
    {
        public static void DetachAndModify<TEntity>(this DbContext context, TEntity entity, TEntity model) where TEntity : class
        {
            // Check for local entries
            var local = context.Set<TEntity>().Local.FirstOrDefault(entry => entry.Equals(model));

            // Check if local is not null
            if (local != null)
            {
                // Detach
                context.Entry(local).State = EntityState.Detached;
            }

            // Set the state of the entity to modified
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
