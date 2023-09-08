using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    public partial class personal_info_entity_remove_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_AgencyGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_ApplicationGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_MotherTongueGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformationEntity_AgencyGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformationEntity_ApplicationGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformationEntity_MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformationEntity_MotherTongueGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "AgencyGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "ApplicationGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "Father",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "Mother",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "MotherTongueGroupEntityId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "MotherTongueId",
                table: "PersonalInformationEntity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "b10c9b9b-1ac7-486b-ac6c-8d436e5e3dc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "3af3e64e-5c24-4c93-a715-dd21a19662a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b58e6ab4-e1f5-46fe-ad7c-ed70979fffe9", "AQAAAAEAACcQAAAAEAgq5jXyRCpR6oeWyddasc1wxghR30BXHLKItDMiVLzWznomf/1x8bI35yRSFeH14Q==", "9a09e14e-619e-450b-8ff9-1c3648be53b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e31ffba-f4a8-477b-aa29-d5a0005a6e7f", "AQAAAAEAACcQAAAAEKiPpB87QEOJSl0gRM379DgqNXKXrxLfWsWkyphq8wEsWz37bbH2PnSIDPeZEYWvug==", "9dadcb50-5bb2-42c7-86ee-0b525a9a736a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyGroupEntityId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationGroupEntityId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Father",
                table: "PersonalInformationEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mother",
                table: "PersonalInformationEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherTongueGroupEntityId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotherTongueId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "199825e7-8009-4580-b5fa-bf91e01fa868");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1acb431eabbf",
                column: "ConcurrencyStamp",
                value: "a1119b10-72de-40ef-aaae-8b29851b810e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4631bd-f907-4409-b416-ba356312e659",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cdfa913-afb7-4d24-9813-e3ea7da03200", "AQAAAAEAACcQAAAAEPGPx87c6/fOxO3fLWcz6BZycv4zBu24NwbbWj5NFkanZ/t3yFtNB0TQPziNNX5YoA==", "261e8961-a447-4d3c-b159-21efbdb9db77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bef8955-b70a-4824-9418-4e98969a8089", "AQAAAAEAACcQAAAAEP5b4Ef9XhE8tJmpwqWKdU3sOd+0BiQBpNW3pY2yr2NqDi0BH5VAI4S2vZuo39yPUA==", "5c3c3c7f-1645-44cd-873d-e40e9d41b259" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_AgencyGroupEntityId",
                table: "PersonalInformationEntity",
                column: "AgencyGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_ApplicationGroupEntityId",
                table: "PersonalInformationEntity",
                column: "ApplicationGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity",
                column: "MaritalStatusGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MotherTongueGroupEntityId",
                table: "PersonalInformationEntity",
                column: "MotherTongueGroupEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_AgencyGroupEntityId",
                table: "PersonalInformationEntity",
                column: "AgencyGroupEntityId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_ApplicationGroupEntityId",
                table: "PersonalInformationEntity",
                column: "ApplicationGroupEntityId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_MaritalStatusGroupEntityId",
                table: "PersonalInformationEntity",
                column: "MaritalStatusGroupEntityId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_MotherTongueGroupEntityId",
                table: "PersonalInformationEntity",
                column: "MotherTongueGroupEntityId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
