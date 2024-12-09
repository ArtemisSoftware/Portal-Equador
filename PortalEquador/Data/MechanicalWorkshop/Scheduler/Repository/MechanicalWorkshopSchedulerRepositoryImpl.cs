using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PortalEquador.Data.MechanicalWorkshop.Scheduler.Repository
{
    public class MechanicalWorkshopSchedulerRepositoryImpl(
        ApplicationDbContext context, 
        IMapper mapper, 
        IHttpContextAccessor httpContextAccessor, 
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<MechanicalWorkshopSchedulerEntity>(context, httpContextAccessor), IMechanicalWorkshopSchedulerRepository
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

        public async Task<SearchDayPlannerViewModel> SearchGetDayPlan(string? vehicleId)
        {
            var model = new SearchDayPlannerViewModel();

            if(vehicleId != null)
            {
                var results = await context.MechanicalWorkshopSchedulerEntity
                                      .Include(item => item.VehicleEntity)
                                      .Include(item => item.MechanicGroupItemEntity)
                                      .Include(item => item.ContractGroupItemEntity)
                                      .Include(item => item.InterventionTimeGroupItemEntity)
                                     .Where(item => item.VehicleEntity.Id == int.Parse(vehicleId))
                                     .OrderByDescending(item => item.ScheduleDate)
                                     .Take(20)
                                     .ToListAsync();
                if (results.Count != 0)
                {
                    var interventions = mapper.Map<List<SchedulerViewModel>>(results);
                    model.Interventions = interventions;
                }
            }
           
            model.Vehicles = Vehicles();
            return model;
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

        public async Task ConfirmRevision(int id)
        {
            await PerformedRevision(id, SchedulerState.Performed);
        }

        public async Task NotPerformed(int id)
        {
            await PerformedRevision(id, SchedulerState.NotPerformed);
        }


        private async Task PerformedRevision(int id, int state)
        {
            var model = await GetSchedule(id);
            MechanicalWorkshopSchedulerEntity entity = mapper.Map<MechanicalWorkshopSchedulerEntity>(model);

            entity.CurrentState = state;
            entity.EditorId = GetCurrentUserId();
            entity.DateModified = DateTime.UtcNow;

            // set Modified flag in your entry
            var local = context.Set<MechanicalWorkshopSchedulerEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(model.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(entity).State = EntityState.Modified;

            await UpdateAsync(entity);
        }


        public SelectList Vehicles(int interventionTimeId, DateOnly scheduleDate)
        {
            var result = from vehicle in context.MechanicalWorkshopVehicleEntity
                                         where vehicle.Active &&
                                               !context.MechanicalWorkshopSchedulerEntity
                                                  .Any(scheduler => scheduler.VehicleId == vehicle.Id && 
                                                                                        scheduler.InterventionTimeId == interventionTimeId && 
                                                                                        scheduler.ScheduleDate == scheduleDate)
                         orderby vehicle.LicencePlate
                         select vehicle;

            return new SelectList(result, "Id", "LicencePlate");
        }

        private SelectList Vehicles()
        {
            var vehicles = (from vehicle in context.MechanicalWorkshopVehicleEntity
                            where vehicle.Active
                            orderby vehicle.LicencePlate
                            select new
                            {
                                Id = vehicle.Id,
                                LicencePlate = vehicle.LicencePlate
                            }).ToList();

            // Add a placeholder item
            vehicles.Insert(0, new { Id = 0, LicencePlate = "" });

            return new SelectList(vehicles, "Id", "LicencePlate");
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
