using Microsoft.IdentityModel.Tokens;
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
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            var description = await contractRepository.GetContractDescription(accessibleContracts);

            return await reportRepository.GetAlchoolTestReport(description, date, accessibleContracts);
        }
    }
}
