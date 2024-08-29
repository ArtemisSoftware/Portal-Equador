using AutoMapper;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.PersonalInformation.ViewModels;

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
        }
    }
}
