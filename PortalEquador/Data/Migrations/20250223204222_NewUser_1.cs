using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewUser_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71bbfde6-72ed-49fa-aa72-8f3f9258ff24", "AQAAAAIAAYagAAAAEISdqt+cfB/CCRNhbd7c+7cqt1va5RwD+AopbsRhfg2W4GJ74pZwxX/5WH4WQ6etAA==", "c705dd6e-8ae9-469c-a23f-c28e97535281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6a1ab17-6256-4d1a-adaf-a69e64d0bc10", "AQAAAAIAAYagAAAAENwrJJdn3crrvhwv0qda6PwlYrS4khfTdOJxc1YACz9Pclns1YlB7zOzd32N+aumNw==", "e9d0b1eb-cb73-40e1-80f1-e0f1864997a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd246882-be8a-4252-89d0-17bf52ca42e4", "AQAAAAIAAYagAAAAEJ2AtkSjJNnD2E/uuJITwpFuY4/OMwCd9E2wKtk0V26I21FZAOaEqcH8rMECY6cdfg==", "e668588a-e95b-4621-a9eb-f385bad3fa35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57d88fb5-2ebe-48f7-a1b0-bf0139fff237", "AQAAAAIAAYagAAAAEP/WjrOQ0r0znmhXExsLa9NueMwwEHIjUO5YQT5o5QWPfLXt9oSNTyIyz2UIK87xhQ==", "0ac55b76-c7d3-41c5-95fd-af74b084da17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fc0f995-3fb0-4a27-ba21-fb89edc4f6bc", "AQAAAAIAAYagAAAAEH/0LH3ITM3mXmEKc/I0DlSoRzqe4a0G+4M6K1PkkCg+ys7diDwxyvR50YN1NCAxqQ==", "782d1aef-c496-444e-805c-613580edf3c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e64480a-1433-43ef-9bb5-b9dd4a128c69", "AQAAAAIAAYagAAAAEDDabzdwwYKxtgt6+LesUwp8nav7/zzjrMfY2AY6+iCj4Do60b8bUm2IPoM7S3K8Nw==", "4a986688-c40d-4e50-9493-663c6fd9cec7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "060d1c3b-924a-4deb-9b7b-37d319cdfeff", "AQAAAAIAAYagAAAAEIlOwhy9+zP7ftx8R5dCk17o9FMIwvY0Ut8jZsZUZ1fawVbYdzemJzoDl4M6LX6ZiQ==", "e9e18ae3-9c8e-4492-bfe9-b6051afbc4b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fab76c8-f0c8-4768-b9df-a211fc1bb51b", "AQAAAAIAAYagAAAAEAu1auTT6Yp9WlnGo5ZR8O0T6zkG/ow+GlImgGMHqGoFhX5kr76bd+Cm6FUHJtMDfw==", "c49f5803-7d25-4c9d-a0fe-3be2b522d3bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4e353ad-166f-43ec-a8c5-3a6b0bb676ea", "AQAAAAIAAYagAAAAEKqyCWV41YSdK1k/LUuL5KtDN8o7NoTCPq0QbbhfadFjOu+kdD02m30EdSGN2rd3Kw==", "6ab9fc2b-8717-442b-a659-23ba6676add1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "474bbdc3-84d5-4421-9f6e-47a4346c867c", "AQAAAAIAAYagAAAAEJE2ve3a9H1uHX8FrkU5nei26DDJMJB/HJzUfOIPF6PIE/GqPR6AtTA3IIJSdY/caA==", "0207df34-8a9f-4a48-a5bf-7ca451829214" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d249ecec-fcbd-4b81-aa03-384b67001066", "AQAAAAIAAYagAAAAEJW3oajGiXbcvRve8nsctEK22wes8PFQQgzJqh3fBna0YJFCr6pi51uxyLYeONKxUQ==", "160063ba-a479-4789-a488-b29e573b82ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fb82a07-c129-490d-a6ce-4e701d894896", "AQAAAAIAAYagAAAAELxpfTPfj+FZ95p/BIHLaQTLLJMENdglGnRVDVdtUWW4DhJ+U64X2wZxlbEStscTYg==", "2050c622-dfcd-4a40-aa16-345a2d31d739" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3629bf3e-2923-4d9d-beda-a47ae0ae1d73", "AQAAAAIAAYagAAAAEMa2zm8SI6EcXaDgKIwEICtBoyfdnXFUBWxHh75YNkumpkHp/qdRXUIw+jBJBmLn3Q==", "dd1716e1-b16f-4e8f-b478-07a17fe81fb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a411a15-3405-4352-9ecf-e096df36bbb1", "AQAAAAIAAYagAAAAELxMKHFLxa00r9vLWp8lmZ2aTdhypzEdT3eZqTADUVhVNZxEMs92ax4j/OH0tUfrog==", "3853ab5b-e7d3-4e65-8e13-b01c8bab5c25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aa70c46-b747-498e-8fdc-bd927bb4fcc7", "AQAAAAIAAYagAAAAEL1U6k9tH92/Pp/S4hOz4QBf5FJzsU+zqe0M5mOdBrj053IFT50NKjXralKH32eMPg==", "582596ec-c4ce-4a49-9eaf-933e659d05a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95cf2500-074e-46db-af22-215fac7a8772", "AQAAAAIAAYagAAAAEOIkX2QOWl4q2fk2OFyOZ4TsyVxMF6T0Xhn1k4yR1+XW23ligRF/2NDatt7JF9hIMw==", "cf69a2d3-92ec-4908-bab7-95eafb5a65dd" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a2b3c4d-0002-4821-8342-7269ec64d949", 0, "f500a981-5b63-454b-b897-9578e79bfdc4", "bmml@alngopco.com", true, "Manuel", "de Brito", false, null, "BMML@ALNGOPCO.COM", "BMML@ALNGOPCO.COM", "AQAAAAIAAYagAAAAEA3EuoAhMzZ3f/I9nmCS4gsju3L78VlH7CGDDBkiIzQQyoYSGMg4iAVuG0bZzkgrbg==", null, false, "c0ebacba-a262-4d4d-b90b-66d450d29fc1", false, "bmml@alngopco.com" },
                    { "1a2b3c4d-0003-4821-8342-7269ec64d949", 0, "56c45b23-0a46-4571-84f4-33e9b64774ab", "orlando.equador@gmail.com", true, "Orlando", "Chico", false, null, "ORLANDO.EQUADOR@GMAIL.COM", "ORLANDO.EQUADOR@GMAIL.COM", "AQAAAAIAAYagAAAAEG5TrXmt+MylTIy2aqh1/rA35Ie4lqCWPuNKNrKpOObuL8xiyLel+uqgx5RLx/dt+Q==", null, false, "d0718ad4-8c76-4d50-8b38-eac5998516ec", false, "orlando.equador@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1a2b3c4d-0002-4821-8342-7269ec64d949" },
                    { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1a2b3c4d-0003-4821-8342-7269ec64d949" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1a2b3c4d-0002-4821-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc4fcb01-de88-4c20-b4ac-8df5c2a65160", "1a2b3c4d-0003-4821-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57164f57-32f6-49c9-bea1-0610c3f01218", "AQAAAAIAAYagAAAAECKoYYmqEALJhTQ/6hkbW+LoTgxFA0QDB5sD5GKD/ONXqr48Y0hbQIs4jiZo/CF4vQ==", "f1f5b03d-8ce8-453d-b129-b6711c325b7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1393f78c-fae3-4a8f-a427-b3d110f2f7e4", "AQAAAAIAAYagAAAAEIeybxdyq8u+rWq9AqGarU8IHBSA/PoHeLQ14M1GET6k4JSZxYrky5f6Er31DR8GFg==", "44f2fb62-f77a-4022-9d2e-5865a26ff14f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "167cea8e-98b9-45ff-bfe8-1ae59fafb00b", "AQAAAAIAAYagAAAAEAqmKi39j41G73G0D72eOWLsyFzDp4SHitFQzxlyGl8PzmnQEleitqCivLAY8VaFCg==", "096fa5e2-b747-4e27-9008-858f30f59416" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fab7d227-cc50-4b2c-a50f-8c4a5eee15a9", "AQAAAAIAAYagAAAAEAz4CB9xHVfuahvlvkU1Vdljcbrg2SB8HXQbe/fjVTcLMF56REi26WiRi/bS+9IhaA==", "0db0e6d1-eab4-4119-9a8e-0a4405d4c69e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3575a819-e277-4229-b981-a0b88f617f4f", "AQAAAAIAAYagAAAAEI3JtczHgsLoKF4B7YiTFMRn0Os24pCLp0Fvy0R1uGXKAq2hS2b+M/yfi5dPu75sBw==", "1d17f27c-1a93-4a40-83d1-454c613c44cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aff2e432-dd52-4729-b737-da0a6c7139f5", "AQAAAAIAAYagAAAAEL5gNTHvS+ajRP3M5lGOC5RbQbqv0ZdCuJkpxmNpkkeCp6i37R4SiEWh7I0+yS3o3g==", "58e0dc5b-f715-4e0e-8ff1-3a651e34637e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc18d458-8037-4173-96ed-a25a86d2c3ce", "AQAAAAIAAYagAAAAEGhERqymGGW9jfyIfpTJE1ILL9H0aYLfwL389ETPxfgqXFwAu/RztemDBl4atvjLmg==", "39ad7460-9f89-4f36-a3a0-519f27ac0e01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18ea06d7-02f5-49f7-b3e9-f9570cf49bf8", "AQAAAAIAAYagAAAAEC50eeyMPNU+icH5o1mT/Zv0wJ+i/26u903OoVySJtrtrwVQ3b2lL1Td4oksz8bvaQ==", "100e3337-b862-4e00-8fd9-a294deead4cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6df5a6a-4661-4e23-a034-2213ef1a9bc1", "AQAAAAIAAYagAAAAEMEBQ4paFtrFQ5xYICdn5GZuHDVuiF0ur5mVSfInWbuu85rTXz1TWTyrr7zExuQQzw==", "f24cbce0-af88-48e1-8ddc-ac603829919f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8e0a542-71a4-469b-b412-a871e89ee139", "AQAAAAIAAYagAAAAEHj9IVIJZ7Jujx278gV4tLl1+v1Km5LbNgvsb7VacTjU5tsHCvGSZ69N01mbcmv08Q==", "7a0eda55-e882-4669-8078-2d86a8520e37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29836c6-19f9-4cbb-ac9e-6ea2e24a130c", "AQAAAAIAAYagAAAAEFJg5xeSdEFS/EwaPbggy8UwTxHPjoOc3kF3bx1Si9qFJw3bJA/UdbTcqbqtAPRkxQ==", "fdda0232-44c3-4200-9f12-814710fddffe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90c5324-98ab-4a5e-bd90-968da193147a", "AQAAAAIAAYagAAAAELc1Y1Rwmbhz912gN5N4NfbXTz1MvsnAK3BERBS/EwtRPZBIUVwGFSEXjFwG4n9DsQ==", "60c292ed-75a0-40db-88c4-b5db49afe3f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4efc4c38-351b-42a0-a499-29351d684c6c", "AQAAAAIAAYagAAAAEIeO5v3RluCCtljJJgT/ab+YtXpwoKN1y6LLz4W32wk2vcbmUTWWfj6e8UJSeMgBZA==", "5f7628fb-920e-464a-896c-807ed42db2fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f21b141-1f80-40dd-bce4-846ed0422d35", "AQAAAAIAAYagAAAAEDotACL2Y10zta95+qqfUteUSrPXCkNN+LUx1mnWPRxj4mAtpPQ1bgkyamqlic3oDw==", "ea1bc8e4-5609-4556-8e7d-fb928b8b190c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a05a553-14b5-48bc-9a03-0cf59612a80f", "AQAAAAIAAYagAAAAEOh/QZk5KFMMsrDspObrPHpzkb62i5FjU9FqUZKmHXXvIQCLZc1YvQe8Gfia9uXwJw==", "4f0d9141-5817-4bff-8b4e-1c8d8cb0b1a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41dabbe1-b702-4bf9-bbd3-6685548d7c41", "AQAAAAIAAYagAAAAEGe6xEQaJD2tLy/Ch6gQZhj0F2RRhtWhBgdGnnjboRCyeDRGuJdwjqWJ268xhvZm4g==", "211be758-c5a6-40c8-8719-cf1a231d98fd" });
        }
    }
}
