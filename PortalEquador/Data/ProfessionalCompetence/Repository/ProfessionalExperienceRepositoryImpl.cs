using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Domain.ProfessionalCompetence.Repository;
using PortalEquador.Repositories;

namespace PortalEquador.Data.ProfessionalCompetence.Repository
{
    public class ProfessionalCompetenceRepositoryImpl : GenericRepository<ProfessionalCompetenceEntity>, ProfessionalCompetenceRepository
    {
        public ProfessionalCompetenceRepositoryImpl(ApplicationDbContext context) : base(context)
        {
        }
    }
}
