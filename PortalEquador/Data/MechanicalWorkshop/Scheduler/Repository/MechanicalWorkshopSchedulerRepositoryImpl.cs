using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using System;
using System.Text.RegularExpressions;
using static PortalEquador.Util.Constants.GroupTypesConstants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortalEquador.Data.MechanicalWorkshop.Scheduler.Repository
{
    public class MechanicalWorkshopSchedulerRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment) : GenericRepository<MechanicalWorkshopSchedulerEntity>(context, httpContextAccessor), IMechanicalWorkshopSchedulerRepository
    {

        private Dictionary<int, GroupItemViewModel> colabTime(List<GroupItemViewModel> schedules)
        {
            Dictionary<int, GroupItemViewModel> colaborationTimes = new Dictionary<int, GroupItemViewModel>();

            var index = 1;

            foreach(var schedule in schedules)
            {
                colaborationTimes.Add(index, schedule);
                ++index;
            }
            return colaborationTimes;
        }


        public async Task<DayPlannerViewModel> GetDayPlan(DateOnly date)
        {
            var mechanics = await GroupItemsList(GroupTypesConstants.Groups.MECHANICAL_SHOP_MECHANICS);
            var schedules = await GroupItemsList(GroupTypesConstants.Groups.MECHANICAL_SHOP_SCHEDULES);

            var schedulesList = mapper.Map<List<GroupItemViewModel>>(schedules);

            var results = await context.MechanicalWorkshopSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.ContractGroupItemEntity)
                           .Where(item => item.ScheduleDate == date)
                           .ToListAsync();

            var model = new DayPlannerViewModel
            {
                Mechanics = mapper.Map<List<GroupItemViewModel>>(mechanics),
                InterventionTimes = colabTime(schedulesList),
                Schedules = schedulesList,
                Interventions = new List<SchedulerViewModel>(),
                MainTime = TimeUtil.ToDateTime(date)
            };

            if (results.Count == 0)
            {
                model.OrderAppointements();
                return model;
            } else
            {
                var interventions = mapper.Map<List<SchedulerViewModel>>(results);
                model.Interventions = interventions;
                model.OrderAppointements();
                return model;
            }
        }


        public async Task<SchedulerViewModel> GetCreateModel(string scheduleDate, int mechanicId, int interventionTimeId)
        {
            var mechanic = await GroupItem(mechanicId);
            var selectedMechanic = mapper.Map<GroupItemViewModel>(mechanic);

            var schedule = await GroupItem(interventionTimeId);
            var selectedSchedule = mapper.Map<GroupItemViewModel>(schedule);
            var dateOnly = TimeUtil.ToDateOnly(scheduleDate);

            var model = new SchedulerViewModel
            {
                ScheduleDate = dateOnly,
                MechanicId = mechanicId,
                Mechanic = selectedMechanic,
                InterventionTimeId = interventionTimeId,
                InterventionTime = selectedSchedule,
                Vehicles = Vehicles(interventionTimeId, dateOnly)
            };
            return model;
        }

        public async Task<SchedulerViewModel> GetCreateModel(SchedulerViewModel model)
        {
            var mechanic = await GroupItem(model.MechanicId);
            var selectedMechanic = mapper.Map<GroupItemViewModel>(mechanic);

            var schedule = await GroupItem(model.InterventionTimeId);
            var selectedSchedule = mapper.Map<GroupItemViewModel>(schedule);

            model.Mechanic = selectedMechanic;
            model.InterventionTime = selectedSchedule;
            model.Vehicles = Vehicles(model.InterventionTimeId, model.ScheduleDate);

            return model;
        }

        public async Task Save(SchedulerViewModel model)
        {
            var vehicle = await context.MechanicalWorkshopVehicleEntity.Where(x => x.Id == model.VehicleId).FirstAsync();
            MechanicalWorkshopSchedulerEntity entity = mapper.Map<MechanicalWorkshopSchedulerEntity>(model);
            entity.EditorId = GetCurrentUserId();
            entity.ContractId = vehicle.ContractId;
            entity.ContractGroupItemEntity = null;
            if (model.Id == 0)
            {
                await AddAsync(entity);
            }
            else
            {
                entity.DateModified = DateTime.UtcNow;
                await UpdateAsync(entity);
            }
        }

        public SelectList Vehicles(int interventionTimeId, DateOnly scheduleDate)
        {
            var result = from vehicle in context.MechanicalWorkshopVehicleEntity
                                         where vehicle.Active &&
                                               !context.MechanicalWorkshopSchedulerEntity
                                                  .Any(scheduler => scheduler.VehicleId == vehicle.Id && scheduler.InterventionTimeId == interventionTimeId && scheduler.ScheduleDate == scheduleDate)
                                         select vehicle;

            return new SelectList(result, "Id", "LicencePlate");
        }

        public async Task<SchedulerViewModel> GetSchedule(int id)
        {
            var result = await context.MechanicalWorkshopSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.InterventionTimeGroupItemEntity)
                            .Include(item => item.MechanicGroupItemEntity)
                            .Include(item => item.ContractGroupItemEntity)
                            .Include(item => item.ApplicationUserEntity)
                           .Where(item => item.Id == id)
                           .FirstOrDefaultAsync();

            return mapper.Map<SchedulerViewModel>(result);
        }
    }
}
