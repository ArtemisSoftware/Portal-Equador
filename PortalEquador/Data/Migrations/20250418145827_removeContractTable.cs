using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalEquador.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeContractTable : Migration
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
                values: new object[] { "1befdfc9-365e-40d9-a9b5-bd71478a8f2f", "AQAAAAIAAYagAAAAEPf9rIzYCNiKXsQttejPM48a8RS24mBvJZeb0imq3s4BcvTrj26o77jckEl60s5Oyw==", "9eccd48b-4663-405c-bfa4-66164592c53c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c51375bf-52c3-4ed1-9b27-d62105cfcc2e", "AQAAAAIAAYagAAAAEO11QofiJ8+IHzDhsNy+mbUY1Wst57IBO56xfRjSvxVmZhX3PytQIxBwuSW26Zdlmg==", "f09f9d91-c0da-4e88-9ded-2aed4847c716" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ba339a6-992d-4362-84e1-db392619fae0", "AQAAAAIAAYagAAAAEJ6odDbDXbmJyd8OpvDDaEs7lf65vKUqeIKS3LwLB/APCwQLC4Xm17tIl8G68ybgDw==", "40ab72c9-4015-4e1d-ad88-5946cfc1088f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "751366a3-5905-461e-89a8-f9db5abd6861", "AQAAAAIAAYagAAAAEO/K7kWFQXIh/NTptszmL/BhHynZT+c0oSxJmEeRRbgu70uPUVYDXWbhWf49GEp05g==", "a1ec2a9b-68cc-4eda-aee2-74b350bdfab2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37ad5e58-72aa-455f-8f50-987c614f2115", "AQAAAAIAAYagAAAAEC3WcDDW5l1LtN6xH1tWY6PQw1h7lULsfT86xqywOMMu3SgD4EyAt90yV9e92xN5kg==", "5aa75607-9d89-480c-b7f1-565a7c5865d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fc3b69c-33c5-40a3-a7bb-70fed2348115", "AQAAAAIAAYagAAAAEPH7tPEjMPRXpk6ixLQubmIRzp0m+jnlQ0Fg4/Bl3+tT7tn1Ai4NEiYBktlKgPZBZA==", "8e72ddb3-b9ab-41a1-bd04-a97251a54165" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe946da5-c755-41a8-9290-efd4db90d9bd", "AQAAAAIAAYagAAAAEA79aIMIwqptL5ITcI1bUc76B7Lq1Qj83uUHDpdSyj6e7TEJmAYIUaSPY092FLJ2gQ==", "bcfc0d9f-8f33-4f59-9490-e6195eb3930c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fe3a370-81d4-4881-8805-a88545fdd460", "AQAAAAIAAYagAAAAEB0ZLvZBCAsZfrHPJvICt2gd7PRF0yMG9/Q/TjWWBS+o29VmpwPblEfTTaJ/8s5iUg==", "e74530fb-5850-4189-afd2-538840b7676a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70980317-41c7-41c5-86b5-f1542ab1776c", "AQAAAAIAAYagAAAAEJKqUse90zm5/Kj3uef3ic7I1dkM9L43FD01/cGvneHQCrnaZtA8cH6Yh4mNDgpcLA==", "54793422-2248-46ed-876f-7c2eea50f233" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85396d3f-2ad7-4417-959c-4f8cc6685789", "AQAAAAIAAYagAAAAEO5T3rHe6jlQuTYSUATMKLneg3Id0+/Tt4+PwKsbmBbgFjNZ5l0lMM1QyZZuS37Yyg==", "1baab4c1-7e08-47bf-8985-a689b1bef8ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f1eee6e-9880-4118-aa09-d94467d114fd", "AQAAAAIAAYagAAAAEKfY7gP6rPVQZ2km9c+FxQ//9ISk743LOMtPMys1trutbaEhLLlwlDcYXdxfPoS0Sw==", "d6341290-feb0-4fa1-ae4c-2f80fe3c90f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945dc311-1978-44ca-8e93-72b83874fa38", "AQAAAAIAAYagAAAAEPOP/H8fs6gH0h8s9EyDtIiZZOfYkHSp/EANUClSOP/bnQ5NpCw8zY38tW+2h+apvQ==", "22f43928-798b-4895-b6a4-970d626c4d24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "178718e4-beac-45b9-b510-839e85fba36a", "AQAAAAIAAYagAAAAEFvGJ7+nXHtsp5i3Bv8g/ALQR+KmjXvZ2vkj9sJiFA274lTfic3HAZZOz3L4NxRHFQ==", "5f17de43-8996-4dca-9318-5ac27a5b90a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9f55adc-4c21-4ff7-ac2a-534d10610015", "AQAAAAIAAYagAAAAEFEwLcRjpdtxZ/w+clbZ7tjcZRDJeYBO/tSD7QO1vGq3ZlQAaxLyV/ANkcJwbk4IaA==", "d539592b-f95e-4605-938e-2c1bc1859932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2feb3117-88a8-4138-adae-0ee9977fe6a2", "AQAAAAIAAYagAAAAEI7oBJNkg9LZ8nrRE/0KG0RpSBrBCAOVrMh4KJHM+xfh2Brk8r1zn1nAieniVV9s4Q==", "2ac9845a-3da9-4303-a5b8-e460369a4dd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ecebc4e-1aaf-4324-845e-3f1dc2453936", "AQAAAAIAAYagAAAAEAFaNi7YL+HuzSMBCWvnUr2qP6WmqDUl3CC6I8EaY2w/PZlV0dF5u2ofecNkYaasHA==", "74842759-5496-443d-93dc-0372fa463c16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "572e4dd2-9498-4508-bb0a-e8e54fdfae9f", "AQAAAAIAAYagAAAAEJW3UTXQqKnje5B5hFQJ6Fsd7o+sUR9atXaskCNYTPXLSguWQyB/+YGzOjGb0RD8tA==", "6d516ced-45e5-4ef8-86ac-3d31edf8324f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8aaaa49-ee16-4bdb-ac3a-e5be59aa6d11", "AQAAAAIAAYagAAAAEE7IqKfeaKFGhT4HjxsitbXei60ObkYqBwqPN8mdkQk8/ZTUQGP62zGXkg/oGlDo8w==", "29421661-fd19-4641-bf57-12f46c81618d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d9b5f2b-a95d-4835-a96d-599e26db9cf7", "AQAAAAIAAYagAAAAEKOXDHWmgLsesI6GOT/1FMBcrxls7R5ynZON4f/37fr1qEyND/roA2CUogC3+NxfQA==", "9fe9e1ab-4f41-46e1-92b8-a5502921a0c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb179739-8542-4fad-80be-2e40e7f34f23", "AQAAAAIAAYagAAAAEOZ/RvrjoqF3ddlzMUsNXzE2LuJtZV6zJ9dNwMRQ4c9bUVTeOo83K7X48de72mIcgA==", "b98d6ce2-fc3b-4752-9ea4-eef0cf2b1ecf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01814f9d-d000-4c2f-80a9-d058eef79bd4", "AQAAAAIAAYagAAAAENnpZ22Hxb6YFElWMpYjOTd0/f4n65hKj9CVBNmSoHDLwNlbJP+wN2QzwHL9SdTGbw==", "1a06e876-c5af-49b1-b50d-a0c7ab3c23f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cfcc74e-20d4-4bae-8d8b-7444ed0d385a", "AQAAAAIAAYagAAAAEPZ66alaxBMMdlxQRqJBpN+olwaELxGZ6AHUMCdWNDJTpvTWE9k49YQj2nXYfOlELA==", "09626b15-b8b1-4790-9be4-7e7f6a77c058" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03fbd13-3843-4282-906b-6ff81002749d", "AQAAAAIAAYagAAAAEPYnZRERh1jHOYAjVajJArKkSsAZJskKGb3PA3oHUEHkgSW4QyjZ481SS5+h1SLUMA==", "a8387246-261b-46d7-990f-4ad548847cb2" });
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
                    ContractStateId = table.Column<int>(type: "int", nullable: false),
                    EditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    ResignationReasonId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_ContractEntity_GroupItemEntity_ContractStateId",
                        column: x => x.ContractStateId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractEntity_GroupItemEntity_ResignationReasonId",
                        column: x => x.ResignationReasonId,
                        principalTable: "GroupItemEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { "f5b28b95-8b10-4a68-a580-3d6271b72715", "AQAAAAIAAYagAAAAEDWupZ0Qb8mA3jrKKvKWObzSojMcxKwhUS3gSQoHO0kfGEP1fwMjizSKsNIWBljFeQ==", "74017b99-ed84-44cf-8403-1895e680bff5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38b5c484-6425-4e30-96b0-df5950737a60", "AQAAAAIAAYagAAAAEDghNo7RRxy3++5tWIcZGPZNGVWNdZdyiW35oh452H4uqkpS7e03DBqWx8j9pVWnYw==", "26c4195d-50e7-4789-bab7-4c91c6d6faef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13e1e08b-9cb7-41d1-a5cf-cf3b2c8794df", "AQAAAAIAAYagAAAAECLJpbK6YAw9vgyES9/ANaOZrv6Pm4Cl4WTZz64xGFuQBNCfZ2+smSTPsO91POOqYg==", "48a4c832-9004-489c-afe1-8e1947121891" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0002-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbf650b9-cbfd-4325-875d-b49a3ce1822b", "AQAAAAIAAYagAAAAEJVAUM9N4Elux6g2FfQgpqYG2hriKZlaX06GLAYO8k5jEY4Qgixr05Nfm4ALNJ1uIQ==", "afd17d0a-7984-4f9d-879e-5834a6269d56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0003-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "956f1319-0902-4f8a-b81e-184248218369", "AQAAAAIAAYagAAAAEK3mspiwdq0ngMMH1COaXInt7TBVqGTa+VRbswKouiTv0frp9jHFLKhvKEiw2CYdjQ==", "3e0d87ac-9030-4ef5-a50b-37468c0e492b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0004-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f1cc918-0d1d-4fc4-ba12-34f45753a6e2", "AQAAAAIAAYagAAAAEI7YEFFs0h+16TkFK7yejWTK8vgFvBvlQsbylgCTASOnVjHqBXXPB/Fnm8t+yvf+3Q==", "c77617e1-d6f3-4b9c-8943-343073ed2def" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0008-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54dcefb6-0aae-458e-9111-02384201e232", "AQAAAAIAAYagAAAAEL6dypqNbs0O9J23ImnRQFnZ4d5i/7/S93xdXGYUETcDS1X04cukewtO2BlT6fG1YA==", "2ee1a743-d96b-4b72-808d-ac525303f096" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0009-4821-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "306dd58f-5534-478b-be8c-f1e8b750aa69", "AQAAAAIAAYagAAAAEG0LX2S4dePP/+cT99Wuy3Y8F5ceuzchMHtczXyNBYeZYm0Yfkca7M0NmPsELkbcTA==", "26d88c49-e344-48db-9209-1925d2a31772" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b2b3c4d-0010-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf5076f3-dde9-4d5d-a22a-4a8a625d880b", "AQAAAAIAAYagAAAAEK5OfoU6P11XmH8JV5qL1oZp5kD2zvdROqznrnCBKNaP2LRl/XJh2vRos93lw6JclQ==", "1aba6cad-4578-4528-bdd1-9305d000354a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2b3c4d-0002-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3066d31-81bb-46a3-9ae9-284d5fa9733f", "AQAAAAIAAYagAAAAED/+RNdiDqyT+j0GLVkUalEweLcPaAhTFj98v6cJhGQrFEFOY/XeAUw7aRtRm4vigw==", "10984913-b737-416f-ab50-c4ab2ec754f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b2b3c4d-0011-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90be72fd-e5be-4bf5-8359-bad1e7fd5ddf", "AQAAAAIAAYagAAAAEHrfczlKihtsEg/Ehi0p4d1fszXShElkSZehGw0CgDQ7ccQ5LLCMCNAP29G4piDuhg==", "fa167ad2-3847-4e24-ad2a-8b074f64f25b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a2b3c4d-0003-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8fc3fe-001a-4b71-8330-5164f16d3d28", "AQAAAAIAAYagAAAAECZWqhDSgnfMf8yJy3M/OWP2L7kNW4zeM70kz/37eS5iYEB+e7Ya0KmLGrbGcBp0PQ==", "1c6bc990-cf43-469f-8cdc-b87123cc0d95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b433a48-0a2f-4aa5-949f-5216d9725c6c", "AQAAAAIAAYagAAAAEORrn6Nrxo/a9ygZXXLECM6lMWi/rBqqkzvP9WYeYd8HtCq0SncmJN4PPIkVeLdAGA==", "f1eb7d1b-8942-4841-aa95-0aa1796d92ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "418aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1350e463-9383-497a-a9b0-cc96acac6a7c", "AQAAAAIAAYagAAAAEMGhVLEToTS5TXtBL3WC5NmxaAMwNPZ7sh1YKqrfzYf50n4Jrk4Y1k6Vuhv2wNqdFA==", "2e8a79c9-d659-4f81-bc37-7c71bee78154" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "428aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2f4e4ad-d1d2-4a9f-bd23-7e3989d88876", "AQAAAAIAAYagAAAAEAavSB6zqM9cNifOKfxHe884S7gac2jkR2nwXr5DlfXoGAmzKik8YxeJ0Er6b+7auw==", "602d1807-aefc-46a7-983c-018e89c01226" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b16ca09a-a8dd-4a68-ad37-a7b14940b95a", "AQAAAAIAAYagAAAAEGqI+vJW+wJq2uvr/2EI6zSGUmZMJc1AvFSX+B4CfAmAvOo28E0Fm1nUVR8CZfKZeA==", "26a3da42-2319-476e-8598-43ceec95c9b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a33eeb89-dcec-4b6b-b948-2f4d9f6ba679", "AQAAAAIAAYagAAAAEAOO9Q+YFy8SjpSAYgOwRFBl1OvdaC/S3GUjNMoE5nCJ1AsoCnVQ6Voa0iZD065ynw==", "48788269-6860-4948-8b92-ede786b878a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a2b3c4d-0004-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f7bfb26-ded4-489f-b9d3-4577907adda3", "AQAAAAIAAYagAAAAEDgr5PLyAzCpyG4FArHtSnk8FgTDjgpZK7s4yvAP01Af5/GdH/fRHx7rFrN3G3DEgg==", "b35b585f-b6a8-4e04-b17a-bd766cce1528" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a2b3c4d-0005-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48ea81f3-d2d3-42cb-827e-1b98826a6475", "AQAAAAIAAYagAAAAEH9pU1JK7/LPWtF6kT0a+8nEX66GWmak6nqb6V2oKKxR167ep1k+A8NYxCZcFrJLuA==", "407d609b-2903-492d-bcde-6cac8cbbbbeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a2b3c4d-0006-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00cc9e89-c03d-49c6-9b14-ce2749668866", "AQAAAAIAAYagAAAAEO69qoC4JoEERNJulGKZIY3TL19XIS+LKt/UoeE1mVWv2RFUpFyShg8S7cCuAohD3Q==", "9d83108a-6aa0-4c7a-8099-0b03972c80c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a2b3c4d-0007-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cd81183-4211-48b8-bdae-bb5705cc2912", "AQAAAAIAAYagAAAAENVPojvBmAVlsOWbqAqwiCOrnNe+xMTSsLVz+YWnrMTW4wQ9l8DCPvwJahSciBpn5w==", "21ce577d-0c6a-49a5-b02c-a813e0055bee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a2b3c4d-0008-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac43d8ed-c288-49b1-9fc8-5d07222d9761", "AQAAAAIAAYagAAAAELEi1WgrzltLMwygZv/wka/t1Q/nAzUy3oCPbgoINs9XOGquqp3LtNPnJ+JyF1Fsig==", "a244b612-7aea-4904-80e9-abb7a8697b9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a2b3c4d-0009-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbf1401c-9c32-40d0-901b-134c21515a08", "AQAAAAIAAYagAAAAEC+OYl0q2MmjGCJla8i8cW0woW3CrcYPlQAI09qu/7PobAGIWqkcoSOmVA/kObO+Zw==", "2a95d751-7b18-4363-99d2-ae9c7b9e095d" });

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
