using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class carwash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarWashSchedulerEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    InterventionTimeId = table.Column<int>(type: "int", nullable: false),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWashSchedulerEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_GroupItemEntity_InterventionTimeId",
                        column: x => x.InterventionTimeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarWashSchedulerEntity_MechanicalWorkshopVehicleEntity_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "MechanicalWorkshopVehicleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarWashSchedulerEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca68917-d5f8-4780-94b3-48c37788b723", "AQAAAAIAAYagAAAAEJtvsXhmmDpD8JMd2taajXztW6sUY+u2g2Xl4gs+vZGyu9+/3ZuOOb2GQ9auUz1FRQ==", "24a5b881-47e5-43e2-93df-f5cef5350e9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4287ef6-c62b-46bb-965a-623a5c0f14b0", "AQAAAAIAAYagAAAAEAc4+B8pgSGtJ7bsk2Zp/UldDMOcpBQIJtqI3q6cS+8ov+ew7ogaFtugu7yzaG/Knw==", "c526ea72-c6c2-47ab-95d2-b31c713561f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2662f2-e7de-4d28-98e3-d0598bdd25c0", "AQAAAAIAAYagAAAAEPbDoYDhmx5zNHIzZR9tgpoXGzlqCOdpBtN1tzIbWZ+iGqgxQ2fHCfhE9cwrmoHIsw==", "1f6330db-756f-4fe0-a2a5-6211289780a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d056d8b-035d-4e5c-8fcc-49b27dcc1e59", "AQAAAAIAAYagAAAAEMzqALp6YG1aB3nstKb+Cplkl4+B81lJZ/R+CflGDaI0cDWZrg2f9e6anYmscRTjBg==", "8d02dadf-1a4a-4be3-8675-19dd9ea0047a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db880e99-691e-4cb0-8bdf-f362a8524fb1", "AQAAAAIAAYagAAAAEIJO8hXbiAg7JQk5dViAGzuQgft5jpE8FuzozxWjHoyrFa67+wjBRyBXJ7qb3zuEWw==", "8bee2145-0186-453a-af06-4a6d8ec90b8f" });
        }
    }
}
