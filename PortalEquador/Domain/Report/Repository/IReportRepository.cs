using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;

namespace PortalEquador.Domain.Report.Repository
{
    public interface IReportRepository
    {
        Task<AgeReportViewModel> GetAgeReport();

        Task<AlchoolTestViewModel> GetAlchoolTestForm();
        Task<AlchoolTestReportViewModel> GetAlchoolTestReport(DateTime date, List<int> accessibleContracts);
    }
}
