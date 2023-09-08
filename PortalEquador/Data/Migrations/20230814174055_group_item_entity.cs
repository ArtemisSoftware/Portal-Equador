using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class group_item_entity : Migration
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
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                value: "4a586a7e-5cfe-444d-8129-0c00c00cf57c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "8dbe4365-8a6d-4d4e-ab58-44297d70566c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3edb437c-3480-4a5e-9cc0-abdad89ad10b", "AQAAAAEAACcQAAAAEACsiyTaqIoa9EKgKEuon5gNczluXXp9uQiG/pATrJSiSF9BEsFfwEBYYVM+SYCbVQ==", "5c5febd9-0035-4f6b-aed9-1a5f57ad150c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ca34b8-51f1-4d71-a095-675dd2996227", "AQAAAAEAACcQAAAAELEgaVj10c8kfSNZjmZuJfl4J/LRt8uLP4v6z+Di3ZoDuxz1NgH2YSrXNX9CAH0UEw==", "73593e7e-6317-4244-9b2d-8605730e5e48" });

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
                value: "c3baa55b-bf6a-4dc5-937e-055a0164034d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "8200dee9-3de6-4817-a8ac-df738b18fd6f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f4249f1-4883-445b-b423-04b6acb305b5", "AQAAAAEAACcQAAAAEMQe5n7jVnB7M2JG996KiPFQwYJxIuHGgS3RYcGZ9qwi6cNRDl6DClRtlr3Pn1ZkvQ==", "39405c31-054b-4142-8c20-4a7803182046" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba839b61-a046-4574-8d4e-0ed2d5487204", "AQAAAAEAACcQAAAAEFv+Lvi7z/WMDY6Ndwht4PhAKmc6ysOwVr/f+MlZ8AJjavEnJ45Za+0Nb/2gEwQPTg==", "e42e67ac-9198-4cae-b334-dcda5e06276c" });
        }
    }
}
