using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class GroupEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupEntity_AspNetUsers_EditorId",
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
                values: new object[] { "c9bc9033-20dc-47a3-b3e2-927b70eb2340", "AQAAAAIAAYagAAAAEGF11z+bEe21QUhzasM2Ng8XPQ1f+NvabwBf882fZ3jyLnis4CXUaLBkoJeNknjj5w==", "eab87cea-e0be-4fd3-9d0c-9ed691088cf5" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupEntity_EditorId",
                table: "GroupEntity",
                column: "EditorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3afda94-c2c1-4e38-99e4-78f7498a01d3", "AQAAAAIAAYagAAAAELitZ+VLAuZsgYfLxO04YeCAiXuqzyAyMX5kErPSXwnVHtxFAoJdc1cc9HS03Y/pgA==", "b7556f15-4a03-4674-8050-7641ed50fc4c" });
        }
    }
}
