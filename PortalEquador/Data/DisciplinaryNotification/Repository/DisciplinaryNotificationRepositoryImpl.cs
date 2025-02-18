using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.EnumTypes;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Data.DisciplinaryNotification.Repository
{
    public class DisciplinaryNotificationRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
    IWebHostEnvironment hostEnvironment
    )
        : GenericRepository<DisciplinaryNotificationEntity>(context, httpContextAccessor), IDisciplinaryNotificationRepository
    {
        public async Task<List<DisciplinaryNotificationViewModel>> GetAll(int personalInformationId)
        {
            var result = await context.DisciplinaryNotificationEntity
                          .Include(d => d.AccidentLevelGroupItemEntity)
                          .Include(d => d.NotificationGroupItemEntity)
                            .Include(d => d.PersonalInformationEntity)
                          .Where(item => item.PersonalInformationId == personalInformationId)
                          .OrderByDescending(item => item.Date)
                          .ToListAsync();

            var models = mapper.Map<List<DisciplinaryNotificationViewModel>>(result);
            models.ForEach(item => item.PicturePath = ImagesUtil.GetImagePath(hostEnvironment, FolderType.DisciplinaryNotification, item.PersonaInformationId, item.Id));
            return models;
        }

        public async Task<DisciplinaryNotificationCreateViewModel> GetCreateModel(int personalInformationId, string fullName)
        {
            var levels = GroupItems(Groups.ACCIDENT_LEVEL, OrderType.Alphabetic);
            var notifications = GroupItems(Groups.NOTIFICATIONS, OrderType.Alphabetic);

            var model = new DisciplinaryNotificationCreateViewModel
            {
                PersonaInformationId = personalInformationId,
                FullName = fullName,
                AccidentLevels = levels,
                Notifications = notifications
            };

            return model;
        }

        public async Task<DisciplinaryNotificationCreateViewModel> GetCreateModel(DisciplinaryNotificationCreateViewModel model)
        {
            var levels = GroupItems(Groups.ACCIDENT_LEVEL, OrderType.Alphabetic);
            var notifications = GroupItems(Groups.NOTIFICATIONS, OrderType.Alphabetic);

            model.AccidentLevels = levels;
            model.Notifications = levels;

            return model;
        }

        public async Task<DisciplinaryNotificationViewModel> GetDetail(int id)
        {
            var result = await context.DisciplinaryNotificationEntity
                .Include(d => d.AccidentLevelGroupItemEntity)
                .Include(d => d.NotificationGroupItemEntity)
                .Include(d => d.PersonalInformationEntity)
                .Include(d => d.ApplicationUserEntity)
               .Where(item => item.Id == id)
               .FirstAsync();

            var model = mapper.Map<DisciplinaryNotificationViewModel>(result);
            model.PicturePath = ImagesUtil.GetImagePath(hostEnvironment, FolderType.DisciplinaryNotification, model.PersonaInformationId, model.Id);
            return model;
        }

        public async Task<DisciplinaryNotificationCreateViewModel> GetDisciplinaryNotification(int id)
        {
            var levels = GroupItems(Groups.ACCIDENT_LEVEL, OrderType.Alphabetic);
            var notifications = GroupItems(Groups.NOTIFICATIONS, OrderType.Alphabetic);

            var model = new DisciplinaryNotificationCreateViewModel
            {
                Id = 1,
                Date = DateTime.Now,
                PersonaInformationId = 1,
                FullName = "The guy",
                AccidentLevelId = 1,
                AccidentLevels = levels,
                NotificationId = 1,
                Notifications = notifications
            };

            return model;
        }

        public async Task<int> Save(DisciplinaryNotificationCreateViewModel model)
        {
            var entity = mapper.Map<DisciplinaryNotificationEntity>(model);
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
