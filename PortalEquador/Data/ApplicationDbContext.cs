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
using PortalEquador.Data.Configurations.Entities;

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



            //----------------------NOVA LISTA-------------------------


            //Lazáro Mazuela
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "1a2b3c4d-0001-4421-8342-7269ec64d949",
                Email = "supervisor.cvx@equador.co.ao",
                NormalizedEmail = "SUPERVISOR.CVX@EQUADOR.CO.AO",
                NormalizedUserName = "SUPERVISOR.CVX@EQUADOR.CO.AO",
                UserName = "supervisor.cvx@equador.co.ao",
                PasswordHash = hasher.HashPassword(null, "Mazuela123"),
                EmailConfirmed = true,
                FirstName = "Lazáro",
                LastName = "Mazuela",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "1a2b3c4d-0001-4421-8342-7269ec64d949"
            });



            //Benedito Joaquim
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "2a2b3c4d-0002-4421-8342-7269ec64d949",
                Email = "benedito.equador@gmail.com",
                NormalizedEmail = "BENEDITO.EQUADOR@GMAIL.COM",
                NormalizedUserName = "BENEDITO.EQUADOR@GMAIL.COM",
                UserName = "benedito.equador@gmail.com",
                PasswordHash = hasher.HashPassword(null, "Joaquim123"),
                EmailConfirmed = true,
                FirstName = "Benedito",
                LastName = "Joaquim",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "2a2b3c4d-0002-4421-8342-7269ec64d949"
            });

            //Pascoal José
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "3a2b3c4d-0003-4421-8342-7269ec64d949",
                Email = "pascoaljose79@gmail.com",
                NormalizedEmail = "PASCOALJOSE79@GMAIL.COM",
                NormalizedUserName = "PASCOALJOSE79@GMAIL.COM",
                UserName = "pascoaljose79@gmail.com",
                PasswordHash = hasher.HashPassword(null, "Jose123"),
                EmailConfirmed = true,
                FirstName = "Pascoal",
                LastName = "José",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "3a2b3c4d-0003-4421-8342-7269ec64d949"
            });

            //Manuel Lima
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "4a2b3c4d-0004-4421-8342-7269ec64d949",
                Email = "manuellima171@hotmail.com",
                NormalizedEmail = "MANUELLIMA171@HOTMAIL.COM",
                NormalizedUserName = "MANUELLIMA171@HOTMAIL.COM",
                UserName = "manuellima171@hotmail.com",
                PasswordHash = hasher.HashPassword(null, "Lima123"),
                EmailConfirmed = true,
                FirstName = "Manuel",
                LastName = "Lima",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "4a2b3c4d-0004-4421-8342-7269ec64d949"
            });

            //Gabriel Antonio
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "5a2b3c4d-0005-4421-8342-7269ec64d949",
                Email = "GANT@equinor.com",
                NormalizedEmail = "GANT@EQUINOR.COM",
                NormalizedUserName = "GANT@EQUINOR.COM",
                UserName = "GANT@equinor.com",
                PasswordHash = hasher.HashPassword(null, "Antonio123"),
                EmailConfirmed = true,
                FirstName = "Gabriel",
                LastName = "Antonio",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "5a2b3c4d-0005-4421-8342-7269ec64d949"
            });

            // Trindade Luis
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "6a2b3c4d-0006-4421-8342-7269ec64d949",
                Email = "Trindadeluis60@gmail.com",
                NormalizedEmail = "TRINDADELUIS60@GMAIL.COM",
                NormalizedUserName = "TRINDADELUIS60@GMAIL.COM",
                UserName = "Trindadeluis60@gmail.com",
                PasswordHash = hasher.HashPassword(null, "Luis123"),
                EmailConfirmed = true,
                FirstName = "Trindade",
                LastName = "Luis",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f2",
                UserId = "6a2b3c4d-0006-4421-8342-7269ec64d949"
            });

            //Almeida Inorio
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "7a2b3c4d-0007-4421-8342-7269ec64d949",
                Email = "fleetbp.one@equador.co.ao",
                NormalizedEmail = "FLEETBP.ONE@EQUADOR.CO.AO",
                NormalizedUserName = "FLEETBP.ONE@EQUADOR.CO.AO",
                UserName = "fleetbp.one@equador.co.ao",
                PasswordHash = hasher.HashPassword(null, "Inorio123"),
                EmailConfirmed = true,
                FirstName = "Almeida",
                LastName = "Inorio",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "7a2b3c4d-0007-4421-8342-7269ec64d949"
            });

            //Alfredo Matos
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "8a2b3c4d-0008-4421-8342-7269ec64d949",
                Email = "fleetbp.two@equador.co.ao",
                NormalizedEmail = "FLEETBP.TWO@EQUADOR.CO.AO",
                NormalizedUserName = "FLEETBP.TWO@EQUADOR.CO.AO",
                UserName = "fleetbp.two@equador.co.ao",
                PasswordHash = hasher.HashPassword(null, "Matos123"),
                EmailConfirmed = true,
                FirstName = "Alfredo",
                LastName = "Matos",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "8a2b3c4d-0008-4421-8342-7269ec64d949"
            });

            //Ilisio dos Santos
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "9a2b3c4d-0009-4421-8342-7269ec64d949",
                Email = "fleetbp.three@equador.co.ao",
                NormalizedEmail = "FLEETBP.THREE@EQUADOR.CO.AO",
                NormalizedUserName = "FLEETBP.THREE@EQUADOR.CO.AO",
                UserName = "fleetbp.three@equador.co.ao",
                PasswordHash = hasher.HashPassword(null, "Santos123"),
                EmailConfirmed = true,
                FirstName = "Ilisio",
                LastName = "dos Santos",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "9a2b3c4d-0009-4421-8342-7269ec64d949"
            });

            //Armando Suca
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "1b2b3c4d-0010-4421-8342-7269ec64d949",
                Email = "armandosuca@etuenergias.co.ao",
                NormalizedEmail = "ARMANDOSUCA@ETUENERGIAS.CO.AO",
                NormalizedUserName = "ARMANDOSUCA@ETUENERGIAS.CO.AO",
                UserName = "armandosuca@etuenergias.co.ao",
                PasswordHash = hasher.HashPassword(null, "Suca123"),
                EmailConfirmed = true,
                FirstName = "Armando",
                LastName = "Suca",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "1b2b3c4d-0010-4421-8342-7269ec64d949"
            });

            // João Magalhães
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "2b2b3c4d-0011-4421-8342-7269ec64d949",
                Email = "magalhaes.equador@gmail.com",
                NormalizedEmail = "MAGALHAES.EQUADOR@GMAIL.COM",
                NormalizedUserName = "MAGALHAES.EQUADOR@GMAIL.COM",
                UserName = "magalhaes.equador@gmail.com",
                PasswordHash = hasher.HashPassword(null, "Magalhaes123"),
                EmailConfirmed = true,
                FirstName = "João",
                LastName = "Magalhães",
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                UserId = "2b2b3c4d-0011-4421-8342-7269ec64d949"
            });
            //-----------------------------###----------------------------



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
