using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Data.MechanicalWorkshop.Workshop.Repository
{
    public class WorkshopMechanicRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<WorkshopMechanicEntity>(context, httpContextAccessor), IWorkshopMechanicRepository
    {
        public async Task Save(int workshopId) {
            var editorId = GetCurrentUserId();
            var entity = mapper.Map<WorkshopMechanicEntity>(new WorkshopMechanicViewModel());
            entity.EditorId = editorId;
            entity.WorkshopId = workshopId;
            entity.Name = "";
            entity.Active = true;

            await AddAsync(entity);
        }

        public async Task UpdateState(int id, bool active)
        {
            WorkshopMechanicEntity? entity = await GetAsync(id);

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
