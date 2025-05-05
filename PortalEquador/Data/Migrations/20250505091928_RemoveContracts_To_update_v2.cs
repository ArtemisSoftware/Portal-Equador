using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveContracts_To_update_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    ContractStateId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    ResignationReasonId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ContractId",
                        column: x => x.ContractId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ContractStateId",
                        column: x => x.ContractStateId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
    }
}
