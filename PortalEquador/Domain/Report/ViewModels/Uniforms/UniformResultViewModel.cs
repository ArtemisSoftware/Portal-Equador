using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Report.ViewModels.Uniforms
{
    public class UniformResultViewModel : ViewModel
    {
        public string FullName { get; set; }
        public string WorkStation { get; set; }
        public List<UniformItemResultViewModel> Uniforms { get; set; } = new List<UniformItemResultViewModel>();
    }
}
