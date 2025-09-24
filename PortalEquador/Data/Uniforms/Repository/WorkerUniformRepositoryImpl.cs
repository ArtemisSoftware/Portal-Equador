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
        public Task<List<WorkerUniformViewModel>> GetAll(int personalInformationId)
        {
            throw new NotImplementedException();
            /*
            var result = await context.WorkerUniformEntity
                .Include(d => d.UniformItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .OrderByDescending(item => item.Date)
                .ToListAsync();

            var models = mapper.Map<List<WorkerUniformViewModel>>(result);
            return models;
            */
        }

        public Task<WorkerUniformCreateViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            throw new NotImplementedException();
            /*
            var uniforms = GetUniforms(OrderType.Alphabetic);

            var model = new WorkerUniformCreateViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Uniforms = uniforms,
            };

            return model;
            */
        }

        public Task<WorkerUniformCreateViewModel> GetCreateModel(TrainningCreateViewModel model)
        {
            throw new NotImplementedException();
            /*
            var uniforms = GetUniforms(OrderType.Alphabetic);

            model.Uniforms = uniforms;
            return model;
            */
        }

        public Task<int> Save(WorkerUniformCreateViewModel model)
        {
            throw new NotImplementedException();
            /*
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
            */
        }

    }
}
