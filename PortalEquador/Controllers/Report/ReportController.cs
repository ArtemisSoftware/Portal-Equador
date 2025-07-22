using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PortalEquador.Data;
using PortalEquador.Data.Contract.Entities;
using PortalEquador.Domain.Education.School.ViewModels;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Domain.Trainning.Repository;
using PortalEquador.Domain.Trainning.UseCases;
using PortalEquador.Util;
using PortalEquador.Util.Constants;
using PortalEquador.Util.Report;

namespace PortalEquador.Controllers.Report
{
    public class ReportController(
        IReportRepository repository
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
            var result = await repository.GetAlchoolTestReport(date, contractId);
            var report = AlchoolTestReport.GenerateReport(result);
            return await ReportBuilderUtil.GenerateExcel(this, report, result.FileName);
        }


    }
}
