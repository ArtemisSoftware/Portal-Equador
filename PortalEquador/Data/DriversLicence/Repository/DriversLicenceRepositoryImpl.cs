using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes;
using PortalEquador.Domain.Repositories;
using PortalEquador.Repositories;

namespace PortalEquador.Data.DriversLicence.Repository
{
    public class DriversLicenceRepositoryImpl : GenericRepository<DriversLicenceEntity>, DriversLicenceRepository
    {
        private readonly ApplicationDbContext context;

        public DriversLicenceRepositoryImpl(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<DriversLicenceEntity>> GetAllDriversLicenceAsync()
        {
            return await context.DriversLicenceEntity
                .Include(item => item.GroupItemId).ToListAsync();
        }

    }
}
