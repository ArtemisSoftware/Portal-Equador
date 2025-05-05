using AutoMapper;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
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
                .ForMember(dest => dest.AlcoolTestResult, opt => opt.MapFrom(src => src.AlcoolTestResultGroupItemEntity))
                .ForMember(dest => dest.Decision, opt => opt.MapFrom(src => src.Decision))
                .ReverseMap();

            CreateMap<DisciplinaryNotificationEntity, DisciplinaryNotificationCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.NotificationId))
                .ForMember(dest => dest.AccidentLevelId, opt => opt.MapFrom(src => src.AccidentLevelId))
                .ForMember(dest => dest.AlcoolTestResultId, opt => opt.MapFrom(src => src.AlcoolTestResultId))
                .ForMember(dest => dest.Decision, opt => opt.MapFrom(src => src.Decision))
                .ReverseMap();

            CreateMap<DisciplinaryNotificationEntity, DisciplinaryNotificationDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Notification, opt => opt.MapFrom(src => src.NotificationGroupItemEntity))
                .ForMember(dest => dest.AccidentLevel, opt => opt.MapFrom(src => src.AccidentLevelGroupItemEntity))
                .ForMember(dest => dest.AlcoolTestResult, opt => opt.MapFrom(src => src.AlcoolTestResultGroupItemEntity))
                .ForMember(dest => dest.Nature, opt => opt.MapFrom(src => src.Decision))
                .ReverseMap();

            CreateMap<ContractEntity, ContractCreate__ViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.ContractStateId))
                .ReverseMap();

            CreateMap<ContractEntity, ContractResignViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.ContractStateId, opt => opt.MapFrom(src => src.ContractStateId))
                .ForMember(dest => dest.ResignationReasonsId, opt => opt.MapFrom(src => src.ResignationReasonId))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.ContractId))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                .ReverseMap();


            CreateMap<ContractEntity, ContractViewModel>()
                 //.ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                 .ForMember(dest => dest.ContractState, opt => opt.MapFrom(src => src.ContractStateGroupItemEntity))
                .ForMember(dest => dest.ResignationReasons, opt => opt.MapFrom(src => src.ResignationReasonGroupItemEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                //.ForMember(dest => dest.PersonalInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                //                .ForMember(dest => dest.ContractStatesId, opt => opt.MapFrom(src => src.ContractStateId))
                //                .ForMember(dest => dest.ResignationReasonsId, opt => opt.MapFrom(src => src.ResignationReasonId))
                .ReverseMap();

            CreateMap<ContractEntity, CurrentContractViewModel>()
             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PersonalInformationEntity.FirstName + " " + src.PersonalInformationEntity.LastName))
             
              .ReverseMap();
        }
    }
}
