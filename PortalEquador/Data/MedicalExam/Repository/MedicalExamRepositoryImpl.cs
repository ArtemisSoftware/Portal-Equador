using AutoMapper;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;
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
            var list = new List<MedicalExamViewModel>();
            list.Add(
                new MedicalExamViewModel {
                    Id = 1,
                    Date =  DateTime.Now,
                    PersonaInformationId = 1,
                    FullName = "The guy",
                    Exam = new GroupItemViewModel
                    {
                        Id = 1,
                        Description = "EXAM1"
                    }
                }
                );
            return list; 
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
            return new MedicalExamViewModel
            {
                Id = 1,
                Date = DateTime.Now,
                PersonaInformationId = 1,
                FullName = "The guy",
                Exam = new GroupItemViewModel
                {
                    Id = 1,
                    Description = "EXAM1"
                }
            };
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
