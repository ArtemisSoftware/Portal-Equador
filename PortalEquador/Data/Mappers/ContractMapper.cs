using AutoMapper;
using PortalEquador.Data.Accident.Entities;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Data.DisciplinaryNotification.Entity;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.MedicalExam.Entity;
using PortalEquador.Data.Trainning.Entity;
using PortalEquador.Data.Uniforms.Entities;
using PortalEquador.Domain.Accident.ViewModels;
using PortalEquador.Domain.Contract.ViewModels;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.MedicalExam.ViewModels;
using PortalEquador.Domain.Trainning.ViewModels;
using PortalEquador.Domain.Uniforms.ViewModels;

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
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.ResultGroupItemEntity))
                .ReverseMap();

            CreateMap<MedicalExamEntity, MedicalExamCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.ExamId, opt => opt.MapFrom(src => src.ExamId))
                .ForMember(dest => dest.ResultId, opt => opt.MapFrom(src => src.ResultId))
                .ReverseMap();

            CreateMap<MedicalExamEntity, MedicalExamDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Exam, opt => opt.MapFrom(src => src.ExamGroupItemEntity))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.ResultGroupItemEntity))
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
                  .ForMember(dest => dest.ContractState, opt => opt.MapFrom(src => src.ContractStateGroupItemEntity))
                .ForMember(dest => dest.ResignationReasons, opt => opt.MapFrom(src => src.ResignationReasonGroupItemEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                .ReverseMap();

            CreateMap<ContractEntity, CurrentContractViewModel>()
             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PersonalInformationEntity.FirstName + " " + src.PersonalInformationEntity.LastName))
              .ReverseMap();

            CreateMap<AccidentEntity, AccidentDetailViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PersonalInformationEntity.FirstName + " " + src.PersonalInformationEntity.LastName))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.CityGroupItemEntity))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.LevelGroupItemEntity))
                .ForMember(dest => dest.EstimatedValue, opt => opt.MapFrom(src => src.EstimatedValueGroupItemEntity))
                .ForMember(dest => dest.Contract, opt => opt.MapFrom(src => src.ContractGroupItemEntity))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
                .ForMember(dest => dest.HumanDamage, opt => opt.MapFrom(src => src.HumanDamage))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Causes, opt => opt.MapFrom(src => src.Accidents))
                .ReverseMap();

            CreateMap<AccidentEntity, AccidentViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PersonalInformationEntity.FirstName + " " + src.PersonalInformationEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId))
                .ForMember(dest => dest.EstimatedValueId, opt => opt.MapFrom(src => src.EstimatedValueId))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.ContractId))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.HumanDamage, opt => opt.MapFrom(src => src.HumanDamage))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Date.TimeOfDay))
                .ReverseMap()
                // recombine Date and Time back into one DateTime
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src =>
                    src.Date.HasValue
                        ? src.Date.Value.Date + (src.Time ?? TimeSpan.Zero)
                        : DateTime.MinValue   // or make AccidentEntity.Date nullable if you want
                ));

            CreateMap<AccidentEntity, AccidentEditViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.PersonalInformationEntity.FirstName + " " + src.PersonalInformationEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.VehicleEntity))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId))
                .ForMember(dest => dest.Causes, opt => opt.MapFrom(src => src.Accidents))
                .ForMember(dest => dest.EstimatedValueId, opt => opt.MapFrom(src => src.EstimatedValueId))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.ContractId))
                .ForMember(dest => dest.HumanDamage, opt => opt.MapFrom(src => src.HumanDamage))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Date.TimeOfDay))
                .ReverseMap()
                // recombine Date and Time back into one DateTime
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src =>
                    src.Date.HasValue
                        ? src.Date.Value.Date + (src.Time ?? TimeSpan.Zero)
                        : DateTime.MinValue   // or make AccidentEntity.Date nullable if you want
                ));

            CreateMap<GroupItemEntity, AccidentCauseViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.CauseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<AccidentCauseEntity, AccidentCauseViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.CauseId, opt => opt.MapFrom(src => src.CauseId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cause, opt => opt.MapFrom(src => src.CauseGroupItemEntity))
                .ReverseMap();

            CreateMap<AccidentEditViewModel, AccidentViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.Editor))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonaInformationId))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId))
                .ForMember(dest => dest.EstimatedValueId, opt => opt.MapFrom(src => src.EstimatedValueId))
                .ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.ContractId))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.Vehicle.Id))
                .ForMember(dest => dest.Causes, opt => opt.MapFrom(src => src.AllCauses))
                .ForMember(dest => dest.HumanDamage, opt => opt.MapFrom(src => src.HumanDamage))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
                .ReverseMap()
                // recombine Date and Time back into one DateTime
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src =>
                    src.Date.HasValue
                        ? src.Date.Value.Date + (src.Time ?? TimeSpan.Zero)
                        : DateTime.MinValue   // or make AccidentEntity.Date nullable if you want
                ));

            CreateMap<UniformEntity, UniformViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.isSizeNumeric, opt => opt.MapFrom(src => src.isSizeNumeric))
                .ReverseMap();

            CreateMap<WorkerUniformEntity, WorkerUniformCreateViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ReverseMap()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src =>
                    src.IsNumericSize
                        ? src.Size : src.LabelSizeId.ToString()
                ));

            CreateMap<WorkerUniformEntity, WorkerUniformViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.Uniform, opt => opt.MapFrom(src => src.UniformItemEntity))
                .ReverseMap();
            
            CreateMap<WorkerUniformEditViewModel, WorkerUniformCreateViewModel>()
                  .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.Editor))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonaInformationId))
                .ForMember(dest => dest.UniformId, opt => opt.MapFrom(src => src.Uniform.Id))
                .ReverseMap();
            

            CreateMap<WorkerUniformEntity, WorkerUniformEditViewModel>()
                .ForMember(dest => dest.Editor, opt => opt.MapFrom(src => src.ApplicationUserEntity.FirstName + " " + src.ApplicationUserEntity.LastName))
                .ForMember(dest => dest.PersonaInformationId, opt => opt.MapFrom(src => src.PersonalInformationId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => (src.PersonalInformationEntity.FirstName + " " + src.PersonalInformationEntity.LastName)))
               .ForMember(dest => dest.Uniform, opt => opt.MapFrom(src => src.UniformItemEntity))
                .ReverseMap()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src =>
                    src.Uniform.isSizeNumeric
                        ? src.Size : src.LabelSizeId.ToString()
                ));
        }
    }
}
