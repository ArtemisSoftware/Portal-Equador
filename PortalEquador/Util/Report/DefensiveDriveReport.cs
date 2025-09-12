using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Util.Constants;
using System.Globalization;
using PortalEquador.Domain.Report.ViewModels.Trainning;

namespace PortalEquador.Util.Report
{
    public class DefensiveDriveReport
    {
        public static ExcelPackage GenerateReport(TrainningReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("DefensiveDriveReport");

            var nextRow = AddHeader(worksheet, viewModel.Date);
            nextRow = AddSubHeader(worksheet, nextRow);

            AddContent(worksheet, nextRow, viewModel.report);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            /*
            
            worksheet.Row(2).Height = 40;
            */
            worksheet.Row(1).Height = 30;
            return package;
        }

        private static int AddHeader(ExcelWorksheet ws, int date)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Report.DEFENSIVE_DRIVE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 5].Merge = true;

            column = 7;
            ws.Cells[row, column].Value = StringConstants.Display.EXERCISE + " " + date;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 7].Merge = true;

            return 2;
        }

        private static int AddSubHeader(ExcelWorksheet ws, int row)
        {
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.NAME;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.CONTRACT;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            CultureInfo culture = new CultureInfo("pt-PT");
            string[] monthAbbr = culture.DateTimeFormat.AbbreviatedMonthNames;

            foreach (string month in monthAbbr)
            {
                if (!string.IsNullOrEmpty(month)) // last element is empty
                {
                    ++column;
                    ws.Cells[row, column].Value = month;
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
            }

            return row + 1;
        }


        private static void AddContent(ExcelWorksheet ws, int row, List<TrainningReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                var column = 1;
                ws.Cells[row, column].Value = item.FullName;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                ws.Cells[row, column].Value = item.WorkStation;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                CultureInfo culture = new CultureInfo("pt-PT");

                for (int month = 1; month <= 12; month++)
                {
                    if (item.Date.Month == month)
                    {
                        var monthColumn = column + month;
                        ws.Cells[row, monthColumn].Value = item.Date.ToString(TimeUtil.dd_MM_yyyy);
                        ws.Cells[row, monthColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[row, monthColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        break;
                    }
                }

                ++row;
            }
        }
    }
}
