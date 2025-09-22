using PortalEquador.Domain.Contract.Repository;
using PortalEquador.Domain.Report.Repository;
using PortalEquador.Domain.Report.ViewModels.MedicalExam;
using PortalEquador.Domain.Report.ViewModels.Profession.Competence;

namespace PortalEquador.Domain.Report.UseCases
{
    public class GetProfessionalExperienceReportUseCase(
        IReportRepository reportRepository,
        IContractRepository contractRepository
        )
    {
        public async Task<ProfessionalExperienceReportViewModel> Invoke(int experienceId, int contractId)
        {
            List<int> accessibleContracts = await contractRepository.GetAccessibleContractsForUser(contractId);

            return await reportRepository.GetProfessionalExperienceReport(experienceId, accessibleContracts);
        }
    }
}