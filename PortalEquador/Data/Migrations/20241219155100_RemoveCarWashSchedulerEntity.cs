using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCarWashSchedulerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarWashSchedulerEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a636a8c9-754a-4cdf-b6cc-f5c81c130d5e", "AQAAAAIAAYagAAAAEKXMpUuqe0+QxiRCRgLMCcpMfWM9cGav9RbzyWfJ4Ecsw4i3zIlSrvEMMbJ7sBiFaw==", "9f83cfd2-5ce4-4a9b-a2f2-660dff64d823" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3378642e-5b92-4730-8fb9-f07303c123fd", "AQAAAAIAAYagAAAAEKmzhsCzWxdaxrFg/Igyxvshd2FOg0lSuw3ACJxEpZLMqKDBaaCzvI3K3UebpoXR+Q==", "e05ab708-265c-4575-9373-0c1fe396114e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e52dd3e0-c4a6-4d0f-9c9c-14ed228c908a", "AQAAAAIAAYagAAAAEGbSpe9WYgV5gjzxYdWavOq7YITcVjq0y15Cc+2Tb9zuE4y7n/5VMK6s1CuqSttwgQ==", "b6678150-51b9-4735-b8f6-39a013f6f712" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c9ee257-5679-4fda-95ce-01d234fa3e48", "AQAAAAIAAYagAAAAEMGAJsDbpk8R4QZ7oA5JYyBNYamX20Egt43RYaEDedQNfojWOGVE4nBjBsXZfs9/fg==", "73690948-d410-4e58-87c8-7a9f3b96bffd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6336e2b4-e3b3-4deb-aa8d-efefefff865c", "AQAAAAIAAYagAAAAEA8K5ELl6F4gjeJkcI+iUQZbJRLPeqPLslRXDWc4GPIJZ27mIXK7j+zSjBnAlpAAcQ==", "a28fe1e4-bf77-42cc-ad70-8e48b8a61915" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarWashSchedulerEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InterventionTimeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduleDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWashSchedulerEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_GroupItemEntity_InterventionTimeId",
                        column: x => x.InterventionTimeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_MechanicalWorkshopVehicleEntity_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "MechanicalWorkshopVehicleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CarWashSchedulerEntity_ContractId",
                table: "CarWashSchedulerEntity",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashSchedulerEntity_EditorId",
                table: "CarWashSchedulerEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashSchedulerEntity_InterventionTimeId",
                table: "CarWashSchedulerEntity",
                column: "InterventionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWashSchedulerEntity_VehicleId",
                table: "CarWashSchedulerEntity",
                column: "VehicleId");
        }
    }
}
