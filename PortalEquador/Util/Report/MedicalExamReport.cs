using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using System.Globalization;
using static PortalEquador.Util.Constants.GroupTypesConstants.ItemFromGroup;
using PortalEquador.Domain.GroupTypes.ViewModels;

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
            nextRow = AddSubHeader(worksheet, nextRow, viewModel.Exams);
            AddContent(worksheet, nextRow, viewModel.report, viewModel.Exams);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            worksheet.Cells[worksheet.Dimension.Address].Style.WrapText = true;
            int totalColumns = worksheet.Dimension.End.Column;
            double maxWidth = 0;

            // find the widest column
            for (int col = 1; col <= totalColumns; col++)
            {
                if (worksheet.Column(col).Width > maxWidth)
                    maxWidth = worksheet.Column(col).Width;
            }

            // set all columns to that width
            for (int col = 4; col <= totalColumns; col++)
            {
                worksheet.Column(col).Width = maxWidth * 2 / 3 + 10;
            }
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

        private static int AddSubHeader(
            ExcelWorksheet ws, 
            int row, 
            List<GroupItemViewModel> exams
            )
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
            ws.Cells[row, column].Value = StringConstants.Display.DATE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            foreach (var item in exams)
            {
                ++column;
                ws.Cells[row, column].Value = item.Description;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            return row + 1;
        }


        private static void AddContent(
            ExcelWorksheet ws, 
            int row, 
            List<MedicalExamReportItemViewModel> report,
            List<GroupItemViewModel> exams
            )
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
                ws.Cells[row, column].Value = item.Date/*.ToString(TimeUtil.dd_MM_yyyy)*/;
                ws.Cells[row, column].Style.Numberformat.Format = TimeUtil.dd_MM_yyyy;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                foreach (var exam in exams)
                {
                    ++column;

                    if (item.Exams.Any(e => e.Id == exam.Id))
                    {
                        var result = item.Exams.FirstOrDefault(e => e.Id == exam.Id);

                        if (result.SituationId == ExamResult.APT)
                        {
                            ws.Cells[row, column].Value = "✓ " + result.Situation;
                            ws.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                        }
                        else if (result.SituationId == ExamResult.CONDITIONED)
                        {
                            ws.Cells[row, column].Value = "⚠ " + result.Situation;
                            ws.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Orange);
                        }
                        else if (result.SituationId == ExamResult.INEPT)
                        {
                            ws.Cells[row, column].Value = "✗ " + result.Situation;
                            ws.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                        }
                        else
                        {
                            ws.Cells[row, column].Value = "✓ " + result.Situation;
                            ws.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                        }

                        
                        ws.Cells[row, column].Style.Font.Bold = true;
                        ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }
                    
                }

                if (!item.Date.HasValue)
                {
                    ws.Cells[row, 1, row, column + exams.Count - 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[row, 1, row, column + exams.Count - 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                }

                ++row;
            }
        }
    }
}
