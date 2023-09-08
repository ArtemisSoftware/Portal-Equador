using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class personal_info_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInformationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeneficiaryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherTongueId = table.Column<int>(type: "int", nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_MotherTongueId",
                        column: x => x.MotherTongueId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ffb23318-7ca6-4aab-abb6-2e0cbe6d7462");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d3e2bed0-5f68-4550-8c14-85186c245037");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e33fac22-af4a-4c6d-bb25-78dedce5a726", "AQAAAAEAACcQAAAAENuVi+glwpcN/D1xI7hdydYtMLytkmwXrvNHv1Xze/3pol0bveHudJVndYdEyMTRoA==", "5f506a59-672d-4074-aa12-93f416a01338" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a45edd-ef53-4b9b-a43b-73b3bfb2e01d", "AQAAAAEAACcQAAAAENMmVA9xyICTRmjMNYfLQbz+dIfQAC+zGV3yUeuvzLImpbZA3F5UXKPf2+4itlQmGw==", "37e23f82-1e60-40b3-98dc-d8bda179442b" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MaritalStatusId",
                table: "PersonalInformationEntity",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MotherTongueId",
                table: "PersonalInformationEntity",
                column: "MotherTongueId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_NationalityId",
                table: "PersonalInformationEntity",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_NeighbourhoodId",
                table: "PersonalInformationEntity",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_ProvinceId",
                table: "PersonalInformationEntity",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInformationEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "e3ff4eb5-ba1b-4932-8e12-95a6adef007b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "26646cf7-9a9a-4557-801c-bac38ae35422");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90f88ca8-1a72-4990-ae73-d98af5e3017c", "AQAAAAEAACcQAAAAEHrgTAv4e5csSZm0fcdSop7zv00PgjM97vismfJxZu0E3RcspdN5wppeEW9b0wUQpg==", "85018fb0-1100-425f-9d7a-07b88cd3862d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8811f2b6-0075-4aa0-b184-dc5c1d28e37a", "AQAAAAEAACcQAAAAEAnuYwyog1UeuV4YllwOK9oLQLhjbMXuIoBwbi4lgeyDytIhgQAXBgBERLkwiRVtlQ==", "c805507e-d629-4a3d-9b2d-2c2b34f41aec" });
        }
    }
}
