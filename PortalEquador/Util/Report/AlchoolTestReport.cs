using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using System.Drawing;
using System.Globalization;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;
using static PortalEquador.Util.Constants.StringConstants;

namespace PortalEquador.Util.Report
{
    public static class AlchoolTestReport
    {
        public static ExcelPackage GenerateReport(AlchoolTestReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("AlchoolTestReport");

            var daysOfMonth = Enumerable.Range(1, DateTime.DaysInMonth(viewModel.ReferenceDate.Year, viewModel.ReferenceDate.Month))
                                            .Select(day => new DateTime(viewModel.ReferenceDate.Year, viewModel.ReferenceDate.Month, day))
                                            .ToList();

            var nextRow = AddHeader(worksheet, StringConstants.Report.ALCHOOL_TEST, viewModel.EmissionDate);

            nextRow = AddSubHeader(worksheet, nextRow, daysOfMonth, viewModel.WorkStation);

            AddContent(worksheet, nextRow, daysOfMonth.Count, viewModel.report);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            worksheet.Row(2).Height = 40;

            return package;
        }


        private static int AddHeader(ExcelWorksheet ws, string testName, DateTime emissionDate)
        {
            ws.Cells[1, 1].Value = testName;
            ws.Cells["A1:K1"].Merge = true;
            ws.Cells["L1:L1"].Value = StringConstants.Display.EMISSION;
            ws.Cells["L1:P1"].Merge = true;
            ws.Cells["Q1:S1"].Value = emissionDate.ToString("dd-MM-yyyy HH:mm:ss");
            ws.Cells["Q1:S1"].Merge = true;
           
            return 2;
        }

        private static int AddSubHeader(ExcelWorksheet ws, int row, List<DateTime> daysOfMonth, string contract)
        {
            var nextColumn = 1;

            ws.Cells[row, nextColumn].Value = StringConstants.Display.NAME;
            ws.Cells[row, nextColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, nextColumn, row + 2, nextColumn].Merge = true;
            ++nextColumn;

            AddMidSubHeader(ws, row, nextColumn, daysOfMonth, contract);


            foreach (var day in daysOfMonth)
            {
                int weekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    day,
                    CalendarWeekRule.FirstFourDayWeek, 
                    DayOfWeek.Monday
                );

                bool shouldPaint = weekNumber % 2 != 0;

                ws.Cells[row + 1, nextColumn].Value = day.Day;
                ws.Cells[row + 2, nextColumn].Value = TimeUtil.GetFirstLetterOfWeekdayInPortuguese(day);
                if (shouldPaint)
                {
                    ws.Cells[row + 2, nextColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[row + 2, nextColumn].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }
                ++nextColumn;
            }


            ws.Cells[row, nextColumn].Value = Display.TOTAL_TESTS;
            ws.Cells[row, nextColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, nextColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, nextColumn, row + 2, nextColumn].Merge = true;

            ++nextColumn;
            ws.Cells[row, nextColumn].Value = Display.TOTAL_TESTS_PERCENTAGE;
            ws.Cells[row, nextColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, nextColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, nextColumn, row + 2, nextColumn].Merge = true;

            return row + 3;
        }

        private static void AddMidSubHeader(ExcelWorksheet ws, int row, int nextColumn, List<DateTime> daysOfMonth, string contract)
        {

            var baseColumn = nextColumn;
            var tempColumn = 0;

            ws.Cells[row, baseColumn].Value = Display.STEP;
            ws.Cells[row, baseColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, baseColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tempColumn = baseColumn + 6;
            ws.Cells[row, baseColumn, row, tempColumn].Merge = true;
            baseColumn = tempColumn + 1;

            ws.Cells[row, baseColumn].Value = daysOfMonth[0].ToString("dd-MMMM-yy");
            ws.Cells[row, baseColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, baseColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tempColumn = baseColumn + 2;
            ws.Cells[row, baseColumn, row, tempColumn].Merge = true;
            baseColumn = tempColumn + 1;

            ws.Cells[row, baseColumn].Value = daysOfMonth.Last().ToString("dd-MMMM-yy");
            ws.Cells[row, baseColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, baseColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tempColumn = baseColumn + 2;
            ws.Cells[row, baseColumn, row, tempColumn].Merge = true;
            baseColumn = tempColumn + 1;

            ws.Cells[row, baseColumn].Value = daysOfMonth.Count;
            ws.Cells[row, baseColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, baseColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tempColumn = baseColumn + 8;
            ws.Cells[row, baseColumn, row, tempColumn].Merge = true;
            baseColumn = tempColumn + 1;

            ws.Cells[row, baseColumn].Value = Display.CURRENT_WORKSTATION_IN_CONTRACT;
            ws.Cells[row, baseColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, baseColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tempColumn = baseColumn + 4;
            ws.Cells[row, baseColumn, row, tempColumn].Merge = true;
            baseColumn = tempColumn + 1;


            ws.Cells[row, baseColumn].Value = contract;
            ws.Cells[row, baseColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, baseColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            tempColumn = baseColumn + (daysOfMonth.Count - (baseColumn - 1));
            ws.Cells[row, baseColumn, row, tempColumn].Merge = true;

        }

        private static void AddContent(ExcelWorksheet ws, int nextRow, int numberOfDays, List<AlchoolTestReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                ws.Cells[nextRow, 1].Value = item.FullName;

                for (int dayIndex = 1; dayIndex <= numberOfDays; dayIndex++)
                {
                    if (item.AlcoholTests.Any(d => d.Date.Day == dayIndex))
                    {
                        ws.Cells[nextRow, dayIndex + 1].Value = 1;
                        ws.Cells[nextRow, dayIndex + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;

                        var test = item.AlcoholTests.Find(d => d.Date.Day == dayIndex);

                        if (test.Result == AlcoolTestResults.POSITIVE)
                        {
                            ws.Cells[nextRow, dayIndex + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.PaleVioletRed);
                        } else
                        {
                            ws.Cells[nextRow, dayIndex + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        }
                    }
                }

                ws.Cells[nextRow, numberOfDays + 2].Value = item.AlcoholTests.Count;
                ws.Cells[nextRow, numberOfDays + 3].Value = ((item.AlcoholTests.Count / (double)numberOfDays) * 100).ToString("0.#") + "%";
                ++nextRow;
            }
        }
    }
}
