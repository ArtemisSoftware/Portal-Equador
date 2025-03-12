using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortalEquador.Data.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Protocol.Plugins;
using System.Net.NetworkInformation;

namespace PortalEquador.Data.Configurations.Entities
{
    public class UserSeedNewUsers2Configuration : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(

                // Matos Fernandes
                new ApplicationUser
                {
                    Id = "1b2b3c4d-0002-4821-8342-7269ec64d949",
                    Email = "matosequador@gmail.com",
                    NormalizedEmail = "MATOSEQUADOR@GMAIL.COM",
                    NormalizedUserName = "MATOSEQUADOR@GMAIL.COM",
                    UserName = "matosequador@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Matos123"),
                    EmailConfirmed = true,
                    FirstName = "Matos",
                    LastName = "Fernandes",
                },

                // Lazaro Júlio
                new ApplicationUser
                {
                    Id = "1b2b3c4d-0003-4821-8342-7269ec64d949",
                    Email = "lazaro.equador@gmail.com",
                    NormalizedEmail = "LAZARO.EQUADOR@GMAIL.COM",
                    NormalizedUserName = "LAZARO.EQUADOR@GMAIL.COM",
                    UserName = "lazaro.equador@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Lazaro123"),
                    EmailConfirmed = true,
                    FirstName = "Lazaro",
                    LastName = "Júlio",
                },

                // Armando Suca
                new ApplicationUser
                {
                    Id = "1b2b3c4d-0004-4821-8342-7269ec64d949",
                    Email = "Armando.suca@etunergia.co.ao",
                    NormalizedEmail = "ARMANDO.SUCA@ETUNERGIA.CO.AO",
                    NormalizedUserName = "ARMANDO.SUCA@ETUNERGIA.CO.AO",
                    UserName = "Armando.suca@etunergia.co.ao",
                    PasswordHash = hasher.HashPassword(null, "Armando123"),
                    EmailConfirmed = true,
                    FirstName = "Armando",
                    LastName = "Suca",
                },


                // Paulo Neto
                new ApplicationUser
                {
                    Id = "1b2b3c4d-0008-4821-8342-7269ec64d949",
                    Email = "pv.equador@gmail.com",
                    NormalizedEmail = "PV.EQUADOR@GMAIL.COM",
                    NormalizedUserName = "PV.EQUADOR@GMAIL.COM",
                    UserName = "pv.equador@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Paulo123"),
                    EmailConfirmed = true,
                    FirstName = "Paulo",
                    LastName = "Neto",
                },

                // Pina Machado
                new ApplicationUser
                {
                    Id = "1b2b3c4d-0009-4821-8342-7269ec64d949",
                    Email = "supervisor.geral@equador.co.ao",
                    NormalizedEmail = "supervisor.geral@equador.co.ao".ToUpper(),
                    NormalizedUserName = "supervisor.geral@equador.co.ao".ToUpper(),
                    UserName = "supervisor.geral@equador.co.ao",
                    PasswordHash = hasher.HashPassword(null, "Pina123"),
                    EmailConfirmed = true,
                    FirstName = "Pina",
                    LastName = "Machado",
                }

            );
        }
    }
}