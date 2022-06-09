using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardwareMoq
{
    public partial class Create_Schema_AndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APCDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Num = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APCDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Min = table.Column<int>(type: "INTEGER", nullable: false),
                    Max = table.Column<int>(type: "INTEGER", nullable: false),
                    Step = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConstParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynParams_ConstParams_ConstParamsId",
                        column: x => x.ConstParamsId,
                        principalTable: "ConstParams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParameterDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
                    APCDeviceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DynParamsId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterDatas_APCDevices_APCDeviceId",
                        column: x => x.APCDeviceId,
                        principalTable: "APCDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterDatas_DynParams_DynParamsId",
                        column: x => x.DynParamsId,
                        principalTable: "DynParams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0ce26fd4-afb2-4ea6-8dfe-7dff8a6a9e67"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1753cd3d-2228-4efa-a3d1-c87cd690781c"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("26759469-5332-4c8a-8428-3c4c82b7f90a"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("39eb9794-3f48-4697-a4ed-1d8a057c4416"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("403b69bc-a914-4aa2-87f8-3ec9ef263ebd"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("42503352-70f2-4153-849a-07068e9b38a0"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("59b62a7f-8dbc-4c13-9362-b3b0a4be80fa"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5aaba64d-b8e9-41c7-a2e9-698d43d6d63e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("698633ef-5c33-44b0-948e-210c0bfdea76"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6b332ba7-f3e6-4662-84a8-beebf4873d79"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7a34ad52-2e53-4ea5-aeaf-2f835f41f69d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("831f67c7-32d3-4f07-8468-97eebf2a79da"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("85d09e09-c62d-4adc-9aad-c1bafd857777"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("95ed9b31-ecb9-48ef-a47b-d2f55a31bdae"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9e646492-4a60-48e9-ae33-b48fab8517c0"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a0afd718-0205-4296-bbd2-6723a1e11bf8"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a4bde09a-edca-4765-b1dd-818ab0c627da"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ac7802f1-8e00-4284-bc14-5edbfc5092d1"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b76b7f6e-ce46-44c6-8817-42c7e0ce49cd"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b9a85cab-1229-411b-ae28-7188ddf2587e"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c0e534a6-6113-405d-a8b6-510a17fa9d0a"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c151fafa-b89c-4f7b-b7df-f4a3600da34e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c2edb00c-f669-4c9b-af2f-35268fb8e544"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cd2528ed-4dab-4aa4-a78c-9a27c0408aab"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("df9b8e62-e002-4431-88aa-cf00e3a080d4"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e306b175-a16a-4909-803c-f349e169ba9a"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e81e66f1-e32b-497f-8803-54c7b0487420"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e86c865e-7190-4fa0-97c5-3d8e4637eda3"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e9b5253e-5a78-4240-9087-16e2d44a4401"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f800a09b-b417-4907-a13c-156914f8d4e1"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("125a8486-bde7-40a1-b2d3-4b2d14d11fb4"), new Guid("df9b8e62-e002-4431-88aa-cf00e3a080d4"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1738306e-53e4-410f-9af0-71ca5604e475"), new Guid("42503352-70f2-4153-849a-07068e9b38a0"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1fea01f3-e73f-43db-9a8e-ecfac3001308"), new Guid("cd2528ed-4dab-4aa4-a78c-9a27c0408aab"), 8, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2a8d2962-bd33-43bd-8464-618944c97d1c"), new Guid("c0e534a6-6113-405d-a8b6-510a17fa9d0a"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3e5eaef8-2082-4375-8c26-da2024fd54e1"), new Guid("1753cd3d-2228-4efa-a3d1-c87cd690781c"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("535e0656-cc96-4274-bcf4-ae40bb584633"), new Guid("f800a09b-b417-4907-a13c-156914f8d4e1"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6f89d682-f6ab-449c-a1c2-e67c1980e978"), new Guid("e81e66f1-e32b-497f-8803-54c7b0487420"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("70e3ede2-3405-46fd-a831-27a8bcf48173"), new Guid("9e646492-4a60-48e9-ae33-b48fab8517c0"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("728ba1fc-182a-44c8-847e-2833936f50aa"), new Guid("0ce26fd4-afb2-4ea6-8dfe-7dff8a6a9e67"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8351086a-7c45-475f-b490-41d2584e2767"), new Guid("e9b5253e-5a78-4240-9087-16e2d44a4401"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("845efb52-431e-4950-a4d1-d6b904801d27"), new Guid("6b332ba7-f3e6-4662-84a8-beebf4873d79"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("86276a07-e9d7-484d-a522-743dbeb4cbfa"), new Guid("403b69bc-a914-4aa2-87f8-3ec9ef263ebd"), 8, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8a3f5f79-02b8-4bd3-8e70-28822f5d6d55"), new Guid("39eb9794-3f48-4697-a4ed-1d8a057c4416"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8e52eb3f-17a5-4af0-8efc-876a176dff34"), new Guid("85d09e09-c62d-4adc-9aad-c1bafd857777"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8ff42bee-1534-4d33-b9ab-e7a57d98d62f"), new Guid("c151fafa-b89c-4f7b-b7df-f4a3600da34e"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("97221d88-a08c-4cf9-9481-753844a9d812"), new Guid("831f67c7-32d3-4f07-8468-97eebf2a79da"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9db1cb54-69f6-4a5e-8854-015771be0ad1"), new Guid("698633ef-5c33-44b0-948e-210c0bfdea76"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9f5f5442-dac5-4c74-bffa-2916a62ff638"), new Guid("59b62a7f-8dbc-4c13-9362-b3b0a4be80fa"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a7058bf8-3404-470b-9169-1d90370e4d48"), new Guid("b9a85cab-1229-411b-ae28-7188ddf2587e"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b11ea890-e0f6-482d-8a95-7d0f87451c03"), new Guid("ac7802f1-8e00-4284-bc14-5edbfc5092d1"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b14a4fbd-c865-49a8-8ead-96c54cfd9ba5"), new Guid("e86c865e-7190-4fa0-97c5-3d8e4637eda3"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b3a334b6-07cf-4d13-ad72-2fee102bbfd5"), new Guid("95ed9b31-ecb9-48ef-a47b-d2f55a31bdae"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b5b74f54-c846-4cb9-a193-6bf9d070a0cb"), new Guid("e306b175-a16a-4909-803c-f349e169ba9a"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b5b97f1a-556e-4853-be02-87312a174023"), new Guid("a0afd718-0205-4296-bbd2-6723a1e11bf8"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b87ec1d1-ff53-47fd-9f39-46bacd4b397b"), new Guid("26759469-5332-4c8a-8428-3c4c82b7f90a"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c0b6c7e5-5584-41f0-8e42-49393b3280d3"), new Guid("a4bde09a-edca-4765-b1dd-818ab0c627da"), 8, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ce489ab4-47a4-4fae-ae0f-1e1c95fa83c8"), new Guid("c2edb00c-f669-4c9b-af2f-35268fb8e544"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d4e684a1-ed85-4ec8-8aff-9db280b586ba"), new Guid("5aaba64d-b8e9-41c7-a2e9-698d43d6d63e"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d5e085a7-f928-4bb6-844d-f46106d61ac4"), new Guid("b76b7f6e-ce46-44c6-8817-42c7e0ce49cd"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ed8857ba-80cf-43d9-98b6-4804c4b7778d"), new Guid("7a34ad52-2e53-4ea5-aeaf-2f835f41f69d"), 12, 200 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("07438aa4-735a-4591-a534-43d6f069f1a1"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("b5b74f54-c846-4cb9-a193-6bf9d070a0cb"), "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("1b06be61-4adf-4458-841c-4475d194557c"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("728ba1fc-182a-44c8-847e-2833936f50aa"), "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("21e81f17-4f02-4153-aee5-f63d4e05a3e0"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("8e52eb3f-17a5-4af0-8efc-876a176dff34"), "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("262838bd-abd5-4e58-a9f7-6dbe6378c04c"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("b3a334b6-07cf-4d13-ad72-2fee102bbfd5"), "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("30a0fc27-6ebf-4326-9841-ffcd2350d90e"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("b87ec1d1-ff53-47fd-9f39-46bacd4b397b"), "Device2_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("36ddcfe7-f514-4db4-ae03-ac4c8aeaa5a6"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("97221d88-a08c-4cf9-9481-753844a9d812"), "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("4081b59c-f21c-4e6a-a89c-1e08b1f4d414"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("a7058bf8-3404-470b-9169-1d90370e4d48"), "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("47181095-fd0f-4e18-9b31-3f932f20b35d"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("86276a07-e9d7-484d-a522-743dbeb4cbfa"), "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("4b196434-3b79-4051-ae03-ede50616f5e6"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("2a8d2962-bd33-43bd-8464-618944c97d1c"), "Device3_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("54cfac38-0372-4089-b902-547ab803f657"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("535e0656-cc96-4274-bcf4-ae40bb584633"), "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("59afafea-bfdb-42ba-a2dc-14fd6ba2d711"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("8ff42bee-1534-4d33-b9ab-e7a57d98d62f"), "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("607c0400-2c67-4dfb-96ca-fdc3afcc1660"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("b14a4fbd-c865-49a8-8ead-96c54cfd9ba5"), "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("6080ebf7-c017-4c6c-b954-8454bafc84bb"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("125a8486-bde7-40a1-b2d3-4b2d14d11fb4"), "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("69ce081d-d51c-43e9-a619-f304e7d77e43"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("d4e684a1-ed85-4ec8-8aff-9db280b586ba"), "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("734d06ea-51bc-4b6b-839e-8ee8681a3a9c"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("1fea01f3-e73f-43db-9a8e-ecfac3001308"), "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("8113441a-590a-4eaa-85e0-5bb860706031"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("70e3ede2-3405-46fd-a831-27a8bcf48173"), "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("91b6c0ac-fe86-429c-b483-fe8badd8fa26"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("b5b97f1a-556e-4853-be02-87312a174023"), "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("9734a4a6-ed84-42f6-971a-b14158f4d45e"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("c0b6c7e5-5584-41f0-8e42-49393b3280d3"), "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("998ce9d1-cd45-4a2e-9f73-7f24d266b047"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("845efb52-431e-4950-a4d1-d6b904801d27"), "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("a19de9c8-7f7e-40de-a8d3-e4c7689b97b7"), new Guid("c6709981-56dd-4ad1-ae3a-ff1b7f17daa3"), new Guid("1738306e-53e4-410f-9af0-71ca5604e475"), "Device2_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("bbcb60af-1537-4ad1-baf2-95ee2c727b9d"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("6f89d682-f6ab-449c-a1c2-e67c1980e978"), "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("c108f3c2-c026-4c04-935f-554ee7cee0e3"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("8351086a-7c45-475f-b490-41d2584e2767"), "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("c9d1d3cc-034b-4055-8e68-278dbee5b176"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("ed8857ba-80cf-43d9-98b6-4804c4b7778d"), "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("d0c457eb-a986-4820-854d-1c21076702e4"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("8a3f5f79-02b8-4bd3-8e70-28822f5d6d55"), "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("dd7c738f-6c2b-4e8b-9bba-f5e147dad032"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("d5e085a7-f928-4bb6-844d-f46106d61ac4"), "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("e0027129-08f9-46ab-809f-1a1d4d9b79b4"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("3e5eaef8-2082-4375-8c26-da2024fd54e1"), "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("eff63169-627e-49e3-80c1-3e3e8b70ec73"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("9f5f5442-dac5-4c74-bffa-2916a62ff638"), "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("f4d54bbb-1b8b-4ca2-a6ff-94c2eeb491a1"), new Guid("99626c44-cb1a-42d7-bfa1-78413e673171"), new Guid("b11ea890-e0f6-482d-8a95-7d0f87451c03"), "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("ff811089-1a2b-4052-ba3b-6bd09d1ec394"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("ce489ab4-47a4-4fae-ae0f-1e1c95fa83c8"), "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("ffe79783-046d-482c-967a-0fd19771ac29"), new Guid("559a2da5-3411-4366-854b-20b6d8178e9a"), new Guid("9db1cb54-69f6-4a5e-8854-015771be0ad1"), "Device1_HeatO2Pierce" });

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ConstParamsId",
                table: "DynParams",
                column: "ConstParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDatas_APCDeviceId",
                table: "ParameterDatas",
                column: "APCDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDatas_DynParamsId",
                table: "ParameterDatas",
                column: "DynParamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveParams");

            migrationBuilder.DropTable(
                name: "ParameterDatas");

            migrationBuilder.DropTable(
                name: "APCDevices");

            migrationBuilder.DropTable(
                name: "DynParams");

            migrationBuilder.DropTable(
                name: "ConstParams");
        }
    }
}
