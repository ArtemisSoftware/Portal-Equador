using PortalEquador.Contracts;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Domain.Models.DriversLicence;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Domain.Repositories
{
    public interface DriversLicenceRepository : IGenericRepository<DriversLicenceEntity>
    {
        public Task<List<DriversLicenceViewModel>> GetAllDriversLicenceAsync();

        public Task<DriversLicenceDetailViewModel?> GetDriversLicenceAsync(int curriculumId);
    }
}
