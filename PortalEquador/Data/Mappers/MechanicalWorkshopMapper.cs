using AutoMapper;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Scheduler.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using System;

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

            CreateMap<MechanicalWorkshopSchedulerEntity, SchedulerViewModel>()
                .ForMember(dest => dest.InterventionTime, opt => opt.MapFrom(src => src.InterventionTimeGroupItemEntity))
                .ForMember(dest => dest.Mechanic, opt => opt.MapFrom(src => src.MechanicGroupItemEntity))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity.Description))
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();
        }
    }
}