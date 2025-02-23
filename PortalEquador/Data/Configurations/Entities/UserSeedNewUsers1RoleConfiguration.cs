using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserSeedNewUsers1RoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                 //Manuel de Brito
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1a2b3c4d-0002-4821-8342-7269ec64d949"
                 },
                 //Orlando Chico
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1a2b3c4d-0003-4821-8342-7269ec64d949"
                 }
            );
        }
    }
}