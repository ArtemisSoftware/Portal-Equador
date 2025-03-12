using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserSeedNewUsers2RoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

                 // Matos Fernandes
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1b2b3c4d-0002-4821-8342-7269ec64d949"
                 },
                 // Lazaro Júlio
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1b2b3c4d-0003-4821-8342-7269ec64d949"
                 },
                 // Armando Suca
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1b2b3c4d-0004-4821-8342-7269ec64d949"
                 },

                 // Paulo Neto
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1b2b3c4d-0008-4821-8342-7269ec64d949"
                 },

                 // Pina Machado
                 new IdentityUserRole<string>
                 {
                     RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                     UserId = "1b2b3c4d-0009-4821-8342-7269ec64d949"
                 }
            );
        }
    }
}