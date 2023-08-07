using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class group_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {


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
