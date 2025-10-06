using AutoMapper;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Uniforms.Entities;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Domain.Uniforms.Repository;
using PortalEquador.Domain.Uniforms.ViewModels;
using System.Configuration;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortalEquador.Data.Uniforms.Repository
{
    public class WorkerUniformRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
    IWebHostEnvironment hostEnvironment
    )
        : GenericRepository<WorkerUniformEntity>(context, httpContextAccessor), IWorkerUniformRepository
    {
        public async Task<List<WorkerUniformViewModel>> GetAll(int personalInformationId)
        {
 
            var result = await (from uniform in context.WorkerUniformEntity.Include(u => u.UniformItemEntity).Include(u => u.PersonalInformationEntity)
                                where uniform.PersonalInformationId == personalInformationId
                                orderby uniform.Date descending 
                                
                                join sizeItem in context.GroupItemEntity 
                                on new { Size = uniform.Size, GroupId = Groups.CLOTHES_SIZES } 
                                    equals new { Size = sizeItem.Id.ToString(), GroupId = sizeItem.GroupEntityId } 
                                    into sizeItemGroup 
                                from sizeItem in sizeItemGroup.DefaultIfEmpty()
                                select new WorkerUniformViewModel
                                {
                                    Id = uniform.Id,
                                    PersonaInformationId = uniform.PersonalInformationEntity.Id,
                                    Date = uniform.Date,
                                    Quantity = uniform.Quantity,
                                    Size = sizeItem.Description ?? uniform.Size,
                                    Uniform = new UniformViewModel
                                    {
                                        Description = uniform.UniformItemEntity.Description,
                                    },
                                } 
                                ).ToListAsync();

            return result;
        }

        public async Task<WorkerUniformCreateViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var labelSizes = GroupItems(Groups.CLOTHES_SIZES, OrderType.Alphabetic);

            var model = new WorkerUniformCreateViewModel
            {
                LabelSizes = labelSizes,
                PersonaInformationId = personalInformationId,
                FullName = fullName,
            };

            return model;
        }

        public async Task<WorkerUniformCreateViewModel> GetCreateModel(WorkerUniformCreateViewModel model)
        {
            var labelSizes = GroupItems(Groups.CLOTHES_SIZES, OrderType.Alphabetic);
            model.LabelSizes = labelSizes;
            return model;
        }

        public async Task<WorkerUniformEditViewModel> GetEdit(int id)
        {
            var labelSizes = GroupItems(Groups.CLOTHES_SIZES, OrderType.Alphabetic);

            var result = await context.WorkerUniformEntity
                            .Include(d => d.UniformItemEntity)
                            .Include(d => d.PersonalInformationEntity)
                            .Where(item => item.Id == id)
                             .FirstOrDefaultAsync();

            var models = mapper.Map<WorkerUniformEditViewModel>(result);

            try
            {
                models.LabelSizeId = int.Parse(result.Size);
            }
            catch (FormatException)
            {
            }

            models.LabelSizes = labelSizes;
            return models;
        }

        public async Task<WorkerUniformEditViewModel> RecoverForEdit(WorkerUniformEditViewModel model)
        {
            var labelSizes = GroupItems(Groups.CLOTHES_SIZES, OrderType.Alphabetic);

            var result = await context.WorkerUniformEntity
                            .Include(d => d.UniformItemEntity)
                            .Include(d => d.PersonalInformationEntity)
                            .Where(item => item.Id == model.Id)
                             .FirstOrDefaultAsync();

            var models = mapper.Map<WorkerUniformEditViewModel>(result);

            model.LabelSizeId = model.LabelSizeId;
            model.LabelSizes = labelSizes;
            model.Uniform = models.Uniform;
            return model;
        }

        public async Task<int> Save(WorkerUniformEditViewModel model)
        {
            var entity = mapper.Map<WorkerUniformEntity>(model);

            // set Modified flag in your entry
            var local = context.Set<UniformEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(model.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(entity).State = EntityState.Modified;


            return await Save(entity, model.Id);
        }

            public async Task<int> Save(WorkerUniformCreateViewModel model)
        {
            var entity = mapper.Map<WorkerUniformEntity>(model);
            return await Save(entity, model.Id);
        }

        private async Task<int> Save(WorkerUniformEntity entity, int id)
        {
            entity.EditorId = GetCurrentUserId();

            if (id == 0)
            {
                var result = await AddAsync(entity);
                return result.Id;
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
                return entity.Id;
            }
        }

    }
}
