using AutoMapper;
using PortalEquador.Data.PersonalInformation.Entity;
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
        }
    }
}
