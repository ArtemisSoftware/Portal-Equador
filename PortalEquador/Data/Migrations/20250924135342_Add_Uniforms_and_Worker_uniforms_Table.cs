using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Uniforms_and_Worker_uniforms_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniformEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isSizeNumeric = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniformEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniformEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WorkerUniformEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    UniformId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerUniformEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerUniformEntity_AspNetUsers_EditorId",
                        column: x => x.EditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkerUniformEntity_PersonalInformationEntity_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerUniformEntity_UniformEntity_UniformId",
                        column: x => x.UniformId,
                        principalTable: "UniformEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "616c2177-8e9b-4f0a-ac3b-466d5b71d1da", "AQAAAAIAAYagAAAAEKNZg+VMoESHtso2K6N5csWhIpW41x/WbHZYtqW45qTLCI7WsNulFqFz89aqHRYZHg==", "e836d699-354d-4214-b9e2-f176ea4090a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "388cf7cc-e2c4-4600-bf1f-624626e06490", "AQAAAAIAAYagAAAAEAFCf5MWHcG2pWAK5xym1+m2ry9JUgmklpE0BJ2HIktLKIBzAtXs2cj5rg/aVSBAfw==", "a2e42041-2925-40b3-8712-bfd4d87d9c77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e42beec-b693-468e-bdbd-89b64fd50045", "AQAAAAIAAYagAAAAEKPIrN/8Z7XdvLcZimYmZSd2GZvbyiNsj5QEt16PqJ/63OOtBK9S2DQLu5YDY3FdEA==", "371d6446-0e8a-47c0-8c19-cfa2fe5104c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1394c63-233e-442a-b184-8f8c340e0eab", "AQAAAAIAAYagAAAAEHbAwrbSs4ykpR+47QV0NqT0Hcmn/4ozCpfXv3p2P1SKuKjcAJgZoXWk1VV0oCE88A==", "6c980176-fcf1-424e-a5fd-065a4c3239d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18fd04e3-7be6-4216-8f4d-3251f6e042ba", "AQAAAAIAAYagAAAAEPqqQwf9BGuv730Hb5hYNcLV8UJwyXK8fMoa7vDsC3ygg4jDtsIS5/OBLs2gyA9Tnw==", "5e54b991-2781-4327-bbed-86c29680a1fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55cd5ecf-163a-4bbd-9e13-16dec72f6b63", "AQAAAAIAAYagAAAAEGccaNAmgCNhSFwObAncs/fi1PT4vrwzQfUcj7zm5bt6NXpx8d0+fVdhR8qM8h8b0A==", "90e5410c-4c72-47e1-9ed7-3fab60a43ac1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01fd0c24-a0b2-4a33-8104-01c96d220be9", "AQAAAAIAAYagAAAAECpr8lVNEmwRzWn7xhUV9h/9ijMnHXX7xegBO4wZvEhurR6UE5UewqptxmbG2WaSRg==", "305ae81f-eff9-4251-b267-e122686ec1f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84a9b316-ce1e-489b-9246-90e95786a3d3", "AQAAAAIAAYagAAAAECx3dRsADv9XqVuO4KpWv1KMZ/i8h53lL7JWvM4ADN11Qob4ZOyxZUXNlPso1FaIow==", "debd096b-d48d-4fcd-b0e6-969422c2aea1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5820f92d-f6aa-4368-86c6-ff3d695693b0", "AQAAAAIAAYagAAAAEGuhTtJhculY6NG7/u77bkUDsaMdmXBnHCMFdxMkiSQm9ODf4B8AnegTHJR+LVhAfw==", "afc9b1b0-0872-41dd-9e55-8585919b0dfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ddf7d1d-2c0b-4779-8a4b-3c64e6e31551", "AQAAAAIAAYagAAAAEFFb+MuGVMkpvI50OoedoRTzSbFFs1Z1tn9PdkcNrW4qtjbTuM67MeyKm0E2LSndoA==", "7eaf07db-0ed5-4e96-add8-d4a03299bfc4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "528a7a14-dc19-4c98-b366-db5c2b9ae950", "AQAAAAIAAYagAAAAEMZfnNvSPc2N8hXEO2KxBHReOtkGSWmJB0h9O73H4cQErBWO6EnfRe4CCzx9Z8H1IQ==", "0e18702d-6cc9-463b-8b30-28519eaf863b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a7a79ec-9cf1-40b1-b62a-8a41d8390527", "AQAAAAIAAYagAAAAEA0AgSlbb83hWFDQ5PXPDFFszXqMGEncAsJvSWyLEYGBgiTiBNVZgtvZ5udUoReqTw==", "1e350fd2-b8ce-4cfc-82c7-2df77a6dcc4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c7ade69-78d8-44fd-ba66-c17492ab9f8b", "AQAAAAIAAYagAAAAEHK9Jz2LPvmAmNNpjrHsYNeOv9bw5B0e+BpXTb63pH2R0ZQWKqJoCvVxtYZC8jnjxg==", "53c01847-161d-4903-8aaa-99af2fca8775" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed423d8a-bdd5-4681-8877-c369d08520b4", "AQAAAAIAAYagAAAAEHNt0Pik9Anb2OeZc3P4AgeMd9XBlKkAnSYRmpTtSbyT53xJv/V2G67I9mm3GLofXg==", "a0356b51-4c91-450c-ab04-d733c2a66e55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdef9360-be87-4a27-9a45-95869729282d", "AQAAAAIAAYagAAAAEJlp6TJhOlAMLjf2HVUjDmZBNBTiRfzSpksCf+OC354+eJbLvt0XHZHkIGBAg0GZFg==", "310660f9-d8bd-42df-8208-23e4fd9d7a3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3fffd3e-4ada-40f7-b95d-e77b219fb9b1", "AQAAAAIAAYagAAAAELSISWBY5gbnMtNzlEan4JcsN7IzewiXcsVuCr+97JKuLUOVH0qHYH5pT2rTfWz7Cg==", "36848255-1eb9-4dba-b5ad-58e197b0b72d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27cbb4da-79ad-4649-8b77-d2084293e20f", "AQAAAAIAAYagAAAAEBgKzEj6/O9+f5PZ8OL6aSRZloQ4j3udOlThopFdWgmAv3YsKMaSLn6h8w0/GB+Y4g==", "0e5cb925-05e5-41fa-9bdc-31862c8a0e34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c381ff98-6222-4539-9fc7-15f922caf43f", "AQAAAAIAAYagAAAAEFVnZIuUTWdcLmgCZ3wisg81fpZoMf5z1f1VegSbHoT1Li/UrvQ76LXi3lecYSZtwg==", "7cea21bc-51c9-4334-aaa8-70c57056fac5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "addbf7f8-475f-4af9-8ee3-6753ca147f2a", "AQAAAAIAAYagAAAAEHLc4bgyBtDsGRSwvPp78wg2+QUwEm+MTQi0SRscneblaUGHuQgBRo93vMU1j/Ob0g==", "6bd03b5c-a749-42a2-bd84-952cb2d64d40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b12f9ca-b03c-457d-805a-e782238f5ec1", "AQAAAAIAAYagAAAAEMwcORaMmEKFZIQxM7U7qWB1mjsPGKFgifcZqWznwrIOURP3oWgW29yFYQSihWyheA==", "eb27dcec-12ec-4225-adb3-ca85687bbfd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d59b617-05cd-411f-8ffc-85c86b8c2763", "AQAAAAIAAYagAAAAECKGAdLEC6/YBnIfMg4djMroin32G3EL0lBz9dteoV+GqSREWAyM5ZPGB7LJhlfI2A==", "f723df18-b8b8-4bb3-94ac-f037c1591c03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62a744ec-e1d1-41de-9aa9-8c26cf691ee1", "AQAAAAIAAYagAAAAEGLEufNlNWhluo4l4/CKdJ58SHhXie6UnS7Ly5EonCcJfujNc1phcKyGPGKBJ/Zmrw==", "dcb4f53b-d294-450b-9627-7513259911ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8bc7b45-7327-4569-b819-58ab852f3e30", "AQAAAAIAAYagAAAAEPwRa3cA7ces83TQuImPQ4Xd4+Wxc50wMAD25MlWIwtHY7pUOaAoopChX1vJLOKI/A==", "b90eb1b1-9105-489d-a03d-4e167a3425e1" });

            migrationBuilder.CreateIndex(
                name: "IX_UniformEntity_EditorId",
                table: "UniformEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerUniformEntity_EditorId",
                table: "WorkerUniformEntity",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerUniformEntity_PersonalInformationId",
                table: "WorkerUniformEntity",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerUniformEntity_UniformId",
                table: "WorkerUniformEntity",
                column: "UniformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerUniformEntity");

            migrationBuilder.DropTable(
                name: "UniformEntity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0001-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce6b3461-30f2-4a58-9a2a-5bf605f884e7", "AQAAAAIAAYagAAAAEAqAGivgvpapor9LSeSxWT6Tq9DFjN0K42EE1H/hxsjGO/VVn4jIWlqsQW9ckRcfQA==", "fca13e39-c5da-480c-94fb-6be56701d4e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db8439c3-6932-48b3-b514-d8481eaf1045", "AQAAAAIAAYagAAAAEJ5XbqCNKlKFdbY77DyQ8kkH2n/SZ+Fyswe/VlSnuHfHr6cXnM6A9pJreZn61uwzfA==", "360f41dd-7c5e-48be-bc10-3aa9b1735df4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d9d7272-b9ee-48ce-a07b-967fc5559998", "AQAAAAIAAYagAAAAEEXLeddWpHq+2A7QE0vC9ZK4cuzyJPVrNG65vBYWLp6T/wifoOexV7f+B5TXYW++MQ==", "4d69b274-4a15-4757-a8c5-9b3da17cd4fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c4b6cec-9e65-4641-be6a-1361d612a2b9", "AQAAAAIAAYagAAAAEDAnKwy/S1jThcnxhZasuUKxoemuaMMsGwLV35OVDxbp4FWqoXIR3lD2CYt0enVGfw==", "e811e881-6392-4175-9aa9-4908718abfc1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99f809c9-2812-4b0c-8f66-7e5ac6af8e77", "AQAAAAIAAYagAAAAEEfcvbWZd2vy825+PLtr/CcWYhdr2U/QuH+mC4/Q8Q0wk4kxXfrKzYVos+gdrx4JTA==", "29037678-b8b1-4a43-84f8-6ca07bd5ee91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb536e0-adfa-46dd-8818-b988461ea7f8", "AQAAAAIAAYagAAAAEBKdDdaYzRlxGeuyTRUbJpfwDS8M1OzBa4PFnUaIy5c4HIAW5+r+w4QjBCgcxPfLiQ==", "974d5c81-84c6-4d77-b6b2-5081743af976" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44ec7937-9e6e-4c5d-8d59-53c1ae8d5ca9", "AQAAAAIAAYagAAAAED4aWZEZpoltRKrPledWNoJ/YMvweGHkgu4nPBo7C76TJ9uo64l3AvBTy4GvDC6BhQ==", "56f66bac-c34e-4389-a3e1-4641397b43b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d97a6adb-7dda-4bbe-9c7b-1e827c5aaf3e", "AQAAAAIAAYagAAAAEB4aCq2TaewoVAC/ulgSBtquTOX2d8QdZYpWqrlmOmVQUND5Dd/KTgoxh5S2Mj2F6w==", "ade075f3-f6b8-43ec-af9d-fb106c4cd644" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad4f7dfd-10a8-44fc-b1dd-ec152715d2a3", "AQAAAAIAAYagAAAAEITTQIMhQZeC8d9MgdXMGHXDmGpmqh9I/hAMlUwDT0riFRUNdTu3TsM85OyxKukGXw==", "e3f4e6ed-9630-46e2-814a-d44bfa16871f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a161267c-10fb-4179-b7ab-889af3fb68ac", "AQAAAAIAAYagAAAAEIWljwX6ODPeRH54pRbshKD1aV/jYEKewXyz598xDwBx3kgkqUdt+c0ezmN5sHV/sw==", "f6b325a6-e1cd-4c18-81b7-d6dc34dea4d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f53fb51-e0e9-4a4b-b5e5-7e027a3ab0ec", "AQAAAAIAAYagAAAAEMCfOF9Ta4brsNgIYdzUMrjQ1bV/6DyJVTr81t4ZwVtcNe3rTKpnbgeZITjMacxBJw==", "0f71572e-2845-48cf-b7c4-2a76a9bea719" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b511de78-53fe-43f5-a00e-2692a3af0d69", "AQAAAAIAAYagAAAAEDuZ3LbtNHDlFU9qyrdkVysEMnrMs5a8S6jgin1UQmctgY7YNFdDtaYTjThW9O9upQ==", "ca78fe14-761d-49ae-bd09-1a6546e76463" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ff4c7f7-b229-454e-a9d0-0ffe8f62d65f", "AQAAAAIAAYagAAAAEETova8jU5bkr/EiuvRkSgGQLI2anzTCGgtyjRTDYP7pG0n0vdA/oSZLrdphk0MxvA==", "1144b044-ffc2-4c63-8e7a-84709b5a8dbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1557d5e7-3028-4268-b62d-3f8897197794", "AQAAAAIAAYagAAAAENRYdJvsmNwxh0JileMybM7kcbzzrmUKtX/8mi5/8QCkBsWLqt+0Srm8ocooGeQ2kQ==", "45fc5443-6422-46f2-b22c-2ddc5c215c18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c0408c8-6023-46a2-be49-acb8f02c2556", "AQAAAAIAAYagAAAAEEHOQvYao+ZbZPn1xXJxq8e1S89mu9IE1lLq9AAM5xEWxcdY9w4ltzmn1Bu6zPI/7g==", "01c762d8-fc1f-4e6d-a870-157f332630bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f78c293-55b0-4751-8f90-baaad845a2b4", "AQAAAAIAAYagAAAAEIp550O7h8XRqFzXOy2pVJIptlPORUSgOiEjIiiB64pagUUtsctKs2Koth67kx04DA==", "2fce6452-2c7a-4ad9-9ffc-c5f270a07347" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a70eb47-b849-4967-8b84-778660243f76", "AQAAAAIAAYagAAAAEPcUh29dBsW9XLEX4GImoaxSTIWOTXB2pkFhnzng1XNaXElPCvf4xzeKbjlMG+uV7w==", "f9e73200-1aa4-4fb7-a935-f85417744981" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270036df-f24c-4d9b-93d2-78aaf215848b", "AQAAAAIAAYagAAAAEBkyXjc/H1vLIKJhexT4a6c/jYQbHaPQTGgnuF/ivyir9xZ517H4YVVb4ImNCV/Gvw==", "20a78990-1cee-44c0-94e9-3df4098f2d9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7f72166-62d1-4bb8-b0ee-01deb26ecde9", "AQAAAAIAAYagAAAAEDGS1Yu3xkIo7ZbBmgN78t14FdSa9Tn5zdF3QR6sGexGbTH+JtEFTdp5F8LDttZ4XA==", "2865c188-5db0-497d-96f8-711f665d2d4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d33af78-02c8-453e-a16e-73e5fbd31124", "AQAAAAIAAYagAAAAEBhsCxJPBGPQ9c6Gf5WwG7HOEmdbdHG+BewAdiGYMTAKj0OtQxt+a2Rsf1VsuTv8eg==", "e7ea2206-a60d-40d0-b7b4-c072d54bbe01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b78383f3-ffa9-4bf5-8377-e951f3ce59f0", "AQAAAAIAAYagAAAAENe0Drov14Yw8ZlJad6HaWeFhxz6KnAfgQgKK7bP5QMb41URsXYcbzplq718mkPqLQ==", "01e3893d-bd51-4060-a151-ed623c4ff74e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49fc9bfd-4b64-4cad-a1a4-0616de15ff34", "AQAAAAIAAYagAAAAEIaGX5dDqedhBMM06JQhhoGrVI4TD0rtJ6u9COzhIyEGgyQKqudX9abX69o+Up5CLw==", "621a75d4-0dc8-4710-bad5-a0b2d5bbde24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9ce6f0a-8d83-4441-aea4-9613fb7ab600", "AQAAAAIAAYagAAAAEL1CzimYspr9ju52mbHozaiyPychquD0IFzt01WYkXsknMul6jqMBPRQdGbymb38Uw==", "7f3f7b4e-b321-478b-af3a-9889d5f36088" });
        }
    }
}
