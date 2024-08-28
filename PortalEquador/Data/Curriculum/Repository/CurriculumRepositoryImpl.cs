using AutoMapper;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Domain.Curriculum.Repository;
using PortalEquador.Domain.Curriculum.ViewModels;
using PortalEquador.Domain.GroupTypes.Repository;

namespace PortalEquador.Data.Curriculum.Repository
{
    public class CurriculumRepositoryImpl(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : GenericRepository<CurriculumEntity>(context, httpContextAccessor), CurriculumRepository
    {
        public async Task<CurriculumDashboardViewModel> GetCurriculumDashboard(int curriculumId)
        {
            return new CurriculumDashboardViewModel { FullName = "Lopes"};
        }
    }
}
