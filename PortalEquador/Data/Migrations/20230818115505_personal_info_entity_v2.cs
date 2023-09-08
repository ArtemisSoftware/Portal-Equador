using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class personal_info_entity_v2 : Migration
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
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "bacfd098-b768-4178-a885-208fba5739af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "fbaa561f-4cb1-47b0-b544-6b6262526287");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6c87ac4-a313-4b7d-9fbb-ef1b29e93cf5", "AQAAAAEAACcQAAAAEMe0UzljmQpgfRR0P3YDHnbIW4RbVztxXQkO1e1O8qAehEMUUk9aouuc6Fch4uWAYA==", "b4cebbd5-99ef-4fa4-94b4-a1beb3f098aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "915cbdf0-0b96-48c7-96c6-d6a2a7a45866", "AQAAAAEAACcQAAAAEPoDtLq6bjhgMdtCOFqX13fPWhHCOTn9HFnr0mRUBfh1ktSiOZRdDZOPsWky8Q+skg==", "e574db8f-6720-4b04-b25d-1e8db4f137a0" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInformationEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "76d2a235-e76a-4293-a08f-f3d365614c99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "7c754e93-09aa-4478-8b41-47af77e18714");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "154fbfcd-c15d-41cb-afd4-9e9989d32ba0", "AQAAAAEAACcQAAAAEMkjX+5sX/UkxlTKOtT8Z6wRfJG5GNhagbt26JH2E7LFqnV+2meexmlmS1XqDTTyFg==", "47f16198-0f01-4796-b3da-7e3742f048c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e16a3ff-c993-44b9-836e-195901d87342", "AQAAAAEAACcQAAAAEP8BLYufNSMh6Ti420NcUeuo/g43TrolGRSADaGlE9QbTOB3oT9WuLSZHcxe/lxeHw==", "af44152f-d1e2-43a9-841a-19224e737c71" });
        }
    }
}
