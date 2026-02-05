using PortalEquador.Data.Generic;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels.Accident;
using PortalEquador.Domain.Report.ViewModels.Uniforms;
using PortalEquador.Domain.Uniforms.Repository;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetUniformsReportFormUseCase(
        IReportRepository reportRepository,
        IUniformRepository uniformRepository
        )
    {
        public async Task<UniformsReportFormViewModel> Invoke()
        {
            var model = await reportRepository.GetUniformsForm();

            var uniforms = uniformRepository.GetUniforms(
                OrderType.Alphabetic,
                StringConstants.Report.ALL_UNIFORMS, 
                true
                );

            model.Uniforms = uniforms;
            return model;
        }
    }
}
