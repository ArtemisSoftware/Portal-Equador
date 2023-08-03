using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae.Entities;
using PortalEquador.Domain.CurriculumVitae.ViewModels;

namespace PortalEquador.Domain.CurriculumVitae.Repository
{
    public interface CurriculumRepository : IGenericRepository<CurriculumEntity>
    {
        public Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int curriculumId);
    }
}
