using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
        public async Task<List<WorkshopDetailViewModel>> GetDashboard()
        {
            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());
            List <WorkshopEntity> result;

            if (hasFullAccess)
            {
                result = await context.WorkshopEntity
                     .ToListAsync();
            }
            else
            {
                result =  await context.WorkshopEntity
                .Where(a => a.Active == true)
                 .ToListAsync();
            }

            var mapped = mapper.Map<List<WorkshopDetailViewModel>>(result);
            return mapped;
        }

        public async Task<List<WorkshopLaneViewModel>> GetLanes(int workshopId)
        {
            var result = await context.WorkshopLaneEntity
                .Where(a => a.WorkshopId == workshopId)
                 .ToListAsync();

            var mapped = mapper.Map<List<WorkshopLaneViewModel>>(result);
            return mapped;
        }

        public async Task<List<WorkshopMechanicViewModel>> GetMechanics(int workshopId)
        {
            var result = await context.WorkshopMechanicEntity
                .Where(a => a.WorkshopId == workshopId)
                 .ToListAsync();

            var mapped = mapper.Map<List<WorkshopMechanicViewModel>>(result);
            return mapped;
        }


        public async Task<bool> WorkshopExists(string name)
        {
            return await context.WorkshopEntity.AnyAsync(item => item.Name == name);
        }

        public async Task<List<WorkshopDetailViewModel>> GetAllWorkshops()
        {
            var result = await context.WorkshopEntity
                 .Include(a => a.Lanes)
                .Include(a => a.Mechanics)
                .ToListAsync();

            var mapped = mapper.Map<List<WorkshopDetailViewModel>>(result);
            return mapped;
        }

        public async Task<WorkshopDetailViewModel> GetWorkshop(int id)
        {
            var result = await context.WorkshopEntity
                .Include(a => a.Lanes)
                .Include(a => a.Mechanics)
                .FirstOrDefaultAsync(a => a.Id == id);

            var mapped = mapper.Map<WorkshopDetailViewModel>(result);
            return mapped;
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
                        Active = true
                    }
                );
            }

            var mechanics = new List<WorkshopMechanicEntity>();

            for (int i = 0; i < model.NumberOfMechanics; ++i)
            {
                mechanics.Add(
                    new WorkshopMechanicEntity
                    {
                        ApplicationUserEntity = entity.ApplicationUserEntity,
                        Id = 0,
                        EditorId = editorId,
                        Name = (model.NumberOfMechanics + i).ToString(),
                        Active = true
                    }
                );
            }

            entity.Active = true;
            entity.Lanes = lanes;
            entity.Mechanics = mechanics;
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

        public async Task Save(WorkshopDetailViewModel model)
        {
            WorkshopEntity? entity = await GetAsync(model.Id);

            if (entity != null)
            {
                entity.Name = model.Name;
                entity.EditorId = GetCurrentUserId();
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }

        public async Task UpdateState(int id, bool active)
        {
            WorkshopEntity? entity = await GetAsync(id);

            if (entity != null)
            {
                entity.Active = active;
                entity.EditorId = GetCurrentUserId();
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }


    }
}
