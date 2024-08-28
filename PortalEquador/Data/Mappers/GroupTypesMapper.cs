using AutoMapper;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Data.Mappers
{
    public class GroupTypesMapper : Profile
    {
        public GroupTypesMapper()
        {
            CreateMap<GroupEntity, GroupViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<GroupItemEntity, GroupItemViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupEntityId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.GroupEntity))
                .ReverseMap();
        }
    }
}
