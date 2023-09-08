using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class personal_info_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInformationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
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
                    NationalityGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    ProvinceGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    Father = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherTongueId = table.Column<int>(type: "int", nullable: false),
                    MotherTongueGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: true),
                    AgencyGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    ApplicationGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_PersonalInformationEntity_GroupItemEntity_AgencyGroupEntityId",
                        column: x => x.AgencyGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_ApplicationGroupEntityId",
                        column: x => x.ApplicationGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_MaritalStatusGroupEntityId",
                        column: x => x.MaritalStatusGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_MotherTongueGroupEntityId",
                        column: x => x.MotherTongueGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NationalityGroupEntityId",
                        column: x => x.NationalityGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NeighbourhoodGroupEntityId",
                        column: x => x.NeighbourhoodGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_ProvinceGroupEntityId",
                        column: x => x.ProvinceGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "199825e7-8009-4580-b5fa-bf91e01fa868");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "a1119b10-72de-40ef-aaae-8b29851b810e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cdfa913-afb7-4d24-9813-e3ea7da03200", "AQAAAAEAACcQAAAAEPGPx87c6/fOxO3fLWcz6BZycv4zBu24NwbbWj5NFkanZ/t3yFtNB0TQPziNNX5YoA==", "261e8961-a447-4d3c-b159-21efbdb9db77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bef8955-b70a-4824-9418-4e98969a8089", "AQAAAAEAACcQAAAAEP5b4Ef9XhE8tJmpwqWKdU3sOd+0BiQBpNW3pY2yr2NqDi0BH5VAI4S2vZuo39yPUA==", "5c3c3c7f-1645-44cd-873d-e40e9d41b259" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_AgencyGroupEntityId",
                table: "PersonalInformationEntity",
                column: "AgencyGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_ApplicationGroupEntityId",
                table: "PersonalInformationEntity",
                column: "ApplicationGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_CurriculumId",
                table: "PersonalInformationEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity",
                column: "MaritalStatusGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MotherTongueGroupEntityId",
                table: "PersonalInformationEntity",
                column: "MotherTongueGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_NationalityGroupEntityId",
                table: "PersonalInformationEntity",
                column: "NationalityGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_NeighbourhoodGroupEntityId",
                table: "PersonalInformationEntity",
                column: "NeighbourhoodGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_ProvinceGroupEntityId",
                table: "PersonalInformationEntity",
                column: "ProvinceGroupEntityId");
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
                value: "e79370cf-1a0c-47aa-bc24-f6720bd3c909");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d5328f0a-fa38-49be-bc99-8efd5dfd8efd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6933f020-8b89-4f44-8a0e-0bdf7387e4f1", "AQAAAAEAACcQAAAAEBijNu3ZlZPONjwSjmKjQ6YFLmIlBLpYNCCi2Lbcp00FynSnfe7TJK/HR2PA320j6g==", "fcd0bdf6-8ad5-47f4-8da1-7a4ab3734adc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea1b83a0-653e-479a-a5a4-0778b5802d33", "AQAAAAEAACcQAAAAEEC54WrWYjj7WyiNAvW4QBm92EGzxxRnhr7FVZM0l/L4oZUl03bIno2b2U0kquq6ew==", "ed20a4a7-7e6f-48d0-8ec7-5985e84786d6" });
        }
    }
}
