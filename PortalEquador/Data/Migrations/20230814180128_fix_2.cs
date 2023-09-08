using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class fix_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
    name: "GroupItemEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "c08ecc35-b9d6-4d32-9c34-a266bd96cd08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "fb0904d2-d783-4930-8003-d4ef3a1849f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6eaaf7a-721c-49c4-aad2-0bafefc4e3d0", "AQAAAAEAACcQAAAAEKHhNpiN/UXpCobJrPLpj9sLud4gzMSlzYS9U9TnjPCbrf/ql0AwnXQR9eBkO6cNLA==", "c552aa86-c246-44ff-bf85-8873883ff562" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4010766-32bb-40c4-9e8a-a064a92ec462", "AQAAAAEAACcQAAAAEGnKviGYUWcDIQGKmfRdNV76OzotANLEUwBPjhOPPF3ZXfTaldF9nfYclNFbJsUolA==", "e6a68edd-c5c0-44e8-95f0-9286676336ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "4a586a7e-5cfe-444d-8129-0c00c00cf57c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "8dbe4365-8a6d-4d4e-ab58-44297d70566c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3edb437c-3480-4a5e-9cc0-abdad89ad10b", "AQAAAAEAACcQAAAAEACsiyTaqIoa9EKgKEuon5gNczluXXp9uQiG/pATrJSiSF9BEsFfwEBYYVM+SYCbVQ==", "5c5febd9-0035-4f6b-aed9-1a5f57ad150c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ca34b8-51f1-4d71-a095-675dd2996227", "AQAAAAEAACcQAAAAELEgaVj10c8kfSNZjmZuJfl4J/LRt8uLP4v6z+Di3ZoDuxz1NgH2YSrXNX9CAH0UEw==", "73593e7e-6317-4244-9b2d-8605730e5e48" });
        }
    }
}
