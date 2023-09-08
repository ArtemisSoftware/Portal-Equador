using AutoMapper;
using PortalEquador.Data;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Models.Users;

namespace PortalEquador.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {


            CreateMap<User, UserListViewModel>().ReverseMap();



            //Group
            CreateMap<GroupEntity, GroupViewModel>().ReverseMap();

            //GroupItem
            CreateMap<GroupItemEntity, GroupItemViewModel>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupEntityId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.GroupEntity))
                .ReverseMap();

            /*
            CreateMap<GroupItemEntity, DocumentDetailViewModel>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupEntityId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.GroupEntity))
                .ReverseMap();
            */
            //Curriculum

            //Personal information
            CreateMap<PersonalInformationEntity, PersonalInformationViewModel>().ReverseMap();
            CreateMap<PersonalInformationEntity, PersonalInformationDetailViewModel>()
                .ForMember(dest => dest.Neighbourhood, opt => opt.MapFrom(src => src.NeighbourhoodGroupItemEntity))
                 .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.ProvinceGroupItemEntity))
                  .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.NationalityGroupItemEntity))
                .ReverseMap();

            //Document
            CreateMap<DocumentEntity, DocumentViewModel>()
            .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(src => src.DocumentTypeId))
            .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
             .ReverseMap();

            CreateMap<DocumentEntity, DocumentDetailViewModel>()
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.DocumentTypeGroupItemEntity))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ReverseMap();

            //Drivers Licence

            CreateMap<DriversLicenceEntity, DriversLicenceViewModel_Finak>()
                .ForMember(dest => dest.LicenceId, opt => opt.MapFrom(src => src.LicenceTypeId))
                .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ReverseMap();
            CreateMap<DriversLicenceEntity, DriversLicenceDetailViewModel>()
                .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ReverseMap();
            //---

  
            //---

        }
    }
}
