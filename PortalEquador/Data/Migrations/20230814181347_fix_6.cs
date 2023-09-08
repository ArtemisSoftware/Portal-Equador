using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class fix_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupItemEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupEntityId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                value: "68eadc56-ea5a-4748-9e85-f572a3221a37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d5279848-3da3-482f-88b5-e292f8dcfbd7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e143019f-27d5-42cb-ae9f-49b4304f4e76", "AQAAAAEAACcQAAAAEImuJ8wJJKKtltVQXlkOJ/hLF4mHRxzWMukf6rqdYsNFobiZtXyRtpmh8fkesjv1fQ==", "857f72db-d5ce-4eda-a8c3-e226740a6c23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2433e609-59f5-4bdc-b9aa-b163b1f63f4f", "AQAAAAEAACcQAAAAEEuN/x7nij6M2sbgfBJSjntEejBTC8yzDUO+IgHKYNGnuscdLQG9ZRbU9mdoVz7S2g==", "ceb91fc0-f5fa-49b2-b1f9-ff4f51153ec5" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupItemEntity_GroupEntityId",
                table: "GroupItemEntity",
                column: "GroupEntityId");
        }
    }
}
