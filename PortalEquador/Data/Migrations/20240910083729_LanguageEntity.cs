using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class LanguageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    IsMaternalLanguage = table.Column<bool>(type: "bit", nullable: false),
                    OralLevelId = table.Column<int>(type: "int", nullable: false),
                    WrittenLevelId = table.Column<int>(type: "int", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_GroupItemEntity_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_GroupItemEntity_OralLevelId",
                        column: x => x.OralLevelId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_GroupItemEntity_WrittenLevelId",
                        column: x => x.WrittenLevelId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LanguageEntity_PersonalInformationEntity_PersonalInformationId",
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

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_EditorId",
                table: "LanguageEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_LanguageId",
                table: "LanguageEntity",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_OralLevelId",
                table: "LanguageEntity",
                column: "OralLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_PersonalInformationId",
                table: "LanguageEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntity_WrittenLevelId",
                table: "LanguageEntity",
                column: "WrittenLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4d75cc8-733e-419d-96ce-6b2439cd5fd8", "AQAAAAIAAYagAAAAEL5MxmoH3njdCPsvjMoJYCexYAkNH6h+jW1m7yaDtPUac8P014zQCIsqpptEYs49Mg==", "3377f834-23d5-4da9-ac2c-7cf7889e79e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5afe026a-2ae0-454a-b994-8dc948fa7b2b", "AQAAAAIAAYagAAAAEEMC3431HH4/fzvVG3frv4MlWs3RtVzUhCvM301pAzoPs6HuxdsOpftI/DMoZyapDw==", "dc4064b0-89d5-4aa5-bb82-80edf3310416" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3add0d9d-fcab-4c7a-8a06-53e4635ec2a2", "AQAAAAIAAYagAAAAEIM+hM7j8+B7sIu+VutMvNZUW3/DUprS6NKcayqd/tHospyhUceCD+PJzVc7WwWYMA==", "501752f8-746d-4a30-8d58-6162f8ec293f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "996d1eba-be24-480f-b6f4-7f565567615c", "AQAAAAIAAYagAAAAEGFw/Dab6jnIz4ZuiSBebRGcEvJjjMVPG1rpJmMrwIL4ZPnC0mexIzdRP18HoBjbEw==", "ee35db5d-3ae2-4f72-bd0f-a43c987c1bae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "132bb42d-4ef2-4bd4-bd29-c1717eebf76d", "AQAAAAIAAYagAAAAEHG2louEr2kwekzTNSJStBpFM8OiNbRgqh/yKZUijkKTZWOUkZugA+CaISu1L8LpPw==", "14641e2d-658b-45ab-9519-26add0694726" });
        }
    }
}
