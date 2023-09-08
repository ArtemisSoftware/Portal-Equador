using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class drivers_licence_entity_drop_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversLicenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    GroupItemId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalRenewalNumber = table.Column<int>(type: "int", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "9aaf604c-c767-44c0-99cd-633ef5a38124");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d09c56c1-57aa-4382-809c-51578f482624");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55ccb79d-f229-4d8e-b884-1feaf4c71fd4", "AQAAAAEAACcQAAAAEEXM1jciPCtpraN6QJqhQKZMjr1dW9Ie+SkVk8/UQuCmGhqJyNn8JVY87SXZCErHbg==", "ef7eefcb-2d3e-4a29-a3fd-c640ab871fab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07e9107f-1b6e-427a-a616-842f0c4bb681", "AQAAAAEAACcQAAAAELP0Md5El2J9g+MJvVhL6GSA/+SMRRfbmlyPGBcQ/Zc2ubymHWKfHkYCTY3+4fhEKQ==", "552385c2-8a04-4134-8eba-535a2f2e3867" });

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_CurriculumId",
                table: "DriversLicenceEntity",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_GroupItemId",
                table: "DriversLicenceEntity",
                column: "GroupItemId");
        }
    }
}
