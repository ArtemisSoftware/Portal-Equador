using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class freashContractTable_v2 : Migration
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
                    ResignationReasonId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
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
                values: new object[] { "f9760b09-ad1b-40d7-9124-939938455a62", "AQAAAAIAAYagAAAAEOQlZMvicyhf7esq3tvSHMgiemk+fMjHfP67artnNieQ5nQYHOEqj07oThf9ozsFOA==", "e4060bf2-a083-4d52-b575-99754a38336e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0a8d39c-ef28-447e-9d3f-da5309300705", "AQAAAAIAAYagAAAAEOdHbi2EwHJ9lXuKcjMWq7q0ScsRPUvKSIlcmNBI0ShmaBmJUeY1goah6JPojwuxJQ==", "b51c2d2c-f604-482c-86fa-4de81e9a63c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b4b53d-99fe-4c18-9afa-114852904b35", "AQAAAAIAAYagAAAAEBTgX4mdMAh4HfHi2fmIDXuNmKZwbhXAo9J4V+24DtRqttSDgqFOo52s11cdi6rQwA==", "e6470e28-8b35-4e88-9659-d556cb2b2275" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30a75b39-0cbb-4ddb-8823-bd24bcc02e1b", "AQAAAAIAAYagAAAAEGGS5TWig9TE1M5BpuKg/yOtpyT23pfKxPRQcesDWrDfT52wAwtzorrePwqYE++kRg==", "fd215770-c49e-47e1-af78-cfe1afa77970" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d8300ae-009a-41cd-9c81-ff8a37d7c798", "AQAAAAIAAYagAAAAEE9MCICHE/e2iTkoRJAugRFtCkd0P0U6+GpAYj6XAqOdRwkYNtyMUQhHp0Qt2ejF8A==", "883f6e53-d7c0-4049-b34b-5c209984aa6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e61904a-4e57-4316-8c8a-ea2b75cf7331", "AQAAAAIAAYagAAAAEGnlmdmvhbA8uBfnN2ESm/2M1fcV5jWwBc46/vf9XsySdtxpdtBeOdynlPKjW4CJsg==", "a6ee9eeb-8214-4131-aab0-8fe8bfe77f28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1358f903-0c10-42f8-8c6e-f923c613bc60", "AQAAAAIAAYagAAAAEPuNd5Igbi4XU2GgGwG/GCtC+QvUCLi5uOvQnwss/R3A0XRGkX8eOOwTZ2SNGBJiZQ==", "30afd7da-5c41-45f1-aa35-0ea3ac3c8ba4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6665db2d-4399-4387-8ac3-31548a7c4d69", "AQAAAAIAAYagAAAAEEZJ3pYGLl9QALs0m1XjYfy73nQocMj7W9JL4KDdrVAuD5r4IOkh8zE7XoLbPQu9SQ==", "d59ccd57-dc32-4270-be92-ca9fabaaab27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a61085db-271b-4464-9074-a561c012afad", "AQAAAAIAAYagAAAAEAU4W6+fDdUIv8CKflmEMhSioCcUNdbRs/VaJyLOxFibwhL1Zcti4/1plC4/5vdxMg==", "1cbdba8f-5735-4d5f-84ec-897c2ba89178" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecb81d7d-84eb-41fd-ba41-00d0cd7cea96", "AQAAAAIAAYagAAAAEITKi864/CVsfOpQaWNwZezxZzld8FJTqudTKA4rlRI3I+Q0M35+WTMACFnapGdEOw==", "c54c5ee2-b405-491f-a5d6-bbd5856547e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff50b241-d06e-49ed-9cb5-c4c44a7184ad", "AQAAAAIAAYagAAAAEOCtcHHfnSIQUIvb1DexOya5hTjCVKBWjDkph5HnVVcb9eOj3XbVhY7maDq+YOq3SQ==", "e9699435-3a49-44d3-8239-d8883cfb8b92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d3f1716-33ce-4f75-a7f7-b5494fbb6b16", "AQAAAAIAAYagAAAAEECyhRiLEjdcEEgCpA13PbuDZYg6ctO4a0uhGfe301+H/XFLpe68isba+yHKcEc2Yw==", "3c0fc359-56d6-4023-9f0f-419d41623f2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40769a41-49e1-4aae-83b3-3dcdf048ac29", "AQAAAAIAAYagAAAAEB/2HUyyxq4B5TqBW6+s1PQtaXpzDxrFJ8ENNIvOXCdehfmcDwfdRfGYStLGrUghUw==", "f9ea0991-894b-43c5-b092-9860b71a0303" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc7115d-fe65-4a4d-9809-3b7702886185", "AQAAAAIAAYagAAAAEOGZZdbIG2LF5j6iyOOPTmnGJ8OWerqYVmM8izjRqKPLxJBPzfzNNJVzhGPQKYPZeg==", "a98fa038-d7a4-42e6-9e2b-b699895dc5fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b59928d-f508-4ade-9112-ed40ce3f908c", "AQAAAAIAAYagAAAAEMdNMPksmftGj9RoEe7ppDT8QhsYENYT6Y80aF4ErYV02SJg2vZyLhydHpfCxWLJhw==", "e156cf9a-cc30-4d9c-91a4-78287fe72dad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8774028b-f355-4542-8f18-45da82858fa7", "AQAAAAIAAYagAAAAEC+899ZpfV+pfVP9c7EfMtRUFE/gH2Wo98EVQ+vx8vbeI06uXZB/1Xvw0npkA5eGFQ==", "cb2b5b58-2e0e-461c-8458-0dd451a346f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1826d1e-c730-499c-aae6-e261a24d542d", "AQAAAAIAAYagAAAAEKZ5Hb8dcNLmkSlvSN2htUul0neM1OP7CmO00cW1C+TA+CWi2nl19UEjr5eStjT2yw==", "6343ccac-2b40-4bfd-89e4-b2e2605083e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c9ef12d-8d38-4971-b363-4b9c2be9b913", "AQAAAAIAAYagAAAAEO4ebbm6HDLpRtKVCM/gginjNhFGvBq9Jyq4vtsGyKqYXHsoeG/kw72yUZPErn7UDg==", "e4128e9d-0994-415d-8d9f-d410493cf6f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbf01eaf-e3a6-4c78-b869-d73f47df7b5c", "AQAAAAIAAYagAAAAEMr74YIFO7bLgr7krvYr4EbZsLQn7ajQzhgioWD7SmregxlqQWE86MTKcQVAebhBCw==", "5cd2d62a-e11e-4e29-881a-beb2b09a33d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a064856c-51ed-4016-a80a-4c9b53c9d139", "AQAAAAIAAYagAAAAEKFeoGMRlVfA7WuYOe668fmhHdoE4w7kGYoS4RZwBpg8wMxoHCYhP5ZpYbURZDPCuQ==", "7d8f1dc4-0d93-4a05-a11b-2b62a4d4bb96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b02aa5f-6a6b-4e0c-9e7b-8f439aee23d9", "AQAAAAIAAYagAAAAEIIWDSlOJpab13+4FV9EzFbgXYX8GHrVxaiKDZBA29bgsFCLWhNNnzh6QjDaHxEbuA==", "a2c15948-fbc1-4d7a-90e0-2eaed7bfd6f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ba0d43f-f11f-4a0c-a26c-1e4ff5e028c0", "AQAAAAIAAYagAAAAECOxcdKHh97XfOYHWoNmhhs913wiL8Bs+/BZCsei32E+o/aPxus2YZVqi/jnMja2Tw==", "320fca39-eaa0-4338-8511-3911628c0cbd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cb34f53-5b34-4d62-b3ac-9e26c028522b", "AQAAAAIAAYagAAAAEJpTLil2d2CQosWc9TGiVRsHO16HZqXJYdDI0FzLz2T2TTMb3Iq+J0VFoiKD9nm3ew==", "9ea23209-9b4f-484a-a95f-0ef33578c6d3" });

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
    }
}
