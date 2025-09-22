using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetDriversLicenceReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<DriversLicenceReportViewModel> Invoke(int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            return await reportRepository.GetDriversLicenceReport(accessibleContracts);
        }
    }
}