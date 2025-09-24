using PortalEquador.Domain.Generic;
using PortalEquador.Domain.Report.ViewModels.Trainning;
using PortalEquador.Domain.Uniforms.ViewModels;

namespace PortalEquador.Domain.Report.ViewModels.Uniforms
{
    public class UniformsReportViewModel : ViewModel
    {
        public List<UniformResultViewModel> report { get; set; } = new List<UniformResultViewModel>();
        public DateTime EmissionDate { get; set; } = DateTime.Now;

        public string FileName { get; set; } = "relatorio_uniformes";
        public List<UniformViewModel> Uniforms { get; set; } = new List<UniformViewModel>();
    }
}
