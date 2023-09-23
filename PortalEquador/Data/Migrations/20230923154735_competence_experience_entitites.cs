using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class competence_experience_entitites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalCompetenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    CompetenceId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalCompetenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalCompetenceEntity_GroupItemEntity_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfessionalCompetenceEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalExperienceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    WorkstationId = table.Column<int>(type: "int", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalExperienceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalExperienceEntity_GroupItemEntity_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfessionalExperienceEntity_GroupItemEntity_WorkstationId",
                        column: x => x.WorkstationId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfessionalExperienceEntity_PersonalInformationEntity_PersonalInformationId",
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
                value: "7c5349a1-b4bc-48c5-b647-3d09fad87546");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "ad94ebb8-f4a3-46e7-8a73-ce61b0729ab9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5498719f-986b-4f51-974e-b5ed2d2215d3", "AQAAAAEAACcQAAAAEAFagA0kcgKh5qpstiSEKPGZbHXbUIrOAbx1nmKOelyPMAeL+EsO9nFFB9Yqwr0MuQ==", "7a922ea7-c87c-4eae-838e-192ac7d2bc00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f18ec516-285f-4b89-b9f5-c9ae8887d3d7", "AQAAAAEAACcQAAAAEBhwemIcmOOJXeMMIfqbN0Sjmet8eMFQxUHiMeVjemXizu8RPD6ju5kDi5VvBS+B1Q==", "775f12a4-2a14-4fd3-98e8-2d4b0ab4b46b" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalCompetenceEntity_CompetenceId",
                table: "ProfessionalCompetenceEntity",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalCompetenceEntity_PersonalInformationId",
                table: "ProfessionalCompetenceEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_CompanyId",
                table: "ProfessionalExperienceEntity",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_PersonalInformationId",
                table: "ProfessionalExperienceEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_WorkstationId",
                table: "ProfessionalExperienceEntity",
                column: "WorkstationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalCompetenceEntity");

            migrationBuilder.DropTable(
                name: "ProfessionalExperienceEntity");

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
        }
    }
}
