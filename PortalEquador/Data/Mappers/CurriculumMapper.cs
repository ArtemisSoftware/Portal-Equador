using AutoMapper;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.Languages.entity;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Languages.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;
using PortalEquador.Domain.Profession.Competence.ViewModels;
using PortalEquador.Domain.Profession.Experience.ViewModels;

namespace PortalEquador.Data.Mappers
{
    public class CurriculumMapper : Profile
    {
        public CurriculumMapper()
        {
            CreateMap<PersonalInformationEntity, PersonalInformationViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ReverseMap();

            CreateMap<PersonalInformationEntity, PersonalInformationDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.NationalityGroupItemEntity))
                .ForMember(dest => dest.Neighbourhood, opt => opt.MapFrom(src => src.NeighbourhoodGroupItemEntity))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.ProvinceGroupItemEntity))
                .ReverseMap();

            CreateMap<DocumentEntity, DocumentViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ReverseMap();

            CreateMap<DocumentEntity, DocumentDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                 .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.DocumentTypeGroupItemEntity))
                .ReverseMap();

            CreateMap<LanguageEntity, LanguageDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.OralLevel, opt => opt.MapFrom(src => src.OralLevelGroupItemEntity))
                 .ForMember(dest => dest.WrittenLevel, opt => opt.MapFrom(src => src.WrittenLevelGroupItemEntity))
                 .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.LanguageGroupItemEntity))
                .ReverseMap();

            CreateMap<LanguageEntity, LanguageViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                 .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.LanguageGroupItemEntity))
                .ReverseMap();

            CreateMap<ProfessionalCompetenceEntity, ProfessionalCompetenceViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ReverseMap();

            CreateMap<ProfessionalCompetenceEntity, ProfessionalCompetenceDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.Competence, opt => opt.MapFrom(src => src.CompetenceGroupItemEntity))
                .ReverseMap();

            CreateMap<ProfessionalExperienceEntity, ProfessionalExperienceViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                 .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyGroupItemEntity))
                 .ForMember(dest => dest.Workstation, opt => opt.MapFrom(src => src.WorkstationGroupItemEntity))
                .ReverseMap();

            CreateMap<ProfessionalExperienceEntity, ProfessionalExperienceDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.Workstation, opt => opt.MapFrom(src => src.WorkstationGroupItemEntity))
                 .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyGroupItemEntity))
                .ReverseMap();
        }
    }
}
