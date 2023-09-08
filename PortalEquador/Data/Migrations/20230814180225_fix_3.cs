using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class fix_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "2f7af3d5-ebab-482b-a461-d0e75984f8bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "c73bd319-7ec9-46e4-bf32-729a4f5171df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05ea8796-387d-4bfc-af11-a22451fab99a", "AQAAAAEAACcQAAAAEJYW0BbivoUqW/ouvYg/Nc6HnCO13gSkYiJ/jt0ZfvgAhnHbfSvn0GyP24s7Nk0HUQ==", "b2589d44-6cd1-40b5-ab68-b23e87ac7084" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "825de69d-8a7b-412c-920d-0774ce97edd8", "AQAAAAEAACcQAAAAEIH2aBH+WIoeZVHpbF2PgqEsnZKMgH5LwjjL23iJIfurv660adwyb4bBvlET6wsQRw==", "7b26fc45-4df7-4f79-aa26-386f4aa0b8b5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
