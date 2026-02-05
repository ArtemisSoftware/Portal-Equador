using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var result = await context.UniformEntity
                .Include(item => item.ApplicationUserEntity)
                .OrderBy(item => item.Description)
                .ToListAsync();

            return mapper.Map<List<UniformViewModel>>(result);
        }

        public async Task Save(UniformViewModel model)
        {
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
            
        }

        public async Task<bool> UniformExists(string description)
        {
            return await context.UniformEntity.AnyAsync(item => item.Description == description);
        }

        public async Task<UniformViewModel?> GetUniform(int id)
        {
            var result = await context.UniformEntity
                .Include(item => item.ApplicationUserEntity)
                .Where(item => item.Id == id)
                .FirstOrDefaultAsync();

            return mapper.Map<UniformViewModel>(result);
        }


        public async Task UpdateState(int id, bool active)
        {
            UniformEntity? entity = await GetAsync(id);

            if (entity != null)
            {
                entity.Active = active;
                entity.EditorId = GetCurrentUserId();
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }

        public SelectList GetUniforms(
            OrderType orderType = OrderType.No_order, 
            string extraOption = "",
            bool addExtraOptionOnTop = false
            )
        {
            IQueryable<UniformEntity> result = context.UniformEntity.Where(x =>
                 x.Active == true
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

            if (extraOption != "")
            {
                var items = result.ToList();

                var item = new UniformEntity
                {
                    ApplicationUserEntity = new ApplicationUser(),
                    EditorId = "",
                    Id = -1,
                    Description = extraOption,
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
            return (new SelectList(result, "Id", "Description"));
        }

        public async Task<List<UniformViewModel>> GetAllUniforms(OrderType orderType = OrderType.No_order)
        {

            var result = context.UniformEntity.Where(x => x.Active == true);
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

            var model = await result.ToListAsync();
            return mapper.Map<List<UniformViewModel>>(model);
        }
    }
}
