using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.Education;

namespace PortalEquador.Util.Report
{
    public class EducationReport
    {
        public static ExcelPackage GenerateReport(EducationReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("EducationReport");

            var nextRow = AddHeader(worksheet);
            AddContent(worksheet, nextRow, viewModel.report);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            worksheet.Row(1).Height = 40;
            
            return package;
        }

        private static int AddHeader(ExcelWorksheet ws)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.NAME;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.INSTITUTION;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.DEGREE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.MAJOR;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return 2;
        }

        private static void AddContent(ExcelWorksheet ws, int nextRow, List<EducationReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                int column = 1;
                ws.Cells[nextRow, column].Value = item.FullName;

                ++column;
                ws.Cells[nextRow, column].Value = item.Institution;

                ++column;
                ws.Cells[nextRow, column].Value = item.Degree;

                ++column;
                ws.Cells[nextRow, column].Value = item.Major;

                ++nextRow;
            }
        }
    }
}
