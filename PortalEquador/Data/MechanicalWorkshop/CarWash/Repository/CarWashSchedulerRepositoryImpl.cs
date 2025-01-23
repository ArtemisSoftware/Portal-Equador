using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.Repository;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Util.Constants;
using PortalEquador.Util;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalEquador.Domain.MechanicalWorkshop;

namespace PortalEquador.Data.MechanicalWorkshop.CarWash.Repository
{
    public class CarWashSchedulerRepositoryImpl(
        ApplicationDbContext context,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment hostEnvironment
        ) : GenericRepository<CarWashSchedulerEntity>(context, httpContextAccessor), ICarWashSchedulerRepository
    {
        public async Task<CarWashViewModel> GetCreateModel(string scheduleDate, int laneId,  int interventionTimeId)
        {
            var lane = await GroupItem(laneId);
            var selectedLane = mapper.Map<GroupItemViewModel>(lane);
            var schedule = await GroupItem(interventionTimeId);
            var selectedSchedule = mapper.Map<GroupItemViewModel>(schedule);
            var dateOnly = TimeUtil.ToDateOnly(scheduleDate);

            var model = new CarWashViewModel
            {
                ScheduleDate = dateOnly,
                InterventionTimeId = interventionTimeId,
                InterventionTime = selectedSchedule,
                LaneId = laneId,
                Lane = selectedLane,
                Vehicles = Vehicles(interventionTimeId, dateOnly)
            };
            return model;
        }

        public async Task<CarWashViewModel> GetCreateModel(CarWashViewModel model)
        {
            var lane = await GroupItem(model.LaneId);
            var selectedLane = mapper.Map<GroupItemViewModel>(lane);
            var schedule = await GroupItem(model.InterventionTimeId);
            var selectedSchedule = mapper.Map<GroupItemViewModel>(schedule);

            model.Lane = selectedLane;
            model.InterventionTime = selectedSchedule;
            model.Vehicles = Vehicles(model.InterventionTimeId, model.ScheduleDate);
            return model;
        }

        public async Task<CarWashDayPlannerViewModel> GetDayPlan(DateOnly date)
        {
            var lanes = await GroupItemsList(GroupTypesConstants.Groups.WASH_LANE);
            var schedules = await GroupItemsList(GroupTypesConstants.Groups.CAR_WASH_SCHEDULES);
            var schedulesList = mapper.Map<List<GroupItemViewModel>>(schedules);
            
            var results = await context.CarWashSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.LaneGroupItemEntity)
                            .Include(item => item.ContractGroupItemEntity)
                           .Where(item => item.ScheduleDate == date)
                           .ToListAsync();
            
            var model = new CarWashDayPlannerViewModel
            {
                Lanes = mapper.Map<List<GroupItemViewModel>>(lanes),
                Schedules = schedulesList,
                MainTime = TimeUtil.ToDateTime(date),
                Interventions = new List<CarWashViewModel>(),
                InterventionTimes = colabTime(schedulesList),
                hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole()),
            };
            
            if (results.Count == 0)
            {
                return model;
           }
            else
            {
                var interventions = mapper.Map<List<CarWashViewModel>>(results);
                model.Interventions = interventions;
                return model;
            }
           
        }

        private Dictionary<int, GroupItemViewModel> colabTime(List<GroupItemViewModel> schedules)
        {
            Dictionary<int, GroupItemViewModel> colaborationTimes = new Dictionary<int, GroupItemViewModel>();

            var index = 1;

            foreach (var schedule in schedules)
            {
                colaborationTimes.Add(index, schedule);
                ++index;
            }
            return colaborationTimes;
        }

        public async Task<CarWashViewModel> GetSchedule(int id)
        {
            
            var result = await context.CarWashSchedulerEntity
                            .Include(item => item.VehicleEntity)
                            .Include(item => item.InterventionTimeGroupItemEntity)
                            .Include(item => item.ContractGroupItemEntity)
                            .Include(item => item.LaneGroupItemEntity)
                            .Include(item => item.ApplicationUserEntity)
                           .Where(item => item.Id == id)
                           .FirstOrDefaultAsync();

            var model =  mapper.Map<CarWashViewModel>(result);
            return model;
        }

        public async Task Save(CarWashViewModel model)
        {
            var vehicle = await context.MechanicalWorkshopVehicleEntity.Where(x => x.Id == model.VehicleId).FirstAsync();
            CarWashSchedulerEntity entity = mapper.Map<CarWashSchedulerEntity>(model);

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

        public async Task ConfirmWash(int id)
        {
            await PerformedWash(id, CarWashState.Performed);
        }

        public async Task NotPerformed(int id)
        {
            await PerformedWash(id, CarWashState.NotPerformed);
        }


        private async Task PerformedWash(int id, int state)
        {
            var model = await GetSchedule(id);
            CarWashSchedulerEntity entity = mapper.Map<CarWashSchedulerEntity>(model);

            entity.CurrentState = state;
            entity.EditorId = GetCurrentUserId();
            entity.DateModified = DateTime.UtcNow;

            // set Modified flag in your entry
            var local = context.Set<CarWashSchedulerEntity>().Local.FirstOrDefault(entry => entry.Id.Equals(model.Id));

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
            }
            else
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

        public async Task<CarWashSearchDayPlannerViewModel> SearchGetDayPlan(string? vehicleId)
        {
            var model = new CarWashSearchDayPlannerViewModel();
            
            if (vehicleId != null)
            {
                var results = await context.CarWashSchedulerEntity
                    .Include(item => item.VehicleEntity)
                    .Include(item => item.ContractGroupItemEntity)
                    .Include(item => item.LaneGroupItemEntity)
                    .Include(item => item.InterventionTimeGroupItemEntity)
                   .Where(item => item.VehicleEntity.Id == int.Parse(vehicleId))
                   .OrderByDescending(item => item.ScheduleDate)
                   .Take(20)
                   .ToListAsync();

                if (results.Count != 0)
                {
                    var interventions = mapper.Map<List<CarWashViewModel>>(results);
                    model.Interventions = interventions;
                }
                model.VehicleId = int.Parse(vehicleId);
            }

            model.hasFullAccess = MechanicalWorkshopUtil.HasFullAccess(GetCurrentUserRole());
            model.Vehicles = Vehicles();
           
            return model;
        }


    }
}
