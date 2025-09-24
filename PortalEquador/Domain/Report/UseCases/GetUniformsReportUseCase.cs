using PortalEquador.Data.Generic;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels.Accident;
using PortalEquador.Domain.Report.ViewModels.Uniforms;
using PortalEquador.Domain.Uniforms.Repository;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetUniformsReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository,
        IUniformRepository uniformRepository
        )
    {
        public async Task<UniformsReportViewModel> Invoke(int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            var description = await contractRepository.GetContractDescription(accessibleContracts);

            var uniforms = await uniformRepository.GetAllUniforms(OrderType.Alphabetic);

            var result = await reportRepository.GetUniformsReport(description, accessibleContracts);

            result.Uniforms = uniforms;
            return result;
        }
    }
}
