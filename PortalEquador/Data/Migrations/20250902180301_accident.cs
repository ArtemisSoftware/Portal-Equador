using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class accident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccidentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    EstimatedValueId = table.Column<int>(type: "int", nullable: false),
                    HumanDamage = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_GroupItemEntity_CityId",
                        column: x => x.CityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_GroupItemEntity_EstimatedValueId",
                        column: x => x.EstimatedValueId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_GroupItemEntity_LevelId",
                        column: x => x.LevelId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_MechanicalWorkshopVehicleEntity_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "MechanicalWorkshopVehicleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccidentCauseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentId = table.Column<int>(type: "int", nullable: false),
                    CauseId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentCauseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccidentCauseEntity_AccidentEntity_AccidentId",
                        column: x => x.AccidentId,
                        principalTable: "AccidentEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccidentCauseEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AccidentCauseEntity_GroupItemEntity_CauseId",
                        column: x => x.CauseId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce6b3461-30f2-4a58-9a2a-5bf605f884e7", "AQAAAAIAAYagAAAAEAqAGivgvpapor9LSeSxWT6Tq9DFjN0K42EE1H/hxsjGO/VVn4jIWlqsQW9ckRcfQA==", "fca13e39-c5da-480c-94fb-6be56701d4e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db8439c3-6932-48b3-b514-d8481eaf1045", "AQAAAAIAAYagAAAAEJ5XbqCNKlKFdbY77DyQ8kkH2n/SZ+Fyswe/VlSnuHfHr6cXnM6A9pJreZn61uwzfA==", "360f41dd-7c5e-48be-bc10-3aa9b1735df4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d9d7272-b9ee-48ce-a07b-967fc5559998", "AQAAAAIAAYagAAAAEEXLeddWpHq+2A7QE0vC9ZK4cuzyJPVrNG65vBYWLp6T/wifoOexV7f+B5TXYW++MQ==", "4d69b274-4a15-4757-a8c5-9b3da17cd4fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c4b6cec-9e65-4641-be6a-1361d612a2b9", "AQAAAAIAAYagAAAAEDAnKwy/S1jThcnxhZasuUKxoemuaMMsGwLV35OVDxbp4FWqoXIR3lD2CYt0enVGfw==", "e811e881-6392-4175-9aa9-4908718abfc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99f809c9-2812-4b0c-8f66-7e5ac6af8e77", "AQAAAAIAAYagAAAAEEfcvbWZd2vy825+PLtr/CcWYhdr2U/QuH+mC4/Q8Q0wk4kxXfrKzYVos+gdrx4JTA==", "29037678-b8b1-4a43-84f8-6ca07bd5ee91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb536e0-adfa-46dd-8818-b988461ea7f8", "AQAAAAIAAYagAAAAEBKdDdaYzRlxGeuyTRUbJpfwDS8M1OzBa4PFnUaIy5c4HIAW5+r+w4QjBCgcxPfLiQ==", "974d5c81-84c6-4d77-b6b2-5081743af976" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44ec7937-9e6e-4c5d-8d59-53c1ae8d5ca9", "AQAAAAIAAYagAAAAED4aWZEZpoltRKrPledWNoJ/YMvweGHkgu4nPBo7C76TJ9uo64l3AvBTy4GvDC6BhQ==", "56f66bac-c34e-4389-a3e1-4641397b43b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d97a6adb-7dda-4bbe-9c7b-1e827c5aaf3e", "AQAAAAIAAYagAAAAEB4aCq2TaewoVAC/ulgSBtquTOX2d8QdZYpWqrlmOmVQUND5Dd/KTgoxh5S2Mj2F6w==", "ade075f3-f6b8-43ec-af9d-fb106c4cd644" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad4f7dfd-10a8-44fc-b1dd-ec152715d2a3", "AQAAAAIAAYagAAAAEITTQIMhQZeC8d9MgdXMGHXDmGpmqh9I/hAMlUwDT0riFRUNdTu3TsM85OyxKukGXw==", "e3f4e6ed-9630-46e2-814a-d44bfa16871f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a161267c-10fb-4179-b7ab-889af3fb68ac", "AQAAAAIAAYagAAAAEIWljwX6ODPeRH54pRbshKD1aV/jYEKewXyz598xDwBx3kgkqUdt+c0ezmN5sHV/sw==", "f6b325a6-e1cd-4c18-81b7-d6dc34dea4d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f53fb51-e0e9-4a4b-b5e5-7e027a3ab0ec", "AQAAAAIAAYagAAAAEMCfOF9Ta4brsNgIYdzUMrjQ1bV/6DyJVTr81t4ZwVtcNe3rTKpnbgeZITjMacxBJw==", "0f71572e-2845-48cf-b7c4-2a76a9bea719" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b511de78-53fe-43f5-a00e-2692a3af0d69", "AQAAAAIAAYagAAAAEDuZ3LbtNHDlFU9qyrdkVysEMnrMs5a8S6jgin1UQmctgY7YNFdDtaYTjThW9O9upQ==", "ca78fe14-761d-49ae-bd09-1a6546e76463" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ff4c7f7-b229-454e-a9d0-0ffe8f62d65f", "AQAAAAIAAYagAAAAEETova8jU5bkr/EiuvRkSgGQLI2anzTCGgtyjRTDYP7pG0n0vdA/oSZLrdphk0MxvA==", "1144b044-ffc2-4c63-8e7a-84709b5a8dbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1557d5e7-3028-4268-b62d-3f8897197794", "AQAAAAIAAYagAAAAENRYdJvsmNwxh0JileMybM7kcbzzrmUKtX/8mi5/8QCkBsWLqt+0Srm8ocooGeQ2kQ==", "45fc5443-6422-46f2-b22c-2ddc5c215c18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c0408c8-6023-46a2-be49-acb8f02c2556", "AQAAAAIAAYagAAAAEEHOQvYao+ZbZPn1xXJxq8e1S89mu9IE1lLq9AAM5xEWxcdY9w4ltzmn1Bu6zPI/7g==", "01c762d8-fc1f-4e6d-a870-157f332630bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f78c293-55b0-4751-8f90-baaad845a2b4", "AQAAAAIAAYagAAAAEIp550O7h8XRqFzXOy2pVJIptlPORUSgOiEjIiiB64pagUUtsctKs2Koth67kx04DA==", "2fce6452-2c7a-4ad9-9ffc-c5f270a07347" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a70eb47-b849-4967-8b84-778660243f76", "AQAAAAIAAYagAAAAEPcUh29dBsW9XLEX4GImoaxSTIWOTXB2pkFhnzng1XNaXElPCvf4xzeKbjlMG+uV7w==", "f9e73200-1aa4-4fb7-a935-f85417744981" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270036df-f24c-4d9b-93d2-78aaf215848b", "AQAAAAIAAYagAAAAEBkyXjc/H1vLIKJhexT4a6c/jYQbHaPQTGgnuF/ivyir9xZ517H4YVVb4ImNCV/Gvw==", "20a78990-1cee-44c0-94e9-3df4098f2d9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f72166-62d1-4bb8-b0ee-01deb26ecde9", "AQAAAAIAAYagAAAAEDGS1Yu3xkIo7ZbBmgN78t14FdSa9Tn5zdF3QR6sGexGbTH+JtEFTdp5F8LDttZ4XA==", "2865c188-5db0-497d-96f8-711f665d2d4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d33af78-02c8-453e-a16e-73e5fbd31124", "AQAAAAIAAYagAAAAEBhsCxJPBGPQ9c6Gf5WwG7HOEmdbdHG+BewAdiGYMTAKj0OtQxt+a2Rsf1VsuTv8eg==", "e7ea2206-a60d-40d0-b7b4-c072d54bbe01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b78383f3-ffa9-4bf5-8377-e951f3ce59f0", "AQAAAAIAAYagAAAAENe0Drov14Yw8ZlJad6HaWeFhxz6KnAfgQgKK7bP5QMb41URsXYcbzplq718mkPqLQ==", "01e3893d-bd51-4060-a151-ed623c4ff74e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49fc9bfd-4b64-4cad-a1a4-0616de15ff34", "AQAAAAIAAYagAAAAEIaGX5dDqedhBMM06JQhhoGrVI4TD0rtJ6u9COzhIyEGgyQKqudX9abX69o+Up5CLw==", "621a75d4-0dc8-4710-bad5-a0b2d5bbde24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9ce6f0a-8d83-4441-aea4-9613fb7ab600", "AQAAAAIAAYagAAAAEL1CzimYspr9ju52mbHozaiyPychquD0IFzt01WYkXsknMul6jqMBPRQdGbymb38Uw==", "7f3f7b4e-b321-478b-af3a-9889d5f36088" });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentCauseEntity_AccidentId",
                table: "AccidentCauseEntity",
                column: "AccidentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentCauseEntity_CauseId",
                table: "AccidentCauseEntity",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentCauseEntity_EditorId",
                table: "AccidentCauseEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_CityId",
                table: "AccidentEntity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_ContractId",
                table: "AccidentEntity",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_EditorId",
                table: "AccidentEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_EstimatedValueId",
                table: "AccidentEntity",
                column: "EstimatedValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_LevelId",
                table: "AccidentEntity",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_PersonalInformationId",
                table: "AccidentEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentEntity_VehicleId",
                table: "AccidentEntity",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccidentCauseEntity");

            migrationBuilder.DropTable(
                name: "AccidentEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b9674eb-768f-4488-8be4-ed87a297b47d", "AQAAAAIAAYagAAAAED5oUh0ErOBSZe5eJV+AfIeVLPBgKVNhjQkEksty4bI/dPMRbjTCGhlH7iwO/8248g==", "1b710c7a-db71-43c1-ab3b-3a201b28a0ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "786ffe98-d51d-4629-beff-0a3c634a2231", "AQAAAAIAAYagAAAAEG2Pj/I1j48zkKkkW9eX6zVCS/4r0Zg8iUCmKmuW5UUL1CN/E/bihdvKzQrNyVbVBg==", "d5e7d631-11d6-444f-aeb8-b76e90986717" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b12f7dd-3c3f-4d52-b827-0f5ba54e45f6", "AQAAAAIAAYagAAAAEKxAv+LJ7jssVrAc8tOcWnO/edDJcyPB5fzlZ6D1AewkDBz7bsCqHYflO8b6UNF1rw==", "8fbb4b22-39f7-418e-8ba6-8f0443b84c1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cc9a1f6-4f1d-4f81-9a3a-1bc3c16f216d", "AQAAAAIAAYagAAAAEFgXmGkS5qbsKty5yZXADevD9CQ/I7NOyPbXGo3cxh0lCVQl4SA77vgTvbrEGN4UWw==", "889f993d-6516-40d7-a3d3-5cfca8c23315" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aa41597-6e26-4d7e-a925-c671b1e489e9", "AQAAAAIAAYagAAAAEMG2Gef+ECbejJSqyQvHlDVKnTPNoq9zaGL982v5DtJESPezOIRN3MiLiPjus9tL+A==", "dcbe4ba1-dcc6-4b0b-9961-25fd8134a1d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7f0c575-1e4b-43e5-8073-2d3ba2cc1a95", "AQAAAAIAAYagAAAAEBuVDYsLM015Ty882j9xGajyicJ84iS1MDGPP01FawfgMRzIoVc7g30GDNIGUG0J3A==", "5c2c547e-3077-45da-8e94-158b626d0e53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f08bfb2-e151-4d4d-9e7c-cd9a56ed026f", "AQAAAAIAAYagAAAAEJ8aAchF3vqCpJkz4DNKDWYSuPM82FDtaLlOW0y/QIZOArxT6BMuezStgG/rdvMkRA==", "765bb418-2371-4eeb-ab05-55daa2a06251" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d334b046-b4f7-4618-86c9-939abc1cf37b", "AQAAAAIAAYagAAAAEPTnEr3t+MvVf6hkQ4B1EsPtHriDQPtcqW3YiPCXr5kHXy/vStpsMAs2CyA/cV5fXg==", "f0d73360-ffac-44d8-ba5c-8d51817e5fc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8448c8ce-68d7-4760-8734-71adf3afbe4a", "AQAAAAIAAYagAAAAEBkPzMOzPKTvr+xcpaG/wJpDO5H5p/a3ORfj1UAet6UN+3rxPRsO+kRnY6JXdGVw4A==", "36693f8e-3dad-46e7-a9f8-8843604363ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "714321f4-af3c-4a6b-9905-d7b7ea75e45a", "AQAAAAIAAYagAAAAEOpZVOsxmMOF8uJgEjh0gk+MYbrV+39lRgWyaZWXY64I2nsi+872Ee5aI7ZbnhJ07Q==", "7fc4e92f-b7e4-476d-ba64-67d966688d60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c977c511-fc5e-41e6-b8ab-ea27265c106b", "AQAAAAIAAYagAAAAEE3vY72vzyj9w8Gt2tqIaYBb3T5HxN+kTTwB2rkAn0UyF7LvZmRLcnr98nnF+BiDvw==", "674a790a-3b48-4401-8216-f082290cdf79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09985807-6b1a-45fc-8441-8fed4455bd2d", "AQAAAAIAAYagAAAAEBc7EMz+maWcrpBt44SKJUKR94FOTAH/PFqT/5Qv8Ti7l1WPrT9RMoKzolOjvAMUtQ==", "8aa6083c-15db-4587-9cc6-9ac3e519eeb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f082c02-a034-47d5-8b50-8aec141d0df8", "AQAAAAIAAYagAAAAEALiyI1LhuAQcI/z4e9nh257gWBisdflLy4gaX9Rc9PiEecQvOC+y9G2B0Z3lGxDgg==", "015beb6b-8f02-4f1f-ac87-9153bf02abca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38ade676-6e67-421c-aa48-f5a0af0ba1b1", "AQAAAAIAAYagAAAAEL6bNXliG7JrXxpH0rVAI9DHn78/FXxrSA5HMXxhvgwh14lhlKHoK8SucAFwJxFd/g==", "56821a95-5876-4997-9217-d8bd0f9468ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509d3b32-42af-48ed-9e05-4a3b4f3a59d3", "AQAAAAIAAYagAAAAEPYYOWGNnjWXfFvlaV23XHWpSbgeTDKgRxHbL5idFqZJLQ+1yWuf2H1NRXAZDyQovA==", "68b55938-42ab-4a03-9804-63a78181bdd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "481de273-bf39-4c16-a427-52dbabefcc73", "AQAAAAIAAYagAAAAEPX4vVdYpzP/t/UOAN6yWEQZ1GTyej9ImrzPvW03S7pmkPs2j0Ez1KyjGvJuasapvQ==", "40d85563-6256-4ad5-8082-a9f19846b1e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62a5b0fb-3def-4834-8552-f11b2b1e57c3", "AQAAAAIAAYagAAAAEFaZb1q6PciQUdmfQWXFuCy9v87kqCtMCF2JEF1c1NYed96ltbH39I59/CpJfouM/Q==", "41cd1f88-c3e8-4123-899f-29aa84a92574" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c89d7f5-efa1-4833-8e92-88e8679aa64b", "AQAAAAIAAYagAAAAECFQMalryUNEj9TKY/SGdroC1esPZYD/WWweJSAlLvdAkJovQ4lCv7eyD/bUzPadvw==", "0d0b60a0-ded7-4ff9-bb38-9d80f034a2c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b247e346-addf-4e0a-bb98-b216eff3ef4c", "AQAAAAIAAYagAAAAEGMl8vnhHUuOzUkQn4YT7uKSeV0h1AHAAxCdzvEJZtrrZMKfNdUL+a49QS/8e9s/CA==", "f83fe0c3-2205-424b-bc60-2fe2f8c3472e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a00deb1c-1afd-4951-b027-9e027a043099", "AQAAAAIAAYagAAAAEO88f9uhLLP68qjMMyzRubXlPeetttbLslQPxC7fqxa78bjkKbKP28p4qwkw8Kqx+Q==", "83310d8b-1b2a-45de-8373-bbf8b5b4a6ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "906c850d-9343-49be-b91c-907e4caddfb7", "AQAAAAIAAYagAAAAEAmlCvIAOtLuUqzRU35t5CmxMePsxXR7iDID3pijy6UAIsuR5p2G2G6H+ueTomZAVQ==", "c3e4f195-985b-4d97-a8b2-643e926d1258" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba6c50ce-907c-4cdb-9db3-35c8c9329921", "AQAAAAIAAYagAAAAEFyKSZrhnXdWqjmOyXQfff3mKGDyt4l4CXSX2CcPPktbtOp61zHphDMGeQDsha7X1w==", "83a8c603-c24c-4afb-9fd5-89ea90ba1fcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a4f005d-2b95-4b01-8829-6bb0b8347ea8", "AQAAAAIAAYagAAAAEEFoC+Vlp8djamdD8s1T+s4nFSuoFaSis4TKbhKbpanEDlsXgwwZOvKUCdnm7C9qZw==", "3b5277ed-d15d-4b95-b1af-57d83b7f826a" });
        }
    }
}
