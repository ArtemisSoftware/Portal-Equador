using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Curriculum.Entities;
using PortalEquador.Data.Generic;
using PortalEquador.Data.GroupTypes.entities;
using PortalEquador.Data.PersonalInformation.Entity;
using PortalEquador.Data.Document.Entity;
using PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity;

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
            
        }

        public DbSet<GroupEntity> GroupEntity { get; set; }
        public DbSet<GroupItemEntity> GroupItemEntity { get; set; }
        public DbSet<CurriculumEntity> CurriculumEntity { get; set; }
        public DbSet<PersonalInformationEntity> PersonalInformationEntity { get; set; }
        public DbSet<DocumentEntity> DocumentEntity { get; set; } 
        public DbSet<MechanicalWorkshopVehicleEntity> MechanicalWorkshopVehicleEntity { get; set; }
    }
}
