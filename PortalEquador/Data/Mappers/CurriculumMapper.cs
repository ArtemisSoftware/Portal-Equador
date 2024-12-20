﻿using AutoMapper;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.Languages.entity;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Domain.Document.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Education.University.ViewModels;
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
                .ForMember(dest => dest.SubType, opt => opt.MapFrom(src => src.SubTypeGroupItemEntity))
                .ForMember(dest => dest.SubTypeId, opt => opt.MapFrom(src => src.SubTypeId))
                 .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentTypeGroupItemEntity))
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

            CreateMap<DriversLicenceEntity, DriversLicenceViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.LicenceId, opt => opt.MapFrom(src => src.LicenceTypeId))
                .ForMember(dest => dest.ProvisionalRenewalNumber, opt => opt.MapFrom(src => src.ProvisionalRenewalNumber))
                //
                .ReverseMap();

            CreateMap<DriversLicenceEntity, DriversLicenceProvisionalViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.LicenceId, opt => opt.MapFrom(src => src.LicenceTypeId))
                .ForMember(dest => dest.ProvisionalRenewalNumber, opt => opt.MapFrom(src => src.ProvisionalRenewalNumber))
                .ReverseMap();

            CreateMap<DriversLicenceEntity, DriversLicenceProvisionalRenewViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.LicenceId, opt => opt.MapFrom(src => src.LicenceTypeId))
                .ForMember(dest => dest.ProvisionalRenewalNumber, opt => opt.MapFrom(src => src.ProvisionalRenewalNumber))
                .ReverseMap();

            CreateMap<DriversLicenceEntity, DriversLicenceRenewViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.LicenceId, opt => opt.MapFrom(src => src.LicenceTypeId))
                .ForMember(dest => dest.ProvisionalRenewalNumber, opt => opt.MapFrom(src => src.ProvisionalRenewalNumber))
                .ReverseMap();

            CreateMap<DriversLicenceEntity, DriversLicenceDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.Licence, opt => opt.MapFrom(src => src.LicenceTypeGroupItemEntity))
                .ForMember(dest => dest.ProvisionalRenewalNumber, opt => opt.MapFrom(src => src.ProvisionalRenewalNumber))
                .ReverseMap();

            CreateMap<UniversityEntity, UniversityViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                 .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.MajorGroupItemEntity))
                 .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.DegreeGroupItemEntity))
                 .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.InstitutionGroupItemEntity))
                .ReverseMap();

            CreateMap<UniversityEntity, UniversityDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.DegreeGroupItemEntity))
                 .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.MajorGroupItemEntity))
                 .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.InstitutionGroupItemEntity))
                .ReverseMap();

            CreateMap<SchoolEntity, SchoolViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                 .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.MajorGroupItemEntity))
                 .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.InstitutionGroupItemEntity))
                .ReverseMap();

            CreateMap<SchoolEntity, SchoolDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.DegreeGroupItemEntity))
                 .ForMember(dest => dest.Institution, opt => opt.MapFrom(src => src.InstitutionGroupItemEntity))
                 .ForMember(dest => dest.Major, opt => opt.MapFrom(src => src.MajorGroupItemEntity))
                .ReverseMap();
        }
    }
}
