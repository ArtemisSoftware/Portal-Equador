using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.EnumTypes;
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
            var result = await context.TrainningEntity
                          .Include(d => d.PersonalInformationEntity)
                          .Include(d => d.TrainningGroupItemEntity)
                          .Where(item => item.PersonalInformationId == personalInformationId)
                          .OrderByDescending(item => item.Date)
                          .ToListAsync();

            var models = mapper.Map<List<TrainningViewModel>>(result);
            models.ForEach(item => item.PicturePath = ImagesUtil.GetImagePath(hostEnvironment, FolderType.Trainning, item.PersonaInformationId, item.Id));
            return models;
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
            var result = await context.TrainningEntity
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.TrainningGroupItemEntity)
                .Include(d => d.ApplicationUserEntity)
               .Where(item => item.Id == id)
               .FirstAsync();

            var model = mapper.Map<TrainningViewModel>(result);
            model.PicturePath = ImagesUtil.GetImagePath(hostEnvironment, FolderType.Trainning, model.PersonaInformationId, model.Id);
            return model;
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
