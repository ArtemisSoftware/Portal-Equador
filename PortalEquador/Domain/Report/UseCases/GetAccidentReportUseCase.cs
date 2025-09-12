using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.Accident;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetAccidentReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<AccidentReportViewModel> Invoke(int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            var description = await contractRepository.GetContractDescription(accessibleContracts);

            return await reportRepository.GetAccidentReport(description, accessibleContracts);
        }
    }
}
