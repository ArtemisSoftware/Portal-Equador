using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class cv_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumEntity", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "e79370cf-1a0c-47aa-bc24-f6720bd3c909");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d5328f0a-fa38-49be-bc99-8efd5dfd8efd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6933f020-8b89-4f44-8a0e-0bdf7387e4f1", "AQAAAAEAACcQAAAAEBijNu3ZlZPONjwSjmKjQ6YFLmIlBLpYNCCi2Lbcp00FynSnfe7TJK/HR2PA320j6g==", "fcd0bdf6-8ad5-47f4-8da1-7a4ab3734adc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea1b83a0-653e-479a-a5a4-0778b5802d33", "AQAAAAEAACcQAAAAEEC54WrWYjj7WyiNAvW4QBm92EGzxxRnhr7FVZM0l/L4oZUl03bIno2b2U0kquq6ew==", "ed20a4a7-7e6f-48d0-8ec7-5985e84786d6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "895bcbcc-a40b-4cbb-a144-fc5616cb1f49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "16a2fa80-e3b4-4fc3-8643-504b37ebbe4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f85c1ff8-c1f6-4516-a69e-62e9fdcbfe58", "AQAAAAEAACcQAAAAEKFAqqBYnURGTaW9XEV+8KZuHNDoFeSKKxzc1VTS9lOfXaqYS9OJ0wlm5NTlij7iVQ==", "1269e552-bae3-443e-af36-d8c1d3c146f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a54cc856-8216-476a-acb2-e0ca87a516fd", "AQAAAAEAACcQAAAAELJ6z8kuXQoP1qqBx8S5NpkPN1aOblLT1IlYAScYNkHM8NeZmz2T2YziAGWCPTd7Fw==", "a7238dc4-5c80-4aaa-80f5-732d6f456930" });
        }
    }
}
