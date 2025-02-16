using AutoMapper;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.Generic;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;
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
            var list = new List<DisciplinaryNotificationViewModel>();
            list.Add(
                new DisciplinaryNotificationViewModel
                {
                    Id = 1,
                    Date = DateTime.Now,
                    PersonaInformationId = 1,
                    FullName = "The guy",
                    Local = "The local",
                    AccidentLevel = new GroupItemViewModel
                    {
                        Id = 1,
                        Description = "AccidentLevel 1"
                    },
                    Notification = new GroupItemViewModel
                    {
                        Id = 1,
                        Description = "Notification -- 1"
                    }
                }
                );
            return list;
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
            return new DisciplinaryNotificationViewModel
            {
                Id = 1,
                Date = DateTime.Now,
                PersonaInformationId = 1,
                FullName = "The guy",
                Local = "The local",
                AccidentLevel = new GroupItemViewModel
                {
                    Id = 1,
                    Description = "AccidentLevel 1"
                },
                Notification = new GroupItemViewModel
                {
                    Id = 1,
                    Description = "Notification -- 1"
                }
            };
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
