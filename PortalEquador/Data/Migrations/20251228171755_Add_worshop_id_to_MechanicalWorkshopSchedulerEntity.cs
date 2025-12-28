using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_worshop_id_to_MechanicalWorkshopSchedulerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkshopId",
                table: "MechanicalWorkshopSchedulerEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_WorkshopId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_MechanicalWorkshopSchedulerEntity_WorkshopEntity_WorkshopId",
                table: "MechanicalWorkshopSchedulerEntity",
                column: "WorkshopId",
                principalTable: "WorkshopEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MechanicalWorkshopSchedulerEntity_WorkshopEntity_WorkshopId",
                table: "MechanicalWorkshopSchedulerEntity");

            migrationBuilder.DropIndex(
                name: "IX_MechanicalWorkshopSchedulerEntity_WorkshopId",
                table: "MechanicalWorkshopSchedulerEntity");

            migrationBuilder.DropColumn(
                name: "WorkshopId",
                table: "MechanicalWorkshopSchedulerEntity");
        }
    }
}
