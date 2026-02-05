using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkshopMechanicEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkshopId",
                table: "CarWashSchedulerEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkshopMechanicEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopMechanicEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopMechanicEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopMechanicEntity_WorkshopEntity_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "WorkshopEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarWashSchedulerEntity_WorkshopId",
                table: "CarWashSchedulerEntity",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopMechanicEntity_EditorId",
                table: "WorkshopMechanicEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopMechanicEntity_WorkshopId",
                table: "WorkshopMechanicEntity",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashSchedulerEntity_WorkshopEntity_WorkshopId",
                table: "CarWashSchedulerEntity",
                column: "WorkshopId",
                principalTable: "WorkshopEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWashSchedulerEntity_WorkshopEntity_WorkshopId",
                table: "CarWashSchedulerEntity");

            migrationBuilder.DropTable(
                name: "WorkshopMechanicEntity");

            migrationBuilder.DropIndex(
                name: "IX_CarWashSchedulerEntity_WorkshopId",
                table: "CarWashSchedulerEntity");

            migrationBuilder.DropColumn(
                name: "WorkshopId",
                table: "CarWashSchedulerEntity");
        }
    }
}
