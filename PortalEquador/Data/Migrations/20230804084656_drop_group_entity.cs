using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class drop_group_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                value: "d7475bc6-9de2-423d-8b3b-f17581f28f6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "bc356384-4bf2-444a-979f-1951c2dc9c42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f2703e6-4687-40fb-93c9-3e988b52967c", "AQAAAAEAACcQAAAAEBGRhvdLxdNNfrHbVXYxE97WFegMKbY3TBmKD7CnURt9yefbYX2kgJvkMe/Y2PWhzw==", "98f1c276-895d-49b6-bed3-4ec43c93bb35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b229e3-c800-4d1d-a9a7-bcb7d4d1fd77", "AQAAAAEAACcQAAAAEMzlmsQmr4/VzGNjHOXPb/94gZBFyekNTaeclmTbm/nmtZmbymzUuc973Eci5SoeLw==", "bf533b58-f86f-4e78-8eff-9b056cdbc84e" });
        }
    }
}
