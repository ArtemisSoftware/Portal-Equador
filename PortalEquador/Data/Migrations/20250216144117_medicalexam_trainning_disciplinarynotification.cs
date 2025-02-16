using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class medicalexam_trainning_disciplinarynotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplinaryNotificationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccidentLevelId = table.Column<int>(type: "int", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryNotificationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaryNotificationEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AccidentLevelId",
                        column: x => x.AccidentLevelId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DisciplinaryNotificationEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExamEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExamEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExamEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedicalExamEntity_GroupItemEntity_ExamId",
                        column: x => x.ExamId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedicalExamEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainningEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainningId = table.Column<int>(type: "int", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainningEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainningEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrainningEntity_GroupItemEntity_TrainningId",
                        column: x => x.TrainningId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrainningEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57164f57-32f6-49c9-bea1-0610c3f01218", "AQAAAAIAAYagAAAAECKoYYmqEALJhTQ/6hkbW+LoTgxFA0QDB5sD5GKD/ONXqr48Y0hbQIs4jiZo/CF4vQ==", "f1f5b03d-8ce8-453d-b129-b6711c325b7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1393f78c-fae3-4a8f-a427-b3d110f2f7e4", "AQAAAAIAAYagAAAAEIeybxdyq8u+rWq9AqGarU8IHBSA/PoHeLQ14M1GET6k4JSZxYrky5f6Er31DR8GFg==", "44f2fb62-f77a-4022-9d2e-5865a26ff14f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "167cea8e-98b9-45ff-bfe8-1ae59fafb00b", "AQAAAAIAAYagAAAAEAqmKi39j41G73G0D72eOWLsyFzDp4SHitFQzxlyGl8PzmnQEleitqCivLAY8VaFCg==", "096fa5e2-b747-4e27-9008-858f30f59416" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fab7d227-cc50-4b2c-a50f-8c4a5eee15a9", "AQAAAAIAAYagAAAAEAz4CB9xHVfuahvlvkU1Vdljcbrg2SB8HXQbe/fjVTcLMF56REi26WiRi/bS+9IhaA==", "0db0e6d1-eab4-4119-9a8e-0a4405d4c69e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3575a819-e277-4229-b981-a0b88f617f4f", "AQAAAAIAAYagAAAAEI3JtczHgsLoKF4B7YiTFMRn0Os24pCLp0Fvy0R1uGXKAq2hS2b+M/yfi5dPu75sBw==", "1d17f27c-1a93-4a40-83d1-454c613c44cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aff2e432-dd52-4729-b737-da0a6c7139f5", "AQAAAAIAAYagAAAAEL5gNTHvS+ajRP3M5lGOC5RbQbqv0ZdCuJkpxmNpkkeCp6i37R4SiEWh7I0+yS3o3g==", "58e0dc5b-f715-4e0e-8ff1-3a651e34637e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc18d458-8037-4173-96ed-a25a86d2c3ce", "AQAAAAIAAYagAAAAEGhERqymGGW9jfyIfpTJE1ILL9H0aYLfwL389ETPxfgqXFwAu/RztemDBl4atvjLmg==", "39ad7460-9f89-4f36-a3a0-519f27ac0e01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18ea06d7-02f5-49f7-b3e9-f9570cf49bf8", "AQAAAAIAAYagAAAAEC50eeyMPNU+icH5o1mT/Zv0wJ+i/26u903OoVySJtrtrwVQ3b2lL1Td4oksz8bvaQ==", "100e3337-b862-4e00-8fd9-a294deead4cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6df5a6a-4661-4e23-a034-2213ef1a9bc1", "AQAAAAIAAYagAAAAEMEBQ4paFtrFQ5xYICdn5GZuHDVuiF0ur5mVSfInWbuu85rTXz1TWTyrr7zExuQQzw==", "f24cbce0-af88-48e1-8ddc-ac603829919f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8e0a542-71a4-469b-b412-a871e89ee139", "AQAAAAIAAYagAAAAEHj9IVIJZ7Jujx278gV4tLl1+v1Km5LbNgvsb7VacTjU5tsHCvGSZ69N01mbcmv08Q==", "7a0eda55-e882-4669-8078-2d86a8520e37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29836c6-19f9-4cbb-ac9e-6ea2e24a130c", "AQAAAAIAAYagAAAAEFJg5xeSdEFS/EwaPbggy8UwTxHPjoOc3kF3bx1Si9qFJw3bJA/UdbTcqbqtAPRkxQ==", "fdda0232-44c3-4200-9f12-814710fddffe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90c5324-98ab-4a5e-bd90-968da193147a", "AQAAAAIAAYagAAAAELc1Y1Rwmbhz912gN5N4NfbXTz1MvsnAK3BERBS/EwtRPZBIUVwGFSEXjFwG4n9DsQ==", "60c292ed-75a0-40db-88c4-b5db49afe3f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4efc4c38-351b-42a0-a499-29351d684c6c", "AQAAAAIAAYagAAAAEIeO5v3RluCCtljJJgT/ab+YtXpwoKN1y6LLz4W32wk2vcbmUTWWfj6e8UJSeMgBZA==", "5f7628fb-920e-464a-896c-807ed42db2fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f21b141-1f80-40dd-bce4-846ed0422d35", "AQAAAAIAAYagAAAAEDotACL2Y10zta95+qqfUteUSrPXCkNN+LUx1mnWPRxj4mAtpPQ1bgkyamqlic3oDw==", "ea1bc8e4-5609-4556-8e7d-fb928b8b190c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a05a553-14b5-48bc-9a03-0cf59612a80f", "AQAAAAIAAYagAAAAEOh/QZk5KFMMsrDspObrPHpzkb62i5FjU9FqUZKmHXXvIQCLZc1YvQe8Gfia9uXwJw==", "4f0d9141-5817-4bff-8b4e-1c8d8cb0b1a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41dabbe1-b702-4bf9-bbd3-6685548d7c41", "AQAAAAIAAYagAAAAEGe6xEQaJD2tLy/Ch6gQZhj0F2RRhtWhBgdGnnjboRCyeDRGuJdwjqWJ268xhvZm4g==", "211be758-c5a6-40c8-8719-cf1a231d98fd" });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryNotificationEntity_AccidentLevelId",
                table: "DisciplinaryNotificationEntity",
                column: "AccidentLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryNotificationEntity_EditorId",
                table: "DisciplinaryNotificationEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryNotificationEntity_NotificationId",
                table: "DisciplinaryNotificationEntity",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryNotificationEntity_PersonalInformationId",
                table: "DisciplinaryNotificationEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamEntity_EditorId",
                table: "MedicalExamEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamEntity_ExamId",
                table: "MedicalExamEntity",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamEntity_PersonalInformationId",
                table: "MedicalExamEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainningEntity_EditorId",
                table: "TrainningEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainningEntity_PersonalInformationId",
                table: "TrainningEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainningEntity_TrainningId",
                table: "TrainningEntity",
                column: "TrainningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaryNotificationEntity");

            migrationBuilder.DropTable(
                name: "MedicalExamEntity");

            migrationBuilder.DropTable(
                name: "TrainningEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05916715-8356-44fb-845c-b1d8993ac227", "AQAAAAIAAYagAAAAEMUzEwF/cGNYLj77y547lOSVB6K08+xb11FFRVTAvmRT+/fZoX8fjTHEOHPNE9BeQA==", "15fe569a-d501-4492-ae7a-b580f3f3ac9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "001defb8-fe65-44f2-a9aa-22e437b1e69d", "AQAAAAIAAYagAAAAEOyK78rCsbD+3KwCCRpiEZXe2sGpuB9KTSJd/D7MyAYFVFkPikQee2X4rGe3JEeNVg==", "5a52e7b1-52f4-494f-8d8a-8e5111666881" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36d97d25-b18d-407c-9a21-78a361077f45", "AQAAAAIAAYagAAAAEKN41oqaSka//Q+wY5qP7X5fbw4DKps3MqQVOAbpOAfdZ0wW2Lt72BhA67J3OzBWbA==", "86b26ee8-395e-414c-a60a-ae2211a0dd43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d7afcc4-3466-42e3-9a29-c2ed345cb83d", "AQAAAAIAAYagAAAAEHEtX1NWPcw25ub6d4sBK5McHICaEBou2N8K5jXYvD7UbKGsvKngRYSeIn2ta7vB+w==", "31e667d8-b9eb-4829-9e26-8337a437f77f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03025b15-f5b6-4615-abf6-da95a63c26f5", "AQAAAAIAAYagAAAAEODBsQ/x5OX+OZUtOeUp3iVaRfQnrcQcQnAurXfP0oVgsoqMdZZlgvFKCgPIzifJFA==", "7219adfb-f1fa-4b57-9f9b-cb17c1757089" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a98bc73-361f-4348-ac8e-188021285cc4", "AQAAAAIAAYagAAAAEDCJ8x+BofjoOhk+iI0SrMTmVYnRXMDuovzxG9ZxQ0LN0e0jUtBN/Rs0Tze8XX9WIA==", "fa1f4f6d-6a74-432b-93b4-89b4ebc5300b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64f2420e-e7c3-45b6-af4f-7930fb873660", "AQAAAAIAAYagAAAAEL37juexJPvgYVqSqrZPAfCx0SovWUpq2DibAdmfmwuu0Licoy1cfkxVqmOWydhzgg==", "b4de6d75-bc0d-4b49-a0af-15811586a753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4fb637b-90f5-44d5-a55b-a5d3b4976554", "AQAAAAIAAYagAAAAEC7z/z/s/tbQahJ1xqz8b/w0G5Vw8cqBM15Xs6ALRj75Dpmyzg9xpkAq4v88FFyhsA==", "0b8c61d7-1924-48d5-a7c5-9193049e585a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddb0805e-d253-4db3-83ee-b4e16b18a13b", "AQAAAAIAAYagAAAAEBZrJ3UQyLx9WKQyOO5WItUgRexQBwigPxDoos2nZSxV80AGyyCRMMXyOC0Yey7E/A==", "6e670717-8209-432b-955d-bcd20722828b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "351b7664-ab42-419d-9e33-308269eabdde", "AQAAAAIAAYagAAAAEJT4I6M3MhQhbLpEETST5fUNe+BATAnw781rbBqgRIbg4s/CLJwOwLH4YV534M2ArQ==", "e71d959d-ee3c-445c-9aa5-e28d3dc8d58b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2e31afb-e29e-4cb1-a994-53eeb75db6ba", "AQAAAAIAAYagAAAAEGFkx5gXr4Pgs9h9rVz3F9N91wkB4QKWAmTfyZH6reVhp5eMcwVP++jwP45HicZwcw==", "0534e9de-5f88-44a6-afe6-1a51c07e7534" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3a8e0ed-018d-4f3a-9f9d-92289e3fed89", "AQAAAAIAAYagAAAAEDO/VcWdAMbcismrTJmnwh1TLOKtQJJSEykkYaCN9s8CN1jZbmhyepQhp+Gpb+V/Ew==", "2f247b23-9b82-452b-b58a-b62c61ba7edb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01cb462d-51e7-4038-bb73-7717c0d1f013", "AQAAAAIAAYagAAAAEOObsE84Ac+SE1YVScxixUN9pXt/0copH7tPjToY1RJS1YHZz84IqATCgkFx9Z38ww==", "ff2e35a2-3acc-4377-8942-1a53a04c9aa0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7867621b-a75d-4431-9b94-41d2486aa2e2", "AQAAAAIAAYagAAAAEMS/dCsxQBylx+DvzoYS09lxs4XWYty0JEnIZWY4U49weX/wN38bMklS91aTXjDsLg==", "805f98b0-cdf0-46b7-82ca-548edfa8c932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c83d1ce4-813f-4f00-898f-0ca767026e5d", "AQAAAAIAAYagAAAAEBQoi+ZqfFLTTNaj7cuLUlpy0xe9LvB2CXpUEf05FHNfvmC0udrqNbMAFTTyeRvtgA==", "733fc68a-e2fb-4c64-aeca-09e49d82b7dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8155cbc-0dd5-4238-89da-fc4faa41e24e", "AQAAAAIAAYagAAAAEITKps5ScauCdiMkBMShDS5S4+kUX5sD/fWK66clmXf+14pJI+z7qPn4Im6qaqOu8w==", "7998768c-c54b-4c54-b03c-e2cc5c1bd558" });
        }
    }
}
