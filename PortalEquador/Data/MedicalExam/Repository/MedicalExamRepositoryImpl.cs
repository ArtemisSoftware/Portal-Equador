using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Util;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.MedicalExam.Repository
{
    public class MedicalExamRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
    IWebHostEnvironment hostEnvironment
    )
        : GenericRepository<MedicalExamEntity>(context, httpContextAccessor), IMedicalExamRepository
    {
        public async Task<List<MedicalExamViewModel>> GetAll(int personalInformationId)
        {

            var result = await context.MedicalExamEntity
                .Include(d => d.ExamGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Where(item => item.PersonalInformationId == personalInformationId)
                .OrderByDescending(item => item.Date)
                .ToListAsync();

            var models = mapper.Map<List<MedicalExamViewModel>>(result);
            models.ForEach(item => item.PicturePath = ImagesUtil.GetMedicalExamImagePath(hostEnvironment, item.PersonaInformationId, item.Id));
            return models ;
        }

        public async Task<MedicalExamCreateViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var exams = GroupItems(Groups.EXAM, OrderType.Alphabetic);

            var model = new MedicalExamCreateViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Exams = exams
            };

            return model;
        }

        public async Task<MedicalExamCreateViewModel> GetCreateModel(MedicalExamCreateViewModel model)
        {
            var exams = GroupItems(Groups.EXAM, OrderType.Alphabetic);
            model.Exams = exams;
            return model;
        }

        public async Task<MedicalExamViewModel> GetDetail(int id)
        {
            var result = await context.MedicalExamEntity
               .Include(d => d.ExamGroupItemEntity)
               .Include(d => d.PersonalInformationEntity)
                .Include(d => d.ApplicationUserEntity)
               .Where(item => item.Id == id)
               .FirstAsync();

            var model = mapper.Map<MedicalExamViewModel>(result);
            model.PicturePath = ImagesUtil.GetMedicalExamImagePath(hostEnvironment, model.PersonaInformationId, model.Id);
            return model;
        }

        public async Task<MedicalExamCreateViewModel> GetMedicalExam(int id)
        {
            var exams = GroupItems(Groups.EXAM, OrderType.Alphabetic);

            var model = new MedicalExamCreateViewModel
            {
                Id = 1,
                Date = DateTime.Now,
                PersonaInformationId = 1,
                FullName = "The guy",
                ExamId = 1,
                Exams = exams
            };

            return model;
        }

        public async Task<int> Save(MedicalExamCreateViewModel model)
        {
            var entity = mapper.Map<MedicalExamEntity>(model);
            entity.EditorId = GetCurrentUserId();

            if (model.Id == 0)
            {
                var result =  await AddAsync(entity);
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
