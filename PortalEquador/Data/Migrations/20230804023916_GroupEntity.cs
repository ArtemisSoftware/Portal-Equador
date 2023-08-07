using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class GroupEntity : Migration
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "375549e5-828e-4775-993b-0763347f1509");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "380608a2-c722-4c8c-a927-c559f672bcf1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5de1bc5d-4a6e-48eb-815c-fc10fb79650c", "AQAAAAEAACcQAAAAEG0AlWpTWwUFLcvuAePB6BCaAQ4/UlR8mJYhm2TnH2tSynb9tuNw4JGZpz13Hy7NrQ==", "a7a0caf2-d94b-4939-9724-d2a14591169d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "168e4c6e-9b8a-4f07-96a0-35b053d7819d", "AQAAAAEAACcQAAAAEH2+Am6P4QfRwNrxXz1N+J1H8O2n6EuZ839aLumCvMyC5YAggAJnHcyLrJh4tDDIrQ==", "8819a001-0a01-4f65-aa0c-8d32b15e7a53" });
        }
    }
}
