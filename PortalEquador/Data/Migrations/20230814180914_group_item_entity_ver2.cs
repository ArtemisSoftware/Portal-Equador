using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class group_item_entity_ver2 : Migration
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
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GroupEntityId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupItemEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "863dac79-d286-4c45-a7c4-aa5dca088c1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "63085f7b-91e0-498b-8a4c-982b6af1bd02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7568243e-ed8c-4bca-81ba-d2f2d9d721a2", "AQAAAAEAACcQAAAAEHb0Ub60N/Uo+Pdu04Jl0h8Kns7QWn3DS/mRnYQkxPb5YdbUZwurz68hmyS9hIdccQ==", "fefb97d3-e395-4aca-bee1-b40db2752d51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7803d3a-4b95-48de-a0e5-733eca76c5c5", "AQAAAAEAACcQAAAAEBxOcPaoLSEaxNmeGA8pFf/TNeD9UTRX71uWYYGlxq4AIvR8k55Ct7tK2aDHSUqKMA==", "49f1e440-9835-4d9f-9f70-1bbaca610ce9" });
        }
    }
}
