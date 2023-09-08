using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class drivers_licence_entity_drop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversLicenceEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "0e29aeaa-ca4d-4331-b82f-7ed950e8e6b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "28fbc9e1-0201-4d1e-9990-be6d06212dce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9bee48b-a58b-4043-b6cb-e854daa60181", "AQAAAAEAACcQAAAAEFqY0Et5TAz1QWTVidmolp3Hs84hDCNIm74j5ZzdXsdphWAhp/ZOYjAuqE/kN3cERA==", "735c4777-33c7-4387-86d8-41c9e96b9f5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba57a282-9c5d-4d88-9c83-812d87209c8a", "AQAAAAEAACcQAAAAEPeJmW9rohMOOV9o55OtZ4b1DhmpjLHLFVdlt/TCUonxBwtw9ytP0upVu4pjkiiE0w==", "630492f5-3cd4-4ec0-a49d-74e91f1401ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_DriversLicenceEntity_GroupItemEntity_GroupItemId",
                        column: x => x.GroupItemId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_PersonalInformationEntity_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "c2256a7f-5665-415d-9cdc-c5a36d03cddd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "2a1d66ef-69a0-409a-8a88-d5cb0b6f9e36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c48a8c82-b46e-4a42-96b2-9f144da4b474", "AQAAAAEAACcQAAAAEGxYcdi2NlWNwhwU6nKdtShMQ4LHymeefQ6yLawj+hwCZ+Tgd+Do8vPl7qw2z0HfUg==", "25be4c9c-73ab-44bd-b7fb-bf1557c50aba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a20e2c41-f4db-4f17-b5ba-85f9051a3f42", "AQAAAAEAACcQAAAAEDyimAYc6M3rRjKzow+swAc1b6dK9QTArSj5MAxabmA47CwHA/lAbuipx0a761wVwQ==", "0b6dbb49-83d7-4a5d-9e2e-bfc35015cbc5" });

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_CurriculumId",
                table: "DriversLicenceEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_GroupItemId",
                table: "DriversLicenceEntity",
                column: "GroupItemId");
        }
    }
}
