using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class MWContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMechanicalWorkShopContractEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMechanicalWorkShopContractEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminMechanicalWorkShopContractEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AdminMechanicalWorkShopContractEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "135d8494-5f58-43a0-bce0-088637ba1f02", "AQAAAAIAAYagAAAAEKr9lvclKLflECAJh+Mut/Ygyss8Bpcvn0EjFCmFWlXzzszaISLg7FcCWUvtdqpTCA==", "321d011d-d531-4122-bb09-c761175e7525" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3112ac04-5214-45f9-9200-21ebfa2027a1", "AQAAAAIAAYagAAAAEDZ9i0dLGA+fiZdVUONTuZ+3vtjDLFVs6eAOWTXApY5JA8BmNCDgpLWSAKpKPzadiA==", "b86f7694-5aca-40a3-a107-cf46e77dd9a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e20b12-9c0f-4147-a50e-6d9f2a448b5c", "AQAAAAIAAYagAAAAEBeK9ki7mRrRYLnp6BYmAjmBf/ks0i/2E9+UzrAnNKcBs9ZW8fuZdBZUQE0uGVzzaA==", "fcdb0e30-9275-4e4b-ab2b-16bb5b42462b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34227aac-7cb1-4488-a106-c572a24a4ee0", "AQAAAAIAAYagAAAAEKDKchvwyuJDzFXLypx+MfzvhTwfk/4moA5YHiXy4ywk/f4QGyeEZ8jPwnpWH/xUPw==", "08eea890-30a0-4d57-ae4c-00f4aa9d2426" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bed9f16-b336-4104-a56f-3fbe3c3a6f63", "AQAAAAIAAYagAAAAELFyg+1T9iQ1l2j7pb21TB9OYHLbfPKOuyMlPX7nid48roIHLXuqY9F77sC2LJ84DQ==", "fe7a42fc-9bed-40a6-b673-2145daa1316b" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminMechanicalWorkShopContractEntity_ContractId",
                table: "AdminMechanicalWorkShopContractEntity",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMechanicalWorkShopContractEntity_EditorId",
                table: "AdminMechanicalWorkShopContractEntity",
                column: "EditorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMechanicalWorkShopContractEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c9b8e90-5d95-4c3e-86f4-9d34659f6f22", "AQAAAAIAAYagAAAAEKpnZwfOwEKHh2oe1NH3G/13nXM5tuzojxPde//3NG/1srrcbgv2Ql1v0HysrzF8+Q==", "1a63aebb-d050-4083-a594-62cea28932c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88a9010e-66b3-4977-aacc-e0e93ca26ab1", "AQAAAAIAAYagAAAAEKUwiNfiHAPQg6UTrPdnDTgUgUEDPc5ndivbE0GW00MUrzbbMq+69DwQ8v4dzktn2g==", "7175a9fa-291d-44bc-8da5-d0f0b35f321b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7846b07-1efc-4d09-8212-a0e72324283a", "AQAAAAIAAYagAAAAEHzbAKs1uoc2vqECh86KzKggqF6NzMqvkTaOayl7sgNhYGGMtSd5Qdq5qT7/CoDRQg==", "fc9a70a9-4289-49a5-ab0d-189c9603e80c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbddb3df-3fe2-45b2-9e46-d02a6a3b02a3", "AQAAAAIAAYagAAAAELjha9+RcsWctGJpWxUu/lOer/BcAPND/5RF+LrYr+9VZWHrrgi4VOTTiUJW4/mJFg==", "413c4ee2-6a76-48b4-ae8c-11571ba7e1ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59d2429a-a857-4463-997b-44bf8caaced9", "AQAAAAIAAYagAAAAEAoI0RyKMuaAOdeM/ferCbXoXscXNnBJD7ARulmRlnJY6BpVu63GFizH2Rt5qsYHnQ==", "09597b21-ceac-479d-ad03-53d0f3fb3547" });
        }
    }
}
