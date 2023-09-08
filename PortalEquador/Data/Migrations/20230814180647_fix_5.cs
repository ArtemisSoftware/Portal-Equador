using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class fix_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "863dac79-d286-4c45-a7c4-aa5dca088c1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "63085f7b-91e0-498b-8a4c-982b6af1bd02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7568243e-ed8c-4bca-81ba-d2f2d9d721a2", "AQAAAAEAACcQAAAAEHb0Ub60N/Uo+Pdu04Jl0h8Kns7QWn3DS/mRnYQkxPb5YdbUZwurz68hmyS9hIdccQ==", "fefb97d3-e395-4aca-bee1-b40db2752d51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7803d3a-4b95-48de-a0e5-733eca76c5c5", "AQAAAAEAACcQAAAAEBxOcPaoLSEaxNmeGA8pFf/TNeD9UTRX71uWYYGlxq4AIvR8k55Ct7tK2aDHSUqKMA==", "49f1e440-9835-4d9f-9f70-1bbaca610ce9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_GroupItemEntity_GroupEntityId",
                table: "GroupItemEntity",
                column: "GroupEntityId");
        }
    }
}
