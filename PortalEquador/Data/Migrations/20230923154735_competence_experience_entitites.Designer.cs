﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalEquador.Data;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230923154735_competence_experience_entitites")]
    partial class competence_experience_entitites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                            ConcurrencyStamp = "7c5349a1-b4bc-48c5-b647-3d09fad87546",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                            ConcurrencyStamp = "ad94ebb8-f4a3-46e7-8a73-ce61b0729ab9",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf"
                        },
                        new
                        {
                            UserId = "3f4631bd-f907-4409-b416-ba356312e659",
                            RoleId = "cac43a7e-f7cb-4148-baaf-1acb431eabbf"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PortalEquador.Data.Document.Entities.DocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("PersonalInformationId");

                    b.ToTable("DocumentEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.DriversLicence.Entities.DriversLicenceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LicenceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProvisionalExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProvisionalRenewalNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicenceTypeId");

                    b.HasIndex("PersonalInformationId");

                    b.ToTable("DriversLicenceEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.Entities.GroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GroupEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupEntityId");

                    b.ToTable("GroupItemEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.PersonalInformation.Entities.PersonalInformationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeneficiaryNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IdentityCardExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("MotherTongueId")
                        .HasColumnType("int");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<int>("NeighbourhoodId")
                        .HasColumnType("int");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("MotherTongueId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("NeighbourhoodId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("PersonalInformationEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.ProfessionalCompetence.Entities.ProfessionalCompetenceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompetenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetenceId");

                    b.HasIndex("PersonalInformationId");

                    b.ToTable("ProfessionalCompetenceEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.ProfessionalExperience.Entities.ProfessionalExperienceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Months")
                        .HasColumnType("int");

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<int>("WorkstationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonalInformationId");

                    b.HasIndex("WorkstationId");

                    b.ToTable("ProfessionalExperienceEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "408aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f18ec516-285f-4b89-b9f5-c9ae8887d3d7",
                            DateJoined = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            Firstname = "System",
                            Lastname = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBhwemIcmOOJXeMMIfqbN0Sjmet8eMFQxUHiMeVjemXizu8RPD6ju5kDi5VvBS+B1Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "775f12a4-2a14-4fd3-98e8-2d4b0ab4b46b",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = "3f4631bd-f907-4409-b416-ba356312e659",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5498719f-986b-4f51-974e-b5ed2d2215d3",
                            DateJoined = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            Firstname = "System",
                            Lastname = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEAFagA0kcgKh5qpstiSEKPGZbHXbUIrOAbx1nmKOelyPMAeL+EsO9nFFB9Yqwr0MuQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7a922ea7-c87c-4eae-838e-192ac7d2bc00",
                            TwoFactorEnabled = false,
                            UserName = "user@localhost.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PortalEquador.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PortalEquador.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PortalEquador.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortalEquador.Data.Document.Entities.DocumentEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "DocumentTypeGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.PersonalInformation.Entities.PersonalInformationEntity", "PersonalInformationEntity")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentTypeGroupItemEntity");

                    b.Navigation("PersonalInformationEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.DriversLicence.Entities.DriversLicenceEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "LicenceTypeGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("LicenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.PersonalInformation.Entities.PersonalInformationEntity", "PersonalInformationEntity")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicenceTypeGroupItemEntity");

                    b.Navigation("PersonalInformationEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupEntity", "GroupEntity")
                        .WithMany()
                        .HasForeignKey("GroupEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.PersonalInformation.Entities.PersonalInformationEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "MaritalStatusIdGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId");

                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "MotherTongueGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("MotherTongueId");

                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "NationalityGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "NeighbourhoodGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("NeighbourhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "ProvinceGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.Navigation("MaritalStatusIdGroupItemEntity");

                    b.Navigation("MotherTongueGroupItemEntity");

                    b.Navigation("NationalityGroupItemEntity");

                    b.Navigation("NeighbourhoodGroupItemEntity");

                    b.Navigation("ProvinceGroupItemEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.ProfessionalCompetence.Entities.ProfessionalCompetenceEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "CompetenceGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.PersonalInformation.Entities.PersonalInformationEntity", "PersonalInformationEntity")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompetenceGroupItemEntity");

                    b.Navigation("PersonalInformationEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.ProfessionalExperience.Entities.ProfessionalExperienceEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "CompanyGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.PersonalInformation.Entities.PersonalInformationEntity", "PersonalInformationEntity")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.Entities.GroupItemEntity", "WorkstationGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("WorkstationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyGroupItemEntity");

                    b.Navigation("PersonalInformationEntity");

                    b.Navigation("WorkstationGroupItemEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
