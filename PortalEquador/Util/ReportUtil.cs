using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using System.Data;

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
                    ws.Cell(row, 2).Value = item.DateOfBirth.ToShortDateString();
                    ws.Cell(row, 3).Value = item.Age();
                    ws.Cell(row, 4).Value = item.WorkStation;
                    // Set font size for the entire table data
                    ws.Range("A3:D" + (row - 1)).Style.Font.FontSize = 14; 
                    row++;
                }

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














    }
}
