using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.UseCases;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Util;
using PortalEquador.Util.Report;

namespace PortalEquador.Controllers.Report
{
    public class ReportController(
        IReportRepository repository,
        GetAlchoolTestReportUseCase getAlchoolTestReportUseCase,
        GetDriversLicenceReportUseCase getDriversLicenceReportUseCase
        ) : Controller
    {

        // GET: Report
        public async Task<IActionResult> Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<FileResult> ExportAgeReportInExcel()
        {
            var result = await repository.GetAgeReport();
            return ReportUtil.GenerateReport(result);
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
    }
}
