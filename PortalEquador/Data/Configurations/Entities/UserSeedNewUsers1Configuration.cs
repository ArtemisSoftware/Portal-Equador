using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserSeedNewUsers1Configuration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 //Manuel de Brito
                 new ApplicationUser 
                 {
                     Id = "1a2b3c4d-0002-4821-8342-7269ec64d949",
                     Email = "bmml@alngopco.com",
                     NormalizedEmail = "bmml@alngopco.com".ToUpper(),
                     NormalizedUserName = "bmml@alngopco.com".ToUpper(),
                     UserName = "bmml@alngopco.com",
                     PasswordHash = hasher.HashPassword(null, "Manuel123"),
                     EmailConfirmed = true,
                     FirstName = "Manuel",
                     LastName = "de Brito",
                 },

                 //Orlando Chico
                 new ApplicationUser
                 {
                     Id = "1a2b3c4d-0003-4821-8342-7269ec64d949",
                     Email = "orlando.equador@gmail.com",
                     NormalizedEmail = "orlando.equador@gmail.com".ToUpper(),
                     NormalizedUserName = "orlando.equador@gmail.com".ToUpper(),
                     UserName = "orlando.equador@gmail.com",
                     PasswordHash = hasher.HashPassword(null, "Orlando123"),
                     EmailConfirmed = true,
                     FirstName = "Orlando",
                     LastName = "Chico",
                 }

            );
        }
    }
}