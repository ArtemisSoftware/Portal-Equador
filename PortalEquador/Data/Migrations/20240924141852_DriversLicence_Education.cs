using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class DriversLicence_Education : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversLicenceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    LicenceTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvisionalRenewalNumber = table.Column<int>(type: "int", nullable: true),
                    ProvisionalExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversLicenceEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateTable(
                name: "SchoolEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SchoolEntity_GroupItemEntity_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SchoolEntity_GroupItemEntity_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SchoolEntity_GroupItemEntity_MajorId",
                        column: x => x.MajorId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SchoolEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UniversityEntity_GroupItemEntity_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UniversityEntity_GroupItemEntity_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UniversityEntity_GroupItemEntity_MajorId",
                        column: x => x.MajorId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UniversityEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0baed35-e29b-4ecc-b789-3b8ad5c7dbf3", "AQAAAAIAAYagAAAAEMjrNc1sV7JKBNHtDf0s5RoOJdUMfNLssVa6PaSNLh7fOehqaIcElnJq2NNeR+4qug==", "9d6d5144-9aba-4a74-9299-a1ac7b26ebd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a78b40-8896-41b3-b0cb-535dd7d3890c", "AQAAAAIAAYagAAAAEDMFfLmnz14BfHufeXIH6rf38vvMIApqCk3iFFDDr6W0GaRjY/KFPKCHIkFQ2HDcsg==", "28d6e239-835b-48ea-92e3-a225d71ceb7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbb69498-fb9c-4e16-8c84-d6093e685032", "AQAAAAIAAYagAAAAEGUcdnEUIbBGnmJ7CR7T1c6oLdaHOp2YaOotpeZOD88ciZofWXmY+lsaf6Ywoq9nxw==", "c89c5a73-6712-4934-a173-cbce60feae15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d11d42c-c73e-4784-8af8-845f33376a84", "AQAAAAIAAYagAAAAEPHDqNgUPnLgtv8INajnxq//kaMqlcWitJa6qJkGSrmSQx3+b/zo1jpzA53ruh6wnA==", "75539fc0-ee5c-4856-a6d1-64679cbd56d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20917a95-fd0c-4bf0-86c5-38feafbf5342", "AQAAAAIAAYagAAAAEEsrUqTvRYuPTQwe2q4qWxVbFiEzL/7HeGy/IC/91tVXUpkPeYes/YYvy4TPHgufrA==", "624513b3-3cc1-47a8-b1cb-156516a65622" });

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_EditorId",
                table: "DriversLicenceEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_LicenceTypeId",
                table: "DriversLicenceEntity",
                column: "LicenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversLicenceEntity_PersonalInformationId",
                table: "DriversLicenceEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntity_DegreeId",
                table: "SchoolEntity",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntity_EditorId",
                table: "SchoolEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntity_InstitutionId",
                table: "SchoolEntity",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntity_MajorId",
                table: "SchoolEntity",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEntity_PersonalInformationId",
                table: "SchoolEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityEntity_DegreeId",
                table: "UniversityEntity",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityEntity_EditorId",
                table: "UniversityEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityEntity_InstitutionId",
                table: "UniversityEntity",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityEntity_MajorId",
                table: "UniversityEntity",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityEntity_PersonalInformationId",
                table: "UniversityEntity",
                column: "PersonalInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversLicenceEntity");

            migrationBuilder.DropTable(
                name: "SchoolEntity");

            migrationBuilder.DropTable(
                name: "UniversityEntity");

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
        }
    }
}
