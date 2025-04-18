using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class freashContractTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    ResignationReasonId = table.Column<int>(type: "int", nullable: false),
                    ContractStateId = table.Column<int>(type: "int", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ContractStateId",
                        column: x => x.ContractStateId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ResignationReasonId",
                        column: x => x.ResignationReasonId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractEntity_PersonalInformationEntity_PersonalInformationId",
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
                values: new object[] { "ea3a58d0-f458-45ff-95f1-fda5567505f2", "AQAAAAIAAYagAAAAED4h9cfZcq3UJw4ViCUswbGnyiKMowFzG06z5konukICf9/KP5lqt85AP18mFxm8zw==", "e3403e4b-983f-431c-a4d7-a362cf6aeb1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5428794b-d359-4578-ab22-3031caf28c57", "AQAAAAIAAYagAAAAEN7Zv4Xphwq0A35MVZH3Hrp7FEU+ie4iLYTUZFWKCi1h4JcfLfrl6tpbugl+sEX0OQ==", "31000daa-8000-454d-9a57-17dca552d716" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2620fb-dfe7-4ee5-93ba-3374b20490f9", "AQAAAAIAAYagAAAAEGlDnCg6zlRsuVP6ztbvmCGVVX0UpaRdSt5HUTfnaDkBQN2tRiKRJzEy9k7TxYuRCw==", "007f8883-5a79-4da7-8799-907a9a51e639" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d76bd83-86bf-418b-a1ee-c4ab9525c29b", "AQAAAAIAAYagAAAAELO/GW3U75xIkal9NPoMjSe1rn2xjHmiCmPRx8ShjdEMj3dBFwL6D/JXbEFy+so2YQ==", "1d0e87e2-4a98-44a0-9748-0ce94c88f25b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "303ddf4b-5201-470d-9e8e-fdf5c8e8048e", "AQAAAAIAAYagAAAAEBOwBDjDjrs1yM4m9sgM506QLpYeR0GRonnk8+AZ7JR/R/NrHCbRfIjYzwQylEhQ0g==", "03da9920-388a-4c47-afc9-8a88d5213e66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f324cdbf-2b5c-498f-ad02-45818d3599d5", "AQAAAAIAAYagAAAAEKxrXg0HGSZ1UzKyLqSQl1+IMIjAcsMqAvRuqTvmJ0xSIFgi9bb0PDSKTxWlm5UL3g==", "09f546c4-58ca-432e-86e2-bc4e8bd7a937" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "196e5580-3778-4581-8294-c58243386481", "AQAAAAIAAYagAAAAEItH82FqKpf8RJfc4LbXsbOs5j7M3oM2xY94PN6OzzqmQgbCJthJD2syX8z7ldljBQ==", "64c8c502-f569-49a3-9294-dad1066f0d38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e8bf2a-1741-41da-9253-682f537380ed", "AQAAAAIAAYagAAAAEC1xo7cGJL1FDO3bou/wbMIgbU9HSPSPHAO2yo0O6tJx3abtRrWllBDaHVvHBgnqXA==", "b72be10a-b4bb-48c8-967e-b075bcf20ae6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "644c8e8c-5c41-4bfb-8b5e-6b93dd3015e7", "AQAAAAIAAYagAAAAEGZYR460gLMDXnbUqJLhe79RZgEUr4aACPV7ccKIXVUYzspfJv6mw2B6umLFkwJ1YA==", "30017447-c3e2-46b4-9b9a-8979281d9aa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d28166-7903-4fdf-bc5d-c9e420dee0e6", "AQAAAAIAAYagAAAAEC85Y5rR5+rwn9NLvGNLC0wR525L4vK+rja8PEz0A1cufo1aDdgXoxdFD9qC3r1/gA==", "9de44622-4717-4194-b587-4be174ad9bd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ccf5e0-a352-4a9d-86c9-686b14f8768e", "AQAAAAIAAYagAAAAEOx9zUedOin/yQSee0Yr5EqihEeVKT6/RgsaaQtpLPjv4oJfySag0FOlDrA4YmIHUA==", "ea5667c6-60d6-4a99-b639-50cbb4e8c4f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3909b26-032f-4457-9dd9-475d4a08cd06", "AQAAAAIAAYagAAAAEEnYlXgvLS2o0URWHYHuFgzsAo5itSh6miDjHFd2FCB/sUqCmIb4d/gC6iZylkK9YA==", "3307e859-660f-4750-bbb7-9de02fbdd203" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de685486-bf30-4f34-bd97-b225f086edb5", "AQAAAAIAAYagAAAAEMpaPIL5pZ7rxyWyCDJKvVNEO/mKOD4ukqaSCvfwS+FNsVmYzEYStpClRs8qLb5KTg==", "6604a3ca-c7b8-4d42-9553-b9192cb0bf41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "829ae2cd-ff43-4dc8-a210-5ad8747bf925", "AQAAAAIAAYagAAAAEJyzQTM/3/e3/zdOCPAM6Z6Io0ZDSP1t+A6qo1+zxPcPVYmdu9Us9ncJm+vZukrr+w==", "ddfe4440-8e7f-4cfa-b3ac-95897b576b06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "642fa5fe-09fa-43ec-8eac-e606017ff2da", "AQAAAAIAAYagAAAAEEWDlpfNZFuiBryQF6jb3ftmTEmzGym5a/K6x3zw6LV03eIA09vvs3ArY/2niyKBRA==", "a85a4116-a506-45d1-9579-54aca19a39b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acab66d3-29c1-4497-837e-b60fd7712bd6", "AQAAAAIAAYagAAAAEB1Kx0tS60CJRS1TEhOkXQgovASN7YnsGkma/8Rc2kExoZQu/F1Ro0GTcl1X/GoulQ==", "418539a5-de98-4833-907e-f82530e62486" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8b340c4-2445-4791-9059-d7247e03381f", "AQAAAAIAAYagAAAAEB/jobxXlQmn5bc+8CmZ7SsPJswxEoJ1hHyDiA6UFScXODArBb4WPfoyU2V/AtiPDw==", "fd913a3e-e499-49f5-8b58-3bf2d8d6949d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8034e386-0a30-48ff-9bb6-104ed536b5cf", "AQAAAAIAAYagAAAAEDENdQTB9WapVmGWzasczgy1Sm4wPk8nqFGlCHGbXVCL+MYaz+2zaDkcYuBAr4q/mA==", "86ff5c62-1520-46e9-b4a1-057ff090e525" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a25e16cb-2c5b-4fd9-a1c7-3650b212f1fa", "AQAAAAIAAYagAAAAENQ7Mlgr04k/3VqsrID2a16h2ORQgJJHTUKUURe2YvZX0+FVCJX+lbAEgzLnW/NJfQ==", "6a4e0a4a-1b57-4324-b30b-3339940393f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "498589d2-2773-46ce-8947-ca455bb1e31d", "AQAAAAIAAYagAAAAEKMdNaVJIzkgh3ZQjet1rJUgb8Sqt7e9RvhJ7MwWjDV3+P+WwpA00pzTqGNQ5V/fCw==", "fd9a8ea1-806c-4c75-96bf-1696ea5bd3d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1adcf8ad-eee0-4d10-b6f7-08bea6206d6f", "AQAAAAIAAYagAAAAENoA/ggGw9taS6352ZR8k9dQdwS+bSlvbxke8+jQz0V0/mb3vqQvkax95Gq7QBGGBQ==", "dd61f2a0-d353-49c2-a3a5-68f85a4e8d30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e46eafe6-4e75-4efb-8025-23f0fda2b5fa", "AQAAAAIAAYagAAAAEJ/KgdbT51wco8tu8ndKGvqGgqqsAALYVyc186vxUnPpfkrL/RYhD32A50A5TLPX1g==", "5c04dcf1-bf08-45c2-96d9-092e4011aeaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3eb735a-c68c-4a6a-b953-39b4059cc4d6", "AQAAAAIAAYagAAAAEDY3dysNG05vM30VTahy2l0J3wzOSAsZwovq5sbrGrjQFdWaJ06usiPE+nT8rmY7Qg==", "6d8ac7d5-27e2-4462-9d74-7608b7ec2704" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractEntity_ContractStateId",
                table: "ContractEntity",
                column: "ContractStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEntity_EditorId",
                table: "ContractEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEntity_PersonalInformationId",
                table: "ContractEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEntity_ResignationReasonId",
                table: "ContractEntity",
                column: "ResignationReasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1befdfc9-365e-40d9-a9b5-bd71478a8f2f", "AQAAAAIAAYagAAAAEPf9rIzYCNiKXsQttejPM48a8RS24mBvJZeb0imq3s4BcvTrj26o77jckEl60s5Oyw==", "9eccd48b-4663-405c-bfa4-66164592c53c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c51375bf-52c3-4ed1-9b27-d62105cfcc2e", "AQAAAAIAAYagAAAAEO11QofiJ8+IHzDhsNy+mbUY1Wst57IBO56xfRjSvxVmZhX3PytQIxBwuSW26Zdlmg==", "f09f9d91-c0da-4e88-9ded-2aed4847c716" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ba339a6-992d-4362-84e1-db392619fae0", "AQAAAAIAAYagAAAAEJ6odDbDXbmJyd8OpvDDaEs7lf65vKUqeIKS3LwLB/APCwQLC4Xm17tIl8G68ybgDw==", "40ab72c9-4015-4e1d-ad88-5946cfc1088f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "751366a3-5905-461e-89a8-f9db5abd6861", "AQAAAAIAAYagAAAAEO/K7kWFQXIh/NTptszmL/BhHynZT+c0oSxJmEeRRbgu70uPUVYDXWbhWf49GEp05g==", "a1ec2a9b-68cc-4eda-aee2-74b350bdfab2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37ad5e58-72aa-455f-8f50-987c614f2115", "AQAAAAIAAYagAAAAEC3WcDDW5l1LtN6xH1tWY6PQw1h7lULsfT86xqywOMMu3SgD4EyAt90yV9e92xN5kg==", "5aa75607-9d89-480c-b7f1-565a7c5865d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fc3b69c-33c5-40a3-a7bb-70fed2348115", "AQAAAAIAAYagAAAAEPH7tPEjMPRXpk6ixLQubmIRzp0m+jnlQ0Fg4/Bl3+tT7tn1Ai4NEiYBktlKgPZBZA==", "8e72ddb3-b9ab-41a1-bd04-a97251a54165" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe946da5-c755-41a8-9290-efd4db90d9bd", "AQAAAAIAAYagAAAAEA79aIMIwqptL5ITcI1bUc76B7Lq1Qj83uUHDpdSyj6e7TEJmAYIUaSPY092FLJ2gQ==", "bcfc0d9f-8f33-4f59-9490-e6195eb3930c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fe3a370-81d4-4881-8805-a88545fdd460", "AQAAAAIAAYagAAAAEB0ZLvZBCAsZfrHPJvICt2gd7PRF0yMG9/Q/TjWWBS+o29VmpwPblEfTTaJ/8s5iUg==", "e74530fb-5850-4189-afd2-538840b7676a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70980317-41c7-41c5-86b5-f1542ab1776c", "AQAAAAIAAYagAAAAEJKqUse90zm5/Kj3uef3ic7I1dkM9L43FD01/cGvneHQCrnaZtA8cH6Yh4mNDgpcLA==", "54793422-2248-46ed-876f-7c2eea50f233" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85396d3f-2ad7-4417-959c-4f8cc6685789", "AQAAAAIAAYagAAAAEO5T3rHe6jlQuTYSUATMKLneg3Id0+/Tt4+PwKsbmBbgFjNZ5l0lMM1QyZZuS37Yyg==", "1baab4c1-7e08-47bf-8985-a689b1bef8ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f1eee6e-9880-4118-aa09-d94467d114fd", "AQAAAAIAAYagAAAAEKfY7gP6rPVQZ2km9c+FxQ//9ISk743LOMtPMys1trutbaEhLLlwlDcYXdxfPoS0Sw==", "d6341290-feb0-4fa1-ae4c-2f80fe3c90f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945dc311-1978-44ca-8e93-72b83874fa38", "AQAAAAIAAYagAAAAEPOP/H8fs6gH0h8s9EyDtIiZZOfYkHSp/EANUClSOP/bnQ5NpCw8zY38tW+2h+apvQ==", "22f43928-798b-4895-b6a4-970d626c4d24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "178718e4-beac-45b9-b510-839e85fba36a", "AQAAAAIAAYagAAAAEFvGJ7+nXHtsp5i3Bv8g/ALQR+KmjXvZ2vkj9sJiFA274lTfic3HAZZOz3L4NxRHFQ==", "5f17de43-8996-4dca-9318-5ac27a5b90a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9f55adc-4c21-4ff7-ac2a-534d10610015", "AQAAAAIAAYagAAAAEFEwLcRjpdtxZ/w+clbZ7tjcZRDJeYBO/tSD7QO1vGq3ZlQAaxLyV/ANkcJwbk4IaA==", "d539592b-f95e-4605-938e-2c1bc1859932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2feb3117-88a8-4138-adae-0ee9977fe6a2", "AQAAAAIAAYagAAAAEI7oBJNkg9LZ8nrRE/0KG0RpSBrBCAOVrMh4KJHM+xfh2Brk8r1zn1nAieniVV9s4Q==", "2ac9845a-3da9-4303-a5b8-e460369a4dd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ecebc4e-1aaf-4324-845e-3f1dc2453936", "AQAAAAIAAYagAAAAEAFaNi7YL+HuzSMBCWvnUr2qP6WmqDUl3CC6I8EaY2w/PZlV0dF5u2ofecNkYaasHA==", "74842759-5496-443d-93dc-0372fa463c16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "572e4dd2-9498-4508-bb0a-e8e54fdfae9f", "AQAAAAIAAYagAAAAEJW3UTXQqKnje5B5hFQJ6Fsd7o+sUR9atXaskCNYTPXLSguWQyB/+YGzOjGb0RD8tA==", "6d516ced-45e5-4ef8-86ac-3d31edf8324f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8aaaa49-ee16-4bdb-ac3a-e5be59aa6d11", "AQAAAAIAAYagAAAAEE7IqKfeaKFGhT4HjxsitbXei60ObkYqBwqPN8mdkQk8/ZTUQGP62zGXkg/oGlDo8w==", "29421661-fd19-4641-bf57-12f46c81618d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d9b5f2b-a95d-4835-a96d-599e26db9cf7", "AQAAAAIAAYagAAAAEKOXDHWmgLsesI6GOT/1FMBcrxls7R5ynZON4f/37fr1qEyND/roA2CUogC3+NxfQA==", "9fe9e1ab-4f41-46e1-92b8-a5502921a0c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb179739-8542-4fad-80be-2e40e7f34f23", "AQAAAAIAAYagAAAAEOZ/RvrjoqF3ddlzMUsNXzE2LuJtZV6zJ9dNwMRQ4c9bUVTeOo83K7X48de72mIcgA==", "b98d6ce2-fc3b-4752-9ea4-eef0cf2b1ecf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01814f9d-d000-4c2f-80a9-d058eef79bd4", "AQAAAAIAAYagAAAAENnpZ22Hxb6YFElWMpYjOTd0/f4n65hKj9CVBNmSoHDLwNlbJP+wN2QzwHL9SdTGbw==", "1a06e876-c5af-49b1-b50d-a0c7ab3c23f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cfcc74e-20d4-4bae-8d8b-7444ed0d385a", "AQAAAAIAAYagAAAAEPZ66alaxBMMdlxQRqJBpN+olwaELxGZ6AHUMCdWNDJTpvTWE9k49YQj2nXYfOlELA==", "09626b15-b8b1-4790-9be4-7e7f6a77c058" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03fbd13-3843-4282-906b-6ff81002749d", "AQAAAAIAAYagAAAAEPYnZRERh1jHOYAjVajJArKkSsAZJskKGb3PA3oHUEHkgSW4QyjZ481SS5+h1SLUMA==", "a8387246-261b-46d7-990f-4ad548847cb2" });
        }
    }
}
