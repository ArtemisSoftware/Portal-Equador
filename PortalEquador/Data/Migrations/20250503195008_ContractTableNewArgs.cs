using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContractTableNewArgs : Migration
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
                    ContractId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_ContractEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5877f51-e849-4774-9969-1bd5b112c03b", "AQAAAAIAAYagAAAAEP6Dq8d2/0vmP22bW6zx2OXuz9af3kfXVroCBINWIcHwjiw6CUyQq0NKPjTJ0b0zFA==", "f6c82319-396e-458b-9d99-6e2757d79778" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e1dd9f5-0366-4928-bad8-7b2ffe0ca7e9", "AQAAAAIAAYagAAAAEKLjj1BBIae6gT7mT4Z+hAygFRMWO8BFHmmd/ZDSOsIbQE4t86RUmrYTvxEjl5eedA==", "b35853f7-b32e-4be7-b10f-cc0fa6be0b09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebe5769b-bf22-474f-826f-f6ae0778c758", "AQAAAAIAAYagAAAAEJz/HGMhD9Uzss923jIpHoIZYoUwg7vWwI+t2ke7E4F31zsqQH4nWlC5iYtwJHuqJw==", "2493b82c-49f2-43c9-b463-6fc2c86c8e2e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e519b58-b190-487b-95f7-1af85f9cf6a3", "AQAAAAIAAYagAAAAEOwJDyxL1mgP3C8XR9jz3RfuU7Zoog7XNMfEZgaEyeGM01CqYEO7PjqImSnlb7dchQ==", "d1a0f8b2-d3c2-4d02-b53e-9316054000e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e61073a-f932-4fb6-a8ea-f7c3d8a32133", "AQAAAAIAAYagAAAAEEVZb/PlizwPQtO/RV2Bvsjc7E0mAVIR22q8CedtQm7pzxe0PtnU6CP7m/9hoMo4YA==", "7ccfc9c7-07a8-46ee-b340-bde7334389be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c64d94aa-f878-4d84-87b9-559b18ce87e2", "AQAAAAIAAYagAAAAEMCnPHLVCqT1mjohv8c2X4TbSWBpZmDsJnvBc66V4YmGXpAJ1k/WnLrYjK8mOwWQUw==", "9ee9984e-f2e8-421f-baba-470e646fed68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "462b818f-2bfc-482e-9dfd-2d2c624631ac", "AQAAAAIAAYagAAAAEJXivwA3RkY2dpa1+LNji/nsbqdzxKyhXHuyINrMmA/2J06QO1IN7LS5d0GWmlaczg==", "9bbec304-c847-427f-ad1e-655056c9207e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efee75b4-fb98-4b56-9a04-bfa757f2032b", "AQAAAAIAAYagAAAAEM+9lBTFrwPp13t737hvUJi8usvF/VQlm5qmP+CVV5JROlQBihrv0gqFgisBDf/CEA==", "4b17cf80-e653-48ad-95a9-b87365f7d02c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3891bc5b-d438-4649-b68c-d229d7adbc92", "AQAAAAIAAYagAAAAEAg5da2tHyxsGaQITbd818iuQRrb2eZRhZwf94ujHgDk0iVamR1A5teF4lZlxg+3fA==", "8379a7e5-5f18-4024-9a82-56be4165b40f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47f98980-7338-47ca-8683-db146e3f4cbf", "AQAAAAIAAYagAAAAEKzgdLoj1M5U7LMOAyC+QsXhxyB5KiAE+1yEWkNucWFEvP0Pn3UYg0AY1ksnAWzEbw==", "53abef2e-5ec2-4f17-9af0-0cb09c4c9222" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79be235d-6bee-417d-8e95-b3ca2973077d", "AQAAAAIAAYagAAAAEJKYTate+jaot9hXurFH7kESCpr9WUkpywLyF0rFmU1oKePNRD3MuGAGemZcLMnQCA==", "9cbd7cde-e8a6-461b-ba8b-199e14043a81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbe62b0a-5d7f-484b-9318-b3399887d4ab", "AQAAAAIAAYagAAAAEPKtTnGLqwsVzsHk6INMgjTgm6S1WgTBJVnvu0IzqvTaGbp3jamjoGMStH/UryQRQw==", "b022490c-56a1-43ae-8f96-e14a1dd50d04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d16b796-1f3b-4ed8-acf4-eb5b569b3ed8", "AQAAAAIAAYagAAAAECCssGqzYz9g78N9yAqs0035BejdRY7+gUylrxULFvnVHDCdOcTgCgyy3dcS1Vh8lQ==", "20861ba6-a97a-42bb-b7d9-77020ff5daa0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68df6510-f871-4204-bcf2-1bf563000b88", "AQAAAAIAAYagAAAAENl49kjVG2rBDR+qVZzY5WUlxgqS+XtBtALer94/7KK7AN8svoVdg6XkcmCxQCLZzg==", "ac6b337d-cd7d-4f7d-8530-93e131f1ee42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1e07be0-95b0-497d-9712-933378ca9ab9", "AQAAAAIAAYagAAAAEPIRXOahLDbHRsPE+wy6huilmQL5M3IlKJjk6+vd+FqOs7M+1Cx1aAgc/M/fGcWoLQ==", "175ecd3b-6219-4a3b-a3da-9a73e08923d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85f1296d-675f-4e95-8d7f-366affcd332e", "AQAAAAIAAYagAAAAENMDhN9DeVAmKLZQDS6TqU+XR71QArBgExZxNmXTRpMvtgCpbzqpcbYj/KRhUoDCew==", "f10e61da-d456-48b2-9907-17704cb9696a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffa9fa53-85ef-430b-b185-2de0ec168f91", "AQAAAAIAAYagAAAAEJMH7xeR8GvplxEh+KAgbBiU/HhBSUcRGKk1CrJmUQWWYDxnTQU8C8+HJi85VDOwKw==", "de9af50b-4b52-4567-aae5-51ca36040d22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "969e44c8-d5c5-4627-b23b-e329a6dfa4f4", "AQAAAAIAAYagAAAAEIIBBoSQY4phcwsQP6DrsQE9ZJ3BW86MTSRmcZ9TPJMdsiW4+lf0gv1tS9Yp2J3YUQ==", "854210a6-2e9b-40e1-82db-2a9c5b34a3af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0595ca5e-43de-44d6-a586-ebf06bfd93da", "AQAAAAIAAYagAAAAEPGFcywNluaAX6PhdXgWWAWTv7Xd5uo0DMOyvkt7ETBXGRVfJnh1C3lO/adlvLeF0g==", "5433ff70-6693-4e23-8747-8bed5ab75b57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e9a713a-77aa-456a-b07b-95d137df6338", "AQAAAAIAAYagAAAAEB7wUFGe579d+rLzqM9A726j6mW0HLB19Ekdi64rENxD+t55gF+pCSvc6CfICC4I1w==", "f1680147-3206-4d7e-83b7-cf3dc6cdb07b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e08fe687-b67a-4873-ae38-1394dab71888", "AQAAAAIAAYagAAAAEPjX64CeJU8KU3YwBM0zN9RFZubsIDpBqpChzNpMviT9skCwpsk5P2pGUyR1oPllZg==", "b73b3807-3837-4546-84ae-a399493314d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ff015ae-c7f9-447e-aff3-01d16ceacd3b", "AQAAAAIAAYagAAAAEJSi7BfmQdwI/c+7zK0zC63iZgXjsrRmhRUSQHLC+/RJ0esv55YfvsPIiEX7IPRqGA==", "ab18560a-8d52-44bc-bfd5-1f9182a3bc4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "055b4c2c-aba7-4659-9026-e6c1b35752b4", "AQAAAAIAAYagAAAAEHYTCY5zy58NcEexbsfz1p/qSwSNBtefFDW6WIAtpNFn+RFxeUgXtutxn2xxN5yJug==", "8009812b-e1af-44c8-beaf-d1fb9e8616a2" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractEntity_ContractId",
                table: "ContractEntity",
                column: "ContractId");

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
    }
}
