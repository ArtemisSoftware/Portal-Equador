

using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using PortalEquador.Util.Constants;

namespace PortalEquador.Util.Report
{
    public static class ReportBuilderUtil
    {
        public static async Task<FileResult> GenerateExcel(ControllerBase controller, ExcelPackage package, string fileName)
        {
            var stream = new MemoryStream();
            await package.SaveAsAsync(stream);
            stream.Position = 0;
            return controller.File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", GetFileName(fileName));
        }


        private static string GetFileName(string fileName)
        {
            return fileName + "_ " + DateTime.Now.ToString() + ReportConstants.EXTENSION;
        }
    }
}
