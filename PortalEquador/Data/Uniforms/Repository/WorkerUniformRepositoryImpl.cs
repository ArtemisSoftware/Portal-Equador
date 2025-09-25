using AutoMapper;
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
using static PortalEquador.Util.Constants.GroupTypesConstants;

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
            var result = await context.WorkerUniformEntity
                .Include(d => d.UniformItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .OrderByDescending(item => item.Date)
                .ToListAsync();

            var models = mapper.Map<List<WorkerUniformViewModel>>(result);
            return models;
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

        public async Task<int> Save(WorkerUniformCreateViewModel model)
        {
            var entity = mapper.Map<WorkerUniformEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (model.Id == 0)
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
