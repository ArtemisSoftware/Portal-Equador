using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a98bc73-361f-4348-ac8e-188021285cc4", "AQAAAAIAAYagAAAAEDCJ8x+BofjoOhk+iI0SrMTmVYnRXMDuovzxG9ZxQ0LN0e0jUtBN/Rs0Tze8XX9WIA==", "fa1f4f6d-6a74-432b-93b4-89b4ebc5300b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64f2420e-e7c3-45b6-af4f-7930fb873660", "AQAAAAIAAYagAAAAEL37juexJPvgYVqSqrZPAfCx0SovWUpq2DibAdmfmwuu0Licoy1cfkxVqmOWydhzgg==", "b4de6d75-bc0d-4b49-a0af-15811586a753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4fb637b-90f5-44d5-a55b-a5d3b4976554", "AQAAAAIAAYagAAAAEC7z/z/s/tbQahJ1xqz8b/w0G5Vw8cqBM15Xs6ALRj75Dpmyzg9xpkAq4v88FFyhsA==", "0b8c61d7-1924-48d5-a7c5-9193049e585a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddb0805e-d253-4db3-83ee-b4e16b18a13b", "AQAAAAIAAYagAAAAEBZrJ3UQyLx9WKQyOO5WItUgRexQBwigPxDoos2nZSxV80AGyyCRMMXyOC0Yey7E/A==", "6e670717-8209-432b-955d-bcd20722828b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "351b7664-ab42-419d-9e33-308269eabdde", "AQAAAAIAAYagAAAAEJT4I6M3MhQhbLpEETST5fUNe+BATAnw781rbBqgRIbg4s/CLJwOwLH4YV534M2ArQ==", "e71d959d-ee3c-445c-9aa5-e28d3dc8d58b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a2b3c4d-0001-4421-8342-7269ec64d949", 0, "05916715-8356-44fb-845c-b1d8993ac227", "supervisor.cvx@equador.co.ao", true, "Lazáro", "Mazuela", false, null, "SUPERVISOR.CVX@EQUADOR.CO.AO", "SUPERVISOR.CVX@EQUADOR.CO.AO", "AQAAAAIAAYagAAAAEMUzEwF/cGNYLj77y547lOSVB6K08+xb11FFRVTAvmRT+/fZoX8fjTHEOHPNE9BeQA==", null, false, "15fe569a-d501-4492-ae7a-b580f3f3ac9b", false, "supervisor.cvx@equador.co.ao" },
                    { "1b2b3c4d-0010-4421-8342-7269ec64d949", 0, "001defb8-fe65-44f2-a9aa-22e437b1e69d", "armandosuca@etuenergias.co.ao", true, "Armando", "Suca", false, null, "ARMANDOSUCA@ETUENERGIAS.CO.AO", "ARMANDOSUCA@ETUENERGIAS.CO.AO", "AQAAAAIAAYagAAAAEOyK78rCsbD+3KwCCRpiEZXe2sGpuB9KTSJd/D7MyAYFVFkPikQee2X4rGe3JEeNVg==", null, false, "5a52e7b1-52f4-494f-8d8a-8e5111666881", false, "armandosuca@etuenergias.co.ao" },
                    { "2a2b3c4d-0002-4421-8342-7269ec64d949", 0, "36d97d25-b18d-407c-9a21-78a361077f45", "benedito.equador@gmail.com", true, "Benedito", "Joaquim", false, null, "BENEDITO.EQUADOR@GMAIL.COM", "BENEDITO.EQUADOR@GMAIL.COM", "AQAAAAIAAYagAAAAEKN41oqaSka//Q+wY5qP7X5fbw4DKps3MqQVOAbpOAfdZ0wW2Lt72BhA67J3OzBWbA==", null, false, "86b26ee8-395e-414c-a60a-ae2211a0dd43", false, "benedito.equador@gmail.com" },
                    { "2b2b3c4d-0011-4421-8342-7269ec64d949", 0, "8d7afcc4-3466-42e3-9a29-c2ed345cb83d", "magalhaes.equador@gmail.com", true, "João", "Magalhães", false, null, "MAGALHAES.EQUADOR@GMAIL.COM", "MAGALHAES.EQUADOR@GMAIL.COM", "AQAAAAIAAYagAAAAEHEtX1NWPcw25ub6d4sBK5McHICaEBou2N8K5jXYvD7UbKGsvKngRYSeIn2ta7vB+w==", null, false, "31e667d8-b9eb-4829-9e26-8337a437f77f", false, "magalhaes.equador@gmail.com" },
                    { "3a2b3c4d-0003-4421-8342-7269ec64d949", 0, "03025b15-f5b6-4615-abf6-da95a63c26f5", "pascoaljose79@gmail.com", true, "Pascoal", "José", false, null, "PASCOALJOSE79@GMAIL.COM", "PASCOALJOSE79@GMAIL.COM", "AQAAAAIAAYagAAAAEODBsQ/x5OX+OZUtOeUp3iVaRfQnrcQcQnAurXfP0oVgsoqMdZZlgvFKCgPIzifJFA==", null, false, "7219adfb-f1fa-4b57-9f9b-cb17c1757089", false, "pascoaljose79@gmail.com" },
                    { "4a2b3c4d-0004-4421-8342-7269ec64d949", 0, "a2e31afb-e29e-4cb1-a994-53eeb75db6ba", "manuellima171@hotmail.com", true, "Manuel", "Lima", false, null, "MANUELLIMA171@HOTMAIL.COM", "MANUELLIMA171@HOTMAIL.COM", "AQAAAAIAAYagAAAAEGFkx5gXr4Pgs9h9rVz3F9N91wkB4QKWAmTfyZH6reVhp5eMcwVP++jwP45HicZwcw==", null, false, "0534e9de-5f88-44a6-afe6-1a51c07e7534", false, "manuellima171@hotmail.com" },
                    { "5a2b3c4d-0005-4421-8342-7269ec64d949", 0, "f3a8e0ed-018d-4f3a-9f9d-92289e3fed89", "GANT@equinor.com", true, "Gabriel", "Antonio", false, null, "GANT@EQUINOR.COM", "GANT@EQUINOR.COM", "AQAAAAIAAYagAAAAEDO/VcWdAMbcismrTJmnwh1TLOKtQJJSEykkYaCN9s8CN1jZbmhyepQhp+Gpb+V/Ew==", null, false, "2f247b23-9b82-452b-b58a-b62c61ba7edb", false, "GANT@equinor.com" },
                    { "6a2b3c4d-0006-4421-8342-7269ec64d949", 0, "01cb462d-51e7-4038-bb73-7717c0d1f013", "Trindadeluis60@gmail.com", true, "Trindade", "Luis", false, null, "TRINDADELUIS60@GMAIL.COM", "TRINDADELUIS60@GMAIL.COM", "AQAAAAIAAYagAAAAEOObsE84Ac+SE1YVScxixUN9pXt/0copH7tPjToY1RJS1YHZz84IqATCgkFx9Z38ww==", null, false, "ff2e35a2-3acc-4377-8942-1a53a04c9aa0", false, "Trindadeluis60@gmail.com" },
                    { "7a2b3c4d-0007-4421-8342-7269ec64d949", 0, "7867621b-a75d-4431-9b94-41d2486aa2e2", "fleetbp.one@equador.co.ao", true, "Almeida", "Inorio", false, null, "FLEETBP.ONE@EQUADOR.CO.AO", "FLEETBP.ONE@EQUADOR.CO.AO", "AQAAAAIAAYagAAAAEMS/dCsxQBylx+DvzoYS09lxs4XWYty0JEnIZWY4U49weX/wN38bMklS91aTXjDsLg==", null, false, "805f98b0-cdf0-46b7-82ca-548edfa8c932", false, "fleetbp.one@equador.co.ao" },
                    { "8a2b3c4d-0008-4421-8342-7269ec64d949", 0, "c83d1ce4-813f-4f00-898f-0ca767026e5d", "fleetbp.two@equador.co.ao", true, "Alfredo", "Matos", false, null, "FLEETBP.TWO@EQUADOR.CO.AO", "FLEETBP.TWO@EQUADOR.CO.AO", "AQAAAAIAAYagAAAAEBQoi+ZqfFLTTNaj7cuLUlpy0xe9LvB2CXpUEf05FHNfvmC0udrqNbMAFTTyeRvtgA==", null, false, "733fc68a-e2fb-4c64-aeca-09e49d82b7dd", false, "fleetbp.two@equador.co.ao" },
                    { "9a2b3c4d-0009-4421-8342-7269ec64d949", 0, "a8155cbc-0dd5-4238-89da-fc4faa41e24e", "fleetbp.three@equador.co.ao", true, "Ilisio", "dos Santos", false, null, "FLEETBP.THREE@EQUADOR.CO.AO", "FLEETBP.THREE@EQUADOR.CO.AO", "AQAAAAIAAYagAAAAEITKps5ScauCdiMkBMShDS5S4+kUX5sD/fWK66clmXf+14pJI+z7qPn4Im6qaqOu8w==", null, false, "7998768c-c54b-4c54-b03c-e2cc5c1bd558", false, "fleetbp.three@equador.co.ao" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1a2b3c4d-0001-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1b2b3c4d-0010-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "2a2b3c4d-0002-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "2b2b3c4d-0011-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "3a2b3c4d-0003-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "4a2b3c4d-0004-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "5a2b3c4d-0005-4421-8342-7269ec64d949" },
                    { "e9f639de-624f-4a4e-b8bf-2381725462f2", "6a2b3c4d-0006-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "7a2b3c4d-0007-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "8a2b3c4d-0008-4421-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "9a2b3c4d-0009-4421-8342-7269ec64d949" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1a2b3c4d-0001-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1b2b3c4d-0010-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "2a2b3c4d-0002-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "2b2b3c4d-0011-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "3a2b3c4d-0003-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "4a2b3c4d-0004-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "5a2b3c4d-0005-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9f639de-624f-4a4e-b8bf-2381725462f2", "6a2b3c4d-0006-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "7a2b3c4d-0007-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "8a2b3c4d-0008-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "9a2b3c4d-0009-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949");

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
    }
}
