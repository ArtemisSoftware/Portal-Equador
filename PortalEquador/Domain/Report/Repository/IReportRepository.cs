using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.Report.ViewModels;
using PortalEquador.Domain.Report.ViewModels.AlchoolTest;
using PortalEquador.Domain.Report.ViewModels.DriversLicence;

namespace PortalEquador.Domain.Report.Repository
{
    public interface IReportRepository
    {
        Task<AgeReportViewModel> GetAgeReport();

        Task<AlchoolTestViewModel> GetAlchoolTestForm();
        Task<AlchoolTestReportViewModel> GetAlchoolTestReport(string contractDescription, DateTime date, List<int> accessibleContracts);

        Task<DriversLicenceReportFormViewModel> GetDriversLicenceForm();
        Task<DriversLicenceReportViewModel> GetDriversLicenceReport(List<int> accessibleContracts);
    }
}
