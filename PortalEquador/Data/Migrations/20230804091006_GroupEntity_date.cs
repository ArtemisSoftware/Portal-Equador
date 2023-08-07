using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class GroupEntity_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntity", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d2292219-9f04-4b4d-ab3b-62148c3138dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "b433b7ce-ad17-4fb8-80a6-74fb49e6acef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6efe9746-f4a1-4c0d-9d82-bd7c510e6ca0", "AQAAAAEAACcQAAAAEBKLO+EUw+6ac8JAf383P9MquutjNV/pfK3o/oWK9V6SGqr0lfHLbLBfl41PeMF/kQ==", "fa36fa04-4147-4e1e-8b48-cd4dcbe94306" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6548f4ac-9e6a-499f-91ab-252fbb2e65da", "AQAAAAEAACcQAAAAEADFLxR8pqnLH4lKjATwqo1vjPL4og6UYnU9ZXqfSNERjDJk4MEEOQSjQTLqqkFgoA==", "a4fcbb3f-4c24-44e6-9296-bec65a4817cf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "22ce457b-fc4d-4d7f-8a1b-f6be4603bd89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "7b3ba26b-aa6e-4773-addf-9eca9127dd3d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c16be9ee-d89f-40a2-b064-2d1fdca459c2", "AQAAAAEAACcQAAAAEBv0x5/XVqkWN5AqKrWHC5f937e76faI51qUOdSqEfKMksLMkGOH9UCJHgucST+cqg==", "6b6a9307-2283-43a1-99a4-03ba8b5d97d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51690d00-cb5e-4648-a719-68c64fa0a626", "AQAAAAEAACcQAAAAEMQGPnkbneSwgi0PQEc57Z+51Db0W67gq1/Zvgi4o52DpsFpvk+mjDd9GFz5J5JgOQ==", "10f09d2e-25f6-4270-968d-18add6c57420" });
        }
    }
}
