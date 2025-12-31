using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.Repository;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;
using PortalEquador.Util;
using PortalEquador.Util.Constants;

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


        public async Task<DayPlannerViewModel> GetDayPlan(DateOnly date, int workshopid, string workshopname)
        {
            var mechanics = await GroupItemsList(GroupTypesConstants.Groups.MECHANICAL_SHOP_MECHANICS);
            var mechanics_ = await GetMechanics(workshopid);

            var schedules = await GroupItemsList(GroupTypesConstants.Groups.MECHANICAL_SHOP_SCHEDULES);
            var schedulesList = mapper.Map<List<GroupItemViewModel>>(schedules);

            var results = await context.MechanicalWorkshopSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.ContractGroupItemEntity)
                            .Include(item => item.WorkshopCentralEntity)
                           .Where(item => item.ScheduleDate == date && item.WorkshopId == workshopid)
                           .ToListAsync();

            var model = new DayPlannerViewModel
            {
                WorkshopId = workshopid,
                WorkshopName = workshopname,
                InterventionTimes = colabTime(schedulesList),
                Schedules = schedulesList,
                Interventions = new List<SchedulerViewModel>(),
                MainTime = TimeUtil.ToDateTime(date),
                hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole()),
            };

            if (results.Count == 0)
            {
                model.Mechanics = mechanics_.Where(m => m.Active) .ToList();
                return model;
            } else
            {
                var interventions = mapper.Map<List<SchedulerViewModel>>(results);
                var mechanicIdsInUse = interventions .Select(s => s.MechanicId).ToHashSet();

                model.Mechanics = mechanics_.Where(m => m.Active || mechanicIdsInUse.Contains(m.Id)) .ToList();
                model.Interventions = interventions;
                return model;
            }
        }

        private async Task<List<WorkshopMechanicViewModel>> GetMechanics(int workshopid)
        {
            var results = await context.WorkshopMechanicEntity
                .Include(item => item.WorkshopEntity)
               .Where(item => item.WorkshopId == workshopid)
               .ToListAsync();

            return mapper.Map<List<WorkshopMechanicViewModel>>(results);
        }

        private async Task<WorkshopMechanicViewModel> GetMechanic(int id)
        {
            var results = await context.WorkshopMechanicEntity
                .Include(item => item.WorkshopEntity)
               .Where(item => item.Id == id)
               .FirstAsync();

            return mapper.Map<WorkshopMechanicViewModel>(results);
        }

        public async Task<SearchDayPlannerViewModel> SearchGetDayPlan(string? vehicleId, int workshopid)
        {
            var model = new SearchDayPlannerViewModel();

            if(vehicleId != null)
            {
                var results = await context.MechanicalWorkshopSchedulerEntity
                                      .Include(item => item.VehicleEntity)
                                      .Include(item => item.WorkshopCentralEntity)
                                      .Include(item => item.WorkshopCentralMechanicEntity)
                                      .Include(item => item.ContractGroupItemEntity)
                                      .Include(item => item.InterventionTimeGroupItemEntity)
                                     .Where(item => item.VehicleEntity.Id == int.Parse(vehicleId) && item.WorkshopId == workshopid)
                                     .OrderByDescending(item => item.ScheduleDate)
                                     .Take(20)
                                     .ToListAsync();
                if (results.Count != 0)
                {
                    var mechanics = await GetMechanics(results[0].WorkshopCentralEntity.Id);

                    var interventions = mapper.Map<List<SchedulerViewModel>>(results);

                    foreach (var intervention in interventions)
                    {
                        var index = mechanics.FindIndex(m => m.Id == intervention.Mechanic.Id);
                        intervention.Mechanic.Name = (index + 1).ToString();
                    }

                    model.Interventions = interventions;
                }
            }

            model.hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());
            model.Vehicles = Vehicles();
            return model;
        }

        public async Task<SchedulerViewModel> GetCreateModel(string scheduleDate, int mechanicId, int interventionTimeId, int workshopid, string workshopname)
        {
            var mechanic = await GetMechanic(mechanicId);
            var selectedMechanic = mapper.Map<WorkshopMechanicViewModel>(mechanic);

            var mechanics = await GetMechanics(workshopid);
            selectedMechanic.Name = (mechanics.FindIndex(e => e.Id == selectedMechanic.Id) + 1).ToString();

            var schedule = await GroupItem(interventionTimeId);
            var selectedSchedule = mapper.Map<GroupItemViewModel>(schedule);
            var dateOnly = TimeUtil.ToDateOnly(scheduleDate);

            var vehicles = Vehicles(interventionTimeId, dateOnly);

            var model = new SchedulerViewModel
            {
                WorkshopId = workshopid,
                WorkshopName = workshopname,
                ScheduleDate = dateOnly,
                MechanicId = mechanicId,
                Mechanic = selectedMechanic,
                InterventionTimeId = interventionTimeId,
                InterventionTime = selectedSchedule,
                Vehicles = vehicles
            };
            return model;
        }

        public async Task<SchedulerViewModel> GetCreateModel(SchedulerViewModel model)
        {
            var mechanic = await GetMechanic(model.MechanicId);
            var selectedMechanic = mapper.Map<WorkshopMechanicViewModel>(mechanic);

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
            entity.MechanicId = 3; //apagar no fim
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

            var userId = GetCurrentUserId();
            var hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());

            if (hasFullAccess)
            {
                var result =
                from vehicle in context.MechanicalWorkshopVehicleEntity
                join scheduler in context.MechanicalWorkshopSchedulerEntity on vehicle.Id equals scheduler.VehicleId into vehicleSchedules
                where vehicle.Active &&
                                !vehicleSchedules
                                .Any(s => s.InterventionTimeId == interventionTimeId &&
                                                    s.ScheduleDate == scheduleDate)
                orderby vehicle.LicencePlate
                select vehicle;

                return new SelectList(result, "Id", "LicencePlate");
            } else
            {
                var result =
                from vehicle in context.MechanicalWorkshopVehicleEntity
                join contract in context.AdminMechanicalWorkShopContractEntity on vehicle.ContractId equals contract.ContractId
                join scheduler in context.MechanicalWorkshopSchedulerEntity on vehicle.Id equals scheduler.VehicleId into vehicleSchedules
                where vehicle.Active &&
                                contract.UserId == userId &&
                                !vehicleSchedules
                                .Any(s => s.InterventionTimeId == interventionTimeId &&
                                                    s.ScheduleDate == scheduleDate)
                orderby vehicle.LicencePlate
                select vehicle;

                return new SelectList(result, "Id", "LicencePlate");
            }
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

        public async Task<SchedulerDetailViewModel> GetSchedule(int id)
        {
            var result = await context.MechanicalWorkshopSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.InterventionTimeGroupItemEntity)
                            .Include(item => item.WorkshopCentralMechanicEntity)
                            .Include(item => item.ContractGroupItemEntity)
                            .Include(item => item.ApplicationUserEntity)
                            .Include(item => item.WorkshopCentralEntity)
                           .Where(item => item.Id == id)
                           .FirstOrDefaultAsync();

            var model = mapper.Map<SchedulerDetailViewModel>(result);

            var mechanics = await GetMechanics(result.WorkshopCentralEntity.Id);
            model.Mechanic.Name = (mechanics.FindIndex(e => e.Id == model.Mechanic.Id) + 1).ToString();
            return model;
        }


    }
}
