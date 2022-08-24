using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardware
{
    public partial class Create_Schema_AndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APCDefaultDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Device = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APCDefaultDatas", x => x.Id);
                });

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
                name: "ParameterDataInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    Format = table.Column<string>(type: "TEXT", nullable: true),
                    MinDescription = table.Column<string>(type: "TEXT", nullable: true),
                    MaxDescription = table.Column<string>(type: "TEXT", nullable: true),
                    StepDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ValueDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Multiplier = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterDataInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConstParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParameterDataInfoId = table.Column<Guid>(type: "TEXT", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_DynParams_ParameterDataInfos_ParameterDataInfoId",
                        column: x => x.ParameterDataInfoId,
                        principalTable: "ParameterDataInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LiveParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterDataInfoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveParams_ParameterDataInfos_ParameterDataInfoId",
                        column: x => x.ParameterDataInfoId,
                        principalTable: "ParameterDataInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParameterDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
                    APCDeviceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamGroupId = table.Column<int>(type: "INTEGER", nullable: false),
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
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("000c4226-5cc3-4636-908d-8c1ce0a2ce7c"), 4024, 8, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00140770-10a4-4563-8705-d4a7c1569062"), 4233, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("001b5666-0711-46a4-9d8f-d3c08c66a0c0"), 4415, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("004108c1-b762-496e-8ecc-a49d02639ad4"), 4258, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00476bca-1416-4731-b085-4563303d0ee0"), 4516, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00571306-ecac-42dc-a341-741c541b0352"), 4424, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("005cc575-b8d7-431b-b8e1-96063cb9eb39"), 4713, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("005e6f63-2564-48af-a42f-df1ac6fc544f"), 4404, 10, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("006dfb81-baa1-4624-9715-0adf3ced8fcb"), 4253, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0082c6cc-f07e-475f-8a84-6c707af43b13"), 4260, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0084abcc-8ce9-476c-9ebc-265dfa92dfe8"), 4259, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00a55acc-e536-48df-b5b9-b926c82d3139"), 4438, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00b7034b-d5c0-4ba8-a281-091e0ab7c1dc"), 4663, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00bbea2c-c88b-4e6d-864b-d6cb573866ba"), 4412, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00f453bf-b1b1-436d-9e14-ff88c06ae337"), 4511, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00f4a30e-5cf2-464f-956f-13ef8be7fb42"), 4006, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0101f13c-19e1-4d26-8fef-97359164a43f"), 4513, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0102c2ab-c605-47b4-8ea4-c77b18ff287e"), 4460, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("010f2d98-d352-43f7-989e-6581b9a9cca0"), 4267, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01598702-0977-4bca-870f-8c65ffa62995"), 4104, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("016ad5b6-84cf-4906-a135-ee3782c0250e"), 4524, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("017f9cc0-ae4a-4dcc-b337-18d21202a9ef"), 4517, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0183c9d5-8220-44e8-bba8-ec05ed0a002e"), 4248, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("018ab685-bad1-4f8a-badb-b30a7fb1d3e3"), 4718, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0195b4bd-2ec9-4975-8e8d-55cfb2f7ff12"), 4236, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("019dc51c-0857-4bd9-9d48-4cdb37241744"), 4712, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01a82216-8d49-4f2f-ba1c-60fd7a214117"), 4036, 8, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01acca18-524e-4409-a50c-49fd8e1f8bf4"), 4405, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01c034ac-8069-4813-a60a-48f636c36557"), 4302, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01d397d5-2e84-418e-a9f8-f029a5a8ae0e"), 4607, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01f0cf9f-ffa0-49c7-8e54-9a6d9bbffa21"), 4317, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("020f3452-aedf-47e7-b452-9782e2417241"), 4421, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("022ea1c8-0b51-46b1-be30-caf7ccda0e58"), 4431, 6, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02514619-eb36-4884-9171-0d1af06dcc61"), 4850, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("026219cd-f439-409f-83b1-44fb6f356473"), 4508, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0269a55a-f985-4b54-bf36-661469016f4a"), 4218, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("026c0192-fb27-449c-8891-97dbed6530d9"), 4265, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0285b290-cafc-4cbb-9fe8-e98fe15514a8"), 4413, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02b7c140-b876-41ca-a288-496115667d12"), 4429, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02c3d2a7-bebb-4de7-ab4b-cbc565774505"), 4023, 9, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02d2c66a-bc08-4081-9271-68a957ad9b8d"), 4237, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02d37af2-7fca-43ab-86bb-ff5a97f2587b"), 4431, 3, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02dd85bf-66b2-498f-954b-371ace56b4eb"), 4212, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02deffa2-6250-4040-8846-91fa96cbbaca"), 4706, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0302d282-da17-4657-a297-372413567afe"), 4454, 9, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("030d66cb-d0f9-4d37-9fac-59b6b67dd410"), 4856, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("032d405b-9ca0-4572-a644-693088307fa8"), 4542, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("034aac88-5649-47c6-80ea-c7a462bcd662"), 4563, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03646ae8-457d-4e83-83f6-be235ba96dac"), 4232, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03681e3d-a550-4ceb-8d9b-7622f0c2ad95"), 4462, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("036fc652-75f7-48f3-9619-50bd9f74549d"), 4701, 2, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("038a13f8-aa9a-4108-acae-d653efab5098"), 4558, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0399152b-f916-4458-8bd6-93d8366728a0"), 4516, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0399ee16-0468-4e6b-845f-5b64de23796a"), 4008, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03a773d3-7705-4e45-802c-000fd849eef8"), 4410, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03aa6ccd-e47d-4e46-8a74-1ee099430743"), 4314, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03b12c7a-a594-410e-8f2e-0d3b1c9fb9a0"), 4228, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04099f4d-3a40-4684-ab14-2db1022e3184"), 4219, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04168036-6605-4ffc-89fb-a69f17b231e6"), 4101, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04369291-91f7-47a5-bdc4-dd40c60b4a76"), 4708, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("043afbb6-1871-47f1-8f90-41dac18a9057"), 4246, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04533835-b66a-44e8-8f9e-740079baa389"), 4703, 3, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0462cdf5-0190-4810-a27d-3bace0a0c535"), 4269, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("046667d2-00cd-42f4-8c1f-965565be7e03"), 4020, 2, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0471f456-3689-497a-ae5c-26b2b264ee11"), 4623, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04795f72-0f8e-4888-a30f-b1eabbe4622b"), 4723, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04a217c0-6bef-4d91-ab3b-4e8776f97a2e"), 4235, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04ac2be6-b23f-44fd-a5c1-74deaa212e15"), 4462, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04e55a83-961a-4c62-af02-a55d1ba6d8e2"), 4308, 6, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04ed3874-fd8f-4f50-9a69-22b91e17befd"), 4616, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04f4a43a-a693-4988-97c2-48c7d4d6aa26"), 4308, 7, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05204d82-c863-40ba-a915-66507922fbf3"), 4700, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("052dd768-1dd1-44bd-9d6b-29b8dc98f8dc"), 4240, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("054cdd3c-71e6-4ccc-bd2c-274462829575"), 4420, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0557b253-9846-41a7-9b6e-187ae508e46f"), 4625, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("055bfe00-f660-4be8-9a94-115a2bdec9b3"), 4555, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0592865f-97b1-430e-9a7e-8f6b93c608b5"), 4609, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0594328b-6c9a-4a8d-95e1-40c13553b75e"), 4228, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05a1a597-6a65-4fce-8d44-2e135a7f6f64"), 4023, 3, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05e26bfb-55e7-4688-af01-bcd4581f3197"), 4802, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05e2bc9c-7c0f-486b-a056-4fc1a4467370"), 4508, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05fe114b-7049-49b4-aa52-04393872f6f9"), 4501, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("060745c2-8be8-414d-93f9-b383ba673303"), 4402, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06146cfd-66d3-4cb9-a6c6-3b9cfe7d19e8"), 4452, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("061734ae-eb86-4274-b154-0b2951fb5660"), 4619, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("061ac64e-aec3-4200-a7f1-bb6fa84203bd"), 4425, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("062ddbe5-2efa-41ba-98c8-47c0e9dc323b"), 4002, 5, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("062ff5cb-b5a8-40b7-93e6-46efd42af370"), 4250, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("065102dc-dbad-4a9f-bba4-3d5449946f74"), 4268, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0691d4a6-852e-4412-b12e-98926e1bc584"), 4660, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06b19d09-8473-45c6-8ef7-b3a2367839c0"), 4801, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06b8ea05-0a0b-4bbe-94e0-a134725c940e"), 4650, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06d4b7d1-d99a-4f65-b741-7f75bb093b6e"), 4003, 2, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06d8bd27-369c-461b-80d8-349c9ca7f493"), 4238, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06db5d27-04a4-4fc9-9fb3-7a49a0f95806"), 4510, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06e722a1-5a34-47e0-8c79-fa0c2321b3d2"), 4634, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06e7d6bc-d93f-40a3-b5ee-834c31a3bc68"), 4113, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06eb2745-1555-4682-9b02-b1e246e31ce0"), 4700, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06f9a364-0f8a-407e-af11-d43d2acc4842"), 4463, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07286702-d161-4fef-964d-e73c17b6fba2"), 4611, 6, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("073d102a-2f91-4612-a40a-6823f9277aff"), 4610, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0759c287-1876-4509-89d5-8c3c98475595"), 4443, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("076f5e11-5907-48cc-8fdf-db2268e1faf8"), 4624, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07a19a46-9770-4166-9fab-5b3a44ebf0f1"), 4545, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07a508bb-6de5-4d2a-bd03-4f2b705f389d"), 4638, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07ad9fc3-69d5-48e9-8af7-127dd4a4c2f8"), 4657, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07c743c9-28a6-41bf-8c6f-ea229459f286"), 4504, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07eed65e-6ccf-4303-b1dc-398f3d900e44"), 4032, 6, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07f8cda9-fdc7-43cc-8323-cef0814723e2"), 4521, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("081050fe-b5f6-4e65-a484-3d5ce3ee74fe"), 4033, 4, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("081611be-8a4f-4e7b-ba16-89b2dcd2d477"), 4422, 8, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("083f8823-4a1e-4485-9b18-c119179bc2ac"), 4423, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08452b67-88f9-4840-aa7e-1e2c28eed280"), 4027, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08681ec3-094e-4e9e-9d98-2be2b8769e84"), 4659, 6, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("086fc80a-9e70-4612-a8f7-7edd26000444"), 4404, 2, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("088b744a-12bb-4432-8925-7412aba0a0ca"), 4405, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08a66fe6-11eb-44d7-ab5c-c873926262b6"), 4702, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08a6c43d-851f-4eeb-bad2-cf2d5fd868a1"), 4720, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08b95870-0515-4f6c-9784-9c1f43e8ab97"), 4618, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08eb042e-4bfd-4273-a38f-05d4792fb0e1"), 4609, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08f98ea2-a7fd-490f-a07f-f4e919d06c79"), 4219, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("090a4bac-22e9-473a-b36d-382a4282a2c9"), 4504, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0928a0f6-d3ac-47e7-80f4-470d3914dccd"), 4412, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("095203f1-bf6b-4466-abc0-edfe81027b95"), 4010, 2, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("099183d2-880c-4098-84df-4dfb8d31177f"), 4028, 9, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09a8ab32-7829-4546-8b7d-63d837315574"), 4417, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09bed4d1-f6a0-44ea-93c6-ebd121199d37"), 4022, 3, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09bf241f-4657-40e5-9a0d-0592200b0e09"), 4558, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09bffcd5-efb5-43ae-a198-2fbfcf4514ae"), 4516, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09d55701-92b2-4766-854a-58630b0ea962"), 4651, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09d69777-ddaf-4900-b37a-184c8c4c6bb0"), 4025, 4, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09f321ff-b2d4-4725-a214-18a6bcf1e877"), 4622, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09f77a29-d702-4d6e-934c-f6b0f700cfbb"), 4559, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09fbae79-421c-4772-8d7b-d03a48274899"), 4413, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09fe9281-33db-4b72-85c6-ba0906822b6f"), 4717, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a261d99-48e8-46a5-b727-1af6c9e6a307"), 4521, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a4733b9-6f99-4c95-a1c9-78fc6c893cc3"), 4554, 1, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a4ec82f-69dd-40aa-b897-de6351431615"), 4205, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a7c75b7-1294-42ed-ac6d-4458af1eb1ee"), 4662, 4, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a865dc5-4109-40fa-9359-f5837f8e01d8"), 4802, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a8e587f-91ea-4268-93c5-d1e8b08d02df"), 4321, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a9ceadd-56d8-4b38-9f33-4b9a229996ba"), 4454, 2, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0aa1ecb3-8dd5-4b5b-8b26-ab8a848fb7d1"), 4226, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ae0326c-d828-4095-8742-78f00a7cc7a6"), 4203, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ae35892-6b22-434c-af7e-25a4c74a7e3f"), 4254, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ae37ac4-9db5-45af-aaa7-c7f3fd41e433"), 4202, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b0e1ad8-65d9-42f7-8c09-2d25bfddba48"), 4639, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b0e6fec-a6d8-46a4-a1d0-c6f384c4f665"), 4214, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b343d99-5e2b-4ec5-a6cc-e402a39c582b"), 4411, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b354661-1e73-4582-936d-fd584ce582b5"), 4028, 10, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b3adcad-f370-4a40-97cf-fbca6cb94b57"), 4031, 9, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b44a330-548d-4987-ad25-78fa0369cc06"), 4625, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b5414a9-1a68-40b9-8c35-871266883e5b"), 4312, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b6108c0-64de-4506-a7f0-050985210a6f"), 4263, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b612acb-4b5c-422a-b1c5-136e7116bd9a"), 4652, 5, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b64a96e-11bf-4308-869c-8346432e1718"), 4305, 7, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b91ea10-63e5-4cce-8110-882051e1e455"), 4242, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bb0c095-2691-4e90-85c9-b14df32925a1"), 4806, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bbce5f8-5f98-40d6-8b0c-c94cec68a694"), 4706, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bcff0d7-609e-480b-8b58-c5e41af42fe6"), 4551, 10, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bd6f4bc-fc0a-497c-a32e-56a0d55b0d14"), 4527, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0be12837-4d71-4df6-a2e2-9f85d209fe4e"), 4204, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0be2fcda-92cc-4940-aaf3-d701f6c167a2"), 4613, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bebffd2-f3c7-4e97-b46a-dd67fe496a76"), 4621, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bfbf407-e500-4d9d-b3ec-70b9572c66bb"), 4407, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c07fde4-eabb-4194-84e9-cc02b571d738"), 4111, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c10c759-d883-4afb-9a04-264e2af62236"), 4224, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c2242bf-d58a-45e4-96a3-9bd01a687b20"), 4315, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c22e5a7-0159-4bfe-89dd-5c810639114e"), 4516, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c2d88f8-e5a2-4fd1-b7ff-f75a4108a9a3"), 4527, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c46cefa-f74d-421b-b311-d3a1b70ef08c"), 4457, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c4afa6a-ab15-4725-9940-ae1a8cd29315"), 4006, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c4ef974-6749-4211-a815-1fecf4a656e4"), 4214, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c504ca2-5ee7-4415-9565-78bd4a6cc269"), 4246, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c5b4ee5-e2be-453e-9feb-388fcdc9d9ee"), 4267, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c612aee-60ff-4e34-90bd-116a4469135e"), 4319, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c644db0-b02b-42f4-8e1b-f69ec5ed9ee1"), 4221, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c715d10-df58-45f4-abb9-84370ee435a6"), 4231, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ca4e12a-e442-4574-833a-83e25e045661"), 4606, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cc2282f-c49f-40bf-bbec-68cb4529c59c"), 4564, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ce65cf3-4fe0-4fcc-a6cb-1ca056058895"), 4211, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cee5990-1d2b-46ff-b01a-b48d8fe2f538"), 4650, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d1916ee-0f0a-4870-953e-0d7d20ec779f"), 4217, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d2e9a3a-cc86-46a2-ac56-1ad4a31ce132"), 4008, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d5b19d5-6923-4c67-b16f-d9a1c3f1f9d9"), 4702, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d63ce15-9475-4828-87b3-769e8e9f57a3"), 4107, 9, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d63ff00-efdd-4515-89f3-6b79eaace1c5"), 4414, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d70c12c-1702-4502-8d6e-13c2d049785c"), 4608, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d7c1c54-5400-4edf-a502-af9d3fff21c9"), 4269, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d8b2f46-e2f3-40eb-8101-66ce669b1f90"), 4272, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d92e91c-8388-49e0-9110-4946d7f1990e"), 4266, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0db675df-9e4e-4a44-bb60-47c42c2355f6"), 4800, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0db9f31b-6c82-4e8c-a65d-fe5118320bfd"), 4808, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dbf7c13-2aad-4ab9-81fe-b234d49b17b1"), 4418, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dc90769-c476-49b2-ba10-bb3b96490e2f"), 4503, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e057077-9ff1-4384-9bd8-f7342262a8e6"), 4434, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e11342e-f7fe-4c4c-bb44-54a27a76ac13"), 4104, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e26ce3e-c7a8-4143-a51e-f3b9042b98eb"), 4662, 2, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e3ffff2-5975-49a8-aab4-2c7f4f75c6b0"), 4514, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e495eef-f5ba-4170-bf18-1a1aeb1f7778"), 4505, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e6422c7-533c-4d6c-b919-95520875733e"), 4238, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e66c13a-7054-4ce6-ad52-ef1f95f8fe0e"), 4013, 2, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e786214-eb60-40a3-9dd5-125ed4703c3c"), 4229, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e7ea910-3e3d-4bea-b94a-8fafcb0d8e9e"), 4806, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e7fcecb-13e3-42a1-ab10-0a08c368f728"), 4530, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e9b5911-b3b4-4deb-81ae-d00f798d668f"), 4559, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e9c6b9d-d933-461b-9c7d-87bc5769d503"), 4703, 5, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0eab389f-63d8-471c-bbc9-813a927562e2"), 4105, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0eab4da5-79ad-48fc-bea9-bcbdb0377460"), 4023, 7, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0edd4e95-c25f-466b-beb0-f6ab13ab2a66"), 4320, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0edd5b3c-655a-4446-875a-a98efd9e72c9"), 4003, 1, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ef4ce35-7d46-475d-b27f-1df4bfd5648a"), 4420, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f0624b9-0ce3-40cd-8c26-5ca1d01ac71b"), 4112, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f1f5764-c302-478f-a199-9574afb07d90"), 4508, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f231a49-9358-4218-b1b3-4a7fa0b0098d"), 4505, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f346a21-f246-4609-8d27-42332535a7b2"), 4201, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f481c6a-a045-4c24-a170-f864a347911d"), 4219, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f69617d-cbed-4a0b-a30a-ab2855e921b6"), 4634, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f76c151-5db0-4f12-ad8b-1475a19fda2c"), 4520, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f7a1047-e2e4-403e-95f6-6cc6b9d90d3b"), 4710, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f95de43-ce78-4578-bad0-9acab5a7d31c"), 4300, 9, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f9e683a-80b5-48d2-8593-4a6a72ed9bbd"), 4461, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fcad394-b96f-4097-b34e-67d086165231"), 4427, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fd0a0c2-31e7-46a3-a054-efcd25c9a4df"), 4656, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ff52744-7cc5-4778-9eaa-360b83656a99"), 4806, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1006c56c-621d-46f7-a1fd-e794d891b4ef"), 4224, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("100dbe85-be80-474d-a138-64789d63058b"), 4256, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1033f849-fe0a-47aa-904a-18a251bb008d"), 4261, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10450b52-1659-4f37-9624-8a686af2e34d"), 4261, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1048f6a6-8cd4-47fe-a343-9f630b846381"), 4222, 6, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("105cec0d-7fcf-408c-a0c5-a68defc5da5a"), 4420, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10609226-bafd-4882-b6dd-863faceabbbc"), 4505, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10689690-c8cd-4ab5-bc48-7b4a064d1246"), 4536, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("106bfb64-6d7d-4848-9512-a7d0edbfcd1b"), 4212, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1072d21f-65c3-4a20-ab89-ac3692852f50"), 4557, 8, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10756b8b-2abf-4b85-8e72-e0b6f3265191"), 4437, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("107aa6d2-4d22-4b9f-b28e-df7bea53a2dc"), 4106, 6, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1082c134-5572-4792-8b11-0e5e14440e83"), 4802, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("108facc9-695b-43dd-b708-feaaedafe8bd"), 4703, 6, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1095ead7-f3c1-4704-9cf9-05059369515e"), 4200, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10a561ea-f1e9-4233-b1ff-8805adf3fe10"), 4255, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10aeecef-de86-4ada-8da2-15a557088c00"), 4234, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10c0cfc4-b4af-4ca7-86f1-3024f8492743"), 4541, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10c497f8-8820-4719-bb0c-b138af3152eb"), 4716, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10c7741c-813d-415c-a537-e581df8bde27"), 4112, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10c7fcbc-fb74-45f3-839b-947a8e619490"), 4427, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10d3d5dc-cd39-43f1-9088-3ef32b3eb76a"), 4236, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10f7fbfc-b4eb-4c22-9e68-94ba32f09f27"), 4701, 4, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10f9723d-d642-481e-8450-741559f93a4a"), 4216, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11051463-5f47-4303-b405-cb7eb09a42a0"), 4316, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("110a28ad-8509-4d12-a3f2-c3861804bbc2"), 4457, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("110e27be-2a15-4f9a-9859-ba62fa48e275"), 4019, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1117f43a-fb98-4e13-9487-421f04ca28f6"), 4418, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("115857de-c7ec-4788-a2e4-1c349368c600"), 4655, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("115e4057-7834-4d89-bdb4-90fb689ae9c7"), 4027, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1175f1e5-2d0f-4c0f-baca-c8a6ca33e509"), 4248, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("118ef228-cc90-4d5e-a804-36f859db11d7"), 4401, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11ba5f5f-6ce3-4732-b786-4398b631abd0"), 4100, 8, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11c39c7e-5401-47f4-8646-224bec49d9b4"), 4604, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11c8286d-9015-4f97-9751-ee5cc09fa592"), 4221, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11cfc05f-48d0-4fed-8031-6fb6fc8d4177"), 4526, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11f41012-3e4c-41a2-8665-c00447537b1b"), 4310, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1204cfdd-c58b-4275-b0d7-3a94cbad160a"), 4012, 6, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1211b698-ea7e-48f0-9ddd-ba2077383f86"), 4414, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("121d0388-aa3f-4910-b98e-3a2574f5e8f5"), 4717, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("123cfff6-8d86-47c4-8dbd-c6a2460e4722"), 4003, 10, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("123f275c-8459-470f-892d-ffb5ab6f52b7"), 4641, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("126cc03f-2500-4446-ae75-5660a7f63519"), 4266, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1275a5b6-0691-4e5e-8b91-317f86528dfc"), 4512, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("127ae74d-4673-4240-bee6-cf6aa082ee3d"), 4002, 8, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12929ea7-ebf9-40c8-884b-cd1b2b1ed55a"), 4603, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1296139b-9f0c-4e70-b7e8-ac4b482ef33e"), 4633, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12a5dca0-56e8-4f72-9d68-f918ff7346ab"), 4660, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12aae856-31f7-4a01-8604-160184b97381"), 4805, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12b0636e-2b6e-416d-a558-ca523b6ca5df"), 4428, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12c0823d-5dea-4503-a28e-e85d56ced502"), 4407, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12d7fabf-3b87-4882-ae3c-b817a049778f"), 4603, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12e8ee29-eedc-46f0-960d-2bc62e181835"), 4546, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1304a2d7-9e41-40f8-8341-2c46b81a7f40"), 4854, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("130ec4ab-d551-442e-961f-ce83b9b7eea7"), 4852, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1310faa1-0f54-4363-8a5f-df84e6206bad"), 4654, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("131167b9-5a01-4837-af72-01f79aea1867"), 4108, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1313edde-0970-4b97-a8c3-6f3a846f839a"), 4258, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("131b9e71-1431-4397-9004-e016921af70e"), 4023, 8, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13289b94-3b3f-4dfd-a547-a74358800bf9"), 4220, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1334ebde-c08a-43ef-bb41-0e2fb2ea0c0e"), 4403, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13433f12-42e5-42c9-826b-f8760fef5061"), 4638, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("136da838-2dc7-4361-afdc-a93591644796"), 4428, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("137d7f6e-f960-43f5-a5ab-b72527fa86ca"), 4273, 8, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13861015-2993-4bc4-a767-b503a86ae90f"), 4309, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1396cbec-eed9-44ed-851f-6bff5a4cf3a0"), 4535, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13975c28-87a3-4980-b375-e87d593a6de1"), 4309, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13ab03b6-5849-4882-b3ff-647e68977e83"), 4634, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13afba0f-1b36-45ab-8e18-83c1abd8e2f2"), 4658, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13bf157d-481d-4412-a47a-aff40109f4b1"), 4256, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13c00746-d855-4a9b-89e8-0489ce06fa10"), 4227, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13c524f6-ff42-43b5-93ab-857df32be3b8"), 4455, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13c898dc-1320-4d83-a65a-0f8ea2f44301"), 4611, 3, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13cc0c8e-5da5-42d4-90fd-507501f7c123"), 4442, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13d0945e-bc27-4e9e-bee9-03747831e92d"), 4633, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13d9c12a-107b-4b3a-b2d1-ccef1fa3ec42"), 4650, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13f62b3a-4a23-4563-877d-d7a6d5a44f1a"), 4107, 1, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1409d695-0748-462a-acf1-8237134530db"), 4625, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("145665f0-99c6-48f1-8332-feb0a3d1bdcb"), 4555, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("145d061b-6e51-474f-b221-127988a8d1f6"), 4710, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("148714cc-8006-439e-996f-0ee3ebc8b509"), 4427, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14da32cb-c55d-4cfa-a72f-ea6196a7fc19"), 4230, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14e4260e-520a-4a0a-b7cd-38fde8176d9d"), 4637, 7, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14e63c35-e0ad-455c-baf4-3ef84b56b95d"), 4401, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14f9714b-b1be-4d1f-911a-761b71cd24b8"), 4513, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14fe426f-73d6-4c60-bff2-fbac1e740105"), 4702, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1507910e-b2d3-4d9b-a439-10414bbbd546"), 4619, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("152d7574-8dd8-47e8-a197-c1173c182b2f"), 4627, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15390da7-abc5-4550-b2ec-3733310ec971"), 4459, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1547eeec-e81f-4770-a678-dedc9e09cae9"), 4035, 5, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1548a125-5699-4e89-9881-c9c158bc13ca"), 4529, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("154c146d-7296-4bc5-aa43-d98313b41a16"), 4244, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1556be61-e5e0-4f0d-bb69-179b7ea62569"), 4851, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("155ca771-f3e9-439e-afa8-9c60ba8a6a1d"), 4722, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("155d2840-ed94-40a5-9ff8-fe242d284e7c"), 4107, 7, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15a5c0cc-0078-4caa-8166-f0400844d748"), 4608, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15b34510-e739-4554-870e-e3a4a5eae648"), 4019, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15beef8d-d4fb-4583-9191-aff468f65871"), 4463, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15c618a7-22a2-46d5-9fb5-8bc5b1285b01"), 4641, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15d5da65-1c2b-4768-9c1b-f2b44f45c57b"), 4442, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15de18c6-fab2-4d12-89d8-ccb07832247c"), 4533, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15de3e8c-a9cd-42b9-b098-844876707e3d"), 4253, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15e113a5-3a88-4bb2-b1fe-7d7c9765debd"), 4457, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16108f4a-fcaf-404c-9bc3-25d83261c366"), 4619, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1649471e-0657-4969-ac5c-c28e72208a7f"), 4807, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("164c2464-a9ec-4886-b109-d3f231ec87c1"), 4545, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1658b4f5-5b00-47b8-8910-ec73285a8437"), 4252, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("165a22d5-4a82-4eaf-91b0-190b0079ce42"), 4006, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16651113-26ac-43a1-8ed4-3478fcc4f6ae"), 4711, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16797978-3055-4bea-b66c-66706ef65128"), 4218, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("167e2907-ea45-4865-8693-ebf63187dc7b"), 4563, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1681fa23-5daa-42bc-a059-d38d6d64b74c"), 4502, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("168b38e4-70c1-4d02-b73a-3b0746c8615a"), 4625, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("169c661e-7cad-4adf-9d9f-eb8ea0849e18"), 4224, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16a67e16-3a41-4a44-8f5e-dc6081e26c81"), 4104, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16af4083-ebec-4bad-8b40-2f1963516ce8"), 4614, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16cbbf60-35d0-4d8c-8484-6dc24f58e4de"), 4704, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16cffc6b-d552-4b7d-8a8d-b853c0195408"), 4102, 8, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16d10316-7f1b-4141-92f6-8d44f303b2b1"), 4248, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16f3ac73-783d-4cd6-ad2b-8841d0eda632"), 4305, 3, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("170a975d-afb2-4c8e-9992-a6522244a9b5"), 4313, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1725ee17-a773-4fa3-9a7b-0b045d6bcd6b"), 4708, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17414dc7-c43d-4403-8ca8-42e904fcda0a"), 4271, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("174cba06-0d97-4e9e-8f7f-d7ae90f58480"), 4006, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("176cba91-7de2-4037-b3b8-fa95ce197d28"), 4105, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1771a633-adb8-408e-b266-92d080511a88"), 4656, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1772b290-6206-413f-9f64-45a895eefe31"), 4241, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1794b824-a4e8-4b86-903a-bdc022947f05"), 4011, 1, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17995574-3d83-43aa-8256-b527ff8ec305"), 4274, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17a6aadb-2798-4518-8ef7-d8150a73e9a9"), 4320, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17a76a8b-8845-47a4-819d-e98c8dd75205"), 4300, 2, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17c780c1-646b-4f48-b867-838ab1bbe351"), 4465, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17e44e34-a95b-4449-9dc6-3cfb537aaffe"), 4310, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17ec0dd7-e3b4-4e41-8ddd-1e9a40b04e68"), 4447, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17f484cb-c2ed-43c8-92f8-390e0878436e"), 4524, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17fdb021-7275-444e-867e-e5937c66e55b"), 4534, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("180451ba-88c7-4566-ae33-006e9164dd94"), 4651, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18128e0e-c99c-4ea5-b0f9-e9a47ef68646"), 4009, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18132f9f-aa03-4b4d-8e0e-c17912bb4f11"), 4706, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18183181-06fc-41c0-b40f-721ae6e03cfe"), 4303, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18214228-a7fe-4d92-81d7-45f4aeed78ee"), 4452, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("182bc355-bd48-444d-83fe-0eec8b8915ea"), 4425, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18319b0e-2194-4593-8f06-c2916807da29"), 4321, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("183385d7-7f23-454f-a1ba-f69d49f4fb44"), 4401, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18751f22-40d2-4bb8-be0a-676d2460ba7b"), 4319, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1880e8c6-347d-4f56-a549-b37d552c636c"), 4012, 1, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1887aae6-5b36-4a61-b444-92b3f30cfe0b"), 4036, 6, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("189394c8-41e0-4bd9-a9c6-7021493df90d"), 4722, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("189dc00c-6b98-4d4c-9a34-81589712e814"), 4319, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18a5c874-f721-4a62-b26a-d6678094abda"), 4233, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18b1fc0a-3147-4c0b-87a8-f9b8bc4cdad8"), 4537, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18bf9afc-4c68-404a-8e29-b701548ad846"), 4419, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18f13945-24f5-416d-93ab-bb067fb21ac5"), 4027, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1901cfd4-19e6-45d7-bc8e-602e2c584d88"), 4213, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1903fe34-e494-499d-a755-71fe0c5fd92f"), 4319, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19322c6b-8980-465a-b3e3-ea5ba0b753d4"), 4021, 6, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19322c86-5cc4-47ea-8fc7-b9391336fb3b"), 4109, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("197bf94a-1807-4386-a293-acc63870aeba"), 4419, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19a818cf-a0e0-49f3-bf8f-6eade8e97059"), 4720, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19bc9309-48f9-4822-ad5d-13efbcf14eae"), 4037, 10, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19c29eba-5a83-4e24-93f5-4c6b2e38d69b"), 4512, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19ff7727-695e-47a4-9ece-1f6cc0a36a65"), 4302, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a266dea-cc8c-40ad-89ae-9ac32d36eff3"), 4202, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a4e20ab-a2b6-4474-aecd-04054b8cf666"), 4429, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a57e2ff-5fc7-49c9-85d8-29aba237e878"), 4525, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a585590-1d79-4106-935a-ddf969288901"), 4000, 10, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a792f13-9e75-4225-bcae-8774d197b78f"), 4229, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a81f8fc-db1e-4ea0-badc-e26a3cabbb7c"), 4031, 3, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a8b9eaa-2490-48b5-bf7f-1dbf3c680d31"), 4531, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a9df0ab-e072-478d-b8d4-2a99f27b4566"), 4460, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ab6efa9-9ce3-4fe6-8795-b13d84e6cf1f"), 4113, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ab8a637-9e24-4492-88bc-b2c22da02bec"), 4538, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ad52fa6-2574-4fc3-b17b-82f94c95aeed"), 4522, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1adfd9f5-b10c-4519-8500-4825bbe0b714"), 4450, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ae10913-9687-4fbb-b63b-9b4c1e7902ee"), 4527, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ae2c687-0d61-424c-89bb-fec5119401a4"), 4112, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1afeb4e8-72c5-48f2-8195-c431b4890cd2"), 4215, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b292609-c417-4d7f-af2a-42e4497e97c2"), 4500, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b3188ed-bad3-4420-9616-cc2681f044a6"), 4554, 7, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b3c37b1-b06e-4c82-aff7-a10a0a9bfcb1"), 4324, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b432a9d-b851-42ce-b6e8-6f5d863adcf7"), 4536, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b5ba81d-b8d9-409e-a195-da10fbc742cd"), 4709, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b8776d9-a112-455c-97fc-6d622aa6948f"), 4453, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ba5dbdf-f7c4-4935-8286-b6814f615cb0"), 4521, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bb8997d-4143-4f39-bfbc-91a69df63cd3"), 4525, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bc2dfb6-4efa-4d15-b6f8-2b86f5118f8e"), 4012, 10, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bd6f8fe-3f7a-4023-b4ba-4df3809d726d"), 4023, 1, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1be92e4b-3016-4a6e-a538-d54fe159ec12"), 4563, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c13c9ec-e38c-43a1-b60f-857a77e6e9a2"), 4007, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c1c7c79-5d32-42d0-8723-b405e0f9d097"), 4413, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c1f2edd-58d5-4240-bf72-e98c56613662"), 4605, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c47fde1-093d-43c4-b7cf-564e19139dde"), 4716, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c643622-15de-4fca-9b95-c76cc29b9cec"), 4017, 10, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c6c2dbd-eaf4-4258-95f6-0302cccf41dd"), 4208, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c831bb7-4186-4d14-a58c-0498f25fcd0b"), 4563, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c8983c2-7965-4f6d-b660-f147ced24e4d"), 4609, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cc70387-50ff-438a-8873-f8aa31ff1f7c"), 4235, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ccf7134-a400-4d73-aa23-df043e03cd6c"), 4602, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cd1560e-7807-47c9-8e66-611cefadb434"), 4520, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ce1ade7-4437-4763-87df-6f5c77786997"), 4008, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cea50db-f553-45b6-b820-fe1706302be0"), 4225, 7, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ced50f7-f120-4e4b-9940-675f93a16318"), 4211, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cf2de7c-8778-4bff-b712-138ea0f49fd3"), 4416, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d10f7a0-0eb3-45f0-b012-d016a80a9b14"), 4004, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d1c0c4f-57dd-424c-b997-2a18e2187fbd"), 4711, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d3ade4b-af85-4761-af50-abdbd6c9d6bf"), 4561, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d3e6797-4e50-4d82-9c03-20e2c53a5bf3"), 4446, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d416cdd-e6d9-47d2-9980-4aa2d12d87d0"), 4035, 9, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d452e74-fdcd-4018-a6db-de3dc45cee5d"), 4263, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d455f9e-8e07-4738-bd9b-fdfd570776a2"), 4112, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d635722-cf7b-4393-88cd-993083546aff"), 4632, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d760faa-2851-4edd-b964-ddbcac4c32e9"), 4810, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d8a907d-fcd8-441f-a04a-ee2c0aefe7d9"), 4223, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d8fba81-38c7-4d29-b0f1-89d7538ed4d8"), 4503, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e05fd5b-98b6-4411-8f3f-98765226434f"), 4206, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e1edc27-9069-45e3-8e65-3cb244d97162"), 4265, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e1eeb60-fc3c-4bc8-a9e5-ef508fd40d62"), 4100, 1, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e3c538d-a66e-455f-8b8c-415513fdcd0d"), 4513, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e467990-13a5-4c2a-99e6-c09323ea3e10"), 4556, 3, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e4bb7df-095d-4bb8-86c3-36ce030bd219"), 4020, 9, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e65704d-02c8-43f4-a017-d3bec930970f"), 4264, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e71d061-4561-482d-a524-8934cfb9f1a0"), 4005, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e898d9a-0581-44eb-ae4a-eec98b7b19fa"), 4241, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e90ce90-0237-4d91-bae4-dca20fd33a54"), 4002, 4, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ea059f8-ff8b-4e4b-bc94-48f374d06079"), 4431, 8, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ea92f00-8b85-4895-83c0-e192c312c225"), 4316, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1eb7ddb4-d74f-42cb-a175-64a8dafe5983"), 4418, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ec243c3-ea5c-4e04-913e-21b1a2639f8e"), 4640, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ee3561f-7240-4154-b2d6-05b23b08bb50"), 4526, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ee39af0-417f-4a00-a885-af8d7f603d36"), 4217, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ef1012b-81df-4b38-a847-a83d3cf64398"), 4658, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f007aae-a5c4-44ae-86a6-bf493a399e22"), 4266, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f135106-4461-4941-9ed1-e0aacef6e1fb"), 4223, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f3c0770-fb26-46b0-b3f6-772474bd82b0"), 4100, 7, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f560861-bfe1-4535-bd14-28eae4982343"), 4029, 2, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f5f2f03-043d-426e-b8c3-b07f7b672062"), 4702, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f640e26-74c7-4ffc-b4d7-77f95b2885e6"), 4511, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f81d716-7506-4a37-8318-11e012aa4785"), 4404, 3, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f83325c-c759-4c98-a9a7-69745f2cb9e6"), 4451, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f858363-845a-48d5-b46a-4752ebcc9e64"), 4233, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fd94dd0-7dfc-4728-80ad-1eb4802f571f"), 4414, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20402c68-f150-4913-88e3-c6817ec150a1"), 4236, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20457e6d-27e3-424c-9855-bc46019f97f3"), 4301, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2056a6e2-9552-4165-9aca-b48770312dde"), 4005, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2064e461-5854-4ee2-a7de-b3f7e7a142e9"), 4616, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2083f6c7-6b16-4aa8-bfef-824eea48bdfb"), 4419, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2098ef70-0618-4dd3-be73-ec3b4985c86d"), 4452, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20a37eb8-5610-4c89-ac78-bb01d2dd72ba"), 4035, 7, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20b021cd-1899-47b1-a42f-51d3fc5cf9c1"), 4416, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20becb0f-dde2-4cd8-89fc-e87bf03905f1"), 4306, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20d9806c-69da-4e9b-a694-af61b7477a47"), 4301, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20dd040f-2728-4f5a-9dd0-0b6c7386d3e7"), 4704, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20e41911-7979-4f27-bde7-67ffef97854a"), 4434, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2111dfe4-d676-4712-8317-9d31ece6ec81"), 4324, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("211f99f2-1cdb-4cee-9805-396cd2e2ad59"), 4502, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2120c184-8783-4552-8120-d0bef46b5bc5"), 4223, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("212d4e7c-1b93-424b-8470-27a197fcf787"), 4854, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21386de4-8d97-442b-918b-d45678e55d04"), 4009, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21393292-0ef4-4ec8-a25b-97132d794712"), 4224, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2144d155-5f62-4cfd-9731-1d934114095c"), 4712, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("215f820b-3f29-4dd3-a1c3-02711aa09bb6"), 4452, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("216e7650-a186-4cb3-82f7-b6fa3baa96ec"), 4447, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("217c60d2-f58b-41da-ac13-5c603cd5a5d3"), 4106, 9, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("217c8829-4719-42e1-8376-aed40bc81a8e"), 4718, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2184d73b-7cea-44d8-ad97-e139dc9c9991"), 4427, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("219ddaaf-c309-4db8-8b16-d8f98844974e"), 4513, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21a800f6-aae8-4ff8-8654-96910ef9249f"), 4030, 9, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b52eae-6250-405e-bbc7-82615b777ab1"), 4510, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b58c70-483e-4dc8-b825-46af3a86f2a4"), 4808, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b8a9d6-4f61-494d-a6fb-51af47fcff02"), 4317, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21e28998-71b1-4b96-aac4-3fc6b543f670"), 4249, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21ea27d8-0494-44db-9259-3a2a50319fb2"), 4544, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2207d028-e697-41d7-ad49-a3bf2dae3151"), 4009, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2214ddd0-cd6d-4b95-9a79-5a701940860c"), 4556, 8, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22167bcc-3aab-446c-903b-335629328f28"), 4524, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22208b21-7c5c-4ab5-95ff-383ea1135ce7"), 4107, 6, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22333763-9be1-4ce7-86bd-f7cb704ddd0f"), 4033, 7, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2249d34d-2ea0-4f9c-a35a-15f52158a169"), 4402, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("226dbbe7-f677-482d-bf76-07eed301528c"), 4512, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("227a532c-2c4a-45d7-ba09-152134f169f4"), 4243, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22941a25-18c4-4f83-b11e-ebebcded486e"), 4721, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22a281d2-5128-4473-bb2b-7320d0c8929b"), 4433, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22b446e1-4db5-443e-8407-0b4481b493a8"), 4623, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22c0ef15-0cdd-4d21-a46d-f2d496afbdbc"), 4308, 10, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22cd3b03-b76a-4a87-b7d4-baaca5e12ffe"), 4443, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2300b60f-1c5a-4d61-8fd8-56894a645704"), 4211, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("230a2639-5159-4c65-9b5e-012db9fb0e70"), 4552, 2, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23115cd9-0de8-44c3-808d-bc645dc17bad"), 4267, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("231217f9-635e-4cfe-9178-32a18e44d766"), 4706, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("231efc84-ff18-43e0-aa81-213cd2a152cb"), 4455, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("231f942e-2438-4a78-894f-62b116cfafd4"), 4415, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23371bd9-eabd-44f4-a70e-25873c39abab"), 4459, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("233e8e76-8b49-456e-977f-66ac98871be8"), 4722, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2343f3ef-2ee1-4a60-ad37-20a1acfca603"), 4437, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("234f7660-558b-4bb1-b265-11a3335dae0a"), 4305, 5, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23673473-36f6-4d04-893e-50ca587ba085"), 4213, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23925d72-120e-49de-b46c-f3e28a1e9196"), 4609, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23954ad7-5ea8-4cb1-a438-8ce6bf2b273d"), 4429, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("239bb0d2-1d89-41fa-aae6-62ce928c2fd8"), 4600, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23b52115-8bfa-4c36-b7b8-be4332037c4b"), 4017, 8, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23c13830-412e-47e7-ae63-dabb73dffb3d"), 4317, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23cf15f8-aa3f-43e3-9935-716e16da6891"), 4112, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23e317e3-a774-40e3-9717-10fdc993faff"), 4216, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23f1ed95-e0aa-40f1-a9f1-6f1b47d4b631"), 4714, 1, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23f6af53-bd6c-4cb7-93c5-a9029bbc5dc7"), 4416, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("240d5eff-951b-464a-8004-c75fb20f2d80"), 4634, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2435ba23-a51a-4128-a985-d00e856f9c39"), 4400, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2443154a-a36a-4264-a103-4b1511dfdd79"), 4533, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("244cbcca-9a9f-4f5f-bcf2-8ea5d7dce304"), 4032, 1, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("247f1d80-9fd0-4ec6-bcfc-477ce3e8aac6"), 4028, 7, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("248cfb70-0968-4243-8071-6bdc56d51aea"), 4850, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24991aad-e3a1-4232-9a57-4f5bf0e8ee8e"), 4211, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24a625f8-3d47-48ef-87ff-64a09fb2735d"), 4562, 4, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24ad3549-3c9f-4fce-a857-2b0a3025d12e"), 4512, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24b66488-2a56-45d1-9748-d8e18aa86bee"), 4853, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24bb328b-fb9a-4adc-859c-730309028ad8"), 4500, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24caf6a4-9147-4321-927f-79c52b9b9f42"), 4524, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24dcd35c-e048-43fd-90af-4a4c01ba3019"), 4034, 6, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24e0f52c-a4c4-49b5-9cb9-4099e8091fda"), 4304, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2511df58-8469-42cd-aab7-a3b0dcb3da81"), 4321, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("251f998b-8ea8-46a3-968c-5c8a846e3ddd"), 4556, 10, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("252063e0-15cf-4f52-89af-acf5fa281164"), 4463, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25224c63-4094-4587-b3e7-f77498ef23dd"), 4001, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("253253e5-8afd-47f3-bc0e-85401d882b1e"), 4251, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("255daa03-98e3-4726-802f-2a5a3c4559b0"), 4456, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("255e89ed-9b8b-48ea-ab50-966ac5245735"), 4034, 1, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("257f8dac-fc26-42d9-8ac5-154b6676be02"), 4259, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25906e7e-2d8d-4aad-8164-28577e80c266"), 4033, 9, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25939d7a-5367-4e6c-8a35-f2baf78987c0"), 4217, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25a8612b-04bc-42b6-9afa-21c7f3c9288d"), 4442, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25aeb1b6-6693-4689-8022-41a57bf4a7bd"), 4203, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25b6e251-a257-4e4a-9184-692947b6cb6a"), 4712, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25d44d1a-46c6-46df-8a38-6e722b9bc295"), 4251, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25e4c16d-ac9b-43a5-8a30-3e140b6b03d0"), 4102, 4, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26173802-fddf-4c47-8e5d-253a330ca5b8"), 4801, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("264bd7a3-dd7c-41b6-9fd9-067870adcf76"), 4243, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2658c9d0-c46e-4fcc-adb4-56d484c004c3"), 4271, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26696a29-a72b-4ec9-8c0f-47e01284381a"), 4257, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2669bf37-ea96-47e0-ad5a-e5cb8c445cf3"), 4544, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2693db1d-0380-4725-bee8-436e996a15d0"), 4723, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26a38794-4b6d-4d6f-95c3-fa4ee3b4f537"), 4106, 10, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26b29d8a-4b96-40ea-a211-cc1bfa23fe03"), 4113, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26df39bf-85da-4753-b51d-00f87ff4fc79"), 4256, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26e1c3a1-4279-4663-9031-755ac702deb9"), 4460, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26e48917-1d2d-4d6d-aaff-1ad0cbe72e75"), 4662, 1, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2745f9d2-8480-4582-b41d-9083761bf9cf"), 4232, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27601873-056f-4a17-80bb-7343b862e727"), 4406, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2762d295-bb46-46f7-8e3b-2491029969e0"), 4629, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("277c31b9-12a7-41b7-99f9-a2d902df36e3"), 4265, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("278b2003-b954-4835-ab44-7705444a9e3b"), 4234, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27949522-326d-4d68-a1c9-0cd3b420c15d"), 4635, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27d2dc3d-36fb-4d5c-ac76-00268af397d6"), 4300, 3, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27d41d4d-ed44-4bd4-a697-65cbaf2dd2aa"), 4455, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27fd2f1f-3986-4a17-aabe-0217c5ae324e"), 4721, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2813aaa0-61eb-4e07-a5f9-5b7ccb605bd9"), 4621, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281b5948-55ff-4852-b881-57beac7e66ed"), 4453, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2826db9a-035a-4ef4-b0db-86db1cff253c"), 4312, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28702fa9-4b4f-4e91-8901-9157a6443efc"), 4406, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("287d7c90-dfc9-4d4f-b113-550e41735a57"), 4106, 1, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28893cb0-597e-451a-8dcb-a8824aad26db"), 4437, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28921239-b3f6-46c2-852f-0c3245bae3b6"), 4805, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("289b1d71-b60e-43dd-acd5-5a218fbf9da4"), 4413, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28c73cab-9231-48bb-8adc-6fe499395723"), 4501, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28ccf74e-6aaf-4b19-a245-ae4eb0f2ea67"), 4304, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28e274c3-7121-4344-9630-6d0547dab316"), 4658, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28f12714-66e8-48e1-bfa7-6fde4c8e641d"), 4605, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2907096c-c27f-4360-911d-07807281073d"), 4807, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("290ac9ce-2dba-44a1-b997-058131ef9493"), 4521, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("290eb197-cd5e-45ca-9ecd-3f670cc9c199"), 4409, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("291ee2ab-e078-47ba-ba84-522317deb067"), 4652, 10, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29256eab-9836-4f09-a032-099bc6d3ae75"), 4006, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("293c289b-c102-40a0-9951-5dc9e9fd3b4e"), 4705, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29482c50-2abf-48db-a50d-8afc640d5c23"), 4227, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2950de56-9e8e-4439-b06d-776ab963769d"), 4273, 3, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29ab1b17-8fe2-4e35-afc4-c1ab95af1a6a"), 4525, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29d3dd65-d0c4-4fe0-83e1-6d50c8159e4e"), 4431, 10, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29d59b1e-ef8e-4f18-92e0-6d1ddd4c4801"), 4524, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29e54975-5faa-4fa5-b2b3-d7fbba801bc6"), 4267, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29e8d8c2-2fb0-445a-81b1-c222ad19395c"), 4201, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29f543bd-c8ce-4e49-ae01-4b4833d8fad4"), 4658, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a03aef2-eefd-44f9-b09c-9614bf03789e"), 4223, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a230702-fc03-4335-a4d3-833d4b8960c1"), 4237, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a3f8aee-1881-455a-ac52-1ce86e469c57"), 4102, 7, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a410515-7e65-4def-b27b-52b3261ab9c1"), 4247, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a42e30c-895d-4dc7-909b-2a1399ae9299"), 4564, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a4916ca-8898-4f09-bb63-d628f56b6090"), 4700, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a668275-75c4-4191-9ee2-4ca3f61eb4c7"), 4604, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a6768ac-cbc1-4841-bed4-1a2fbe5654d3"), 4635, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a977f07-c068-4482-875d-060ad3e13080"), 4662, 5, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2abe7d89-28ca-4a3c-a05a-63ae007c6b20"), 4105, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2adeaf45-0825-4607-a8b5-433a64aa1c67"), 4532, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ae7354a-fb3d-4f86-852a-d03f05faa12e"), 4007, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ae9e3ef-66db-4db3-8121-1e16c825b9cf"), 4460, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2af713f9-f945-4e57-9f51-2e240c711cb7"), 4427, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b2f2d1e-5fe1-4c48-b03a-f8fcefb2b7dd"), 4252, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b5a523d-4ee5-496b-b11b-6bf203db9dfb"), 4634, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b5aa978-39b6-4699-b9d2-6e869ba0c26a"), 4808, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b744369-c972-4745-a48f-f41e25546228"), 4608, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b85ff60-d4b4-4f2d-b033-41625276b1ca"), 4454, 5, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bc74c18-2854-463b-aea4-59a5ea823d30"), 4710, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bdfae74-1726-40db-8813-035ffbc9c207"), 4255, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bf120be-c363-4104-a185-e90cbdd8411e"), 4851, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c28e2ac-028b-4905-a2c2-0445f6828949"), 4850, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c30731f-bdc3-43df-8ae3-9e052a111f8b"), 4421, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c472fc1-b3bb-4758-834a-886b4bc47aa3"), 4455, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c4b85ba-525e-42f5-b05d-7307bcfdd303"), 4323, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c5c08b6-da30-4a38-bc2a-30f74d5bb73e"), 4657, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c7ca81b-7fdf-4514-918a-8404032c99f6"), 4316, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c8e35b2-4c65-41f4-bde0-f909b7d76f9e"), 4663, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c9b2895-5065-4f8a-8517-fe18d696284f"), 4538, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c9b93a2-b4f2-48b8-8d6e-28541a185a48"), 4804, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ce3b09b-af1a-4b3e-8986-6a7004fd0f50"), 4430, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ce7a598-95fa-4723-ba5b-bd689cb40e26"), 4245, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2cf7dbed-6e1d-4ddd-bbd5-16b01c5b17c1"), 4513, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d109db7-1707-4383-b0b1-ed191fcf0793"), 4224, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d11e456-d73a-4a65-a7ab-65c913e9d13e"), 4705, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d1c0ae8-915d-45c3-a7e1-c9c72535a4f5"), 4655, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d296910-cf7a-4df0-a803-5541e9363218"), 4854, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d2fa7b0-e412-43a8-bdf7-c01712c3932b"), 4709, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d3446b7-6a2d-4c4d-9872-35be8f72c47a"), 4311, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d407df6-364e-4839-915b-af098319e1c1"), 4457, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d464182-9486-48db-8064-8639dc06746e"), 4007, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d50b39e-eb4f-4590-8113-496cc97f4c0a"), 4418, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d58cc8f-a9ab-42dc-838d-0f9973466978"), 4604, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d668c5f-77fd-48d2-bce8-571ae780f22b"), 4536, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d68aa51-aacf-41d7-aab1-d3070da5fd8b"), 4553, 3, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d69329f-c4d5-473f-a42f-fcc0eec9ca79"), 4563, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d81ec31-1eb4-4050-85ac-9257621cacb6"), 4551, 8, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d85e674-d7c5-4f98-819b-4055522aef90"), 4269, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d979caa-bbc4-4eec-a538-3f02c869ce76"), 4809, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2da0aa43-3632-4b4b-bf15-ed2b381f937f"), 4101, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2db90ab1-5e1c-4797-8b1c-b1a39f48d004"), 4661, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2dcc7588-e322-4887-a9d3-8091001c7376"), 4322, 6, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2df234cb-5763-44a8-9e1e-3cf20ae0ffe7"), 4559, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e123abb-b8d3-4eca-89db-9da6f9998a6d"), 4014, 4, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e276940-ca9d-49fa-81d3-c421cadc88ef"), 4015, 1, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e2fe9a1-2182-41d2-8be5-61712b831991"), 4261, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e546024-b418-42ff-835e-2937934488e5"), 4226, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e8c4f97-2859-4f88-90f4-b55205e2a4b4"), 4209, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e9d14b2-b47b-485b-941e-c73c9516b65c"), 4231, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ea20f2c-a848-4b98-ac09-2e2a335126f3"), 4700, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ea2a10d-fff1-411a-ace6-0a11d08649bb"), 4557, 5, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ea3d52a-7e17-417c-9edf-5bea158a82c5"), 4004, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ea9662a-6302-4672-9b43-86b841a9e180"), 4560, 9, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2eecc74a-bec8-4d84-8283-91a9a4b79122"), 4100, 3, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2eef8064-338c-4e94-a7f3-13c356576e42"), 4018, 1, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2efa27bd-03f5-4a8b-8ebd-ada6a93e640e"), 4618, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f276417-68e1-49a2-bd4d-08e9722aef1e"), 4628, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f412981-55c5-4d3d-9de2-598a74555004"), 4225, 9, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f6fa29c-a0f9-42bb-acc7-92e04d8eb984"), 4708, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f81631c-78e6-4e96-a59f-4fc43ba1fe92"), 4400, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fa185ab-bb06-4ae9-8759-ca445b42f652"), 4636, 9, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fabfe57-b5ec-4e35-9aea-65ec913905ac"), 4101, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fd9ff94-5fd8-42d2-be40-758aa615455c"), 4245, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ff955d1-4ebc-4100-8d80-9f8aba0cd4ed"), 4509, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ffacd6b-068b-4278-aa98-2d76bd15e005"), 4630, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("303314b8-4916-4761-bf2c-dc6deb1c1d54"), 4019, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("305039a6-87b4-41f4-84b9-8d3199f28d7d"), 4527, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3050c280-f82a-485b-8938-772b8030a382"), 4451, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("305d81d3-2f3d-41e5-97db-1ce227c4961f"), 4320, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("305ebb79-843f-422d-8dc6-d0fbaf981574"), 4430, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3066bc61-625d-4949-90dd-b62d72a71cc7"), 4115, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3087f869-d324-4741-8baf-807671716660"), 4532, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30e032ff-2e37-483c-b0ee-34d4b2bca0a1"), 4640, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30e4afb5-b586-48c5-9c5c-875be0060636"), 4229, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("311536e9-e206-427b-9b72-87121b297159"), 4304, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("312755fb-3b41-4d3a-bb33-f201797761c3"), 4637, 8, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("312a16bd-d065-44c2-b71b-0bff1e3d3fe8"), 4638, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("313d3b47-0948-422a-9577-70c45e39572e"), 4000, 8, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31456874-661f-4803-9ee0-d4ffc725501e"), 4320, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3153278d-3d75-4a80-bacb-cb26f982b0fe"), 4420, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3156f92b-af0b-4741-ab7f-2faf70fe6b6d"), 4535, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("315cffd0-ef67-49ec-b092-f3956615a4ab"), 4302, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3162f547-f266-4375-a25f-12fbca2d1322"), 4541, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("319f6dc1-ad76-4499-9d3e-bdd3670ff3a7"), 4109, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31a0bda7-3641-4c98-8960-5ba30240590f"), 4463, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31c5dc3e-d62a-4bd6-ae04-66eecd53a737"), 4215, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31c86a6e-6134-4e5b-a2e2-c3447b06fe85"), 4700, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31c99a09-963e-4f14-abfc-ecc2689775e3"), 4539, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31da54ef-285c-4bf6-9aac-248300150c06"), 4244, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32026001-d56e-4204-b68d-1b63fab1a270"), 4209, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("321d4d07-2a75-449a-b4fa-313ee384810c"), 4561, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("323c5831-71ec-4bc3-a64c-25b0b89e7f94"), 4261, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("323e2193-8779-4058-a1b2-cfce13223ef9"), 4537, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("324ee159-357c-421e-aec9-deb50664b9a5"), 4660, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("325735c3-a112-41fa-a051-0241e2008fa0"), 4021, 3, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32638270-7c65-4f8a-b373-ff7c498f6c76"), 4014, 1, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3266b2d8-1b88-4f36-876d-605b0d665738"), 4205, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32838b21-16fb-4be7-b839-c64ca1a23067"), 4318, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3286059e-24cf-4361-8207-e31fcbacd399"), 4307, 8, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("329eeb69-2255-4e1b-8da4-93f78840101a"), 4235, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32a732dd-8a25-4df1-92d9-bcdae5d5aa5d"), 4609, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32d7fd78-bc8a-401c-be2d-37a6924e949c"), 4428, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32dc505c-9274-4d27-b552-a153bbb3b865"), 4264, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32f29a8d-7de9-4274-b92d-1b9490ddd45a"), 4547, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("331c692e-1eee-4058-87ec-9429f1acc14c"), 4269, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33209170-d956-40f4-b438-b54e48592077"), 4015, 3, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("332cd2bb-39b4-4152-a9da-e7df268fe5d1"), 4620, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3339ec5a-1fbd-4fcd-878e-12d7f0662e05"), 4652, 2, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("333ec1ef-1dc9-44fd-b54a-f5171ba01c98"), 4705, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("334b8083-433e-4dbb-8d76-ffcc9fbf5856"), 4710, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("336388ec-c949-4aa5-9f14-e7e5818ac9f8"), 4234, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("336b5a1d-9ba6-45c6-8005-befdf38e5518"), 4520, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33759bca-2217-4e53-9dba-2f38a57a55ce"), 4436, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3381cf1d-3777-45bf-8fc6-0db059735c88"), 4503, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("338ea40f-dada-4e7d-93ac-9dd1a63459d8"), 4629, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("339748fb-da46-40bd-bab7-6b258154b04b"), 4226, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33bddefc-46cc-4e1f-9121-c1dcc4ddae6c"), 4518, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33deff24-339e-42d7-893b-b5e66d952edd"), 4634, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33e262ca-0269-43f7-9929-ffcd5d1f952b"), 4109, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33eccb8c-5441-4b9b-8f97-dcac198f08f2"), 4718, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33f65eed-6fa1-491f-af4a-3733f473630e"), 4037, 7, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33ff3e1c-91ad-4463-bd7f-953eb75675a0"), 4239, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("340ba1c4-5512-4b47-97aa-9f1bcd094d5c"), 4026, 5, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34117d42-5ad7-4a12-b84d-063b172ae8c5"), 4530, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("343816cb-9d7c-4b48-b834-3563cb9e1de9"), 4220, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3441b279-9904-4f2d-b4ec-7094f8c2bd48"), 4318, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("344526f3-87aa-4dcb-b31c-93700e863a81"), 4224, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("344b9d74-a523-42b0-8b60-27457bc94775"), 4433, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("344f0b6b-bac3-4de9-a00a-3db6dd29051f"), 4560, 7, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3453b591-15d8-4c96-b90a-72dce2ee562d"), 4425, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34561bad-10e6-446c-8a54-bec973b24e8c"), 4114, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3484652e-a82b-46a6-beec-049e8763256a"), 4722, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3498d57d-8413-4c32-b09a-113d6e771d28"), 4246, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34b5bead-9d0b-4d2b-abc5-338046e890d5"), 4011, 10, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34c15063-42a6-462b-a695-3ca095d6c4c5"), 4315, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34ca6fd2-d637-40dc-92b3-225ba055aa66"), 4807, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34d5af01-e93c-4e20-a628-2eb1726c744b"), 4630, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34eb373d-5b48-449b-b009-167ddd07ebb1"), 4532, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34fc8461-34b8-4566-bb96-6585f805108f"), 4113, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("350981fb-4112-4901-8344-f6f487ad92b8"), 4323, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("351eb545-267f-48c8-90b2-a991dd52d52c"), 4228, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35339b79-988d-4f97-826d-a6e28269f3d0"), 4273, 5, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("354bb7c0-694f-4b46-9c6b-46f0875208ae"), 4722, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3580eb0f-13da-4385-8784-b7c2ab0c6fcb"), 4322, 9, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("359545ad-f903-492e-9f19-f976a1fef8fc"), 4103, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35bb7759-1b4c-4759-b638-7bda07b8d20c"), 4206, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35d367f2-61ea-4676-a2f1-1b5e5f507e0e"), 4538, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35d5304a-b1ea-4848-9476-2b0fb4d6b804"), 4562, 7, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35e98f7d-5498-4cb1-b4c5-01cef8844ea0"), 4532, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("360caa31-3f4f-4b41-8ebb-9f2fda6301bc"), 4446, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("362317f3-d864-409a-8944-863776ae0322"), 4264, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3628bcd6-795c-4b8c-8363-f15132670df9"), 4557, 10, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36298f30-2d17-426e-bd8e-918f6be622f0"), 4032, 3, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("363048bc-ab22-4f90-a69a-fa90089f2825"), 4228, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("363cb51d-aac7-47e8-9c93-9824d4a9bbc3"), 4621, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36594ea7-2428-4c1e-8282-7e8b02e722b7"), 4800, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("365f43fb-c34e-42ae-a4b6-320b3f49c69a"), 4518, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("366be447-8d9d-484b-9ee4-291bcd04062f"), 4613, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("367990a3-c8c9-4a86-898c-246ec9d1273c"), 4239, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3695376e-d684-4ba5-9ff1-82eabb082ead"), 4207, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("369923e4-0fe1-47e1-901e-8d226a14cc30"), 4407, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36c267b2-97b7-450f-8002-c0dff315a2f8"), 4105, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("370403a9-9762-4c9d-af0c-0f66b4a95897"), 4453, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3742e4d0-cc7a-4a93-bff8-87fee12815ef"), 4612, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37457ad9-2e6e-4802-a434-38c436dbb857"), 4234, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37653650-fcfb-49a8-a14f-b6a1c345fac9"), 4552, 10, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37667dbc-1f95-4f84-afe9-b466a1c52c6e"), 4500, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("377784d9-fab2-4286-a0d8-113ed5affdc8"), 4619, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("377d5a7c-a1e3-45f4-ab2b-955da86c0f25"), 4241, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3788cca3-85b5-4b0c-97f0-2fdf564d78b5"), 4008, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("378aec9c-51fb-4e94-a427-be2807c54d82"), 4708, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("379c692d-be60-4fa9-b5c1-45e22987d1a7"), 4651, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("379ecfb6-cfa3-4699-ae2a-b29f1738f8f3"), 4444, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37ae7d24-0c64-4c07-86d1-ff01eb9742d4"), 4712, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37d1b080-e41d-457b-8156-811c955771ac"), 4205, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37eaf94a-855e-428c-9d18-073e64ff07d0"), 4429, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37ef959f-16d6-495c-af50-da0de022a73a"), 4242, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37ff7c67-3c49-4f14-94b5-a1cf2ab456b0"), 4537, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("380286b7-7fac-4714-a8f2-007b671ea043"), 4021, 10, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("381d71a7-bb22-4572-9d25-f5e304275e25"), 4850, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("382e0fc7-00c9-4d1c-b19e-ada6cf65809b"), 4230, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3851466f-74c9-4644-b939-cddd3977df94"), 4543, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("385216a8-de98-42c3-acb1-f9adce2faf37"), 4252, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38587533-c9cb-4595-9157-1896344f06b1"), 4233, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3858b37d-5f4c-4ff9-9a5e-beffa8a12c50"), 4636, 4, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3862626e-dd33-4da3-8e26-9be6dc4ac419"), 4436, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("386e0986-7c20-4e8b-9c76-70b8857e20ad"), 4426, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("387405b6-d18c-49d2-bf07-6f28b058f35c"), 4100, 6, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3876a137-dd00-48ce-900e-b37e51cd7af3"), 4723, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("389b320c-c10c-41a0-a7c0-8ee3459042eb"), 4268, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38c5d942-450b-4bf8-9eb9-be175cd431b8"), 4000, 2, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38dfe825-7795-4479-a83b-a9c9d96495d8"), 4618, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38eb829f-f0c2-47e7-8c03-28dd07e4e73a"), 4420, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38f0ad14-fb59-40ad-9eb1-759438e86f62"), 4450, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38f5cb4e-11e4-4c5c-9664-14947d73b47a"), 4212, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39047ad3-a94d-47f7-a5c6-dd0341106baf"), 4621, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39071df5-06e1-4aac-ad17-875d8a5979a9"), 4850, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("391d784c-fccc-4402-b857-3746feccc29c"), 4551, 6, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39223b90-a440-4dee-af51-b0629da24db6"), 4503, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3939f296-e54b-4a71-97f3-0e0d203eaaa9"), 4018, 7, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("393d5ebf-8db0-4787-a795-64441c9a3fbf"), 4303, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("395b3968-5e6c-4c5e-8f21-8c1d7844a17a"), 4257, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("395de1a9-09a3-4846-ae17-693cb6c397d4"), 4723, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("396501b2-bd73-4ba0-94b7-a1336d2ead98"), 4461, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39674582-20f5-4632-a403-b2902adaf5f9"), 4462, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("396a7a80-2e21-4a3f-a970-f3e7a3c30528"), 4236, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("396e4ea7-9208-44fb-99c4-294e8ecc2909"), 4026, 8, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("397895d0-a6ea-4643-aa91-bcfa05e92201"), 4412, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("397a1efa-7738-42fb-a0ee-37cbdc663614"), 4272, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("397b1c2a-b797-4b05-b8d9-86c722f51ba5"), 4628, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39934f34-9706-428f-a448-93f6003e40ae"), 4206, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39b56c21-6c90-4d8b-bf1f-b02792b4191d"), 4713, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39cf490a-ce20-46c9-9cd0-e8439c9d4cf6"), 4221, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39da4026-401e-4638-9462-50afccca1f09"), 4301, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39f7572a-6c4c-4d96-a375-a6176006b4a6"), 4509, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39ff54cb-0f38-4ebb-9acf-3aceacf6ea47"), 4015, 10, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a162237-3c35-4202-8f77-0a82d3f71888"), 4850, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a18a49d-1841-4ff4-98dc-347970cbb969"), 4608, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a2842ab-6f55-48a1-bb7f-c07592e68196"), 4208, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a34816b-4060-41d5-9849-b5f9c5359805"), 4621, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a7b1fe9-eefa-48c1-946d-60319ab6b18f"), 4463, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aa5d4b4-e4e4-4d61-8282-46c0d1ebd160"), 4461, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ab79193-dba5-42f2-8d17-438ce18874ac"), 4242, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ae04c46-bc2b-40b2-9901-536442296c81"), 4856, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aedb538-f968-4b23-bd11-cd382fc58fb0"), 4418, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aefb2ff-462d-4f1c-bad1-f911523e876e"), 4312, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3afb089f-ee6e-457e-90ef-0c9e8e526d94"), 4514, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b0096c8-9284-4a5d-9fcc-1174cb8f7f08"), 4262, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b071d1e-96e3-4936-9850-ac8f871bd3c6"), 4249, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b13e392-4a74-450b-bea0-b237154297cc"), 4445, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b26ec1e-35eb-4ff2-a0ae-2609b4909f75"), 4408, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b29bd50-d41f-4ebf-8f2a-e5bc8492c375"), 4433, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b3a15f5-0dc6-424e-8f5d-f25d9bd29ab8"), 4256, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b4bdc01-51e8-4fad-bad0-9e5feec74da8"), 4718, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b66e6ea-7e58-4c40-9e43-9abe5dd6a0cb"), 4262, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b6eef1d-022e-4b68-b1e3-85478662f69d"), 4257, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b79d446-3c2a-4e00-827a-7d87292043be"), 4617, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b810839-74c5-403d-9469-aa2f1993367b"), 4001, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b8a5feb-3f7e-47fa-a492-881a17f470c8"), 4622, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bc7e843-1cdf-4a3e-b22d-352d7050093e"), 4455, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bcd0e5c-c2a2-4bd1-8a14-0e33b9086935"), 4429, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bf13d7c-09b8-4d8d-85b4-4a2132419b71"), 4550, 4, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bf25f1e-9680-430a-81c4-38cb40f571e5"), 4850, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c0e02c2-9ad9-4b03-a873-d7899f0f04be"), 4029, 3, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c1100b0-96a3-4599-9383-0bcf32e71e21"), 4509, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c1be2ca-025b-4890-a3a8-ba87446d13f1"), 4270, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c23a907-3751-46a6-95f6-00693fff90c3"), 4723, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c294336-9325-409a-9a70-d34ab0c4489a"), 4413, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c2db23b-ca74-4e7e-8379-0b21478f9301"), 4445, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c33e232-b552-49cd-ae7d-668d57f03b2f"), 4028, 3, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c820241-5078-44bc-ba23-4c54d698c930"), 4260, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c8d10ed-2358-43fb-8dce-11ace01cac46"), 4545, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cb0c4a8-a4cb-4280-9cf3-8f126ec9b6fa"), 4630, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cd55bea-3ea4-4205-b3a4-e08273bb3b57"), 4610, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cf2cf28-862c-40b1-9573-a84ef2f81982"), 4528, 10, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cf75fed-3152-40d4-8bab-a9867c87afdb"), 4518, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cff5dac-fa58-46a7-b7fa-aabb62c47c3d"), 4524, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d0badd5-922d-4b54-9987-66c091e9a7ef"), 4463, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d17df6d-6684-463a-9806-c5adc383a272"), 4555, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d313605-5814-46f1-ae79-f9b9759cb283"), 4546, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d313805-ed80-499a-ba64-a11289b4e83e"), 4804, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d356542-583c-4017-848c-30c4281a8ca7"), 4716, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d3bb6ea-4285-4773-91b9-360c385821be"), 4563, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d4d581b-f203-48a8-a88e-b4c896be6ffb"), 4630, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d612409-ff3c-42e0-b91e-018e3228d303"), 4443, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d702714-970c-47f3-ac7a-dd8109cd819f"), 4640, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d7eca5b-f681-4245-972d-7a8f751177d0"), 4451, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3da2047a-93a9-4da5-8ea7-df8958fcd280"), 4254, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3da26583-d376-4953-9555-568cc02fbd81"), 4312, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3dcb3fc3-da60-4e6d-b1ef-c52f7be9fc0f"), 4314, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ddcc7f4-0ac5-4d83-965d-e17291dfb53d"), 4255, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3def41bd-4501-4065-8b83-f0c346ca71c9"), 4663, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3df38e9a-d258-490b-8b78-00dd8a291a29"), 4005, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3df91091-ec45-4020-8fec-3b0edb760e1e"), 4315, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3dfecc03-3b39-4a3b-b17b-1313dd62c310"), 4030, 4, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e038fb4-d6cc-495a-9b4c-c9b822ecd0f9"), 4547, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e07e03a-786b-4d89-9985-ec6ab4568155"), 4633, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e08ea3d-9cb0-489d-81ad-0fedfe84201c"), 4110, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e09e469-00eb-4e42-8784-a18abc35d4f7"), 4414, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e327587-18d4-46b9-8c2e-3a0ade81ef0d"), 4012, 8, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e46e937-e77c-43af-b927-315cb93941e3"), 4630, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e591974-069e-4d75-a33e-aaf57fe3e500"), 4446, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e62566a-ab20-47e4-8744-8191a8dd7495"), 4437, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e70499d-ee83-4391-b273-1d6c68f48ed0"), 4641, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e8d1a04-2985-4525-a667-75f80f7b8f8e"), 4410, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ea60600-0313-4661-87a3-992a0574cf0b"), 4852, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3eb5458d-13a1-4b9e-a4cb-3c34aeb0a291"), 4222, 7, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ecdcb95-7781-4c07-afa2-3c8eaa3e264e"), 4805, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ed01c4d-6510-4f92-bd8d-a7ef7658ebac"), 4202, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ed48da6-29d1-4937-93dc-61accd91a069"), 4263, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3edab207-31c0-40e4-a0b6-811d9a33179c"), 4608, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ef52a19-d2ce-4422-8a95-1900114779d6"), 4225, 3, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ef54d96-ccbf-4859-98da-cbf2c75226b6"), 4311, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f052bba-4581-49dd-923f-336ecec276c7"), 4010, 9, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f17727f-dda7-4263-a5a3-43baa555250e"), 4015, 7, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f19e72d-7b99-4db0-acdd-22c5b12d9149"), 4524, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f45e7bd-acb5-4959-a4ba-848a2d640508"), 4602, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f484957-01c1-4e32-8be8-a7f0e3cfcebe"), 4641, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f4a0fc1-cf88-4ff5-a704-d315fcf8aaaa"), 4565, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f4acdee-2f78-4ce6-b5a3-3169c33243e5"), 4661, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f6dfcb3-ec94-4a28-866a-7f49abddff04"), 4006, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f7428ce-c847-476a-b629-34526590a153"), 4034, 3, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f78caa6-429e-44db-bde6-fa485d2bb3a9"), 4412, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f7feb69-afa7-435f-a51e-cf5ab1f968ed"), 4407, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f8203b7-8140-45e0-a4e1-620783f94b0f"), 4540, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f83769b-cc7b-4197-87d4-de751b64779b"), 4419, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f84506e-b425-4b63-8b96-85ccbd081855"), 4442, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f8c49d0-9fee-4106-9451-75c82fdeec02"), 4231, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fc5d664-7c03-45ed-b78b-ab5f4e4bc1f7"), 4556, 7, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fd1bc00-3eda-424c-9f1a-10d3f01a1fa3"), 4031, 4, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4003e043-8819-48b4-ba2f-23296494a1ff"), 4850, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("400b6b78-cb43-42dd-947b-6ea5cfd019e8"), 4541, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("401584dc-06b6-4d29-a2ad-74615d3742a3"), 4638, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4025824c-192f-4605-b629-5024b0861c67"), 4458, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("402a4294-7735-4384-9f45-1779c8c2701a"), 4653, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("404ed340-b060-4c9f-bddb-8799ef62359c"), 4437, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40524ebd-9666-4ca9-9259-ed12c7d61edf"), 4711, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("405a9f8c-2db1-44e1-9ced-a216a192f598"), 4202, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4062d7c6-ff93-4d68-982f-2ad309f72222"), 4853, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("407247cd-6a41-4da7-ab7c-c49fed1a72c2"), 4102, 6, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4075d881-6ff4-450f-9e2c-6acc7d501f6f"), 4225, 1, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("407b3e34-0eb5-4e45-9115-c4cc7275fdf1"), 4231, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("409b6626-62d6-402c-b46d-dc7d591ff0ab"), 4551, 3, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("409e9176-176a-4011-b035-95f979b5fefe"), 4464, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40a305ce-ff63-45f8-8f69-fb8766aadf07"), 4708, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40c57789-be79-4d07-87ea-c9c4f19b24bb"), 4101, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40df6ef5-d71a-4eb8-9b43-a8cc75fc125b"), 4721, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40e7cf25-14b9-4ca0-848e-d14c0558b0d1"), 4010, 1, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("412b84e7-7b94-4511-9873-fc9819c1b2c2"), 4621, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("412d393f-fc9e-4ae7-8ace-f381cbfa4b5f"), 4802, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4140ce7d-0b05-47eb-9808-e0b2a1f455a8"), 4635, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("415d25e5-0d56-40f2-a8c5-635295169913"), 4631, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("417901c8-86a9-40a1-b36c-535886e9f963"), 4503, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("418490a1-03e0-4900-ab7f-32ad26ee187a"), 4435, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41cdab04-a480-4cbf-b0eb-6b1dac74d0d5"), 4546, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41fa57e2-a210-422f-aebc-66629d0558a1"), 4619, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41fc0311-bb09-411f-8945-2861163c6cfa"), 4631, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42002865-9f98-4e9e-becc-bb56ae6be14b"), 4406, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4200fe45-7bf8-4469-b905-d1302e393e5a"), 4509, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42221b02-cb8f-4c55-b90b-4ec31651bf67"), 4237, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4223ea31-45b8-490b-aa06-06f1042a8272"), 4443, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("423164a0-1c42-46ce-8d10-fd90216f899a"), 4268, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42368c90-7e2b-4dc9-b51b-482575fcb590"), 4533, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("423f01f9-f927-4eb2-bc5a-78aec4740ee0"), 4711, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("427d94ad-dc7f-4c42-af8c-b34bace5580f"), 4323, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("427e2baa-8ba8-4f1c-b695-fa0283307400"), 4636, 10, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42802b5b-eaa8-4867-a9ec-a7fd9e7303fc"), 4614, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42bba981-32d7-4555-b0ef-f2e8c031dc44"), 4415, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42bfe01c-6c8f-4ba2-95a4-2052a651b4fd"), 4026, 3, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42d5db32-74db-4ca6-b0ef-76ce18262379"), 4626, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42de9960-00e6-4f79-929c-56c0b4dbd0e1"), 4459, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43206b25-7339-4599-a2a3-8d1fe9303f6d"), 4540, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4330539a-5d4c-491a-9a07-69987ddcc182"), 4618, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4340965f-3b7c-4975-be00-458e1ac4d570"), 4635, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("434becb8-e747-4949-9fd1-f1afd5e9fff4"), 4455, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("434f332b-d2c7-4691-b18d-b270adc68bd8"), 4011, 2, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43620bf9-45b5-4d60-ad5e-522b5325041c"), 4622, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("436ba4c4-438b-4175-b2dc-7b84a0c7e423"), 4539, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("436f91a4-4718-4b42-bc68-b20f7b9fc6d6"), 4114, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("438b65a7-7975-4839-843f-019040a3b9ce"), 4011, 5, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43bcfb76-15ad-4f10-a8a7-9a85d9006ddf"), 4535, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43e88a3e-2145-45f1-a44e-5380f7924718"), 4460, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43fd8667-8bf8-447f-8216-f737dd20819a"), 4024, 9, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("442954c8-f9af-4aba-a92c-c87c667fc94d"), 4104, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4433329b-6c21-41b4-9cb4-3c49fb314934"), 4303, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4434e969-6169-457c-a2fb-3684c07ce0c6"), 4613, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("443a1dd1-26e4-49b4-9289-b03e7814cb4c"), 4439, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4446342b-276b-455a-91c1-5a2bc01f778d"), 4623, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4446abab-41d2-43d0-a447-660cd6bc17b8"), 4629, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("444b8469-25a0-44e9-8bdc-23bd2dc2a4e4"), 4025, 5, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44597d53-4718-4ed5-9ab7-2018019ae2c3"), 4550, 5, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4462c483-0d47-4293-bec8-9147df623960"), 4024, 4, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("446d7178-fae7-48b4-83f0-65e6db08a74c"), 4415, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4484c2ba-ee0c-45ea-85a2-d8384631cc0c"), 4640, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44b144a5-5932-4f64-9b27-4b8409e2b0d8"), 4518, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44c792d8-1f78-433f-97e1-8819ed2d0e69"), 4259, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44d62eb5-16fe-43e1-b268-560336a79a65"), 4032, 4, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44e0fae4-9114-49cc-b303-1d725aa5a72a"), 4432, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44f24b82-fac6-4e4a-a4dd-b964d1bbed68"), 4243, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4510814f-2a3b-4b25-a49d-9e0686b386c7"), 4218, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4511b84a-9fe0-4304-b34b-d16821bd8b05"), 4019, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("451d2c59-6ff1-4d21-8ab0-afdcb068204c"), 4637, 10, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("452089a2-12b2-4301-bdc1-c5522b2fbbe7"), 4510, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45276c7f-fb2e-4fb0-b81f-28deeee36c19"), 4401, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("452fd3df-6d7b-4d2e-b237-2920b265011b"), 4464, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45316ae9-52cb-4842-82db-7671dbc683be"), 4519, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45457f4d-1975-4a65-8a08-d38e0c621744"), 4216, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4549a324-eff0-45b0-8c52-2de11a7926e1"), 4506, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4550c5cf-0833-49eb-a13b-4535c7a4a36a"), 4529, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45610f38-ca3f-4a9b-a01a-da848126411d"), 4225, 4, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4564291d-aa68-4797-b5d5-800754213705"), 4439, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("456e9d2d-eca5-4c33-9358-7cf8e1e8acf8"), 4853, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4579b210-bdf1-461f-be10-8951ae84f566"), 4243, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4581854e-4d4a-4caf-9cd7-475c3ad74619"), 4501, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("458c3a68-7590-4da7-93c3-f560af7a2d01"), 4322, 8, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4598ed76-1b49-4eec-9694-b363519d33dd"), 4302, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("459da881-97ff-4479-b245-ae663c2c764c"), 4210, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45a16238-d426-41be-affc-1c348a3f6e7b"), 4208, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45af1834-5f72-4b4a-a64d-352d1b72cabd"), 4416, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45af6cb5-cc70-4d54-91e6-98ffe6e09a87"), 4314, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45c92a0b-0549-4ba2-95a3-4173513820bc"), 4703, 8, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45d54e1b-6a9a-411f-9ef4-c7af0682ee23"), 4225, 6, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45dcb2a2-d954-4292-92d6-0fe9fda4196b"), 4636, 8, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45ec3b45-ae22-4c5d-b900-da33dcab46a5"), 4513, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45f71b3a-5f8c-41aa-853b-bb7094183ce8"), 4612, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45fe8af8-6670-4f92-a57e-2dc40fd4c506"), 4618, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4617d43b-7b22-493a-97c0-2abb5d452ff5"), 4612, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("461bcbad-6f49-4c57-9c93-f50de9cc11a2"), 4661, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4629aa18-7eef-4b7e-9664-654bfb874892"), 4624, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46328834-9c46-4cb7-b536-60e8afd6b20b"), 4627, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4641a252-d410-4341-9726-6b66e78bd400"), 4248, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("464682ee-874c-45b0-bbbb-4f5b4ad495d3"), 4428, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("465c3165-bdba-4eff-8e1f-6711e9c4a35f"), 4024, 5, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("465e748d-0bd8-4ab7-b387-19bb651c11f9"), 4543, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("466a5c61-aef7-4c7b-a087-8c6ded0511ee"), 4020, 7, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46a9b051-3ced-4e5c-bde3-5508634b1cfb"), 4103, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46ac7367-2aa8-4cb9-92bd-71d817e05b6a"), 4701, 6, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46b2ff44-df02-40b8-beea-a61d90e7ea5a"), 4112, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46bde7ca-cc89-425f-a30b-5c599fecab99"), 4534, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46d17083-973b-4d04-8203-c4c8067c5fe6"), 4638, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46d24c54-2469-45db-8297-f2e3e4087422"), 4526, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46d3b141-bfc0-47be-92ef-5716706461c0"), 4217, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46dbe9e8-a269-49c2-a833-a08ec0cd787a"), 4201, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46efa08b-af37-4cb1-b96b-2d83b951dd98"), 4270, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4709613a-4c09-4c62-91eb-e7bbee5f3d20"), 4639, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("470dacfd-c0f0-4d4d-86c6-8c190036fdfd"), 4108, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4714b3d3-a3a9-4a5a-9d23-7d3c4a37567a"), 4115, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("471de007-a10d-455b-8269-b62636290943"), 4718, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4727712c-7a18-4541-8b24-75b37c44b324"), 4659, 4, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("472c173f-62b6-40a1-85ed-521dbb9f62d9"), 4262, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4733b529-c279-42a4-b39b-8e42405df32b"), 4236, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4736f25b-7d8e-4f93-9ca7-bb2cd1126911"), 4514, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("473815bb-261b-4fbe-a491-bfda493609d3"), 4506, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("477747e1-1b5e-4362-a9ea-abe2ee8d8f13"), 4709, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47779490-ce55-4d4f-8d88-2677afba35ee"), 4005, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("478a75fc-3e47-45f6-bbab-ea88da81c322"), 4455, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("479418df-c667-494e-9cbf-d1c3735e9bdf"), 4505, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47b0457e-c54b-441f-ada9-386a13461aab"), 4429, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47c1c458-0408-42b0-98ea-fa5fd79b62d9"), 4001, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47e6dcef-9a2b-4681-a33f-2745db422bee"), 4721, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47e88b1b-7f8a-48b4-9759-d3fa2d707132"), 4853, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47fa68bb-4ac3-40de-95f3-eb612b94ef56"), 4222, 1, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47fd80ac-1444-48af-a0bc-bdbc43dabcb3"), 4565, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47ff7374-b0c3-4fb8-aa2d-6e29f6cc84f3"), 4659, 5, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48143545-7c12-485a-90ea-744c3fb8565c"), 4108, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48400e88-0183-4a78-b620-9e256d799d81"), 4620, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48475936-dae7-4b32-8b6d-3d1c2e560d1d"), 4029, 5, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4848ae0b-1906-4886-a136-eea47467f7aa"), 4036, 2, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4851092a-47c6-44c4-9de1-49c420ab53c1"), 4206, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48569649-32a6-4126-b61c-682c03ddb806"), 4540, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4870e9a7-aa01-460a-becb-016bf1a502ba"), 4318, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("488bc1d5-bef2-4681-bc41-d75d960fa86e"), 4606, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48958d82-d9d2-4a74-974e-7cfa66fdd05e"), 4537, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48a61e9d-c2a1-43b8-810c-deafcc1c7f38"), 4021, 8, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48aa8902-d2b6-4916-a173-1986760fe714"), 4272, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48add98a-3c38-43e3-9a9d-77f365a6c07d"), 4447, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48ae1535-6a9b-444f-985a-6eed25fb35ee"), 4547, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48d7a7fc-2301-4a1f-a9a2-396c844dda8e"), 4308, 5, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48e13513-a5d2-4473-8613-ab18596be2f9"), 4232, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48f05277-24b0-43c9-9172-1c4973facaf1"), 4243, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48fee62f-204c-46cc-a3b6-40bac21b2f87"), 4558, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4900610d-2c44-4513-bc55-a31cb2fe960b"), 4111, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("490d0a23-21cc-4501-8a14-592762fc7411"), 4314, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49254869-1727-4e15-b4e7-f711b13db771"), 4416, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49381b63-4f95-44f1-85da-551e3a9e33f7"), 4414, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("494e0e26-9b1c-4e41-841b-24e23c766b96"), 4520, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49526509-0a96-41e0-b362-ca09758834d3"), 4009, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49655497-28f0-42d4-91b8-d5cf42910384"), 4514, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49811596-80a8-4f92-bc58-149a5a2405df"), 4205, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49986836-63a1-473a-b454-39fb69cf8f21"), 4653, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49a8528a-6c48-4fad-9170-aff21eeaf7ef"), 4316, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49aa2c63-98a8-47e5-893b-5d9fdf6156ef"), 4551, 7, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49ab7f30-2b2e-4f1e-8eb1-c8f42ddb148a"), 4300, 8, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49cd6fd0-7ebe-44cd-8130-8674c5f7be52"), 4000, 5, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49d1dea1-1abc-4602-83e9-62a4742dd030"), 4264, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49e849e9-c815-4864-ae57-3428aba29d19"), 4238, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49e8af9a-4e7d-464c-ae1f-9e50004d1c93"), 4535, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49fa97f9-46c9-47c0-b21e-ce2d967fd043"), 4263, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49fe48e3-d766-470c-80dd-1a60caf083f5"), 4103, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a12eddc-1730-445d-854e-a883bc0a4756"), 4214, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a285dee-1d3a-44bc-9107-07b7dfa869ea"), 4629, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a2d60f8-efd4-49db-a9f5-17c3739a9715"), 4210, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a2d8c65-d7e8-42a7-8754-98c182284fd9"), 4273, 1, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a3e78d6-3c72-47cf-b08a-03643a126de8"), 4708, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a3fbedc-f4ac-4446-8dfb-d91dfb63ec17"), 4854, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a480fb9-f451-46e8-855a-0af32df511e9"), 4622, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a6ad49f-9317-4ca4-8991-e976c4933d22"), 4660, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a704648-e5f1-4b13-920c-fc2ab6cd534b"), 4323, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a8feee6-776a-41ee-b357-8b65e7242443"), 4230, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a995e7a-e6b7-4a0b-bfe5-4b540dfefcb4"), 4628, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ac36af5-a592-4964-8344-527577cb071d"), 4716, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4acbc6df-2b57-4c16-9bd5-6bf93c4ba365"), 4640, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ad1b0d8-9ba7-47dd-b796-11c46d405ae1"), 4214, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ad87459-347a-455a-ab34-90ce16531064"), 4258, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ae739e6-b8c3-4b55-b839-48344c30752b"), 4802, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4afa0f97-b2a6-4126-b374-ad1a5aea06af"), 4527, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4afb6422-868f-48e7-804e-af4909b42576"), 4444, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b004e1e-447e-444b-a88d-71d73d6d5ae6"), 4721, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b1a4b37-b53f-4c6b-a6b2-2d258ea6b5b9"), 4426, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b2153fe-4d82-4d63-8220-41d69d3bc622"), 4565, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b252301-693d-4bd0-83bf-53e693ef05e4"), 4427, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b27339b-d774-4754-86ed-2bdb3bb0c253"), 4016, 1, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b3b18fc-0177-499a-8daa-18b8da495608"), 4853, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b3cad15-bc37-430f-a930-e2e8ab42015b"), 4502, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b5e4b9d-d8e9-466e-a3ec-363814a40e04"), 4213, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b7dd129-76a4-42c0-b942-6b5471b0d00d"), 4559, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b820af2-15ad-4950-85a9-999246de10e8"), 4100, 10, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b91931a-ab42-4997-a7e7-94560d2a047b"), 4552, 8, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b922e38-5103-4970-96c8-15f03a1a555a"), 4501, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bb08ed0-a9df-4a57-9cde-de87a8776d62"), 4502, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bb458ad-72c8-4089-94a9-96ecb5279f5e"), 4230, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bb99421-289c-4216-8469-53859e0e8d2a"), 4800, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bcf881a-3018-4d6e-9e36-46d064cad455"), 4700, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bd3d889-d780-4752-bd72-89d8c6b39432"), 4623, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4be3b473-375d-4e76-96b1-ddb48c5ba4de"), 4108, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bf9d389-dbbe-41ee-8c61-a80dce45406b"), 4720, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bffc388-f964-49ea-8a16-2eb6b1fca60a"), 4662, 3, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c047b9e-cb5d-4efc-bc6b-93bd05cc5208"), 4110, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c0b6b30-0af9-4d7a-be28-4a6c8d29844b"), 4522, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c0cf629-d696-4996-9f30-ae4b5776a9c0"), 4528, 6, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c14ce61-26e2-42b4-889c-255f917d5508"), 4226, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c16caeb-39e9-49fc-b5c9-e5b56b66f8c1"), 4206, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c1a7dbe-0bfc-4c78-ba23-1ce00dde4dcf"), 4704, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c2e04af-3d75-447d-8d98-dba47677046f"), 4243, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c2e4be0-7f60-4b1d-bd0b-b91efed2f95e"), 4202, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c55b829-767a-480a-8927-523fb3aa6a73"), 4231, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c59059e-a8fa-4ffe-b808-e7c09455af6a"), 4442, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c73b40e-5ba4-4784-8e98-ba9bcd9c3422"), 4529, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c7b1853-aeb8-41b8-8bd3-0d01110d6fcb"), 4614, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c8015c5-0841-4952-a375-7bd4767ad814"), 4215, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c995b01-1e14-4313-b011-60cc2909dd13"), 4658, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c9d6eb2-e156-40dd-9ef9-3cdd70330292"), 4536, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c9e8bb0-3969-4bbd-b88e-250351ffcb89"), 4005, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ca59dc2-d0e7-4e97-a3eb-46088a0b6a31"), 4611, 5, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cd1665a-fb18-4dc6-b8ab-40b05597eba4"), 4216, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cd6182e-bde0-4e57-9ee6-0c3e0d3a94ad"), 4309, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cec6787-d640-40d1-a1a3-4ce2a58ca8f4"), 4722, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cefff9d-ab84-459a-a93f-c911056084f2"), 4436, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cfe36b4-1a13-4352-843e-fdcae67feb46"), 4459, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d02b300-a116-4acb-a93a-851bb44af2a5"), 4303, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d2205b9-265a-4733-a8dc-a7d59eecbd49"), 4201, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d2323b7-ca90-4ae0-b9b8-c71556bd5e2f"), 4110, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d80f405-0eec-40f3-8f96-31ceee32fc09"), 4222, 9, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d8df30b-3113-4943-97ec-14a74be4f72f"), 4519, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d995f7b-cd08-4ec7-930b-9a752ec54e5c"), 4257, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4da79c10-5a6e-422c-9ede-37f015b1234f"), 4401, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4db7c05e-7d34-4f6d-9e23-fe8b9676e605"), 4533, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4dc11f75-86e3-4f7d-8a17-94ad8ab084b5"), 4632, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4dcef6b9-26ad-4c05-8876-be4cde4f01e9"), 4701, 7, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4deb42db-a8c2-402e-9d7e-c67ea2817eb5"), 4515, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4df398d3-9b09-4d20-90c1-34a1848b70dd"), 4301, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e03db84-e48e-42bf-9e45-c676206f21df"), 4609, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e0b7468-06bf-4c2a-83d7-f6acdbe3794f"), 4027, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e2968c8-5b3c-4e54-b1cb-76ecf20587c9"), 4628, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e368edb-a33c-4420-b757-11f34b6bfa28"), 4408, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e3b2e05-c47c-4f5d-b0ef-3af4ab370402"), 4520, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e4a1960-df11-4ed6-9a49-ffb8c335f1dc"), 4723, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e4a58fc-42ea-4f4f-b7c8-be3b88e9445f"), 4657, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e5b6257-81fe-457a-b1bd-eed060d0b1be"), 4706, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e5b9b6a-743e-4ae6-b41c-623bc2fcc5ca"), 4237, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e6ac98b-7c8b-43bc-82c0-91489cb3a48b"), 4626, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e7979d5-db31-422f-aae4-56a3824c8e65"), 4432, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eadbfe5-410c-4729-bd3c-9df91f5f1d8b"), 4607, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ed2288b-1029-44e4-9207-da81cfa4ce70"), 4605, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ee4642f-24b3-4933-8aa0-20b6dd831865"), 4319, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eef093a-80b4-4310-af3f-e3105269fe4b"), 4626, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ef79805-7142-4757-9b0b-ec2705dce1ca"), 4410, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f084aca-2ef0-4f40-a5de-086444d81f60"), 4531, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f27708a-a0a8-4044-81c8-4f0b6a9131b4"), 4254, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f2f6b52-bc6b-4552-950c-b5b0c0096e51"), 4415, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f4f1e51-3914-4a02-b20b-c4ef8926313d"), 4503, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f516277-214d-491e-8e15-1017c59124b5"), 4420, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f778a51-35b6-44f9-8c0c-234572e9f972"), 4562, 3, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f77d5a0-6dbc-4bcd-ba33-fba41231fc8f"), 4407, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f784215-c667-4ea6-b0d7-398df3c8a509"), 4235, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f7d4e8b-b5ae-46b8-a3c9-3aa98df8873d"), 4233, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f8756e0-8f22-4a53-9954-acf6cbe91fa4"), 4251, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f8a9dfc-a8e2-44b2-81a6-abd60b26ba9a"), 4002, 9, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f8d826f-0c6f-46ec-847f-234ba1c1c262"), 4034, 5, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f8e5653-3d2d-460a-95e7-cb34c35f60b0"), 4004, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f97f32d-1ffe-4c44-bbf2-b9ccc82b48d2"), 4853, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f9d1d34-6b4b-402b-88fa-2e56acff5ced"), 4659, 7, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fb2e088-24b3-4b07-a8d1-e4e42c4fd659"), 4652, 4, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fbec768-e905-4615-b8f5-776c5957a9fd"), 4522, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fd149ce-f526-4a5c-b967-541fa923673d"), 4005, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("500720d9-02a0-475d-9616-d2d917210e08"), 4410, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50103a4c-470b-4b9a-912f-f48ccf1d81df"), 4111, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("501f1297-6a96-4d75-9bc3-9ae9504ed85f"), 4009, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5020f3b1-2a9d-4c07-bd92-70f244564d12"), 4234, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5026d752-e358-4ec1-aeb5-4c23e0acb304"), 4205, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50279cb5-5ba7-47ed-b514-af08a0bba827"), 4460, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("503c023e-27ef-41b4-bb44-1d16a8f50185"), 4810, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("505ee867-b8c7-4596-b35e-72329e2dde01"), 4550, 9, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50675fd0-3876-4b5e-b547-f72ae9c69a09"), 4617, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("508567fe-9b63-4dd5-af48-080c54e79731"), 4651, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50885e07-4996-455b-a134-50ece99c1484"), 4016, 6, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("508b676a-a8c3-42f6-92d3-f42241d102a5"), 4015, 6, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50910293-c342-40a6-9062-b894d9754051"), 4465, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5096ac17-2a9c-49d8-895a-ea5834a33f85"), 4213, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50ac88bb-7b5e-4497-8caa-9f2edfd38f2d"), 4534, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50d77771-1f3d-45e0-984c-97b0229b3c1a"), 4323, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50ebeb74-164f-47e9-b327-1a23ec1127ff"), 4426, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("510237af-3fd8-4daf-995d-00585e78bf4e"), 4803, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51130ecb-a169-4ea6-95ca-ddef5b13569f"), 4416, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51401e25-6814-450c-bae5-5093dc242043"), 4562, 9, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51538b37-7e81-4d86-b762-136ca8b88302"), 4250, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("515f7576-1ef2-47c7-9f46-d991f149687c"), 4440, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("517815c8-858d-46b8-bb93-a4f1820b453e"), 4110, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("517a5b48-b135-4008-b187-e7771dd03bde"), 4257, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5180ce4f-10c4-46a5-93a9-b0bff6a3e43b"), 4107, 3, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51a0bec2-4dbe-45ae-9dda-3c99ef62dd38"), 4208, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51b38699-f48a-4cd5-90ca-5c261ca5ecc4"), 4422, 3, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51bc2079-7840-4c2e-82e6-4e7ba82e4148"), 4503, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51c0f408-c9c3-4558-b1f9-4e2224356c24"), 4239, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51c6c6d3-e6a7-4fc2-b63b-9e5c25b752a9"), 4312, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51e20159-05de-4e37-9453-309bc5ad75f7"), 4462, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51e4f46d-aef2-4409-b3f4-0bdb2be19201"), 4432, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52090492-7ed3-49e6-a867-caaf554a2bed"), 4248, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5214984e-bd8e-4df7-918e-a373be3269b3"), 4528, 9, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5226a02f-2291-44e9-ac32-e6e33a274b67"), 4204, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("522ab522-87cf-404a-8312-0ec6736f8233"), 4564, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52342c70-5eef-49c2-bb1c-4c488f5bc342"), 4533, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5244b541-1213-4a99-a631-8703f8eef642"), 4437, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5245999b-6733-4301-8e6f-b3c05563a318"), 4310, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("525d5b22-f1b5-4790-8282-da385c551d51"), 4659, 1, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5266ed14-8a11-475a-8ce6-f3b0b809a1fa"), 4216, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("527756ba-ca6d-422a-9bd1-327fba37ba2f"), 4653, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("527bd84b-0dca-4a48-a4c3-66768cfdb096"), 4242, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5283d5ac-5556-4639-9423-d18b282fc41e"), 4801, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5284ef15-2341-4564-8de9-55f6cb32e16f"), 4856, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52914c45-c6fc-45c7-9eea-74f075f21cc0"), 4501, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52947d92-ee46-4ab6-9067-dba84b12b551"), 4216, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5299fb54-61cb-48ca-8c3c-211b7c2c7301"), 4638, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52a7ad1d-05af-4e69-9815-704dbe16bdcc"), 4112, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52ab3eeb-ecce-4577-ae40-414a78007413"), 4008, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52b56a45-d9ec-40c7-bec5-971e51f9b8ad"), 4220, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52b5a034-d8d1-40c2-8f14-f686f4a4f759"), 4659, 8, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52c80402-102a-40a0-b85a-411863e65d7f"), 4562, 1, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52d2300b-b8c2-4f59-95d4-bdc2b89ff598"), 4273, 6, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52de1cf5-ea35-471a-a48e-e7d2006c1365"), 4507, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52f5e9bd-89c0-467c-9a74-cea4969ad896"), 4202, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("533a9865-0371-421f-97b8-29c21a50d737"), 4115, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("533b97c8-2a40-45ca-aee3-4ce73360446c"), 4436, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("533c456f-2701-479f-b6cb-0970da1bc4f7"), 4515, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53444f83-a229-4485-930d-fd5e74b7caab"), 4455, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("534bc894-4e12-40d0-a180-f87f77112ffa"), 4110, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5362f5b6-c70e-43ab-a14b-a248a7cf96a1"), 4460, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5388fc2b-ab12-47b0-8bac-a86ae8c68325"), 4506, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53ab19b5-4264-4a93-8af6-0d95fda0c93e"), 4623, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53b0fff6-b831-4067-a33f-87590cc9ad5f"), 4651, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53d79fd6-8732-4d2e-92d9-16533fa95b95"), 4401, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53e46ff9-c62a-45f0-ac30-8c1534d0bb67"), 4804, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53e7a1dc-39a3-4574-be6a-e297a0783d65"), 4460, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53efd85f-df6b-4afa-989a-57431dc37413"), 4424, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54003dac-09bb-4e9a-a731-7acc04e412bf"), 4242, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54008569-4a0a-4218-8427-511a385b7fea"), 4633, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54040eff-fbba-40ea-92ad-a3428fb7e2e5"), 4254, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54215d1e-b47b-4f3b-b778-cf67ebb0cb9b"), 4258, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54484467-0bf5-4d22-976d-ad4b11858153"), 4415, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5453a120-4b52-4547-abad-d18cc71533e7"), 4028, 1, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54561bdb-7fb8-4a96-bec0-f0ebe11e309c"), 4441, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("545faaf7-e878-40fa-9c45-f6cbc79949be"), 4801, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("547244b7-a647-48e1-b296-b6bd795b69b3"), 4263, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54b81344-a504-4f70-80f1-1dde1f7df508"), 4854, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54bb3b6d-ff7b-42ec-bc7f-98235462b2ab"), 4234, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54cb6dd9-f347-4ed4-8fff-673ae69045c1"), 4801, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54d3502d-9dc2-4041-87e7-eabc8d6763ea"), 4274, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54e64426-3c8a-4718-83b1-d6e61db62193"), 4534, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54e90a84-1dad-4a7f-9865-6fa73bf88098"), 4318, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55045ccc-80cc-493a-a431-b91d7706ee28"), 4222, 5, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5517fb26-db23-463c-862c-af0c9e12d63d"), 4020, 1, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("552ccc6f-6ea3-4c0b-9e16-d712d03967fb"), 4533, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55341ec1-b556-4ca7-adac-a8f6d1e0f2a0"), 4020, 6, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55432591-c39f-45c7-8975-f90994686244"), 4663, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("554c5d2d-ec64-44ca-9858-3da254525063"), 4504, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55508080-6a5c-4597-bd95-44ebbc6c1da7"), 4206, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("555714c8-a452-487e-83ba-91094eda3dc4"), 4423, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("555a4665-d7e5-4d48-b888-3a5d0b6118bc"), 4270, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55b32d2e-fec7-4486-b770-924ba2a2d342"), 4806, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55f4b7cb-0b97-4f68-8ac8-72bb4f964939"), 4715, 7, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5604cd2d-efa2-4c96-a260-22ab5c536921"), 4520, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5612ad3e-1b77-42df-88d1-fa5c9bf26deb"), 4516, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("561c8d70-f5db-461d-a464-beed620c1d02"), 4207, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("562910f6-0c2b-4b21-b6b5-21fb4939b03a"), 4247, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("563cae75-364a-4fdb-9c80-8ceebdff34fe"), 4716, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5655a8a0-bae9-4742-8e17-da19357b92df"), 4105, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5679115f-6c87-4228-9f1c-7de99b238ca5"), 4551, 4, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("567e9d25-6e91-40ae-ae74-feffbf41fc03"), 4507, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56845886-49d2-4870-8e5b-939d4e4ae54e"), 4626, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5692edb7-6060-4d16-a01d-aa644aef286f"), 4408, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("569b5be4-b1cd-4678-a413-fef43f32c23c"), 4706, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56a36d0b-0449-4618-9bf3-49c4868dad80"), 4308, 1, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56aed879-3adc-4d39-bf2d-0b805d5fbaf6"), 4600, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56bc81c6-69a3-4206-8c9c-73855505ee0c"), 4452, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56cba6c7-fe35-4b16-bd00-d38d5f92e38e"), 4432, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("570ebd39-d00b-4396-9652-ac0f3d13202c"), 4504, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("570fcabc-1ac3-4b9a-abc3-0fe09d4a002b"), 4507, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57218a5f-4e0a-4afb-b4cd-195102d77287"), 4564, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57275795-51e5-48e8-8a2a-8d5dad78ce5f"), 4606, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57704830-b81a-4531-9662-21f78c9e69f7"), 4539, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5771f3ad-f814-4079-8db4-6400aace9925"), 4115, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57794963-7372-42d9-a190-c0ad502467fc"), 4413, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5790b6a8-994c-4967-b682-f0fe504258f0"), 4631, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57b36bed-7441-43dd-8844-6f1ff49b7dd0"), 4526, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57edfd4a-5c5e-4ecb-ba16-a8729f51f726"), 4204, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57f7f313-4410-407f-bd4d-a63b173172c0"), 4307, 4, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57fe21f8-d0d4-4ff6-a7e0-1215fa2c62f4"), 4442, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("580f04da-2b57-44ce-8350-b71079c49470"), 4032, 5, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("581fa23c-b871-405f-be2b-1f53d3417cd0"), 4000, 9, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("583a4ad6-b404-4bdc-8186-525b554dd5f6"), 4405, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("583d6c3a-d0b1-45a5-82e3-15fc4ebcf516"), 4410, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58594e65-91dd-46e1-aa78-cf38373d175e"), 4025, 10, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("586fb141-52ce-41f9-b1b0-7349d3a6dc88"), 4637, 5, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("587777cb-38d5-42d0-986a-f7cf30e72522"), 4521, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("588975bf-59d9-4a74-8f8c-36196007fac7"), 4265, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5893d244-c0c9-46bc-a382-90c206afc9a9"), 4565, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("589b0916-9654-43aa-b6ca-f3180585ac1e"), 4274, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58ab0bf7-553c-4553-9ae8-c24d336f261c"), 4218, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58b0ffa1-0f08-4e72-82a2-ddd7cbe5f17e"), 4663, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58b8c01d-9f94-49df-ba10-61d1b685570a"), 4028, 2, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58b8e2ff-2fca-4e61-a32b-37332df1746b"), 4013, 8, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58ea42f2-0018-41f9-92cd-7c7d2db92ab9"), 4715, 8, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58f39123-5057-4f7f-85f7-7060c1830ac2"), 4628, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58f4b2e0-b69c-4fe9-bdab-db8fc7d43ca3"), 4259, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59191959-32c4-422c-bad7-00ea4369864c"), 4506, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59203564-b911-4175-ac45-31562cd1721a"), 4442, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5923e846-3b3e-4196-97b0-3a8122c0bea7"), 4614, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59253ba7-6854-40fe-a509-6bb344a7f8a6"), 4655, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("592c60a2-9635-499f-940c-fc5bd82578f6"), 4114, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5944c30a-6d1f-4e66-921b-fddb7fe1099a"), 4436, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("597423b6-12ad-448d-9846-71a6bffaa6d8"), 4107, 2, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5987aaf9-2722-4e92-8982-5c782050fa8d"), 4465, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5992f8a1-6739-4c03-a7d4-d736a3d4de33"), 4508, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59c15489-15d6-40bc-8d46-095c791e3ac9"), 4019, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59c5acc8-7910-434b-91ee-fc9c9e33b5ff"), 4401, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59cd90c3-438f-4ebd-97ef-86bf425fe341"), 4661, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a088d55-bf7a-4456-b52a-f6150089dfae"), 4651, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a11a596-f5ec-4986-b0d7-2fcf327b7b26"), 4243, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a1a25dd-31da-43d7-9b7a-9a0fca89ce45"), 4273, 4, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a1d66e2-b59e-4ade-8532-eb2c34566f39"), 4623, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a461f22-7dbf-4159-96a4-f2e956248d40"), 4024, 10, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a531c8c-de67-4e65-aec7-a14d3c4b98c8"), 4462, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ab3a5bb-1555-4889-bddd-628551bb8572"), 4546, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ab42928-3b7c-4700-bed7-a64dba155fd5"), 4101, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5acb0939-c3c2-4462-bdec-133cd5b2fa27"), 4255, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5acb139d-6fe7-4e52-b6d6-c22dadd35117"), 4447, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ad47d40-323f-4d04-9167-ae66cee057f3"), 4542, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ad5afbf-5e52-4f85-85ac-f186ff0cff3a"), 4657, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5af5cc1a-33be-4f67-97e1-7077f2afa7b5"), 4016, 4, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5aff0465-1c8e-4fb9-b1df-53ecb4655b16"), 4243, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b176b57-4b56-4100-b422-de927641ac5e"), 4021, 7, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b2202ea-f3f2-4951-8bd6-741037e11313"), 4543, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b254e95-4749-4925-a34b-bfd8ec634749"), 4637, 2, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b44e090-38b2-4bde-b614-9c5857ec226c"), 4451, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b6c351f-183d-4462-8a63-2325753a6e2d"), 4557, 7, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b79cea1-c489-4f7f-b198-a224fa7b92fd"), 4526, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b91f546-73bd-4fc9-9643-6be0dbf59ed0"), 4639, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b9632df-91e5-43e3-866e-9ba8faf0ff3b"), 4259, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ba2c933-8d5e-4ca3-aaaa-be797447777f"), 4610, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ba40140-d1be-4166-af74-34b7d841b940"), 4617, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ba9205b-9348-4604-88a0-e22855962b27"), 4256, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5baae2b4-e828-4584-aec2-9e778a0c067b"), 4632, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5baee74e-9bca-4128-b105-051911448e56"), 4526, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bb0f5d5-b3d5-4cc4-ab1d-47fe69da2369"), 4541, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bb18e2e-1e30-4129-ba69-27f13835f7bc"), 4403, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bc3af1d-fe9e-41a9-94e6-11857236f52b"), 4314, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bd5bd84-795e-48f3-9599-b129ad8a60be"), 4703, 7, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5be33577-e31d-4dae-8d19-22ff697add4f"), 4272, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bf01466-defb-495f-86cc-2ccefbb34275"), 4615, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c050d9f-e6cb-4073-96f5-7610f69ea552"), 4459, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c220f02-178e-445d-9485-5197260d49fa"), 4610, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c2b4deb-4c56-4eca-ae7c-360c26808f50"), 4271, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c52a8e0-9ef2-4bcf-bdeb-8dc9140c6bf4"), 4620, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c6529c5-777b-45ec-bf78-cab300ba0a4b"), 4417, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c8b1d2e-ff7f-4a7c-ae48-82bcb4d63910"), 4425, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c96d6d7-2ec9-4850-af31-3f140060966d"), 4034, 8, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c9fc3f2-74ba-4e97-a888-48fbad508c53"), 4260, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cb39f51-b392-463c-8dab-50a43ab855a9"), 4105, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cbf2f52-85b2-4bec-872a-0506e41a7720"), 4265, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ccefff6-e799-4afb-8471-b77016d8484f"), 4635, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cd959d8-88cf-4823-8358-987bbe3e6799"), 4456, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cef0d43-8079-442a-b504-465f03241077"), 4515, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cf4b51a-b49c-499a-954c-20259fe149cd"), 4258, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cf66703-6886-4481-89bd-81a002f429dd"), 4309, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cfa858c-2f24-4ae6-8b3b-2797a4506022"), 4652, 1, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d057839-a689-42e0-b425-de66e448269c"), 4539, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d0bed43-ce24-4251-bc28-bc133a8b7e6b"), 4000, 6, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d0c0a61-9599-4be7-a3e0-4e53f07378aa"), 4708, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d0fe4e6-1395-4fd1-932c-5405ffa0ca96"), 4622, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d36d02e-3e50-41b4-9312-59179694c3b4"), 4556, 6, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d44d21b-e6e1-4181-97f8-dbb2e8255187"), 4317, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d47e8d9-c726-4270-aec8-193de2ddb72e"), 4019, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d490991-6675-4fc2-9292-5692237bbed4"), 4554, 5, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d4a62ba-ff1b-4632-9962-0c4152c76bda"), 4270, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d4f8bcb-7c6e-4e96-925d-4c6f05287018"), 4311, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d565ac5-cfd2-4cc1-b569-7c0a1c087f1a"), 4233, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d60d7d0-e41d-47b6-9754-71228858b24f"), 4419, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d75c406-e2bc-42cc-a9e2-fec6e838c117"), 4712, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d7e6d90-eabb-4f14-8c06-e469f3219693"), 4600, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d88b43a-c30b-4b22-999c-aea499b7bc58"), 4017, 4, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d897ad8-def9-4dd2-b544-3a6537e961d6"), 4210, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d9baaad-5570-4466-841c-dcef62999699"), 4809, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5da74f24-a50b-4ae3-bdbf-d6c7bfe57559"), 4222, 10, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5db16954-0366-435f-b792-2e9c69d57df6"), 4621, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5db945ce-896b-4f07-86d7-b40f87ec36ff"), 4240, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ddcc92c-7512-4b6c-9bde-7c8123cdb3ba"), 4025, 2, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5de888bf-70e8-43d0-a3b3-254cae361ac4"), 4208, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dfd4290-2c4d-4338-b072-3eeb91c34cd7"), 4438, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e0af419-41c8-4005-96d2-c31f25e9b234"), 4711, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e16fbd3-4314-4b55-a314-caa1384c711a"), 4441, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e1d59d4-18c1-4251-9e68-7510ee41037f"), 4409, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e2da3f8-096b-48e6-875b-e71cbe75f74a"), 4433, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e2e6fda-6615-4d8f-8b57-154cc8769116"), 4800, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e53cb75-e2ac-4298-8595-0de854a99de0"), 4560, 5, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e5a3b83-12e4-4342-a82b-967af1c27e26"), 4417, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e7f2e99-f701-4e24-b54a-3e2f8b093d0d"), 4202, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e9039b2-017c-4830-8d23-9ba8e2c308cd"), 4635, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e99fbc8-3566-4d81-a200-ff7167014e72"), 4264, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ea4a67d-6c0a-4157-8a44-aff7b2def7cd"), 4439, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eafa9c5-606f-4bce-b9c4-05089ca668ff"), 4226, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eb3b0a7-f8b5-4719-8474-59ba858c1397"), 4260, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eb6a692-f3aa-4fa7-8745-292d85ebf5a5"), 4300, 4, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ec30347-42d4-4316-9a01-aae5157d2371"), 4713, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ecc6049-89fd-401e-8b23-5a91290cae8f"), 4510, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eef4247-66ce-4291-a219-f4b9f1abb521"), 4409, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eef812d-6fd5-4165-9315-6ce6546ed2aa"), 4531, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ef6f5f5-c8c7-4b8d-ad8f-df872d10a524"), 4800, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ef83994-e69a-412a-bac7-9b05878a2eff"), 4621, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f0516a9-ecee-4538-a94f-f738997944c3"), 4235, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f1e8041-00bb-45a4-9070-6cc721538bc7"), 4437, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f23e18c-0a7e-4ef9-80ad-e43b3db3a64a"), 4450, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f3349ca-2799-4be6-a733-958ddabf2396"), 4316, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f662311-ed5e-4bd1-a12b-6f6374af3aac"), 4661, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f75696e-0ee0-4222-8ec0-3aaf43a37615"), 4030, 2, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f784d06-9b4a-45a8-93a9-8b39bc15f36d"), 4613, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f89c9f3-2c40-4b3e-9e48-5ee115c798de"), 4457, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f8a9609-6a4e-435a-9c9d-82b3abcec188"), 4660, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fc8252f-0696-4800-8914-8212ff607314"), 4453, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fc9184a-daf7-46bb-aa05-33344ea66223"), 4709, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fd3f415-ebe4-4d07-80b1-e6f79e23d592"), 4027, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fd4549c-100f-4cf3-aa68-fe1a22cb972a"), 4550, 10, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fe1feb1-e914-4d6e-98c9-8ecf7d4a617b"), 4209, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fea194b-714b-439b-a817-90ebcc32bd76"), 4213, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("600f6b21-bf1c-4097-9340-391d4cb15d31"), 4266, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("601078da-ee21-4a91-9411-aa960c808291"), 4271, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6022ffb0-5c5b-4e69-8065-77ce0db32c8e"), 4637, 9, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60237c67-a2ca-4ffc-9334-2f7c911c788a"), 4435, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("602f8986-11e2-400f-8a92-24b131ddab96"), 4022, 7, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6032df89-237b-41b8-bead-c38e5992a540"), 4218, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("604c82c1-b681-48a4-9446-961bad019f71"), 4613, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60836e54-8ed3-4ddd-9fe8-31b76b7d6356"), 4554, 9, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("609641db-699f-4baa-a1a7-724db87653b7"), 4017, 5, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60a53eec-9b51-4815-8b38-4f6a11e9ebb7"), 4546, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60bf5fb5-6d64-415d-9234-72d5d51fc569"), 4251, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60c0c9b1-406f-4fdc-b8f3-edbf3530da12"), 4260, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60c4cc8d-5aa9-42f4-a54d-d7032126fd96"), 4707, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60ee69f0-7824-4369-b59d-9f3cb348541b"), 4314, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60ef5c7f-5cb8-41d4-81f4-a93a572b4406"), 4203, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60efa88c-82d0-4e62-9447-ee36449c19ff"), 4438, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60ffa9db-a34c-48e1-a9dd-ad6cff7fb719"), 4805, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6107be51-b9e1-47ed-9f6c-b676d6295bf2"), 4405, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("611016ff-909b-49ac-b085-af2806ada1ef"), 4510, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6112306c-adb5-43f3-bf71-4342e1abd191"), 4204, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("611ef147-a70c-481d-b4a1-f43d57ec53f4"), 4013, 7, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("613b72ca-4894-4741-98fa-ef8d45b0097f"), 4604, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61592321-a861-4752-abb0-995a8cfbc158"), 4321, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("615bd895-3cff-4c91-b052-6edab443b036"), 4309, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("617b9d03-6360-4fb3-9ebf-db7d1f327a3d"), 4636, 3, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("617db7a0-8de9-4524-b5d2-a20b6b418228"), 4454, 1, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61e9a465-ec4e-42e6-b173-19ae0d287c3a"), 4234, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61ec2f29-e9ca-48cd-a423-487b42187a51"), 4409, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61ef4667-84b0-41c6-a555-35b79773f8e4"), 4524, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61f02a85-b68b-454c-a7ff-1d68c091bbe3"), 4037, 8, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61fb299d-98a7-4774-8b32-06e23ddc1274"), 4030, 5, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62004433-eda2-43c0-b7b9-88301d21eea1"), 4702, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62048968-65b8-43a4-bd0a-a7cf5de361e6"), 4522, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62083d87-cd90-4bea-b4f0-6818727f8b05"), 4852, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("620bcdee-c48b-40e8-8c4a-96c9970227ab"), 4403, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("620ccad8-fb93-458c-9b96-9a80df1415ca"), 4256, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("621300fc-1dfb-4386-bdd8-4b5986436010"), 4639, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("621a809b-c402-4e12-a133-2401f60827f9"), 4538, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("623e9465-17bb-42c1-8ead-6af4ce83c04b"), 4553, 1, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("624a4f3b-4913-40e9-9a39-336b42548ce6"), 4714, 6, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62741a4d-f9d8-49d2-bee1-69a6ab31797c"), 4610, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6275de9b-2f2c-4d80-8ee5-bc74a334c5a5"), 4638, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("628d12ec-25ce-4bd4-a416-a30bb1b9dcf8"), 4015, 9, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62927d8c-1654-4bfd-98d3-b52d8fc5f648"), 4415, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62ad83f8-f0d1-45dd-9a4b-e9191ce31e41"), 4001, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b439ba-9344-4955-988a-73ce79957468"), 4221, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b59203-0478-4591-8e89-3b8f819dfb1b"), 4217, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62bc30ab-9dd1-442a-a429-0dacf1f629d2"), 4114, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62ccdd1a-a68c-41c0-b25a-7078824f877e"), 4513, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63013105-8223-4538-bf4c-05d4f62e469d"), 4705, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6318fafa-be57-425e-b9fa-b5d3c5ddd1ac"), 4031, 5, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6325e959-b5ef-4f9e-a7f8-29949e5affc1"), 4718, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63404511-3294-453f-8e9c-ac3093b67680"), 4409, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6344b3b2-29f5-4c1f-a5a2-b9a7dd07ce98"), 4229, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63648a4c-e8f7-4a99-98b6-6b3f261f6733"), 4539, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("636b82c3-ebec-4818-b311-e997947f34e0"), 4308, 4, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63b66da5-f1b3-427b-b83b-39a78420d719"), 4101, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63c274e7-3b02-4cc2-9934-bd7979299379"), 4502, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63c385ef-f34b-4c94-b82c-3406b89fbc8c"), 4013, 9, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63c9589e-a761-4ece-8753-4c0d093d526a"), 4717, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63d1c957-4751-4419-a574-d50eb55b42be"), 4618, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63ea74cc-0340-4c15-9a39-95a72700f2a1"), 4409, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63edd3b9-de89-4006-9270-9bb2269769c3"), 4445, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63f5b113-0d47-4ad9-99bd-5d25b3a484c5"), 4632, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64209f03-2b56-4298-ac2e-72cb54c51f94"), 4018, 6, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("643f3948-7713-4e83-b00e-cb76eb4ee67a"), 4207, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("644e9bcc-570b-44ce-a87c-e55b57ca3b72"), 4427, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6455f93a-e53f-40ef-8f4d-67d2b0e0b837"), 4545, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6476516c-f46e-47f3-b928-965e8f4bb48e"), 4509, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64bf5d74-3d1c-45b8-90a7-11f1f0df554b"), 4560, 8, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64c9578b-7dea-44ed-a434-6b831228e281"), 4270, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64d9340e-de1c-42f6-8203-b2eadb08b104"), 4012, 2, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64de969a-dd12-40fc-afaa-d191565a6d39"), 4851, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64e931c6-92e2-4a25-81d1-8fb66c0613d0"), 4404, 1, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64ef20e2-0c8b-4d1b-bb91-3fa5c80fa271"), 4034, 7, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65191634-fcd6-47de-a9e5-fcfcab01b81d"), 4225, 5, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("652091ed-8351-48c8-aa43-fa18a76287da"), 4408, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6523c72d-93b2-4333-85f5-2e68f742eb9c"), 4655, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("653afbb1-fe24-4de2-861e-65c4abd51e1d"), 4406, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("655dfa83-e1a7-4c17-81ad-cb8ca192bed7"), 4307, 9, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6574369d-d711-4ef6-bb4f-ca20237f8179"), 4253, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65808671-8f35-4e98-87bc-313537052859"), 4220, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("658d6c2a-19ad-4f4b-be39-217b1b17b139"), 4810, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65915608-e0ed-4575-b358-09035530afed"), 4237, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("659e0ba5-6318-49ce-9c57-559c74b20a83"), 4461, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65c45dfa-13c1-47c3-9a4a-d8b473043d09"), 4619, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65d7c9c3-d3b4-4423-8d4c-b867ef463135"), 4230, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65db4478-b6e1-40e4-8f84-43d4687cabcc"), 4622, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65ddc44d-c81c-4ae6-9688-26f90c46018d"), 4620, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65f8d19c-2a46-458e-adb2-cd62005a13aa"), 4231, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6616a18a-7968-4e68-af80-232b0d42464c"), 4702, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("661b9cdf-6256-426d-9105-5689e73e63b8"), 4029, 9, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6620ccc8-cdef-4111-a32b-8918db893cbc"), 4406, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66220742-cbd6-46cb-970f-3a8a7a1f1d40"), 4000, 1, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("662a59a4-acb4-42d2-9434-a3d7faef6c35"), 4603, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("662a9c94-9444-429e-982e-c9983aa16910"), 4020, 3, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66318c15-4061-4cc4-9af0-af04dfcfe39f"), 4033, 1, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66517509-56de-40a2-a99d-050e9b88db86"), 4805, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6664e9bb-b560-4379-8329-9c668c6864db"), 4001, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("667852ba-ab64-42a9-b202-260d2399793b"), 4563, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("667a8a87-79f2-4720-b90f-d32a7560d345"), 4604, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66a0f6d1-098b-4a4d-b915-0bb6d2e7e5d2"), 4267, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66a6815d-deed-4d2e-8fa9-d91b4a700625"), 4702, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66bc4d9b-b65d-4ef5-aae0-ba6095180bd8"), 4217, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66dabcc8-9b32-444f-80fc-0ad5b9f305c1"), 4109, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66f44f97-22e1-4909-a341-0b6169927c37"), 4445, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66f7c447-bad0-4301-ab8f-37574de9cc6f"), 4302, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67144f2a-d09e-4025-b830-6e6631e058b4"), 4409, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("671be5b0-d64c-4db4-bb4d-abbd6b7821a5"), 4545, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67243e9d-f8c7-4476-b7ac-330b706e016e"), 4223, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6743ca7f-ad69-4f2b-8ec4-edeefcc5841f"), 4722, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("674c62da-a7e6-482d-97a0-3b25cc7544ee"), 4270, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67539df2-4f10-4fab-a636-a056172fd886"), 4008, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("675be73f-38d9-48c3-9a58-3d3c7aa37942"), 4512, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("676ae6f9-a4c2-460c-9ace-5bfedc65e6e7"), 4269, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67960886-f41d-49f5-b8a5-13fecfed85ce"), 4003, 7, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67aa4d1d-506e-4e77-ac97-3fcbb15688a8"), 4521, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67ad944c-fafc-48fc-b956-c2255a3076bb"), 4454, 4, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67c7694b-251b-4592-8e48-3f0308c74792"), 4630, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67d05b02-3739-4fa3-8a65-f7e21fe235da"), 4619, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67e8b2fe-783c-4b3b-bc02-c74f14112361"), 4020, 8, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67e8f204-ce68-4e02-b55f-d08c93d85db9"), 4001, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68106420-06cc-42a1-96ed-0f386e70c6fa"), 4607, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68149c2e-7e0d-4883-8ff1-04e58df95a6d"), 4251, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68330b8c-49b2-48de-b519-d2e69e2629aa"), 4414, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("683fdb8d-532a-4b37-b96b-fb57286e8d46"), 4016, 7, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6847c80e-d1dd-4654-8548-db87d504e28b"), 4656, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("685cdf4f-e0ad-4be9-af23-57e779066c44"), 4658, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6870fbfd-b9e5-461f-86f4-34d1cb7acbc4"), 4259, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6882323a-eafa-4abb-b2d6-0837b7f456d8"), 4105, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("688cb7e1-a932-4a8c-9c44-b2d4766f2d35"), 4534, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("688e4e2e-dc6a-4064-82d1-283527c535e8"), 4527, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("689c4cd2-81d5-4387-9de1-89cd64f3d57c"), 4504, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("689f027a-d5bc-43ac-8ddd-28635408066b"), 4506, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68a3e45e-1f7d-4acc-8d70-bb1613d517b7"), 4110, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68aff8cb-6d88-48a0-8220-950a29b60ac2"), 4717, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68d1a3e2-91b9-43f0-824b-6fe7901dc196"), 4528, 5, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68d369be-14a6-423f-af42-a20f925af806"), 4239, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68f2977a-19a2-467b-a923-3f2429b29325"), 4249, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6920d9a9-327a-4149-bf03-b554013db6fd"), 4801, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6921ee99-be3f-4871-aef6-1de7c21b3e0c"), 4855, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("693893b1-2f13-4283-aa17-606336c64e59"), 4240, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6939027c-1126-4266-afb4-998c51e1b0c9"), 4540, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("693bdfa3-4459-4c72-ab5f-222bfc462950"), 4208, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6951819f-4f30-46ed-a7e3-91ef0150eeeb"), 4441, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("695538e3-c8cd-48ca-978b-d9f5fd2e6752"), 4722, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69a14578-ebde-45f1-b99c-9e75760d763c"), 4641, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69b06e66-cd49-41bd-b9d1-94f3782ab86a"), 4640, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69bacace-5762-4d3f-ad42-910de0522aef"), 4601, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69c2e722-b71b-485a-92f5-8f129705a431"), 4600, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69dcaf12-00dd-443f-9b95-d36591d0a3e3"), 4016, 3, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69dcb3b0-ff74-4d39-85c5-c179071a45af"), 4306, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69e3cafa-f401-4a55-ba62-5abaf094df67"), 4010, 4, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69ea886a-66de-42a3-b3a0-f1accefcd907"), 4705, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a02cb96-e090-465d-b883-5a27a4019984"), 4638, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a070c45-2ed3-44e5-a8eb-74f1e922e465"), 4261, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a20a405-d19c-44df-aa59-c87b0106cdc5"), 4304, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a251115-f32f-4669-9dcf-cf89b1d54400"), 4531, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a48d46b-7f5d-4b5a-acb4-45dd91c80513"), 4030, 7, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a4a3c42-75c5-4841-b170-4bc160156360"), 4239, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6aae6f09-31e8-4062-af78-7b02ce2057fc"), 4558, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6abe253e-9e2e-406c-85c5-dc498566227b"), 4601, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ad54ca1-8698-429d-be96-e2e49f07a90a"), 4512, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6af548d1-eaf7-41bd-9c7b-81509cae3f13"), 4529, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6afd7290-51a3-405b-87b6-2a967dcc8191"), 4708, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b16fefd-eac7-4c30-8f48-c485e5f1f885"), 4532, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b24c14d-00e1-4ce4-9b8f-1fe709809161"), 4249, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b2d33c6-4099-4ec0-b739-4e9890e7af31"), 4618, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b33c1a0-1f76-4dbe-b35e-dd4086f96c9d"), 4265, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b3818e4-9722-4c1b-8fd3-f0184f1a4519"), 4531, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b3e2001-64a8-4e78-a3bd-49d2b74235c7"), 4552, 7, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b5088e1-7d0d-4963-8bd1-4a68397a19dc"), 4204, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b7cf2e9-dfda-4f24-9135-af183eba9572"), 4456, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b9be8a7-9aa7-4ecb-9a4c-341e97bc2f4b"), 4543, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bb3db87-7753-40af-a2f4-75684a36fe0b"), 4601, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bbb669f-9a26-4ec7-899d-d88fddf76f54"), 4537, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bc991de-8670-4b44-b181-8dc212ca3024"), 4007, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bd81a4c-1d08-45f4-aa56-7747de105787"), 4519, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6be06f1f-bc69-4e60-9a33-cef707dfdec4"), 4614, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c01eba8-60d1-4608-9e30-1b3990af2dbe"), 4315, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c32a87d-b016-4885-bf99-ae8731a29591"), 4223, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c4df5ea-3cbb-49dc-a3e5-9125a3b116f6"), 4438, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c572cab-780e-403c-8a76-4d69c27ab56c"), 4447, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c6ea138-9b6f-4044-9d54-d8399bb2f87a"), 4612, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c79dc9b-e5f9-414c-af63-b178045e479d"), 4315, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c7f142d-1546-4aa6-8c97-880937b1656b"), 4003, 5, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c808bd6-2a8d-4584-a9c9-b1dad943a349"), 4717, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c80a041-08ff-4d25-a7f6-70941d895df4"), 4703, 10, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c813ab8-d6ca-49ac-ba22-843c2fe652e4"), 4228, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c85f2b9-9771-42b9-b27c-d8a646abcb0a"), 4538, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c919c48-0ee9-42bf-9ac2-a315cce3cb75"), 4105, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cbaf360-f8be-4bb1-afea-5dbe2f5b826a"), 4704, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cd2f091-66ac-4b1c-890e-84d2dc5576fd"), 4557, 2, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cda40d9-87de-45a4-b22c-c63833a4c75a"), 4021, 5, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cde9abb-afb0-48c3-8b6b-a7118bf92670"), 4441, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cf36dfa-752b-454a-a2e7-6c4a4936a70c"), 4230, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cf8e6cb-be10-461e-8eac-6e02244a987d"), 4203, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d3556d7-705a-4661-b661-a23fb5bb0b2b"), 4526, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d4edc13-8590-4914-bae1-67f8d923cfa0"), 4560, 1, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d5b4951-4d46-4fe8-a4a5-cb0541be0ad5"), 4426, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d6e55e2-89d1-4f73-bd6b-6ae986265e79"), 4856, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6dac6de9-1e20-493e-a808-3ba07be42079"), 4541, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6db96e75-effe-4899-a81e-6d198075ff98"), 4553, 6, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6df26dcf-2a1e-4e2a-bee1-8878530856cb"), 4304, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6df4162f-43c2-4fae-bda8-6b194186ae61"), 4602, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6df4895a-caba-4589-8627-0e67953e9f82"), 4464, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6dfe3e93-bdbf-4851-b2f5-0e5f96e9032a"), 4563, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e0cd760-ff6e-4556-8cf2-e9127986162d"), 4565, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e25b59f-ba4d-47e0-839e-453057163241"), 4108, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e29de9f-f58b-475d-b496-dd52cdbc5cbf"), 4526, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e37ea02-cf27-4223-9166-16eb6155a9d4"), 4656, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e5be3f8-f8be-4ed8-af00-fc6c3fa5f882"), 4017, 1, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e7a04f5-b8ca-436b-bbc1-a1899f6a94e8"), 4229, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e941dd1-2df1-43dc-9a50-940ff89d4c2a"), 4609, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ea6ac2d-14b5-4772-b5bd-12d2f41d5c25"), 4239, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6eb60f24-6dd8-4310-9aeb-da7bac458dcc"), 4608, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ee03a71-2073-4b6c-b37d-6b30414565f9"), 4200, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ee18ec9-57bb-4a03-a6da-e165b1eb8796"), 4557, 4, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ef2c85d-f86c-43af-b430-2f35f3589844"), 4027, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f028103-bad2-477f-9158-eae6178f49e4"), 4259, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f040dde-f9ad-419e-9cbb-b913a0e69359"), 4452, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f1bc109-c866-4b71-b6be-c779e451bb44"), 4017, 9, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f49b124-2a5d-493b-8fed-1e688af42a4b"), 4207, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f520923-fc61-4fed-8362-e00457c5c328"), 4452, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f525e90-d9c1-4e0f-9557-d4cfa9826341"), 4304, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f5844d3-5241-4946-a1f4-a30b7f27a41f"), 4720, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f63d504-f004-42f7-abaf-c51faa20867d"), 4801, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f6700d3-ba55-4be7-9806-345510e9fc9f"), 4520, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f70c53a-2b8c-430d-91a5-887a9091368c"), 4015, 2, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f7574f5-d3dc-4fe9-99ab-58c7d2530ef2"), 4201, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f790f47-9253-4f10-a14b-787905446d8f"), 4535, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f9622a4-59d0-4a59-a9d9-1f9458565dc1"), 4106, 2, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f979776-8787-4327-bf88-109c3ae3a02a"), 4208, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f9f7756-1235-43b2-859a-ef6a4421052a"), 4422, 2, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fa87eb7-acc2-4693-85a0-e882fb8210eb"), 4807, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fb32332-7cd7-412b-aa0c-e591394c3ffc"), 4632, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fd9b72c-dd29-43bf-9b3a-1a1bacb026ef"), 4852, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fde8eb0-0f7f-4606-bdeb-a2ea586d5220"), 4707, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ff25a36-3871-4418-949e-43d76f96971c"), 4103, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7002dbef-79dc-40cd-877d-eb0777641e12"), 4550, 2, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70089afd-b418-40e6-9d1f-1fb10717337b"), 4462, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("701ceb40-7774-41c3-b203-a31b8bf620a6"), 4207, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7027e09c-928d-481f-bee1-adb59ef61a74"), 4307, 1, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("703db910-b8c4-4c41-aca2-6395ed5718c7"), 4631, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("703f2103-69b4-4fd1-9936-b0ff1a345d3e"), 4320, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70493187-2eb6-4579-9ed2-f3cb1fab2958"), 4223, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("704ea5b2-2024-46d8-9a69-60dbc504f744"), 4660, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70516050-1560-4477-98d6-fe68da75db99"), 4539, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7053b552-e310-4641-8794-f3be8f3586fa"), 4422, 9, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("705f8698-c073-4a29-a6f1-8b5f60208141"), 4453, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("707408ea-bbc4-4d86-be88-732386b87fdd"), 4715, 3, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70936c72-972c-435d-af31-f27c4a02f681"), 4507, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70a6089a-9d2a-4cd3-83b6-6d1e8315bdcd"), 4651, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70a6f30f-2a25-4f01-8ef0-fdf29ff3f464"), 4009, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70ab75b1-25a2-4a2a-9cde-ecb350c3bb9f"), 4704, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70b3bf3d-605f-4882-acfd-2c164e35d5ec"), 4312, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70d93aba-a2e0-4b76-9325-ab8a03a86cd2"), 4272, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70e4e084-7664-45f6-8b94-d1966ba752e0"), 4319, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70faa1c3-62ad-4ad8-86c8-643863b853a4"), 4037, 1, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("710a59d9-b6e5-405d-92b9-2c9075e5e924"), 4557, 1, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7128542b-993b-4ff9-b17a-6a74cbc88e82"), 4450, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71327370-144f-44af-b077-04c14f9ee2eb"), 4228, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7133cf27-21ec-4679-9fd2-1c72c53c09d8"), 4439, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7142c588-5b4f-4a1d-995c-3f0efee2e334"), 4317, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71483780-3a18-4746-b44b-d60aeb76a7f5"), 4703, 4, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7167cc71-558f-4a72-a15e-b0b4474d908b"), 4465, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7182c522-55be-47b1-92d5-aea06a57d384"), 4224, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7183d807-fd95-4703-a5ca-1bd144b5658a"), 4807, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71973c87-0c15-481b-bc52-9f2aba31e664"), 4626, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71a1b023-1a96-43e8-95b9-667c7e16fd1d"), 4520, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71a70fc2-72ab-46d0-a405-5376f4f86b39"), 4801, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71cf6625-165a-4026-81ab-933185eb4c91"), 4604, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71da90c8-c8d4-4212-a10a-dacda7146199"), 4321, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71e01713-500d-42d9-be43-d63e4818296d"), 4017, 6, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("720287da-714a-48d8-96ac-5c60ddcc76a3"), 4564, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("720c84d3-c76b-4d1c-b386-77d70879ae86"), 4221, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("720e1db8-2ada-40a7-bebb-0bcadab59ed2"), 4016, 5, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("723bd9a9-4fc8-4761-9223-795e572e960a"), 4111, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("725e4ed5-0a36-407b-bd51-8fc69be8bbb8"), 4110, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7289f20d-91e0-439b-8efe-c9104907848d"), 4660, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("728f9786-a6f4-4035-86d3-ba1b79ae6e43"), 4513, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("729375e8-c94d-4f71-8338-14379f9b6317"), 4223, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72b1fff5-4a9e-4c76-9400-192ebdfc541c"), 4238, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72d0f5e8-1d65-4b02-9661-cd3205184417"), 4259, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72e13012-912c-4c6f-a7b9-0d42f77901b0"), 4306, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72f4ce70-6531-4fc7-b469-7e3fae9d9005"), 4203, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72f9894d-d31b-426c-8dc8-d1978a46ea53"), 4235, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72fa076b-b95c-4af0-ad8a-540316ddaa81"), 4318, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72fee4ed-cbcb-494e-908b-4c2d42957af1"), 4200, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("730e6b47-428f-41f9-a77a-cbc2b9f5eafc"), 4404, 9, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("730ef7c5-9054-44e2-8302-edbc8584c92e"), 4314, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("734d099b-444c-4b6d-a9f0-8042891319f1"), 4653, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7353110b-6fe0-47ff-bb4b-29e4d31eab1f"), 4203, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("735d4fd8-4a1e-45e5-b674-569eabf6248c"), 4615, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("737a3f85-6ea7-49c0-b62d-dd05c1612a4d"), 4434, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73a717c3-8976-4d84-bbb2-5b736af42081"), 4654, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73bb087e-4205-40f3-93a5-9f383f9a843e"), 4530, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73bde054-5360-4ec1-97c2-909514429aa6"), 4622, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73c2bc5a-a8f9-46e0-90b5-d9f89236d892"), 4615, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7404d7a8-e6e9-47c9-9c25-e53fe634d660"), 4243, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7438d88b-2e89-407b-9bbb-85417ffefa68"), 4619, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74546902-d8b6-4680-956e-f451d229c7f2"), 4210, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7459ba51-ed71-4459-9fc8-d7deac1a8d98"), 4556, 4, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("746dccd5-6ba0-4ac7-a44f-aa59b5e4b059"), 4010, 7, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("747a7665-7d27-4f45-a310-7b4102f59704"), 4652, 7, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7486b7a1-3eaa-4a1d-a620-1cd0292b42bb"), 4258, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74876d36-0067-4001-a1da-2fd1467b128a"), 4301, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7493fdc2-739c-4413-b8b3-6ac25b797b3e"), 4023, 2, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7494f56b-e1bf-40ee-8843-1b2624e51310"), 4851, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74b2b7ec-5d04-493f-b59a-e99a492f3c73"), 4439, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74c926ca-c0a4-4cba-b2de-7439e38dc578"), 4616, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74cd6755-5342-4407-ba36-f21dc992b671"), 4603, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74d79f94-4d4f-431d-a8fa-8ed12b449638"), 4013, 6, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74f92a11-52a5-419a-bf3d-24b243123718"), 4313, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74f9eff0-6164-4544-b3d3-9324a15a5586"), 4657, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74fc8799-65c3-4bef-b92a-412972c3a304"), 4112, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("751e048a-a86b-4495-9ebd-aaac7ef73e34"), 4445, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75345f1d-9677-45fb-b947-04fde75db464"), 4719, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("754f8127-7967-49f0-82d3-af6b63d40946"), 4324, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75544a7c-de19-4636-8d53-3d207a5f3184"), 4808, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("755f9528-4ab5-4fe7-86bf-a1a0a2761264"), 4036, 1, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("757ebee2-f41c-4542-ab02-cea3e8070549"), 4310, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("759f77a7-ea07-45ed-8bd0-9c2a844d1549"), 4540, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75a14a98-2c38-450a-a830-298d8a35c521"), 4256, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75afc755-045f-4ccb-aaa9-39420adbbd44"), 4807, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75b20111-a64f-48f9-a5a5-b40def8f51c2"), 4435, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75be1a7b-2716-4d5c-9dd6-6bee2f352ce1"), 4856, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75bef2aa-125b-4094-a060-61ef29f18f08"), 4532, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75cefcb8-0b3e-4698-9aa2-f56e3964ab8a"), 4216, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75d6bfef-874e-467f-9477-434e54af8a10"), 4006, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75e96d5a-0a0e-45b2-a7a4-243f114f2069"), 4263, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75f4d899-2d96-4861-9b92-18974ad32392"), 4323, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("761884fc-d2a9-44e9-9743-d756dbe12f9a"), 4267, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76380f33-840e-46ca-a6e1-04908f1cfac1"), 4856, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76665a01-2f87-407d-bae8-714c47240dfb"), 4317, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("766cd407-5688-49c7-adc0-1bbd76ffb1ac"), 4458, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7696a28e-0069-4e4b-b1af-e32379e65942"), 4441, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("769d91eb-c266-4394-adfe-ad7a649c61dc"), 4307, 6, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76b1359d-0e83-4b8f-a841-485b403c5c8a"), 4723, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76c59b54-7a19-42d9-9a60-eca7c58b1e19"), 4540, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76f02dc1-ee92-420c-b423-7a9e452c241a"), 4315, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76f62759-ee13-4ef4-9063-3110f9467f13"), 4306, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77058f78-d418-4db7-90fc-72966bd7b8e6"), 4625, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("770f11e8-c423-4aff-bf8b-c90fc8399b13"), 4109, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7720fdb1-977f-4d02-b072-09e9f5891086"), 4622, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("773624b2-cd71-4899-8e1d-d99466205327"), 4024, 6, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("774b4232-61cb-4f68-a523-f76bbcd1c09e"), 4518, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7769e52d-825f-4504-87a2-0d2e217046be"), 4100, 5, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7794c520-db42-485a-8363-ac6bf8a800f3"), 4019, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77980eb2-5615-4b41-a5f1-c305478d34b4"), 4018, 5, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77b0d4a0-1b07-4887-b493-c5b4c491e755"), 4653, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77b37cd4-d658-4342-92bd-12b9f1410f86"), 4213, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77c5111e-f9c1-4a5c-a7b6-972f28794760"), 4631, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77cdde59-b0f8-4928-b973-637211ea0afb"), 4023, 6, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77d5077e-3f94-4eb6-8aa7-e10d318637aa"), 4456, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77d915ac-eb16-4218-b2b8-444a16fb98a5"), 4663, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77e42c9f-478e-4b15-a1f7-9b2811f86d1c"), 4321, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77ea5460-263f-4beb-9c05-7e9dee3e04f5"), 4305, 9, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77f840b5-586c-4f2f-9844-be86fdc45f3b"), 4022, 9, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78100391-558a-49c0-bf78-35e9f27e8243"), 4436, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78217bb7-cdb5-458b-8e99-da57d0cc6a95"), 4516, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7844dca8-6170-4e1d-a36f-093b28b64535"), 4635, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("785a2845-ccf9-401f-aa61-3db3b176f571"), 4503, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78641e94-23a3-4582-938d-749261e6699f"), 4715, 9, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7890760f-e6d7-4b2b-b359-f1b0ad3a4b46"), 4641, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78c91e63-82b0-4a10-aec0-e5268af9c801"), 4662, 8, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78dc11ef-5567-4ac8-ac4d-1e8d7d94b2f2"), 4511, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78e05d5c-50a5-46ec-baaa-7a47219c2f10"), 4627, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78e8ed11-dee3-4f9f-8f5f-355215aadb4a"), 4114, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78f805f1-a733-4a51-b941-a0dbd56a5db0"), 4301, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("790c768a-efd2-4ac5-8668-460d4feb8c13"), 4616, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("791b03a9-7915-4361-b46d-47132214b8f5"), 4262, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("793943d1-e018-425d-88a8-e3dda8db5744"), 4654, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7956b6ad-96b9-43b7-8571-377807335149"), 4307, 3, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7962a7ae-e3bc-4da7-8061-1cbd993d1cd7"), 4510, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79720e7b-4fd2-4ecf-835f-24645d3e2ad9"), 4651, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7976744c-658a-4d6d-8c9b-cfd783b600bc"), 4253, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7977dc03-fb7a-46d5-9ab5-a1de0693b8be"), 4457, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79832727-8243-49e6-8081-48821e584b41"), 4517, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("799a66bc-6a02-48c4-a2fd-6261e12baf67"), 4702, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79a15387-ab12-468c-bc45-b0c1410883a0"), 4504, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79a27e55-64b1-4fe3-b164-bbbc0a89125c"), 4661, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79a707bc-ff10-4ba1-a475-a84c5a5c4dac"), 4423, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79af4033-b20b-465e-8f6b-b74ded4e833c"), 4565, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79bc5d49-b2fc-462c-8734-ebdb447f922f"), 4108, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79bffd81-21bf-4e78-a7ef-200fae67e629"), 4809, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79c62940-124e-4a42-bd39-58ff871c7d7f"), 4521, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79e53a95-b514-4f19-82ff-24aeec556484"), 4446, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79ef42ec-acea-4c1c-9eeb-a562f3a41596"), 4107, 8, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79f6d847-c6a7-473b-89fd-86cb9906242c"), 4407, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a073db2-3506-4ed8-a2fd-68ac550ab557"), 4209, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a1a3854-7707-42a7-8374-67c19edf8542"), 4660, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a35e3fe-dbe0-4e3d-8473-43ed6a2a216c"), 4602, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a4c0723-991b-4daa-8e89-ffedb244040f"), 4404, 4, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a5cf794-b2a7-43b3-bb20-c02301dd8968"), 4211, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a6e88cc-fe54-41f7-803e-eea3e00da823"), 4454, 6, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a717959-064f-4148-9708-73585702a71d"), 4459, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a8b7610-8472-449c-9ba6-cdee474cae85"), 4249, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a919815-67f7-4fe1-a211-94bff0b5b6b4"), 4461, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ac4367a-b0d3-4296-b562-e323073572c1"), 4273, 7, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ac50129-b70f-4a9b-a219-5acca8e8526c"), 4271, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ac73c29-7475-4a50-9b33-4531e8110a5b"), 4444, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7acf1e13-0e49-4695-80df-9c6057e63c2c"), 4660, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7adf05f3-cdc6-4a6a-9891-d460084dfcea"), 4250, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7aeddb3c-911e-4421-9054-b8641418fce2"), 4104, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7aeed6b6-59cc-4930-86ca-ae618704f09d"), 4463, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7aeff741-669b-4193-9c1d-abee94507ea5"), 4809, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b0f09b8-39b8-42c2-9934-a05f07d35e0d"), 4721, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b123b73-a61d-49ba-a1b2-bcf78492262f"), 4632, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b483b6d-90a2-4a06-b2d0-6f9946665ab3"), 4216, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b68a369-c21d-47d8-996a-baeda6c6b1a7"), 4317, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b6da6f2-7e61-4975-9bd2-c4279674d861"), 4035, 10, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b9092cd-db27-484c-8537-14524a1803db"), 4707, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b90b3c7-627e-4c70-b967-6147ba804446"), 4022, 4, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bc9c8b9-7872-4941-ab2e-4fcb0478061b"), 4403, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bc9ede8-bb7a-4de5-aceb-3345e6219ca1"), 4559, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bcb2d69-2079-4685-94cd-cdcc391cddce"), 4226, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bf1c75e-8740-47b8-a558-09ab68ec0935"), 4653, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c0ca1f2-5026-4058-a073-950652e76edd"), 4240, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c367995-4263-4908-95e0-22e34d8c4e80"), 4723, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c41a031-b1bd-4f5b-86e5-b4b0050d1c19"), 4851, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c57a574-dea4-49ae-b712-84d2047e9e85"), 4036, 10, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c76f29d-3ade-42d7-9f2b-2a234dc33046"), 4639, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c8788bf-8214-4120-9e1a-ceec14b170de"), 4519, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c88c325-6b66-42e9-ae85-377ba153cdfd"), 4719, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c8fb198-79a8-4bf1-aa77-88d2b9a2f2ff"), 4219, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ca23f87-49bd-4019-adc4-589cadfda5fc"), 4652, 3, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cc7a399-0f4a-481a-a91e-31434cf01cc1"), 4311, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cd64770-feb5-40be-a693-9d1678e3f646"), 4024, 3, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cda8ac7-3ec7-4fb5-aa12-336fcabe5498"), 4030, 3, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ce3b2c9-f462-464a-9bfb-fc8c9b473a32"), 4457, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ce7d602-9d79-441b-b876-d176396f9c65"), 4423, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ced1304-91ec-49ee-aba4-549ebabca893"), 4558, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cf7f5a5-422a-48c9-a280-003c92dfe41a"), 4111, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d049c89-2ad7-4069-9a1c-f615f91a38fd"), 4264, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d323c89-5258-4542-9378-07d6d902a556"), 4636, 2, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d369e99-9e68-4d7f-9d57-52ab63102689"), 4323, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d8e8742-8566-4428-a9a3-6287e94bd1d6"), 4236, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d9b1256-9c50-4ef7-b527-7dcced739bf6"), 4607, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d9f9e39-ebaa-4f62-a81d-1b8a94792443"), 4518, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dc1453b-5773-4b29-9817-0c2d882043fe"), 4422, 7, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dc95aa8-52ad-465f-af65-848969431853"), 4421, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dcece7b-1b02-44ae-9935-1ca7d054e0e4"), 4107, 10, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dcfc4dc-8afb-4302-90aa-fd8517cadb06"), 4464, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dee77a2-d01a-410f-ac3a-d5d138b98a50"), 4638, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7deec278-62bd-4b60-8396-42240f1acc58"), 4031, 2, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e3bccc7-986a-4e57-86cf-19efd6564baa"), 4311, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e480581-158d-435d-b175-1fba651a6e75"), 4241, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e5d0b1a-5dbc-43a0-9e8c-e268ae07ed54"), 4239, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e80f4f4-a146-4d50-bab4-db58e594fd52"), 4611, 2, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e862dc7-e1ac-4430-9c3c-dad77d17c708"), 4305, 6, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e8c23d0-897c-417e-ac3d-328a581d117f"), 4451, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e9d2142-fa57-4fb4-aadf-66f7e82ba211"), 4032, 2, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7eb92292-3072-4c43-86fc-8594b6df1683"), 4801, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ee3c0ce-88b8-4f35-a084-048847ce618a"), 4102, 10, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ee8562d-8092-4389-9d8f-378adb54d942"), 4638, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ef7843f-d77a-43dc-8a0b-d95cf1c45d77"), 4404, 6, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f06baee-beaf-4607-bb1a-bb7ae777c87c"), 4303, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f090ed6-1056-42f5-bc7b-f04814c3d54a"), 4720, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f1016b6-a2d1-486a-bf1e-c28697ad0ba1"), 4109, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f203eca-cb88-496f-b88a-e9d055a27cf7"), 4214, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f2a32fc-18fc-467a-ade5-069b96589100"), 4432, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f2e8baa-3fc8-4e1d-ac38-e9515b385e44"), 4218, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f3a27c4-41d7-4531-91eb-e4ec43a6135e"), 4661, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f427d94-c8ed-4642-af3d-ca07e64da584"), 4553, 7, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f489010-a1ef-4a27-a4c3-975c2b7bfb0a"), 4207, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f5a4696-03b6-44b9-875c-e977aa4dbe53"), 4808, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f9b36e7-df7e-44e7-960d-f8c7d9ccc59f"), 4005, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fa92715-d989-4f4d-a9a0-46c8517fd21a"), 4253, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fddd5b6-a535-43cc-8c07-c041500ed0af"), 4037, 5, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fe646df-381b-4a76-b6de-564d29a9f033"), 4270, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7febdcf5-06a8-443e-a4c8-402a60d06719"), 4267, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fef5f65-d616-454b-a0ff-1f7820193635"), 4465, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("800dffd6-3b41-44c4-bd6a-a5c23c41c3ac"), 4265, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8014f917-f6e8-4aa4-91ff-623f768a3200"), 4625, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8016c67a-f036-4eeb-8178-8d94b9b84c46"), 4803, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8042beaf-c25c-44f2-9dbe-7ec7adfc49db"), 4258, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8050e9a9-319d-4582-a728-0bb2c38ba8aa"), 4547, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("805f8d3f-a18f-4a3e-8280-c9f481a091ec"), 4705, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80850dac-a64a-40dd-877d-d12c1c7419bf"), 4454, 7, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8093ac2a-9049-4e6d-ac1b-5e6e523bb378"), 4252, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80950b93-0584-4a56-8d3c-3a91478e1ac2"), 4269, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("809bce4a-c001-473e-8a23-2611fecae413"), 4807, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80a770af-be1b-49eb-98ee-201572b077b3"), 4010, 8, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80c63d54-1640-410e-b507-ab57641da2c4"), 4307, 10, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80d73a8d-8af8-4bfe-9738-f43d3e5182da"), 4250, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80e11c10-0687-4b3b-b3f0-39ca045f1a24"), 4211, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80e561c7-43c5-4ded-8dc8-5fc0616f257b"), 4628, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80f08b6c-2477-4426-ab37-91c54918c360"), 4453, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("810e9c00-c054-4acd-94b2-20347938d135"), 4450, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81130f37-5369-4df2-9b0e-40e73ca232a4"), 4257, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8115cbe2-3a48-43e2-b5fc-9e00dfb673e6"), 4707, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81190e8a-16ec-47fb-bcea-161a4c5f5b3d"), 4565, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81319394-1a3f-458e-bd6b-5acd2393b70e"), 4517, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81381234-34f4-4367-9f5c-3138c0d55f6e"), 4245, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81591c91-f83a-4e65-a36e-75f37fa06ad0"), 4538, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("815c1416-8051-4ed5-9d86-24617ae5c660"), 4210, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("815f93ec-3013-4d76-ada0-7059180118a0"), 4600, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81695694-3afc-4667-bd95-cbcb5934886e"), 4519, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81700b19-a097-489a-ae7e-78ff91b198c9"), 4003, 3, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8195d3a5-bc16-45c3-bc4e-815ba3479c27"), 4440, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81992b3e-90d4-4908-930e-7d943d82d743"), 4535, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81afc7e8-e029-4b87-b6e4-7a5ccb405312"), 4268, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81d32439-01a1-4125-8943-b3b2393052b7"), 4802, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81d510da-574c-4c02-b0ed-7e6d177ab31a"), 4426, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81efa18c-6b71-4dc3-8cef-a5c6a6b906f2"), 4032, 7, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81fe345b-fbb2-4d80-85e2-41b2f3574f9c"), 4237, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82048c57-ca7f-406d-813e-75356a2d783d"), 4505, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("822a3df4-f38e-478f-992d-92069eee8fd7"), 4561, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("822de9b7-10c4-4d93-a250-8dba42b6a8b8"), 4267, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("824a6408-ca39-4f35-be48-af8a5cc6be18"), 4271, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("824ae728-3d0b-4671-b172-0cbbb5f576ea"), 4228, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8253367d-74c6-4177-9455-a30b2587b493"), 4533, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82574957-2b20-4e95-b06f-ca367933a2b2"), 4450, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("825db7c7-77b4-491c-92d6-64374652e4ab"), 4519, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("826ec19c-0cc9-4197-a6cd-ebe31da5c143"), 4721, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("829119f4-5156-4a84-a6cc-ad76b3bb7b42"), 4109, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82ac780d-20ff-4df2-b38a-e2550a19535a"), 4440, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82c68d84-3ccd-4e9b-9077-83fb0d7026fe"), 4441, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82cfa174-b149-404b-95b1-a28dc09970ee"), 4251, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82e3c0c1-e993-4393-a79c-9c35ce34ee03"), 4442, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83102340-609f-47b2-9239-6da2da8359c0"), 4443, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8322c98a-ba50-4845-851e-201246bd12c7"), 4205, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("832f2e99-f866-4733-b24e-9e86ca2c6c33"), 4422, 5, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8333b65b-7dee-447e-8944-9d5af1ca9e2a"), 4274, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8362c583-f643-4c04-9641-419f1fad0314"), 4630, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("836bea95-e33d-41e6-9f27-3c227d98a020"), 4854, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8387cdfa-5983-482e-8428-819e6d22bc89"), 4855, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83946958-f59e-49b6-a380-9bbdcd9422bf"), 4257, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83948298-b1e8-4bfe-b8b4-cd1052ebbfb3"), 4547, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8397cd4c-2cd8-4b84-bcc6-6d0570940edb"), 4524, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83a527b5-7697-4a5b-b668-71c281b671f9"), 4445, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83a744d8-2f17-4662-9ced-17a5d64773f6"), 4520, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83a94e90-a97e-4257-8f5f-af9b8dc460c9"), 4716, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83d604b4-e39e-4420-8fda-8303f6d1e9c4"), 4631, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83ef5798-620e-4183-9d24-bd31b1aec1bb"), 4806, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83fa9754-806f-471b-9036-4579fb180741"), 4307, 7, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84064352-9f57-413a-9b54-61e2b5406a8e"), 4712, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8408d48a-c263-4a0a-802b-c7120ece030e"), 4707, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8423fb41-d478-4411-81f4-1d2d2a1aecb6"), 4559, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("842b4843-516d-4bd4-89b3-180ddf5d38ae"), 4015, 8, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8454f1f9-541f-4f3e-bcff-5b8f31daba7a"), 4562, 10, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84762f69-4277-466c-bc2e-1e0afe642632"), 4502, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8489b0c4-8fb3-47d6-b167-3cfd482f88ba"), 4411, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84e0e61c-1e06-4b76-9c71-b833a35cad63"), 4552, 1, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84ebd647-f4f0-4f04-b510-92bd54782e7d"), 4440, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84f38440-e0ad-40f9-ba18-eeddc5a6ea1e"), 4316, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("852d5e01-d63f-4bd8-92a5-80c09e844b36"), 4006, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("854e3fae-123d-4ea7-be35-16edee3336b2"), 4106, 7, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85768ce2-e791-4649-bf8b-2bef69d16889"), 4419, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8576e151-7387-40c0-8ddc-ac1c2188f31f"), 4257, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8594a454-83f9-4244-9fbf-fdd075806d51"), 4009, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("859ada48-5468-4ecb-a141-f6f7cf310503"), 4415, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85ba705e-a29d-4e4e-b8f5-3870c8535dff"), 4235, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85bb43cd-a4f2-47ae-91b8-ac3e55f01dfb"), 4433, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85c3b001-6dad-46b3-b7ec-2b8a95463cdc"), 4416, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85d181ef-f40d-4de1-8e04-4bf5e2748f05"), 4222, 2, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85e48b49-03bd-47d6-9027-516d07ee1395"), 4400, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("861ab379-7793-4e96-a067-54b079f9356f"), 4460, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("862629c9-1f23-452a-ac4c-d66535fb9495"), 4639, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("864bdaaa-9749-4788-95cd-b8e08d1bb740"), 4720, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("865186cc-1bb6-4e68-ad98-1bd222fe0260"), 4542, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8670424c-8a92-4c6a-83d9-f64c8684e479"), 4536, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8685a4e8-0fd5-4ad0-830b-79872b4942b7"), 4525, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8686ec64-66df-4775-a696-d12134246c84"), 4021, 2, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86c74441-0ae7-41c3-9580-53f50e3f1d0f"), 4451, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86debe59-7c92-4ee0-a17d-22469aca24c1"), 4035, 4, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86f01e16-397c-469d-b61f-2fa6799bc144"), 4228, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("870e18f2-625e-447d-8e27-0e3461512381"), 4219, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87250180-38cd-4316-8700-3542538edcb8"), 4521, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8751311a-4372-49b7-ae8a-4b76559f387f"), 4854, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("876a5d5a-4e3b-4417-9867-48935d45946c"), 4519, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("877aece3-f11c-4965-a382-16ef30830a68"), 4508, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87836bba-28e6-4008-9a9c-2d1aafa0e462"), 4611, 4, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87887544-df61-4406-afd9-8b7afc4dd711"), 4528, 4, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("878a6033-d47a-4bec-8dce-ca0cc958ddef"), 4245, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("879fc32f-0368-4739-8881-264e91831aae"), 4402, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87b8c5a2-ece5-481d-9986-eba23efaa409"), 4106, 5, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87b9f8e9-b86b-4aca-8228-8faa1eb2b1fe"), 4504, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87eceed2-217e-4945-9873-0c6a43579d3d"), 4428, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87f856ab-0738-4fc4-be98-513162c755aa"), 4720, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("881de4be-32b2-44dc-a7d1-01ec5792617f"), 4500, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8828ff9a-957b-4d44-9ff2-81aa1dd65413"), 4536, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88435a73-84c8-4766-a50e-b1aa0b8b6931"), 4720, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("884ab66a-8597-40f9-a7ee-30f5227ce8c3"), 4025, 6, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("887233d7-7fd3-49f8-a75b-ce8e7fb7501b"), 4028, 5, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("887323dd-924c-42cf-ba76-b2567fa1eea0"), 4246, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88733622-7ef5-42fd-bfb8-afd6fa7a606f"), 4265, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8886131e-316a-46e6-913e-19ac5ac19cc5"), 4650, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88b13bad-1d44-4ac1-bdbf-0b24becd55ee"), 4434, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88cfe50b-e9bf-4cab-aede-27a36276c335"), 4531, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88dab0a0-8838-40d7-8700-f93043cb30f4"), 4322, 5, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88e50a76-1351-483d-932f-e4248c747a26"), 4557, 3, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88f21f5a-9a8b-479c-8ff0-a0d034251b39"), 4462, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88f49c05-8fd3-4cb2-aff0-e04be372ce0a"), 4035, 8, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89187fc9-4da4-455d-82fa-fd2554c5ee1a"), 4320, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89436238-6cc8-40f1-b134-a5dc89e4571b"), 4314, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8951e725-f3f2-4af3-a838-8d65d81d3066"), 4714, 5, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("895f97d5-b693-4cd2-bec0-7c1d6678968f"), 4115, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89698f6f-14cd-46ae-8bc3-458164ee5e88"), 4023, 5, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89aa358a-c6f1-48b0-b703-aaa1f2a72741"), 4300, 7, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89ade42d-d400-4174-a7d5-d596d66ed6f9"), 4226, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89d66c3c-e33a-458a-b658-12ea6633712a"), 4318, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89f0d092-ce82-4120-b680-447153c7e751"), 4702, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89f5d012-7ab8-4012-a128-b6c6f7636966"), 4031, 6, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a1feb19-eae2-4654-8cc7-889de57e53d5"), 4001, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a4cc0e3-4948-4044-910e-a54f45dacb88"), 4465, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a521636-862b-406f-bd63-d73333461c16"), 4514, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a55374c-0497-4194-9331-4ff964078ec5"), 4004, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a59adc4-e57d-4382-8aa9-6e49d6a545ac"), 4525, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a6d4092-5630-4011-ac0c-e0b9afd37f70"), 4522, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a7e8aba-8f8b-4135-95c9-0647d6536aa1"), 4507, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a84f377-c61f-49ed-b977-ef0091112426"), 4409, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a918e01-407e-4e04-a25c-ccf1efb6899b"), 4709, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a992cc8-9c24-4cfb-a644-fc96a01ec70e"), 4026, 1, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a99edf2-8e11-4014-95a6-2bf6ccc537c3"), 4244, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8aad2533-c719-414e-a5cb-7431933d2529"), 4446, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ab51276-9ff7-49b3-b22d-da1450b737a4"), 4227, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ab8221f-6f5c-4bc9-bd2c-c4e19c299e12"), 4539, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8abf5d61-7841-442d-8158-1aa207b8be73"), 4033, 6, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ad33aef-61b1-4bb8-ae6e-d9ca240e8643"), 4258, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ad9b320-d3a3-4d8a-814f-e853b0baca0f"), 4505, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8adf1a54-d2a0-4d1f-b74e-8b87842a4850"), 4012, 5, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ae8cac2-9a92-49b9-856b-e521ce47cec9"), 4301, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b0d602d-f923-4d2f-8a99-9c312697e67f"), 4005, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b21777f-ca1c-4dfb-b93e-2092997efa8d"), 4430, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b2c53f1-6d34-4cca-a0a1-751d97e8b5d2"), 4252, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b2fb28b-a942-425f-aff3-d9e0f37a5ad2"), 4627, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b352930-0da8-47b2-95b7-289150edd304"), 4005, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b3c0e3e-a27e-48bb-9eb5-0bcca3ff41cf"), 4662, 10, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b443a98-1dc8-4101-899e-b29b15719c74"), 4301, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b5cf634-5936-47c1-ab0c-872cc8ed1b9c"), 4624, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b962758-d394-4313-a769-0ab215f0a4cc"), 4114, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ba28581-2a9d-4e85-ae8b-91dde09a0bd2"), 4311, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bb3840c-e584-4295-bf27-f684cba9dfe7"), 4720, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bbbe4dc-cc1b-4e50-8644-2aa66edac386"), 4212, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bbf72d0-7377-4d3d-a374-799412337c66"), 4027, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bc249ac-3d56-42aa-b0f3-58ea806904ae"), 4616, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bca1ab3-3c08-46de-81e3-ccc3da84b038"), 4260, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bdf8418-d3f4-43cc-a763-d0f26a1bb21f"), 4552, 4, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bdf99e1-c761-4963-a77e-fe62505ea810"), 4620, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8beff052-fc36-4894-b782-abff42bf2cfb"), 4429, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c02db08-1320-4f3c-b590-dd366d23877f"), 4522, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c09fbbe-a805-44c8-b58b-c7e6672810cc"), 4659, 2, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c28c55e-de0b-4f39-a46e-ddaf78828f20"), 4715, 1, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c760f8c-b4e6-4174-88c1-af7943099578"), 4624, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c9a66a9-9aa0-4ca9-b05f-156fb10db4d1"), 4413, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ca1e7b0-d209-4d58-ae46-0f2cf69a5c9a"), 4113, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ca92c98-3eec-45e9-8665-b3fe8edf97ae"), 4400, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cad2949-defd-448a-bd6a-e3014ac3df66"), 4215, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cb6bb18-d65c-4357-b266-8278108cc18c"), 4710, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cb8b488-bdba-4c2c-806b-1e9a15e26301"), 4507, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cc1fb4e-80b3-4c48-bb99-d97161f2077c"), 4002, 3, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cc54bc9-6c47-437b-a110-93346a5560b7"), 4716, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cd31eda-0fe7-4117-af79-fc11c511c0f6"), 4853, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ce06481-c9b0-403e-a528-37e8757b1b84"), 4714, 9, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ce7a619-e2c0-493b-a7ed-6bf198f4169d"), 4210, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ce8d3ee-ae63-4049-8f1c-7c1ceebcaa10"), 4465, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cf3785e-629c-43b7-bcd1-88cda88432a0"), 4114, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cf4be4a-110f-4bad-a85a-e0e99f606a39"), 4221, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cf81238-40c3-4c96-ba3d-24e49bf667ab"), 4526, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d2e22b8-57fa-4465-8956-c9f00974003c"), 4800, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d3284ed-21a6-467c-8f3b-e06035e584ac"), 4555, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d4b70e9-3c9a-4a31-8b7d-c13d7830592c"), 4527, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d4b9e03-b357-43fa-bfcc-fa3cb8fddd86"), 4262, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d4d5546-4b69-423d-a6fc-e7f322bd33a2"), 4218, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d6d091e-3417-44ff-bf6c-f2be87f344a3"), 4408, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d7a2ffe-da79-4696-978d-273bf928c9ca"), 4535, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d7df573-8869-40fc-8b24-923d6a70c6cc"), 4551, 9, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8da88551-dc95-4749-b04b-eda1ed97191a"), 4219, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dbc2a58-5653-4d2e-959a-5aacedbc8d3a"), 4626, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dbdcba6-92d0-49cc-96d2-71a49e83daba"), 4803, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e0a5dda-4466-4d53-bdf5-f8caa0064975"), 4854, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e288096-2752-4574-a997-31ae96cc64e2"), 4218, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e4a3a67-c8c1-435d-b1bf-8210cfd9ecd5"), 4517, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e510245-eab2-43a7-8266-80c24b19e573"), 4803, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e5200f7-7a13-48a0-acd7-5c1b1f98a654"), 4271, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e59b29f-e7fc-4e1b-85b4-c30ad76b244e"), 4443, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e5eecc1-3011-44e5-8d3b-49efc061bb03"), 4018, 4, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e6d5bdd-50d2-4671-8e86-92c70b8eda98"), 4022, 1, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e7fdc5a-762f-4fc5-8fca-e20d14a920f9"), 4237, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e83f4c7-7a34-4fe9-ad8a-b9925648c4b6"), 4511, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e84fd64-a3f4-4f1d-9f1b-5bdf559b110c"), 4608, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8eaf6531-6093-4343-8520-6102966d32ed"), 4254, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8eb96205-fcc6-483e-80f7-0d25ea018efa"), 4310, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ec83728-921e-4ce7-a5bf-153290f5c845"), 4500, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ee21b89-0a05-4051-89fd-fb7d2e016c47"), 4214, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ee65651-9856-4d1d-82da-0bf07b05853b"), 4707, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ee6ea6d-e43e-4f74-8cd8-c87a266437cd"), 4802, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8eed57c1-e51a-43f3-8648-6f64629eccd3"), 4532, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f0ab2e2-cc58-4477-9699-03fc2c274fd2"), 4509, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f1a81d2-868d-44f3-a1e0-014c907009fc"), 4629, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f1b386b-bf1b-4886-964e-26c9ba2c66b7"), 4227, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f4eb601-1836-4a05-819f-9955dba31ebe"), 4621, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f77009d-2c84-46ee-90fd-079de37e7254"), 4269, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f9839cf-eed3-433f-98d3-795dced31ef3"), 4529, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f9982a1-89a7-498d-aa1c-4e3362114b44"), 4719, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fa2ae9c-4130-46ad-8159-df71324614c7"), 4425, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fab4e48-6b06-4be3-8e72-95469983b69c"), 4036, 4, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fafb400-8ac1-4507-82b3-1ec7312244e5"), 4107, 4, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fecf201-9463-4cf8-8c43-7ee191b12c45"), 4250, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fedfe1b-d6da-4509-9713-386b8b1272f9"), 4412, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ff7a4ce-fdd4-4eba-96d6-112ed8fa41c8"), 4403, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ff9de98-ea11-46d4-869a-ab05c0562d73"), 4852, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ffbf151-4ad7-486c-8c8a-951d580628bf"), 4432, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90198a14-0056-4a14-ad81-4f6ec95858aa"), 4632, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("901cdd38-5970-463d-b591-822ffa6870d7"), 4403, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("902a4b91-5085-4b53-a3c3-534a590538d2"), 4553, 10, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("904271fe-8040-47fd-ad5e-740cd8eb5f13"), 4461, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90522cc2-ee99-46a1-a846-79e78de79047"), 4650, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90526ca5-3fb3-4d04-be50-b222798b349b"), 4530, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("905708eb-cee9-4e6e-a6f1-a24f2ed2bf90"), 4556, 9, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90722599-2b82-4562-8dd0-503875f80fa8"), 4554, 8, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9095ccdf-cda0-41d9-a93c-54f48fd77f3a"), 4011, 6, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("909d2282-b382-4b1f-96af-bf1f70fecfe7"), 4400, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90acff90-b632-4535-8756-d592267ad46d"), 4271, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90b47316-1afc-4021-b3b6-c5e600bfa6bf"), 4511, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90d9551f-d0fd-454f-8aba-292132bda7bc"), 4533, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90da2d46-abaa-449d-9fd3-26760e3f93f6"), 4717, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90f12b0f-4dde-4f8b-8b49-5e99a9c419fc"), 4431, 4, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91000f2e-3da0-4967-9637-35a7dc5beb92"), 4517, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("910e3645-ea11-48c5-9efd-99223f92fbdb"), 4023, 10, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("914b0dd5-046f-40a3-a46d-939817697bb7"), 4530, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9155c19a-6c1f-47fd-80a9-748831095285"), 4456, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("915c37e0-1456-422e-887c-5039e1901832"), 4273, 10, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9166bf60-178b-44f7-b600-0ddf3804ae7c"), 4455, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("916db654-70df-437c-a610-af904baf7f41"), 4113, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("917418ef-0fcf-4c70-ac33-bf4ed54dea7b"), 4547, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("917d9c3c-6a9a-4af3-9f60-bb4d99d7ff88"), 4010, 6, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("919be301-a201-4f16-9e79-9007412849ef"), 4530, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91c3044b-fdc8-4c66-b66a-546f44921a84"), 4707, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91d2d292-4cc6-465d-9c7e-98790cdae8e9"), 4541, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91d5ebbe-7037-42fc-ad9c-7ad11a003f1a"), 4509, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91e492c1-32f8-4c49-a74d-60d516258118"), 4851, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91f76c28-c41e-45a6-b097-318817e39bb7"), 4551, 2, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("921b2b35-a1c7-4b0d-8d0c-85a797948bf4"), 4115, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("923f3ed0-615f-4b97-8fe2-1062e1b06b1f"), 4459, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("924f7de2-450e-4570-a391-2b30fc87f8e3"), 4808, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("925f2dfb-f69c-4fcf-89cc-36b7abe128f3"), 4442, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("926f9f3b-e421-4773-af45-75bded7d1f9f"), 4424, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92934756-20ba-4cea-a403-927dea431c1e"), 4103, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92c6b823-0379-4111-a9b2-6022f70bd0c0"), 4232, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92c956f8-2a64-4dfc-a608-a64666219caa"), 4807, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92ea3c92-4ecf-4330-a17c-e2922fa39e5a"), 4302, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("932984f6-fff1-4ee6-ab3c-f84f0fc4f166"), 4639, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93333bfe-e1f4-49e5-946c-c9114f259c76"), 4527, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9335ad02-075e-4a77-b186-1f86d189c370"), 4614, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9365bbc5-1218-45b8-8653-905566257267"), 4024, 7, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("937583c2-d22e-420f-b5e3-48d7d13911ab"), 4700, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("938152e9-36dd-4c8c-8ddd-155896530a26"), 4416, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93816514-64d7-4037-8744-c3265fd5a4d0"), 4508, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("939179b7-c04f-49af-a86a-451389a41821"), 4654, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9393ec34-a549-4aa5-9c11-6a051a2e13de"), 4706, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93abb721-0c55-4732-8627-c846b6bced81"), 4506, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93adcc41-eda0-4142-be8e-9ce773b867f8"), 4553, 5, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93bd4bc5-e419-48a6-9a73-2d3661f91019"), 4708, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93d891b7-bb76-4327-beb4-5879588e8f39"), 4627, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93e28ddb-4793-404c-bd61-23262eea9b2f"), 4650, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("941e2bff-f126-420c-bcd5-4fa311431a7e"), 4309, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94273cea-0773-4715-a857-4503522acb05"), 4320, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("942b7ac7-132b-459c-9543-9680cccfa574"), 4565, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94326ddc-90dc-4660-a279-6823faab01ae"), 4637, 1, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9462b5e9-0832-49bc-98ab-5dc6f8947333"), 4256, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9463dda4-60dd-48b3-b1a6-6f2f5f8b1658"), 4458, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94aec580-7519-4e8b-8f3f-65b4c9fa5bf4"), 4714, 10, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94d2d86f-93ef-4d64-b648-179863efb75d"), 4553, 4, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95102abe-537b-4764-ad96-00fc164f588a"), 4634, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95368caf-8e56-4fec-8229-cdcf71caceec"), 4652, 6, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9556f585-2087-4ce5-9429-b5c36f4022f6"), 4008, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9558c112-a182-4ce4-a88d-1d02060ed7d4"), 4542, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("955a7c00-bff2-4679-a697-a486ae116b87"), 4559, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95779654-89d5-4b5e-a75b-f58f1d159f6d"), 4301, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95b1ded7-2d6a-4620-88d5-a38b54058502"), 4002, 7, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95b31cc7-6491-42a5-a411-04914d548512"), 4463, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95d3db36-9b55-4367-b43c-fe23d40ff12c"), 4805, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95ed1167-8724-4ebe-b0f0-8c668ba612cf"), 4236, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95f4cef5-e0b8-446d-8712-2b8e1ba97c58"), 4444, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95f5947f-c919-4326-92f6-6a787ce21fe2"), 4629, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95fbef47-f20d-4cab-af48-35c2d8b7b2f7"), 4207, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95fcd0d4-8a95-4e8a-bea3-293941479c82"), 4300, 10, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95fd1c63-8441-4d83-af20-0c1cc87c00d8"), 4411, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95fdc62a-fe64-4e2e-ac48-eb2a5f648cc2"), 4015, 5, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("962056a9-b42a-404c-8f8f-e54d58a6f4e8"), 4266, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("963b515a-ea66-492b-9d55-c9d4e895609f"), 4234, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96422634-fc68-468e-89ac-a42c8d9b66fb"), 4246, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9655c482-56ed-48bf-911d-d277640d1804"), 4606, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("965af961-e28b-4239-be4e-1d0e419ae51a"), 4700, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("965fb857-c31c-4507-8138-633f4559e6b2"), 4306, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("966cdc47-3d52-4f3f-9c27-fdf4111948f2"), 4037, 9, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("967081a7-9ae5-4992-99cd-22db65dab585"), 4036, 3, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96796fbb-2187-4ad8-9741-51aebb066b9c"), 4547, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96833ce4-6dec-46a6-bfc0-ae0db0a2c1a2"), 4421, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("968c738f-1bb1-40ce-8e0d-f06364bcf9b1"), 4309, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("968d28e5-9451-4b93-88e8-a595d35c185d"), 4654, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96adde71-5271-4e2a-afdd-80c9c4369b90"), 4539, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96c2c90b-503d-4b66-b4c8-ca94e747c4cc"), 4411, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96c4221b-0753-46bf-9ffb-0878a064679e"), 4423, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96d1cfbf-da75-4deb-815b-b8091282b36e"), 4270, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96db51b2-a4d2-400a-87eb-b2afcf5da890"), 4703, 1, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96f7b78e-a7e1-4032-a3e6-49c93dbaf461"), 4311, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96f94e11-1186-447d-83d0-d90f46c8a424"), 4407, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("971592be-4c7f-4d87-8e64-bb633f2352f8"), 4654, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("972d5270-dbff-4103-b253-7c0b1d99418f"), 4444, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("973f4391-7039-45f6-8f1a-3cf71058beb9"), 4258, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("975274a3-ae52-475b-ba59-f42e22bb00bb"), 4709, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("975e7bd2-3291-4cab-846f-7832ed3dcbdd"), 4007, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97768226-eccd-4082-84c6-ed5137d936b4"), 4241, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("977e293e-4456-4ad9-b635-9f8d6610b1cb"), 4425, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97906841-407d-4a36-987b-2edfef31e107"), 4559, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97a8d453-a4e6-4a78-8384-3a8595ee3bdd"), 4510, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97c5928e-c5fb-4970-b7ca-f4a3bbde73cb"), 4304, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97cd5ff9-cb17-49c1-8ece-edb97034668f"), 4257, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97cd788e-23b4-4ac7-91c6-3d5b264fd9a3"), 4412, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97d70905-5f7c-437e-8d3d-eb8a32d471d3"), 4316, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97e18706-2ae3-4a27-b404-e7aa2a4a1bd8"), 4263, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97e90c25-29a5-419a-a453-38d15010eca0"), 4635, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97f9a3a9-392e-4d9c-8a3d-4553b2fb12c4"), 4034, 2, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("981c846d-9a7f-488a-94c9-b43ad9cceb4f"), 4221, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("982b58ad-6b4f-49b3-8ea4-7db403d3f39f"), 4557, 6, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9831a1b0-757f-4dfa-accd-e7f5ddbbd1f7"), 4650, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("983486f8-de3d-4083-bab4-40d340a48e6b"), 4550, 8, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("985b942e-8fdf-4067-9ef4-ab80622e7365"), 4606, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9868f826-c23b-43f8-bf7a-821e87ff5f24"), 4663, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("986a15d9-44d4-45a6-b47d-bbfcdbd6acaa"), 4217, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("988404ee-7d77-489b-945c-93f6db6589d6"), 4456, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("988f3cd2-3a02-4cbc-bf58-e55225d1fe46"), 4612, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("989d0451-eaff-4874-a030-3302804451ce"), 4855, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98a4cf71-7c9a-48da-9ba7-2d76e63aec19"), 4544, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98a67219-ee17-4d0f-802a-43b1c40a4d74"), 4104, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98b264ec-7f8f-4abb-b2e5-930446cbb9b6"), 4312, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98b90770-9577-40dd-87a9-6fc896fd4233"), 4111, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98c8764e-7fd4-4c11-9138-e995c9db1038"), 4421, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98cda359-8be4-466f-bfbf-67d9a2009593"), 4623, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98dd3b0c-d24f-4fb6-8648-0cc9bababfaf"), 4425, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98f5327b-b70b-4787-9806-feefa7dde8a9"), 4539, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("991cf77c-280c-49c2-97f9-b61a003185c9"), 4310, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("991e0bfb-b257-4d42-85f1-712941b92bcd"), 4245, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99226b1b-faeb-4a74-b1e6-540a439a6f32"), 4639, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99271447-5164-4e7f-8120-a4b08ef4a744"), 4403, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99397d0e-3182-4719-bf21-cd3e5014f52c"), 4232, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99450b42-a911-428c-a14e-90206c8cab23"), 4713, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99475c63-417d-40af-aef3-89cfb21d5431"), 4001, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("994c5e30-58dc-4efa-95aa-96ea789e71b1"), 4423, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9956b3fb-53f3-40d5-b782-9c46c56ac7a0"), 4308, 9, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9981f840-9380-452c-8ec0-5dc6b8cfa625"), 4265, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("999e032d-afc9-4bfc-bf6b-5ead0925d319"), 4458, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99a7e403-004d-4127-9922-8537cf0752dc"), 4701, 10, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99a895ca-f384-4a45-aa2b-651784083e45"), 4207, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99ab478d-0541-4967-8e1e-11e71aa5dc3e"), 4655, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99ad2791-1606-4a1d-8276-5baa8be19d61"), 4200, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99b42c11-e48e-4b1b-bebd-ed64ffe64b57"), 4109, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99d5b68b-c436-4c18-9b7e-fe63e47d4e73"), 4561, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99d94f34-c86a-4d69-a99e-93298f00a125"), 4533, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99e8c2ad-736a-4136-9be2-6aeec4885f34"), 4409, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a0a8662-e7df-4b49-a1ef-14b2672eff62"), 4624, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a0c05c1-a663-4c0a-ba33-7aedd5f42e7f"), 4613, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a1392f8-d890-4dbd-bf2b-5ce26f57dc31"), 4010, 10, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a175115-918c-4bc0-8b67-3369175bb03f"), 4854, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a280711-d1b2-4954-9d26-1df1cd165828"), 4216, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a3be683-2618-4f08-b4f5-986c6b350329"), 4262, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a5003a8-55c0-420a-80e3-884a6f2c11d5"), 4632, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a7485ec-4fa7-4e86-8756-0e8401e80f27"), 4555, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a95956e-7155-41d5-9ef0-3b11e9063633"), 4230, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aa15129-648f-4007-be8b-24b79341feb1"), 4402, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aa1b333-1232-4614-8508-520273647d6d"), 4230, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aa4caa3-06f2-4f79-9eb1-a265b7b3434a"), 4028, 6, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aa90f71-579a-4714-929c-5894ba9ad6fc"), 4603, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aceb9fb-2eec-4190-8218-f9aa28a5a88b"), 4444, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9adbc1e9-25dd-4ea9-8911-7bbcd954bdba"), 4538, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b0e48da-e83a-4811-b32f-0078119293b5"), 4658, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b1737c7-3875-4f80-8f0c-8035fe554c19"), 4253, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b854cbf-759f-4428-b860-d38d1714735c"), 4014, 6, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b884ff0-b322-4982-bf37-870a7b8a2ee9"), 4267, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b94c917-7a09-4154-8680-bd2ee4c08e4b"), 4437, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ba4aa9c-d04d-43c0-b9e8-202ead6b9018"), 4802, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bada6ad-b0a1-4ade-9042-b0059e1c3a94"), 4541, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9badadb7-4468-468e-b959-aa51a7531532"), 4100, 2, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bc126e8-64c9-493c-82f7-08ce2a6422a4"), 4111, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bc1580a-cb49-40db-a5a9-cfeea8a7dd75"), 4561, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c2ca371-15b4-4e64-9758-479900a0d6e2"), 4637, 6, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c31c285-25ee-4d80-b251-ee4f50118d1a"), 4541, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c3a3ec8-1166-4dd5-a231-6f99f7bb7fd7"), 4206, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c5b02d1-1967-4a85-b954-a550f4cf4760"), 4322, 1, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c5c6914-6495-4f33-bce9-8d9eab2e5420"), 4511, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c70054c-db26-4f15-8b51-54d01da42ffd"), 4219, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c7471c2-20d1-403d-a42e-a5429397b647"), 4238, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c8fb5b2-ac25-44c8-95e4-73b4ee238d74"), 4413, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c982adf-4ebc-4d75-bdf8-601a760095af"), 4013, 10, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9caebd70-8bca-477c-9e30-bf5d40a546b1"), 4511, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cbb6d68-be4b-4905-b7ea-5582cb51ecac"), 4718, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cc3de30-ea26-49f6-986b-c7af21311893"), 4404, 7, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cc5442e-5ebb-4bdd-934b-98cb9a750719"), 4517, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cf057c6-a41d-4576-9ef2-7b53a7d97f53"), 4851, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cf5d11f-3ca1-430e-aef9-ff0efd01f0ee"), 4023, 4, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d18a813-5257-487b-8f39-11e13fb9dac7"), 4800, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d18d53b-d806-481f-ba9b-76b4c9ba0598"), 4500, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d2800a6-9fab-489b-8a73-767788e1fb88"), 4246, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d366db8-5056-4ea3-a25a-d1477f029408"), 4261, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d3c1a4e-5ec5-4129-81dd-d5484d0f2e99"), 4414, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d553c7e-78c6-4212-9c07-94344e44e6e3"), 4536, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d7aaf02-9ab3-483d-b6de-743debefc016"), 4435, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d8455ab-7a8d-45cc-90e3-9a448f5f0ee3"), 4434, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d8c6f96-7cbe-4145-bcc4-737814dbdd37"), 4459, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d93d479-1ba8-4673-9982-a99323af79ec"), 4529, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d997aba-ac5f-4d0b-97a3-b7e527d4126a"), 4546, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9da24101-706b-4eb9-a16c-87ed1f165944"), 4530, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dda63a0-e9fb-477d-b62c-1075b4d4f4da"), 4617, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e183264-b264-4b3d-9339-b125a488431a"), 4272, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e200e88-54d2-4271-b69d-18649e9215b9"), 4616, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e4314f4-68c7-42ee-a423-d2631339494b"), 4630, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e458804-737b-4891-b678-a3ac7bc111c0"), 4007, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e506087-b5a2-4a8c-aa3a-e86a341b1276"), 4613, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e61bf22-e056-4b4d-9f5a-b53e9c494666"), 4546, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e6f2d7b-eeb4-48ab-869d-d33bf245ed90"), 4252, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e70dec3-18aa-4fde-b8ec-fed059da3182"), 4411, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e81aa92-1a8b-4753-b767-405f2127bb78"), 4422, 4, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e82e79f-bafe-4acf-b119-d2c614c1d450"), 4020, 10, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e846e73-81bb-4b14-b48c-444804a1b288"), 4306, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e8bb70f-9bd0-4b9f-99af-e6d2e75e854c"), 4256, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e8d28b9-d40c-489d-b89e-c8c7e3c4155c"), 4611, 9, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e99f757-0312-4ea3-8b38-073a891206d7"), 4636, 7, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ea123d7-52de-4ee4-93b1-6793a0a6c757"), 4432, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ec46b3a-b54b-4b5d-9133-a3eae0df047b"), 4717, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ec5ff2a-e17c-4985-9d04-1dc3374a8e26"), 4214, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f0434c2-cc08-444e-83cc-ffdcdb497887"), 4111, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f269dd3-8f83-4468-a1b0-7a18e48c4305"), 4704, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f2f7236-08b4-4048-8ca9-55f6acc2f8ad"), 4624, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f3d4b56-38e4-498e-974f-81068c03bd39"), 4215, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f41d686-a83d-4dcf-adbc-d6813708fa11"), 4717, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f9477bc-3686-49d4-adde-2dd41f7f7ee6"), 4564, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f99564d-5e3f-4eb3-ba7e-5c9e8f51732c"), 4215, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fb60a12-0ba0-4d30-9b7c-600f7d8b1f4d"), 4113, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fbcb9b8-d17b-46ea-93ed-3d0d90dda901"), 4241, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fcc9e8c-078a-4d4c-91da-43a23f582439"), 4711, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fd48b76-69d5-4219-bb3b-f8298f97ea4e"), 4656, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fd7a9d9-f197-43bd-b6dd-3124693f2b6a"), 4240, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a002ecc5-3f75-4d84-a525-5391b0ba6d69"), 4305, 10, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0318661-230b-4230-8e95-9fa2727a53b3"), 4709, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a039e0c5-50ee-4f90-8196-c38bce4d4591"), 4462, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a043ea60-8789-4406-9e9b-95fc27a89907"), 4534, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0483d46-7fe8-43ad-88ed-7629ed804741"), 4517, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a084458b-7513-4bc1-a139-6ef5fc04a470"), 4425, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a08d0b41-f493-4321-85ba-64edaa02cc77"), 4457, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0c74457-bc73-4c20-8bcb-4a6de303654e"), 4444, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0d2c4d6-97b9-4088-9b7a-154316128521"), 4453, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0ed2f07-2087-4935-9568-861afa1a3f72"), 4264, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0f97a4d-f44f-4242-800a-b9855e2862c0"), 4017, 7, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1368770-1833-452b-9848-fd9d1caa1c44"), 4640, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a13a802a-5345-481b-8a61-8cc4733b39e3"), 4443, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a17dab96-395a-4ee9-85c8-b3ffba5ffcd0"), 4555, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a18c3a22-41ea-4278-8735-9dc6aed0135e"), 4451, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a19319a5-b912-413d-a719-825befd5c5a8"), 4601, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a198a2ee-71a2-4852-9af8-4b1e5b51e1e6"), 4662, 6, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1b0df73-f970-4803-9f5f-d1a4f188a2f3"), 4242, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1b85414-8ff3-4155-9772-5ee1b8a6c001"), 4013, 5, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1c06ac2-00ca-4ce9-9eb1-f4ec50269269"), 4239, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1ca4125-9d47-4b51-85bb-c9817a739a12"), 4804, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1d91868-8333-4f81-90b0-76e215002f68"), 4411, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1e33766-8f01-4ee4-ace3-2085f7d04f23"), 4002, 1, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1f1d24b-2f92-4660-8bfe-95519cfdfd9d"), 4240, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1f77141-be8d-4ae9-a447-3abf524f65ff"), 4800, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1f7b6a3-32ef-4903-b752-6fa90dd0c652"), 4521, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2040c70-d144-4af7-9c2c-8a9374a494b5"), 4657, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a205b879-a80d-4c2f-a318-e2c859986375"), 4714, 4, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2175ba5-fa1c-4cef-b955-0dde02c07357"), 4855, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2222164-c6db-4cca-8f33-982adfd81d26"), 4212, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a224540f-10c2-45ae-ab1c-4c6381ac7b86"), 4616, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a26101be-d7bd-44d0-ad2c-fd44e45fb7cc"), 4412, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a272acba-d4fb-4fc4-9d41-b382c44438fc"), 4211, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a274839b-face-4c54-9f22-53224f17f7a8"), 4523, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a27fdc78-70ad-455c-bf8c-0cf83584ca09"), 4269, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2910105-b52d-412b-a32c-09dfce6f7fcd"), 4723, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2be5ae0-695a-4285-9f0e-a8bcb78e8fbf"), 4611, 1, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2cdd8b4-d557-4a89-a53d-62ad50c15491"), 4302, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2d0f87f-45cd-4b11-abc8-1582dfccbe26"), 4530, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2dc066f-a933-4cde-982d-583350bc21c7"), 4303, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2e9ca77-7b0a-48b0-8747-14990851ef52"), 4805, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2f0cb09-0251-4fa6-bdf1-4ce93a2d7e69"), 4655, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2fbe68e-a5d3-4c2c-a25a-d008765b4571"), 4220, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3139c1b-10d9-425f-937f-e2edf710e260"), 4249, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a31918f6-e66a-4037-a120-0f750bffd273"), 4429, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a35e7b93-c8ba-46cf-81c5-95fe6f0ab92e"), 4203, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a371b001-5198-49c3-ac07-b0623967a954"), 4212, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3774a31-23ee-4214-aea2-6dde163a8c43"), 4004, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3797bc3-ee96-4315-8165-687ee6a3d43d"), 4313, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a39cd859-f41b-4222-aa7e-b9152eea7953"), 4208, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3a84f6c-d1e1-4cd3-af1d-cfa11e69489f"), 4710, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3aebd8b-9a1e-48c8-9b25-972a7cb5ca47"), 4436, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3c8844c-d095-4151-bbbf-0c08f11251ee"), 4220, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3df23da-ff39-4b25-a0ee-4284f61c4fbf"), 4207, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4089687-40bf-4dfd-87fb-0fbfb4c3a653"), 4210, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4126c2f-ea3f-4428-b7c4-7cbbb0d8b180"), 4428, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a415f314-da65-4412-96c2-2ec80f6d718f"), 4310, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4276260-9630-4e04-bd86-a285557982b4"), 4457, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a43d264f-132f-4583-8530-73fe3d885320"), 4461, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a449ec4f-9b8e-4672-a53e-9ddfec587a29"), 4640, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4606c55-88b8-4d44-8292-e6ea7bed83b0"), 4018, 3, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a461c7ea-a434-487b-a0fa-60048b4ebdb5"), 4313, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4739770-69ad-4fb1-8652-7aa6a3d7b4ee"), 4235, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4806271-066e-46ee-abd0-cfee767decac"), 4031, 8, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4974a80-db2b-4e8c-a000-fb902d5a6369"), 4245, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4a99529-a46e-44c3-b6d2-7148a7742090"), 4803, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4cd3086-fd0c-464e-97b7-1507057baf4a"), 4511, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a50d4f3d-b5e4-4fe9-9e02-73dc0bcc37ee"), 4225, 10, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5194e2b-7a2f-48ac-9218-4322ff1b2c11"), 4541, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a51be6df-3f6f-42d8-9298-a96b97cc1b97"), 4850, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a51e9962-c07f-4245-9106-3865749bbc0a"), 4809, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a53d3adb-f3da-4646-a157-1075fc17c165"), 4410, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a541c1b0-9a06-44b6-b362-0e1fb44e2d91"), 4543, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5429fc5-4d42-4e11-8f98-5527cbd57710"), 4713, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a55df364-afc2-4156-8147-c5dc14221b55"), 4602, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a56ff04e-ccc1-4ebb-9b42-812e04f7d56d"), 4511, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5797ca4-d72f-48a0-bbf2-c2ed872a1eb1"), 4026, 10, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a59800e6-f9cf-4031-9faa-a27dc2c9f49c"), 4221, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5991627-5cf9-4295-acff-1bea7b2d8728"), 4432, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a59a2cd2-5a3e-42f3-a256-90ba8950b97f"), 4544, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a59f738e-682c-4e77-a5d2-439a2374fc5e"), 4515, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5adc4c2-8852-4cf4-b8e1-db303407401c"), 4707, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5b10afb-4108-4ed4-a5fb-d774ca8f4c51"), 4236, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5b30c01-1eac-44d1-952a-c8afcc7ba788"), 4411, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5bacfee-9790-423b-af40-348642364dfa"), 4322, 4, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5d64dbe-3a3e-464f-a4e5-1901320250d0"), 4270, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a61d1d82-009c-494a-b161-c43b7647734c"), 4435, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6795378-caf3-41b3-8ae5-bcd84ff0c38f"), 4618, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a67e9462-8b80-46a8-8774-5a650af3d0f0"), 4114, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a695a7c4-9734-4913-a1dd-fc368c3b7af3"), 4322, 3, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6e00b89-c4ce-4be7-a0c6-015257b84e59"), 4615, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6ff0aca-0f8a-44ef-9651-7429d56f186c"), 4205, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a700505d-2d4d-418e-addb-320d7dd255a9"), 4555, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a71aa690-7784-4fe7-9f18-f5296297cb2c"), 4709, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a72b9e56-cfd9-4fd9-8e06-8eb8c64378df"), 4260, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a751a7b8-82ff-461b-b999-f65e761657f8"), 4721, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a778290d-6bc4-47d5-b7ad-4edd726ca5ff"), 4029, 6, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a77844fd-b128-4829-80ba-9fef786a5852"), 4027, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a77ed721-61b6-46e9-9eb7-570083092985"), 4202, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a782a56d-08a5-4c1a-8b5a-e5e42e143513"), 4247, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a786e4c4-b20d-4001-b69a-fde3525ffae6"), 4014, 3, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7af56c5-be7d-48dc-8778-dc7d579cd583"), 4515, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7b6dd20-6c3b-4795-b5a6-cbea3f86f111"), 4626, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7bb706e-78d4-4e35-b208-5b45a73b8cd8"), 4109, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7c97e90-f8a5-4f5c-a382-68ef4143b16e"), 4022, 5, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7cbd622-5bb1-4e05-b7f8-0ef60530dcca"), 4641, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7d167db-594a-4dee-ac40-888bf42674d7"), 4025, 3, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7f6a102-567b-4573-aa14-1bd04bc951e7"), 4410, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a805f2e1-354d-4b1d-ae06-998b730e4f9a"), 4405, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a807a146-3c25-4c6a-9301-a4f745c3945f"), 4721, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8192341-02d1-4a00-9150-97523568e1e5"), 4412, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a82a447e-dd41-4f2c-913a-64f259b9cc06"), 4510, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8301b82-587b-4930-b8b7-6c5b1457326a"), 4201, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a832f8c3-baf8-44ab-8011-e908d1e60af9"), 4418, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a837591c-885f-4f21-baea-081e090a671c"), 4406, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a85586a6-a089-4a73-b5cb-f429610c7b9f"), 4658, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a85e5dc4-e231-49ec-b7b9-824b492f9992"), 4029, 7, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a85f9403-0f59-4a9c-b1b9-42c098958e2a"), 4542, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a865bb7a-ab68-457a-8123-706ffe087134"), 4101, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a86d740f-6bb5-4198-abeb-7e03725e64dc"), 4022, 6, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a88921c4-a349-43d0-8fb9-8e66e9ae1442"), 4853, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a89561ef-d2ad-42fe-b30f-57fa25497495"), 4609, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8c54f4d-fed6-490a-af24-8321560bf10b"), 4456, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8cbc0f8-926b-4308-b84c-956f29efaace"), 4542, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8d07b5d-dab8-4d1b-95f1-7b47a5771d6f"), 4241, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8e0cb2b-eaa5-468c-94ea-08ef10307742"), 4560, 2, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8e5f360-e785-4c42-8272-da302865d8d8"), 4313, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8e7d104-75e9-4a04-af8e-d7667cd63a18"), 4211, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8ec2fab-bbc3-444f-b083-783173ea0117"), 4231, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8faad3f-ba06-4762-95a5-949bd9c10a62"), 4100, 4, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a91045b5-3a69-4fbb-9e69-d83c8010feb0"), 4706, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a911f7ed-4c44-453b-bc7b-224ec39716f9"), 4432, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9290d21-010e-4728-9b7a-f8020cfd1871"), 4616, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9994d2f-b371-4625-9e13-467b331f106d"), 4802, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a99f3e5c-7433-4fcc-bc02-cec7b7c6505d"), 4306, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9a0f631-7dd7-4b03-99dc-c8a6e1c362b5"), 4711, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9a5b770-15f0-4022-b7c6-dff8c7b9941e"), 4532, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9a5c649-b0d8-433e-b559-616f4d7b14db"), 4563, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9d1ef69-2c91-480d-98ad-652b44567345"), 4445, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9d72cb9-553f-4ead-86ce-80cedab8d0ab"), 4719, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa070f10-85ce-4d19-b20a-5f497e35ac05"), 4272, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa09a3b1-d78e-45f3-87cd-e2bfac09f9ec"), 4223, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa11a66d-1cb7-4211-9c48-831939df1ee0"), 4719, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa163e61-f0ee-4325-a291-4336877c932b"), 4464, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa26c739-de21-4524-b0ef-40de56b37457"), 4113, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa34544b-3d79-4ca1-84e9-39a7541476b8"), 4036, 5, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa445e28-106e-462e-abad-8158fc796d34"), 4508, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa50ce6d-dabe-4866-ba34-558e9a8e1bbf"), 4532, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa95bc7e-9bd7-48b9-a6ff-daada2dbf813"), 4550, 3, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaa288bb-92d5-460c-83ca-b630ba6268fc"), 4435, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaad5957-0c9a-4088-a96f-94ce0c34c76a"), 4607, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaaeb530-15ec-4554-a147-d4085a3b1b9f"), 4302, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aab1ac5e-3bdb-4feb-aafe-6ca2791d0d16"), 4236, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aabfeb81-c7cf-4227-8a12-0fa5e494c96d"), 4443, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aacb86ea-f0c5-47e9-8d97-273275c6f668"), 4004, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaddd95e-4708-4103-a3ba-7740f45bee4d"), 4035, 2, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaf9ab7f-6f24-4002-9fb0-8948867d275b"), 4212, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab11e9d1-f9ce-4eef-807a-bde73ad50634"), 4618, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab33bf2d-8d93-4b25-bfa0-9cfaae90f0cb"), 4810, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab4769c9-48c6-4e00-adc7-dbf7d70dd80c"), 4534, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab57a35c-0753-42d7-b32f-9451eb5e7525"), 4414, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab65bcc2-14a7-43b7-9826-540afddacd56"), 4249, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab945c1d-7ec0-4513-9371-bc65b18bdf8e"), 4227, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab9eab09-537d-402f-bbe1-3fd14922a975"), 4545, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aba209e5-d437-4b69-bd77-3c321bf7f6a1"), 4542, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abba0cb8-1c08-4ecd-afef-1d11efab1cd7"), 4027, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abc174db-7504-4001-9b08-79588010f2b1"), 4263, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abd80c19-0e7b-44f1-81ee-4963e0ba2a2c"), 4012, 7, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abe80573-65da-4088-9d96-b55c475757a6"), 4517, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abeb1d0a-5ad0-4b79-91ff-68b8d193c1ad"), 4543, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac07f590-2a3d-4297-86d7-c33a1742767e"), 4222, 8, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac0b47db-477b-4b57-9c04-bddae88a0c68"), 4030, 10, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac13849c-112a-444c-be49-36aff4bf722e"), 4655, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac28c6e6-9118-4c85-8c36-ad5b825b12d7"), 4658, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac4758da-b919-47d6-97d2-66bd007a3ab1"), 4803, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac554369-0bf2-4a04-9cc5-23f72ec785ad"), 4427, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac5ffccd-2af9-4983-8bc2-b9943a31ca06"), 4203, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac8e77f9-1798-43bc-9397-19d172a28b63"), 4219, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac956230-78be-4a97-baa5-9e4b35e3b601"), 4507, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac96c85b-b0f7-4a76-942b-874b735df3e7"), 4110, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acce7524-c064-4a60-b33e-d2a5f0a21777"), 4612, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acdad1fa-888e-4d71-9cac-cb4ba362be22"), 4263, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ace57873-1606-4fa0-bad9-c3a292f2ff2e"), 4528, 8, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acf84acc-a3ae-4538-a37f-f8d183591bec"), 4507, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad0e78d8-f2e7-4d6a-918f-02de2c41cfc1"), 4505, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad208657-17f7-40fc-a8a6-cd781935929b"), 4201, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad37ea1a-3c0e-449c-b3e8-32ed5dd36d9f"), 4458, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad50e580-1dae-4417-b346-da83d24a3f53"), 4529, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad54b9e8-e22d-4f07-a95e-031d8992f6bf"), 4641, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad697646-df19-496c-b51f-383eb2eb87e2"), 4810, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad6f6068-1917-4f89-8dc1-929ed23c78e4"), 4446, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad83a9ad-7da1-408d-9a5f-f1c33e0a12d4"), 4259, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad9af452-7a89-48b9-8dba-a767e85ef596"), 4019, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada6b018-cf8b-491c-a9d6-b3ade27950ad"), 4408, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adbcfaf5-afce-480f-858b-205bb8f64143"), 4004, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adc84400-ade8-4b8c-8fc1-51add2864f58"), 4013, 3, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add68ad1-e96c-4b5e-9fe0-91fe5455f0ca"), 4418, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("addd6304-aa1a-4b87-b407-ce98c22a19e1"), 4266, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adf0eb04-17c7-4ff8-9447-991e23836129"), 4459, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adf2906a-08ea-4943-8150-2300ba9757f3"), 4525, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adff8d30-00f3-47e3-8587-07afaaeb9d88"), 4228, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae10f861-8a1b-47b5-906b-927414edcbd8"), 4701, 8, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae113d7c-8599-4e9e-820d-5e3ea9bfea80"), 4663, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae1852f2-bbbb-4cc9-8c7e-5db3c11086b2"), 4113, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae21da46-aade-4c1a-8912-c07345574a71"), 4464, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae4b369a-d7bb-4166-a4b8-7a04110a26a6"), 4447, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae53bab2-c7bd-432c-bdd6-bc34d06c42d7"), 4502, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae669911-c581-4d9e-a20f-b65b214b452e"), 4505, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae8dda81-92a5-4ec3-a466-4b077a7b78df"), 4719, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae9f098d-11cc-4022-8399-3bbc59457c2c"), 4420, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aea58726-3351-464f-9342-5752ed72ab16"), 4522, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aeb390fd-6b7e-417c-925f-92878c8cfa13"), 4512, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aec12cfa-21cd-45eb-a1f6-4c71426882cb"), 4400, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aeccd6b8-7157-46bf-8d55-418821b49762"), 4407, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aefa9ab5-9fcf-4840-84d7-76fed27c9678"), 4241, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af111633-0a81-40d0-a717-a61b642f3114"), 4234, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af19d035-6cfd-4a5b-ad6e-38c4a4b26fc1"), 4423, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af42c997-8b0b-41db-b3f5-ae65e4a26aa5"), 4608, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af894f3b-2c9f-4540-8ac7-89d4b4d35dd4"), 4405, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af8b98f8-5679-4249-b18e-6dca22988071"), 4528, 1, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af9266cf-f29d-44a9-a549-bf192563f19c"), 4604, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af940252-a0e9-4b76-848a-61420a3dc8aa"), 4200, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af95f416-94df-493f-acb3-6547063157f5"), 4721, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af9f187a-3453-4f62-b2f4-c21edbedca36"), 4217, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afa58161-dbac-4bc6-829d-29a390c4403e"), 4853, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afb2ca6a-64e2-477a-9400-04762ef22947"), 4309, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afb4fd96-d5bc-4464-9f90-e12c83130e83"), 4605, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aff00757-00f9-4870-81dc-587b80dbd0da"), 4024, 1, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aff0739f-56f4-4692-b3ec-39a10b22e403"), 4110, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aff7fdbb-1506-4c0b-b107-c3630ae1504f"), 4607, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b028c3cb-811c-4275-b0d3-2c7d9a224f4f"), 4803, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0340661-7d8f-457d-b307-7bc9b28d52e1"), 4611, 7, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0481aad-cf28-46a7-8c31-160399d33ca7"), 4502, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b078e72d-e74b-47e5-9825-e98dfa27f949"), 4503, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b08531eb-43e9-47b5-82e8-bfd89a201321"), 4659, 10, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b095d58a-0507-41e0-8d59-ac395873db0b"), 4501, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0a443ce-abe0-42b5-8ae6-658334174ddc"), 4226, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0bae87b-9a01-4457-bbab-a69834a6af5f"), 4810, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0c092f4-47c8-4321-8ab2-4d6d13ddca2e"), 4640, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0da7ebd-ca3b-4ce5-85f4-66cac32e75c4"), 4402, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0e80e24-c48f-4bb3-ad03-96574c28c6d2"), 4227, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b10abccc-4a73-44dd-9aba-7a1939603c73"), 4215, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b15e416b-53e9-4f0e-9190-b592d664f8f9"), 4808, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b191a7c7-927b-479e-aee8-0fbd2592ec55"), 4417, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b191fea2-8248-46a8-8d20-40f87f69b288"), 4465, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1985193-530c-4d2e-8092-7374f615ef1f"), 4545, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b19f10bf-ca96-4c43-9747-df62c365772c"), 4241, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1bc9c9f-6828-44b1-b28a-41c4ef2c738c"), 4631, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1f618cd-90d6-4ca4-8c51-ee89870d275e"), 4401, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b21b2ab3-7e70-4277-a3d0-26c870afda37"), 4516, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b244a8db-21a7-465d-98b6-25470284b716"), 4418, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b24c396f-1eea-4429-a2cf-a982781e0d42"), 4424, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b25203c6-2ece-4b3a-8150-55ae714be3de"), 4552, 3, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b257520c-9671-4b41-8fef-6920a0a57ce5"), 4214, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b258130e-d54f-4fdb-81dc-6579ac38b3cd"), 4237, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2676931-3872-4214-87a0-1bda3af28c85"), 4408, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2741d2e-0536-47f0-9008-2a336050003c"), 4809, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2757747-72b3-4bce-bc0a-ed831a72e861"), 4254, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b275e992-394e-4e0e-858c-68b0e256a5b4"), 4431, 1, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2a95c99-317d-4b37-8205-f22fb2287eac"), 4614, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2ad2fdf-a959-46f1-a8b6-30b10057e0dd"), 4520, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2b2287a-a602-42a6-9fc6-f66ba6a4b32e"), 4310, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2ba0ee6-0ad5-42b4-91d5-0c6ea1e74f63"), 4410, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2c89d06-4e83-4cbc-9334-cc919db79c6c"), 4558, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2ddd158-c005-4e5a-9e54-bf6a6f64b3e1"), 4419, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2df8ffc-b09f-459a-b467-84afaff5dd98"), 4250, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2e25c23-c703-4f4e-b852-a83eb72c80ee"), 4248, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2e2fe7c-62b2-4568-bc41-a291d6b4a6d4"), 4021, 1, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b33a0268-e4da-46c8-9501-fb199f687ece"), 4264, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b33a6485-38e2-425e-bce4-e81bf06aca36"), 4313, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b340dc59-61cd-4ca5-8bcd-1486a1469356"), 4423, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b351ccee-4b0f-473b-a551-de1f93c3ae4b"), 4653, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3742260-ef27-40e6-be9e-bf89e70b9267"), 4232, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3749a0a-e0fa-42a3-a76a-f12be1d45bd0"), 4603, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b38067d5-a5fd-4a56-af5d-9fc0fdc68b98"), 4227, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b399f0d4-448f-481b-8375-750b9d16dfac"), 4622, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3a5dc2d-9046-4f4e-84f4-15618c3430f1"), 4414, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3ab957d-b534-4a52-8f52-d0f42b461691"), 4706, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3e9a5c1-0009-42df-a233-678e14b8a991"), 4601, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4047c36-b93d-4e47-8223-7d278927197a"), 4507, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b40a981b-2312-463f-82c2-65c740cbefa4"), 4431, 9, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b417293a-2c5d-4d16-ad97-03ee94081812"), 4221, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4175f2e-f436-4c95-9da0-d79e16c58d00"), 4627, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b42c8efb-0085-4bf7-b18c-cd20dcdf1c54"), 4554, 6, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b439e440-3c96-434e-a5e9-294c20518e41"), 4224, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b45123bf-2bec-4b96-8e83-596bec689ecb"), 4531, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4624cf6-24f3-4346-8e7a-b6699d434dca"), 4534, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b48aa3f0-b23a-4f3a-90c4-0182a345100d"), 4551, 5, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b48d8e3a-be73-4ef2-a5b1-593937de0f43"), 4305, 8, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4a5b277-e753-4701-b94b-3fd6eada7369"), 4417, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4bddd2f-abc0-408d-80b5-d5790e780ece"), 4322, 2, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4d44b58-320d-4261-8547-1bf272ace735"), 4252, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4e31bb4-3525-42d9-8c9d-39d39bb4166b"), 4604, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4ea337e-2382-4505-bdb6-41830bcfb794"), 4253, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4f4ab63-826b-4195-8d39-c1ec3f169c2c"), 4109, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4f80045-6677-4f9c-bcaf-fd525f7f12c9"), 4231, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4fc358d-72e0-4576-9fe7-29e994fa58d3"), 4719, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b50fb442-7031-44cf-a659-ca803a807fbf"), 4457, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b51bde37-ee76-40c8-b38c-fd6545431aaf"), 4711, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5257104-87d7-4fd1-bee8-869afc32024a"), 4219, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b52f16a4-35b6-4113-bbc6-767b5f86f197"), 4426, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b54b6c7f-e7a3-4fa4-bbc1-3f5aff1306fe"), 4652, 8, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b55fc458-00e8-4a71-9df6-63583368114a"), 4555, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5622f1b-9cd4-4f7d-8944-102699b0597d"), 4809, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b56d119a-088a-45dd-86c0-af3d2d96df63"), 4430, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b585e62d-e638-4764-9236-e27e5fa5032e"), 4317, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5b1b823-82d9-4708-8943-db4dd5fbecbd"), 4212, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5e4bcbb-7bcd-4376-860d-75aab8190e0a"), 4514, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b600f491-08fb-45f9-88af-c38b09994057"), 4617, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b61483b2-900d-44ae-8742-1b08e3273812"), 4310, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b614c9e9-12c7-40dd-b8f2-4a6151732acc"), 4210, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b636fb96-6836-49f7-87f5-d8d73f0065c5"), 4716, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b63d06b7-7db0-40ec-820e-746eb9be16ab"), 4418, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b63e9ac7-7b9f-43ab-bf6a-a69d7efafce6"), 4537, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b64a3758-d347-4e56-b6eb-583c5efd625b"), 4103, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b65d5b3f-1c86-4a8e-b234-a6c43a58a3d0"), 4313, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b667b5fd-6163-41f4-9ccd-130af94e0e3b"), 4535, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6990c05-97ec-4c74-be68-eb8985268061"), 4272, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6b30f0f-4a1f-4085-8b21-9a5f8c0b3806"), 4719, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6bc7723-e396-4c38-9db4-d6a6d49f9e39"), 4613, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6c0a220-528d-4bf8-8e81-45debb7d3a63"), 4613, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6cd674f-f980-435f-ae62-ea2f9de9342d"), 4108, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7095c95-cd06-4abf-9817-6a602cfdbfa5"), 4013, 4, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b71bc291-6492-4401-a82d-3894e729378b"), 4321, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7269659-7331-4f1b-b7c8-d9bd547c0bdb"), 4029, 10, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b73f86d4-71ec-454f-aa56-b6fc2c1a89f6"), 4417, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b744054e-297b-41d7-b5c4-c8e41375f2ab"), 4454, 3, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7467dfc-19d9-45c2-9703-b166fae252a3"), 4615, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b774491d-b2a9-4be0-9410-b29d8b80b3e4"), 4810, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b776450d-63c4-4911-9264-0729efab819d"), 4411, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7b8ddf8-87f7-428a-ab35-b6fc15af590d"), 4320, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7bbe948-454b-4749-adf4-7a1e67bd3ee6"), 4562, 8, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7ccce8f-7bc9-4fbe-bf3c-0bb6f40e3f85"), 4209, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8055707-5af2-49f2-a621-04ed0c08bb6b"), 4443, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b81fa20f-3455-4633-9c5a-66c005192947"), 4507, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b824ba95-0262-47be-85bf-44d7c8a97232"), 4324, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b82628cb-c98c-4966-b260-561ee0cc0b43"), 4022, 8, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b84a21db-0c5c-41b3-8431-f6d6273cf8d9"), 4627, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b84e5ed5-b499-4bf6-8e7d-cb9a7cf8c5f1"), 4104, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b84e90a2-4def-4ec7-9d9f-fff934c6058d"), 4002, 10, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b893dc8b-dfe3-46b7-bf64-9c047c36d046"), 4320, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8982688-ce40-4012-a1ed-c37b24523c55"), 4272, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b89bd8a8-3c28-44f6-b611-45d41a7f63cb"), 4550, 6, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b89e4401-1d42-422f-9f1e-e402dde5c2ea"), 4420, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8a627e2-65e1-43ff-aba4-86db4e36552e"), 4445, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8dae6b4-68c1-4f3d-8f2e-5ecfd9f47100"), 4321, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8df2f68-ca26-4d11-8680-7ada08bbd9af"), 4321, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8e48c08-47b8-436d-8f88-d8860f8423e7"), 4544, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8eccc08-a30e-443e-aa4a-47dda4593c05"), 4037, 2, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8f2cec1-255d-4b25-9b47-605dd8baf898"), 4515, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b90bdc1e-9f5f-465b-a753-2a53a780c6ea"), 4619, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b92a84c5-657d-4aef-a298-26a57f5f610a"), 4655, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b92e780c-32f7-4b1c-a263-7ef67bd7d946"), 4411, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b941506c-605b-4e42-8085-18d3bed932c2"), 4231, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b97e5ba9-5c5e-470d-a9c4-246e4181931a"), 4527, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9ab719a-d525-45a5-9cdc-e9a0aa4c83ea"), 4715, 4, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9b2b17f-692e-45e5-917e-251b9e22ae25"), 4306, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9caf996-dc09-4b7a-968a-5b59a95be553"), 4661, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9d3e1ff-0d2b-4fde-bce5-4e06f7cdc59a"), 4407, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9d69849-c3e8-4ff9-a821-68dec925e336"), 4029, 4, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9fe84d8-14df-46e4-8c09-86f8e195a379"), 4001, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba13f903-73ba-4e9d-8e88-bd990977d3bf"), 4240, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba166775-202b-4c67-a06c-26fca02bb187"), 4422, 1, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba2cf714-5db1-49de-8761-0dfefe88696c"), 4215, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba425d15-926e-4c22-9097-f9664954e150"), 4516, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba470398-4ecd-40df-b1dc-9a5f1d708815"), 4036, 9, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba4957d2-dc19-43ac-86b7-d32dcddfd552"), 4102, 5, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba4cf4c3-384b-42b4-806d-d03673f7fe3a"), 4719, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba5bb2a1-0b46-40f6-8233-e7fccc2cd5c2"), 4000, 7, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba6c68c7-34d1-44c2-abbc-81187918d5d0"), 4430, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba7f5081-e669-4d29-83b6-9c7e0eaf01c1"), 4261, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba86e002-6968-4ee3-a3f9-8df93b941871"), 4700, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba9869a0-0345-4366-b694-99566740779d"), 4002, 2, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baa7b4f7-04cb-40e2-809d-ae4a50697f0b"), 4443, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bab03954-6bd5-4f93-89db-52eee770f54b"), 4208, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bab5c4a5-ff32-4016-af05-6585a7f758f9"), 4033, 10, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bab875ec-bf15-4f65-900a-b0d8deb8231c"), 4561, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bac63fd5-898d-4bce-9a77-da4e1a86c86e"), 4535, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bacea7b1-4285-4096-8022-fb2b5afbdcde"), 4446, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bad2d28e-0e4e-4617-994e-accfd2eaa5a3"), 4509, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baed93f6-5aa0-4429-a0cd-d9b3e76e0aa7"), 4655, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baff7e1e-cbf9-4f95-b411-bc9389f7257c"), 4544, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb463a95-076d-488e-b377-11af1e8b6f11"), 4231, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb47d850-459b-4af1-8c56-539f89912565"), 4519, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb47d895-aac4-470d-b1d2-20d6a4f7ea1a"), 4525, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb6f2b11-0bf9-4209-8561-bf2df0ffb5c8"), 4226, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb7f61ba-e75c-47a3-9d47-09d0894d6782"), 4307, 2, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb8e54ab-f3dc-4eed-9c12-1d656005f20e"), 4258, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb8f9fa0-dec5-47b6-b005-91525a58e343"), 4607, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbaa4b58-fb3f-4ce5-a87d-90fc0f9283ff"), 4014, 8, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbacf3eb-a463-43a5-88cc-a216304b1c44"), 4244, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbae23aa-7157-40ee-a14a-002daac2102c"), 4558, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbb06ba4-e6ad-4ede-b757-f72d84e65d28"), 4428, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbc29862-d515-4860-8d0e-e9a24e5545e1"), 4518, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbfd9d29-3ee3-4523-83f2-92397711fed4"), 4205, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc24150f-a510-46fa-a7a7-438177fb6db7"), 4318, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc252460-bca4-4b0d-b38b-0abe404c7b42"), 4211, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc2b56ed-cb36-42ba-a0fc-24a846ea6b2b"), 4802, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc31bf8e-8dcb-43f8-87d3-e07596898260"), 4200, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc4be14b-7a6b-46a4-9362-dd31a5448f5f"), 4608, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc5ad691-eb81-4518-9e3a-c2c5455c5490"), 4434, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc5e0157-4ffc-4f86-ab50-b7245eaaba20"), 4304, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc5f0794-6c93-4969-b3ee-9b35e342de1b"), 4414, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc72f572-cb6a-46ea-9bb1-24d82f07882d"), 4454, 10, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc81d402-41a5-4641-b713-3b0a78025cd9"), 4012, 9, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc8c0dfb-c1ac-4e5f-97d9-020a6cbf0fcb"), 4715, 6, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc8d0978-2440-4ce3-9d60-b8556858b073"), 4260, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc90a752-9c29-45e1-9fcb-51871b087cd5"), 4612, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bca19043-dc85-490f-8149-4e7c91cee450"), 4423, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcbc541c-ec9c-4874-9792-a208f0501560"), 4617, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcc863b5-ccd4-4824-a915-7d863d47ab33"), 4403, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcd92cc3-507f-43c8-9a7f-8b25fb7f1289"), 4525, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcec69da-9f02-4de8-a51a-a68653ec3b1b"), 4701, 1, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcf1ab82-69d5-404c-b78b-317c5a04c91a"), 4245, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcfa2d84-489f-4d73-8c1f-a2514f1d3d82"), 4630, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd1971d6-5452-4dad-b460-65e27e143701"), 4261, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd1a85e0-c04a-4539-ba24-a44f59e8b146"), 4852, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd1f015f-b4f3-47b1-a10c-2df252c28103"), 4600, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd344a3e-5c86-438e-8ab0-e64393ff6825"), 4451, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd3c7b00-07aa-41b5-bfc7-db2e040ac99d"), 4210, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd414a28-5442-4310-a538-8eae5c2d8f42"), 4461, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd67f47e-0cb4-4422-ba2d-df4b2d9076b9"), 4402, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd6cbd76-abd7-4340-a390-2c71e46a1ac6"), 4274, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd8a58d8-bbb3-4b25-8d68-7b32abd5d03d"), 4232, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd8dff42-ad68-485e-974c-8cca7757a133"), 4704, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd90abac-20b6-4017-a0e0-32099b17e48e"), 4248, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd946148-6635-4c52-b8b3-973c041dc8df"), 4011, 8, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd9e8619-3bd1-46fc-b134-042cdb5f6775"), 4612, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bda558df-2e59-46cc-a325-a08101fd09cd"), 4501, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdd2726c-ff92-4d9b-888d-6ddd8bf3471a"), 4242, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdec744b-84a5-40fa-a9b2-72269bea86ee"), 4544, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdfaf460-1afb-4074-bf93-66b343afa480"), 4615, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be0faa07-0b23-45af-8c1e-4dfcea92d41a"), 4626, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be17e29a-dc3f-4523-bbcc-bc20c325f8e7"), 4006, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be1d9b3e-0d98-4957-a3b7-e5a3a29db77d"), 4319, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be3895da-ecb2-45f7-8e72-e210badbef06"), 4247, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be59d33a-4255-4487-a381-56552f361607"), 4032, 8, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be7a35e1-84b2-4aa9-832b-430245de243e"), 4709, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be87eb68-2f34-4249-a0b2-fe510960ee85"), 4720, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("becabefe-e6a0-4298-b720-e9f41b104626"), 4238, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bece8636-bab4-49a9-8265-934e5b513b05"), 4025, 9, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bee93bb5-19bc-4abb-8df4-a3722e9043e5"), 4504, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("beeb7876-ee74-48c9-ba00-8067cbc60cd2"), 4430, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("beee6fd5-159a-4a83-881d-af01ac2d2448"), 4806, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bef27e81-863c-46e8-89a2-45d9e94d7f41"), 4514, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf04aa52-7101-43c6-b504-e9004485f186"), 4014, 5, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf066a44-f445-4828-ae64-fa78abf195e1"), 4202, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf220f07-dafb-46f1-bcb1-400c0f3b30b0"), 4538, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf25c408-ea29-4571-8b4f-8bd4b6ff4ad3"), 4606, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf2d77f3-4aa7-42e6-9b9f-5a88965e1424"), 4026, 9, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf4615db-893b-4401-b997-3e794935db47"), 4313, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf4dad5f-c6b4-4576-af25-54c687bd35bf"), 4020, 5, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf537c52-7923-46aa-945e-85ef54799176"), 4452, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf60a5c6-c5b3-417c-b97a-18e9d0cf3f75"), 4424, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf60d5cb-c0ad-4ecd-a750-7d200edbbffd"), 4550, 7, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf758869-ba8f-469c-bcd0-10773b9202bd"), 4501, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf7b1069-18b2-4fb7-9498-f63a24e8e51a"), 4403, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf7d0515-bb1c-4ea3-a0d6-a8f716d424ba"), 4433, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf825d37-df06-4f1c-aab8-1745fceda5b0"), 4108, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf8a75bc-fcdc-4676-bd69-a7f1edcd18cd"), 4610, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf9f7daf-15e3-4693-b440-2e2faa4918aa"), 4602, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfbdc164-d445-4882-8f2c-be3b5b13d8d1"), 4031, 1, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfe65448-2f2a-4705-97c3-b00581595465"), 4515, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfeca79c-c36f-4202-a681-bec63f2aa982"), 4225, 8, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bff1dee3-cba9-45e9-8aa6-33617d54442f"), 4201, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bffde2a9-b9c2-4c02-96d3-2056e2ff847d"), 4601, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c005d6d5-e337-48b3-b01c-3af8c06c6b45"), 4624, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c02234f2-b456-4239-91a5-d0063b823840"), 4855, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c03e327c-f45d-4780-a50c-4ff622dbb5a9"), 4654, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c056b6c8-7add-42fd-919f-29f6985c0e4f"), 4113, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c06b049b-c3ab-4b97-8691-740afefb9494"), 4704, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0706cb7-c007-4a8b-920b-fec634e91815"), 4259, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0818e8c-c681-4bf0-82d5-9a80bf127244"), 4114, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0821db2-3701-4317-8525-5ab7301ae398"), 4271, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0d0bff3-799b-4a7c-9a0e-3429be16dd32"), 4808, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0d9759e-a3d3-4383-b046-988f3f844b27"), 4406, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0dc6e5d-bf18-41c5-a1d8-ef16a3ab4c79"), 4527, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0e33ea7-a242-4541-bc65-d59ea86729c3"), 4268, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0f4c777-50f6-4286-ac30-a6f0acb418e0"), 4447, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c11285e0-4689-4d35-989c-5bf0ff9f4200"), 4435, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c12c8e0b-308d-4ad7-bfbd-42d09a7e0c0c"), 4246, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1459502-6a0a-418e-ae11-18dbe77ff3b7"), 4229, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c14e6ab4-a1d6-4a5c-9708-b378ee0ed1a6"), 4554, 2, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c172ce6c-822d-4c77-96be-23002c20e8e9"), 4426, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c187a800-f1c3-468b-94a4-2ba155ca16b7"), 4421, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1a0c5a4-6017-48a8-be7f-c1c7d7277c85"), 4545, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1ae4772-92b8-4854-a8a3-6f3d595fd8d2"), 4610, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1c27d05-d506-46e1-b548-9f2c9f842d09"), 4452, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1fe11ab-e472-4437-8156-31bd02e064cc"), 4439, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c22f8c1b-9bce-475c-be06-9f4c6214d53d"), 4250, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c234c987-52dc-49b3-9b6f-f643874f7946"), 4718, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c24b4980-87dd-4677-a61c-fe3584aa1bb2"), 4804, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2572eb6-03bf-489c-b8e2-19de3701ce90"), 4011, 9, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c265e1d9-1a5f-434f-bc4e-205ae7d60645"), 4547, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2698df3-291a-4369-b4b0-94f19169d14a"), 4242, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c26aa8d4-beb2-465d-b5ae-68fff8fcfe52"), 4558, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c26dc638-22b1-48b2-86f7-a890299ce0f5"), 4654, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c277facc-b48b-4ac1-ac52-94bc3142ea85"), 4249, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c29550d9-e1eb-4692-a6e7-5371db8867f6"), 4554, 3, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2aa1b69-5a08-4e96-b1e1-2c0f3e0479fc"), 4543, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2c87ff5-1842-4b5f-993e-077aeb282ac6"), 4600, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2dc6a2f-de52-45d5-94b8-eac2b2a4433b"), 4212, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c303dfe1-032c-418f-9a7c-6941fdeb5784"), 4307, 5, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c30a3cab-54ca-44ef-a312-072efbdcd4e1"), 4560, 10, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c31d22e0-1975-4f5a-a365-99e5192945e1"), 4716, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3285ccd-f646-45ef-a2dd-9ed02ebc4608"), 4525, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c335ef5d-29ca-466c-8385-4329c0b88420"), 4324, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c33cd837-30cf-4e12-98d3-fc35b9cbccc4"), 4261, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c35455fd-a667-4441-9e97-d6d2783722f1"), 4519, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c363fbbb-3e2f-4660-afdd-b20c90edde15"), 4714, 3, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c376b48f-521c-47b0-b038-bbb3591835b9"), 4854, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c376ebf1-1f37-4951-8861-8096668b601f"), 4034, 9, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c38db348-9bfa-4ffc-94db-b760267841e8"), 4024, 2, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3af1c1f-e09d-4ff6-aabf-1047e3543566"), 4633, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3b5e87d-ee1e-4b57-90b1-f43b1cf9abf0"), 4273, 9, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3c2be51-858c-425f-ba99-0eef22829e9e"), 4324, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3cfbff3-4902-49ec-922f-6f5908e2fc0f"), 4604, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3d769ca-7b97-46e1-849a-9d629c6ef968"), 4229, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3e23803-8b52-4859-88a6-7f6f00abf9b8"), 4515, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3e8fa39-58bd-4211-b7ed-aa1d721938d4"), 4270, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3fd3b3a-e250-4590-b1c0-7c8331e9e83c"), 4506, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4011808-2e6e-4fb5-90a1-e6292306d8a0"), 4606, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4387bb3-32b8-4c01-9e93-6efb3a3d256c"), 4460, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4617b1d-cd42-4d58-a45c-538fb5f50891"), 4710, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c477e49c-ccea-4f9c-bd72-dd652e4dc53c"), 4806, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4809f03-3bb6-463e-8d01-a71f0cd47cac"), 4400, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4ced5ad-8e98-4b01-892a-2275de05c625"), 4400, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4de89bc-5652-4bd9-a632-2ef7450ce121"), 4852, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c506df4b-f6a8-4853-888f-dcae51b46aef"), 4030, 1, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c52422d8-2db0-45d6-b760-d8048a4d89a6"), 4413, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5320a91-d935-4c97-a4e5-9f07c30e443c"), 4406, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5335cfb-b548-4f49-9d56-c18655e55379"), 4616, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c54037e5-2f23-4f1f-9b7e-5361f486b5e4"), 4556, 2, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c547e984-ae9a-48dd-864f-c0e6b7b1f920"), 4554, 10, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c55aa6a7-02d3-4d82-9678-15686ee4a7ca"), 4021, 9, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c55f9be5-1bd0-4a30-b963-ef0cb25afaf5"), 4274, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c56f9613-9d8a-4126-a989-5fba1e797941"), 4713, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5a3e606-3152-4302-9ad7-bc3c835a4640"), 4430, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5d4be01-9aff-478d-80cb-21a20ea83357"), 4658, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5da49be-82d0-4cac-8c86-cb3e5fd392eb"), 4233, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5ec07be-e379-424a-8301-129362aba8fe"), 4238, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c616a6c0-9308-4618-b35e-b36e0e7b07f5"), 4225, 2, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c61dcbab-aba5-4b46-a7f8-371ee802f11b"), 4012, 3, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c62adefe-be5a-4f7a-864c-f460084e1d3f"), 4424, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c64f548b-59b4-4d48-80ab-e8beea63697c"), 4554, 4, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c674de3b-5256-466d-a7b3-b13b90e4be91"), 4011, 3, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c68eb16d-0f51-49b0-aafd-76244552ef01"), 4405, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c698c168-1853-4c3b-a450-3b636d9b0ab3"), 4512, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c69ee124-83ad-4b34-8914-334604d8b90a"), 4650, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6c8b0d1-3da2-42d7-b820-75a72a2cab6a"), 4112, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6e6d99a-d874-43b7-985d-39195d9bed4e"), 4528, 2, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c716ae45-4b7b-4c64-98b8-798fe7ed9ff0"), 4513, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7299c7f-9d97-4f52-a6e1-a2410bf25a30"), 4434, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c734279b-19fe-496c-94cf-a6e4c4c1c54c"), 4000, 3, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c75274b8-f5da-40ad-8290-e10a28fcf559"), 4631, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7630dc0-4616-486a-bfc0-30cc0d6c42ed"), 4315, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c770683b-03d2-48bc-915e-8871b3853c76"), 4650, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c773caf6-71cb-4e5f-a336-bd95f4637b4b"), 4523, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c775da47-c68a-4fbc-b35c-970cb6c90ba8"), 4428, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7803020-e83d-4c91-aac3-b74bbb6ecf3c"), 4553, 9, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c789854c-d5f6-41e6-8269-4e0601a7595d"), 4450, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7e0ddc8-bd08-4689-88d8-d01a2004c63a"), 4641, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7e9e7c1-f828-4ee2-96b2-b0c10339761d"), 4628, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7ec6aaa-d4dc-4ebe-b2a7-29d27eb22bcc"), 4631, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8172005-c183-48bc-95a8-dfd078f38836"), 4513, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c85208b0-afd0-4117-9f1b-b8712d7cc5b7"), 4227, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c866df5c-6d1f-4ea9-ba14-bbf1b641c168"), 4433, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c86b0ad7-eafb-4db5-a892-083580839d2b"), 4102, 2, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8816f27-cd2c-41ea-83fc-f6c21973bd50"), 4560, 6, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8a2daaa-c1f4-40e9-ae91-9921921617b0"), 4511, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8a9f991-496c-4fff-b2e8-4b687fcc1c9e"), 4268, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8ad7567-46dc-4ace-9f6d-ab48518d379e"), 4026, 7, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8d0d1ad-d729-4cdb-b513-54abec4b38bf"), 4450, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8fda178-2364-4664-8d4f-a3d8866cdc20"), 4703, 9, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c903e107-cdce-43c6-969e-416ae9493dc2"), 4453, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c90997bc-e437-4c4f-b5fc-3e4d49e63cae"), 4011, 7, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c91902b1-302e-47ef-84b2-60cadee21549"), 4612, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c924e352-ae39-432e-96d7-0d1dbb0d8a22"), 4537, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c96e433b-82da-45ec-923d-04f294c44b0f"), 4105, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c991d4d6-35b6-4dad-b1be-e3640e3c2f36"), 4220, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c99934d5-f47d-4346-910d-5a7889b4ddd0"), 4434, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c99f8f14-d909-44f2-901b-ec63fcc13127"), 4424, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9b27f8d-3b6e-4903-8f7c-68155519010f"), 4419, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9b7afc8-8a77-480d-b51e-b4a2c38040e1"), 4458, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9ee6187-4390-4e99-b368-1c2ddf5bc901"), 4712, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9f8bf6b-52af-4b3c-a4c9-9e20ce5493f2"), 4509, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca07e935-998d-49cb-8d98-684d3444d6da"), 4504, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca134478-0806-4a3c-b72d-4dc38b1df909"), 4850, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca16591f-6bdc-41f1-8e8a-355215244479"), 4435, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca2db521-b8e2-4c20-a4a3-b82d7cf7e27d"), 4035, 1, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca3da54b-6265-4e20-9f6d-35c176407984"), 4464, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca60134e-973f-4895-a7d9-b793efa67b76"), 4524, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca7a2a1b-9dac-4b3a-bb17-e15068b4ce75"), 4240, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca999b33-cd9f-4e60-a8ff-fad7a8295eae"), 4230, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("caa0451f-0d78-4e5d-bd5c-12153332d098"), 4625, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cab5c31e-a961-48bc-af3c-25ac74e6595d"), 4252, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cac75d14-abd6-41da-b54f-69a3ce297fbf"), 4564, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("caea3ae0-276c-45a5-b749-734ac4cd164e"), 4439, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("caed6a08-a1fc-4b45-8f61-3904ec2ebca7"), 4019, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb01dc14-595b-48c5-8cf2-87721e6cac29"), 4545, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb0ecceb-0f5d-4880-91dd-24da63c9369a"), 4304, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb26bcf5-a513-44a8-afad-a3a2fede3e72"), 4032, 9, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb2776c1-6835-4372-8578-349fc6a5d262"), 4652, 9, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb3d791f-2c05-4f41-8049-1ae505191550"), 4806, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb716ae2-ddf9-4490-8e53-64adbe64d8eb"), 4804, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb7efdd2-2dde-4363-acbb-6e76170ba580"), 4523, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb7f389c-6874-48b4-b22d-f55aacf87d23"), 4531, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbbf68ce-54a6-4ebd-914c-79d6d5a7328b"), 4639, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbcaff40-cbc6-4b61-9d81-2ef760a71bdc"), 4425, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbdf4ce0-7bf1-4a09-80d1-869f43838566"), 4540, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbfe23cc-87be-459f-92c8-27c258f0b7c6"), 4614, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc0c2f0f-6ddb-4abc-a478-c2ad9d70c44c"), 4217, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc17055c-1387-4afd-b097-92dbb22e98e9"), 4403, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc1d6547-341f-4018-8c9c-cba474ace360"), 4803, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc2daadd-e05e-46f3-af71-60e12dd17eb6"), 4009, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc6c467a-5ecb-486b-85e8-327f5c915242"), 4547, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc8a5dfd-fc24-40fd-b56e-b44a26ea75d3"), 4657, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc8b534a-60cc-43ce-9d5f-e1231e7feb60"), 4804, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc9c1699-809e-4e3b-a925-176851e298c0"), 4651, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc9db55f-8274-4530-8196-9e9d4097e000"), 4201, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cca04a80-2d37-4c2c-b833-0a0988a68bc6"), 4627, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccc83908-797e-4657-8a7b-2ed185e67233"), 4244, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cce333a1-6141-4953-9a59-b664cfefd69c"), 4210, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd046d10-dd55-43a3-9ba6-d6f963ca04c2"), 4523, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd221574-3f1c-4b90-8ffe-409a4dd9c040"), 4453, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd2d486a-02f8-473a-a840-f81e406636bc"), 4200, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd576165-b2fb-491c-b7c4-bb97266ed739"), 4514, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd58ce26-8669-4e6d-b89e-b83a28faa944"), 4505, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd747964-aead-4114-a6d9-8eac567491f7"), 4605, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd790176-aaf0-4299-8685-181cc0770f66"), 4437, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd7cc45c-d5a5-48de-8146-a4b0eda9cf36"), 4510, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd7f325f-99b0-420f-a32f-ef8e9e706845"), 4030, 8, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdae8aa8-8330-427f-91a9-842a2c9b9357"), 4806, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdd7cffb-33c1-4917-b80b-fe36c3676471"), 4244, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdddd7b4-e895-465e-8331-348e501ceb80"), 4851, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdf8c3f2-959b-410f-b095-423683bca132"), 4558, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce07982e-79ce-478e-a96a-fc72f5c47e85"), 4423, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce32abde-ffee-4ab1-8cee-dc8810a3feb7"), 4701, 5, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce390a27-b165-4265-96bc-90e3fb86a5dc"), 4308, 8, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce4af81e-998d-44f7-93d7-012fed8fe2fc"), 4552, 6, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce5c9766-2cc9-42df-be8c-885e8257af9e"), 4300, 5, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce745d0a-6292-4386-b5a0-e27bee8a7adc"), 4234, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce7d2cdb-799d-40ad-a560-4afee9877db5"), 4620, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce888863-8000-499f-abaf-58cbab1e43de"), 4545, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce993141-6265-496c-8b64-81a3973e8643"), 4311, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cebb070b-6a09-44b8-b797-94dd2b54a64c"), 4226, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cebf1382-6407-4799-b2d6-b0131140f675"), 4321, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cebf26f1-859c-47e6-a2d3-04f192055477"), 4322, 7, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ceccd151-a216-4a61-a227-ab6bffa39759"), 4438, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ced57c78-e04c-4127-ab60-3a21fbc4289f"), 4722, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cee62eef-722e-4114-bbf7-bbf2e7da3f85"), 4323, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cee8b7ce-d4ec-42c6-bca2-227b90bdd738"), 4622, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf0cbdf7-5a15-4570-a407-93488c2a6ac1"), 4274, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf12f341-eded-4fd9-bd2b-1b734b364a43"), 4033, 3, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf289472-d70f-4bf5-acdc-e5aa0640ec9e"), 4427, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf607d83-62e0-4f7b-9b4c-6825a2c1b942"), 4436, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf626476-3538-4098-8d03-f0c08631d393"), 4512, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf9c6f85-36d8-4b9e-b5b2-80729be74d24"), 4303, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfa895e3-e9f9-4289-8d8c-d8ebb6c2f332"), 4636, 5, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfb0ea86-7399-4cc8-ac71-d83b0a09da6a"), 4205, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfb94709-20c3-4de0-bd72-9488f6a17718"), 4236, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfd142d2-857f-496f-bdf0-107d40a79e21"), 4421, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfdb118b-2bbb-496d-bd33-10b95f10a2d5"), 4033, 5, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfdbbf17-2ab4-40d1-af72-701a5612076f"), 4607, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cff283b1-7674-49ff-a378-ca78f3ba175a"), 4243, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cffa3061-da99-4072-a275-76776559a2bb"), 4653, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d006c5e7-0f69-486a-b2e7-dd8b9b0be347"), 4855, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d00722e1-aad9-472f-bc28-21f5b323ca56"), 4500, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d011082e-331f-44d3-a479-cc5f3150b414"), 4523, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d01654cd-39b1-4772-8a7f-2e2858b56c83"), 4003, 6, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0188244-6432-49fb-a882-b7a275f1bd34"), 4446, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d018f92b-f543-4c7c-b628-9657945aa075"), 4558, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d01c9fe3-de99-4892-a35a-c7200c92c149"), 4008, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d01dce48-70cb-4a9f-8319-12ed4e75073c"), 4255, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d02e67d9-5d17-4fc5-a37f-ad8336715a44"), 4556, 5, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0397ed5-ec9d-41b0-bbf1-9a624e4d7765"), 4430, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d03dfecd-4a58-4744-a61d-e73d1c09b379"), 4518, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d052b5d1-1bd7-495b-9d7c-474ed60658b8"), 4106, 8, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d05af1b9-1248-4066-aa70-45dd3713a851"), 4605, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d05c13f2-1233-4328-aded-659da606f97a"), 4037, 3, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d05e4ce6-7a61-40ff-9965-5e731dbd8dfb"), 4451, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d06f4750-20cc-47db-9af1-a72d15489435"), 4633, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d074a0ec-816e-4403-a632-84869de7c82f"), 4200, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d08c3396-f1d6-412a-8d2b-519c47e3ed30"), 4102, 1, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0a84cd4-06a4-46e9-9c54-351a0f9cadef"), 4656, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0b3fbfb-43db-4c80-b372-c20e43a7fbfe"), 4500, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0cfccd4-a0b6-420f-8331-84680d535ffa"), 4026, 2, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d10ec2f3-7f02-41be-8b59-3b93fe8a9a8c"), 4717, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d112e2ad-9dfa-416a-954a-3ab570fbc3ba"), 4657, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d13c2754-5f24-4d5e-9256-265133031f87"), 4405, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d141e6ab-5466-48f5-b3e7-cf95b94c80aa"), 4115, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d144e75a-50c8-4022-b242-e7bf973b403c"), 4433, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d15e1561-1151-40fc-9a1c-038c22324779"), 4633, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d17b8c49-591c-4442-96f6-d11b8ab21b49"), 4537, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d17c3ff9-96dd-442a-98f8-a38f4b598797"), 4539, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d18e4502-0872-4b31-a930-b0c8983fd5ac"), 4429, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d194a2af-4cf9-438f-9163-0f0bf567aa15"), 4456, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d19906ae-5ba4-40fa-8c41-9279ad29ba28"), 4514, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1a194c4-11e4-4600-a8e5-5017f500d353"), 4035, 6, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1a804d5-d96a-4cc4-a462-80b3a35150af"), 4544, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2241f61-dafe-4679-91c0-83bce1b08d7d"), 4559, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d27e2d5a-fbab-49e1-8334-d7f0b61d9325"), 4603, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d295803d-3acc-4513-8f7d-a1a5d91cc6b7"), 4260, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2b13d42-bcfa-4466-b8c2-d5cdb9565c4c"), 4653, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2c33642-0e81-4db6-8489-a22f723c1abd"), 4318, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2d0df1d-e6a4-4500-a79f-ae784f9de946"), 4250, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2da9d76-74c0-4754-b630-4c3625482821"), 4230, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2f8cc25-191b-48e8-9499-e8e017751479"), 4324, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d30e3efd-8da5-423f-a873-8c550a760a97"), 4251, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d314cf94-b260-4f79-a047-2efe777aeae1"), 4220, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d32882de-85be-415d-aedd-876efe0aee1a"), 4506, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d33732db-1e98-4d0e-889c-aa2f014cead4"), 4438, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d35d0ee1-f3b4-4e41-bb88-7ae88663fcca"), 4245, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d379a132-c6e1-4591-bfbc-ce6dcde400a8"), 4601, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d37f2f6c-655d-44a3-87b3-5aea8caa8142"), 4254, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d392535d-a369-483e-84e3-9a567f86dbeb"), 4421, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3967fc5-aa7e-42de-a0b1-7d90e346d608"), 4274, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3aed990-9734-4c7b-8b55-5813a1faf0f3"), 4543, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3d82bca-0db3-4644-99c5-9a26b6afc1bb"), 4241, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3dbb585-3f02-4961-ad79-c82ed5a202dd"), 4323, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3efcb0b-da19-48f6-aaf9-5943aa37dfc7"), 4500, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3f37355-4443-4543-b209-6dfc7e7d2b84"), 4402, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3fd89b3-586e-4aa1-9b9c-fe82a67f4d00"), 4247, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d42273c7-9969-46df-bc4f-685b330e47b4"), 4444, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d424cf97-b10c-4ca5-a319-0c946d9df187"), 4559, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4483231-2259-4dab-8b12-3d5a3112a3dc"), 4605, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d44a1d31-3a47-4d50-bff6-62708a142845"), 4602, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d44fdd20-be1a-42b1-a70e-456bdf5a6a99"), 4610, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d45114e8-d519-4246-8cec-f17fd21600c3"), 4516, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d47b1392-3fbf-41ef-a5f0-1926268ccb52"), 4631, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4bcf266-7fc1-4ae4-9a7d-b3d34bac4740"), 4856, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4cc3c20-defd-4c58-a984-734dae575aa6"), 4104, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4dc70c3-a089-42ec-9f6e-e930f93b4607"), 4437, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4e59c68-b5d6-4955-ba97-6d6f514fa221"), 4654, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4f0a4d2-b737-4eaf-a1ec-96343d4e2987"), 4025, 8, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d52bea0e-b648-4916-a19e-be5e497284f2"), 4317, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d53f6d72-112c-4e17-866c-9d5d68c286d4"), 4615, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5431f09-69b3-47b4-aeb9-53668357ee63"), 4852, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d547dfde-9f44-49ef-8b90-17fbec03b21e"), 4562, 6, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5653861-b934-4fe4-b08e-adc31dc8a5ed"), 4105, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d568cd7e-7356-4eff-bb54-75a3a36391ef"), 4615, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5695807-9988-4fa5-bdf5-a1999e3101b2"), 4446, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d586c3ec-9f3b-48a6-8213-d84d6e342db1"), 4716, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5968d77-fdcf-4714-a877-cb00873fe1ad"), 4464, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d59f54a0-9eca-4f24-87e0-6d48ff233465"), 4536, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5bd608f-e41a-4996-a335-db27a4fd4fb0"), 4251, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5cd918c-1e6f-42bb-90d1-86bddeb47f53"), 4705, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5d0507b-a727-4862-97ad-ea235a7d11e3"), 4561, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5d41ffe-9c97-46a5-9a60-4daa83e574a3"), 4101, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5decc37-8964-4567-a4e1-7170bf879c34"), 4221, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5ed97c1-b399-4c6f-be40-e35433df7463"), 4209, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d60e1b75-3f2d-41d4-bf76-7b6473df0c4e"), 4262, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6124fb2-3472-4c1c-8bbe-5c872b7f949b"), 4855, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6291f8b-e248-4166-9e07-e01e2d3c9e82"), 4529, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d62e1348-70a0-40b3-838a-04d99e54b438"), 4229, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6400824-184b-4c77-8312-8c41c786ca1c"), 4237, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6615b65-546d-4573-8f51-9b3eaf6973ea"), 4440, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6817d22-c819-4323-bc4f-5a31d530ddc8"), 4713, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6c3a87d-b4d4-4b2a-8f73-3d567e51dbd1"), 4255, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6ce68e8-746f-479c-9c84-fbcd1e55829f"), 4601, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6e917f4-4579-4c00-ab06-615e874cbcfc"), 4028, 4, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6ea09de-e453-44de-b6a5-425483eaca55"), 4525, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6ffa62c-c563-447d-90b9-e528f9c7d542"), 4031, 7, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d70b8add-3563-4cc5-8f2b-dab66bb74a5f"), 4502, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d70bfad5-32e6-428c-8613-025e0e664dc1"), 4229, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d70cc66b-9b80-4e86-b532-7d7414505156"), 4606, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d71a159e-b750-4fee-b589-6cf0e0b12e2b"), 4108, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7270b56-cba6-4d35-8ce7-aa8dd37b7f8d"), 4426, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d72773b1-f8cb-4d3a-b04f-1d64bf28d5fe"), 4206, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d74bfe08-d408-4300-82bf-8ff942b63bcb"), 4265, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d765e9eb-1ce5-4788-a058-172547076b01"), 4523, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d78fcf43-21da-4be0-96cd-06231d571979"), 4629, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7944d51-d080-4394-af20-188f3502019c"), 4015, 4, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d79b99cf-f676-4f2e-8fbe-b1af87c4cc89"), 4625, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7ac09d3-ec04-4342-970c-ba8d7b964750"), 4515, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7d5774f-0af7-4ae9-8ef5-973156041eaf"), 4510, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7f52cb0-ab54-4ef4-854d-fa92d7c943ee"), 4604, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d80ee644-9c18-4415-9fa8-86bb3cc051c6"), 4555, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8279015-bc00-4832-a15a-b63d322cb436"), 4202, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d84369a6-c4af-4abd-bc6b-d50d52fe7e1b"), 4312, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d84a7278-dbc5-4e21-b503-469ce0da46e5"), 4800, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d87703bb-af3b-467e-87d7-c8166bb5cb41"), 4463, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8879e78-c6be-4668-bcc7-ece9fc6f0b78"), 4315, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8a5360c-8428-4f9d-b48e-127679e8eda4"), 4617, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8a7674e-75d8-425f-9b95-f1124e0fc23a"), 4204, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ae440a-3f83-40a8-b6a4-0847c1a58e8f"), 4009, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8b51b88-6d20-446e-bfd3-3ae7d3477d31"), 4214, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ce451d-2811-4ffe-8112-f05eb50b3f9c"), 4616, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8df2b0e-8a69-4bce-b361-a246bcabf00f"), 4271, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8e0a081-9dfc-4d19-98a4-b96b9477ba7d"), 4014, 2, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ec7224-6bfb-40f0-b1f4-2ff487bf6b38"), 4657, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8f328a2-7dc2-4579-bdf6-03221bb8d240"), 4551, 1, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d94ea2c4-ae80-4621-8da2-0acb30703fbe"), 4421, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d96c56e2-030a-4113-8450-3052aba70b00"), 4420, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d972f206-6a65-4b53-85b8-86652300eaba"), 4552, 9, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d979843a-ac86-4962-907f-11d00c0cc193"), 4262, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d983372e-6679-495d-9893-d32dca202fcd"), 4415, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d98a3666-ebd0-4f54-ae1c-ebab5bd3b9ab"), 4553, 8, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d98ec72e-6d8f-4bce-85a1-76ecd5caea40"), 4010, 5, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9a21fa9-d538-4326-9b72-6b45ea5becfd"), 4030, 6, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9ab05fd-6470-40dd-9cf5-c28b6b928c5b"), 4436, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9ab69a5-32fb-482f-b638-3a6f78a8ddb5"), 4434, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9acdfa0-98aa-4a70-8d3e-2d07b071f28c"), 4229, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9c9a4a9-f012-4f0d-8c3d-106472dfb05f"), 4417, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9cb670e-7089-486b-bc45-9cc65bd9329d"), 4310, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9d687ca-aa5d-4526-bdbd-c4a49381ee53"), 4308, 3, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da2618b4-1c45-4f21-b96c-2ff291f5ab19"), 4611, 8, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da299811-f98d-4c52-924e-16ab09af3836"), 4600, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da2d0fab-b733-4673-89bc-1e3efa5f59f9"), 4433, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da3702e6-5ff3-4667-a691-83f12d2382e4"), 4620, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da377e97-e763-4121-817c-f5610973522a"), 4462, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da40f97f-e953-4685-a8c5-26b9221a4721"), 4618, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da426f88-c244-48db-b977-25dbaaf4de31"), 4444, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da5de6f5-f756-4be8-b499-c315886508a7"), 4314, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da62b543-cc18-462a-b8ab-b26a7edee9b5"), 4247, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da639399-5d5b-4ec8-bc70-60f7587f1a65"), 4301, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da73466f-c407-42ad-9d2f-2c7d2ba26f0f"), 4103, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da99a49a-de0a-41ec-9423-e5029ef8449b"), 4441, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("daa1ee76-161a-4f41-830b-b00442b2477c"), 4856, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("daeb02d7-40c1-4b8e-98e8-014d13ab543c"), 4702, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("daf06d80-2779-42ce-85f5-c5093da67013"), 4402, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db14e1f6-9846-417a-a179-d363dc5be554"), 4806, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db18992e-a0ee-43dd-8c33-5e1bc3dfe7b2"), 4269, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db28b938-c1b5-4691-a4f4-cf9163feb63c"), 4016, 9, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db63a778-fa8f-4b53-ab19-1ec9c0b41782"), 4450, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db6f7ca0-beec-4905-a9e2-7146740b53cc"), 4661, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbac02fc-e64f-4ea2-ab63-15f805bd1aa3"), 4441, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbcc1cbd-694f-460c-9cba-6463743ac293"), 4438, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbd02fd3-dc2a-4039-a91b-c7291a730748"), 4219, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbd28300-faa7-44ab-9215-7c99bfd31c43"), 4319, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbd55c69-6bbc-4e49-b638-a6a6dd9c85c1"), 4628, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc04d658-8253-4e74-b3bd-e15d23ad8a86"), 4516, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc225524-83cb-496a-8e51-ebc8cab28a22"), 4319, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc38c299-e399-4d78-8887-aebd3bb8e0de"), 4431, 7, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc44df37-b11c-4c99-bd29-f58cf499eb4b"), 4718, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc6a1f7a-5e66-4247-85b8-4e5fa01e26dd"), 4110, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc70bca6-4071-4bba-ad32-c683e771b35d"), 4506, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc7663a2-b3ac-4e94-9859-1f00ed1ce6ca"), 4654, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc89c9e3-f178-49a8-857f-09b5c5bf4b20"), 4540, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dccd024b-9c08-4993-89c1-4d5d12a4fed9"), 4636, 1, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dce568f5-5f70-432c-99f5-ed07713dc7e5"), 4264, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcea792e-f41a-4aa6-a5d5-977443a4c06b"), 4235, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcf0f9c2-1376-4171-8a57-9135573ffe31"), 4504, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcf4be77-482e-4f4b-aafa-7bde259c9f2e"), 4250, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcf68f56-bf2c-4dc4-8f1c-d6cef0a66fcb"), 4211, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd010cf2-90f5-4325-8709-04b3ee1b1dd4"), 4855, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd022ab8-d92d-4862-a952-e05b043ff436"), 4103, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd028a58-7e8b-4b1e-bb6d-36b1358bd345"), 4536, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd0f647a-760f-4f6d-a497-efdc1e732a52"), 4103, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd10045c-bdb7-455e-be3d-3f69c7ddd4b8"), 4115, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd10d553-35d6-426d-88d9-acf84bf8509d"), 4022, 10, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd248b58-4780-40f6-98ad-0873e5fc010f"), 4704, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd2e2d7c-5c3f-4bfe-9fe7-74c36954531a"), 4439, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd3512ce-f7d7-45d3-995e-654cb541af39"), 4254, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd3c1046-bbf4-4955-a11e-9d3875d33a21"), 4412, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd423d22-4e79-40ba-b851-ed1e3ac7c702"), 4274, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd4ca438-0a0e-40db-862d-dd179acdaf0c"), 4704, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd6c0d6c-433d-4dd5-88a6-ac84712b7729"), 4318, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd7c8de2-9d76-4f2b-9658-f801ce8b99ae"), 4111, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd820b3d-cd90-4347-b5d4-262c3056961d"), 4809, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd9ebe18-be05-4a2c-8504-d8228598145c"), 4004, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd9f5b92-c4a1-482c-bcaf-4f3e7dd77742"), 4659, 3, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddace35d-a027-4db1-a69b-6d58037a2580"), 4262, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddb787d8-3adc-4b6f-86f0-7ca208918ab0"), 4805, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddc85ed3-05ed-4df5-8517-92f1c5a4b9b4"), 4715, 2, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddd936e5-30a8-41aa-96dd-cab1dc6b0caa"), 4708, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddf77d65-578f-49c0-b992-be50b7bc0430"), 4029, 1, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de2efe80-7072-4f61-b5fc-11312a580e86"), 4251, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de5e09f6-b689-495a-a211-bf51d06c4878"), 4710, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de7ae1d1-9350-4bcc-a1c4-733f5072fc90"), 4034, 10, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de81eb9a-f669-4aae-81e5-0eb846bbd85c"), 4624, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de92075b-a068-4ad3-b195-a4cd41df126d"), 4509, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de9ca803-d649-442f-b262-5296dbb886e5"), 4703, 2, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de9dc493-23c0-42f6-b4a8-b6bb3f5aa1a5"), 4532, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ded43e7d-5c25-4a04-a9a1-8091960b30fa"), 4244, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dee80725-3eaa-4672-8024-341db7cbdf98"), 4426, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("def1a72c-196a-4424-9e97-893525264ca7"), 4620, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("def78806-15bb-46aa-a8b5-1268cd668f4f"), 4461, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("def7ae14-b289-46ff-9a37-2b28c5ab1a78"), 4636, 6, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("deff7639-e491-4f2c-9603-23593693d2ee"), 4218, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df05a5ae-93d8-4f4c-a443-675103a54868"), 4318, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df0898c9-121d-47eb-9f7b-909296fb501a"), 4810, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df177aeb-35c4-44e6-8d2f-77f89ed9772a"), 4319, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df1eb820-254a-4f4c-911b-ae641fea262d"), 4621, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df303e4b-fc3e-4bfe-8c9b-9b19dc9f2061"), 4242, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df3644fa-3064-4616-bdca-3c5fbb81085d"), 4852, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df41fadf-2b05-48dc-9155-3031f91d3684"), 4239, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df4f8089-1116-4a2c-bcfb-c2ec88dc2c67"), 4246, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df67db1c-db79-4168-8db9-19e77a0396c2"), 4709, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df78d71a-4b4a-4fe3-8da6-9778a0636324"), 4557, 9, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df7efc24-1def-400e-aca5-8ea25044e41b"), 4503, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df9a2527-90a7-4838-b4c6-e91f3388fb1f"), 4711, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfb20cbe-89da-47fd-bdc9-19467600c176"), 4244, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfc4e1ee-3fee-4e2f-a434-1d3796a6d82f"), 4630, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfdc452f-041f-49f6-adb1-2982171822a7"), 4523, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfe23a5d-15c7-4fa4-b864-6b2b9e4aed65"), 4464, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfe78a4e-df74-4d99-81ed-61b6e407de61"), 4444, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfed7ee7-aad4-4a1b-922b-60033f5df320"), 4633, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e018612a-e901-45c4-b780-a65e181857ce"), 4560, 3, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0270e9e-3062-447f-b49d-c6da9efe2fac"), 4009, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e033a8c6-8233-4355-95bf-e4c81415aecb"), 4245, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e03ffd7e-84ac-4fc1-abf0-5d8396216a54"), 4001, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e07cf494-322f-48cb-9351-b101cc25aca4"), 4268, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e07fab12-77d0-4127-9bb6-b9fe3104e5ae"), 4534, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0853f63-8dfc-44ac-88a5-233ae457bdac"), 4707, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0a338eb-85a5-40a0-812b-1758ca74141a"), 4205, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0b5d318-fa32-42ef-9d23-58ba5666f861"), 4004, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0ebd545-5687-4f50-a2ce-5f1900c3c8ae"), 4209, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0f16511-1c14-4880-b5ec-2047c8f1a5e9"), 4710, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0f70eca-353d-41fe-9fc5-ee4e0b17c6d0"), 4438, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0facaa2-a5fa-4795-932d-49f35a6dd279"), 4320, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1046927-9fb6-4464-a981-33bca8c1ae0e"), 4719, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1194ad3-21f0-4ece-b788-e0b39df1ef51"), 4435, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e11f43cf-09e9-4149-88d3-2b9e3f3d156a"), 4614, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e122e6ce-06c7-4b4b-9fa1-f1a65eeec99e"), 4533, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e125e705-e320-4843-96b2-665546809abb"), 4656, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e12778aa-cb0e-4d2a-9685-a12a0dede83e"), 4565, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e13fb58f-bc81-4b88-865d-8a90f167155c"), 4424, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e14b19cb-bbaf-46b9-a139-abe744c867c4"), 4518, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1646d2c-e04f-4d23-bb7a-b9c86f8f25f8"), 4542, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e16b5e80-9a3d-41de-9cbc-0f99c8fe38c6"), 4544, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e19719e4-765c-4ec8-a995-4efa5f24c7d6"), 4419, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1aa270b-ebb3-4f48-9e93-1e7b906266d9"), 4541, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1af3605-45b3-4ce9-8618-2c4954db2097"), 4633, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1ce7fae-4bc9-4a3d-aeb2-e67bce249495"), 4324, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1da2c87-e868-4f88-bf48-a79bbb159ad8"), 4313, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1e1ea47-94b7-4a69-a78a-cf3b0c0fa29f"), 4546, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1ed606e-35d4-4462-8856-30887d15eb0a"), 4408, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2009998-c3b7-45ea-bdb9-267e09a9f7d0"), 4617, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e206f6b9-4d14-4b17-994c-ff953c9c78b7"), 4713, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2079937-3cf9-40a3-a530-1d8fde308ae2"), 4256, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2300a65-cff8-43c6-b68e-2b6e5936079e"), 4021, 4, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e23657ab-8186-42dc-aea6-b29e75a2dc6b"), 4514, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e245f853-8d0f-4e4f-94e3-e0e98d404fa0"), 4553, 2, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e24a3175-ec71-45d9-bacd-100a03f6d9f6"), 4111, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2893c2f-5ad6-48c5-abbb-10e7dfe2ca13"), 4453, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e293a588-4eac-4032-aee4-05386bd1a389"), 4429, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2a932e4-dd01-41b7-917a-0732a931bd9e"), 4428, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2b7d5c3-56a6-41c5-b070-fb4bf59573e0"), 4458, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2cc0821-a960-4529-bcc4-b4566536ab4a"), 4266, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2d509a1-98bc-4fd3-9d01-ad290e2fbdd7"), 4115, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2e515ba-52da-4f39-bb43-660481c2c1f8"), 4272, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2eb6d56-1a4b-4d4f-8f79-0eb63f43f093"), 4400, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e32d76ac-016a-4a0a-b150-6534f8122024"), 4804, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e32f6a1d-995e-4e0b-81dd-97f516051b34"), 4714, 8, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e330ffc8-0394-4941-aeb7-59e65a2d0f99"), 4025, 7, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3354d87-eca4-4f73-b480-19f445f3a973"), 4213, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e338953d-6410-43da-b9e0-5f415184dcea"), 4705, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e360420f-8fa1-4e89-bcc3-c77f6b482a9f"), 4232, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3724731-a30d-4958-8a8e-a696347c1b24"), 4536, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e373677c-526a-4e03-b579-5dc688b88171"), 4018, 10, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3889fb2-a1c9-4856-aa25-b4868adc7b5b"), 4441, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e39f154c-0cc3-4629-8515-4514ef838914"), 4222, 3, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3bec5d8-e03a-4ebf-928b-987d499bb8a2"), 4805, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3c53147-d8e2-49a5-b6ee-d9e2751ead50"), 4540, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3d66a75-74d0-416d-ac79-427747d6d9ba"), 4723, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3e29623-2dda-483a-8d26-7543ad019b02"), 4426, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3f0cd5c-03f3-4acd-9ed4-a94215a3e9b5"), 4500, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3f4d773-be70-4072-b708-43b962797797"), 4632, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e43fb4d2-09df-4397-81ba-04d989c1b3df"), 4204, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4491ee4-d387-49aa-8d72-1eec66c85979"), 4249, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e46d38d5-771c-4369-8e97-fe79cfc5fd0f"), 4016, 8, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e496a605-5708-4245-bd53-f3c09377ba49"), 4309, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4a04ac6-5232-47fd-b748-a09badf13316"), 4227, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4a5fbeb-0bef-48a1-83e1-c4af141a1f74"), 4450, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4b73f1d-de4c-4cb5-a243-69fd37b897a3"), 4406, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4be3778-68ba-4442-9ee4-c8988bade5a6"), 4605, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4efd33f-4427-46f6-9751-3dcf670b82dd"), 4601, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4f6f981-283f-44d0-b426-20fe74cab61b"), 4620, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5017b29-2d51-4b6d-9eb9-128f0b6ae417"), 4438, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5373070-679d-4a7d-89ff-043dda7f0787"), 4800, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e537df6e-a98e-4536-958b-6702c0cde96b"), 4639, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e53e4cd9-0582-4c16-9d0c-77d83758c52b"), 4522, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e541a0b6-ba0e-4722-ac2d-53a5bbd169b7"), 4552, 5, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e543af53-a88f-45da-843d-b4b49cf4f455"), 4203, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5463a47-141a-46ac-9d8b-7a72f3a3e520"), 4316, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e55b093b-2568-48e6-b9bb-6706cd9869e6"), 4017, 3, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e560d3ab-f9eb-469b-925e-c5d73bdca084"), 4228, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5785fd8-6de5-429e-a5bb-04a9c87619d5"), 4317, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5984519-0889-4899-aa21-1d8bb1b055b1"), 4233, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5a1c5b9-452d-4b91-bd6a-1a1479f106b4"), 4801, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5c45365-2a42-430c-9884-c5bd1b5cfdcb"), 4404, 8, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5d883ca-5e38-415a-b106-7b44c86491c1"), 4543, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5eb3d42-5f61-44f3-9c83-a3b2a7ae36ef"), 4252, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5f9f947-9cb0-410a-9260-cdbae4726ba5"), 4418, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e60afa2e-b4da-489e-bc4e-7f772f0e7c17"), 4005, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e61ced3f-e3dd-4ead-940e-6f9813badb09"), 4856, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e62157c6-c965-4241-8c6d-e9b55ebcfa64"), 4502, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e62b949c-34b8-4766-badf-048ec5d84b2c"), 4718, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e669dd0b-483a-4256-aa7d-d137609c8608"), 4239, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e66ccf04-2b07-4e91-a637-e3211d71acfd"), 4713, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e66e9eef-e241-4a4c-97e4-fa804d2a051e"), 4264, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e67cd5d3-21df-4abd-823d-86e3f72d26bd"), 4314, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e680fc8a-c42a-4bd1-a5f3-fb33ad14f580"), 4227, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e696b9fb-f03c-4967-9043-142058c9e590"), 4011, 4, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e69a4d93-d08e-4ce1-b025-50a0fb3d4496"), 4312, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6bc7780-0ff7-4be4-9bad-2d89515bda97"), 4007, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6c3ffc4-50cb-4e1d-b285-7a98a61928a2"), 4274, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6d79c6f-ceb3-4345-967a-143148eb859e"), 4804, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6de48e0-85fe-4824-9095-44f89072e720"), 4200, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6e537cc-043f-4372-bd1b-7dc913178121"), 4462, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6f82813-6764-4159-8831-61bd3767e04b"), 4530, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e705342f-fe1d-4131-ad04-771c7d2da77c"), 4238, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7280a3b-6fcf-42f5-8d1b-969f0f3d133d"), 4650, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7367ad7-857c-4fb3-af3d-cbf40936fe23"), 4629, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e736eb75-3174-4958-81ae-985b9c1ead95"), 4252, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e73e753b-f606-41fc-8e9c-8a2c8f0d6527"), 4417, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e77a10ef-3c79-43ae-a818-cd647efcd8d8"), 4237, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e78c6269-ef72-4a22-878e-5751f984771e"), 4013, 1, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7b1b3d4-835a-4f86-b554-304ad69d7bb5"), 4220, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7cf6857-6a0b-4521-a2bd-cea7bcf8a29b"), 4255, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7eafbfe-691f-465c-807e-e095407f91f7"), 4305, 2, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7ee2bd3-9f6e-40bf-9bb7-dde8d5b657eb"), 4410, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7fedf73-12e1-436b-b17b-1e38b042d222"), 4303, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7ff64f3-6c8e-4394-a027-ab973a503625"), 4458, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8033b73-1c71-4cd1-a543-b264b38340bb"), 4107, 5, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e817de72-0276-49b4-8eba-c52f013dc75a"), 4446, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e822adff-3b37-4a96-a6f3-00bb245e38a8"), 4601, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8379998-f465-46f8-9dec-9751a5c7fa9c"), 4101, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e846a923-66bc-4061-9866-c43dc00c48e9"), 4603, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e858e2b0-6a7c-4368-9991-8302eeec0d54"), 4432, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e85e6dce-530a-4b7d-84e3-8944981a3c7f"), 4245, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e86e3768-17e9-4cac-863e-5d3ca575cc34"), 4662, 9, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e874f579-4a6e-4e2d-97bc-31b53c3672dd"), 4620, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e87554df-894e-46d8-b720-31f4571c4a62"), 4305, 4, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8a9ac47-f4a3-4062-8d9f-303954836cbe"), 4262, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8f0d870-477a-494e-9747-37800a96743c"), 4428, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8fd42fa-efb5-4e1f-9e64-9511415f27e1"), 4458, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e90e5aa1-2801-439d-b01f-f9565f0b5d36"), 4253, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e911a0da-8e45-4e60-980f-3a44d21f7840"), 4526, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e91b6e50-d3e7-4cfa-ad30-2ee72043e599"), 4017, 2, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e91fab89-076e-4c54-825d-698cfebb9239"), 4316, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9234d1d-b63c-4283-8487-06bc8138c07a"), 4540, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9238a96-dc10-4573-b894-53f765624e09"), 4037, 6, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e935f10f-2d07-4c76-ace1-5faf9277481d"), 4102, 3, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e941a3ba-da05-4a93-8ea3-3ef98ea49459"), 4534, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e94cbd12-9c7d-427d-8d29-5b810594a4d5"), 4531, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e960651b-b567-4f41-b7f3-ff7aa07933e2"), 4624, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e96eb3c8-5d94-4099-aa17-a29eaad034ba"), 4517, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e97dea9d-40c2-4980-aa9c-35336d1a62cd"), 4605, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e985b75e-5a96-48c4-b72d-b2d1aba12121"), 4251, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9a4db9e-53d0-4281-a5d1-7a9d407147ab"), 4506, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9daab28-8f53-434f-8f9b-a78d4a1453d0"), 4311, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9dd7e13-122c-42aa-b71c-e90a5b9ea9fb"), 4400, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea005ae2-3344-4d0e-a367-16a2ede0df3e"), 4434, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea11eca6-6fee-4d31-aad4-59231a0cc770"), 4851, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea3ff3ed-ea04-4fa8-842e-4c2db78a622b"), 4653, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea5c8217-5500-4f93-b68e-b6ede269d3b2"), 4104, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea649b5e-b958-494e-bfdd-61de1d651c54"), 4523, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea6e0f9c-1a51-41bd-8386-95cfac9a2143"), 4440, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea7759f6-a67f-4145-95ec-2465e0b21b8a"), 4855, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea8e71f7-0b69-411a-a0f5-ba1d39adac1a"), 4302, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea8eb451-01d9-4070-af2d-5128f50b4ac8"), 4851, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea926051-cf66-4e1b-be7d-468833b1872c"), 4641, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea939ec6-1e7e-462c-9271-25cf90f473a5"), 4213, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea969e0c-5549-4859-88a3-a9298d5fc9d0"), 4809, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaa1d875-9808-4a72-a4f5-3e9ac90215ce"), 4409, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eab1b514-5b22-41e7-9d07-04cea0624cb2"), 4008, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eabb6a95-8f84-4de5-bc57-a00e8d56803f"), 4722, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eabe9cda-58a6-4aef-aad9-22bf08637b9e"), 4562, 5, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eacedda5-e3c9-4ce1-9018-c0a41d495d60"), 4717, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eae79abf-5579-46ef-aab1-9ab3a67850c3"), 4102, 9, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaeab7e3-00d2-4a36-af9b-c563e8d3478f"), 4853, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaf0a577-e000-4a10-bab6-c7d58897865f"), 4610, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eafcc753-e6a5-4673-a124-40e721fa8e04"), 4032, 10, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb283844-fd40-48fc-a5aa-59f7e80b0286"), 4244, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb35b211-a14b-4cbd-ab27-1cc5f5954b85"), 4031, 10, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb363dd1-8650-4287-afab-babf8ae409cd"), 4313, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb534225-5ab2-4e1a-837d-c51be978c23a"), 4232, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb5c949e-294c-4229-a84a-739a142470ac"), 4033, 2, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb63ba56-e1fd-4bc3-b0d0-dd962d84e7d6"), 4424, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb760ba2-7a57-4b71-8b85-8fa0aa78765d"), 4455, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb76627e-2fef-485e-bba4-63272f36a722"), 4529, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb82827a-b9c1-4b85-9abb-80162633e4d0"), 4661, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb8929f8-c0b5-4ba6-86b8-c123383ff188"), 4445, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb94c958-d2f8-4604-a36a-58f11d551b6e"), 4242, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebc2ecb4-dcc6-4f69-9ff5-fad1d7811624"), 4002, 6, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebca8d97-ceff-4020-9a05-40af9593cfd7"), 4564, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebcdc385-8b47-4b50-9787-c6c98afdfa36"), 4627, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebcf46e1-79a9-4c1a-84d9-ebfbd3c58e72"), 4246, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebefe0b7-0c83-4b07-923f-95a21177b3a8"), 4441, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec0366af-6ec9-4878-b71c-805af439a0de"), 4633, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec580466-bff1-4bf3-9742-55e34a8f82d9"), 4255, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec6990ed-e0f1-414f-a646-8bd7cfd1db89"), 4445, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec6ac391-68a1-480b-af3a-d51b29e6a8ba"), 4607, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec9276d9-aa5c-4825-bc70-ff02169e10a8"), 4804, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec9776a6-6b8c-442f-bd0d-35e0d3e8228e"), 4659, 9, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eca17744-13b9-4219-ba76-22db1107d075"), 4413, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecba498f-eafa-47fb-b145-1248caa7f636"), 4623, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecc0c0ee-e0e5-426d-8618-9a8d9303f37a"), 4522, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eccc8afe-dd87-45d0-8bd5-9334befecb74"), 4417, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecf8ecf6-d6dd-4e14-84d5-bb60c3ad23ff"), 4247, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecfb634a-ce1b-44b3-9678-59948ba9ca6e"), 4627, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed03ea33-b16b-49a2-9148-612c65ade298"), 4304, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed15fa73-5bc8-4a02-a03f-a1cc28f3a1b2"), 4233, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed2deed6-2a5a-4b40-b02b-e5de40f8f73d"), 4602, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed2f9d32-05d1-416f-97d4-3b9df2e54c14"), 4856, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed38e526-b45b-487a-a50a-04a5f33bc30f"), 4249, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed39f3bb-8b13-49f6-a25a-0ffc8bd73576"), 4235, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed3c49e8-5f22-48c0-b0be-6e3fde2b4f36"), 4263, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed3e594d-020a-443f-a9d5-30818139f6ac"), 4628, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed47ffaa-83a9-4072-9ead-396a8b211120"), 4266, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed5fea6c-9119-4128-b9d7-75c8d4bff284"), 4407, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed74ecda-2be2-4632-9a1f-1d1855423aba"), 4632, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edd4414a-d68e-4f44-b590-ea6fd6eeae4a"), 4606, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edeac90b-663e-4ff8-acfd-3c3dccc2de1e"), 4714, 2, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edeafd30-a212-4e01-8724-247f8b3bdacd"), 4431, 2, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edf46a38-343e-45e7-98bb-4d71c363c97a"), 4547, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee09d8c9-ffa1-45b3-bf11-99335a411299"), 4222, 4, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee270f8a-5c5e-4009-94b8-9ef9f50f662a"), 4628, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee5e3f8a-5879-4457-94d2-8c3134631de8"), 4808, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee8c648b-8391-4269-85d2-33767ca73718"), 4803, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee92fce6-c3e7-402b-af82-2ec8fb9ba19c"), 4246, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eeaad9e6-ec7a-4235-b8db-320374f347c7"), 4103, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eeb033f6-df2c-4126-b51d-b4dfe9934d0a"), 4560, 4, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eec0235a-24a0-496e-9822-6cb9afe20163"), 4203, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eed5d838-ab27-49c0-a229-1fcf72a72495"), 4459, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eee0eeff-4456-4035-898c-e92270fc700a"), 4027, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eee731e3-4303-4bcc-97e6-7379a79502c7"), 4602, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eef01b4a-05bf-4bb7-8264-6dd90613e943"), 4501, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eef12ecc-3dea-47ce-87d6-b53034c3e804"), 4018, 2, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef19de41-2ff3-42f0-a64f-b40265863ae9"), 4308, 2, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef1dfd6d-91da-465b-b4fe-d2b219bd45f1"), 4714, 7, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef249a41-b76c-4dd5-ab69-b8168fcf5e3e"), 4416, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef439504-6732-4f69-ba5a-a1d81a003295"), 4440, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef46bd99-11b5-4308-82c3-b22c1479ee17"), 4255, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef5bcd29-9bc2-413e-b333-eeabd14396d1"), 4303, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef6004cb-27e0-4236-accd-0a59615b40b3"), 4401, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef69485e-eb7b-4609-8e58-ca8f575d2777"), 4114, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef6cd13a-7a01-416f-96af-9ff34c2091ed"), 4108, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef7f5551-1a7c-4b54-a12d-4920b312bbb0"), 4634, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef8ab206-3811-499b-abed-bac92ab37f4f"), 4402, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef9ce58b-9028-44e8-8bfa-b7623ffe4dea"), 4028, 8, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efae1e52-207a-4841-ba3a-232d8cf2168c"), 4257, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efb2748a-256c-46ab-991f-2e6bf1d9e744"), 4517, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efdb6f3d-0cc2-4be5-adfd-c929e6e4e901"), 4530, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efe07a0a-a39a-4fd0-ac45-e7ccd7a7333d"), 4018, 8, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efe7b6e2-58fa-4520-b498-472d27d48a05"), 4529, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efe87b94-ec82-4a26-b646-65d2646c40bc"), 4215, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efeee7b8-504b-4be0-b7e5-696e061305c1"), 4026, 4, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f005cb5e-51c3-48ae-adc7-440419d939b5"), 4248, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f00fd189-7a01-4bb5-8a1d-ad7a72871737"), 4018, 9, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0167e10-0712-48c7-9af9-bfefd8314455"), 4324, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f01ec8af-9730-4c39-828c-2ce4dd2806f6"), 4269, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f022c191-99d4-4f39-92f6-bd52d74f7e3c"), 4316, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0246123-cada-4c4e-a1da-3a63b1dceb14"), 4660, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f03ca2db-546f-4f2b-8237-43137a7134c7"), 4805, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f04a959f-bd5e-43fc-b6e2-184287e4c42b"), 4208, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0569e1b-a60e-422e-a045-e44cf3fe78c9"), 4563, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f05fe445-5038-42be-b90c-5f97050dcd9a"), 4216, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0691f8a-654b-45a5-8193-fbf9c97b187e"), 4623, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f07a9ed4-04ce-436b-bf6c-de2c3f28065f"), 4501, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f07e17c5-088e-4896-94d0-9d6714069614"), 4440, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f07f2e84-2bd5-4871-aab9-75d7a7637d38"), 4603, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0898d09-eff9-426a-a602-26dfc245acc1"), 4562, 2, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f08b7706-8361-42ee-a63e-435fdc9297c4"), 4625, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f08ecadb-ec45-44a7-9c34-0b6f86f1c620"), 4447, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0aa73a8-adb9-431b-8493-3f68b6c7ee29"), 4422, 10, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0b5e14c-49af-4710-b9e2-26cf599a49e8"), 4617, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0c93386-150e-4da6-8377-5bf97e0cb7ab"), 4033, 8, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0f66fc5-7425-413f-8125-937d1cd2b163"), 4020, 4, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f106d1b8-3280-4ada-8f0d-8273a28a3b23"), 4430, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f10a93a4-1a64-4fd5-96ad-6b8ef101ae30"), 4323, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f11728c3-2c33-4d79-b86d-c839a1b13441"), 4810, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1188f5d-1a05-4b86-9c11-ca08205c3fdc"), 4034, 4, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f13c4aa8-b2e1-4ad5-8d97-9ca0fe2c176a"), 4617, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f14aead1-db47-4f58-8004-189add40023f"), 4463, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f14f339d-4dc0-4c7a-b81d-8e858c8cb6dc"), 4247, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f15bed27-6567-4d83-b92b-a7ff08889d18"), 4012, 4, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1669ef5-dd3d-4fcb-9595-ab2aaf3a19d9"), 4303, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1803434-94a5-40ed-84db-04fc2bfe99c7"), 4456, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f19370af-5f1b-432a-8827-88be88061763"), 4007, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1bc7bb8-ef2f-4027-b498-1c5fe0221729"), 4300, 6, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1df0ed2-882e-481b-8936-755df8f99d19"), 4322, 10, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1ec0091-bdbe-41bf-a9a6-828781912803"), 4635, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1f28388-1983-48e2-9b33-273922ff1b4e"), 4214, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f20c458a-2cdb-4d5a-96fa-0b19c983e17a"), 4029, 8, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f21036ab-ae2a-4f57-a91f-6e12f7c21da8"), 4112, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f22c6286-4b14-4038-b5c7-0a8a19e4657b"), 4637, 4, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f23fc905-3f89-4aee-8ace-5ee333eb59f6"), 4405, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f24b4b7c-0938-4dab-aa75-76b1a82a1639"), 4247, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2549d5b-819f-4601-83f8-056f48361e95"), 4712, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2559758-2830-43e6-82b5-2d73000f9f31"), 4605, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f281934b-6189-47bd-a3ba-6ff93fa969d6"), 4663, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2a08a81-0b8e-4f20-b479-30dbdc53ef35"), 4430, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2a86069-6c1a-402e-bf7a-8e7c078aef78"), 4625, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2b6bb9e-21a6-49f4-acab-df0d3b936cdc"), 4006, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2b8a408-1bb3-4215-88a5-c2f8cd67b280"), 4201, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2c88aea-4498-4da6-acf4-09cc5e442fe6"), 4207, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2ca4c64-cd51-4f45-92c5-3e551c278300"), 4217, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2cbba90-973c-4087-92d7-d2bdc18dc17d"), 4000, 4, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2cf0b28-684f-41f4-a2ff-c4883f9bb534"), 4564, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2ddc911-4276-4056-baa6-477170a00843"), 4456, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2eae493-58e5-4480-86bd-9717f4d863f5"), 4268, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2f2b5ba-51f0-4e20-80c4-88c4498f6821"), 4612, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2fe8641-0f06-4962-8d11-0b556c8e5aab"), 4447, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f32110ef-6d4c-47d8-bc7f-4bf6144510de"), 4807, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3267511-dddc-4fc2-8c6f-b28d84e3e486"), 4253, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f327fa18-aee4-44a3-8d87-3c0fe93b07d5"), 4603, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f34d2f6f-d5c0-4743-b9ea-2357d39bb628"), 4004, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f36ebe3a-2ee2-4bf3-b09d-c14c15741c3e"), 4606, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f386d6e5-4ece-4cf8-b98b-f6f7ffd4c157"), 4447, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f39680bb-2e4b-401e-9555-9d1da384446a"), 4807, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f39979da-517e-4404-afcc-ca0d6648d905"), 4014, 7, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f39cb3c9-d2a8-4226-896f-d8021b598294"), 4302, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3b20f0d-1134-45f0-a4b4-2168235618be"), 4422, 6, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3e6c9a9-2cd2-4934-a571-4903233672cb"), 4537, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3f56593-f8af-4335-8498-e5bc27363240"), 4209, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f40d76d1-426f-456d-ba63-55fc597ad1fd"), 4508, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f414d934-2571-4ff9-b63c-86d8ddf1c150"), 4438, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4165f8d-eb4b-406f-8093-e0b7b3e255bf"), 4561, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f418ffc4-6aec-41ee-99de-2020ec6f9fec"), 4204, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f41c8009-8f96-4b51-9ab0-2b3df5b1074c"), 4505, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4220945-511a-480e-a1f0-4f70ce096ac7"), 4656, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4265a3a-48b5-43fd-96aa-0ec8696a5b4b"), 4218, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4502407-f807-4103-bd36-fa4ed1298f45"), 4240, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f45e3081-ddde-485a-beab-e7d400ed0f44"), 4550, 1, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f47e20db-868c-430f-a972-4a01072b7b6c"), 4615, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f49664a0-43bb-4d28-bc25-42c1a267522c"), 4640, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f49d0cf0-5ec7-4133-a330-d095906e8593"), 4655, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4cfb53c-08c3-4798-a9e9-9979fc854fb4"), 4609, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4d55fcb-589a-4929-b393-a254433a0a9b"), 4556, 1, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4de7355-b3d2-499f-9eec-f2aaca3ba81d"), 4253, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5034602-cb95-47ca-bd76-664ce3c1c596"), 4311, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5095903-4bd7-4b6c-8290-215e3731b668"), 4007, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f50b22c0-7d32-43d5-b2dd-898a09477698"), 4635, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f50d214a-c8b9-47e1-b4aa-e789872ced44"), 4657, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f517d0bb-df5c-45f0-8147-49baa04b2988"), 4035, 3, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5245320-4178-409c-bcfc-36bc0adf7e49"), 4007, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5480f1e-105d-4726-b353-07f85afd9889"), 4712, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f55e3dca-371a-4806-90c6-d0ef11d94d88"), 4538, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f562953d-1756-4338-9a42-53a3b3a76469"), 4602, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f56a91ca-aca8-4107-81a2-75942c1748f0"), 4254, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f581e3f2-df41-4b59-b4b7-9106874fb726"), 4808, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f58855fa-f062-429e-b8a3-17a5bf558341"), 4402, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f58c96a3-d791-4ed6-8259-03846a91c9f2"), 4268, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f58f9263-02db-497a-a527-2d689091d5bf"), 4206, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5a20c13-f01b-4c58-9da8-16194583b68c"), 4451, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5c4f587-5500-468c-aa82-496d6575129c"), 4260, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5d93096-0a2d-452b-be25-d8b3a37d7ed1"), 4607, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5dba63b-1743-4782-a5e0-4f87d5b8b8d5"), 4626, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5de605d-c932-4be1-9cf5-4e2a4146e8ac"), 4415, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5debdb0-4ae9-477f-b3d5-f4713746cabd"), 4206, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5df49de-96aa-4166-aa25-074caecda7cd"), 4431, 5, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5ea4465-1112-4d66-8c50-a56614f19499"), 4440, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f60b73ba-8ba6-46a7-bf3f-e16a1c9a87d8"), 4629, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f60fe051-3a8a-4db5-930d-cd368d20ec37"), 4300, 1, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f622ccdb-0a5f-4237-a3d8-8e0fa6f8803f"), 4248, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f624b70a-b745-4314-a9ea-df4f745f8caa"), 4439, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f630a658-3bcd-4913-b5eb-5a3c12839c6f"), 4254, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f631bd58-5bc9-42b3-b130-c4ff23e2167c"), 4224, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6558675-f5d9-42ce-a17e-de6f94b0776f"), 4404, 5, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f65c2cac-148c-4579-a052-9124034f1458"), 4324, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f662e19d-b7ce-459b-b051-55523887d64d"), 4465, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f676b08a-2e99-4755-82c3-cb5e6893b885"), 4025, 1, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f685d097-e5ea-4220-a270-6ab23459dd3f"), 4535, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f68bf393-efcf-4647-a6e5-30da9b4e3478"), 4439, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f68c756e-4502-44ec-840a-853f9ef47874"), 4809, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f69cabd8-a3c9-4ec8-85af-487c02751dad"), 4306, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6a2cb7a-bcdd-4af3-a996-ae793066656c"), 4425, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6e28072-0914-4a53-9ee7-1edfd12459d6"), 4213, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6f7c676-14e0-44b1-a910-93cd3217a830"), 4528, 3, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6f97d55-23d0-4595-82bf-be5b1c608401"), 4546, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f700308e-7cc2-465a-8329-7b6d0ae20c1a"), 4608, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f704cd92-3dd9-4760-aaa5-0b43cf132301"), 4454, 8, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f70d8a23-7260-4fa3-b2b4-a51984259f39"), 4250, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f73ffcbe-9448-44ec-92ad-9c86c711f285"), 4521, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f764690e-0682-421e-9661-8c9c987b0ae5"), 4436, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f76d0599-7438-4a5f-8abd-0c7ef5586e0e"), 4106, 4, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f76d66e6-f9af-43ea-b646-e1f07a4d3025"), 4522, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7811e14-1368-48f1-8c53-7351556b6744"), 4465, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7a20fc2-e147-443b-a054-a2cb02b98232"), 4416, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7a4e557-3ee2-4a2f-89a8-eaa0ad19971f"), 4706, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7bafcd6-7e0d-4b34-b436-08b872028228"), 4419, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7bd3843-b415-4942-9590-3566c6255b6e"), 4408, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7d27428-b6e6-4192-93c8-932fe55451e3"), 4026, 6, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7ff9824-4048-49e7-ae7b-36159ebc424b"), 4412, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f801ad2d-1ea2-44bc-b121-12501c5db214"), 4435, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f80d2a8f-fcea-41c3-89b5-79d130bf781c"), 4651, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f81035f1-cd1f-46df-ab32-370ee8b990ba"), 4215, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f834f517-cb11-4b0e-bc1a-4ed86ece0be3"), 4705, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f849dd98-3757-46aa-adeb-3e5289cc2a74"), 4523, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f88f84f2-959a-493f-bb70-1604942bdbcc"), 4019, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8963e6c-645e-4a89-9aa7-0498512c7362"), 4306, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f896a5bc-dbed-409a-b71b-454852fdcd78"), 4701, 9, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8aa9d82-4635-43ac-b6c6-a49eaf772601"), 4309, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8b9d4ac-d175-44de-923c-3d160798285e"), 4220, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8cdca9e-3aa8-4f6d-9084-57030f6bdb58"), 4623, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8f4a41e-1115-4b55-baf1-7e122725ea87"), 4508, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8f9b650-898a-49d0-b497-82249df582c3"), 4401, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8fac9f4-5923-4325-a4ff-d85d34f86e83"), 4626, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9059715-812f-4775-8bcf-a3804810d063"), 4700, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f936695c-e8b2-450c-984d-073c26f2b334"), 4266, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9539030-3fc2-41a9-82ad-77d0b6fe6fbc"), 4508, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f95db1bd-f395-47b5-95a9-384b895c0e2f"), 4315, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9710d6e-09a5-4cf0-855c-a8ef044878bf"), 4223, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9815ebe-b6bd-48ee-80be-a70a610cbefd"), 4528, 7, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f98d66df-cb70-47a5-a04f-85c1af99353a"), 4014, 9, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9bfe049-735e-4a9d-928f-b0f9f467f797"), 4420, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9c4f7a9-4037-4030-8d39-9edc46301c6c"), 4312, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9d0f405-f2b5-4837-9283-247838a28716"), 4212, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9d22586-cb94-4cfa-a66d-96ac358fc5da"), 4433, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9d7855c-7d53-41bd-b602-9010b585860c"), 4209, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9dc68ac-69b0-43bf-8922-94773382b133"), 4405, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9e82b48-e118-4045-a963-747c47548424"), 4232, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9f31e18-89ec-430a-9eab-1ca689a4358c"), 4238, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9f77bcb-4c9b-4271-9cdd-ccaa06d4d86c"), 4852, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9fd31d4-9e51-46c4-b5a5-81943c0a647d"), 4629, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9fe368b-7c6e-4ca6-8957-564b3ea13525"), 4600, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa136850-a9f5-438b-bb93-171f4bcab132"), 4615, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa13c7c3-06ac-47e1-93a2-8826d03126de"), 4261, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa3b6e2f-6fc5-4be4-9eef-db96cffe0bf4"), 4213, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa3d466a-c5c7-4a45-84db-a28ee525fe62"), 4209, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa40f632-e661-44d0-a29d-120f621a481f"), 4715, 10, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa61f3d9-5fb1-451c-8d77-316c1a0c10c1"), 4610, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa63c825-2b3f-4241-8e18-8345f82133ea"), 4619, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa79214e-6a9c-413d-9abd-69b6fa91b262"), 4523, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa797532-f9ed-4116-900c-3fe6167e9974"), 4705, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa7afab9-78fe-468a-aa65-f42a6731210d"), 4224, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fac08a5f-bfa5-43a3-8df6-1a33daf70140"), 4003, 4, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fad31f13-8066-44f1-a6f6-3c67fa8c488d"), 4036, 7, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fad8bd0e-8236-4170-9956-5a8dcf549437"), 4406, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fae3bac7-46d3-49a4-8347-a70f4b206d24"), 4016, 10, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("faee67ab-f9f0-4e59-a3e3-8c8b6aa00dc8"), 4656, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("faf3329e-1b37-4f7c-a4bf-26fd52302d9d"), 4518, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb040ea7-b509-4149-a32b-c057332677c1"), 4411, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb0614f3-1475-4289-bb1d-82b254d1c549"), 4461, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb11fdec-7d87-46af-91d4-88d0e8ec1f97"), 4452, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb1b8892-4d87-42f0-9f52-749864e5ace0"), 4713, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb1f08ca-58ac-4db3-9a32-9bf97bfb956a"), 4656, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb2aa08f-ba06-451c-8912-7726149c2c7f"), 4531, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb3bd83b-5688-458e-b3cb-a66200b5a5fe"), 4458, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb478896-d5bd-49fe-8c81-3eebec3178cd"), 4538, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb6348a1-2c1b-4aae-bcc8-94469047bd27"), 4611, 10, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb6e3324-0fa3-4fb8-a453-4db43a74055b"), 4204, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb73018d-37d1-42dc-baab-78c659876b16"), 4564, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb7e4a1d-efe0-4662-8bf0-4edf9fe8ec5e"), 4710, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb7e70ee-b253-48c7-a020-72b64c103ba6"), 4016, 2, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb9b7442-cde1-490f-9418-07ca9159e95d"), 4543, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbab0a40-6bc9-4e11-a792-76fb742d1f25"), 4417, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbcb1b6b-30c1-4bf1-a8d5-1a4e4278f50a"), 4104, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbe0c49d-e393-4fbb-8515-73424e89f1d1"), 4803, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbe3db6e-83e4-40fa-9b11-0fe98ca21877"), 4555, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbe7889c-1f59-4b1d-acad-7e0219fa8cc5"), 4624, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc0bbdfe-7f0c-45df-97bf-ef2214d8aa2f"), 4255, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc11cec9-9b41-4503-aa4a-69bb1aca2f6e"), 4305, 1, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc26605a-f7b0-4da2-8155-71b7e9d6723f"), 4662, 7, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc2ca8bd-7bf5-4274-b758-8b7a74128436"), 4248, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc6121f5-8117-449b-83bd-5ee9d788ec20"), 4663, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc84ef80-54aa-4416-bd6c-de46945383d5"), 4561, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fca04135-e309-417f-8806-812e2a32596d"), 4542, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fca44150-4775-49b2-ba79-b2a12bed7b7d"), 4268, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcbe16da-b7fa-4289-b4d3-da05059ebdea"), 4701, 3, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcc024ac-8c59-448a-a688-66fd4daa98a4"), 4464, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcce04cd-4411-4765-8d44-d1275a4854bb"), 4408, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcd46931-0326-4115-a9eb-107a5b13e4b3"), 4115, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcd5de23-d24a-4617-9a82-0e6ecfdf22e4"), 4810, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcf26ec1-93f4-4fa5-a4fd-b77053d47f95"), 4003, 8, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcfddf34-94d0-4b23-8768-7ec9df392ee4"), 4637, 3, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd2d320c-c846-4244-a280-5974d8d4e914"), 4014, 10, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd514abd-2207-4f00-880b-fd2e25186f22"), 4537, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd55fafa-86ca-4c77-bb96-d46244536307"), 4600, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd5ba0dd-7d17-4ec5-aec5-224530096758"), 4565, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd5d373c-9737-49e8-8976-f8455f883e38"), 4200, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd5dde1a-cbb2-4215-8f0d-9e5e876ea1b1"), 4267, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd65a07c-f903-428c-a0f7-93a6357712bb"), 4613, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd68be0c-cd68-4de6-be72-26f9208038da"), 4037, 4, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd807323-dd92-46b1-ae47-d94b4eab5892"), 4424, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd81dea7-44e0-4546-9dd8-ee4c6363f045"), 4634, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd9f91c3-00e1-4962-9d91-4fb1c933e299"), 4634, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fda1b156-f010-4235-bb03-fa6b8eb38891"), 4266, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fda70ebe-580c-4d4a-babc-75e16f301e16"), 4008, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdefcda3-9ce0-4945-9fa2-2350e21e0177"), 4715, 5, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdf7ffcc-3cfb-42f5-a775-03850ffed199"), 4315, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdfa45bd-7d01-4b6a-80cb-9efb51848f69"), 4561, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdff3129-414d-4c5e-9207-9b32466811cf"), 4609, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe14c42e-9882-4e18-a795-1952a52d693c"), 4010, 3, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe1719ec-1864-49a4-87b8-632bdf283f43"), 4442, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe49a98b-e99c-46ed-910c-a638cf850cce"), 4427, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe4a6083-4a87-4f32-bf18-2922a695f468"), 4707, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe5685ed-9dc9-4351-a955-6c24a6f1bef5"), 4855, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe57cf6b-f1f7-4c45-8223-cee57ae1d404"), 4410, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe58a115-5b42-4011-8f68-cb42204d34f8"), 4100, 9, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe754c9b-d2ce-408f-9a0f-2ee0992c4d93"), 4519, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe85e1ff-e7fb-4e23-b0a5-1a56749af1fe"), 4512, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe927619-934d-4ec4-9bef-9cf7e3c5d5d0"), 4233, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe9729d6-de8d-4d42-b84c-f284cc8c4435"), 4003, 9, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fee39759-bfaf-47cf-b0fa-7ac374a14ca2"), 4515, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fee7c501-9ed1-4ac9-aeac-4c1967477edd"), 4238, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fefe4f3b-a670-4ee4-9dcc-a98452ea6ca2"), 4106, 3, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff009f86-56f7-4b0b-99fd-6858f51d4977"), 4204, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff4c9c3a-6e12-40b7-bb41-6b37b5ef70df"), 4711, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff4d0336-0ade-4fa7-9b62-721cc031dd9e"), 4421, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff50675f-01a5-48e5-8398-dc939d16572f"), 4244, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff5d280d-7a3d-4c66-9258-840e260517bf"), 4240, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff6b48d2-807e-46d3-a63b-10b443924e8e"), 4101, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff70d99c-64de-4b45-af5c-6094b97cdf19"), 4614, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff86bd77-b89d-4cfc-870e-13a38aa75f76"), 4022, 2, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff8ebd75-3f14-40e1-a867-a2cd39a0c0fc"), 4542, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffa8ac9a-38bd-4767-8e0f-1ec4c5bbeac4"), 4247, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffa94ac8-0ce9-4d30-b2b5-178bfc65d55d"), 4544, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffdca196-66df-49a6-8625-49aef17725fd"), 4273, 2, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fff3c58f-4cf4-4202-98c3-590cdeb85307"), 4712, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fff8241a-9d1c-4f17-bded-d0ff0542bad3"), 4546, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fff8956b-cee3-4d7e-ae4a-b049234d639e"), 4440, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("2569e214-fc79-452d-95d6-89d98fc76eed"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("3081977a-4000-460d-90d3-0948c5bba063"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("6bf537aa-ed77-42e7-8c19-c970083d99cf"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("80e4822f-0e06-4a83-8ff6-c71e7bc452a8"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("85290855-b905-4847-804c-7a1a4918eb94"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("991340b3-fe44-4704-8310-fadfc996acbf"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("db4b070a-baf9-45ba-a636-3748612c31c7"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e21bdf1e-cc95-449b-8c6c-2bb3c1b55363"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("fa5f42ef-bde4-4965-9c28-1654f59f7bea"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ff041d00-351c-420b-9838-366a203c12ff"), "APCDevice_3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ConstParamsId",
                table: "DynParams",
                column: "ConstParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ParameterDataInfoId",
                table: "DynParams",
                column: "ParameterDataInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveParams_ParameterDataInfoId",
                table: "LiveParams",
                column: "ParameterDataInfoId");

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
                name: "APCDefaultDatas");

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

            migrationBuilder.DropTable(
                name: "ParameterDataInfos");
        }
    }
}
