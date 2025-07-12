using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using System.Data;

namespace PortalEquador.Util
{
    public static class ReportUtil
    {
        public static DataTable GenerateExcel(AgeReportViewModel viewModel)
        {
            DataTable dataTable = new DataTable("People");

            dataTable.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn(StringConstants.Report.AGE),
                    new DataColumn(StringConstants.Display.EMISSION),
                    new DataColumn(viewModel.EmissionDate.ToString()),
                }
             );

            dataTable.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn(StringConstants.Display.NAME),
                    new DataColumn(StringConstants.Display.DATE_OF_BIRTH),
                    new DataColumn(StringConstants.Display.AGE),
                    new DataColumn(StringConstants.Display.CURRENT_WORKSTATION_IN_CONTRACT),
                }
             );

            foreach (var item in viewModel.report)
            {
                dataTable.Rows.Add(
                    item.FullName,
                    item.DateOfBirth.ToString(),
                    item.Age(),
                    item.WorkStation
                 );
            }

            return dataTable;
        }
    }
}
