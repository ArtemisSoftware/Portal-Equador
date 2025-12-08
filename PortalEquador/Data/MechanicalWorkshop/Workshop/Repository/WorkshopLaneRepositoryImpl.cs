using AutoMapper;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Data.MechanicalWorkshop.Workshop.Repository
{
    public class WorkshopLaneRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<WorkshopLaneEntity>(context, httpContextAccessor), IWorkshopLaneRepository
    {
        public async Task Save(int workshopId) {
            var editorId = GetCurrentUserId();
            var entity = mapper.Map<WorkshopLaneEntity>(new WorkshopLaneViewModel());
            entity.EditorId = editorId;
            entity.WorkshopId = workshopId;
            entity.Name = "";
            entity.Active = true;

            await AddAsync(entity);
        }
    }
}
