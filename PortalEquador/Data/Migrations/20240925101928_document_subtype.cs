using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class document_subtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "DocumentEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubTypeId",
                table: "DocumentEntity",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca68917-d5f8-4780-94b3-48c37788b723", "AQAAAAIAAYagAAAAEJtvsXhmmDpD8JMd2taajXztW6sUY+u2g2Xl4gs+vZGyu9+/3ZuOOb2GQ9auUz1FRQ==", "24a5b881-47e5-43e2-93df-f5cef5350e9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4287ef6-c62b-46bb-965a-623a5c0f14b0", "AQAAAAIAAYagAAAAEAc4+B8pgSGtJ7bsk2Zp/UldDMOcpBQIJtqI3q6cS+8ov+ew7ogaFtugu7yzaG/Knw==", "c526ea72-c6c2-47ab-95d2-b31c713561f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e2662f2-e7de-4d28-98e3-d0598bdd25c0", "AQAAAAIAAYagAAAAEPbDoYDhmx5zNHIzZR9tgpoXGzlqCOdpBtN1tzIbWZ+iGqgxQ2fHCfhE9cwrmoHIsw==", "1f6330db-756f-4fe0-a2a5-6211289780a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d056d8b-035d-4e5c-8fcc-49b27dcc1e59", "AQAAAAIAAYagAAAAEMzqALp6YG1aB3nstKb+Cplkl4+B81lJZ/R+CflGDaI0cDWZrg2f9e6anYmscRTjBg==", "8d02dadf-1a4a-4be3-8675-19dd9ea0047a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db880e99-691e-4cb0-8bdf-f362a8524fb1", "AQAAAAIAAYagAAAAEIJO8hXbiAg7JQk5dViAGzuQgft5jpE8FuzozxWjHoyrFa67+wjBRyBXJ7qb3zuEWw==", "8bee2145-0186-453a-af06-4a6d8ec90b8f" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEntity_SubTypeId",
                table: "DocumentEntity",
                column: "SubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentEntity_GroupItemEntity_SubTypeId",
                table: "DocumentEntity",
                column: "SubTypeId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentEntity_GroupItemEntity_SubTypeId",
                table: "DocumentEntity");

            migrationBuilder.DropIndex(
                name: "IX_DocumentEntity_SubTypeId",
                table: "DocumentEntity");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "DocumentEntity");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "DocumentEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2fec03c-43e1-48c1-b341-503498e13286", "AQAAAAIAAYagAAAAEDinfoSWOzkZTY0AULiARy52aeJib2DGPTenGDCJeQZ1VzhVOHp0rWs4v113c+i9Ew==", "27cf3a4c-3de5-4a5e-b92c-e6c3f900850c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca5a50a1-1647-410d-b55a-61fa8d4aa27a", "AQAAAAIAAYagAAAAENxQzdqpEgIC9nKoC3zbH8rDLrQbtNdkRz4uN952gEUM9LhqfmlKKtaUcxghCc796g==", "c1c679f7-ee55-4ad4-b6be-cf69f6c6eed4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b96a3461-522b-4315-b11d-8679c151d20f", "AQAAAAIAAYagAAAAEF9A/yAW2/dQc+QX8U2MVMnA1pJJcQafJsNEuU4gaPmCCO4BKD73ZwWmDBf5mMYIwQ==", "aead7f9b-a828-4034-ad6f-298669edad84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa0e5d4b-b691-431e-bf30-c969e97b81d1", "AQAAAAIAAYagAAAAECTLDWzFjLcyYIFt9c9LB7jfKtbHup5uB+vIcXGoQ1dF1q7AhPXlWZVAb78mHlAIGA==", "7fd33f99-04dc-4ecc-a649-edf259f9698d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f2983f0-bfea-4f12-bfa4-6d0b871214d2", "AQAAAAIAAYagAAAAENUiLKWigzFohJmUeauY+VPziSMF+481B7Df4XSJJe0QKmeotVcXH74tNoAEBLY/+A==", "fda32cce-fa02-482f-a81f-9d1889b0abe9" });
        }
    }
}
