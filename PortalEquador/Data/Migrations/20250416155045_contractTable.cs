using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class contractTable : Migration
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
                    ContractStateId = table.Column<int>(type: "int", nullable: false),
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
                values: new object[] { "d5a25c72-5732-408e-8e36-635d8638922b", "AQAAAAIAAYagAAAAEOQqTtjrAuHdGTX3LYVsJTLH8QwJSkhKEZJfhWzsi+URaiiAJVTM0nmaBCek5VebYg==", "d3ce5609-5825-4b02-a19d-c2752bdd5d0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8caf20e-0e60-424c-9ac3-02e60f570272", "AQAAAAIAAYagAAAAEMxEjAJxt7LQav1DblAvVQ0gcYQp2ntZ+RWR+gw5b1fBmYk/3b8/wLzvLef4ILSgPw==", "0cfdcf76-0066-418d-a310-551399d8593d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3563c230-9214-4477-87d9-10ab2f0bc983", "AQAAAAIAAYagAAAAELgdDrQwRb4iuMetxF3AFRUGl+y+e6cxXES+a7nqgeTwi0oHzS7NMKb+W3VoMIELUQ==", "ed11ec5f-a713-4a63-9dcf-ed26e4c2b532" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe9cf271-7ee1-4c6d-a423-bbd2df683722", "AQAAAAIAAYagAAAAEFRXAa6UQID9mUX0i2a9mDOUPHb3IOgF7Prn5GjfTamDvKEpdnz1Ln6gbKyE5Eu9FQ==", "424fcd9a-f815-4040-b478-bcc1566fa482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19921de8-a5b1-4de9-b0d4-f5bd8dbd86ca", "AQAAAAIAAYagAAAAEPKVvxe9B9yaNzufC+B00KIH0Q4CBRsVSr/i/B7zn+1DQNQcm958IiIl4CGD6vK4aw==", "5fba3058-1c8c-47c4-9165-65a24a3a76d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "598fe6e9-9c44-46e0-a9cc-7b1d69ad064a", "AQAAAAIAAYagAAAAEEZeZD3c0XcBxw4Nb+47USp5C3uL6tRiKqdyuvXVT23+kwBjdPSrHEbXw4M0H0U+rA==", "a823ee3c-667b-4cb7-a7be-70a8305857cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "258a761c-aca3-42ea-b067-e43e7896ea48", "AQAAAAIAAYagAAAAEDSHbNFVlP8fl0dwKg5EV9uPE/peAnwpaP8u8PFmAwym3CdQhs7XEpDGJ/1wBywG1A==", "8b69119c-6354-47b9-9334-bdc4f00cf038" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6d5c548-84c9-4be7-ad76-628cd5ac164f", "AQAAAAIAAYagAAAAEJSPxmYuBVx0wO2/FyAKa7KpzEQHcUTPwAD3tu/fhw4tpBo5mcJVIRKMTtQVdl+LOg==", "9c8f3cee-e77c-4ca2-b71c-f118cc40cc15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dc681ee-e9ee-4d81-a65c-996737dba049", "AQAAAAIAAYagAAAAECiOMBjgvACOda3SNItyG7zITdhkIQHHwiqf43gEPQZJOYov0EpimhbjlFpD5kxzqw==", "b6fd6a01-08a1-4f6c-ba24-0844d6a636b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc3fc61-98c5-487c-8ff3-22968fd68f2b", "AQAAAAIAAYagAAAAEMBjOmvJdK7kst0rqwoZ+OGoGoFXBmfvectcn6nfi6WLeCWoUS/m6qEb0amsZ0fU0Q==", "f017fe6d-0d6d-4f01-89e6-ea6798a23779" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "308cfc17-bf91-4011-8ea7-c25257d3dd7c", "AQAAAAIAAYagAAAAEK2gVfnb0xYUZZmSaUWGyY0rAu1XzpB2sjCMrRuPstFmiznNW+wsVEKy/QJEwsg6XQ==", "bfede184-3f1b-4c93-a1ab-eb59c34e5d96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d86abed4-f9d7-438d-b9f7-b41e235f760f", "AQAAAAIAAYagAAAAEFkBFdMF7I5/giYLuDiEb1KN3bJPuoIyWVrWedco2MOg+2sWUmrYS8NQIWxMGcqoeQ==", "cac8d366-a072-40e7-a93f-7f37382d36a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f74aeb3-cf38-4df2-9721-b8b786bc0ad1", "AQAAAAIAAYagAAAAEP+7iA3EmKn5jE3y+NJdodEuWON20TG4Tz9AhwfABe6U3yhJIA+bOa8HTthSsY4JAw==", "7128ba0a-ec62-4111-b807-401aa78f8cde" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce0872c2-bc06-4fcd-8452-6e317d7bd188", "AQAAAAIAAYagAAAAEPSLafj3+AjNHlrQYm/LMn0JYVdOMun8979zHK/tFaFkSLN0eIeDaAoSMqRXsF54pQ==", "74ec5e95-c09a-4052-bddf-e4ae7d6fa55a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b7e659c-3638-474a-a410-5fe319476b4a", "AQAAAAIAAYagAAAAEP+T61SVTFzTLP+oe7xysJ/3WKRM1ddetIpwIL0CDR8OLz8WDDhgv5v+XJDF8i2T9Q==", "c8325da1-13e1-4386-aba0-d2565a1f58a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9be02af7-04a6-47aa-b7c9-9b24cf608629", "AQAAAAIAAYagAAAAEIPnOnSN8BhflWv3s8iT4aSbBIUwadzY5t34lZJbjxoBU4LGqMoyeOdzRyvDts7Nag==", "f4d30a78-9d1f-44d9-919f-984910238d33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f955d20d-c0a4-4dda-bdf9-f15a8af7e0e4", "AQAAAAIAAYagAAAAEBTaekrLReTXI+h9NcTrVQMjo8OXENeflpmROK9iiUdKDPWSsxXAjURtC1poy1GDog==", "72df68c4-a881-4cda-bd68-c0f8c640488e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ba04df8-fe48-445f-8f7a-ebc5057c9c40", "AQAAAAIAAYagAAAAEPQURPEJabQwAyQCchRKHrCObanfi9Dt7id39b4fVcy/vPcZHZ2J/QxF/F0looZDyQ==", "d486fe13-97ce-486d-b95d-476587f7e9c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9113c8f0-863d-4d8b-b0fc-1023ab128de3", "AQAAAAIAAYagAAAAEDZpJdWzpjlvTOe2haTtfpDsrlXtkjyHh7qmMyTNzYhQme23mdf9c/snoCXGeoKY/A==", "768e6e39-aba9-44e7-a7d1-ac4b015cc223" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc2a9868-4884-47fe-8ee5-6c27542bccff", "AQAAAAIAAYagAAAAEIJkUDRDLYQvEE6BGW8mCUw9uSujSylqjlE0B/yJ4zkOnN3X8gQwRB9UNSyOUazbrQ==", "0cb55bc1-a212-4600-b02d-059fbfac316c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38e1e071-fd8c-4938-b509-c6baa2c6475e", "AQAAAAIAAYagAAAAEJNOywHaz8ztK5h7BxI2Nj0AX6yyYhHCcLz4xeA/LuTXOqMFQAkSwrn5cKVhHDzY7Q==", "ed1a1f0d-eb8d-4f0e-93bb-7f04fbd72990" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d571a9c-7026-48b0-83a7-e53dda4aa615", "AQAAAAIAAYagAAAAELoFxWMGzgeta3YaQ+yfiikrbcxjRV0vFDYVgG0AXavUiit/DFXUlrCWBpf1OwrfSg==", "15559dd8-d3d4-440e-a024-e4ec5144c95a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f53ba5f-68fd-4103-a205-935143b666e1", "AQAAAAIAAYagAAAAEMHIj/TbzAmn/93mrXb5fvLgVgs2Vb0s4WTMK3qtNkn/nZaUXO87h3XMDcp+pZ04+Q==", "aa671fe6-10e7-4549-93d0-20ecd26abb73" });

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
                values: new object[] { "5dece20e-c247-483c-916d-3e7ffaa16571", "AQAAAAIAAYagAAAAEJ5YD+GKDOtUqabh4RwLaPw4VU/0IR4z2wO8G84iZNQRcL3uqjKjUrqqfI3RnR+v5A==", "8bed7629-fe22-4058-86fc-7e6b59ba83bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b9e11eb-c80d-4290-896e-574237d4acc0", "AQAAAAIAAYagAAAAEN219LuGBY3z46oqsQpcMZlcEgxNd9tOtpzPKtunTqawsT4B1Z6yJeeyZ2hxrdsjGg==", "d5161a32-9a93-44ee-bf87-5664bcd5ec3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4264d785-6f5a-4bde-b36f-617c34464095", "AQAAAAIAAYagAAAAEHs9rqELBaydbQoAA6F7f0sr6lKpVQG9xpPnigsim7ozE3X8MlG9TkaAInEhrXfdKg==", "2cd37db8-58c8-49cf-abbd-a28aad9121e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81e51e36-326f-43e6-b2ee-14eaa104d658", "AQAAAAIAAYagAAAAEMR1MVGM+IVUrDSZwNSRA9IRTjCziYkBd4017kGZz0FBo2Mw5qx0LmgXbt7pJFmCbA==", "94c708b4-b7a5-4d1a-9da3-813ef0b2b43c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b637dfb-40d7-4458-a572-72582310acf4", "AQAAAAIAAYagAAAAEFRWogWm3Q+DpG7AaDfoAnZ7A9EnrtEKT/N0Z5ZgXnu6pNyyrYj0fuQfFgDxTk93ag==", "71ccfb0b-a3a8-40e4-b5a4-4d6594556317" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20291e2-717c-4d53-a622-a650e6b0c120", "AQAAAAIAAYagAAAAEI+pYnksCH6bvJ/+fSFwjDKqOeMoWxTqgG+An6wfLR0GneUYxmQlXZImhhHXYiGLYg==", "18f28bc6-a00b-4bb8-af21-11c8cc7e6b37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8345134c-437e-4240-897f-c12184b5f6b6", "AQAAAAIAAYagAAAAED/Z4gwfvb22lzryHBYXb28gZQMWt3CGsTbkrUoIiXEUCcTbwHYxEgpl5EIiC5+TFQ==", "815b4ce3-5c9b-4019-9fa6-f4ce068068f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d5b2e7c-ee87-4ced-b378-1060aeef3e47", "AQAAAAIAAYagAAAAEDUVaMbUrIx3UkssCEW0gbIsAtNTJriagc/m0D7ONCj6ddy4jV1IJNe7821lGXSJCg==", "03ef0e58-2a69-4caf-85e3-31e55e29cc1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63ebbe4f-776a-4b42-b0e7-ab8890808f02", "AQAAAAIAAYagAAAAEI2z4q/ji8uF+PAkXzbBB+oXVVrJi41bO8EYn3MTNC7HIB4BhVsgXhgj9ES8g4Ar5g==", "f7783fe8-f929-4314-af36-4d82140d78b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7415893e-3bc5-444e-b3ff-51e75ad82bad", "AQAAAAIAAYagAAAAEPNoGJQy3KkJQzjMPhx0vK7WAJmPE/I6o/GdPuEuzBFaFoM2KyO6/jD7GIwwPEkyvQ==", "fe74b3a7-022f-4d99-84cb-212194329b8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a641834d-6940-42a0-aa1a-de708d7cf151", "AQAAAAIAAYagAAAAEH4jpXhwxv5r5KfV7XNZFbO+dmAcM+KctIAuJSxAR//OeaK5dOokulNxxI4rikqxNA==", "838b2c01-ebb7-45f4-a7e3-39dafc49be6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "532e3847-ac55-4d55-961f-6aa1d5a0ee0c", "AQAAAAIAAYagAAAAEKNEv18yWsHmb/hXqXubi95Hf31wTtIFI/FxRuw+t7IAEaiD8CDnwQS+XlOprawQLg==", "8089eefd-cd95-4e14-acd0-2902ca3c1577" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8d2e7f6-79ff-456d-85eb-d88fb2683173", "AQAAAAIAAYagAAAAEEWnbu3Rov5r4bEqnNiszuQTdZlizM3GB939vrpD0Z5D5D5gXqDqxtjdy7yYOI8K4A==", "32b9d21e-7ba8-42f0-a802-7d173a9eec42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "471d1808-9e1a-448a-8dfd-0ae85efa4bee", "AQAAAAIAAYagAAAAEPffBOV3u3QSUjqzPUooQ1kyWv0nh2u3LZ2IpTvChmTu9WafVY2oswywesMaXjPo7A==", "38cdefd9-d8cb-4f9d-81ba-b369d6f9455b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68037caa-1e91-43c9-8d6a-1941df196f25", "AQAAAAIAAYagAAAAEFiJDI7ctmTPIcjDHvHObVScIg4PsN4H13ubblAaErXUDD2fRmY3RKQnk5zQg8SnSg==", "570892f8-aae7-47a4-a2a7-435f5d32ea5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e134e6-2bb7-4d11-abfe-239cbf4f9953", "AQAAAAIAAYagAAAAEHsC7VBmSIL06AGgYDZIKMoNvmsgbdjHhR14F5DQgB7kI8HBBq0KkqkDx3Rlr0SX1A==", "8efecaae-e2e1-48d6-be14-da70423bb04e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23ecbe3a-ca23-41db-832e-a561ee114601", "AQAAAAIAAYagAAAAEOLjwHzQ4JrVXqTegOlY88lk7WGY0xAoEe9SeaSJeMB+OFfntuETcJFP7eXD31bPQA==", "1b8a51c6-d61b-49f1-aa6b-8fcf4fb4e196" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26febcb0-f3bb-4d8a-9030-173238e1d62b", "AQAAAAIAAYagAAAAEOa8kwONW/Jy5eadpqyQIxrGGHtn4wSMDnZp1r9ZQBlL4DtLHp3wRIE3cdM3qrZfqA==", "62fd2588-0a3b-4d8e-a926-d9d196b69cfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "461188ca-1b35-418a-9f52-2589ffd321ba", "AQAAAAIAAYagAAAAEGC15ATNaiSz3ZbVTUrHeESBmnv4miCz/yKHwaQUJEkhyQPO7xfc/P49iFLgn8QGYQ==", "b0111293-1383-45ff-8d90-f34543d93486" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5c2acd6-ef08-4579-a204-a14f1cc5de79", "AQAAAAIAAYagAAAAEGvxpFcnPFbSJ4n43Pw9mkIALBx/q3XOz4rqeyy3czn3VfWjW9afboNyrJYvy2+M+A==", "014fabbb-f7b4-4c71-9115-1eae852a0502" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30bf729b-a2e6-4b34-a7f0-0bdfae15a9e4", "AQAAAAIAAYagAAAAEPYoDRLPJ52VLnP7/CADSVbKkyYnAfRMB3KXkzaIs5gMx5x2owqXAPlI01eE0hXX6A==", "eb9c247d-92e9-4d8e-9388-268bafc2e9d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e118d67-8bb8-4d23-a3fb-7e49d22484e5", "AQAAAAIAAYagAAAAEF35OkiatXSY7eKdJxOT5QQyIO4bha7aNlFAaFbpY2xRjtOuC011IqGykeFPgR7KgQ==", "bc5536b3-c812-4226-a492-defe72e9c93b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74aa670e-fe23-4564-a519-7a4cb6f2dd6a", "AQAAAAIAAYagAAAAEBl/8FDtAzDOBD6KpfBwcdbQ5KBcegGF7B+e1vaKEbf76fVvk9mCO8CuyuM6XaT/NQ==", "ff67a4e5-d9dc-41d1-b1c1-e54d54a57d26" });
        }
    }
}
