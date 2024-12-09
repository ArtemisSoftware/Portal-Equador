using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentStateScheduler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "MechanicalWorkshopSchedulerEntity",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95a10cb2-871d-4858-a6bc-240471830c00", "AQAAAAIAAYagAAAAEPWPfcjOHEgxESZ237FzfoTgmeh2VMd5taNgOzgddpi0PNaYolDwCl+eikTbMEy7wg==", "08dcbc68-7f7c-43b0-ba55-205e86067964" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "023e79b4-fb8f-4b0e-8798-4fe2bf64d9e2", "AQAAAAIAAYagAAAAECWRmSdvlBPO8yOashosj8PQCBuvm2uWwiv0no/RKZff5YYYNOHB7nQMv8+FwK219w==", "c47906b8-4f05-42c1-b3b8-782ba77cf46c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a7cf0dc-50c1-4f71-bab9-60d3c03bb183", "AQAAAAIAAYagAAAAEHDF/gb2i3dQoUfhHMcGQDP9tefQviTnzJEgrXi8s2bKUVCBZJQPQDB+LY+vWKRk7w==", "a2451fb1-f3f7-4a40-b797-47152f7d54cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd04fad4-8d6e-404d-945f-b234578df5c0", "AQAAAAIAAYagAAAAEOG6+OrK6mvbX+j4VZDZ4tDMycq2DTBrSyC0viQ5ukHLiUXE31obcYzlM9R1oR3HkQ==", "1d0f7b94-1b1b-4547-91ac-f13a13a38907" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f2593f9-0125-419a-a231-9267f2bb1bc0", "AQAAAAIAAYagAAAAEPCjiQxR1XNojVzFOD0PCdCBk98QRLd9m+rcLq8pGsEu0knoEOKCujfXdMWmX4dlyg==", "607ee3a1-98db-4ed9-a499-14d29c2e015e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "MechanicalWorkshopSchedulerEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2ed6dcd-f1b8-4a0c-adfb-35bb6764e146", "AQAAAAIAAYagAAAAEAGxrY2yUAnrRlVAtV0GNRv09N3/EuCeWbfT2QYPKvWQmkxP1Cajdsf2eUyLyFV8Ng==", "035d6ae6-51ad-484e-897c-b9c120595bfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2ca5c74-cff1-413f-9a22-a68b384ced8b", "AQAAAAIAAYagAAAAELTk1TrBjZnpwZiAw7f2Da6plybPXZXqBdPriMFni2eZq9hoejZ8NooKeT2we8jxtw==", "a57c2f79-9da4-4798-b442-9ee337293a0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bebef897-c5fd-4cf6-b40e-b5ed54530740", "AQAAAAIAAYagAAAAEPl+nyxLxUOpc4tWFZaRUQqJpC+itW9tV8/a+caLYPk5KnvIFKAY3fuDcc+S8WmSoA==", "2e381c29-e6a0-4d0c-b5db-e9e40202c381" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6fafd34-5647-4305-a549-c8f0e5838517", "AQAAAAIAAYagAAAAEP63Q/X4IaFK5XB59mbz/OSoZLlE8dG/euOe5FdJEPnTiiz/xkXnrZiFICoCyqKIFA==", "fa6d972d-0146-4fc5-be1c-b84639d36409" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdf73126-664a-44f4-9b71-44f9fbb1246a", "AQAAAAIAAYagAAAAEIEmcSopgw5fuEfBOS2i049tFqD/7e3CepgIq/1qkAvEpKJX8EH1ch0xBBozXvq0dg==", "767ce821-98a6-4617-8865-478b03e4e0ae" });
        }
    }
}
