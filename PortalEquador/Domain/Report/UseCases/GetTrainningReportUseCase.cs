using Microsoft.IdentityModel.Tokens;
using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Domain.Report.ViewModels.Trainning;
using PortalEquador.Util.Constants;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetTrainningReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<TrainningReportViewModel> Invoke(string year, int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            var result = await reportRepository.GetTrainningReport(Int32.Parse(year), accessibleContracts);
           
            return result;
        }
    }
}