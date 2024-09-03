using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class testUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4d75cc8-733e-419d-96ce-6b2439cd5fd8", "AQAAAAIAAYagAAAAEL5MxmoH3njdCPsvjMoJYCexYAkNH6h+jW1m7yaDtPUac8P014zQCIsqpptEYs49Mg==", "3377f834-23d5-4da9-ac2c-7cf7889e79e1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "418aa945-3d84-4421-8342-7269ec64d949", 0, "5afe026a-2ae0-454a-b994-8dc948fa7b2b", "aguiar@teste.com", true, "António", "Aguiar", false, null, "AGUIAR@EQUADOR.COM", "AGUIAR@EQUADOR.COM", "AQAAAAIAAYagAAAAEEMC3431HH4/fzvVG3frv4MlWs3RtVzUhCvM301pAzoPs6HuxdsOpftI/DMoZyapDw==", null, false, "dc4064b0-89d5-4aa5-bb82-80edf3310416", false, "aguiar@equador.com" },
                    { "428aa945-3d84-4421-8342-7269ec64d949", 0, "3add0d9d-fcab-4c7a-8a06-53e4635ec2a2", "dovictor@equador.com", true, "Domingos", "Victor", false, null, "DOVICTOR@EQUADOR.COM", "DOVICTOR@EQUADOR.COM", "AQAAAAIAAYagAAAAEIM+hM7j8+B7sIu+VutMvNZUW3/DUprS6NKcayqd/tHospyhUceCD+PJzVc7WwWYMA==", null, false, "501752f8-746d-4a30-8d58-6162f8ec293f", false, "dovictor@equador.com" },
                    { "438aa945-3d84-4421-8342-7269ec64d949", 0, "996d1eba-be24-480f-b6f4-7f565567615c", "manioca@equador.com", true, "Mateus", "Nioca", false, null, "MANIOCA@EQUADOR.COM", "MANIOCA@EQUADOR.COM", "AQAAAAIAAYagAAAAEGFw/Dab6jnIz4ZuiSBebRGcEvJjjMVPG1rpJmMrwIL4ZPnC0mexIzdRP18HoBjbEw==", null, false, "ee35db5d-3ae2-4f72-bd0f-a43c987c1bae", false, "manioca@equador.com" },
                    { "448aa945-3d84-4421-8342-7269ec64d949", 0, "132bb42d-4ef2-4bd4-bd29-c1717eebf76d", "lumira@equador.com", true, "Luís", "Mira", false, null, "LUMIRA@EQUADOR.COM", "LUMIRA@EQUADOR.COM", "AQAAAAIAAYagAAAAEHG2louEr2kwekzTNSJStBpFM8OiNbRgqh/yKZUijkKTZWOUkZugA+CaISu1L8LpPw==", null, false, "14641e2d-658b-45ab-9519-26add0694726", false, "lumira@equador.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e9f639de-624f-4a4e-b8bf-2381725462f1", "418aa945-3d84-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "428aa945-3d84-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "438aa945-3d84-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "448aa945-3d84-4421-8342-7269ec64d949" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9f639de-624f-4a4e-b8bf-2381725462f1", "418aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "428aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "438aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "448aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b25c31a4-66f2-4f86-b305-0f6d01a033f5", "AQAAAAIAAYagAAAAEFD6uj2OEyHmu25M1gj66qmfAvkhsjMlPqbXq5bH0iii8V358v7URJQWWu7lecUMlQ==", "98b56f8b-4376-47b4-bc70-a9734c711df1" });
        }
    }
}
