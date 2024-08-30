using AutoMapper;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.MechanicalWorkshop.Vehicle.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;

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
        }
    }
}