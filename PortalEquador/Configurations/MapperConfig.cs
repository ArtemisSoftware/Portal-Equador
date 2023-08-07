using AutoMapper;
using PortalEquador.Data;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Models.CurriculumVitae;
using PortalEquador.Models.Documents;
using PortalEquador.Models.Users;

namespace PortalEquador.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {


            CreateMap<User, UserListViewModel>().ReverseMap();

            //---
            CreateMap<PersonalInformationEntity, PersonalInformationViewModel>().ReverseMap();
            CreateMap<PersonalInformationEntity, CurriculumListViewModel>().ReverseMap();
            CreateMap<DocumentEntity, DocumentCreateViewModel>().ReverseMap();
            CreateMap<DocumentEntity, DocumentDetailViewModel>().ReverseMap();
            //---

            //Group
            CreateMap<GroupEntity, GroupViewModel>().ReverseMap();
            CreateMap<GroupItemEntity, GroupItemViewModel>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupEntityId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.GroupEntity))
                .ReverseMap();

            //GroupItem

            //Curriculum

            //Personal information

            //Document

            //Drivers Licence


            CreateMap<DriversLicenceEntity, DriversLicenceCreateViewModel>().ReverseMap();
            CreateMap<DriversLicenceEntity, DriversLicenceViewModel__>().ReverseMap();

            CreateMap<DocumentEntity, DriversLicenceCreateViewModel>().ReverseMap();
        }
    }
}
