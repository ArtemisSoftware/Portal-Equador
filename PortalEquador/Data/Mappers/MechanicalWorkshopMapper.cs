using AutoMapper;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Data.MechanicalWorkshop.Workshop.Entities;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Admin.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Workshop.ViewModels;

namespace PortalEquador.Data.Mappers
{
    public class MechanicalWorkshopMapper : Profile
    {
        public MechanicalWorkshopMapper()
        {
            CreateMap<MechanicalWorkshopVehicleEntity, VehicleViewModel>()
                 .ForMember(dest => dest.LicencePlate, opt => opt.MapFrom(src => src.LicencePlate))
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<MechanicalWorkshopVehicleEntity, VehicleDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                .ReverseMap();

            CreateMap<WorkshopEntity, WorkshopViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.NumberOfLanes, opt => opt.MapFrom(src => src.NumberOfLanes))
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<MechanicalWorkshopSchedulerEntity, SchedulerViewModel>()
                .ForMember(dest => dest.InterventionTime, opt => opt.MapFrom(src => src.InterventionTimeGroupItemEntity))
                .ForMember(dest => dest.MechanicId, opt => opt.MapFrom(src => src.WorkshopMechanicId))
                .ForMember(dest => dest.Mechanic, opt => opt.MapFrom(src => src.WorkshopCentralMechanicEntity))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                .ForMember(dest => dest.ContractDescription, opt => opt.MapFrom(src => src.ContractGroupItemEntity.Description))
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<MechanicalWorkshopSchedulerEntity, SchedulerDetailViewModel>()
                .ForMember(dest => dest.InterventionTime, opt => opt.MapFrom(src => src.InterventionTimeGroupItemEntity))
                .ForMember(dest => dest.MechanicId, opt => opt.MapFrom(src => src.WorkshopMechanicId))
                .ForMember(dest => dest.Mechanic, opt => opt.MapFrom(src => src.WorkshopCentralMechanicEntity))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                .ForMember(dest => dest.ContractDescription, opt => opt.MapFrom(src => src.ContractGroupItemEntity.Description))
                .ForMember(dest => dest.Workshop, opt => opt.MapFrom(src => src.WorkshopCentralEntity))
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<CarWashSchedulerEntity, SchedulerViewModel>()
                .ForMember(dest => dest.InterventionTime, opt => opt.MapFrom(src => src.InterventionTimeGroupItemEntity))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity.Description))
                //--.ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<CarWashSchedulerEntity, CarWashViewModel>()
            .ForMember(dest => dest.InterventionTime, opt => opt.MapFrom(src => src.InterventionTimeGroupItemEntity))
            .ForMember(dest => dest.Lane, opt => opt.MapFrom(src => src.WorkshopLaneEntity))
            .ForMember(dest => dest.Workshop, opt => opt.MapFrom(src => src.WorkshopCentralEntity))
            .ForMember(dest => dest.LaneId, opt => opt.MapFrom(src => src.WorkshopLaneId))
            .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
            .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
            .ForMember(dest => dest.ContractDescription, opt => opt.MapFrom(src => src.ContractGroupItemEntity.Description))
            //--.ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
            .ReverseMap();

            CreateMap<CarWashSchedulerEntity, CarWashSearchDayPlannerViewModel>()
            .ForMember(dest => dest.LicencePlate, opt => opt.MapFrom(src => src.VehicleEntity.LicencePlate))
            .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
            .ReverseMap();

            CreateMap<AdminMechanicalWorkShopContractEntity, AdminMechanicalWorkshopCreateViewModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
            .ReverseMap();

            CreateMap<AdminMechanicalWorkShopContractEntity, GroupItemViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ContractId))
            .ReverseMap();

            CreateMap<AdminMechanicalWorkShopContractEntity, AdminMechanicalWorkshopContractViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.ContractId))
            .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
            .ReverseMap();

            CreateMap<WorkshopEntity, WorkshopDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.Lanes, opt => opt.MapFrom(src => src.Lanes))
               .ForMember(dest => dest.Mechanics, opt => opt.MapFrom(src => src.Mechanics))
                .ReverseMap();

            CreateMap<WorkshopEntity, WorkshopCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
               .ReverseMap();

            CreateMap<WorkshopLaneEntity, WorkshopLaneViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
               .ReverseMap();

            CreateMap<WorkshopMechanicEntity, WorkshopMechanicViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
               .ReverseMap();
        }
    }
}