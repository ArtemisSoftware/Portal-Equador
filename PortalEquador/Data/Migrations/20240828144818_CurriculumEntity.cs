using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class CurriculumEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2d18fe7-8683-43a0-9b2b-176a657c9f97", "AQAAAAIAAYagAAAAEITr6SRCdVzzDAZ0iKH5zD9Fwx/MooK+rkHl/3Rt4WA56SySt6gicAZ1D4m/KFJBQg==", "5375b075-4c60-4b62-95a9-0d0ebbbe92ed" });

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumEntity_EditorId",
                table: "CurriculumEntity",
                column: "EditorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4f8c1e-e18f-4443-a7b8-c8005f81b402", "AQAAAAIAAYagAAAAEAK7uJuwDYAe4f+M9jnjGoO0FBGcEf3Fxtn3jEk5AoO32DtjCkrMhcxy1ppTp53olQ==", "e2cf0765-3958-4eca-8f7d-a5e152f4731f" });
        }
    }
}
