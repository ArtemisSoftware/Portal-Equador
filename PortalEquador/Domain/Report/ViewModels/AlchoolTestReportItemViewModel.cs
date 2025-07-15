using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels
{
    public class AlchoolTestReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }

        public string FileName { get; set; } = "relatorio_testes_de_alcool";
    }
}
