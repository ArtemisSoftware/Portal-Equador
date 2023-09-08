using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class drivers_licence_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversLicenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalRenewalNumber = table.Column<int>(type: "int", nullable: true),
                    ProvisionalExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_GroupItemEntity_GroupItemId",
                        column: x => x.GroupItemId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversLicenceEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "04329a38-a6ab-4be3-a3c4-cdee5dd78244");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "cda683b5-f070-4252-bc47-da99cd92dd7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf1b1c45-d9fb-4475-8131-ffb7e0d6167d", "AQAAAAEAACcQAAAAEA66jVVV398zblrbpMA8tRx3R7BMpJDdz40k+DzLYMAicbUX3Gmz1K79IGnFpqI5CQ==", "7d4c6df3-c52f-44bd-8e14-7a02600bdfe0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fa86f0c-208c-42e7-8c93-f78798753ccd", "AQAAAAEAACcQAAAAEGdzfUHKuNxUuY1Uoa+ESFViti1PuGBUwf768CuhI5dVYLT0OvSE78NLh9ORb2U8VA==", "f1f2e547-bb4c-44ea-b289-1c032f2f6767" });
        }
    }
}
