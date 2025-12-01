using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Data.MechanicalWorkshop.Workshop.Repository
{
    public class WorkshopRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<WorkshopEntity>(context, httpContextAccessor), IWorkshopRepository
    {
        public async Task<bool> WorkshopExists(string name)
        {
            return await context.WorkshopEntity.AnyAsync(item => item.Name == name);
        }

        public async Task<List<WorkshopDetailViewModel>> GetAllWorkshops()
        {
            var result = await context.WorkshopEntity
                .ToListAsync();

            var mapped = mapper.Map<List<WorkshopDetailViewModel>>(result);
            return mapped;
        }

        public async Task<WorkshopDetailViewModel> GetWorkshop(int id)
        {/*
            var result = await context.WorkshopEntity
                .Include(a => a.Lanes) 
                .FirstOrDefaultAsync(a => a.Id == id);

            var mapped = mapper.Map<WorkshopDetailViewModel>(result);
            return mapped;
            */
            throw new NotImplementedException();
        }

        public async Task Save(WorkshopCreateViewModel model)
        {
            
            var tracked = context.ChangeTracker.Entries<WorkshopEntity>()
          .FirstOrDefault(e => e.Entity.Id == model.Id);

            if (tracked != null)
            {
                context.Entry(tracked.Entity).State = EntityState.Detached;
            }

            var editorId = GetCurrentUserId();
            var entity = mapper.Map<WorkshopEntity>(model);
            entity.EditorId = editorId;

            var lanes = new List<WorkshopLaneEntity>();    

            for (int i = 0; i < model.NumberOfLanes; ++i)
            {
                lanes.Add(
                    new WorkshopLaneEntity
                    {
                        ApplicationUserEntity = entity.ApplicationUserEntity,
                        Id = 0,
                        EditorId = editorId,
                        Name = (model.NumberOfLanes + i).ToString(),
                    }
                );
            }

            entity.Lanes = lanes;
            var id = 0;

            if (model.Id == 0)
            {
                id = (await AddAsync(entity)).Id;
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
                id = entity.Id;
            }
        }
    }
}
