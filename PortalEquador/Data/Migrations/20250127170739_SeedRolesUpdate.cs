using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9f639de-624f-4a4e-b8bf-2381725462f2", null, "DataManager", "DATAMANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f391ded-cae1-4c22-a378-8e44269478f9", "AQAAAAIAAYagAAAAEM3wCHo6e7dDC8GVHSJleIY5rA47p2HUPUCYlfEDsUKPNeWBEqYeKylCkYAm2nWhuQ==", "f9e32128-72ef-4cbb-8f97-4a172aa39567" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69207e7f-306b-4864-b6dd-db4d50eaef1a", "AQAAAAIAAYagAAAAEOr+x4beGY6Y1C2AsphgPxn+SXAWy53K3ioGbT76gjZEeWm4/0OeC9VWWuTqFiGATg==", "d06bd9c1-1609-4b18-a606-09637a58b6ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc110ee9-1e1a-4350-a5ce-2c3ff5df598b", "AQAAAAIAAYagAAAAEIeBdg1pakH7whja3A76neiYogHhtRwRoRW07I56ZhunZnRPW+IM10/SigFHJ1USqg==", "f3444bf5-db9f-4bbf-b8a9-ea1f08102167" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d493b58a-5e71-41fa-a0fe-cf82929a065a", "AQAAAAIAAYagAAAAEC1+ADfM/jkWHZodNOrmJdj0PkovOxf7+flKTgJOSIftq/fJtfaPQnWSlJb08gaqNQ==", "c2b50b1e-50a0-4b39-921e-3d098941511a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c821c460-393d-4822-9ea2-4b342c9ae2c0", "AQAAAAIAAYagAAAAEC0DETqCDZqJY9087+t8TTIUpOIyX8eX1muocereC8K4fTehVYxjKMnQqZ4gf8MkcA==", "3f3b3d71-7254-478f-b1e3-cdf044878cde" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9f639de-624f-4a4e-b8bf-2381725462f2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "135d8494-5f58-43a0-bce0-088637ba1f02", "AQAAAAIAAYagAAAAEKr9lvclKLflECAJh+Mut/Ygyss8Bpcvn0EjFCmFWlXzzszaISLg7FcCWUvtdqpTCA==", "321d011d-d531-4122-bb09-c761175e7525" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3112ac04-5214-45f9-9200-21ebfa2027a1", "AQAAAAIAAYagAAAAEDZ9i0dLGA+fiZdVUONTuZ+3vtjDLFVs6eAOWTXApY5JA8BmNCDgpLWSAKpKPzadiA==", "b86f7694-5aca-40a3-a107-cf46e77dd9a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e20b12-9c0f-4147-a50e-6d9f2a448b5c", "AQAAAAIAAYagAAAAEBeK9ki7mRrRYLnp6BYmAjmBf/ks0i/2E9+UzrAnNKcBs9ZW8fuZdBZUQE0uGVzzaA==", "fcdb0e30-9275-4e4b-ab2b-16bb5b42462b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34227aac-7cb1-4488-a106-c572a24a4ee0", "AQAAAAIAAYagAAAAEKDKchvwyuJDzFXLypx+MfzvhTwfk/4moA5YHiXy4ywk/f4QGyeEZ8jPwnpWH/xUPw==", "08eea890-30a0-4d57-ae4c-00f4aa9d2426" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bed9f16-b336-4104-a56f-3fbe3c3a6f63", "AQAAAAIAAYagAAAAELFyg+1T9iQ1l2j7pb21TB9OYHLbfPKOuyMlPX7nid48roIHLXuqY9F77sC2LJ84DQ==", "fe7a42fc-9bed-40a6-b673-2145daa1316b" });
        }
    }
}
