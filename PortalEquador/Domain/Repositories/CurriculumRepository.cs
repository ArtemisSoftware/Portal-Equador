using PortalEquador.Contracts;
using PortalEquador.Data.CurriculumVitae.Entities;
using PortalEquador.Domain.Models.CurriculumVitae;

namespace PortalEquador.Domain.Repositories
{
    public interface CurriculumRepository : IGenericRepository<CurriculumEntity>
    {
        public Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int curriculumId);
    }
}
