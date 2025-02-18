using AutoMapper;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.DriversLicence.ViewModels;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;

namespace PortalEquador.Data.Mappers
{
    public class ContractMapper : Profile
    {
        public ContractMapper()
        {
            CreateMap<MedicalExamEntity, MedicalExamViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Exam, opt => opt.MapFrom(src => src.ExamGroupItemEntity))
                .ReverseMap();

            CreateMap<MedicalExamEntity, MedicalExamCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.ExamId, opt => opt.MapFrom(src => src.ExamId))
                .ReverseMap();

            CreateMap<MedicalExamEntity, MedicalExamDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Exam, opt => opt.MapFrom(src => src.ExamGroupItemEntity))
                .ReverseMap();

            CreateMap<TrainningEntity, TrainningViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Trainning, opt => opt.MapFrom(src => src.TrainningGroupItemEntity))
                .ReverseMap();

            CreateMap<TrainningEntity, TrainningCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.TrainningId, opt => opt.MapFrom(src => src.TrainningId))
                .ReverseMap();

            CreateMap<TrainningEntity, TrainningDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Trainning, opt => opt.MapFrom(src => src.TrainningGroupItemEntity))
                .ReverseMap();

            CreateMap<DisciplinaryNotificationEntity, DisciplinaryNotificationViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Notification, opt => opt.MapFrom(src => src.NotificationGroupItemEntity))
                .ForMember(dest => dest.AccidentLevel, opt => opt.MapFrom(src => src.AccidentLevelGroupItemEntity))
                .ReverseMap();

            CreateMap<DisciplinaryNotificationEntity, DisciplinaryNotificationCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.NotificationId))
                .ForMember(dest => dest.AccidentLevelId, opt => opt.MapFrom(src => src.AccidentLevelId))
                .ReverseMap();

            CreateMap<DisciplinaryNotificationEntity, DisciplinaryNotificationDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Notification, opt => opt.MapFrom(src => src.NotificationGroupItemEntity))
                .ForMember(dest => dest.AccidentLevel, opt => opt.MapFrom(src => src.AccidentLevelGroupItemEntity))
                .ReverseMap();
        }
    }
}
