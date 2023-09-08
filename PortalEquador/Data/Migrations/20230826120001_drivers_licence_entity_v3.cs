using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class drivers_licence_entity_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversLicenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalRenewalNumber = table.Column<int>(type: "int", nullable: true),
                    ProvisionalExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_CurriculumEntity_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "CurriculumEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_GroupItemEntity_GroupItemId",
                        column: x => x.GroupItemId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "c49da581-15f4-45f7-8832-76b39c738469");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "6fcd26be-4d09-420e-978c-84722d899e17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf7a2d80-d58b-46a3-916d-3fcf24c80256", "AQAAAAEAACcQAAAAELmpx6okH2WXoXvG/duOetZLscgg7tKd14zdsiWLJWwEwQmXCtaBQWYXkYVEwC/7pQ==", "be276662-55ef-4eac-add9-46774134badc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76d52342-a9b3-4c90-aa00-4283bb4ac4e7", "AQAAAAEAACcQAAAAEKq7glz/g5FGzDefU9+AfFDSwb/u+nBo0+TUNYqDp+PQq3fUEwIhFWTNTFLoRBNf8w==", "606841d5-9e13-49c8-8d73-3f322cd68f0f" });

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_CurriculumId",
                table: "DriversLicenceEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_GroupItemId",
                table: "DriversLicenceEntity",
                column: "GroupItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversLicenceEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "52acb236-4287-44c3-8e1e-7837d0d3e232");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "0592b92b-cf24-4a1d-bd4d-e05d27ad6d4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad69d4c2-64a3-45fe-99cd-894fd774bcf8", "AQAAAAEAACcQAAAAENMd2+OyXs3g1eu+u5GMEgnYY3FS792+qiICDyG9gsSTEEwVDtH15OhgxVaq9dS9lw==", "2ad8dfd5-dd27-47da-8f1a-5ae69820e3e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e65a507c-7660-4219-af41-e7d0254a072f", "AQAAAAEAACcQAAAAED8+U3UHYkk141AV7pziJnq2HYjXxe9NQpAErpYqM16BPXVg9eT/1wi1KPPIUfKWLw==", "3278460b-ebc8-44b1-a88a-00e1663d5baf" });
        }
    }
}
