using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarWashEntity_parameter_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkshopLaneId",
                table: "CarWashSchedulerEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarWashSchedulerEntity_WorkshopLaneId",
                table: "CarWashSchedulerEntity",
                column: "WorkshopLaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWashSchedulerEntity_WorkshopLaneEntity_WorkshopLaneId",
                table: "CarWashSchedulerEntity",
                column: "WorkshopLaneId",
                principalTable: "WorkshopLaneEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWashSchedulerEntity_WorkshopLaneEntity_WorkshopLaneId",
                table: "CarWashSchedulerEntity");

            migrationBuilder.DropIndex(
                name: "IX_CarWashSchedulerEntity_WorkshopLaneId",
                table: "CarWashSchedulerEntity");

            migrationBuilder.DropColumn(
                name: "WorkshopLaneId",
                table: "CarWashSchedulerEntity");
        }
    }
}
