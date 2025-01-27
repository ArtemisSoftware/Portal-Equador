using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                 new IdentityUserRole<string>
                 {
                     RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                     UserId = "408aa945-3d84-4421-8342-7269ec64d949"
                 },
                new IdentityUserRole<string>
                {
                    RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                    UserId = "418aa945-3d84-4421-8342-7269ec64d949"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    UserId = "428aa945-3d84-4421-8342-7269ec64d949"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    UserId = "438aa945-3d84-4421-8342-7269ec64d949"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    UserId = "448aa945-3d84-4421-8342-7269ec64d949"
                }
            );
        }
    }
}