using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class fix_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "5c935d52-812b-4893-9945-617e96b214f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "efee90f2-cfed-4734-be79-277cb9106e43");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51807797-2584-48a7-b93f-f8767e80438b", "AQAAAAEAACcQAAAAEK96AoKwY8azYAkNdgegYqT1030UC6hAYf4Py+fIzV5nMo4gV70mEZhEAIsfkke4TA==", "7fe14ea5-d1b0-4b22-8ba8-db3f53eb9e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a895ace-6859-4e88-a860-97aa881f7e5e", "AQAAAAEAACcQAAAAEKnVJ5B/f1+8KlNQripOoWgTQfh3+zSQcN9gtlICYYSSXILMc6HV0Cbmy64CUUjOfw==", "0d6f3447-47a2-4c29-b1b6-e7b0adfc5668" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
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
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupItems_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d0fd330b-f4d6-4317-8a69-952536a8248e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "b635a82d-7f88-40fe-a962-84eae8c52a4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a187f516-c3b9-4f40-a9a7-aaa68f5a8eb9", "AQAAAAEAACcQAAAAEOj8g1JHjuJlg0fFszu6IBbu8wDQxlijj4xQaJFaEeP6ku6t+Mt44B+lsCUAR+zzNw==", "f7e6ceb5-e522-4fde-b9fe-474aa83d9845" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7628a67a-22dd-4136-9760-fe842de43c5e", "AQAAAAEAACcQAAAAEEYorjcP9SSM47EySOtrWnT7f8JD22Bj4pJpsJV4H7Pi8xWy2hnWv0dN4WVIL+wm0g==", "2421219a-6e9f-4f7d-ae81-b9a2dc9d3c87" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupItems_GroupId",
                table: "GroupItems",
                column: "GroupId");
        }
    }
}
