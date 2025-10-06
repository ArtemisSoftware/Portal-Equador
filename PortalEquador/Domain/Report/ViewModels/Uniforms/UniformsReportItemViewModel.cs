using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Uniforms
{
    public class UniformsReportItemViewModel : ViewModel
    {
        public string FullName { get; set; }
        public string WorkStation { get; set; }
        public int UniformId { get; set; }
        public string Uniform { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public DateTime Date { get; set; }

    }
}
