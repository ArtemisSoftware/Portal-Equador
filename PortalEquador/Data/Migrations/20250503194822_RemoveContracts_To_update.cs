using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveContracts_To_update : Migration
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
                values: new object[] { "ec221cff-b25a-453d-875a-0fdea029dc66", "AQAAAAIAAYagAAAAEJ6q8fR0GgJ2Dnp+ytB2p378vOcdNbDC6DXpA8edqpdmigWHZjuQJXhQb0CnFOW7cg==", "e34844e6-cb00-4804-b15f-5a6005c92c15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf15aedd-e102-4c6e-84b4-cf8768d7a3da", "AQAAAAIAAYagAAAAEGSASTMa/rcB7zJh/ULRxFmvQdETE/xwct3ZyqTVAvIq6RZTMNIcLkfUODIuGCVFxg==", "a10500bf-fac0-4a0d-a7b3-b8644f104240" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99fe197f-9334-4959-80bd-cb43e7625d5b", "AQAAAAIAAYagAAAAEKBZKDVFriHWsJZPmjg5+6YfHjZWMvYpi079DhybCjlcgkQL/MNWKKYUYbGGFXSRvA==", "23fa5c11-50ed-4c51-9917-eb056864490d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c6f7aca-b4e7-4755-9ca9-febdc4d0e4e1", "AQAAAAIAAYagAAAAEI4t+ngtNHMF7o4Um8HMqhYy4OOaJSuApSBU3vZHICUG5oZuRftM31uCJ0jLvrLIHw==", "44c1fbcb-fa0b-45e3-841c-55d6b0496f5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f94e732e-f465-4a89-ac18-4cd62de106d3", "AQAAAAIAAYagAAAAEJA7/DRA1T27WNlE4aHJUOKZUzaXcQIBbUxaSuj/cvF6l6gSi1a6rjh5BHEbZJ0zRA==", "e715c4e7-4170-4dae-b40a-972c9febfa33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26d1405c-ef27-430c-a623-2c57cf9345a0", "AQAAAAIAAYagAAAAEK7pa0a1Q2uwv2KFGEKmPv6B81K7p9eXFWrYqUU+UEAvTt6Li2R8b1L0Xls9kVrdGA==", "dda2323f-7263-47db-a231-1db9fd59d85b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12966ee7-af44-4a49-a273-84874ce39b47", "AQAAAAIAAYagAAAAEGpaP8hjwfOiFYUOlEF0Ima4ftrIXzaFP/h/Ik2PVV0dXzUnjmNzB+v8L7vSre/NOg==", "ded4ccb5-be26-4136-8a05-f6ae60a05bd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5781073-b6e6-47cb-b59e-4a0511bc0511", "AQAAAAIAAYagAAAAEKHA6Wp+1vf0cuNogUlUsp0kaBbAGuqNSytYrtc1xGHdKd3s0El5DaOve9DcfAagYA==", "6ce2fe32-726b-4c2d-96c7-b7eee805f89a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85444527-6734-4ec5-b676-2afe40e212bb", "AQAAAAIAAYagAAAAEBfnyXHXmkYs+m2DtFddOI6DYTSPikm/zqokd+VvB3EelwhSaF3CrO1V5E0GKbVyTQ==", "3a742cc2-e1e2-4fac-adca-a9e1388cbff9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bc35c88-7150-4821-a7ab-6646d2067000", "AQAAAAIAAYagAAAAEIHm47bgQPzat2aszIa3oDsqM/K8FISt0pzonRM2yz0SJ/unswKFq+BXderiMMD06Q==", "1b73427b-aea6-4d05-8a9c-327b976826d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ac73146-8bf9-4dca-9215-020573f9580a", "AQAAAAIAAYagAAAAEKzYYR5UePEf7cThtwn95oHR4zacSkwxYYTEf48In6Mcpx3A7b2t7WZr2sCeah56eQ==", "6ed1ce9d-0c8f-4f0d-ae25-7a93e043c793" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bac0620-6599-41bd-83b6-f814534541fa", "AQAAAAIAAYagAAAAEJ+A2fAlRsyUE3GaWmhfWzZzWXjRX/+Aa16z6kPQkWv5z1XaCsZpvTLafquDFmDRQQ==", "b56d83d1-8086-44fd-b9d7-2e0efb5655c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "009cfed6-3e80-4fa3-83f4-0d42758a054c", "AQAAAAIAAYagAAAAEPl1Dx8v5C1p+4Sblu7Ti1TBUA3330mdnwiguEYLTTANF0KL2Ow55pKlfAn6hMYIdg==", "4deba7d0-46c4-4ccf-832f-c64002ce5628" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ac6efb2-89bf-49f8-8b42-ffe8cbba10ce", "AQAAAAIAAYagAAAAEPiSlEJ6ROXsq+zuKhLFDQ50V64UhGogBw9h3LRMyid4tGioJM84+rGVS7ycJ7rzsw==", "416a6b77-92bf-4a65-af83-1ba8e0a22275" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cc95f12-2837-4e57-9371-d7b19f44fd36", "AQAAAAIAAYagAAAAEI/FdNWiXzVz8kXmtaf6GNtQNmWXIl5IeWqSCnvplYmQAFZxJyE6PtZ+g35vOdCZqg==", "3464da6e-af21-4a49-ad6e-c453af1d405a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c118eeac-895f-44a9-b616-acdab7e59c6a", "AQAAAAIAAYagAAAAEAPFOx1qEhVd8GRvJFWXNipk8hTkqwQY0AXnvdpt56YNrgxbyaneMVMVI6YZSvcGfA==", "4ff4b820-8387-46dd-abaf-dbdfd66d3d16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1062eb5-ea12-414d-9de7-cd4d663555ae", "AQAAAAIAAYagAAAAEA2+GJxYRBD4RTqQ0vLncjBfo/NZf5SOFw+OPrew1dO8aLseEm+Dl2GJ3PchyE89fw==", "4da5d353-26b2-4214-82a3-026cb521b433" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e55ae834-f368-4304-b9ba-854dd3bc7208", "AQAAAAIAAYagAAAAEIkh8Gg8DyhO2pZFwqY3WIWQmGJwjR+KB9Dk3GsN9FJJ3kewO7BXHE8WGvfw/Mqtvg==", "5a450012-51dd-47d9-b725-efcc67afccd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbe01bf0-2d88-43bc-856d-8dd75c100f48", "AQAAAAIAAYagAAAAENyhrs5De45VdG/DzP7tbhPfEMTo2z4PlJxyzYrBI6hUnFxlfgRU/gw8aJWE7tbo/w==", "23ca779a-fbc2-4038-9003-f5f6c46706b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dffbfbd-84e6-47ca-a455-c028f38d9a59", "AQAAAAIAAYagAAAAEAtYOdem/bVJRrWIJ9gVPpIbWGEwVPDe+m6ohCCvG/99NkoH3m9MCgm0Y0Z5COzAYw==", "a7f5861c-6d35-4b35-84de-c43a8c3fd4c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dba751be-75fd-44a2-9885-6db2b0cc39a6", "AQAAAAIAAYagAAAAEIsLOAy5hBEGZdZfrgfwC99lfDhQBvWchR5qtOTEncItu12ipD9XOaiEfkYqNPZwtA==", "47fda54e-905b-49bf-b739-0612c46a3aff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e597d50-dde2-48c4-9aee-320fb61050bc", "AQAAAAIAAYagAAAAEK0Vww/1YYx5s+eap4yemmTEq/QX20nsDVJ8/chsgWA4UFcIch1AcqM4ZKOqmtIRlQ==", "46296824-9b61-4047-9b53-d4838e1d9463" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b88e23a1-3cb9-4a32-bd21-9348aafc9427", "AQAAAAIAAYagAAAAEJHQYLlERinmN3/h6RFbbVtPbUsJyKqs8iRzMKXAbayfcb4qxLyIVcbR79W1vydSqg==", "d5480d4b-a848-4c6e-a578-9ed0215c4fac" });
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
                    ResignationReasonId = table.Column<int>(type: "int", nullable: true),
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
    }
}
