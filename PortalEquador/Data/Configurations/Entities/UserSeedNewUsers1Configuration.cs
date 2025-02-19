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
                 new ApplicationUser
                 {
                     Id = "1a2b3c4d-0002-4821-8342-7269ec64d949",
                     Email = "supervisor.cvx@equador.co.ao",
                     NormalizedEmail = "SUPERVISOR.CVX@EQUADOR.CO.AO",
                     NormalizedUserName = "SUPERVISOR.CVX@EQUADOR.CO.AO",
                     UserName = "supervisor.cvx@equador.co.ao",
                     PasswordHash = hasher.HashPassword(null, "Manuel123"),
                     EmailConfirmed = true,
                     FirstName = "Manuel",
                     LastName = " de Brito",
                 }

            );
        }
    }
}