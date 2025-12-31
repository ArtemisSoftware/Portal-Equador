using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class MechanicalWorkshopVehicleEntity_parameter_type_change_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkshopMechanicId",
                table: "MechanicalWorkshopSchedulerEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_WorkshopMechanicId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "WorkshopMechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalWorkshopSchedulerEntity_WorkshopMechanicEntity_WorkshopMechanicId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "WorkshopMechanicId",
                principalTable: "WorkshopMechanicEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalWorkshopSchedulerEntity_WorkshopMechanicEntity_WorkshopMechanicId",
                table: "MechanicalWorkshopSchedulerEntity");

            migrationBuilder.DropIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_WorkshopMechanicId",
                table: "MechanicalWorkshopSchedulerEntity");

            migrationBuilder.DropColumn(
                name: "WorkshopMechanicId",
                table: "MechanicalWorkshopSchedulerEntity");
        }
    }
}
