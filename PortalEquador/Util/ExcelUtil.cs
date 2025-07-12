using Microsoft.AspNetCore.Mvc;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using System.Data;

namespace PortalEquador.Util
{
    public static class ExcelUtil
    {

        private static string GetFileName(string fileName)
        {
            return fileName + "_ " + DateTime.Now.ToString() +  ReportConstants.EXTENSION;
        }

        public static FileResult GenerateExcel(DataTable dataTable, string fileName)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                       GetFileName(fileName)
                       );
                }
            }

        }

    }
}
