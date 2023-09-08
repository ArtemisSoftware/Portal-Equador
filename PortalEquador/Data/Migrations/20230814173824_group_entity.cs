using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class group_entity : Migration
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
                value: "c3baa55b-bf6a-4dc5-937e-055a0164034d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "8200dee9-3de6-4817-a8ac-df738b18fd6f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f4249f1-4883-445b-b423-04b6acb305b5", "AQAAAAEAACcQAAAAEMQe5n7jVnB7M2JG996KiPFQwYJxIuHGgS3RYcGZ9qwi6cNRDl6DClRtlr3Pn1ZkvQ==", "39405c31-054b-4142-8c20-4a7803182046" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba839b61-a046-4574-8d4e-0ed2d5487204", "AQAAAAEAACcQAAAAEFv+Lvi7z/WMDY6Ndwht4PhAKmc6ysOwVr/f+MlZ8AJjavEnJ45Za+0Nb/2gEwQPTg==", "e42e67ac-9198-4cae-b334-dcda5e06276c" });
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
    }
}
