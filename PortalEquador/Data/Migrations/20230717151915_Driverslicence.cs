using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class Driverslicence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "f7746062-0fcb-4433-8ee3-05a8a25315e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "49c85af2-28f1-4d38-89a0-9de2e353054a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a26e576-3058-4c67-ac87-383a591c5a17", "AQAAAAEAACcQAAAAEHvqmkAwMVmsSptV6W+QOGumFxFvNkqntEAysF+nc4/K7xwEFYmSYtxCUUf5fpfMMg==", "fc5b6947-a4a5-4665-b470-246460e47229" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f43fe6f5-1345-4327-a17d-76687f0687de", "AQAAAAEAACcQAAAAEOKB1FDeVDr+wHRQDrmGTjKydR59Y6/20Cw3JFzSFelwN5jIJvYutI+PbynDwdp4Xg==", "ec5df768-51ec-4553-987c-d9a1bf6cf80c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
