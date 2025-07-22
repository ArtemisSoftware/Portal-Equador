using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using System.Data;
using System.Drawing;

namespace PortalEquador.Util
{
    public static class ReportUtil
    {

        public static FileContentResult GenerateReport(AgeReportViewModel viewModel)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("People");

                // --- Row 1: Custom merged headers ---
                ws.Cell(1, 1).Value = StringConstants.Report.AGE;
                ws.Range(1, 1, 1, 2).Merge(); 
                ws.Cell(1, 3).Value = StringConstants.Display.EMISSION;
                ws.Cell(1, 4).Value = viewModel.EmissionDate.ToString("dd-MM-yyyy");


                // --- Row 2: Actual table headers ---
                ws.Cell(2, 1).Value = StringConstants.Display.NAME;
                ws.Cell(2, 2).Value = StringConstants.Display.DATE_OF_BIRTH;
                ws.Cell(2, 3).Value = StringConstants.Display.AGE;
                ws.Cell(2, 4).Value = StringConstants.Display.CURRENT_WORKSTATION_IN_CONTRACT;

                // --- Apply bold formatting to headers & Set font size for the headers---
                ws.Range("A1:D2").Style.Font.Bold = true;
                ws.Range("A1:D2").Style.Font.FontSize = 18;


                // --- Fill data starting from row 3 ---
                int row = 3;
                foreach (var item in viewModel.report)
                {
                    ws.Cell(row, 1).Value = item.FullName;
                    ws.Cell(row, 2).Value = item.DateOfBirth;
                    ws.Cell(row, 3).Value = item.Age();
                    ws.Cell(row, 4).Value = item.WorkStation;
                    // Set font size for the entire table data
                    ws.Range("A3:D" + (row)).Style.Font.FontSize = 14; 
                    row++;
                }

                // Format the DateOfBirth column as dd-MM-yyyy
                ws.Column(2).Style.DateFormat.Format = "dd-MM-yyyy";
                ws.Column(2).Style.NumberFormat.Format = "dd-MM-yyyy"; // Extra safety

                // --- Create table from the data range (includes headers) ---
                var tableRange = ws.Range(2, 1, row - 1, 4); // from header row 2 to last data row
                var table = tableRange.CreateTable();
                table.Theme = XLTableTheme.TableStyleMedium9; // Optional styling

                // Auto-size columns to fit content & Then double the size for more breathing room
                ws.Columns().AdjustToContents();
                foreach (var column in ws.Columns())
                {
                    column.Width *= 2;
                }

                return ExcelUtil.GenerateExcel(wb, viewModel.FileName);
            }
        }


        public static FileContentResult GenerateReport(AlchoolTestReportViewModel viewModel)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("People");

                var numberOfDays = 31;

                var nextRow = AddHeader(ws, StringConstants.Report.ALCHOOL_TEST, viewModel.EmissionDate);

                nextRow = AddSubHeader(ws, nextRow, numberOfDays);

                AddContent(ws, nextRow, numberOfDays, viewModel.report);



















                // --- Row 1: Custom merged headers ---



                // --- Row 2: Actual table headers ---
                /*
                
                */
                /*
                ws.Cell(2, 2).Value = StringConstants.Display.DATE_OF_BIRTH;
                ws.Cell(2, 3).Value = StringConstants.Display.AGE;
                ws.Cell(2, 4).Value = StringConstants.Display.CURRENT_WORKSTATION_IN_CONTRACT;
                */
                // --- Apply bold formatting to headers & Set font size for the headers---
                //ws.Range("A1:D2").Style.Font.Bold = true;
                //ws.Range("A1:D2").Style.Font.FontSize = 18;



                // --- Fill data starting from row 3 ---
                /*
                int row = 5;

                    */
                /*
                ws.Cell(row, 2).Value = item.DateOfBirth;
                ws.Cell(row, 3).Value = item.Age();
                ws.Cell(row, 4).Value = item.WorkStation;
                */
                // Set font size for the entire table data
                //ws.Range("A3:D" + (row)).Style.Font.FontSize = 14;
                /*    row++;
                }
            */
                // Format the DateOfBirth column as dd-MM-yyyy
                //ws.Column(2).Style.DateFormat.Format = "dd-MM-yyyy";
                //ws.Column(2).Style.NumberFormat.Format = "dd-MM-yyyy"; // Extra safety

                // --- Create table from the data range (includes headers) ---
                /*
                var tableRange = ws.Range(2, 1, nextRow - 1, 4); // from header row 2 to last data row
                var table = tableRange.CreateTable();
                table.Theme = XLTableTheme.TableStyleMedium9; // Optional styling
                */
                // Auto-size columns to fit content & Then double the size for more breathing room
                //ws.Columns().AdjustToContents();
                /*
                foreach (var column in ws.Columns())
                {
                    column.Width *= 2;
                }
                */
                return ExcelUtil.GenerateExcel(wb, viewModel.FileName);
            }
        }

        private static void AddContent(IXLWorksheet ws, int nextRow, int numberOfDays, List<AlchoolTestReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                ws.Cell(nextRow, 1).Value = item.FullName;

                for (int dayIndex = 1; dayIndex <= numberOfDays; dayIndex++)
                {

                    if (item.AlcoholTests.Any(d => d.Date.Day == dayIndex))
                    {
                        ws.Cell(nextRow, dayIndex + 1).Value = 1;
                        ws.Cell(nextRow, dayIndex + 1).Style.Fill.PatternType = XLFillPatternValues.DarkTrellis;
                        ws.Cell(nextRow, dayIndex + 1).Style.Fill.PatternColor = XLColor.Red;
                        ws.Cell(nextRow, dayIndex + 1).Style.Fill.SetBackgroundColor(XLColor.LightGreen); //XLColor.Red
                        ws.Cell(nextRow, dayIndex + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        ws.Cell(nextRow, dayIndex + 1) .Style.Font.SetFontColor(XLColor.LightGreen);



                    }
                }

                ws.Cell(nextRow, numberOfDays + 2).Value = item.AlcoholTests.Count;
                ws.Cell(nextRow, numberOfDays + 3).Value = ((item.AlcoholTests.Count / (double)numberOfDays) * 100).ToString("0.#") + "%";
                ++nextRow;
            }
        }

        private static int AddHeader(IXLWorksheet ws, string testName, DateTime emissionDate)
        {
            ws.Cell(1, 1).Value = testName;
            ws.Range(1, 1, 1, 2).Merge();
            ws.Cell(1, 3).Value = StringConstants.Display.EMISSION;
            ws.Cell(1, 4).Value = emissionDate.ToString("dd-MM-yyyy");

            return 2;
        }

        private static int AddSubHeader(IXLWorksheet ws, int row, int numberOfDays)
        {
            var nextColumn = 1;

            ws.Cell(row, nextColumn).Value = StringConstants.Display.NAME;
            ws.Cell(row, nextColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range(row, nextColumn, row + 2, nextColumn).Merge();
            ++nextColumn;

            for (int dayIndex = 1; dayIndex <= numberOfDays; dayIndex++)
            {
                ws.Cell(row + 1, nextColumn).Value = dayIndex;
                ws.Cell(row + 2, nextColumn).Value = dayIndex;
                ++nextColumn;
            }
            
            ws.Cell(row, nextColumn).Value = StringConstants.Display.TOTAL_TESTS;
            ws.Cell(row, nextColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range(row, nextColumn, row + 2, nextColumn).Merge();
            
            ++nextColumn;
            ws.Cell(row, nextColumn).Value = StringConstants.Display.TOTAL_TESTS_PERCENTAGE;
            ws.Cell(row, nextColumn).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws.Range(row, nextColumn, row + 2, nextColumn).Merge();

            return row + 3;
        }









    }
}
