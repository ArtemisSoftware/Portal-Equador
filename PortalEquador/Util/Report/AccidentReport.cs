using OfficeOpenXml.Style;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using PortalEquador.Domain.Report.ViewModels.Accident;
using PortalEquador.Domain.GroupTypes.ViewModels;

namespace PortalEquador.Util.Report
{
    public class AccidentReport
    {
        public static ExcelPackage GenerateReport(AccidentReportViewModel viewModel)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("AccidentReport");

            var nextRow = AddHeader(worksheet, viewModel.Causes.Count, viewModel.EstimatedValues.Count);
            nextRow = AddSubHeader(worksheet, nextRow, viewModel.Causes, viewModel.EstimatedValues);

            AddContent(
                worksheet, 
                nextRow, 
                viewModel.Report, viewModel.Causes, viewModel.EstimatedValues
             );

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            worksheet.Row(1).Height = 30;
            worksheet.Row(2).Height = 40;
            return package;
        }

        private static int AddHeader(ExcelWorksheet ws, int numberOfCauses, int numberOfLevels)
        {
            int row = 1;
            int column = 1;

            ws.Cells[row, column].Value = StringConstants.Display.NAME;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.DATE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.HOUR;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.CAUSES;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row, column + numberOfCauses].Merge = true;

            column = column + numberOfCauses + 1;
            ws.Cells[row, column].Value = StringConstants.Display.VALUE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row, column + numberOfLevels].Merge = true;

            column = column + numberOfLevels + 1;
            ws.Cells[row, column].Value = StringConstants.Display.HUMAN_DAMAGE;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            ++column;
            ws.Cells[row, column].Value = StringConstants.Display.ACCIDENT_LEVEL;
            ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[row, column, row + 1, column].Merge = true;

            return row + 1;
        }

        private static int AddSubHeader(ExcelWorksheet ws, int row, List<GroupItemViewModel> causes, List<GroupItemViewModel> estimatedValues)
        {
            int column = 4;

            foreach (var item in causes)
            {
                ws.Cells[row, column].Value = item.Description;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ++column;
            }

            foreach (var item in estimatedValues)
            {
                ws.Cells[row, column].Value = item.Description;
                ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ++column;
            }

            return row + 1;
        }


        private static void AddContent(ExcelWorksheet ws, int row, 
            List<AccidentReportItemViewModel> report, 
            List<GroupItemViewModel> causes, 
            List<GroupItemViewModel> estimatedValues
            )
        {
            foreach (var item in report)
            {
                var accidentIndex = 0;
                var levelIndex = 0;
                var column = 1;

                foreach (var accident in item.Accidents)
                {
                    ws.Cells[row, column].Value = item.FullName;
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ++column;
                    ws.Cells[row, column].Value = accident.Date.ToString(TimeUtil.dd_MM_yyyy);
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ++column;
                    ws.Cells[row, column].Value = accident.Date.ToString(TimeUtil.HH_mm);
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    for (int index = 0; index <= causes.Count; ++index)
                    {
                        if (accidentIndex < item.Accidents.Count && causes[index].Id == item.Accidents[accidentIndex].Id)
                        {
                            ws.Cells[row, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                            ++accidentIndex;
                        }
                        ++column;
                    }

                    for (int index = 0; index <= estimatedValues.Count; ++index)
                    {
                        if (estimatedValues[index].Id == accident.EstimatedValueId)
                        {
                            ws.Cells[row, column].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                            ++levelIndex;
                        }
                        ++column;
                    }

                    ws.Cells[row, column].Value = accident.HumanDamage;
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ++column;

                    ws.Cells[row, column].Value = accident.Level;
                    ws.Cells[row, column].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ++column;
                }

            }
        }
    }
}
