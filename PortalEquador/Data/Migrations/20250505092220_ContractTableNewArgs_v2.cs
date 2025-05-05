using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContractTableNewArgs_v2 : Migration
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
                    DateOfContract = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                values: new object[] { "67c2061c-dcb1-4b5a-a7f0-4596f87ee22e", "AQAAAAIAAYagAAAAEFNT05hiMnUerFwmTBNbyR4ZEKYeeOuZsMAtBvalvJNvv/LfwvJAVb8YIl8IUU6wwA==", "6fc48e69-7b39-4774-87f3-d49192940c86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "832d12b9-dacb-46c6-aaf2-6e09670904d6", "AQAAAAIAAYagAAAAEFFJeFLlvhZZ+ikTCrpQcZypybANfG8jcm/8MXZD7k6nfdeoVR2bJOYNhTSpQCbBtA==", "60767085-e7e8-4825-9eb3-7b1048e5c2d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da80fa66-1c57-43b3-a52f-065271058f97", "AQAAAAIAAYagAAAAEOxyTYDcjgg4CjI+aGkNuf18LIvaWdNIQSg1ISoVLcanIFh/1XkOIUp9FcPmspJlKQ==", "8d55a29b-d181-498a-bbac-775c0c93c020" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bf9f0ea-13be-48ad-9a4e-cf72e8f9296d", "AQAAAAIAAYagAAAAEPzp6HfK0tHpVvS3+MBZ7cSIBcPKea+j19gXFJGrXsRdvqfMFAtaiKLp9r5055tszA==", "a1657273-cd7d-4e81-86f7-c37468b539e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84ec895e-dd7a-4b3b-938b-c9de9676693c", "AQAAAAIAAYagAAAAEBr+zcuamDO+j1AC1GUHMvFUm3rbCTTkUxytQ31iodQ2nYUTgPeAg7ExlLuNP/CamQ==", "d31b3475-c76b-47e7-aea4-5ba46227d8c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "463c7b5f-2ae2-4935-8030-2936c16f79a0", "AQAAAAIAAYagAAAAEMoLcWIBJ7jSQXMtIetaHbtJAHJTjGIU4pLAxn4ha47ERSqIOlVKrOOTM3kLMzD/Ww==", "0375f343-d560-4045-a596-3d9a2daf2327" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09f94cdf-cc58-43f7-ae3a-023721e934cb", "AQAAAAIAAYagAAAAEE0AflzIX7YvDa6gcdN490UkKbpF18r8IiT5ORlFbwp8l/OPTxnIK5Y7+oS5r1w9Lg==", "c07a8962-9e14-4f9f-bdb2-3bd948108aad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bed8891c-a083-497d-aa77-61d086b08347", "AQAAAAIAAYagAAAAEPuYwc6kPriTV5eyvHJzEgHpgeP39xkyWW6tDMQxbVIjeNTeoQtBDBkcv4DCuTZJSA==", "f38f378c-a11c-43cf-b9c3-f2275d3ad973" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa4964ec-f403-4192-b3be-5280f46112fa", "AQAAAAIAAYagAAAAEEYprjOqs0NxgVAxNFyv6Rud9gDrUcK4kJ5KmcUMq9Cml5GvD8tWCI4wBQ55EpLqtg==", "8b1d1d8d-4163-4686-9b3e-2306ded92e2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a78a50f-9c76-40dd-a77a-092dd4a6715c", "AQAAAAIAAYagAAAAENMpDar0cgWV0tfHaqagdPiK8NnAm4FiQBgATEHBjFz8ZznMYmjZ9OCmyHeNYW1hLA==", "7323b300-e506-4090-8be5-e340af960984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e362a6b-f036-4505-91ad-79351d3916c8", "AQAAAAIAAYagAAAAEEYMJMtq3qaocOEptu5o3FE7wbnSa7WefSph2fF/DaobymWXQpac7RtupNZnll8mlw==", "c70e6ef9-47f9-46ac-922c-848434f84f88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e72bf569-de82-4440-b4b6-7ac07fbf5679", "AQAAAAIAAYagAAAAEBByRbJCGEtszBOE8nH4ajNZM6yxPRZFdrAj+XmucUzmKTpVTdvsKmVUtXQbH4cFlw==", "a2d90062-61dc-4841-ae71-2c8a703d93ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c4ac688-2cd3-4058-ada4-b7e34383dcd6", "AQAAAAIAAYagAAAAEFPb8muvPjA+lvYfc/kmRQdRMh8qHsBgkqGpE/7eomUyUPSS6wUyZ00C12gX5ZXjiQ==", "c17d6810-b197-42a9-9c78-b29c8ede9107" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92e3e6b8-efc0-46ed-a982-4c79815ae049", "AQAAAAIAAYagAAAAEJd4WQN3DNK4U9VoWVaDUyBFZTo+oVoTU3I2EcJlu7mBvujgC49K8uuFgmwPLEaWrw==", "bed66187-9bfd-49ae-96dd-f0e5258d6408" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0962b44-0245-4288-8e75-49f321e5ebe5", "AQAAAAIAAYagAAAAEH+ps6jX3j/Wl7GiH2KRcP5Vk02L87hx4EXpwUvgLl1q7tsj3cDXFNizeLQL+BME6g==", "16358de5-c5b6-446d-b16e-956455edaaf6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21087740-8c75-4736-95eb-ef4cbaab8d95", "AQAAAAIAAYagAAAAEDAHNXit/Sw5ViOVZ3+ZLMVeokN0BBNTCkPpzQBpsYy04AjmfRqSDgPOWF4iQm6XlQ==", "ee1b2bd3-78dc-4dea-9cc0-557bb96707b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c92e43-df74-4542-b442-86b5226dd9b9", "AQAAAAIAAYagAAAAENmJqr6Mto+3X91zXQFLy4qhD/ybmYQgdrlUtBTNMzr7wQkq/QKdpNMbasqQoRy84w==", "e3f89539-8034-44f9-9c4e-3dfca2989c14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "253005bb-dbe0-4d63-ac93-8360aa8a099c", "AQAAAAIAAYagAAAAEHy/Pc92RuJ+b0RTQrlUMj2cY9I3q+de8QiIZIGKNbxCq4/2q33p4daSnT4fYPIj8w==", "ea0579a1-16f5-46e6-b41e-59a3c27fea84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba4f05a1-b288-4fdd-8d1a-8d4851fec1e9", "AQAAAAIAAYagAAAAEOEJ0ARZVkz4W+IZwp3nTuAKHK6xPU066DXPP1ggnpPKZYL/O7CnIH65wmJJWS6rpw==", "a76add0d-736c-406c-854e-8566039aa18e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b84758f-01a1-4ecf-8cc0-60bce63b5213", "AQAAAAIAAYagAAAAECNRqm13RVl3kmr5ykfGr5hW+blVBuZo/22D2do8Oa8tSf1O+4ZnVSwFfq9DAbSfrg==", "c9c8c7e4-db44-4968-9d0b-64d8ca9cf9e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d54a9f85-ebb1-4945-b1c9-21a2ccfafa9f", "AQAAAAIAAYagAAAAELvY1Y8OXGrKnVvQfTjYl51kHWpJkZfTkcii217oEWflGdH6EkP0IeP7Ns3zPNEFZQ==", "4f100558-6cb9-49fb-ae4a-ebbb272bda40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "861d0aa8-ece3-4e01-8541-9ffbb8665685", "AQAAAAIAAYagAAAAELbnq4sPwZFJvPEqj7xB9kUgv0j/DAwujojLGf3ifdo1IHtVLAYGFGLu00Hs6HSRsA==", "cb74240a-2901-4354-b014-85bd2dcd3961" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d333b9-5dad-46ed-ae76-d571921d635b", "AQAAAAIAAYagAAAAEIuobUAlR+GOAK7h0OierTwTkKVnUJ5hk/FD3FgHiOHOtQ7cl6khwkp2mmSvoDrmhw==", "0fe2cc41-7299-4156-b79f-d6ec21898b11" });

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
                values: new object[] { "6d8865cd-4754-471c-a974-6bc596ee8ae0", "AQAAAAIAAYagAAAAEPja+Hbj0sU7FwVI2v/YEpc21nz0mjrSzenefoXGKkDGnRRfkkkrIdqThVNr9EfDpw==", "73a0613e-c36c-471f-a054-aa0b426ad497" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "781316cd-307c-4dbf-8c01-41326660d3a8", "AQAAAAIAAYagAAAAENa0gTxj6oYMCVIXCwukQVNetHS5y1Ke5BOdyQFUwjW7IEdxKJ9ejwQYNF27ZkLSlw==", "cdc4f526-6bef-416b-98da-8b81682c5d3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cbf1a16-dc37-4cde-8885-235e9e0ec729", "AQAAAAIAAYagAAAAEATdTQDfkLFaeb44kVVnGWK8Z5Gw6rB2ZxEo1/zfi+6t30ljcRoyjKdXykamD6bG5w==", "14a20c89-8309-44cd-8d2a-daf8fbfd02f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "069d7e98-6b48-458f-8cb8-ac389b8ac21a", "AQAAAAIAAYagAAAAEPjWm6kRpUtRQYz3yYznUZCXpFNe3sLvXd+CTfvghrIFo2/rEiwXty6q0a7cyZsrBg==", "f49bee63-07be-4aa7-b280-77df78076df0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "178bc9b6-b70b-4148-a856-89eba1f2b52d", "AQAAAAIAAYagAAAAEGsktwqFp0WYeKaWeOl0zgMBbm/b7PvQZO3Cpix3MHcvT5PCnv4r0DaMbF6lar3qkQ==", "7986d0d0-00f9-438f-aef4-d5e08c633936" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6307741-eb07-4fc0-b562-905f97e89e01", "AQAAAAIAAYagAAAAEHnGr3EZcZpTMWM+Yi5wDOiEMiy4UiLXiC8g4h1unJ8YxKzJ8TgbVeMZchVw+OEzOA==", "ced75753-2a1f-45d7-8cf9-e263d834abdb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "012e64d9-2584-41cb-b024-25884f0afa4a", "AQAAAAIAAYagAAAAEA83Xg4WtEM5a155kWe6yjLV9rpl0RODyoxacMOCWbpZ1xggDctoEw9I1NGFPkz0Qw==", "2c0a1921-cbc5-4efe-ab13-2442690b1d64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55caaae4-62ed-42fe-a9fa-e061e5156c4f", "AQAAAAIAAYagAAAAEO6VJ3wnWNRmzgDgE2qfGMdGGNDfwmYVbuIsUuxSuyII/rzehqAcvZ6thjbopNMswA==", "6fb54e87-c7be-4d73-9d38-6e6d3acadbaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5dc17b5b-9c93-4f52-97c6-8766d6a17184", "AQAAAAIAAYagAAAAEGP1MPeW8tLq+d6Gnp3WNj4c+gHqNw0zQg7OYKICw5HJWpOdwVsow4rlZD3bcx7ynA==", "d8d9ae93-b912-4e78-ac93-a112cc6bcb55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "599598ad-2baf-4468-b843-a08803478a87", "AQAAAAIAAYagAAAAEJW89p6WrnFgsIw8oo6Pk4BD0Ij9VyGJ5SdW8Dcd+MFY1FO6GNt4XCoPdPSbpt4LrA==", "6d13811e-a0c6-4954-bf61-de42ddc72551" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "885022e3-b455-4960-9727-c645159e33d5", "AQAAAAIAAYagAAAAEM0iU+ZFDCh3IwdpkDL+JepJtcyFClYPA+PXq8Tcp9osum6yeGpiDjhXBjC7Tp++vg==", "194817e9-0b97-408e-949b-536f186fdccb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "252ae99e-0859-415f-8fbe-8900ecb393ed", "AQAAAAIAAYagAAAAEBTXvRgpLlyyj28NSte4Tmz3nb6+yCcdssZb1hYSSkZlSVXyfC/EASaKNoSoNzismQ==", "ea542512-d14e-4cc9-b90f-cf00f219dcb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5ff3369-2fcd-472a-baf6-c29d4d8ba5e8", "AQAAAAIAAYagAAAAEDzQd+o5DWkSNkfLH3wyvQT+Av6GHClwcpR+/YwwJIaKAJwKl9KKoOgmtilqLtvKDg==", "a7cad895-a63a-4b57-a5f6-71b8e5ec541f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d09d60dc-23f1-4f6e-aa64-427845ef9eac", "AQAAAAIAAYagAAAAEHbsRDTjqvwr2OAO1KC3bbZ0G636Zmjg+GkT/iqlulDIm+kORpXEeH95OdOS9dinfg==", "4243a182-56ad-42a1-9f31-725ea63045da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cab84814-9c5a-4abc-8b33-9419c5c184c7", "AQAAAAIAAYagAAAAELqK8O9AIkW/uIvODbJO7BxsNcxay/Cj+2JxetXrJuLmxw8Z/vdPSRNuW+QuB+sy7A==", "7105220d-439f-48ac-8413-674ae44837cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd8cf7ad-a2e1-4158-86f0-2dc62e39374a", "AQAAAAIAAYagAAAAENZFDP713vxCoanK2pJgxKYueSzZB1R0RhXIILHJJGQ/bbVE1dsD7yySHoh/QnfvpQ==", "88022043-78c8-49f8-9aeb-6534080259b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c180d62-2944-4201-b5f1-ad0c96784a7c", "AQAAAAIAAYagAAAAEH/Ou6t9n8Ak1f58anDLrA+2aqpndVMVUyx/Gcr3X4ovzw7jVM+9Et/FhQMVCDKV5w==", "6f940ba5-dcef-4453-a876-6ec236577bd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddb6f584-13c5-4629-a2d6-fff78ff64a53", "AQAAAAIAAYagAAAAEMy+12OpFovo4iXi42Pz0k1PScm6csmGjrS+RKE1qpOlDxmX2zk5tmVsvqhOrTJE4g==", "8cc4e8dc-f956-41e7-9aa0-f3cd9123b823" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3a7fbdd-8690-4d86-bdb9-bf58ad63e85f", "AQAAAAIAAYagAAAAEPoE/IFKGatLlp9Vy4y26o4APPjt1noXjh4glGO0J2lljjeJYCg+aAqiw32vwpVyBA==", "9d134af8-1ec8-4eeb-bafd-b503a22ee429" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a622e59-b8ef-4493-a6e3-e2c183342d03", "AQAAAAIAAYagAAAAEG3IgiT+j8+KfKMnptUkNkip//5d1ofzx064hhJD9/AX+CSHj1n1fBNwc2h4pDVPUg==", "39f45637-01be-47d7-a39c-507afd8ad6f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "497d24dd-2fe1-49ae-b297-aa0664ba11ff", "AQAAAAIAAYagAAAAEHwnlx8ufFYpB5b7NYyhlUDyiNEpgpHNTmTLh11KXaKLHXgoGfTkgsnk5pbtuZuCWQ==", "c37d17b0-c49e-4172-8dbe-1784957bcc86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9a316d3-fde0-45c0-9074-7fa097eb6bf9", "AQAAAAIAAYagAAAAEDLyK6JzYA/cjpjJ87NVHl/KLTyG5VOJZIlIqoWEMWu/GaBWFpZs7KPxUidODuspWA==", "f3fa88ec-6e01-458b-bcf4-7cb9d6c7675d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "052b2112-fa09-4b47-a46c-838554d21ca3", "AQAAAAIAAYagAAAAECw8ZEgWpGrkIA9jaeQMwIFPSpG9mC+7bDXk2HrV/NpbjVosUyQ5D/uTyBKapBy4ww==", "3aba4220-c0ec-4dbc-953a-fe6e18356d46" });
        }
    }
}
