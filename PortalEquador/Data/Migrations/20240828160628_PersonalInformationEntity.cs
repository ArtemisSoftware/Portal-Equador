using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonalInformationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalInformationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityCardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeneficiaryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    NeighbourhoodId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherTongueId = table.Column<int>(type: "int", nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformationEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_MotherTongueId",
                        column: x => x.MotherTongueId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_NeighbourhoodId",
                        column: x => x.NeighbourhoodId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonalInformationEntity_GroupItemEntity_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fbeeec7-040c-4a47-81f1-759441373ff4", "AQAAAAIAAYagAAAAEOq67By+o1z/o/HBy02aeuDeMYi+onO+a7gahiBdmUiuL3K/+e5r/c4g5tdVZhU8lw==", "285509d8-1afc-43c8-9d8e-8ff60e438d3b" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_EditorId",
                table: "PersonalInformationEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MaritalStatusId",
                table: "PersonalInformationEntity",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_MotherTongueId",
                table: "PersonalInformationEntity",
                column: "MotherTongueId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_NationalityId",
                table: "PersonalInformationEntity",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_NeighbourhoodId",
                table: "PersonalInformationEntity",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_ProvinceId",
                table: "PersonalInformationEntity",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInformationEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2d18fe7-8683-43a0-9b2b-176a657c9f97", "AQAAAAIAAYagAAAAEITr6SRCdVzzDAZ0iKH5zD9Fwx/MooK+rkHl/3Rt4WA56SySt6gicAZ1D4m/KFJBQg==", "5375b075-4c60-4b62-95a9-0d0ebbbe92ed" });
        }
    }
}
