using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_agency_result : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "PersonalInformationEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "MedicalExamEntity",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b9674eb-768f-4488-8be4-ed87a297b47d", "AQAAAAIAAYagAAAAED5oUh0ErOBSZe5eJV+AfIeVLPBgKVNhjQkEksty4bI/dPMRbjTCGhlH7iwO/8248g==", "1b710c7a-db71-43c1-ab3b-3a201b28a0ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "786ffe98-d51d-4629-beff-0a3c634a2231", "AQAAAAIAAYagAAAAEG2Pj/I1j48zkKkkW9eX6zVCS/4r0Zg8iUCmKmuW5UUL1CN/E/bihdvKzQrNyVbVBg==", "d5e7d631-11d6-444f-aeb8-b76e90986717" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b12f7dd-3c3f-4d52-b827-0f5ba54e45f6", "AQAAAAIAAYagAAAAEKxAv+LJ7jssVrAc8tOcWnO/edDJcyPB5fzlZ6D1AewkDBz7bsCqHYflO8b6UNF1rw==", "8fbb4b22-39f7-418e-8ba6-8f0443b84c1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cc9a1f6-4f1d-4f81-9a3a-1bc3c16f216d", "AQAAAAIAAYagAAAAEFgXmGkS5qbsKty5yZXADevD9CQ/I7NOyPbXGo3cxh0lCVQl4SA77vgTvbrEGN4UWw==", "889f993d-6516-40d7-a3d3-5cfca8c23315" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aa41597-6e26-4d7e-a925-c671b1e489e9", "AQAAAAIAAYagAAAAEMG2Gef+ECbejJSqyQvHlDVKnTPNoq9zaGL982v5DtJESPezOIRN3MiLiPjus9tL+A==", "dcbe4ba1-dcc6-4b0b-9961-25fd8134a1d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7f0c575-1e4b-43e5-8073-2d3ba2cc1a95", "AQAAAAIAAYagAAAAEBuVDYsLM015Ty882j9xGajyicJ84iS1MDGPP01FawfgMRzIoVc7g30GDNIGUG0J3A==", "5c2c547e-3077-45da-8e94-158b626d0e53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f08bfb2-e151-4d4d-9e7c-cd9a56ed026f", "AQAAAAIAAYagAAAAEJ8aAchF3vqCpJkz4DNKDWYSuPM82FDtaLlOW0y/QIZOArxT6BMuezStgG/rdvMkRA==", "765bb418-2371-4eeb-ab05-55daa2a06251" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d334b046-b4f7-4618-86c9-939abc1cf37b", "AQAAAAIAAYagAAAAEPTnEr3t+MvVf6hkQ4B1EsPtHriDQPtcqW3YiPCXr5kHXy/vStpsMAs2CyA/cV5fXg==", "f0d73360-ffac-44d8-ba5c-8d51817e5fc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8448c8ce-68d7-4760-8734-71adf3afbe4a", "AQAAAAIAAYagAAAAEBkPzMOzPKTvr+xcpaG/wJpDO5H5p/a3ORfj1UAet6UN+3rxPRsO+kRnY6JXdGVw4A==", "36693f8e-3dad-46e7-a9f8-8843604363ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "714321f4-af3c-4a6b-9905-d7b7ea75e45a", "AQAAAAIAAYagAAAAEOpZVOsxmMOF8uJgEjh0gk+MYbrV+39lRgWyaZWXY64I2nsi+872Ee5aI7ZbnhJ07Q==", "7fc4e92f-b7e4-476d-ba64-67d966688d60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c977c511-fc5e-41e6-b8ab-ea27265c106b", "AQAAAAIAAYagAAAAEE3vY72vzyj9w8Gt2tqIaYBb3T5HxN+kTTwB2rkAn0UyF7LvZmRLcnr98nnF+BiDvw==", "674a790a-3b48-4401-8216-f082290cdf79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09985807-6b1a-45fc-8441-8fed4455bd2d", "AQAAAAIAAYagAAAAEBc7EMz+maWcrpBt44SKJUKR94FOTAH/PFqT/5Qv8Ti7l1WPrT9RMoKzolOjvAMUtQ==", "8aa6083c-15db-4587-9cc6-9ac3e519eeb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f082c02-a034-47d5-8b50-8aec141d0df8", "AQAAAAIAAYagAAAAEALiyI1LhuAQcI/z4e9nh257gWBisdflLy4gaX9Rc9PiEecQvOC+y9G2B0Z3lGxDgg==", "015beb6b-8f02-4f1f-ac87-9153bf02abca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38ade676-6e67-421c-aa48-f5a0af0ba1b1", "AQAAAAIAAYagAAAAEL6bNXliG7JrXxpH0rVAI9DHn78/FXxrSA5HMXxhvgwh14lhlKHoK8SucAFwJxFd/g==", "56821a95-5876-4997-9217-d8bd0f9468ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509d3b32-42af-48ed-9e05-4a3b4f3a59d3", "AQAAAAIAAYagAAAAEPYYOWGNnjWXfFvlaV23XHWpSbgeTDKgRxHbL5idFqZJLQ+1yWuf2H1NRXAZDyQovA==", "68b55938-42ab-4a03-9804-63a78181bdd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "481de273-bf39-4c16-a427-52dbabefcc73", "AQAAAAIAAYagAAAAEPX4vVdYpzP/t/UOAN6yWEQZ1GTyej9ImrzPvW03S7pmkPs2j0Ez1KyjGvJuasapvQ==", "40d85563-6256-4ad5-8082-a9f19846b1e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62a5b0fb-3def-4834-8552-f11b2b1e57c3", "AQAAAAIAAYagAAAAEFaZb1q6PciQUdmfQWXFuCy9v87kqCtMCF2JEF1c1NYed96ltbH39I59/CpJfouM/Q==", "41cd1f88-c3e8-4123-899f-29aa84a92574" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c89d7f5-efa1-4833-8e92-88e8679aa64b", "AQAAAAIAAYagAAAAECFQMalryUNEj9TKY/SGdroC1esPZYD/WWweJSAlLvdAkJovQ4lCv7eyD/bUzPadvw==", "0d0b60a0-ded7-4ff9-bb38-9d80f034a2c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b247e346-addf-4e0a-bb98-b216eff3ef4c", "AQAAAAIAAYagAAAAEGMl8vnhHUuOzUkQn4YT7uKSeV0h1AHAAxCdzvEJZtrrZMKfNdUL+a49QS/8e9s/CA==", "f83fe0c3-2205-424b-bc60-2fe2f8c3472e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a00deb1c-1afd-4951-b027-9e027a043099", "AQAAAAIAAYagAAAAEO88f9uhLLP68qjMMyzRubXlPeetttbLslQPxC7fqxa78bjkKbKP28p4qwkw8Kqx+Q==", "83310d8b-1b2a-45de-8373-bbf8b5b4a6ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "906c850d-9343-49be-b91c-907e4caddfb7", "AQAAAAIAAYagAAAAEAmlCvIAOtLuUqzRU35t5CmxMePsxXR7iDID3pijy6UAIsuR5p2G2G6H+ueTomZAVQ==", "c3e4f195-985b-4d97-a8b2-643e926d1258" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba6c50ce-907c-4cdb-9db3-35c8c9329921", "AQAAAAIAAYagAAAAEFyKSZrhnXdWqjmOyXQfff3mKGDyt4l4CXSX2CcPPktbtOp61zHphDMGeQDsha7X1w==", "83a8c603-c24c-4afb-9fd5-89ea90ba1fcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a4f005d-2b95-4b01-8829-6bb0b8347ea8", "AQAAAAIAAYagAAAAEEFoC+Vlp8djamdD8s1T+s4nFSuoFaSis4TKbhKbpanEDlsXgwwZOvKUCdnm7C9qZw==", "3b5277ed-d15d-4b95-b1af-57d83b7f826a" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInformationEntity_AgencyId",
                table: "PersonalInformationEntity",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamEntity_ResultId",
                table: "MedicalExamEntity",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExamEntity_GroupItemEntity_ResultId",
                table: "MedicalExamEntity",
                column: "ResultId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_AgencyId",
                table: "PersonalInformationEntity",
                column: "AgencyId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExamEntity_GroupItemEntity_ResultId",
                table: "MedicalExamEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInformationEntity_GroupItemEntity_AgencyId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInformationEntity_AgencyId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropIndex(
                name: "IX_MedicalExamEntity_ResultId",
                table: "MedicalExamEntity");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "PersonalInformationEntity");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "MedicalExamEntity");

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
        }
    }
}
