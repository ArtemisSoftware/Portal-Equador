﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortalEquador.Data;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Id = "6d9ed3ff-bebb-42bc-ad07-0255bb0f7edb",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "7d9ed3ff-bebb-42bc-ad07-0255bb0f7edb",
                            Name = "Guest",
                            NormalizedName = "GUEST"
                        },
                        new
                        {
                            Id = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160",
                            Name = "Supervisor",
                            NormalizedName = "SUPERVISOR"
                        },
                        new
                        {
                            Id = "e9f639de-624f-4a4e-b8bf-2381725462f1",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f1"
                        },
                        new
                        {
                            UserId = "418aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "e9f639de-624f-4a4e-b8bf-2381725462f1"
                        },
                        new
                        {
                            UserId = "428aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160"
                        },
                        new
                        {
                            UserId = "438aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160"
                        },
                        new
                        {
                            UserId = "448aa945-3d84-4421-8342-7269ec64d949",
                            RoleId = "cc4fcb01-de88-4c20-b4ac-8df5c2a65160"
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

            modelBuilder.Entity("PortalEquador.Data.Curriculum.Entities.CurriculumEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EditorId");

                    b.ToTable("CurriculumEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.Document.Entity.DocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("EditorId");

                    b.HasIndex("PersonalInformationId");

                    b.ToTable("DocumentEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.Generic.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
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
                            ConcurrencyStamp = "b4d75cc8-733e-419d-96ce-6b2439cd5fd8",
                            Email = "adminEquador@teste.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEL5MxmoH3njdCPsvjMoJYCexYAkNH6h+jW1m7yaDtPUac8P014zQCIsqpptEYs49Mg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3377f834-23d5-4da9-ac2c-7cf7889e79e1",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = "418aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5afe026a-2ae0-454a-b994-8dc948fa7b2b",
                            Email = "aguiar@teste.com",
                            EmailConfirmed = true,
                            FirstName = "António",
                            LastName = "Aguiar",
                            LockoutEnabled = false,
                            NormalizedEmail = "AGUIAR@EQUADOR.COM",
                            NormalizedUserName = "AGUIAR@EQUADOR.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEMC3431HH4/fzvVG3frv4MlWs3RtVzUhCvM301pAzoPs6HuxdsOpftI/DMoZyapDw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dc4064b0-89d5-4aa5-bb82-80edf3310416",
                            TwoFactorEnabled = false,
                            UserName = "aguiar@equador.com"
                        },
                        new
                        {
                            Id = "428aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3add0d9d-fcab-4c7a-8a06-53e4635ec2a2",
                            Email = "dovictor@equador.com",
                            EmailConfirmed = true,
                            FirstName = "Domingos",
                            LastName = "Victor",
                            LockoutEnabled = false,
                            NormalizedEmail = "DOVICTOR@EQUADOR.COM",
                            NormalizedUserName = "DOVICTOR@EQUADOR.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEIM+hM7j8+B7sIu+VutMvNZUW3/DUprS6NKcayqd/tHospyhUceCD+PJzVc7WwWYMA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "501752f8-746d-4a30-8d58-6162f8ec293f",
                            TwoFactorEnabled = false,
                            UserName = "dovictor@equador.com"
                        },
                        new
                        {
                            Id = "438aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "996d1eba-be24-480f-b6f4-7f565567615c",
                            Email = "manioca@equador.com",
                            EmailConfirmed = true,
                            FirstName = "Mateus",
                            LastName = "Nioca",
                            LockoutEnabled = false,
                            NormalizedEmail = "MANIOCA@EQUADOR.COM",
                            NormalizedUserName = "MANIOCA@EQUADOR.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGFw/Dab6jnIz4ZuiSBebRGcEvJjjMVPG1rpJmMrwIL4ZPnC0mexIzdRP18HoBjbEw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ee35db5d-3ae2-4f72-bd0f-a43c987c1bae",
                            TwoFactorEnabled = false,
                            UserName = "manioca@equador.com"
                        },
                        new
                        {
                            Id = "448aa945-3d84-4421-8342-7269ec64d949",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "132bb42d-4ef2-4bd4-bd29-c1717eebf76d",
                            Email = "lumira@equador.com",
                            EmailConfirmed = true,
                            FirstName = "Luís",
                            LastName = "Mira",
                            LockoutEnabled = false,
                            NormalizedEmail = "LUMIRA@EQUADOR.COM",
                            NormalizedUserName = "LUMIRA@EQUADOR.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHG2louEr2kwekzTNSJStBpFM8OiNbRgqh/yKZUijkKTZWOUkZugA+CaISu1L8LpPw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "14641e2d-658b-45ab-9519-26add0694726",
                            TwoFactorEnabled = false,
                            UserName = "lumira@equador.com"
                        });
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.entities.GroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("EditorId");

                    b.ToTable("GroupEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GroupEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EditorId");

                    b.HasIndex("GroupEntityId");

                    b.ToTable("GroupItemEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity.MechanicalWorkshopSchedulerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InterventionTimeId")
                        .HasColumnType("int");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ScheduleDate")
                        .HasColumnType("date");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("EditorId");

                    b.HasIndex("InterventionTimeId");

                    b.HasIndex("MechanicId");

                    b.HasIndex("VehicleId");

                    b.ToTable("MechanicalWorkshopSchedulerEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity.MechanicalWorkshopVehicleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("EditorId");

                    b.ToTable("MechanicalWorkshopVehicleEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.PersonalInformation.Entity.PersonalInformationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("EditorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("EditorId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("MotherTongueId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("NeighbourhoodId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("PersonalInformationEntity");
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
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", null)
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

                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortalEquador.Data.Curriculum.Entities.CurriculumEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.Document.Entity.DocumentEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "DocumentTypeGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.PersonalInformation.Entity.PersonalInformationEntity", "PersonalInformationEntity")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserEntity");

                    b.Navigation("DocumentTypeGroupItemEntity");

                    b.Navigation("PersonalInformationEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.entities.GroupEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupEntity", "GroupEntity")
                        .WithMany()
                        .HasForeignKey("GroupEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserEntity");

                    b.Navigation("GroupEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.MechanicalWorkshop.Scheduler.Entity.MechanicalWorkshopSchedulerEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "ContractGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "InterventionTimeGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("InterventionTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "MechanicGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity.MechanicalWorkshopVehicleEntity", "VehicleEntity")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserEntity");

                    b.Navigation("ContractGroupItemEntity");

                    b.Navigation("InterventionTimeGroupItemEntity");

                    b.Navigation("MechanicGroupItemEntity");

                    b.Navigation("VehicleEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.MechanicalWorkshop.Vehicle.Entity.MechanicalWorkshopVehicleEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "ContractGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserEntity");

                    b.Navigation("ContractGroupItemEntity");
                });

            modelBuilder.Entity("PortalEquador.Data.PersonalInformation.Entity.PersonalInformationEntity", b =>
                {
                    b.HasOne("PortalEquador.Data.Generic.ApplicationUser", "ApplicationUserEntity")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "MaritalStatusIdGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId");

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "MotherTongueGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("MotherTongueId");

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "NationalityGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "NeighbourhoodGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("NeighbourhoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortalEquador.Data.GroupTypes.entities.GroupItemEntity", "ProvinceGroupItemEntity")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.Navigation("ApplicationUserEntity");

                    b.Navigation("MaritalStatusIdGroupItemEntity");

                    b.Navigation("MotherTongueGroupItemEntity");

                    b.Navigation("NationalityGroupItemEntity");

                    b.Navigation("NeighbourhoodGroupItemEntity");

                    b.Navigation("ProvinceGroupItemEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
