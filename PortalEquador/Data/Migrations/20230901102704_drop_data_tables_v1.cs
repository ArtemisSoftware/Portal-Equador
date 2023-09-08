using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class drop_data_tables_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntity");

            migrationBuilder.DropTable(
                name: "DriversLicenceEntity");

            migrationBuilder.DropTable(
                name: "PersonalInformationEntity");

            migrationBuilder.DropTable(
                name: "CurriculumEntity");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEntity_CurriculumEntity_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "CurriculumEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentEntity_GroupItemEntity_GroupItemId",
                        column: x => x.GroupItemId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriversLicenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalRenewalNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_CurriculumEntity_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "CurriculumEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_GroupItemEntity_GroupItemId",
                        column: x => x.GroupItemId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_CurriculumEntity_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "CurriculumEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "c49da581-15f4-45f7-8832-76b39c738469");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "6fcd26be-4d09-420e-978c-84722d899e17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf7a2d80-d58b-46a3-916d-3fcf24c80256", "AQAAAAEAACcQAAAAELmpx6okH2WXoXvG/duOetZLscgg7tKd14zdsiWLJWwEwQmXCtaBQWYXkYVEwC/7pQ==", "be276662-55ef-4eac-add9-46774134badc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76d52342-a9b3-4c90-aa00-4283bb4ac4e7", "AQAAAAEAACcQAAAAEKq7glz/g5FGzDefU9+AfFDSwb/u+nBo0+TUNYqDp+PQq3fUEwIhFWTNTFLoRBNf8w==", "606841d5-9e13-49c8-8d73-3f322cd68f0f" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_CurriculumId",
                table: "DocumentEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_GroupItemId",
                table: "DocumentEntity",
                column: "GroupItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_CurriculumId",
                table: "DriversLicenceEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_GroupItemId",
                table: "DriversLicenceEntity",
                column: "GroupItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_CurriculumId",
                table: "PersonalInformationEntity",
                column: "CurriculumId");

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
    }
}
