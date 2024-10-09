using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;

namespace PortalEquador.Data.MechanicalWorkshop.CarWash.Repository
{
    public class CarWashSchedulerRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<CarWashSchedulerEntity>(context, httpContextAccessor), ICarWashSchedulerRepository
    {
        Task<CarWashViewModel> ICarWashSchedulerRepository.GetCreateModel(string scheduleDate, int mechanicId, int interventionTimeId)
        {
            throw new NotImplementedException();
        }

        Task<CarWashViewModel> ICarWashSchedulerRepository.GetCreateModel(CarWashViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<CarWashDayPlannerViewModel> GetDayPlan(DateOnly date)
        {
            var schedules = await GroupItemsList(GroupTypesConstants.Groups.MECHANICAL_SHOP_SCHEDULES);

            var schedulesList = mapper.Map<List<GroupItemViewModel>>(schedules);

            var results = await context.MechanicalWorkshopSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.ContractGroupItemEntity)
                           .Where(item => item.ScheduleDate == date)
                           .ToListAsync();

            var model = new CarWashDayPlannerViewModel
            {
                Schedules = schedulesList,
                MainTime = TimeUtil.ToDateTime(date),

                //Mechanics = mapper.Map<List<GroupItemViewModel>>(mechanics),
                //InterventionTimes = colabTime(schedulesList),
                //Interventions = new List<SchedulerViewModel>(),
            };

            if (results.Count == 0)
            {
                //model.OrderAppointements();
                return model;
            }
            else
            {
                var interventions = mapper.Map<List<SchedulerViewModel>>(results);
                //model.Interventions = interventions;
                //model.OrderAppointements();
                return model;
            }
        }

        Task<CarWashViewModel> ICarWashSchedulerRepository.GetSchedule(int id)
        {
            throw new NotImplementedException();
        }

        Task ICarWashSchedulerRepository.Save(CarWashViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
