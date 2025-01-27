using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;
using PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity;
using PortalEquador.Data.Languages.entity;
using PortalEquador.Data.Profession.Competence.Entity;
using PortalEquador.Data.Profession.Experience.Entity;
using PortalEquador.Data.Education.School.Entity;
using PortalEquador.Data.Education.University.Entity;
using PortalEquador.Data.DriversLicence.Entity;
using PortalEquador.Data.MechanicalWorkshop.CarWash.Entity;
using PortalEquador.Data.MechanicalWorkshop.Admin.Entity;
using PortalEquador.Util;

namespace PortalEquador.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "6d9ed3ff-bebb-42bc-ad07-0255bb0f7edb",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "7d9ed3ff-bebb-42bc-ad07-0255bb0f7edb",
                    Name = "Guest",
                    NormalizedName = "GUEST"
                },
                new IdentityRole
                {
                    Id = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "e9f639de-624f-4a4e-b8bf-2381725462f2",
                    Name = "DataManager",
                    NormalizedName = "DATAMANAGER"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "408aa945-3d84-4421-8342-7269ec64d949",
                Email = "adminEquador@teste.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                PasswordHash = hasher.HashPassword(null, "Admin123"),
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                    UserId = "408aa945-3d84-4421-8342-7269ec64d949"
                });


            //António de Aguar
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "418aa945-3d84-4421-8342-7269ec64d949",
                Email = "aguiar@teste.com",
                NormalizedEmail = "AGUIAR@EQUADOR.COM",
                NormalizedUserName = "AGUIAR@EQUADOR.COM",
                UserName = "aguiar@equador.com",
                PasswordHash = hasher.HashPassword(null, "Aguiar123"),
                EmailConfirmed = true,
                FirstName = "António",
                LastName = "Aguiar",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                    UserId = "418aa945-3d84-4421-8342-7269ec64d949"
                });

            //Domingos Victor

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "428aa945-3d84-4421-8342-7269ec64d949",
                Email = "dovictor@equador.com",
                NormalizedEmail = "DOVICTOR@EQUADOR.COM",
                NormalizedUserName = "DOVICTOR@EQUADOR.COM",
                UserName = "dovictor@equador.com",
                PasswordHash = hasher.HashPassword(null, "Victor123"),
                EmailConfirmed = true,
                FirstName = "Domingos",
                LastName = "Victor",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    UserId = "428aa945-3d84-4421-8342-7269ec64d949"
                });

            //Mateus Nioca

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "438aa945-3d84-4421-8342-7269ec64d949",
                Email = "manioca@equador.com",
                NormalizedEmail = "MANIOCA@EQUADOR.COM",
                NormalizedUserName = "MANIOCA@EQUADOR.COM",
                UserName = "manioca@equador.com",
                PasswordHash = hasher.HashPassword(null, "Nioca123"),
                EmailConfirmed = true,
                FirstName = "Mateus",
                LastName = "Nioca",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    UserId = "438aa945-3d84-4421-8342-7269ec64d949"
                });

            //Sr.Luís Mira
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "448aa945-3d84-4421-8342-7269ec64d949",
                Email = "lumira@equador.com",
                NormalizedEmail = "LUMIRA@EQUADOR.COM",
                NormalizedUserName = "LUMIRA@EQUADOR.COM",
                UserName = "lumira@equador.com",
                PasswordHash = hasher.HashPassword(null, "Mira123"),
                EmailConfirmed = true,
                FirstName = "Luís",
                LastName = "Mira",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    UserId = "448aa945-3d84-4421-8342-7269ec64d949"
                });
        }

        public DbSet<GroupEntity> GroupEntity { get; set; }
        public DbSet<GroupItemEntity> GroupItemEntity { get; set; }
        public DbSet<CurriculumEntity> CurriculumEntity { get; set; }
        public DbSet<PersonalInformationEntity> PersonalInformationEntity { get; set; }
        public DbSet<DocumentEntity> DocumentEntity { get; set; } 
        public DbSet<MechanicalWorkshopVehicleEntity> MechanicalWorkshopVehicleEntity { get; set; }
        public DbSet<MechanicalWorkshopSchedulerEntity> MechanicalWorkshopSchedulerEntity { get; set; } = default!;
        public DbSet<LanguageEntity> LanguageEntity { get; set; } = default!;
        public DbSet<ProfessionalCompetenceEntity> ProfessionalCompetenceEntity { get; set; } = default!;
        public DbSet<ProfessionalExperienceEntity> ProfessionalExperienceEntity { get; set; } = default!;
        public DbSet<SchoolEntity> SchoolEntity { get; set; } = default!;
        public DbSet<UniversityEntity> UniversityEntity { get; set; } = default!;
        public DbSet<DriversLicenceEntity> DriversLicenceEntity { get; set; } = default!;
        public DbSet<CarWashSchedulerEntity> CarWashSchedulerEntity { get; set; }
        public DbSet<AdminMechanicalWorkShopContractEntity> AdminMechanicalWorkShopContractEntity { get; set; } = default!;
    }
}
