using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class Education_MajorIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntity_GroupItemEntity_MajorId",
                table: "SchoolEntity");

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "SchoolEntity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntity_GroupItemEntity_MajorId",
                table: "SchoolEntity",
                column: "MajorId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolEntity_GroupItemEntity_MajorId",
                table: "SchoolEntity");

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "SchoolEntity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0baed35-e29b-4ecc-b789-3b8ad5c7dbf3", "AQAAAAIAAYagAAAAEMjrNc1sV7JKBNHtDf0s5RoOJdUMfNLssVa6PaSNLh7fOehqaIcElnJq2NNeR+4qug==", "9d6d5144-9aba-4a74-9299-a1ac7b26ebd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a78b40-8896-41b3-b0cb-535dd7d3890c", "AQAAAAIAAYagAAAAEDMFfLmnz14BfHufeXIH6rf38vvMIApqCk3iFFDDr6W0GaRjY/KFPKCHIkFQ2HDcsg==", "28d6e239-835b-48ea-92e3-a225d71ceb7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbb69498-fb9c-4e16-8c84-d6093e685032", "AQAAAAIAAYagAAAAEGUcdnEUIbBGnmJ7CR7T1c6oLdaHOp2YaOotpeZOD88ciZofWXmY+lsaf6Ywoq9nxw==", "c89c5a73-6712-4934-a173-cbce60feae15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d11d42c-c73e-4784-8af8-845f33376a84", "AQAAAAIAAYagAAAAEPHDqNgUPnLgtv8INajnxq//kaMqlcWitJa6qJkGSrmSQx3+b/zo1jpzA53ruh6wnA==", "75539fc0-ee5c-4856-a6d1-64679cbd56d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20917a95-fd0c-4bf0-86c5-38feafbf5342", "AQAAAAIAAYagAAAAEEsrUqTvRYuPTQwe2q4qWxVbFiEzL/7HeGy/IC/91tVXUpkPeYes/YYvy4TPHgufrA==", "624513b3-3cc1-47a8-b1cb-156516a65622" });

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolEntity_GroupItemEntity_MajorId",
                table: "SchoolEntity",
                column: "MajorId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
