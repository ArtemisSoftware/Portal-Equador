using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.Age;
using System.Net.Http;

namespace PortalEquador.Util.Report
{
    public class AgeReport
    {
        public static ExcelPackage GenerateReport(AgeReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("AgeReport");

            var nextRow = AddHeader(worksheet, viewModel.EmissionDate);
            nextRow = AddSubHeader(worksheet, nextRow);
            AddContent(worksheet, nextRow, viewModel.report);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            /*
           
            worksheet.Row(1).Height = 40;
            worksheet.Row(2).Height = 40;
            */
            return package;
        }

        private static int AddHeader(ExcelWorksheet ws, DateTime emissionDate)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Report.AGE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 2].Merge = true;

            column = 3;
            ws.Cells[row, column].Value = StringConstants.Display.EMISSION;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ++column;
            ws.Cells[row, column].Value = emissionDate.ToString(TimeUtil.dd_MM_yyyy) ;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            return 2;
        }

        private static int AddSubHeader(ExcelWorksheet ws, int row)
        {
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.NAME;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.CURRENT_WORKSTATION_IN_CONTRACT;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.AGENCY;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.DATE_OF_BIRTH;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.AGE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return 3;
        }

        private static void AddContent(ExcelWorksheet ws, int nextRow, List<AgeReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                int column = 1;
                ws.Cells[nextRow, column].Value = item.FullName;

                ++column;
                ws.Cells[nextRow, column].Value = item.WorkStation;

                ++column;
                ws.Cells[nextRow, column].Value = item.Agency;
                
                ++column;
                ws.Cells[nextRow, column].Value = item.DateOfBirth.ToString(TimeUtil.dd_MM_yyyy);

                ++column;
                ws.Cells[nextRow, column].Value = item.Age();

                ++nextRow;
            }
        }
    }
}
