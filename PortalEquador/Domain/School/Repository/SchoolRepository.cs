using PortalEquador.Contracts;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Data.School.Entity;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
using PortalEquador.Domain.School.ViewModels;
using PortalEquador.Domain.University.ViewModels;

namespace PortalEquador.Domain.School.Repository
{
    public interface SchoolRepository : IGenericRepository<SchoolEntity>
    {
        Task Save(SchoolViewModel model);

        Task<SchoolViewModel> Get(int id);
    }
}
