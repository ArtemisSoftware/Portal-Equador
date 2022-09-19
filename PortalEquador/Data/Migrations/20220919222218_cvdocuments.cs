using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class cvdocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_GroupItems_GroupItemId",
                        column: x => x.GroupItemId,
                        principalTable: "GroupItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_PersonalInformation_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "43b5b2b3-c3fb-4a4b-87c7-d5b8f3696444");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "856c8937-dddd-4860-b61b-223f15d7f0b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc57b8c-a761-4f25-886b-11bcec71e254", "AQAAAAEAACcQAAAAELfWbXmoIaZwbcXRQMj7h8535fu4AVzJaHbmLHcn0SPXmtBD8CqXelIJMMoxzaOzFA==", "c4979382-dc31-4192-9188-cc0fe0f90945" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf30c5d2-71c8-49fb-accc-8e0e766bca05", "AQAAAAEAACcQAAAAEMh48wqOCI5/QY1zTOZObGTceKCYpgEb5A1X0C0PefH+1HUDutiwW8Wg8nNSLrt93A==", "4389d46b-aa9b-4f66-bde5-3340b85f3ec0" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CurriculumId",
                table: "Documents",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_GroupItemId",
                table: "Documents",
                column: "GroupItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "9378a485-a79a-43ab-8a95-4c74aba45946");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "0addfa6b-81cc-4c8c-91ab-7a7714c321cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9193ca69-ed73-4fea-a2fe-b2aad8e23f3d", "AQAAAAEAACcQAAAAEHmukXLEO60NXGLkt85jwr5vK6WOins5sWTdoZsNGvlXWiyw6c637bD9D6rW15W1wQ==", "eacff36c-e98f-4d88-bb52-035bde4e5f14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13056ba1-7562-4c6c-8c71-f33e0b460a66", "AQAAAAEAACcQAAAAEIqhydTbpqv9jOGuU+8JUU+PVGuAYb05lU4jrd8SDseaOHey1n1EG3e+Y9gUYkX72A==", "7264dd51-0c15-4022-9fd3-183bce2486ea" });
        }
    }
}
