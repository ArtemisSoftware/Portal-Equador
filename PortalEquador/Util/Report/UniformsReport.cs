using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.Uniforms;
using PortalEquador.Domain.Uniforms.ViewModels;

namespace PortalEquador.Util.Report
{
    public class UniformsReport
    {
        public static ExcelPackage GenerateReport(UniformsReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("UniformsReport");

            var nextRow = AddHeader(worksheet, viewModel.Uniforms, viewModel.AddUniformReturn);

            AddContent(
                worksheet,
                nextRow,
                viewModel.Uniforms,
                viewModel.Report, 
                viewModel.AddUniformReturn
             );

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            /*
            
            worksheet.Row(1).Height = 30;
            worksheet.Row(2).Height = 40;
            */
            return package;
        }

        private static int AddHeader(ExcelWorksheet ws, List<UniformViewModel> uniforms, bool addUniformReturn)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.NAME;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.CONTRACT;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.QUANTITY;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            foreach (var item in uniforms)
            {
                ++column;
                ws.Cells[row, column].Value = item.Description;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.MEASURE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            if (addUniformReturn)
            {
                ++column;
                ws.Cells[row, column].Value = StringConstants.Display.RETURN_DATE;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
            return ++row;
        }


        private static void AddContent(
            ExcelWorksheet ws, 
            int row,
            List<UniformViewModel> uniforms,
            List<UniformsReportItemViewModel> report,
            bool addUniformReturn
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
                ws.Cells[row, column].Value = item.Quantity;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var index = 0;

                foreach (var uniform in uniforms)
                {
                    ++column;

                    if(uniform.Id == item.UniformId)
                    {
                        ws.Cells[row, column].Value = item.Date.ToString(TimeUtil.dd_MM_yyyy);
                        ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                }

                ++column;
                ws.Cells[row, column].Value = item.Size;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                if (addUniformReturn)
                {
                    ++column;
                    ws.Cells[row, column].Value = item.ReturnDate?.ToString(TimeUtil.dd_MM_yyyy) ?? string.Empty;
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                

                ++row;
            }
        }
    }
}