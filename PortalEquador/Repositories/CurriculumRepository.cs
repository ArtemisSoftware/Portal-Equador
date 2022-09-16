using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;

namespace PortalEquador.Repositories
{
    public class CurriculumRepository : GenericRepository<Curriculum>, ICurriculumRepository
    {
        private readonly ApplicationDbContext context;

        public CurriculumRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
