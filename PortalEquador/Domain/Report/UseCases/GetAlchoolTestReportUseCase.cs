using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.DisciplinaryNotification.Repository;
using PortalEquador.Domain.DisciplinaryNotification.ViewModels;
using PortalEquador.Domain.Document.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Util.Constants;
using static PortalEquador.Util.Constants.GroupTypesConstants;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetAlchoolTestReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<AlchoolTestReportViewModel> Invoke(DateTime date, int contractId)
        {
            List<int> accessibleContracts = new List<int>();

            if (contractId == StringConstants.Report.ALL_CONTRACTS_ID)
            {
                accessibleContracts = await contractRepository.GetAccessibleContractsForUser();
            }
            else
            {
                accessibleContracts.Add(contractId);
            }

            return await reportRepository.GetAlchoolTestReport(date, accessibleContracts);
        }
    }
}
