using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class Professional : Migration
    {
        /// <inheritdoc />
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
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalCompetenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalCompetenceEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalExperienceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalExperienceEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5d75f03-ebd9-4a35-9e37-988906d30107", "AQAAAAIAAYagAAAAEAP16moslTYrRh7ALCkArJo5E/Sa+NJotZkRIB0UcmTRFF18+YXARs6ShlSw4bbRdQ==", "33667573-2474-41fa-bb9d-2c81bcede80a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5e7e0c9-b052-41f4-8de1-ab66780f2efc", "AQAAAAIAAYagAAAAEJ1g5SslvOtaab2QF0rlrviS7TOmvENXgmFpCvGBMTSrYUekAElSlg9xOuD9KTyN3Q==", "dabb4755-c2f6-4cc0-9549-c35de75adfb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9720783-3814-4395-83f8-1df8030b4fa6", "AQAAAAIAAYagAAAAEKPZHuRq7dXemMt8ToQglkdE8fptx6EY71+t+EBcj16bba1w/nvD0xEVnga9cM1zJg==", "73bd2bcf-93ea-48c8-8f10-18cf6a02fb20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3273b284-327c-4059-84be-fa8787905bcc", "AQAAAAIAAYagAAAAEBXEu9SNerSv5u6bA2x6YNFVQ1y8OjYNth3PHt4BKSBi9/BwuU4yq0Zzg5oCIrFGyw==", "b3840242-bde9-4c76-9769-3c4ddf2bec91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "515822c6-dfbf-4160-99f3-12cc5f76c4c8", "AQAAAAIAAYagAAAAELlUpeKFAjmbsupLDc6brEu4r0e1tQ1nUPgq/vYA7YC0IN7URA5wqnaaiu0uP/4eEg==", "df7f49cf-6b58-4e0d-a95f-939b65bdb12a" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalCompetenceEntity_CompetenceId",
                table: "ProfessionalCompetenceEntity",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalCompetenceEntity_EditorId",
                table: "ProfessionalCompetenceEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalCompetenceEntity_PersonalInformationId",
                table: "ProfessionalCompetenceEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_CompanyId",
                table: "ProfessionalExperienceEntity",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_EditorId",
                table: "ProfessionalExperienceEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_PersonalInformationId",
                table: "ProfessionalExperienceEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalExperienceEntity_WorkstationId",
                table: "ProfessionalExperienceEntity",
                column: "WorkstationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalCompetenceEntity");

            migrationBuilder.DropTable(
                name: "ProfessionalExperienceEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb58e3a-aa40-45af-aa95-238b99a68aee", "AQAAAAIAAYagAAAAEMT/7egQ2FMfSn+0W6CBEg97sVq1Y24Hg1E75aYWEsHwqmNAmvrU/448TLLg/lontA==", "5d2efae8-14e1-417d-baf5-0cdcb79274fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15b455eb-73c3-4190-acf5-bb07b2c8fa6a", "AQAAAAIAAYagAAAAECm77SRSZS08IbXxhttQGRqcNWg2cLnKuwqXk4xwPhUYx/d7H8kmXKax/rsivqZoRw==", "e38be3d3-abb8-4025-938a-7e44c42360fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8c050c4-15ab-4970-bfab-79fea7dcea42", "AQAAAAIAAYagAAAAEB81/Sdc/bYmNj4nZ4O+YzRqj71GPFUzu2lRHZWHptzg2SA8s83tOyRkRdQZ871PnA==", "de65b1fb-650f-4d92-a490-cf229ed21a77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbc803f7-95c5-4ac0-a2e3-b174122568cb", "AQAAAAIAAYagAAAAEEqpzw9+jBIZPikVwS39A875MFvSQW2c4HPmjlV+Nm2mXQBUXBi0RgH54SLgNxQTEg==", "3e636543-ef4d-40a3-b5ca-65a0fdf9ef90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "364735e0-6b42-4fe2-99c4-347383498153", "AQAAAAIAAYagAAAAEBPOfA4dsA5DMisXJl1NHiteqInrThRHOCeHpwD6qzMTUlaMq9oClH61vKjmsmVORg==", "e41dacef-472a-4aa2-b244-bbb2837cd41b" });
        }
    }
}
