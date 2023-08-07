using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class GroupItemsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupItemEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupEntityId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupItemEntity_GroupEntity_GroupEntityId",
                        column: x => x.GroupEntityId,
                        principalTable: "GroupEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "dfe3b693-f8bd-4abc-8cd9-22e15a0b3bae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "8776d720-fbd1-4433-8102-b8b7100c810d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eb3a1ae-be21-4e1a-a666-af400e5156e5", "AQAAAAEAACcQAAAAEDElwUe3cZdpxyPPTQp/EGU3kki+rwPqOF+jaRhkfopcC9ODK8j8M9XPJ7EnMzw4XA==", "589f61c3-f512-4dfa-856c-00468103dc87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22eb40f0-7f66-4481-8b85-297ce9475c3b", "AQAAAAEAACcQAAAAEGlEapKIPKk5WzbRidJ8hTI/e1g0iexJAxw3snjF0QJBjxbusehvBWujGnuDW88I/A==", "2eb9fb97-c9f9-40b6-bcc9-7ff727c10b54" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupItemEntity_GroupEntityId",
                table: "GroupItemEntity",
                column: "GroupEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupItemEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "d2292219-9f04-4b4d-ab3b-62148c3138dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "b433b7ce-ad17-4fb8-80a6-74fb49e6acef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6efe9746-f4a1-4c0d-9d82-bd7c510e6ca0", "AQAAAAEAACcQAAAAEBKLO+EUw+6ac8JAf383P9MquutjNV/pfK3o/oWK9V6SGqr0lfHLbLBfl41PeMF/kQ==", "fa36fa04-4147-4e1e-8b48-cd4dcbe94306" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6548f4ac-9e6a-499f-91ab-252fbb2e65da", "AQAAAAEAACcQAAAAEADFLxR8pqnLH4lKjATwqo1vjPL4og6UYnU9ZXqfSNERjDJk4MEEOQSjQTLqqkFgoA==", "a4fcbb3f-4c24-44e6-9296-bec65a4817cf" });
        }
    }
}
