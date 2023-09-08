using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class personal_info_drop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInformationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    NationalityGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodGroupEntityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceGroupEntityId = table.Column<int>(type: "int", nullable: false),
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
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NationalityGroupEntityId",
                        column: x => x.NationalityGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NeighbourhoodGroupEntityId",
                        column: x => x.NeighbourhoodGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_ProvinceGroupEntityId",
                        column: x => x.ProvinceGroupEntityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b10c9b9b-1ac7-486b-ac6c-8d436e5e3dc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "3af3e64e-5c24-4c93-a715-dd21a19662a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b58e6ab4-e1f5-46fe-ad7c-ed70979fffe9", "AQAAAAEAACcQAAAAEAgq5jXyRCpR6oeWyddasc1wxghR30BXHLKItDMiVLzWznomf/1x8bI35yRSFeH14Q==", "9a09e14e-619e-450b-8ff9-1c3648be53b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e31ffba-f4a8-477b-aa29-d5a0005a6e7f", "AQAAAAEAACcQAAAAEKiPpB87QEOJSl0gRM379DgqNXKXrxLfWsWkyphq8wEsWz37bbH2PnSIDPeZEYWvug==", "9dadcb50-5bb2-42c7-86ee-0b525a9a736a" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_CurriculumId",
                table: "PersonalInformationEntity",
                column: "CurriculumId");

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
    }
}
