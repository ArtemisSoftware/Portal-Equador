using PortalEquador.Contracts;
using PortalEquador.Data.School.Entity;
using PortalEquador.Data.University.Entity;
using PortalEquador.Domain.ProfessionalExperience.ViewModels;
using PortalEquador.Domain.School.ViewModels;
using PortalEquador.Domain.University.ViewModels;

namespace PortalEquador.Domain.University.Repository
{
    public interface UniversityRepository : IGenericRepository<UniversityEntity>
    {
        Task Save(UniversityViewModel model);

        Task<UniversityViewModel> Get(int id);

        Task<List<UniversityDetailViewModel>> GetAll(int personalInformationId);
    }
}
