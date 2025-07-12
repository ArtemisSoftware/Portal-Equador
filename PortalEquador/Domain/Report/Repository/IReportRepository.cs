using PortalEquador.Domain.MechanicalWorkshop.CarWash.ViewModels;
using PortalEquador.Domain.Report.ViewModels;

namespace PortalEquador.Domain.Report.Repository
{
    public interface IReportRepository
    {
        Task<AgeReportViewModel> GetAgeReport();
    }
}
