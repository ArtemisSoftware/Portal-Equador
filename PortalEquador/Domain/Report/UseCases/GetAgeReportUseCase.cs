using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels.Age;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetAgeReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<AgeReportViewModel> Invoke(int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            return await reportRepository.GetAgeReport(accessibleContracts);
        }
    }
}