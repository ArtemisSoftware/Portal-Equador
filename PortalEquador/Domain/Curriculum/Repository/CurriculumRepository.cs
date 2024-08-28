using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Domain.Curriculum.ViewModels;
using PortalEquador.Domain.Generic;

namespace PortalEquador.Domain.Curriculum.Repository
{
    public interface CurriculumRepository : IGenericRepository<CurriculumEntity>
    {
        Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int curriculumId);
    }
}
