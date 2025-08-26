using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using System.Globalization;

namespace PortalEquador.Util.Report
{
    public class MedicalExamReport
    {
        public static ExcelPackage GenerateReport(MedicalExamReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("MedicalExamReport");

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

            ws.Cells[row, column].Value = StringConstants.Report.MEDICAL_EXAM;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 6].Merge = true;

            column = 8 ;
            ws.Cells[row, column].Value = StringConstants.Display.EXERCISE + " " + date; 
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 8].Merge = true;

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

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.EXAM;
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

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.RESULT;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            return row + 1;
        }


        private static void AddContent(ExcelWorksheet ws, int row, List<MedicalExamReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                ws.Cells[row, 1].Value = item.FullName;
                ws.Cells[row, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[row, 2].Value = item.WorkStation;
                ws.Cells[row, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[row, 3].Value = item.Exam;
                ws.Cells[row, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var column = 3;
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

                ws.Cells[row, 16].Value = item.Situation;

                ++row;
            }
        }
    }
}
