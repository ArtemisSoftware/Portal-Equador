using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class carwash_v2 : Migration
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
                    LaneId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_CarWashSchedulerEntity_GroupItemEntity_LaneId",
                        column: x => x.LaneId,
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
                values: new object[] { "6c9b8e90-5d95-4c3e-86f4-9d34659f6f22", "AQAAAAIAAYagAAAAEKpnZwfOwEKHh2oe1NH3G/13nXM5tuzojxPde//3NG/1srrcbgv2Ql1v0HysrzF8+Q==", "1a63aebb-d050-4083-a594-62cea28932c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88a9010e-66b3-4977-aacc-e0e93ca26ab1", "AQAAAAIAAYagAAAAEKUwiNfiHAPQg6UTrPdnDTgUgUEDPc5ndivbE0GW00MUrzbbMq+69DwQ8v4dzktn2g==", "7175a9fa-291d-44bc-8da5-d0f0b35f321b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7846b07-1efc-4d09-8212-a0e72324283a", "AQAAAAIAAYagAAAAEHzbAKs1uoc2vqECh86KzKggqF6NzMqvkTaOayl7sgNhYGGMtSd5Qdq5qT7/CoDRQg==", "fc9a70a9-4289-49a5-ab0d-189c9603e80c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbddb3df-3fe2-45b2-9e46-d02a6a3b02a3", "AQAAAAIAAYagAAAAELjha9+RcsWctGJpWxUu/lOer/BcAPND/5RF+LrYr+9VZWHrrgi4VOTTiUJW4/mJFg==", "413c4ee2-6a76-48b4-ae8c-11571ba7e1ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59d2429a-a857-4463-997b-44bf8caaced9", "AQAAAAIAAYagAAAAEAoI0RyKMuaAOdeM/ferCbXoXscXNnBJD7ARulmRlnJY6BpVu63GFizH2Rt5qsYHnQ==", "09597b21-ceac-479d-ad03-53d0f3fb3547" });

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
                name: "IX_CarWashSchedulerEntity_LaneId",
                table: "CarWashSchedulerEntity",
                column: "LaneId");

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
    }
}
