using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class MechanicalWorkshopVehicleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MechanicalWorkshopVehicleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalWorkshopVehicleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopVehicleEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MechanicalWorkshopVehicleEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "babc5617-5502-4564-9ffd-8c9eb494daf5", "AQAAAAIAAYagAAAAEBVLz4vZD2VBjOg6aclguYbclg7VGkJjVoLjaSlNve99S/NlZkelYEtjHmbFHegStQ==", "a6df3032-7133-4f5d-b047-77f8aea6a32b" });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopVehicleEntity_ContractId",
                table: "MechanicalWorkshopVehicleEntity",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopVehicleEntity_EditorId",
                table: "MechanicalWorkshopVehicleEntity",
                column: "EditorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicalWorkshopVehicleEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4ce27f-43ba-476a-9ebf-a93ee4884b95", "AQAAAAIAAYagAAAAEKvTBkb6qx1ZbUqPEQ8kfLUrHJ551vbvrArcy/9mYqu2YTNLvIUqEaXVenqPBRSRMw==", "a414ade8-8078-418c-af4d-c8bf9b22f7c9" });
        }
    }
}
