using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetMedicalExamReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<MedicalExamReportViewModel> Invoke(string year, int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            return await reportRepository.GetMedicalExamReport(Int32.Parse(year), accessibleContracts);
        }
    }
}