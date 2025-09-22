using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Uniforms.Entities;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.Uniforms.Repository;
using PortalEquador.Domain.Uniforms.ViewModels;

namespace PortalEquador.Data.Uniforms.Repository
{
    public class UniformRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
    IWebHostEnvironment hostEnvironment
    )
        : GenericRepository<UniformEntity>(context, httpContextAccessor), IUniformRepository
    {
        public async Task<List<UniformViewModel>> GetAll()
        {
            throw new NotImplementedException();
            /*
            var result = await context.UniformEntity
                .Include(item => item.ApplicationUserEntity)
                .ToListAsync();

            return mapper.Map<List<UniformViewModel>>(result);
            */
        }

        public Task Save(UniformViewModel model)
        {
            throw new NotImplementedException();
            /*
            var entity = mapper.Map<UniformEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (model.Id == 0)
            {
                await AddAsync(entity);
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
            */
        }

        public Task<bool> UniformExists(string description)
        {
            throw new NotImplementedException();
            //--return await context.UniformEntity.AnyAsync(item => item.Description == description);
        }

        public async Task UpdateState(int id, bool active)
        {
            throw new NotImplementedException();
            /*
            UniformEntity? entity = await GetAsync(id);

            if (entity != null)
            {
                entity.Active = active;
                entity.EditorId = GetCurrentUserId();
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
            */
        }
    }
}
