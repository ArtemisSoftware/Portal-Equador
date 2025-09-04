using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Domain.Accident.Repository;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Admin.Repository;

namespace PortalEquador.Data.Accident.Repository
{
    public class AccidentCauseRepositoryImpl(
         ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager
        ) : GenericRepository<AccidentCauseEntity>(context, httpContextAccessor), IAccidentCauseRepository
    {
        public async Task Save(int accidentId, List<GroupItemViewModel> causes)
        {
            var entities = mapper.Map<List<AccidentCauseEntity>>(causes);
            var editorId = GetCurrentUserId();
            await DeleteCauses(accidentId);

            foreach (var entity in entities)
            {
                entity.Id = 0;
                entity.EditorId = editorId;
                entity.AccidentId = accidentId;
                var dd = await AddAsync(entity);
                var ddd = dd + " w";
            }
        }

        private async Task DeleteCauses(int accidentId)
        {
            await context.AccidentCauseEntity
                .Where(item => item.AccidentId == accidentId)
                .ExecuteDeleteAsync();
        }
    }
}
