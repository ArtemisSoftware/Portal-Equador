using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.Accident;
using PortalEquador.Domain.Report.ViewModels.Age;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Domain.Report.ViewModels.Education;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Domain.Report.ViewModels.Profession.Competence;
using PortalEquador.Domain.Report.ViewModels.Trainning;
using PortalEquador.Domain.Report.ViewModels.Uniforms;

namespace PortalEquador.Domain.Report.Repository
{
    public interface IReportRepository
    {
        Task<AgeReportFormViewModel> GetAgeForm();
        Task<AgeReportViewModel> GetAgeReport(List<int> accessibleContracts);

        Task<AlchoolTestViewModel> GetAlchoolTestForm();
        Task<AlchoolTestReportViewModel> GetAlchoolTestReport(string contractDescription, DateTime date, List<int> accessibleContracts);

        Task<DriversLicenceReportFormViewModel> GetDriversLicenceForm();
        Task<DriversLicenceReportViewModel> GetDriversLicenceReport(List<int> accessibleContracts);

        Task<MedicalExamReportFormViewModel> GetMedicalExamForm();
        Task<MedicalExamReportViewModel> GetMedicalExamReport(int year, List<int> accessibleContracts);

        Task<ProfessionalExperienceReportFormViewModel> GetProfessionalExperienceForm();
        Task<ProfessionalExperienceReportViewModel> GetProfessionalExperienceReport(int experienceId, List<int> accessibleContracts);

        Task<TrainningReportFormViewModel> GetTrainningForm();
        Task<TrainningReportViewModel> GetTrainningReport(int year, List<int> accessibleContracts);

        Task<EducationReportFormViewModel> GetEducationForm();
        Task<EducationReportViewModel> GetEducationReport(int educationId);

        Task<AccidentReportFormViewModel> GetAccidentsForm();
        Task<AccidentReportViewModel> GetAccidentReport(string description, List<int> accessibleContracts);

        Task<UniformsReportFormViewModel> GetUniformsForm();
        Task<UniformsReportViewModel> GetUniformsReport(int year, List<int> accessibleContracts, bool addUniformReturn);
    }
}
