using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserSeedMWConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "1a2b3c4d-0001-4821-8342-7269ec64d949",
                     Email = "supervisor.cvx@equador.co.ao",
                     NormalizedEmail = "SUPERVISOR.CVX@EQUADOR.CO.AO",
                     NormalizedUserName = "SUPERVISOR.CVX@EQUADOR.CO.AO",
                     UserName = "supervisor.cvx@equador.co.ao",
                     PasswordHash = hasher.HashPassword(null, "Mazuela123"),
                     EmailConfirmed = true,
                     FirstName = "Lazáro",
                     LastName = "Mazuela",
                 }

            );
        }
    }
}