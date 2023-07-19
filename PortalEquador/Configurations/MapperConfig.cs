using AutoMapper;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Models.Documents;
using PortalEquador.Models.GroupTypes;
using PortalEquador.Models.Users;

namespace PortalEquador.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Group, GroupsViewModel>().ReverseMap();
            CreateMap<GroupItem, GroupItemViewModel>().ReverseMap();

            CreateMap<User, UserListViewModel>().ReverseMap();

            CreateMap<PersonalInformation, PersonalInformationViewModel>().ReverseMap();
            CreateMap<PersonalInformation, CurriculumListViewModel>().ReverseMap();
            CreateMap<Document, DocumentCreateViewModel>().ReverseMap();
            CreateMap<Document, DocumentDetailViewModel>().ReverseMap();

            CreateMap<DriversLicenceEntity, DriversLicenceCreateViewModel>().ReverseMap();
            CreateMap<Document, DriversLicenceCreateViewModel>().ReverseMap();
        }
    }
}
