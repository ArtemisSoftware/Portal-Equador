using PortalEquador.Contracts;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Models.CurriculumVitae;

namespace PortalEquador.Domain.Repositories
{
    public interface DriversLicenceRepository : IGenericRepository<DriversLicenceEntity>
    {
        public Task<List<DriversLicenceEntity>> GetAllDriversLicenceAsync();
    }
}
