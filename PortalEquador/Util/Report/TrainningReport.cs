using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Util.Constants;
using System.Globalization;
using PortalEquador.Domain.Report.ViewModels.Trainning;
using PortalEquador.Domain.Uniforms.ViewModels;
using PortalEquador.Domain.GroupTypes.ViewModels;
using PortalEquador.Domain.Report.ViewModels.Uniforms;

namespace PortalEquador.Util.Report
{
    public class TrainningReport
    {
        public static ExcelPackage GenerateReport(TrainningReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("TrainningReport");
     

            var nextRow = AddTitleHeader(worksheet, viewModel.Date);
            nextRow = AddHeader(worksheet, nextRow, viewModel.Trainnings);
            AddContent(worksheet, nextRow, viewModel.Trainnings, viewModel.report);

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
                worksheet.Column(col).Width = maxWidth /3;
            }

            worksheet.Row(1).Height = 40;
            worksheet.Row(2).Height = 30;
            return package;
        }

        private static int AddTitleHeader(ExcelWorksheet ws, int date)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Report.TRAINNING.ToUpper();
            ws.Cells[row, column].Style.Font.Bold = true;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 7].Merge = true;

            ++row;
            ws.Cells[row, column].Value = StringConstants.Display.EXERCISE + " " + date;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 7].Merge = true;

            return row + 1;
        }

        private static int AddHeader(ExcelWorksheet ws, int row, List<GroupItemViewModel> trainnings)
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

            foreach (var item in trainnings)
            {
                ++column;
                ws.Cells[row, column].Value = item.Description;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            return ++row;
        }


        private static void AddContent(
            ExcelWorksheet ws,
            int row,
            List<GroupItemViewModel> trainnings,
            List<TrainningPerDayViewModel> report
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
                ws.Cells[row, column].Style.Numberformat.Format = "dd-MM-yyyy";
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                var index = 0;

                foreach (var trainning in trainnings)
                {
                    ++column;

                    if (item.Trainings.Contains(trainning.Id))
                    {
                        ws.Cells[row, column].Value = "✓";
                        ws.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                        ws.Cells[row, column].Style.Font.Bold = true;
                        ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }
                }

                ++row;
            }
        }

    }
}
