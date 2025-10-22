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
            /*
            
            worksheet.Row(2).Height = 40;
            */
            worksheet.Row(1).Height = 30;
            return package;
        }

        private static int AddTitleHeader(ExcelWorksheet ws, int date)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.EXERCISE + " " + date;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row, column, row, column + 7].Merge = true;

            return 2;
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
            List<TrainningReportItemViewModel> report
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

                var index = 0;

                foreach (var trainning in trainnings)
                {
                    ++column;

                    if (trainning.Id == item.TrainningId)
                    {
                        ws.Cells[row, column].Value = item.Date.ToString(TimeUtil.dd_MM_yyyy);
                        ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                }

                ++row;
            }
        }

    }
}
