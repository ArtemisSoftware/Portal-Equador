using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class document_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_CurriculumId",
                table: "DocumentEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_GroupItemId",
                table: "DocumentEntity",
                column: "GroupItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntity");

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
        }
    }
}
