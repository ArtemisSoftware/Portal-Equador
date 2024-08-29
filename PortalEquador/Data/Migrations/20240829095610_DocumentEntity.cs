using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class DocumentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocumentEntity_GroupItemEntity_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DocumentEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4ce27f-43ba-476a-9ebf-a93ee4884b95", "AQAAAAIAAYagAAAAEKvTBkb6qx1ZbUqPEQ8kfLUrHJ551vbvrArcy/9mYqu2YTNLvIUqEaXVenqPBRSRMw==", "a414ade8-8078-418c-af4d-c8bf9b22f7c9" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_DocumentTypeId",
                table: "DocumentEntity",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_EditorId",
                table: "DocumentEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_PersonalInformationId",
                table: "DocumentEntity",
                column: "PersonalInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fbeeec7-040c-4a47-81f1-759441373ff4", "AQAAAAIAAYagAAAAEOq67By+o1z/o/HBy02aeuDeMYi+onO+a7gahiBdmUiuL3K/+e5r/c4g5tdVZhU8lw==", "285509d8-1afc-43c8-9d8e-8ff60e438d3b" });
        }
    }
}
