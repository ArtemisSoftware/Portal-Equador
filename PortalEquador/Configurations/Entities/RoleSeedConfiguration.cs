﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalEquador.Constants;
using System.Data;

namespace PortalEquador.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        void IEntityTypeConfiguration<IdentityRole>.Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(

                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                }

            );
        }
    }
}