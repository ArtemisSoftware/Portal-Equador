using AutoMapper;
using PortalEquador.Data;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Domain.Documents.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Domain.ProfessionalCompetence.ViewModels;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
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

            //ProfessionalExperience

            CreateMap<ProfessionalExperienceEntity, ProfessionalExperienceViewModel>()
                 .ForMember(dest => dest.WorkstationId, opt => opt.MapFrom(src => src.WorkstationId))
                 .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                 .ForMember(dest => dest.Years, opt => opt.MapFrom(src => src.Months / 12))
                 .ForMember(dest => dest.Months, opt => opt.MapFrom(src => src.Months % 12))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ReverseMap();

            CreateMap<ProfessionalExperienceEntity, ProfessionalExperienceDetailViewModel>()
                .ForMember(dest => dest.Workstation, opt => opt.MapFrom(src => src.WorkstationGroupItemEntity))
                .ForMember(dest => dest.ProfessionalExperience, opt => opt.MapFrom(src => src.CompanyGroupItemEntity))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ReverseMap();

            //ProfessionalCompetence

            CreateMap<ProfessionalCompetenceEntity, ProfessionalCompetenceViewModel>()
                .ForMember(dest => dest.CompetenceId, opt => opt.MapFrom(src => src.CompetenceId))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ReverseMap();

            CreateMap<ProfessionalCompetenceEntity, ProfessionalCompetenceDetailViewModel>()
                .ForMember(dest => dest.ProfessionalCompetence, opt => opt.MapFrom(src => src.CompetenceGroupItemEntity))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.PersonalInformation, opt => opt.MapFrom(src => src.PersonalInformationEntity))
                .ReverseMap();

        }
    }
}
