using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
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
                 },
                new ApplicationUser
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
                },
                new ApplicationUser
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
                },
                new ApplicationUser
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
                },
                new ApplicationUser
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
                }
            );
        }
    }
}