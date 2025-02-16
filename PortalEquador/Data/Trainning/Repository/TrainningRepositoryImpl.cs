using AutoMapper;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MedicalExam.Repository;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.ViewModels;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.Trainning.Repository
{
    public class TrainningRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
    IWebHostEnvironment hostEnvironment
    )
        : GenericRepository<TrainningEntity>(context, httpContextAccessor), ITrainningRepository
    {
        public async Task<List<TrainningViewModel>> GetAll(int personalInformationId)
        {
            var list = new List<TrainningViewModel>();
            list.Add(
                new TrainningViewModel
                {
                    Id = 1,
                    Date = DateTime.Now,
                    PersonaInformationId = 1,
                    FullName = "The guy",
                    Trainning = new GroupItemViewModel
                    {
                        Id = 1,
                        Description = "Trainning"
                    }
                }
                );
            return list;
        }

        public async Task<TrainningCreateViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var trainning = GroupItems(Groups.TRAINNING, OrderType.Alphabetic);

            var model = new TrainningCreateViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                Trainnings = trainning
            };

            return model;
        }

        public async Task<TrainningCreateViewModel> GetCreateModel(TrainningCreateViewModel model)
        {
            var trainning = GroupItems(Groups.TRAINNING, OrderType.Alphabetic);
            model.Trainnings = trainning;
            return model;
        }

        public async Task<TrainningViewModel> GetDetail(int id)
        {
            return new TrainningViewModel
            {
                Id = 1,
                Date = DateTime.Now,
                PersonaInformationId = 1,
                FullName = "The guy",
                Trainning = new GroupItemViewModel
                {
                    Id = 1,
                    Description = "Trainning"
                }
            };
        }

        public async Task<TrainningCreateViewModel> GetTrainning(int id)
        {
            var trainning = GroupItems(Groups.TRAINNING, OrderType.Alphabetic);

            var model = new TrainningCreateViewModel
            {
                Id = 1,
                Date = DateTime.Now,
                PersonaInformationId = 1,
                FullName = "The guy",
                TrainningId = 1,
                Trainnings = trainning
            };

            return model;
        }

        public async Task<int> Save(TrainningCreateViewModel model)
        {
            var entity = mapper.Map<TrainningEntity>(model);
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
