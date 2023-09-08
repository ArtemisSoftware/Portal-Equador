using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class document_info_v3 : Migration
    {
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEntity", x => x.Id);
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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "09110de6-1188-4de7-97d1-fc9d9d66840f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d48f83dd-37d5-42d0-a7c1-259645bf1558");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d35bb684-4689-4d30-91b4-edc3406d8a9e", "AQAAAAEAACcQAAAAEIpmXvN4tn/qqzFxRdvoSMV1jA52/lwPWam2seNUkwPD5/z3gTI79a4s4zZ9W5hOKg==", "ab1beb85-ed4f-4ded-ad68-3328f917d333" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b139556-03d7-400c-9d29-1922dfa53360", "AQAAAAEAACcQAAAAEPy1DgiEj/lsIw6dwOrfLAXehzyU2iDBvqXoEP2YGkCtLGXnseC35VeWtngW85UlzQ==", "b7752e3d-7226-4446-b614-5ed1aee6f0c7" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_DocumentTypeId",
                table: "DocumentEntity",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_PersonalInformationId",
                table: "DocumentEntity",
                column: "PersonalInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "ffb23318-7ca6-4aab-abb6-2e0cbe6d7462");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "d3e2bed0-5f68-4550-8c14-85186c245037");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e33fac22-af4a-4c6d-bb25-78dedce5a726", "AQAAAAEAACcQAAAAENuVi+glwpcN/D1xI7hdydYtMLytkmwXrvNHv1Xze/3pol0bveHudJVndYdEyMTRoA==", "5f506a59-672d-4074-aa12-93f416a01338" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a45edd-ef53-4b9b-a43b-73b3bfb2e01d", "AQAAAAEAACcQAAAAENMmVA9xyICTRmjMNYfLQbz+dIfQAC+zGV3yUeuvzLImpbZA3F5UXKPf2+4itlQmGw==", "37e23f82-1e60-40b3-98dc-d8bda179442b" });
        }
    }
}
