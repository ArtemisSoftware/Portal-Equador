using Microsoft.EntityFrameworkCore;
using PortalEquador.Contracts;
using PortalEquador.Data;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.GroupTypes;

namespace PortalEquador.Repositories
{
    public class PersonalInformationRepository : GenericRepository<PersonalInformation>, IPersonalInformationRepository
    {
        private readonly ApplicationDbContext context;
        public PersonalInformationRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> PersonalInformationExists(string identityCard)
        {
            return await context.PersonalInformation.AnyAsync(item => item.IdentityCard == identityCard);
        }

    }
}
