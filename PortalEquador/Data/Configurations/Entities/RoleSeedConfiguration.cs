using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Util;

namespace PortalEquador.Data.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "6d9ed3ff-bebb-42bc-ad07-0255bb0f7edb",
                    Name = Roles.Employee,
                    NormalizedName = Roles.Employee.ToUpper()
                },
                new IdentityRole
                {
                    Id = "7d9ed3ff-bebb-42bc-ad07-0255bb0f7edb",
                    Name = Roles.Guest,
                    NormalizedName = Roles.Guest.ToUpper()
                },
                new IdentityRole
                {
                    Id = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                    Name = Roles.Supervisor,
                    NormalizedName = Roles.Supervisor.ToUpper()
                },
                new IdentityRole
                {
                    Id = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "e9f639de-624f-4a4e-b8bf-2381725462f2",
                    Name = Roles.DataManager,
                    NormalizedName = Roles.DataManager.ToUpper()
                }
            );
        }
    }
}
