using AutoMapper;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Models.GroupTypes;

namespace PortalEquador.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Group, GroupsViewModel>().ReverseMap();
            CreateMap<GroupItem, GroupItemViewModel>().ReverseMap();

            CreateMap<PersonalInformation, PersonalInformationViewModel>().ReverseMap();
            CreateMap<Curriculum, CurriculumViewModel>().ReverseMap();
        }
    }
}
