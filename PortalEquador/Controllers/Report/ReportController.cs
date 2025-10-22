using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.UseCases;
using PortalEquador.Domain.Report.ViewModels.Accident;
using PortalEquador.Domain.Report.ViewModels.Age;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Domain.Report.ViewModels.Education;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Domain.Report.ViewModels.Profession.Competence;
using PortalEquador.Domain.Report.ViewModels.Trainning;
using PortalEquador.Domain.Report.ViewModels.Uniforms;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using PortalEquador.Util.Report;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Controllers.Report
{
    public class ReportController(
        IReportRepository repository,
        GetAlchoolTestReportUseCase getAlchoolTestReportUseCase,
        GetDriversLicenceReportUseCase getDriversLicenceReportUseCase,
        GetAgeReportUseCase getAgeReportUseCase,
        GetMedicalExamReportUseCase getMedicalExamReportUseCase,
        GetProfessionalExperienceReportUseCase getProfessionalExperienceReportUseCase,
        GetTrainningReportUseCase getTrainningReportUseCase,
        GetAccidentReportUseCase getAccidentReportUseCase,
        GetUniformsReportUseCase getUniformsReportUseCase,
        GetUniformsReportFormUseCase getUniformsReportFormUseCase
        ) : Controller
    {

        // GET: Report
        public async Task<IActionResult> Index()
        {
            return View();
        }


        /*--------------AgeReport---------------*/


        public async Task<IActionResult> AgeReportForm(string? error)
        {
            var model = await repository.GetAgeForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgeReportForm(AgeReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportAgeReportInExcel(viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await AgeReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportAgeReportInExcel(int contractId)
        {
            var result = await getAgeReportUseCase.Invoke(contractId);
            var report = AgeReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }


        /*--------------AlchoolTestReport---------------*/


        public async Task<IActionResult> AlchoolTestReportForm(string? error)
        {
            var model = await repository.GetAlchoolTestForm();
            if(error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlchoolTestReportForm(AlchoolTestViewModel viewmodel)
        {
            try
            {
                return await ExportAlchoolTestReportInExcel(viewmodel.Date, viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await AlchoolTestReportForm(ex.Message.ToString());
            }
        }

         [HttpGet]
        public async Task<FileResult> ExportAlchoolTestReportInExcel(DateTime date, int contractId)
        {
            var result = await getAlchoolTestReportUseCase.Invoke(date, contractId);
            var report = AlchoolTestReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }

        /*--------------DriversLicenceReport---------------*/

        public async Task<IActionResult> DriversLicenceReportForm(string? error)
        {
            var model = await repository.GetDriversLicenceForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DriversLicenceReportForm(DriversLicenceReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportDriversLicenceReportInExcel(viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await DriversLicenceReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportDriversLicenceReportInExcel(int contractId)
        {
            var result = await getDriversLicenceReportUseCase.Invoke(contractId);
            var report = DriversLicenceReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }

        /*--------------MedicalExam---------------*/

        public async Task<IActionResult> MedicalExamReportForm(string? error)
        {
            var model = await repository.GetMedicalExamForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MedicalExamReportForm(MedicalExamReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportMedicalExamReportInExcel(viewmodel.Date, viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await MedicalExamReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportMedicalExamReportInExcel(string year, int contractId)
        {
            var result = await getMedicalExamReportUseCase.Invoke(year, contractId);
            var report = MedicalExamReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }

        /*--------------ProfessionalExperienceReport---------------*/

        public async Task<IActionResult> ProfessionalExperienceReportForm(string? error)
        {
            var model = await repository.GetProfessionalExperienceForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfessionalExperienceReportForm(ProfessionalExperienceReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportProfessionalExperienceReportInExcel(viewmodel.ExperienceId, viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await ProfessionalExperienceReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportProfessionalExperienceReportInExcel(int experienceId, int contractId)
        {
            var result = await getProfessionalExperienceReportUseCase.Invoke(experienceId, contractId);
            var report = ProfessionalExperienceReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }

        /*--------------TrainningReport---------------*/

        public async Task<IActionResult> TrainningReportForm(string? error)
        {
            var model = await repository.GetTrainningForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrainningReportForm(TrainningReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportTrainningReportInExcel(viewmodel.Year, viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await TrainningReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportTrainningReportInExcel(string year, int contractId)
        {
            var result = await getTrainningReportUseCase.Invoke(year, contractId);
            var report = TrainningReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }



        /*--------------EducationReport---------------*/

        public async Task<IActionResult> EducationReportForm(string? error)
        {
            var model = await repository.GetEducationForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EducationReportForm(EducationReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportEducationReportInExcel(viewmodel.EducationId);
            }
            catch (Exception ex)
            {
                return await EducationReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportEducationReportInExcel( int educationId)
        {
            var result = await repository.GetEducationReport(educationId);
            var report = EducationReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }



        /*--------------Accident---------------*/

        public async Task<IActionResult> AccidentReportForm(string? error)
        {
            var model = await repository.GetAccidentsForm();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AccidentReportForm(AccidentReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportAccidentReportInExcel(viewmodel.ContractId);
            }
            catch (Exception ex)
            {
                return await AccidentReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportAccidentReportInExcel(int contractId)
        {
            var result = await getAccidentReportUseCase.Invoke(contractId);
            var report = AccidentReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }

        /*--------------Uniforms---------------*/

        public async Task<IActionResult> UniformReportForm(string? error)
        {
            var model = await getUniformsReportFormUseCase.Invoke();
            if (error != null)
            {
                model.Error = error;
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UniformReportForm(UniformsReportFormViewModel viewmodel)
        {
            try
            {
                return await ExportUniformReportInExcel(viewmodel.ContractId, viewmodel.AddUniformReturn);
            }
            catch (Exception ex)
            {
                return await UniformReportForm(ex.Message.ToString());
            }
        }

        [HttpGet]
        public async Task<FileResult> ExportUniformReportInExcel(int contractId, bool addUniformReturn)
        {
            var result = await getUniformsReportUseCase.Invoke(contractId, addUniformReturn);
            var report = UniformsReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }

    }
}
