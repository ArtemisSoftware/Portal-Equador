using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;

namespace PortalEquador.Util.Report
{
    public class DriversLicenceReport
    {
        public static ExcelPackage GenerateReport(DriversLicenceReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("DriversLicenceReport");

            var nextRow = AddHeader(worksheet, StringConstants.Report.ALCHOOL_TEST, viewModel.EmissionDate);
   
            AddContent(worksheet, nextRow, viewModel.report);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            worksheet.Row(1).Height = 40;
            worksheet.Row(2).Height = 40;
            
            return package;
        }

        private static int AddHeader(ExcelWorksheet ws, string testName, DateTime emissionDate)
        {
            int row = 1;
            int subRow = 2;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.NAME;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.CONTRACT;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.DRIVERS_LICENCE_TYPE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.DRIVERS_LICENCE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row, column + 1].Merge = true;

            ws.Cells[subRow, column].Value = StringConstants.Display.EXPIRATION_DATE;
            ws.Cells[subRow, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[subRow, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[subRow, column].Value = StringConstants.Display.REMAINING_TIME;
            ws.Cells[subRow, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[subRow, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.PROVISIONAL_EXPIRATION_DATE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row, column+ 1].Merge = true;

            ws.Cells[subRow, column].Value = StringConstants.Display.EXPIRATION_DATE;
            ws.Cells[subRow, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[subRow, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[subRow, column].Value = StringConstants.Display.REMAINING_TIME;
            ws.Cells[subRow, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[subRow, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return 3;
        }

        private static void AddContent(ExcelWorksheet ws, int nextRow, List<DriversLicenceReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                ws.Cells[nextRow, 1].Value = item.FullName;
                ws.Cells[nextRow, 2].Value = item.WorkStation;
                ws.Cells[nextRow, 3].Value = item.Licence;

                ws.Cells[nextRow, 4].Value = item.LicenceExpirationDate?.ToString(TimeUtil.dd_MM_yyyy);
                ws.Cells[nextRow, 5].Value = item.GetLicenceExpirationRemainingTime();
                ws.Cells[nextRow, 6].Value = item.ProvisionalExpirationDate?.ToString(TimeUtil.dd_MM_yyyy);
                ws.Cells[nextRow, 7].Value = item.GetProvisionalExpirationRemainingTime();
                
                ++nextRow;
            }
        }
    }
}
