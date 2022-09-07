using AutoMapper;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.GroupTypes;

namespace PortalEquador.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Group, GroupsViewModel>().ReverseMap();
        }
    }
}
