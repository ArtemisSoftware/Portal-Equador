using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsForNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlcoolTestResultId",
                table: "DisciplinaryNotificationEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bulletin",
                table: "DisciplinaryNotificationEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "802c0750-6242-437b-9a13-cadbf0240840", "AQAAAAIAAYagAAAAECYigXHvkoNb7xLiwdAfqcGIyjhsM0giuV7PNqjWkb9RJoY5M/QEHBJ3/EgTxU4s3Q==", "0d179a12-6f1b-4671-815c-695ddb18f144" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e54d924d-941f-4d4c-935b-d8ede9d5d9f1", "AQAAAAIAAYagAAAAEK4nF8HYjBpt/4QBBBJWYwdClru8HBv+cCgwrWF2u3h+ze17wlTmuOTFjUe53+TE4w==", "dad1a6de-7f41-4070-b1a4-c8e593d9fa76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b36b9aa6-b8f3-46d1-916b-1c2ce4ae8bad", "AQAAAAIAAYagAAAAEKi6kvAA0D6eanMS4sxIOkDLSh+i1f8c5bscpXVFrc7EaP0nbqqeSjiKHaHz4MVqgQ==", "6adfe232-1452-4c97-9712-527aabf30b2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20fd4715-b129-4e45-a56e-970f9202f146", "AQAAAAIAAYagAAAAEJKBfw3iAsuoY3yCnqqvGIQzWC5fkmuQkM38ZLrurOwI+O1UpngYUqkDyYCXW0mAGQ==", "439842df-82fc-4990-a31e-7c6f94acf76e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "411069f9-16fc-4ada-86dc-1c79321f2d28", "AQAAAAIAAYagAAAAEDKhOpjrsJBKL18+DM/4mYKn5ogMk18hi+un9TraSd90poAH9LX8DHuh96XlLYvNJw==", "91d9856d-5ebf-4261-84b3-e3fedef90548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "774d9830-8dc7-4f35-8321-1dcd3f449a47", "AQAAAAIAAYagAAAAENZbyy3eM7u5vjATepZlHFjazgmXjpnvKnDsy6zG74xYjZRfcA9iNUnsONo+of/wcw==", "d108a6e1-2085-4c10-80cd-fc8c98dc1fe7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66868860-2207-4287-9ada-bd3496edb338", "AQAAAAIAAYagAAAAEK0pIl81afdON1uKKdCDHJhH0shRro+TX2DaeMYqy/+RGCoI6EzWlz3anM9kJbgbuw==", "3108438d-21e8-4ccd-a5bd-def04d27403b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d23ae1d-07fd-46be-ad18-89f85a4514e0", "AQAAAAIAAYagAAAAEGF04B6La6TjhII/FcF+QatznLQOZb7LOCvjfB+LZzHfKsGhnplXLXrm+PWQFkswpw==", "73155737-c291-4813-b2d1-9841b4b91e0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef6b800c-b193-4043-82d4-ef58bb5b7b9b", "AQAAAAIAAYagAAAAEIjAP61Ba6Ql8kRo6m7+h5O9ByILK7fKOtW5K3C+/ilZSc0aRHBwY8k81fql5nTI5g==", "6a547b5c-dc02-4d5a-8fff-1fbf9c4294de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be78098c-1900-4f57-af3a-2aa3a1ae7dca", "AQAAAAIAAYagAAAAEB3G8Fv5QZoF2ZBq7/WMH+uNiPSusmWOXZxLygep3jH/bFbJjqf1mF64EtYShHb0zQ==", "ec5c6a5f-9be2-4963-bac4-402f318c4784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83a0e792-5055-415f-9c38-04a481ef5516", "AQAAAAIAAYagAAAAEPUZ414YPeYI9Q4Pu4M4Hc3VgXDFHRTMVRNFIbc/JTO2ALAxHKsOlLbPwf+h5qp00w==", "5ac8373a-16e0-4089-8875-a6c12049d52e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c533fae4-372e-4623-aa04-d580721485bf", "AQAAAAIAAYagAAAAEGjAxFJqBgJ1o7O29hQ99+hwIFCv5Sa8RGOrdQffrt95UvEBZpKoy+7OcRtQhXHAvw==", "fc210137-a259-4561-8c99-a22b66d26128" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1b5794d-51d5-4118-bbca-74e30f88e7dc", "AQAAAAIAAYagAAAAEMf8jJBmBotXSlmMjltUrUKwwwLtJhtls8kjMoZ0ZEaxynqNEbgesbbKicwjKgt45w==", "570270e0-ff2d-4f4b-ba6e-2911b07730bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b2c8248-dda7-408f-aad1-4c2be97233ec", "AQAAAAIAAYagAAAAELMj1bX1RkaCazTLBHJq+L58R/vKe/nYlu1lXeGpdd0Q+Eu1xuZjqUJ5GGBT6TFkFA==", "f21ce3f6-173b-4a5c-942d-f83bb00dd476" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "139e0e72-1ced-42e6-b2d8-f10deb924fb5", "AQAAAAIAAYagAAAAEBzG4EsYq5l1+7HUD0wkJwS5Z1E3f93h/v+DzF7m2nyA5zh+r/0fVkmvj3G2J/IWlQ==", "352f9a36-9527-4873-9766-d9fa82668622" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01fc9064-8638-4e35-ac51-77bb63f511ec", "AQAAAAIAAYagAAAAENg55pJxi5ueraCvYKVr3DYg7f7aStr3zKnuC3avTEpk6P8su8N/wbV9iRDqnBb2MQ==", "e00bf94c-ca01-463b-8557-57a957facd73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65701f11-25d6-4c7e-a8bb-ac62ba4484c2", "AQAAAAIAAYagAAAAENVaKF0EvcWVPKWyBFyGtRCVUh2kBENnxRj6vQs8p8OBUHp5JhYSdMNSIsxId9/5tg==", "5b07f4b2-9dad-47ad-b853-5779237966ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3f9d765-f324-41cc-8efc-cabb1b897587", "AQAAAAIAAYagAAAAEI9IqooA3PurphbL2Hb7fVobhFhVMqfIOlI892W9j5KeoglBDCHXuTdWY7tMG33Svg==", "c2d9a5ba-2eeb-4f47-b0fb-5be15b433280" });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryNotificationEntity_AlcoolTestResultId",
                table: "DisciplinaryNotificationEntity",
                column: "AlcoolTestResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AlcoolTestResultId",
                table: "DisciplinaryNotificationEntity",
                column: "AlcoolTestResultId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AlcoolTestResultId",
                table: "DisciplinaryNotificationEntity");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinaryNotificationEntity_AlcoolTestResultId",
                table: "DisciplinaryNotificationEntity");

            migrationBuilder.DropColumn(
                name: "AlcoolTestResultId",
                table: "DisciplinaryNotificationEntity");

            migrationBuilder.DropColumn(
                name: "Bulletin",
                table: "DisciplinaryNotificationEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71bbfde6-72ed-49fa-aa72-8f3f9258ff24", "AQAAAAIAAYagAAAAEISdqt+cfB/CCRNhbd7c+7cqt1va5RwD+AopbsRhfg2W4GJ74pZwxX/5WH4WQ6etAA==", "c705dd6e-8ae9-469c-a23f-c28e97535281" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f500a981-5b63-454b-b897-9578e79bfdc4", "AQAAAAIAAYagAAAAEA3EuoAhMzZ3f/I9nmCS4gsju3L78VlH7CGDDBkiIzQQyoYSGMg4iAVuG0bZzkgrbg==", "c0ebacba-a262-4d4d-b90b-66d450d29fc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56c45b23-0a46-4571-84f4-33e9b64774ab", "AQAAAAIAAYagAAAAEG5TrXmt+MylTIy2aqh1/rA35Ie4lqCWPuNKNrKpOObuL8xiyLel+uqgx5RLx/dt+Q==", "d0718ad4-8c76-4d50-8b38-eac5998516ec" });

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
        }
    }
}
