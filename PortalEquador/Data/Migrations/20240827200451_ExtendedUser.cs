using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d9ed3ff-bebb-42bc-ad07-0255bb0f7edb", null, "Employee", "EMPLOYEE" },
                    { "7d9ed3ff-bebb-42bc-ad07-0255bb0f7edb", null, "Guest", "GUEST" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", null, "Supervisor", "SUPERVISOR" },
                    { "e9f639de-624f-4a4e-b8bf-2381725462f1", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "408aa945-3d84-4421-8342-7269ec64d949", 0, "b3afda94-c2c1-4e38-99e4-78f7498a01d3", "adminEquador@teste.com", true, "Admin", "", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELitZ+VLAuZsgYfLxO04YeCAiXuqzyAyMX5kErPSXwnVHtxFAoJdc1cc9HS03Y/pgA==", null, false, "b7556f15-4a03-4674-8050-7641ed50fc4c", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9f639de-624f-4a4e-b8bf-2381725462f1", "408aa945-3d84-4421-8342-7269ec64d949" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d9ed3ff-bebb-42bc-ad07-0255bb0f7edb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d9ed3ff-bebb-42bc-ad07-0255bb0f7edb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc4fcb01-de88-4c20-b4ac-8df5c2a65160");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9f639de-624f-4a4e-b8bf-2381725462f1", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9f639de-624f-4a4e-b8bf-2381725462f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
