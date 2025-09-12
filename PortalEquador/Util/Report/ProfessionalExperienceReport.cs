using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.Profession.Competence;

namespace PortalEquador.Util.Report
{
    public class ProfessionalExperienceReport
    {
        public static ExcelPackage GenerateReport(ProfessionalExperienceReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("MedicalExamReport");

            var nextRow = AddHeader(worksheet, 1);

            AddContent(worksheet, nextRow, viewModel.report);

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            /*
            
            worksheet.Row(2).Height = 40;
            */
            worksheet.Row(1).Height = 30;
            return package;
        }

    

        private static int AddHeader(ExcelWorksheet ws, int row)
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
            ws.Cells[row, column].Value = StringConstants.Display.SUB_CONTRACT;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.ENTITY;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.PROFESSIONAL_EXPERIENCE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.PERIOD;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


            return row + 1;
        }


        private static void AddContent(ExcelWorksheet ws, int row, List<ProfessionalExperienceReportItemViewModel> report)
        {
            foreach (var item in report)
            {
                var column = 1;

                ws.Cells[row, column].Value = item.FullName;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                ws.Cells[row, column].Value = item.Workstation;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                ws.Cells[row, column].Value = item.Agency;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                ws.Cells[row, column].Value = item.Company;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                ws.Cells[row, column].Value = item.Experience;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++column;
                ws.Cells[row, column].Value = TimeUtil.GetYearsAndMonthsFromMonths(item.Months); 
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ++row;
            }
        }
    }
}
