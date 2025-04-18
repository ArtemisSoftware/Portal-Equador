using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_freashContractTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f967db9c-c9f2-482f-b853-e483e87e942d", "AQAAAAIAAYagAAAAEA3bbjaFR0eDRKbywuUiTmGM7hli0OhKCP3G2K3fE2NvrFr6raVJ8KIyEmLN32p1+w==", "d9191216-58b7-4397-88c8-01863b49be8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "142699a2-4cb9-4418-9635-0d1386fae1bd", "AQAAAAIAAYagAAAAECUq/BqAvuFYXXNtce+J6Du1WPeKGIg1LUNSGASyKDOlochWyCMFPVuY3x9yo0iv8A==", "98230ea0-c386-41f5-96c5-fd6beb5948bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a316703b-a79e-4cf3-8237-303e2972823c", "AQAAAAIAAYagAAAAELHgdUbrRDSo+Z2ipeATgRkowoOLM90N08iE36lDa9FQopKtIOCDwjzh3I8/RM2hyw==", "23daaa89-f546-4c88-ab4a-170a476e221d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aca3d57-1b6d-403e-86ea-84a39663ad7f", "AQAAAAIAAYagAAAAEIRG7z8NRFSFWoH327aHFQM8aTKLUpHAW+p8vHjV76IiiTvfGfEbMVDn4zGxghUcrQ==", "62be67c8-d4f7-42c9-8f08-68d9124a7b6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99b3397b-c904-49d2-8d2e-3ba6c12d9392", "AQAAAAIAAYagAAAAEMqZZ7uTS0R231WWpXHkfpwqJXbKpIoe+QJCKkDYzhEe7StOkeheX1Jayyguoy+0YA==", "82c6fbbb-fda2-4e52-9c2e-7a5c60af8b96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8080a3a-b26d-452d-b55b-b6a6f6fc3138", "AQAAAAIAAYagAAAAEPNYeNC2iro2qNSBb+wNbwB5BE2uFC50lEgtaWOsCebRPAYD4LWgERUsqHiLQFkYPw==", "1ae5d8ac-3ce4-45e2-93e1-aa177622316c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b95b2624-dbe5-414c-9def-d007070994f2", "AQAAAAIAAYagAAAAECPQ7SpfVExfbnBCgv9f05avoFzw+kQ3Y1irx1qdfcjrQmlHxIttV4Lacm5uScLChw==", "66910e5c-4e6e-43f7-a09d-d0132e2eeba3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb2bd411-6037-4b61-889a-e6db023c9c49", "AQAAAAIAAYagAAAAED4637xhoGDQbElhpWOsoTSAO96xhCr02h8/78puJG/F80NtrZF/W4s5B+WVTCVxdw==", "978829d0-4948-412a-b310-390b0aeacfa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2491a4e-d378-49eb-a004-da2d5a42364c", "AQAAAAIAAYagAAAAEPdzq+duY4mijo9+9Nu5elzjqX2yRt2UCiAhXCCS0H4QY/p3VH/2QY6CS8I4NzN5Ug==", "8f4914d5-c797-441d-8506-24fa0d46b622" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8790891a-fa8c-4fac-b93a-4d6df7fb241d", "AQAAAAIAAYagAAAAEAt+9QeFY/E53oXgRFI+R8uMaTinQLDzeu9BCi5CgEGBDImiHOlzRY5hOuRLxc2NuQ==", "8cbd3809-824f-4ca9-8924-c2dac9a93071" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6e30c11-30ed-4b8a-88b4-a09f91735a2f", "AQAAAAIAAYagAAAAEGWASkZf1vGp18WdLoZMBndGkscmXL7egphyMJhFRvcp4rqrm3fQnqkMapNdDaxvSQ==", "2320850e-86c4-44dd-9172-4861b710ba43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61a131a2-51a1-4dde-8e24-c7c48a6bbd2c", "AQAAAAIAAYagAAAAEHOK1cTkTtZC0YWcGJ0P0CV0n1YtPAs+LsHncyxDH7SzJcJfvQf4tdES2ioIzYaQpg==", "91b67494-3c9a-4fe3-8c3a-2780b0829da5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a519ab9d-b303-4424-85ed-c42d130e58d6", "AQAAAAIAAYagAAAAEHv3rO58n+RwsUJ1awT3IveXItIyRTXUFMxPR46+asbOowkkl0lNSokl36xaP9puTw==", "a2733732-fbaf-49a1-ab7a-54550e039f50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d14ae3b3-2c8a-43d5-9c51-163d16096cb0", "AQAAAAIAAYagAAAAEJU9/EfKFtRkP2ds6YiVLtBLrZFylXJ/DvUUdD+CYvFiz2hAxo4VSfAcZJkqbk61Pg==", "f52974e5-0337-4c52-9392-c31e11dfb997" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bd2482d-8976-44b2-9539-7713f0344543", "AQAAAAIAAYagAAAAEAWKOmSs9mBqz5SOhHuRrESse3j74Wr65v1+9xjuDgTw/QEJf24HRuyiKKJPREvcgw==", "db8362dd-6f94-47e9-98dc-4117ebdaf83d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64799abe-ac99-4697-91dd-5c67637e1148", "AQAAAAIAAYagAAAAEIV89aeKj2CG8QC7SERO+F9P7qPX2tpPkYs575XzNQf+7q/+dS3twp/zxvhqEd8Dig==", "8a8faf6c-8304-43fb-bf6d-b12045ffde7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afff4d04-849b-4b0c-a0c3-7259aeda96ce", "AQAAAAIAAYagAAAAEDo4vGT+XwjF4fG4hr0k91lPDoEdnc/LDrCOU04Pj0vDasJLYl4joGV486cWYSutog==", "862f0490-9eda-4397-ab6e-8d80c7b41680" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30b6eb87-cb80-4179-ab96-abf43e2c8746", "AQAAAAIAAYagAAAAEBLFIHz17Fma8ftwWHMdn4rbYU/DTYP5Wf2Uyqmoh3UggSr3T0SbG3MBuU7SmEhzQQ==", "634669d2-9712-4b2e-86fd-d1bb18b0ee5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ce8938f-5685-46b4-aa03-d38f22703a9d", "AQAAAAIAAYagAAAAEDjOxZ7rrDn+kjNr2gMryZb+8F0i9QlXKqlj118xOUh/6hHSSKL+X1UvJSh7qhGwow==", "937b55d1-cc16-474c-b95c-f29596f64125" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f4e7ec3-ee0d-46ee-9e19-a932eed9d250", "AQAAAAIAAYagAAAAEAl0z43VM9TSZrT+6HUPP0eepGV5IOdOfvof4dvI0y+5CF1F2GKb7nk03N1VYcKhtg==", "6243fd6e-fb4e-4c33-ae93-3c676bd4a533" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd2ed28b-e1fe-4b4e-9f65-9f5ba2f0be04", "AQAAAAIAAYagAAAAEIRAMwO4FtObEjkOVjvjTj+RiN7OKwInhxHS76ayhXXew+KTYszOSlEX1+0mTnCJig==", "39943d73-2f93-456b-8b96-41d597c8fa37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a87998c8-7807-45bc-b239-097ed4a93e36", "AQAAAAIAAYagAAAAEFhSwiOANTu393SRww0bR07VkK4UqoWkVvLWfPi7iHmYZRRsEJ35BiFrtAZezAs8Ig==", "d01c11bd-a18b-4a52-b7db-6a7a1ebacf5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47b0afc7-e604-4e32-928c-a459bea7f431", "AQAAAAIAAYagAAAAEEvJayi66PRmm44xuIky+0K5Oc/A/sB7lrNMok9qTw/uwo//30NovodHTJrM83lNgA==", "ff57e600-ead1-4f08-920a-a03c74fb5a59" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractStateId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    ResignationReasonId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ContractStateId",
                        column: x => x.ContractStateId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ResignationReasonId",
                        column: x => x.ResignationReasonId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
    }
}
