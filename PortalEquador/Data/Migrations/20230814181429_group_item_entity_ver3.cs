using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class group_item_entity_ver3 : Migration
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
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: 1),
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
                value: "895bcbcc-a40b-4cbb-a144-fc5616cb1f49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "16a2fa80-e3b4-4fc3-8643-504b37ebbe4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f85c1ff8-c1f6-4516-a69e-62e9fdcbfe58", "AQAAAAEAACcQAAAAEKFAqqBYnURGTaW9XEV+8KZuHNDoFeSKKxzc1VTS9lOfXaqYS9OJ0wlm5NTlij7iVQ==", "1269e552-bae3-443e-af36-d8c1d3c146f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a54cc856-8216-476a-acb2-e0ca87a516fd", "AQAAAAEAACcQAAAAELJ6z8kuXQoP1qqBx8S5NpkPN1aOblLT1IlYAScYNkHM8NeZmz2T2YziAGWCPTd7Fw==", "a7238dc4-5c80-4aaa-80f5-732d6f456930" });

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
                value: "e35d0f9a-34cb-4286-ba12-c1a33e09f25f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "413c5135-f0c3-4370-8735-37f18f41f470");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47b62f5c-509f-43e7-bd64-657f88d83e4e", "AQAAAAEAACcQAAAAEOKfW2ATrJcI/dukg+fxG0gKRS70GGAMJABq2TkfR8zGP+4qzuWN0lc0WtehjHZxBA==", "56fede2b-1693-416c-9cbb-24aa4636397b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53ef988a-6f0f-454e-802c-592614a08966", "AQAAAAEAACcQAAAAEPKWHiDrxd2HJQrHLCzzRyYegOfMRDuqJzSbsMLNTbIvsh6S38aRLYeBGfnQa+OAMg==", "d7ca1f5e-8be5-4895-86e5-b7cb1509108e" });
        }
    }
}
