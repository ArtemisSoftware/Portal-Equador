using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class NotificationsNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AccidentLevelId",
                table: "DisciplinaryNotificationEntity");

            migrationBuilder.AlterColumn<int>(
                name: "AccidentLevelId",
                table: "DisciplinaryNotificationEntity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "062bc7be-e839-40fa-8ada-8b47c17f766c", "AQAAAAIAAYagAAAAEDbFLAGZUUu9D0xXfMPE/c6SDwebzHUuBtdT899vE24C3zBRWJQcHuE99GrI5MLpng==", "423f1d7f-ddcc-4d31-9134-08920ca56459" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d33ea7cb-6c94-4e6a-a4e7-a7f95d9acca5", "AQAAAAIAAYagAAAAEHTzmzMLDxxuAtg6X09JT9cYJS//0na4tbN4eFa5zVQJeLXRyJHBjRNV0BR2yHNsSg==", "c534b2e0-12b9-4bf4-8068-ab8b53476d42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3b628de-0f42-4724-810f-9a463a26ce53", "AQAAAAIAAYagAAAAEI0vR8zZMyPVsMs+b2bFVycr1370J54Kr22JCy0ZzCOjETI++N6ZVzq0vKtQgEoXbA==", "bad60bff-b7c5-453b-9b1e-df2a346aa6c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27d247b9-c2ab-47b3-bbb5-4b7ff83c07dd", "AQAAAAIAAYagAAAAEGOOgbYvTSCKT/drWAfRMfby89lpnHBcyPwPSGxjhGwGW5s4RAHb6vfA7x82Wi755w==", "50c54582-35d0-4951-833e-6d77dfc3ac7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ad9dfb0-cc1f-4535-a799-ef5865b73eb4", "AQAAAAIAAYagAAAAEMggYkYLOGr7D3WQIGlhC242qMFkUCaeulcGD3VwBJUtcpej85+wS5iXRmzGeKFBKA==", "e9b30f4e-6095-445c-b16d-bc72451703a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7560ad5-52de-47f0-9800-b0d94785a313", "AQAAAAIAAYagAAAAEPOvi4vJJ3+2aqStRqqm/0Qv50brTDHDRcPPC/3APb07XHDmIK3xlIg1taUc6XFssQ==", "cadb8176-5d45-46bf-9600-78fad9c0a39f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0432ddb9-2a2e-4da9-b6af-240535fd3949", "AQAAAAIAAYagAAAAEDRLpSzvuIsB59N8cAUGR/ycXO6MLA9fmqtNFOaKMf0hQP/jVOiXAUY1Dzz3Dv7xWQ==", "a3e17748-581d-451c-9b1f-998141a9544b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a34224b7-5b04-413f-a4de-8eb87174a4d4", "AQAAAAIAAYagAAAAEBFvXZ9aB5kIu/3cZ/6Hexk8Hy58zYdqmG2QgYj/PvRJjdWs6oA2/MCQlWX3OTxmGQ==", "758afae2-bd6c-451d-8f8a-5d83e9310cfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2a7d8fc-b3f7-40b8-9afb-7246045c39e3", "AQAAAAIAAYagAAAAEC2MMV3Hgmk1OYqxWNnWTPCgB5InO3YZov29PyxVBhZdKX5NePAar7xjopyxcaXibg==", "10ea4c59-de32-4243-ba1b-2e244992c611" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb799061-75c8-4efd-aa9f-9c5e3d0821b8", "AQAAAAIAAYagAAAAEBTrlVq3xlXbpOrhg4EmX0lww9U+aMcOp3CoF9K5F8lBqIhjTv7L6SKtsHJS7mWBdg==", "fbd81940-73e9-4ef0-8725-36366dd04bfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9eff18-2a7a-43a1-ac1f-78ac3d66a6aa", "AQAAAAIAAYagAAAAECCLjODaqzvwlhybgtLd5Y6rqCDL1sawednhrDtTacUIP/453bv+QxnsxykeFRbyzQ==", "c24a493e-39bc-46f9-ad86-469163f41c53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1767b692-1660-4742-9a6f-00c633d6dde7", "AQAAAAIAAYagAAAAENzJ0BGuq2GW9Imzyq7pmoy0SCOfPQAtADyRWCsSpAfFhTQ7DNDqTNTel9rC/CNDBg==", "8bc1a894-2f80-4205-b9c0-1515c1971cb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "299fa1df-05a0-4f95-9fb6-44a26db97f0a", "AQAAAAIAAYagAAAAELoCsheok+6fJPchVsOFl4EcZUI8I4IrwGiusG1yNleFzIuTGpZYvPNVz3VrdTNxkA==", "cb48f6d7-0aaa-41ee-be60-04c1024bbb75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d97ad21c-e329-4567-8515-32272aa63054", "AQAAAAIAAYagAAAAEJMWtwn6zs63CPhlp8rwL8OZH8NPTT/2Lt36WykjI/p2S3B20bi+2Rc9Uo7y+4hafQ==", "4ea30187-d140-48ad-a842-052c84009b94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af597e72-d869-4c51-ad1e-463219f09f47", "AQAAAAIAAYagAAAAEN8JvQzCp0IvlRUQ3mwFt8/5/VmsEALuNAFECRXrAHZTziS/DXIvKRLDql63WY++dA==", "d6d46be6-868e-457c-bd17-e5ab52500dfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa25a2f0-6ae5-4c80-898a-fd0ccb4edf71", "AQAAAAIAAYagAAAAEFLKyS5jpt/1gWlY4wwZ4BZrHwg/Fzfki2HZ0UJa73nBBmAxUHp0zU7oCi9eURr9Fw==", "f0c465c0-7e15-4acb-9610-8d47b4e9acf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c394e7e8-7b62-4b46-b9fd-6f65d11f9f0e", "AQAAAAIAAYagAAAAEEA+u+0C19Q1NIqV4OV8tTZly4KU2lfWvVkhY5SJuuXkaOD7x8zR0IeydfPeSrU9FA==", "f184e3f0-9b5c-4488-8078-d2ce04429e91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00ad7c69-8622-4550-8137-6aa002bd3eb7", "AQAAAAIAAYagAAAAEJ6dH7Md8KFIiCH9OFCetO84l+F4qdLUM768xYGx1uPQGbjj1srHW9X+ze/YslluDA==", "fe208c6b-8070-4d1e-b39d-8bebaf6bc05a" });

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AccidentLevelId",
                table: "DisciplinaryNotificationEntity",
                column: "AccidentLevelId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AccidentLevelId",
                table: "DisciplinaryNotificationEntity");

            migrationBuilder.AlterColumn<int>(
                name: "AccidentLevelId",
                table: "DisciplinaryNotificationEntity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaryNotificationEntity_GroupItemEntity_AccidentLevelId",
                table: "DisciplinaryNotificationEntity",
                column: "AccidentLevelId",
                principalTable: "GroupItemEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
