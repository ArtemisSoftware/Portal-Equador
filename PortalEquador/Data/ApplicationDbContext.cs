using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Configurations.Entities;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes.Entities;

namespace PortalEquador.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<GroupEntity> GroupEntity { get; set; }
        public DbSet<GroupItemEntity> GroupItemEntity { get; set; }




        //public DbSet<CurriculumEntity> CurriculumEntity { get; set; }
        //public DbSet<PersonalInformationEntity> PersonalInformationEntity { get; set; }
        //public DbSet<DocumentEntity> DocumentEntity { get; set; }
        //public DbSet<DriversLicenceEntity> DriversLicenceEntity { get; set; }
    }
}