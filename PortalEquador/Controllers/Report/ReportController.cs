using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.UseCases;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Util;
using PortalEquador.Util.Report;

namespace PortalEquador.Controllers.Report
{
    public class ReportController(
        IReportRepository repository,
        GetAlchoolTestReportUseCase getAlchoolTestReportUseCase
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


        public async Task<IActionResult> AlchoolTestReportForm()
        {
            var model = await repository.GetAlchoolTestForm();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlchoolTestReportForm(AlchoolTestViewModel viewmodel)
        {
            return await ExportAlchoolTestReportInExcel(viewmodel.Date, viewmodel.ContractId);
        }

         [HttpGet]
        public async Task<FileResult> ExportAlchoolTestReportInExcel(DateTime date, int contractId)
        {
            var result = await getAlchoolTestReportUseCase.Invoke(date, contractId);
            var report = AlchoolTestReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }


    }
}
