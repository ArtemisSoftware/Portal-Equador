using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class MechanicalWorkshopSchedulerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MechanicalWorkshopSchedulerEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    InterventionTimeId = table.Column<int>(type: "int", nullable: false),
                    MechanicId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalWorkshopSchedulerEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopSchedulerEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopSchedulerEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopSchedulerEntity_GroupItemEntity_InterventionTimeId",
                        column: x => x.InterventionTimeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopSchedulerEntity_GroupItemEntity_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopSchedulerEntity_MechanicalWorkshopVehicleEntity_VehicleId",
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
                values: new object[] { "b25c31a4-66f2-4f86-b305-0f6d01a033f5", "AQAAAAIAAYagAAAAEFD6uj2OEyHmu25M1gj66qmfAvkhsjMlPqbXq5bH0iii8V358v7URJQWWu7lecUMlQ==", "98b56f8b-4376-47b4-bc70-a9734c711df1" });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_ContractId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_EditorId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_InterventionTimeId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "InterventionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_MechanicId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_VehicleId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicalWorkshopSchedulerEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "babc5617-5502-4564-9ffd-8c9eb494daf5", "AQAAAAIAAYagAAAAEBVLz4vZD2VBjOg6aclguYbclg7VGkJjVoLjaSlNve99S/NlZkelYEtjHmbFHegStQ==", "a6df3032-7133-4f5d-b047-77f8aea6a32b" });
        }
    }
}
