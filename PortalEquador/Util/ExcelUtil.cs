using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using PortalEquador.Util.Constants;
using System.Data;
using System.Drawing;

namespace PortalEquador.Util
{
    public static class ExcelUtil
    {
        public static Color DeepBlueHexCode = ColorTranslator.FromHtml("#254061");


        private static string GetFileName(string fileName)
        {
            return fileName + "_ " + DateTime.Now.ToString() +  ReportConstants.EXTENSION;
        }






        public static FileContentResult GenerateExcel(DataTable dataTable, string fileName)
        {
            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);

                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var content = stream.ToArray();

                    return new FileContentResult(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        FileDownloadName = GetFileName(fileName)
                    };
                }
            }
        }


        public static FileContentResult GenerateExcel(XLWorkbook wb, string fileName)
        {
            using (var stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                return new FileContentResult(
                    stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = GetFileName(fileName)
                };
            }
        }

    }
}
