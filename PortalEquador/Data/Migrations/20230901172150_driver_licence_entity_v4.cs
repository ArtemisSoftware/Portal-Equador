using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class driver_licence_entity_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversLicenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalRenewalNumber = table.Column<int>(type: "int", nullable: true),
                    ProvisionalExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenceTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_GroupItemEntity_LicenceTypeId",
                        column: x => x.LicenceTypeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_PersonalInformationEntity_PersonalInformationId",
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
                value: "0429c0c2-0a49-48a7-bcbc-9e7784db186a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "e06f26b7-5a1b-4896-87ed-d154b140f42d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e76151c-3b2d-42cb-85ce-f63a477b43f7", "AQAAAAEAACcQAAAAELlxFZCNXky5Izf3osMjIUboCbh/K26r78ZhOz1zkygT4mcx8WStljEKyGzQkKauNA==", "8b1c6ac6-d491-4763-a3d5-71017ee53eaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "812ac5db-7139-44d9-9e2b-a48ed8c04531", "AQAAAAEAACcQAAAAEM2MyZVuUtA6aOULB/QZlkZ8Urs0Jd0Wwv1lnh+DN/SuS8WP75dgeMNVCrTxh96sfw==", "cdf0ea47-7853-4b42-9d02-a0a40d576838" });

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_LicenceTypeId",
                table: "DriversLicenceEntity",
                column: "LicenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_PersonalInformationId",
                table: "DriversLicenceEntity",
                column: "PersonalInformationId");
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
        }
    }
}
