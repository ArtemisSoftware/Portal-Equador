using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Configurations.Entities;
using PortalEquador.Data.CurriculumVitae;
using PortalEquador.Data.CurriculumVitae.Entities;
using PortalEquador.Data.Document.Entities;
using PortalEquador.Data.DriversLicence.Entities;
using PortalEquador.Data.GroupTypes.Entities;
using PortalEquador.Data.PersonalInformation.Entities;
using PortalEquador.Data.ProfessionalCompetence.Entities;
using PortalEquador.Data.ProfessionalExperience.Entities;
using PortalEquador.Data.School.Entity;
using PortalEquador.Data.University.Entity;

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

        public DbSet<PersonalInformationEntity> PersonalInformationEntity { get; set; }

        public DbSet<DocumentEntity> DocumentEntity { get; set; }

        public DbSet<DriversLicenceEntity> DriversLicenceEntity { get; set; }

        public DbSet<ProfessionalExperienceEntity> ProfessionalExperienceEntity { get; set; }

        public DbSet<ProfessionalCompetenceEntity> ProfessionalCompetenceEntity { get; set; }

        public DbSet<SchoolEntity> SchoolEntity { get; set; }

        public DbSet<UniversityEntity> UniversityEntity { get; set; }

    }
}