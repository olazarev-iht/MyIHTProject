using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardwareMock
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
                name: "APCSimulationDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Device = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APCSimulationDatas", x => x.Id);
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
                values: new object[] { new Guid("00068cae-df16-4679-a0bc-9319d4677b13"), 4658, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0009c691-c88b-43ec-8a41-3a06e37f4996"), 4113, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("001a90eb-f0ba-4526-b5ff-9f632e22833f"), 4222, 8, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("001b8b81-fb06-4449-87f9-d3a8b92cbac8"), 4422, 8, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00320fad-17b1-471a-a3f2-79efb41f72c8"), 4267, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0052a5b6-7fcd-4ccc-906c-46b0f55a476e"), 4656, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00585612-bd9d-442e-802b-2f93f500690d"), 4522, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00591a26-36da-406e-bf93-22fc7adbdf09"), 4420, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("005c519a-824f-42db-8094-0d191c1470d2"), 4035, 9, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("006dcd2a-3bb3-47f9-8916-b7064510c805"), 4700, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00846e99-3eb5-4db4-8bfe-930a417b7003"), 4235, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("008dc93e-9b9c-4660-97bc-135a8eaa7f5b"), 4221, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00ab0ff1-29b2-4238-9798-cdf65cf683c6"), 4534, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00bee813-7453-4a3c-a261-e6403d221a15"), 4430, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00c86a90-8ac9-4784-99e7-91a3854230b3"), 4557, 3, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00ea8c87-dad6-4efb-b221-625e387ef239"), 4302, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00f6c270-1571-4ab2-9c8f-5f2bbbcfea79"), 4438, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01113c6b-fe58-4940-b362-be683a18ec5a"), 4503, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01196db9-346a-4ad0-9aa2-2863fb51ffc1"), 4462, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("014c6bf1-c85a-42cb-a9dd-70b978bca49e"), 4035, 6, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0174eb48-6d92-4446-91ff-1987baef2851"), 4450, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0198f912-e22e-42aa-b8e0-da67df778377"), 4547, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("019cd6c3-6c7d-4b84-8daf-2fc51aca1545"), 4265, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01c8fca0-e483-44be-a12a-941b0ba3b2f3"), 4461, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01ea5642-6337-474b-9a8f-de9d8375e527"), 4517, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01f69773-9cfe-4a65-ae70-37a91b4df84e"), 4018, 7, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01fd0fad-a07b-40d9-a3f2-72f29a1b5c9a"), 4304, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("020fa57a-ba59-4c73-95cb-0b4c750fe135"), 4438, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0224e190-aca2-4efa-83d3-09d4bd0d08ac"), 4517, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0225deb2-1d23-4a3b-9ca8-cc6e1c463e5a"), 4304, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("022954bd-c9f4-4e2d-b115-4db09e1af7b2"), 4321, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02342823-9101-4eb3-9c66-5f4f5f4473ee"), 4104, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02492b40-c410-4ef1-a063-1c994980b685"), 4101, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("024ca946-a002-4233-8044-7319666ba4cb"), 4560, 6, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("027fabd2-40b5-4aca-893c-24df8650a46b"), 4207, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0294e889-d353-4a54-a848-9031774b522f"), 4228, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0295ac23-82d5-4c0f-b911-f603ee185cca"), 4405, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("029a9840-7bc5-4500-af71-f50982335c95"), 4720, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02a7fefa-c751-4312-ac1f-7a8c6afa033f"), 4417, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02b49257-3148-4867-856e-1a4568ac6d3f"), 4622, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02de3660-466c-41d9-9312-d9b208424dce"), 4662, 3, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02f62bfa-9d6b-49e2-b8ff-a5dcb4ab795c"), 4401, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("030760d6-4b35-48d4-a7c6-bb17acbff30e"), 4710, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0308aa20-353c-46c3-b6e2-0198f5381a62"), 4802, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("030f957c-645e-47d6-b86a-4d230256da36"), 4029, 6, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("032d9e01-141f-4392-93a7-0399cf161b8c"), 4309, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("032fd0d5-a9c4-4449-8650-e3248922a476"), 4607, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03318757-f43d-446f-ac77-7a95c1dc6a8b"), 4257, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03487b86-c022-446b-a0c5-c529426ab203"), 4007, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("034e56ee-1936-473f-afa3-b257a6afdb28"), 4607, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0351e1b4-0b1e-4bbf-ad22-2e2f16412693"), 4005, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0359f713-4d35-46ae-a3e4-bd38f8673cb3"), 4553, 3, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("036e61e6-bff1-4ba7-bcaa-23d10d931cfb"), 4001, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("037d9b26-b811-495f-99c6-a674f29cf7a1"), 4013, 2, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("039050c9-447e-4939-9c79-38ec7d448eab"), 4465, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0390e480-78e1-4f9b-b19f-bb16785fd765"), 4255, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03ac2cc7-2a5d-473d-88c8-57ec88c8be52"), 4523, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03b7a0fb-bea4-4237-9fdb-d7cfede3562b"), 4243, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03c2e674-b199-4358-817a-ca11cf33dc5a"), 4249, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03df4a80-5b4d-441a-bff2-76056ab1772d"), 4219, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03e57c79-e70d-405c-a732-4dcb2cfa2102"), 4106, 4, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03f3d6f6-1643-400e-ba21-815e532a909d"), 4255, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03ff9b33-f22c-44b5-8a77-24248e4f08e9"), 4710, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("040c47cf-88e4-4ba0-90b1-0f12ea06206b"), 4105, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("041e63eb-7aa8-44ca-9dc6-cb16323be24c"), 4856, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04606506-f646-496a-9766-33ed5dc400cb"), 4008, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04613b1e-82ae-452f-ba85-ed850f4eaf6a"), 4208, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0466ace6-378e-466f-8abb-59968158e253"), 4301, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("046d1266-207d-4a77-9108-9c33940c8474"), 4526, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0476a5f8-713a-4a4f-b3f1-1f7e6d226a5c"), 4659, 8, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0479d573-388a-45b1-b456-1e6749eae01c"), 4444, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("049f0f52-5c6b-4cf8-9c58-c8532a233907"), 4802, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04a874f6-21c7-4028-a56b-767e469353b1"), 4236, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04b28aeb-ba91-48f7-b17e-aea81c6ac1aa"), 4524, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04d628ed-6c57-4988-a020-3e44ee6a4642"), 4315, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04d718d9-249c-4891-a72a-873ffa2f42a0"), 4804, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04ece3d5-8046-4c47-a94d-d8823b3d4bfb"), 4267, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04f432fd-a36e-4cff-9fea-a3c27ecaebc9"), 4308, 9, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04fdcf9f-8393-4fe6-b29c-78752a7f147a"), 4232, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("050270ea-d501-49c1-9d8b-8943ba6f3693"), 4010, 1, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("050458fc-9ca6-4594-ab00-d9adc3912ff3"), 4035, 5, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0510187e-9385-480b-97b8-66abcf68272e"), 4521, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0525fa1a-578a-4509-a164-5830dbd0ecc3"), 4704, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("054afda5-9e65-4754-a843-c8f1dfe30e81"), 4306, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0575b378-75d7-49df-a85b-71c785f93537"), 4244, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0578a53b-bb76-4d30-af32-c57bd6314767"), 4528, 8, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0579a138-7f2c-4fae-b846-da70cdc4c272"), 4219, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("059f5bec-987a-43c3-82b5-c24abe2b07d5"), 4533, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05a118f0-8c19-4e6e-9958-01c8c0649dae"), 4510, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05bcd525-7b15-42ac-97dc-b4715fe312fe"), 4009, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05c52c6b-acef-48ba-bc74-c88948a7d1e3"), 4263, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05caf998-85b6-427c-9b92-1bba710d2f5d"), 4662, 4, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05cd44f4-328f-4b13-82bf-a2f9672ca1a9"), 4271, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05d5dc9b-a0e1-4fc1-913d-b96aa300d0bc"), 4639, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05dad72f-37da-41da-8b25-74f392be7c65"), 4513, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05e65b6c-60f0-4b12-b197-92f32f68dea4"), 4258, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05ed12b1-28b2-477c-aded-5add7c4fe00a"), 4430, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05f34a9a-c252-419c-9868-642396d26aca"), 4422, 7, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05ffd866-338f-4f76-966e-7a6afe9cb162"), 4850, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0603a250-2226-43c5-8634-7a7b159e0c66"), 4222, 2, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("060e76a0-d5f1-4025-a585-b69b1a09200a"), 4003, 8, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("061fffa6-a2ac-413c-909c-6a2d29c8d740"), 4615, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("062cf03b-9a15-4e3d-87c3-c809a5c56750"), 4850, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06303b32-614c-4966-8037-980ced32b466"), 4535, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("063b06d0-6743-4607-bef9-86aa87e43eb8"), 4415, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("065e538f-09e6-4705-87e3-8b0a25afc383"), 4720, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("065f6440-5839-4c53-a6ba-35b2023069df"), 4428, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0672b86c-b771-44f9-b6d0-f7614722136c"), 4235, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06763f51-50d4-43a4-bf14-00d37c2b0b8e"), 4618, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("067dabe2-5ab6-4255-9178-d61f9b50ee1f"), 4400, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06842f37-c010-4d99-8dc3-1eb4d70366f5"), 4505, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0684764f-33a0-4f4d-bb82-d777e3ba388c"), 4319, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06b4bef2-3fd1-449f-80cd-2a2b3f5465eb"), 4705, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06b65dd3-e022-44bd-b701-14e8c15d8e70"), 4502, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06df3310-ce28-4b91-b66d-9afd89a2e6bc"), 4238, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06ea3364-086e-4911-8257-5c5c4986390a"), 4272, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07052e25-14ad-4995-ba71-a39c07fbcdbf"), 4235, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0707d6d1-754d-4694-bcfc-231ad198b667"), 4271, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("071ff64e-032f-4522-b21a-6ba8c8a772bf"), 4457, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0720aeba-f632-4b26-95d1-102118c86ffe"), 4850, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07276e23-73d4-4c8d-8177-cc40a30b9cd1"), 4413, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07363ce0-a11d-4eca-a455-2fcfa9571343"), 4800, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("074bad86-a045-44f5-8feb-6386acd1e8e0"), 4100, 2, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("074ce544-1108-48db-9c7d-f0acb009c7f7"), 4023, 1, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0786ba69-6996-411b-a1ea-13f0967ad19b"), 4027, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("079458a0-5b5f-44fe-82eb-7ef0a841d2cc"), 4464, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07b50445-4b7e-4c66-80cd-26593372cc10"), 4427, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07c63237-65f6-4123-b30b-5faf7ea6aac1"), 4555, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07da0253-967d-4877-9935-9f6c86be580b"), 4235, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07da6d96-fa22-44a9-8f9f-951761ba1544"), 4267, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07e1e03f-9a57-4c7b-80f9-b7c0cb2a4020"), 4416, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07e293e7-264c-4444-817b-8a3f2fe0a567"), 4719, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07e5f48a-7300-4259-85dd-cd647d5c0186"), 4229, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07f06c1a-32e6-478f-a6e1-40a425bb7979"), 4324, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07fb9594-7b00-4364-9be2-0fee590a9bb4"), 4320, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07fbc674-356b-4294-98f3-db073a36d6d9"), 4114, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07fd64fb-f35a-4a22-8eef-91157ed98787"), 4526, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("081f874b-2143-4d03-a4fe-39844485748a"), 4242, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0828416b-3b4c-43a0-8111-0cac2d1d6a7c"), 4661, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0866eb44-e660-4d5d-bef0-a6bcecb372f2"), 4625, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08772a74-ff17-45e8-838c-9d5fad203d59"), 4440, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("088ef169-f068-4513-a46d-369f1ba0c231"), 4402, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08977284-a3fd-42c3-baf8-d04d535d1bd0"), 4307, 1, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08b4aae4-26be-45ef-809a-b0cccc713390"), 4274, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08bb47a7-7617-4073-825c-0f4a26877272"), 4547, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08c49fe4-6200-4626-8df0-737bc0cdda88"), 4424, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08c97cf8-309d-4a60-a8cc-1a5c4465d959"), 4705, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08e5150b-6ff2-4e0a-839c-422894d69971"), 4608, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08ea0f96-3234-4ae1-86ba-310df56c8093"), 4308, 4, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08fbaa1b-ce84-4a40-80c2-295cb2a74f5b"), 4016, 9, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09196a2b-f1d7-4195-a104-0e1c5dda282c"), 4662, 9, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0933344d-692e-4608-8261-80402d913dee"), 4414, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("093ca4a2-2380-4f5e-80c2-4d2c6abc7c34"), 4623, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("094d270d-b76b-4f98-bfa9-1cf2287e1429"), 4114, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0951e053-0d5a-42f6-b50c-5f6fa4c7e7e5"), 4559, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0963f01b-1b58-4f8b-9366-d163ae225f94"), 4412, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09906d5e-ed1e-48e5-8ce0-6002f8193f22"), 4609, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("099708fb-4a91-4c74-a4f0-0f637e82b695"), 4110, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("099ab982-d695-4d7e-a168-f4bf658c8302"), 4720, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("099bc4b9-466d-47b6-a60d-fc46430f68cb"), 4426, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("099dc003-7bc4-4c9b-bd57-c4ca0cb7d59a"), 4034, 10, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("099e2b51-e927-4571-9b19-a39a93ee51b2"), 4637, 7, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09aab92a-efa1-4d6b-942d-8c99215e8d3c"), 4525, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09be4cf5-2f8c-4fc8-b76e-36aa7c9bec36"), 4211, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09be8e5e-6fa6-4e8d-bb88-6e8f5cd53628"), 4634, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09d130a6-8a31-46d1-80f8-84ba48b679c0"), 4543, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09df28ad-a1a2-4f90-b652-58dbcf0ab7c6"), 4230, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09e0be35-e012-4bf0-ae30-6cdebf01a0bf"), 4464, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a0065f9-d770-4915-9520-659c7ae37b48"), 4245, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a12e90b-dfdb-4260-967a-d34e5450ecc8"), 4535, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a18ad10-d2b3-4b55-9068-93595509b3e6"), 4241, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a1ab2e1-721f-4e8a-9cfe-0eee27b78a94"), 4314, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a26885c-0ef1-404e-b436-13605c9d1b67"), 4801, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a3c8d2d-efda-40c3-947d-5dac96150483"), 4635, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a41e34c-fa5a-40e5-b596-27a9c9666b39"), 4420, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a4678cc-ff2d-4fa7-972a-d5fde08328ef"), 4113, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a6c28ac-781d-43e1-bd3b-d25248d6b3b3"), 4223, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a793a3c-aef1-4949-85ad-102980cf285d"), 4404, 1, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a7f42df-4992-43a9-a309-2346fe9bb6bb"), 4440, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a8eb1f4-3015-45fb-bb94-93085e48fdae"), 4220, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0aae0867-0e57-4e8a-8ec5-4c3dcf4c054f"), 4416, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ad36225-99e3-45c8-ae7b-878b67b66da1"), 4532, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0aec4c18-42ab-45f7-881a-577af77bed53"), 4438, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0af16ae4-043a-4b54-a709-aad36bc8b90b"), 4650, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b035c16-221a-425c-be54-813400bbfa3d"), 4553, 7, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b2b6bb0-30d5-4c0e-9494-730a88f1a4ab"), 4402, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b41df25-f108-4884-a462-445b9a1129cb"), 4408, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b531de8-dfca-47d6-a58b-36a76d25f075"), 4411, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b573cf0-32ec-46e0-82cc-37fc27784498"), 4419, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b6bb5c9-ced1-4949-8b9a-7926fc5074b7"), 4036, 1, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b718f14-5e36-4b7f-929c-f5989addb7d7"), 4600, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b7c4afe-ba6b-4924-8b83-719d732e5953"), 4007, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b86b481-48cc-4630-a14b-83b6aaf75e2d"), 4717, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b980def-4fb0-4977-af14-6fedbf0425e6"), 4722, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b9c2ef9-d10a-47fb-b5c1-dc2484bcdff4"), 4507, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bac256a-6878-4260-8342-dcfe308e38d1"), 4506, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bb7401b-086c-43e5-81f4-ef1f31ab2078"), 4605, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bbdf232-4fa7-40b9-9b48-a810b60d22d3"), 4637, 2, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c19bd40-0839-4cfa-a449-207dc471ddea"), 4034, 9, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c20506b-7e1a-461c-a948-c18b932e8b65"), 4519, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c2ab8a2-d1e9-4501-a407-90134039c1d3"), 4722, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c35ce81-cf56-44dc-a4b3-075dd0423bb5"), 4546, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c8cafcc-ada8-4224-8ed5-9a3d37863104"), 4558, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c8e6477-0d9d-4a0c-b7b6-5a9909eeaf79"), 4463, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c8ed72f-e98e-45f3-b28c-3f7f18533db7"), 4504, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cb14d29-86eb-445e-9598-35fd3665c1a0"), 4319, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cbc2f47-c7f5-4b3b-b19b-2b83359e9450"), 4541, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cdfcf62-d986-4fba-ae89-f48d20745b72"), 4433, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cea8cee-485f-441c-ba4d-0c64dc1d485f"), 4506, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cf3fef3-4ff1-4270-88f1-a75534436e0c"), 4544, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d0bd384-886c-4619-9c09-30589d5411cd"), 4404, 5, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d1e2248-7c5d-4d94-8da3-fd70a4a39d0f"), 4309, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d220737-7580-4d0e-b2d1-b96c55d7b9cd"), 4410, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d30f6ff-50f2-4ea3-a06c-5fbe9f6574b1"), 4429, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d357f1f-95bd-4293-8ada-7cb927efbaa2"), 4413, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d56fca5-776f-40ec-8baf-17d72300b736"), 4623, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d62c3e6-dfe5-45e0-8b14-26a07091cfb3"), 4855, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d7e36a5-597b-4a81-bb25-dc6fe7af485c"), 4220, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0da9736f-440a-424f-a6cb-0fb353f397b3"), 4269, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0db3128d-ca66-45d4-83ba-38b94fe34e8f"), 4115, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dc6d4db-4d3a-4b5f-92bf-27893c8cbfc5"), 4428, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dd176fc-ec90-4d1d-8542-36411f7e4931"), 4531, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dd810ab-0ed1-4a1e-8280-21d2f304b535"), 4651, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0df0c465-0385-4b82-9a90-e41a7df18638"), 4624, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0df7c85a-3dd1-4511-9272-291fe2fa685a"), 4225, 4, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dfc6fcc-67d0-4792-b6c9-c5b93c9e16f2"), 4266, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e0fb74f-0773-4e24-beab-fca17fd3ab46"), 4718, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e1c4466-bd49-4c79-b5d7-48c064865b5c"), 4721, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e1c842b-3b42-4710-9d14-ea5943ec5361"), 4218, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e507699-ba58-4d73-8ebe-2ec0f7af53b8"), 4561, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e65b538-979b-4025-a526-fb1c72cae579"), 4303, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e7bf037-b134-432f-8775-92cf9150cf80"), 4559, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e7e5c8e-92d1-45bc-b807-11b1a8de608e"), 4511, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e87f6de-0548-44e3-ad48-faa7ece31c00"), 4209, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e8b868a-273f-425c-9651-03ba6c2d4990"), 4704, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e8dee8f-5c5f-4a4f-ae45-1497e204299e"), 4206, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e949202-abc2-44a2-bb24-1672888ab0c8"), 4402, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ea2399a-26fe-4083-b4e8-0a04a71ccded"), 4543, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ec3a24c-a081-44bd-8f59-18ddad48f511"), 4017, 4, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ec3bacc-45e1-4403-ab3c-d7c1945e9498"), 4229, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0edec21f-c182-41de-be2c-3ae9db2a08fc"), 4208, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ee08ac4-f427-4890-987c-24c2e5c429df"), 4510, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f0d466a-761c-4f67-8893-1a40a01a552a"), 4851, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f13317b-5d79-4057-9fb1-c29923fa98c6"), 4506, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f190794-a56c-4359-bc87-429e24bd3e64"), 4535, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f230300-8d23-4027-9949-f624cd075980"), 4510, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f24fd77-994a-445e-8b41-3367d53091b4"), 4802, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f4136eb-69ab-4f46-87e6-22bf41688b4a"), 4010, 7, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f48e43f-fb14-42b6-a550-edcd26b3e178"), 4658, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f5885c5-c0f0-4839-8e5d-ae1aa7b4aa33"), 4114, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f61bcd8-f450-4b5f-9e85-c421d86c9275"), 4323, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f62303c-0979-42e6-9166-76ed4af9fac3"), 4317, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f74a23e-c2dc-40da-95a0-9ab0c8f30174"), 4002, 1, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f8fad2e-d2f3-4073-86aa-806e2a3f887c"), 4106, 8, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f921486-36eb-4275-ae7e-8443a58ddde4"), 4703, 5, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fa5ca3c-7568-45b4-a7b8-37ea2abdd46c"), 4424, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fbbe01f-4bc0-45c6-af81-9929a9e382bc"), 4652, 4, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fca6937-002f-4aad-8551-05fa9b27f457"), 4314, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fcfbe72-e01b-4cfa-8381-f8b24bf5b36d"), 4700, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ff58512-b172-4c63-80d5-20058d738101"), 4708, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ffd97fe-87c2-49b8-8e5c-aa1dd5e426d5"), 4511, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10084e7c-c4c2-4dfc-a29a-6f2f2c2443c7"), 4027, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1026e859-193e-4bf4-8000-13f77c5872c8"), 4560, 3, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1036fef9-a27d-499d-b18c-11afd9cd94af"), 4415, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("104bb855-c878-4908-ac11-c5a1c6852e7f"), 4113, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10584b22-8815-4086-9606-0ce49d9eecdb"), 4303, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10593cb4-eb42-4024-af58-265fa31dde2a"), 4264, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("105defe2-8269-4f8d-bae2-bffc069471c6"), 4208, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1063a968-67a8-42c4-8339-018cf50bb073"), 4639, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10879115-9494-43e2-aff1-7d3af9b20cb2"), 4417, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1087cbc3-b6a0-4ea6-a9c2-5ee0e7972d9f"), 4031, 6, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1087dafc-1ab4-4813-99c0-368b236d3f9f"), 4264, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("109ae59a-5195-4fa2-b895-f6ec0c76c8c1"), 4425, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("109d166b-b136-4fe1-be9c-7824a69d1cd4"), 4531, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10a95925-d7d3-4467-9cb8-8ac4a2c4f12b"), 4037, 4, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10c069d9-86d1-41c0-b2dc-e12fb3e63513"), 4024, 1, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10db2875-038e-4be6-9a9d-4dff9b1af5c5"), 4205, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10db4d87-01f0-4957-ade7-50329f740da6"), 4450, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10f450fd-4aa1-42c1-973f-4ec7b7eb290c"), 4230, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10f54aa5-4f9d-4917-9122-e9f2e42362ef"), 4028, 5, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11082e6b-ef26-457b-b971-5d0b2f58a643"), 4300, 6, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("110aa219-a408-419e-aeb5-9e653f9bd3fb"), 4222, 10, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("112722bc-7a38-41f2-875f-259f6855983a"), 4225, 2, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("114da28d-9c56-41f2-9691-0565dbf9d884"), 4222, 9, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1152c3d7-754e-445d-9aec-5379458272a3"), 4030, 4, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11538873-4f99-40df-af53-e4ebd99b82e7"), 4712, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("115854ce-38bb-456d-a7f2-f96e69ac9bf4"), 4450, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("116370d1-2d49-4d03-8e33-44e85e754885"), 4006, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1170b4f2-34b5-40fb-8c53-907979a8a03e"), 4614, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("117d19b3-6e6e-441d-9bd9-4c7d9f6e4528"), 4710, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("118e3422-dac2-46de-9389-061038548aaa"), 4322, 8, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11a10411-7bf1-4c96-b2db-22773d47ca40"), 4455, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11b11813-a47c-4988-904d-f00b9eceef1a"), 4268, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11c6e6b7-beaf-42cd-a3e8-b61cd7c430d7"), 4711, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11cfc3a8-0079-4cb1-acb4-c0ca0586a73d"), 4251, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11dff55d-c8d6-4e46-a660-2fb77e457e9a"), 4429, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11e02109-f445-42b0-aa7c-ea4dd4862843"), 4217, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11f857e2-93a2-493b-8478-1f14ce5d731e"), 4323, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12060c87-0c00-41c5-bb75-6fe2169a1777"), 4539, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1237461d-392e-4283-b6cc-13f02347c9cd"), 4218, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12594ddf-f7dc-4d38-a580-4b2c33195b12"), 4511, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1259668c-940d-425d-9c5a-e5507ef6477c"), 4101, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1285fcc6-e97d-472f-8212-088bc7843017"), 4660, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12a30656-41a8-4c35-804f-f97154d6e55d"), 4207, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12ba18ef-1700-4c5b-ac52-483b8ee285e0"), 4628, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12bc3586-c5f0-47cb-b5fd-a5dc5ad76d0b"), 4311, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12bd22cb-accf-451a-8470-94867378e226"), 4214, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12df43ad-8c7c-400f-b040-735d11656f7b"), 4520, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12e06507-a438-4b8d-957d-e0c7486b2eaf"), 4037, 8, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12e224f7-5096-465c-b88f-3e29b339b611"), 4521, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12f6a69e-4750-47d7-986e-7d82ebd2d32e"), 4203, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12fe369b-7d59-4cea-81af-6ca4d578a55a"), 4617, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12ff7f2e-1961-4abc-9786-2e9dd5a4fc7c"), 4009, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13188477-f636-462d-9ae5-2794f7e91213"), 4215, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13361635-5771-4042-9ffe-595a7aca85ff"), 4452, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("134447c5-3e10-4566-9cb9-86cc014a60e9"), 4313, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1347fe22-87f2-44f4-83c2-f4bc61a8ed25"), 4614, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13590717-634f-4e9c-bd74-50cfa95630f8"), 4604, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("136e5708-9d2a-414b-b23d-c121ffc51e5c"), 4723, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("136ec3ac-ebbc-4258-b8e2-40562a2a9596"), 4659, 3, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1393fb2e-c0a4-4319-9554-482f31b2be23"), 4713, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13989620-ece5-44c6-9203-f7188664d77e"), 4610, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13bf71de-2e0d-49c1-8fb1-b256144cea98"), 4020, 7, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13c57f62-9630-4047-8c0b-d6963c707b31"), 4557, 10, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13d967bb-a7da-458d-927d-c228a60bf903"), 4607, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13e714de-1d2d-4ab3-b5ca-81b05e0da0ef"), 4564, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("140013a5-e822-4e00-a52f-383c36d64606"), 4515, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1405d4d7-c4aa-4390-96a6-7f9975c29f93"), 4240, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14081951-a5a0-44ec-825b-56e2933cf9c7"), 4408, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1418c0ab-7ee4-4641-82da-57c63f37204e"), 4022, 4, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("141a37ae-ba42-4fa8-9c84-ba72ce9adcbd"), 4626, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("141e0813-8672-4049-abf1-fcaa7b9201f5"), 4608, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("141e7364-cb19-417e-8dd6-849e7e2fe962"), 4809, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("143ac497-3771-4a4a-919a-3b66d7984634"), 4272, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("143c01d5-2486-42c0-8902-cd9142b4b010"), 4653, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1444b9f8-3c53-4aae-a262-5146bd19419d"), 4432, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14493c48-aac4-4178-9e37-1a79b6daabdb"), 4418, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("145186da-87e1-47c9-ab1f-ebb5a4318c6c"), 4653, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1455abde-4e06-46f7-95ff-f03286060c09"), 4506, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("145b631f-f696-4e4e-aed4-2d69b28445cf"), 4210, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("146ca8c9-3a00-4ec6-9cf3-818fb167c32b"), 4613, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("147e3b83-9855-484c-8d70-1ff7ff73b995"), 4320, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14801d61-65c7-4627-9b0a-fc42f6e9c8ea"), 4458, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1483914e-288b-4b4f-b5f5-e24b7be0aa3e"), 4562, 4, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("148ceb28-64e4-401b-826f-259e3468e21b"), 4021, 1, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14a96cf6-d4f2-4752-9b06-e2e5a0cffd60"), 4806, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14ba8a9a-3065-4d20-87c4-a1ab03eb9f73"), 4403, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14f2dbfb-473a-4f3e-8b24-82289267402a"), 4510, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14fba4d6-93da-4c24-897a-20b8d97b8f53"), 4404, 3, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("150ccb7b-4e27-434f-a3be-2343d2cfe8b5"), 4535, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("151306ea-bf2c-4772-af17-7b5ff8977761"), 4452, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15374d79-e625-416b-86ca-661e3774f711"), 4625, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1585009a-b94c-441e-964a-0d9a947dde0f"), 4023, 10, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15b0646a-7391-49e4-9785-9eaf08b46fdc"), 4633, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15b222a5-ae13-4ad8-bf34-ec2fc145b33f"), 4405, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15cbbf20-5ed0-4f10-8f4f-96a25e682315"), 4504, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15d33340-5347-4e73-87b5-2785e2ac0022"), 4249, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15d95b7c-3288-4c6b-84a7-ea7f1d728e2b"), 4547, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15e3da97-e207-4f73-9c89-0374cdfd261e"), 4009, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("162824f9-23ef-4328-b35d-9d4c8a8d51b0"), 4650, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1628e5df-6ffd-457a-99ba-ec3ccb409bb8"), 4273, 8, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("162a9b87-07e7-41d7-a1b0-2bdf007a1396"), 4107, 3, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("162b9f7f-00d0-4e69-93f3-daed1e386026"), 4413, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1632c350-f02a-48c0-a455-ed3b28c35734"), 4503, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("163f99d1-910b-4758-bcf5-bf7fea086115"), 4450, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("165eae8d-83e4-4dce-9f91-06309581001e"), 4236, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16713a8d-c29a-46ae-861b-851f6563ce32"), 4658, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("167529bf-4134-43bf-b243-6554cf276832"), 4720, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("169ea165-417f-4440-bdcc-1ff5980117eb"), 4526, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16b3e1c7-34ed-4b22-bee4-53d20c3686a3"), 4224, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16cbad45-6c6f-495d-b5ef-054f079b37f6"), 4015, 7, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16d57f68-bf09-4966-8c0d-54989b1717a0"), 4267, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16dc9f05-19ae-4e55-aa82-a9eb63b5c5b7"), 4719, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("171f55f8-cd6b-4350-8a04-8568f6574783"), 4243, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1751adea-3d04-4b42-8503-d1db721fa5b5"), 4442, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17644767-74b2-43a1-9068-e8fe55d98e5e"), 4604, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("176c9497-6365-4353-927a-b8c61e8c3bb4"), 4026, 2, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("176d3102-e8be-47ee-bf4f-398729014457"), 4401, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("176d5855-a356-4cfc-b9a6-620f0a44a71c"), 4654, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17809cbb-d150-4461-8298-f4786b6c0334"), 4528, 7, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1783d499-75db-4f7d-9399-e91f1cfb6a9c"), 4803, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("178bc625-0729-4910-8bf8-459e6523769b"), 4529, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17b89c3f-09e9-438e-8c7a-c20ce29c228d"), 4521, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17bba77f-8cfe-403d-ba07-385b1c71c70d"), 4600, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17e1d4a8-4682-46a5-866a-cf9093628771"), 4704, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17eb252c-fb17-4b87-9afa-745ab43b354e"), 4504, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17f3ab2e-fa8c-4d94-b8f6-d79a7dc2b6d9"), 4440, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1818835c-b7da-4426-bdf0-e0dc94e8e2df"), 4014, 10, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("181bcec0-6d82-4f60-b19f-e12dcc2fb15d"), 4557, 5, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("181fbc93-0867-4c11-83f7-019dbc643ed0"), 4207, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("182b56dd-dcf0-434e-aa0c-0d888527fe2d"), 4521, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("182f53c9-316a-4b92-b2d6-38e6b078b13b"), 4662, 2, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("184cf035-72d0-4eec-9cb1-557c90ad5ec5"), 4111, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("187c7f49-3dd7-4a73-b0a8-920d01110cec"), 4445, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("188ed23f-82ee-467e-8d75-d0d19f48a3bc"), 4001, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18b8b5e0-83e5-44a8-8ec5-7a065ed9f749"), 4555, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18e529be-0ee3-4d83-90b8-96fc8facec30"), 4104, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("190a3549-01a7-46a4-848b-21cbfd162031"), 4010, 3, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("193dd0f5-78fd-4ebf-8b1f-6d7e415ab1a0"), 4258, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19a71c37-b09b-45cf-971d-1f0f82c60b37"), 4262, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19a76860-6300-4b5e-9462-1d88ba5b4d66"), 4653, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19cbf293-06f2-4dd1-bbaf-d6a3a1fea1ea"), 4716, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a0f61ff-6d0d-4f5e-9e14-979067c3fc1e"), 4312, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a24097e-36c4-414c-b6ce-e848aefa301b"), 4450, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a641818-dbb3-4f59-bad5-904a4fb5d81f"), 4110, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a745344-1cd5-4652-83ee-733da8e7b44d"), 4300, 4, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a836828-3792-452b-b073-e41fc46e82a3"), 4852, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b0241c8-d048-4881-a0ae-eac2dd3cc2a9"), 4408, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b1674d9-d458-4bcf-9969-46be25a12ce1"), 4629, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b1fc515-33d0-4da8-a7ed-1a5ca798e56b"), 4800, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b20378b-10c5-4621-8a6f-3812e82a5620"), 4622, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b27fde1-99d1-4a8a-8b2d-4835f45f29a9"), 4621, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b3aff25-ae15-4b1c-9b08-83482e18fe32"), 4806, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b40a120-2b66-4abc-9bd9-40ef15aa22a8"), 4551, 2, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b4948bd-0219-4fc3-9d25-8b704126ff92"), 4222, 4, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b4f9921-2791-47dc-8f15-e2c50c706018"), 4630, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b889e23-f2fe-4f12-99d0-449de58650e8"), 4520, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b9df1e9-7e87-4dd9-85d7-3c8865c34d5e"), 4435, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bad7959-a725-4f81-81d0-94ebe90e1038"), 4402, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bb8c384-e549-4599-b9a6-6a72c7b83ef7"), 4013, 10, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bbeb114-3c28-4dbe-88b7-37e3c661e723"), 4633, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bc62cb2-3480-4292-85ce-0088ee2d7d7d"), 4854, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bd20f7e-569a-41de-8d81-4c17be90e1bc"), 4228, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bd69e16-3c3a-401c-8e1c-bda6ce89d82b"), 4609, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bd7f41d-866b-49c5-90f6-ebaf27f35d26"), 4313, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bdfb816-b22d-4e06-b185-97820fd73c35"), 4434, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bfe6d36-bf1c-4c91-b918-4e553778e06f"), 4503, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c090dfa-5264-4ef4-9591-e8fd019a9bef"), 4556, 3, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c2e8240-df69-419d-8a68-7d89ee6c30ec"), 4707, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c3e3caa-3c39-4d3e-9ae9-3f0fa8a4daa1"), 4268, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c5bc3c7-f572-4908-b899-d68da37fe116"), 4454, 4, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c5e9e14-8c5a-4eef-a0b5-37f1c92f1591"), 4703, 8, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ca4822e-c876-433d-8978-885d5e8690bd"), 4508, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ca5d529-076c-4ea1-9d5b-7c3839a033e1"), 4269, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ccc4c27-308a-406a-b110-f34cb2692781"), 4603, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cccae11-1769-43c8-b3cb-63358bf74fba"), 4237, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cdbe91a-040a-4595-8ce6-f3e4a2ac7e32"), 4320, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ce11b1d-36b9-4465-92e6-9270fe13c7f9"), 4246, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ce6dabf-5c20-4c51-893f-8c1870afb132"), 4611, 6, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cef14a0-a0dc-4b67-9eb2-c7a0f293cc1d"), 4102, 8, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cf1c250-6e49-4dd5-a179-f565c14a0aa9"), 4808, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cf9385c-2d2c-4f5f-a3a0-0b0d63867a12"), 4314, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d031d25-767f-48a6-9dad-88ca63239b51"), 4550, 9, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d07560a-383e-40d1-a560-75161c4dfd74"), 4660, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d158beb-e87e-4b4c-a283-8acd40d6749d"), 4029, 2, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d16bff0-0768-4047-af92-07f6d5e0491e"), 4238, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d27798f-56eb-4bfc-8a21-402d6f1b5d6f"), 4452, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d48d70a-02ea-4e81-b511-cfe5decde86c"), 4245, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d748ca1-c207-4932-b4f9-1c0e931201b9"), 4538, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d9475b2-e9fb-47eb-949f-dd098b08d8f3"), 4447, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1db6b1ec-0077-4344-aa99-c9e8592dd075"), 4717, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1dbb41b9-6859-4449-9d39-947468e8adfb"), 4416, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1dbcd1d0-c7ef-46a7-8c01-c40b50303dcd"), 4006, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1dcbb40e-1b43-4f8a-9e08-7cade1554186"), 4265, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1dccdfce-3850-4f5f-90ea-2a126d734c23"), 4606, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1dda278d-59ce-4530-9145-753e5ebb7e15"), 4242, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e050fd3-99d6-408e-b172-f33f3f186460"), 4307, 2, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e0f1515-950f-4ead-9b2f-74f7e93506af"), 4431, 3, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e1f4f1f-c0b6-40ba-b7d0-6dfb03021a4e"), 4655, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e271156-7a07-41f8-9a84-fd9b431aff36"), 4442, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e32b974-0703-4b2e-879c-c6226adfa787"), 4528, 6, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e3e96b5-3fe7-4a37-8339-9d673eadc573"), 4605, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e76d0ec-8a96-4336-be98-124fcebb81f8"), 4507, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e800060-cc1e-41e6-a044-2d399bf463d3"), 4416, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ea49e9b-b7c7-4e0b-8410-46b90b46e469"), 4234, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1efe103c-5484-4dbf-9431-39ec30c87186"), 4627, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1efe9656-9a5f-4b6f-9c3e-dc6a0f77928f"), 4400, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1efed447-350c-4f46-a3fb-185f00273d82"), 4444, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f0da6e6-90cf-4e2b-b0a6-925ec7926eb8"), 4217, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f1b142e-50f0-46e1-b013-864dbbbab991"), 4502, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f201f88-2621-4a56-ab5a-0b3697bf4c66"), 4502, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f20fe7d-8899-483e-8b55-035c004ce772"), 4315, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f31e4cc-8c11-4226-856b-075646b35234"), 4536, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f400e8c-4dd3-48e2-80c7-cec45f510122"), 4500, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f55495b-6fa1-4c93-9ace-9b0b35d35aee"), 4263, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f57a703-90ee-40af-8f8b-93378248108e"), 4456, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f6572b8-d69c-47de-914b-75311b4baafa"), 4617, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f83ba89-89f9-474b-a189-f247452fef63"), 4232, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f83d611-7cdd-4ad0-820e-3e41c508cd4b"), 4652, 1, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fa2e96d-6f9a-4040-96af-89cde82b2825"), 4707, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fb6787c-f0c9-41f6-ac54-5173ded43fb6"), 4552, 1, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fb908a8-72b6-43c2-bfc8-297ff50e5042"), 4226, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fd12704-094b-4d42-beff-fe3e0f6159ea"), 4707, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fd454ef-e438-4992-83ec-ae3cef1402a8"), 4606, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fe1ac88-d57b-4c78-a53f-c052eeeedf23"), 4438, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ff9f177-8054-48c7-bd9c-1d7bad3112c9"), 4723, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ffb8afa-1eea-4649-82a2-4fefa8844f0a"), 4100, 9, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("200c4693-23bf-45f1-89f9-8dd176cdb32c"), 4429, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2015c1cb-d3f4-436c-8de2-44eba189d98e"), 4520, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("201c074d-1dc3-41d0-82eb-f806c363ae74"), 4505, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2030a1e7-8e21-437f-9e0c-8ab8a7306c2c"), 4464, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("203cd838-9dda-471e-a947-8707f539cdfc"), 4655, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("204551d2-2585-4b27-867d-986dde882b44"), 4708, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("205a1081-4744-4d35-9909-8b9bae0803d1"), 4653, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("206655dd-ea65-45c2-a42c-6450fb72e5ec"), 4434, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20777420-ab12-4f2a-8291-581faa4f81e8"), 4213, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2099e127-41e0-4d8c-933e-54d1bbb6ed5b"), 4426, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20b02fa5-348c-4732-a52a-335129894806"), 4715, 6, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20d47411-4b31-4aa0-a9bc-2ad1eab38293"), 4254, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20dbb7d2-6a16-4279-a08d-bb97724747d0"), 4018, 4, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20dd978b-23fd-4ae7-8561-13c682469ce4"), 4266, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20e71679-1fa3-42ff-aed5-94aee39efbc3"), 4541, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20f0f03c-e9cd-4908-bdd3-c75a011447d1"), 4003, 5, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20fc52c2-4d00-4288-8731-e4afe5a61150"), 4230, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21029a5f-b84a-4ecc-ac08-8f615e383549"), 4105, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21086d52-3eda-4b8b-91b5-118f03ebc85c"), 4533, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("212dc7de-bbb2-4c68-abcc-d2e1a8aee123"), 4234, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2135b29c-7bdb-4173-ac06-15dc6a31e77a"), 4619, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("214bf159-547f-4aa6-8952-75186584251b"), 4701, 9, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21577e20-41ce-428c-8ad9-9040fa71c2e0"), 4435, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21635252-09b1-4557-a2b3-e664e6708fa4"), 4451, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21816c7f-a6d3-44f0-8f22-a5f40755b32f"), 4540, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2185f007-835f-4a74-a389-4abcb1d71adf"), 4633, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2187bf4d-80bd-42ab-958a-282be6187ebc"), 4560, 7, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b8e714-6357-4783-9e22-748e57e77859"), 4239, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b9d0eb-e68f-4e46-9faa-e14271cf2e7a"), 4313, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21ecc4ed-36e3-4306-8a10-5220df71f0d9"), 4530, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21f17757-8989-4f28-9428-fe9d28715a0a"), 4505, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("220a86cf-2d36-4624-b9b9-98fe80cd680c"), 4410, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("221fb445-a5ea-46bd-96d1-cf911b0c74bf"), 4247, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22205d2b-b49a-408f-86cf-d1782f379e01"), 4256, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("224295ed-9e92-45d0-ac54-e32eb16fa28b"), 4107, 6, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("225b4156-601f-4053-9c6e-440c2d541455"), 4106, 6, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("225f2c5e-e720-46fd-9b90-da0a4552209d"), 4033, 6, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22627d70-6ce9-414b-8f9d-7f8c0f7d171a"), 4230, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2262e4a8-155d-4806-8027-29c49d9eb3e7"), 4453, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("226eb1f1-7915-4f0e-9e90-1185ea2237c4"), 4317, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("227995c3-9a3b-4132-af6a-ba4d33259b3f"), 4602, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("228d5de1-524d-4d33-b6d5-d9a9208a554b"), 4254, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22c375da-77cf-4e64-87ba-f248568fff76"), 4404, 6, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22cf696b-d40f-4de1-81e6-ea0e08cc0e1b"), 4509, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22d811ae-9668-4c3a-9f66-845adfd1bc92"), 4401, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22fed4d3-01b7-47dc-ad18-1005a7e97089"), 4036, 6, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23395f7c-83a4-4da6-a76b-3e8bece24ae6"), 4800, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23411882-c073-4efb-a398-67e9dc9fa932"), 4420, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("234f7148-4f11-400d-88ac-f67d27c68fb2"), 4629, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23520087-7fc6-4489-abf4-25198ae332aa"), 4003, 3, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("236e73a9-cb39-4943-967b-1215d024ae0c"), 4415, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("237a55e2-a817-4d82-bd97-5cb3528ba6e9"), 4014, 5, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("237fe12f-ab72-4aa6-987f-ad4e31c5f748"), 4317, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2383be4b-19e5-4c20-a268-2965cd2f64ab"), 4558, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("239115b8-f678-490c-a78b-1bb806a915d9"), 4235, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23b0221e-59c0-468e-b740-d203b03c4f2c"), 4631, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23d0ef54-2344-4983-8a69-f13b02ef3220"), 4555, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23e58d59-b57f-4ca4-89e4-91fd63758fd7"), 4245, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24229082-c52e-47d7-8d76-2f310d4d37c3"), 4433, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24287ca7-d8e0-494a-89c8-16c78d4aba71"), 4555, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24405360-31dc-4e1a-b5e0-ab6b95e0c042"), 4418, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24451960-c6cd-4eba-9ac6-71e1d33f952b"), 4615, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24479fde-224f-4b93-96c7-d8cb30dad38c"), 4301, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("244c960f-90d7-4d71-9585-50d2b796098a"), 4245, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("244dc8ae-c7ae-4b09-91a4-8b5dcd8b0459"), 4446, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24622d38-a9e9-493e-92b6-5d8d75af2639"), 4225, 3, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24693c16-15df-438f-bec4-bc13d10942d6"), 4421, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("247599b5-5def-40eb-abbf-ea1e169f8807"), 4709, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("247c2b58-6d12-4411-a3cf-9cfb854c8c20"), 4246, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24825a58-2d3b-4a5d-bf33-3dec1a0cd134"), 4718, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("248c496d-d1c4-452a-8a6f-df6463346d15"), 4654, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24952039-a2ab-483f-abf1-ae0283905552"), 4402, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24964448-3874-4076-9e13-dd0d2736902e"), 4258, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24a172d6-064e-41f7-a25e-4f3a5a4a53ed"), 4625, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24af09c5-c384-42b7-892a-3dd4fdbc715b"), 4255, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24b9d3cd-de6e-46b0-b23f-43af580a0767"), 4243, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24be4f02-798a-4e51-b2d8-edea42c6bdec"), 4609, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24cbbac1-4c75-4cfe-bec3-dc31f631483c"), 4458, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24d2dc22-ed14-44bc-903e-99d7cd352bfe"), 4446, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24f93a55-e437-42fd-91a8-6a85a22092ee"), 4513, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("250e2999-79bc-4b07-88e0-dbefbbb3d2cc"), 4405, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25213bc9-5e59-4b7f-aa48-09255166dff0"), 4021, 8, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("252bf9d0-6f66-4854-a803-32e7dd41c23b"), 4564, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2538e4e1-afbd-4b03-bc8f-51926780510f"), 4019, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25494aee-222a-429e-bb23-159166aaed37"), 4240, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("254be19d-82c9-4007-87f3-385ccd944678"), 4433, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("256e1b05-ef26-4db7-8279-575142e149e4"), 4016, 10, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("256fefc9-15f3-4217-9133-88322b6f5322"), 4219, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25818679-1c5e-4ac5-ae6b-090364c5e123"), 4243, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2592cd37-34bc-4622-b2fe-86148969d7a7"), 4265, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25a36a82-a6f2-45d4-9dcd-b647151128d1"), 4540, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25b3a011-d26b-4e55-980a-f0ee74b66cc2"), 4226, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25f6fb91-a57c-47c6-92ef-1febc0869377"), 4432, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26004dc9-8f5e-43a2-9db5-77a5e4dbfd79"), 4462, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26054713-4b54-462f-b1ed-46838a54fbea"), 4244, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("260a4ee9-29a0-4145-9635-7b6cc6eb4cb2"), 4611, 7, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("261a7533-e846-4055-b251-6cab673a3dcd"), 4454, 5, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26276eaa-4ac9-45ed-aea8-4d652bfb61a0"), 4011, 9, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("265a7ea0-cd34-477e-908e-be9e8b0bde36"), 4309, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2664da19-c143-40cc-86a5-072b781233f5"), 4310, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26804726-ebd9-44eb-ab8c-a529306c0eb3"), 4306, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("268a57b4-ab1f-4d1b-8bdb-b5b46e12ef16"), 4223, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26a00d5f-626f-40a7-977f-327c55c2d9bd"), 4640, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26b7adbc-64dc-4aa3-a618-8ba47d4fc636"), 4635, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26c72350-483a-400b-bb0a-63009162c321"), 4509, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26f04c26-94e8-4b57-9f02-4b3e846a4b75"), 4655, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2708653a-0968-448f-b720-11dc8f534ad4"), 4534, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("271adf17-c3b5-4e32-b093-b1dd9c399ac3"), 4513, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2730106a-5d8c-4653-ae3a-89e8acc85514"), 4204, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2739bb2b-9ac7-47ad-8f2e-463b723de3f1"), 4243, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("273d68ee-20ee-4e28-8939-be480b3f8d86"), 4310, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("274db1e4-06ac-4976-969d-e15cbeb17c8a"), 4322, 9, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("276513ce-9b2d-403b-ae90-4d198866368e"), 4435, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2765f8b7-025c-4223-addb-d9ec475e99ac"), 4014, 8, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("277c711f-d6d5-4715-aa71-cc913a1b3eed"), 4854, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2790c0a9-4fcb-4d2b-a92a-be97d597ffea"), 4011, 5, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2792dad3-71e6-49a5-8c46-bb9f063dee9b"), 4712, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("279e9ebe-9f52-4dff-a234-4b92625606b8"), 4539, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27a9eaf8-d22a-4ffd-a39c-91ee4d8cfaef"), 4242, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27b181a4-0ae8-47cd-b638-7daba0a7e84c"), 4713, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27c30254-048c-4be8-ae15-691f47027121"), 4007, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27dcf5b0-dde6-4d01-9a3a-8dd38c34aa53"), 4613, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27ff3cab-0659-49b3-80d4-09e419987f5c"), 4518, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281a633e-901c-4036-8695-f3ea33d52591"), 4257, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281cb715-2a00-4ffa-a5db-0121536db487"), 4006, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281e0bdb-e511-45df-afb3-2a4977567661"), 4019, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281ffbd0-33fe-400d-b906-acbb5d231a77"), 4853, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("284016ef-2d7c-4ae3-96a2-a15ff1df4fba"), 4517, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28549ecb-413e-4240-a9aa-b2cd86ce534d"), 4025, 10, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("285ff49b-c190-4216-b88f-e4b742f9f365"), 4257, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2867699a-1952-42bb-98dc-40fc34f0b5c3"), 4441, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("287688a4-40e3-410c-9c0b-215e43db535a"), 4456, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("287ffa5d-adbe-44d2-a1a6-8d14ec0a771a"), 4803, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2888a1ce-488c-4657-88f1-6c97ebcd3077"), 4621, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2894490d-2aef-4b5a-ab6c-0277303d787b"), 4639, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28c478c8-e15d-47df-96f5-ef9d495a1422"), 4637, 5, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28d4f894-cbf4-4e70-ac01-3d23975eedbe"), 4112, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28e4c2f4-d3eb-4b09-853d-dc67ee268817"), 4720, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28f1998c-3218-465e-b7ea-67d1f486e2c3"), 4460, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28f26551-726f-42fa-a62d-eb7d467c2b63"), 4024, 9, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28f8412b-3935-41fa-b7ce-8ebb0eb0a21c"), 4257, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29047297-99ad-459a-9f35-13763a5ac85c"), 4005, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2905ee1e-625f-48a9-8288-d36858c4cfa1"), 4808, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("291f58fe-2152-49eb-bfed-418e2786d587"), 4620, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2926f59f-1127-4eca-9c80-8b1f95fbeb88"), 4425, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2928c9f6-48d8-432a-9935-49b6ca7e4a12"), 4522, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("295253b4-bed7-4db6-af1c-6a20c4f58882"), 4451, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("295f2ef9-bb8f-4f0d-b3e0-879ae479b153"), 4416, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("296a9345-138b-4306-8a46-63f29e8bb35c"), 4412, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29775d08-0669-4809-9f07-31473bff17c5"), 4630, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("297a83b3-0063-4d45-8087-b3ff6ef7eb8e"), 4018, 5, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("297bfd64-d9d9-49ca-9360-f8f44bcf3cc4"), 4018, 2, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2980af4a-99ea-4ebb-bc4f-a28f22d2c10f"), 4505, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29963a34-0422-4a55-bdd6-023115c63714"), 4016, 2, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29999153-812b-451f-8a10-42008144d37c"), 4303, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29afeac9-f9bd-4e3d-abd5-805151e8a7a6"), 4309, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29c75158-ef6c-4f11-89ac-3829cbc996f6"), 4554, 8, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29d4ecf6-4703-4656-9bea-e891821b860c"), 4205, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29dc9fde-9c71-48ae-afc1-b6b72907128b"), 4031, 2, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29e71380-e519-444b-b1f3-e3a75702a4ce"), 4024, 2, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29e7f7b3-3dd1-4d23-bbae-de1a074e89f0"), 4262, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29eabc20-b62c-4fc5-9fd8-f91b527b9e03"), 4323, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29ec1a21-4546-4ec3-b7fd-56ad4d049ab0"), 4209, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29fdf2a6-f942-4eeb-99fb-b1e26e110db0"), 4527, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a20f70d-f31f-4cc5-b2b3-25e051fa4a7a"), 4529, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a30f4ad-7aae-4f92-94f6-56d3667dca0c"), 4103, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a35a400-c42a-47d9-a0ba-b0c39796323e"), 4238, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a392893-0205-424c-96b8-cc67cf769765"), 4412, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a54def8-3560-4871-baf9-8ac26288bfcf"), 4407, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a7172bc-e535-48a8-a615-836d5bccd55a"), 4550, 3, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a7b74c0-3b71-4115-992c-671b4d735a0f"), 4321, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2aa1a6ec-b4c0-4b50-8897-de83f525d172"), 4114, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2aa1cd98-712b-41a0-b9c4-42cb9de2fa96"), 4268, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2aa40372-04d4-455c-9988-ff241f210788"), 4530, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ad12b00-23c7-4e18-a76b-0d05fd223d19"), 4538, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ad23685-650b-4e12-8785-5943299f696b"), 4202, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ad6a803-6ae0-445a-8314-66244810aa33"), 4452, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ada9c40-b26f-440e-8b4c-840201dd8645"), 4806, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2aec7f03-db4a-4efb-913f-be21a3fea5b1"), 4701, 1, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b0c7ea4-dc0f-45a8-8661-439eb6bb3d03"), 4311, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b28f285-c7c7-4abd-ae5c-036bcebbe9e9"), 4018, 10, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b2f3c96-97af-4329-ba24-862f6cfd5fc9"), 4616, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b2fe8c6-ae4a-4e35-b52a-1c031ff98931"), 4314, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b4ff2bc-3d22-499b-9407-27dbc5862d87"), 4607, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b515363-fea3-4867-a01a-c781ee5c3ac1"), 4249, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b6ca2c1-5d55-4f85-8680-b0b777bfc0d8"), 4856, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b726192-c314-4354-b0b2-2e97df14a04b"), 4216, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b8b8420-1d18-4ea6-b747-38aef3e3c518"), 4856, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b9371bd-98c4-4d81-8710-c72dcd3c8546"), 4254, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ba218f5-8378-4564-a4ab-e0ad9aa1eea1"), 4435, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bdb109b-bb7d-4d84-90e9-447007da85f3"), 4538, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2be796dd-6687-4482-bd95-260b64c0f334"), 4315, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c072665-e855-47bb-b05d-8a5fa7986f80"), 4206, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c0ab894-ccd3-4ff9-af4f-64f3d100e9ac"), 4242, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c16b04d-e8f4-4f93-a5b4-a1c72791443c"), 4855, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c219a39-6f82-4419-82f9-859467a38775"), 4606, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c245eb4-3246-44f9-9325-d36e1317bd9b"), 4105, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c2864ee-519c-456c-b79f-4436da69013a"), 4514, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c30ddfa-92b7-4bfb-8d24-f7f199ca4538"), 4537, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c363d60-2da7-44e2-8114-63b392b863b3"), 4703, 6, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c403329-78c6-4727-9613-094b875b8b8d"), 4418, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c4206e3-53a7-4214-ac60-81bb9cd31641"), 4400, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c538ed2-3b29-469d-931a-dab1076946fa"), 4001, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c83f62f-87bb-43f1-a64f-6b614c59a9c2"), 4303, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2cb525df-d4e6-43c7-b6cb-898bc0a1e7a9"), 4414, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ccd08ee-fcda-48c2-8ec3-cdb4d4dbb52e"), 4256, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ce9f20e-0114-42c9-905e-29f4597a57de"), 4214, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d2d06ed-32a7-41a6-a017-c4f970965e5c"), 4611, 10, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d347163-b50c-4bdc-963e-74c8b862ba88"), 4514, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d41b2d1-33e5-4cae-985e-3829b8dc6f7e"), 4542, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d5b00d1-5a4e-4603-a366-9bc1c3bb333f"), 4241, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d6a53df-183a-4c4e-9349-a8ba8150fd28"), 4031, 3, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d8f9d1f-2b1e-425f-af83-4087c9bbd45e"), 4201, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d90758f-5c4c-4407-919b-3fad257f7cc5"), 4036, 7, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d944d9b-309d-4018-9043-900e052bfa5c"), 4321, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2db94912-5034-46d3-adcf-45dd8d8df249"), 4029, 8, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2dc4e534-ab73-41ba-9695-61826df73718"), 4026, 6, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ddbf43e-08d6-4edf-9e2d-b33391bf2de7"), 4112, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2de18fc7-8a63-4511-a236-deaf6d9c0e98"), 4422, 2, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e131514-8160-4d1d-b1a5-d5a8bdeb4fa5"), 4624, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e16a2c1-9eef-485c-8a05-b04f4acf3ba5"), 4106, 3, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e200d48-9654-40d3-93c4-960fcde0ddc6"), 4711, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e20e066-5c34-46a0-950a-8dd3452c11ed"), 4542, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e255842-9594-40b0-9061-d4134a6ceebc"), 4520, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e3c969b-f239-4af6-93ac-261dbeb53bc6"), 4535, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e5e51f5-6fd7-4c39-b854-9fb889bbfdeb"), 4324, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e797615-f8be-40a6-ad1b-553fbf381d91"), 4505, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e7c53c4-6399-45f8-8d2d-69ea69bad4e3"), 4514, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e896248-2859-46c4-8e26-0d6283318e5e"), 4536, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2eb8283b-8fa6-4bdd-a3d6-165ec3555ec0"), 4562, 5, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2edcc137-cc65-4a07-8d96-9d357ad32444"), 4037, 3, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2efb0230-e420-40d5-a568-119676f42d1e"), 4236, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f0827a3-4c20-481f-8084-0c72f5466d8c"), 4407, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f0887e6-52aa-4e9f-85a3-630752577abf"), 4620, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f1c2e3f-9ba1-482c-9439-05a1398dcf17"), 4600, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f2091a8-a6c1-4ab4-a564-4329bffb0cf3"), 4547, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f228905-c8cc-446c-8003-04d3e23f7eb5"), 4606, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f248ed0-f7ad-40b0-b1bf-fcad41aef489"), 4270, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f50bee1-be54-45ac-bbcf-2965c686eb69"), 4219, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f983fa3-e37a-4620-aad2-09821386f7c2"), 4029, 10, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fa0bec8-a58f-4054-ae5f-23b0bee726d4"), 4656, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2faef408-8993-4093-b943-0465a2fe999a"), 4447, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fb24606-adcd-4319-9614-3dfa17a602ff"), 4518, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fbd7adb-5fde-4b31-986e-fb452458146c"), 4531, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fc58cca-bf09-485d-9755-7f93b9e197ee"), 4266, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fc7f033-8d71-4c15-858a-ea886289dde8"), 4635, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fcdc400-c1ea-428b-b2ec-7dbaa1265ab5"), 4031, 7, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ff2adcf-1fd4-4feb-ab9e-9b4fe35b55e4"), 4243, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ffb0852-dcbe-4392-9b62-7396f6a28609"), 4216, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("300132bc-5fcf-43cd-a500-d8b6874e0a89"), 4633, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3008ceb1-9659-4837-a144-134d00c96642"), 4424, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3011ef3b-aa75-42a0-a092-3787d2408a9a"), 4100, 4, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3039067f-b0dd-48e4-96fc-69c1e72a4c60"), 4310, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30471f35-0032-4868-bf4f-9b7ca3022536"), 4303, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30497dc8-1294-496e-9699-38d7c5f6c734"), 4637, 6, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30614c8c-9d8c-4409-80e4-2087cdfee874"), 4017, 3, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("306933d9-e4a7-44e8-8247-70615b0b92d3"), 4525, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3086d43f-3e38-4f26-b471-3a4f4f887b89"), 4723, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("308bbd6a-6cc5-4865-837e-d6adca38127c"), 4544, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("308bfa02-0518-40fa-a386-175b84ea2232"), 4561, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("309a7df6-96df-4ea7-834c-49a8843b600e"), 4522, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30b238cd-06c8-4432-bbdc-ac7bc9fe4935"), 4269, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30dcc06b-0c0e-4825-8cc3-a37cf1e01e70"), 4107, 1, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30e4948e-d7d4-4e29-899e-acab524c0b60"), 4433, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30fc2c70-afa5-4236-b2f6-24567bc5e0eb"), 4507, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31087ac0-5dc6-4ec3-97a2-0f2f15974fbf"), 4716, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3119c41f-f5e3-4033-b476-9ce888ba4709"), 4028, 1, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31238407-f8bd-4a9e-b6a6-b1a6231660fa"), 4530, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31318a49-2c17-414b-a7b0-c26f29121d52"), 4020, 2, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3135aff7-6a2b-49e0-b62e-2320c8d0b1b3"), 4205, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("314062fd-bb80-4b71-9515-00e3a197fe6b"), 4532, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31537842-2338-4b5a-8be9-8fdfbe316e88"), 4658, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("315c38ee-6373-423e-ade0-4c7d6dd737b7"), 4714, 8, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("316d7052-46b5-4e53-a123-fd5eb91dc716"), 4423, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31e8b86e-85cb-40e9-b3aa-340d60c123ff"), 4259, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31e8fc76-43b2-4086-ba40-7ef8704f04b2"), 4115, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3204a607-2b1e-41aa-a48f-11e26bbe5e39"), 4305, 2, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32347aaf-1c5f-44d2-ab33-897ac3310972"), 4465, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("324b1987-696b-44cc-beeb-d2a0519d5d62"), 4703, 10, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3252b3e5-c6ca-407b-a2b5-cd3987e2be45"), 4701, 7, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32708169-445b-4fdd-a858-7bb94ee66039"), 4213, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32716269-4d8d-4a7d-bcba-15e7910ed06e"), 4519, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3280c5bc-2707-41db-99a7-1d8d7f7abbd1"), 4010, 5, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32a36858-7b7d-4e65-b4df-5fbf934f108e"), 4465, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32a576f7-857a-4f41-88bf-308b883d621d"), 4321, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32abf940-c934-4a58-b551-b9a58d608705"), 4022, 10, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32b7b81f-c469-4a95-a4c9-b396432127e3"), 4526, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32cdf624-97f5-475f-850c-08d917fb6ee1"), 4017, 7, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32d2aa49-38b7-4052-ad4a-d6ddbbd9e0f5"), 4001, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32facea1-2ddb-4139-9107-039900525727"), 4608, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("331b95fe-d0bd-4315-9804-4a83dd4ea1a4"), 4855, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3327752c-0517-4b55-81f6-cba194ecdc80"), 4001, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3327da17-107a-433f-ab40-25782bd23dea"), 4551, 6, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3335d922-b0cd-4cc1-842e-8640995135a8"), 4006, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("333ccd21-bd38-42f9-aebf-eaf3573cf052"), 4100, 1, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("334a5502-6e05-4d83-8fd7-8abab1872c8c"), 4436, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("335fcd44-8781-4734-8af7-b552163d9d8e"), 4708, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33859362-9ae6-4bca-bba4-b4e881475804"), 4625, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("339448cb-5220-4858-9141-72d57e86fe16"), 4269, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33ad2504-3645-4a7a-8801-48740678917f"), 4033, 7, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33cbc716-26d9-4353-bc35-5af69a210c3d"), 4634, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33ce18b8-ce83-4cd3-a086-66f743519102"), 4033, 5, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33d0702b-7cc3-415a-adbf-f5e2c3cb44bc"), 4407, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33d8bbb4-2844-4081-b594-19e730f56a94"), 4640, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33f6075d-912d-488f-b87b-8a44df97af97"), 4520, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33ff308c-24b5-4e4d-bbbe-a3ac137185bb"), 4251, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3418f97e-946b-4d2a-b3b1-6afada4de4d0"), 4260, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34263ff6-445f-40f5-8223-68f53252ee08"), 4014, 7, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("344c340b-df1e-4d75-b232-5810b33e68cd"), 4631, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3453b718-7e13-4de7-9939-ff2ee3d10996"), 4429, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3471df15-702f-4214-9c19-58743933ae6f"), 4654, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("347431f1-cb35-4d27-bf11-e861ed865615"), 4551, 3, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("349cd860-5b27-4e29-83a6-625cfa1080ba"), 4702, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34aa1765-38d2-43fa-ad95-ecd0975f5635"), 4618, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34c3350b-0af8-4017-b26d-def863c8c479"), 4317, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34d51d64-2b65-4467-ad23-8dd15fbcd1e0"), 4705, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34e2f860-c562-4848-b338-9216573a7f04"), 4257, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34f4dac8-d673-4a65-b43e-eb6470243dbc"), 4260, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35023e1d-7563-4bbc-bd63-1a08c3b9c516"), 4218, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("350665bf-d1ac-4e0f-af11-7105edc8fc87"), 4638, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35260bee-4975-45c9-910e-ecd8b07c92d1"), 4309, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3538e2d0-582b-4e4b-91ad-782f5fda14ee"), 4247, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35480d35-a2c5-4d35-8689-a28bb1515d53"), 4456, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35575fc6-d097-480e-8610-8a1570ff62e4"), 4227, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("356358e6-680e-4cf9-bc71-08b759d0329c"), 4441, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35793fb6-c4c3-4a2c-b472-3da15cff44c8"), 4320, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3580eb9e-ac31-4806-bb17-dbdead28680d"), 4440, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3591a989-e796-4bbd-a040-c67384c6c079"), 4269, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("359ee218-6593-4126-9f5e-3045a93eb685"), 4271, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35a6864d-8443-4f79-bb50-4ee43b747c2a"), 4411, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35b3c3fb-97a9-46ac-9400-e85a5fba23a7"), 4533, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35b5d6dd-ef3a-41a9-8906-91e828f3dae5"), 4210, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35ca03cf-381e-489e-b062-fdfa0d38af35"), 4523, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35cbf597-f49d-4a50-9d5d-b941b68a9aa9"), 4709, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35e3c72d-6e11-4d7d-a430-fd21260218f1"), 4508, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35f10c35-5f89-4010-b17a-eca38c5351b4"), 4612, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35f4f76d-4aa2-4885-8fe4-a46cd34b9e5c"), 4257, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35ff0865-0153-4183-ba62-da647a2e0a3d"), 4001, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3602c602-143f-4e09-a971-6314aedca717"), 4002, 8, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36062dbe-5453-4f6e-8cd5-8b73214b71e2"), 4625, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("361ed63b-5e44-493a-afc5-0ebcd85b8e12"), 4433, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36320ead-1a1a-40db-9b33-90df2d5aca97"), 4410, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("364a8df5-0aa7-4a5a-ac1d-832437113eb7"), 4532, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3651cafd-519b-40c3-b766-c65e9018d4eb"), 4406, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("365a3d8c-db82-467f-9515-31b8cf3701ea"), 4620, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("365a566e-9717-4cbe-87e8-7288b3a04c48"), 4253, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("366cb3b8-d409-4dd1-9a17-107fd215c7b9"), 4027, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3672e306-d931-4ac6-aac0-2ea281b541a6"), 4409, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("367749cb-eee8-4f57-8804-0876c506f440"), 4265, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("367ee730-a79f-4670-b9d1-616da70a1c6f"), 4316, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36814086-cea7-4def-9c72-224cd746eb38"), 4221, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36905e05-0c55-428d-82b0-88757cc94459"), 4809, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3691d1ce-7229-458a-807b-52066a9cddc4"), 4506, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("369fdbc8-260a-4152-ac2d-7fcb8bc23842"), 4608, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36b84b29-7df5-406c-ab60-4b07428f85ae"), 4508, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36bde1da-77b4-46e1-97a7-c4eca700c71c"), 4465, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36c98b96-d2bc-4328-a904-7949540aaa56"), 4853, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36e16055-ec6e-4ed5-a915-34d3b2eafd3a"), 4658, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36e3e375-2485-4c5d-9eab-90bf60a64640"), 4541, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36fd641c-23be-4543-9bf5-5f370a9cc9b9"), 4630, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("371147dc-76ff-43f2-965a-4365b0a93a64"), 4552, 7, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37132bcd-a173-4196-a728-405e7d4a591c"), 4259, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3715ebcb-e82b-4425-b16a-dac56f6ac2da"), 4023, 4, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3716d978-123f-4b4a-bf4d-1eac0e7f15e2"), 4264, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37186278-bd6a-43eb-9476-2e7995397414"), 4712, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("371c37b6-7446-43eb-ba86-4fb6744c4734"), 4019, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3739572c-513b-4ccb-8b59-1302490aa243"), 4516, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("373bb41f-438b-472c-8411-16db65777ce2"), 4427, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3748d238-bd32-407c-858e-ac59f486b82a"), 4657, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("375e536d-7e04-4e63-aa4e-d6aee31cbaf4"), 4563, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3764f9ca-d49e-40cf-9942-0c953e26e305"), 4014, 4, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("376653ed-81a3-463c-81c1-c25fadfe37de"), 4604, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37673b63-ed21-4621-a22e-0a2a2667718c"), 4422, 9, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37b3cb75-68b1-472d-8994-8b8b8c0d985f"), 4715, 3, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37b61595-048b-42f9-b810-1cc1de00be58"), 4810, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37e31f6d-af19-4015-a455-81c29af03440"), 4250, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37f28e91-ad92-4570-8c4a-7773f6d5dc05"), 4433, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37f6f8b5-4a30-46f4-9122-064fc8bd4db7"), 4526, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37f7c9a4-cc5d-4b85-becf-3ba31f8b87c2"), 4802, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3801a32f-c7ee-46ac-a9ff-ac6056978e90"), 4711, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("380522a3-7486-4bda-8ac1-bbdc2f66c30b"), 4421, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38071019-3b2c-4f13-9391-bde3771d5905"), 4602, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3809a521-e729-4da1-a04e-f64a28ca2579"), 4313, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("380cc058-d7f5-4c29-b92d-aa11799b3b4a"), 4451, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("382466ee-3434-4c85-8191-ee392fbf361d"), 4603, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3826358f-9260-4673-8d3b-f8b7cd5f10e3"), 4565, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3827876f-33ae-4306-816b-7d03c4b630d6"), 4609, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("382a281c-0471-4c47-835c-1cbfec25097e"), 4206, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("382baedc-cd49-4e59-83a6-2406989d6a53"), 4465, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3836c2c0-a50d-403d-9193-e2b5b9f6d353"), 4716, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38387f5a-2430-4ded-8ad7-025d06b60ced"), 4251, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3846e866-c620-4521-85a1-27b6022ecec5"), 4005, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("384f12d8-b921-46d5-aa0b-5b7aca0f4292"), 4451, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38605d7b-2681-4fad-ad34-ebe1d29bdebe"), 4701, 2, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("387713dd-35d7-470a-9475-30fb2f757745"), 4430, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38818c14-8037-4442-ab04-075e2e43e8f4"), 4213, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("388ba175-a2b9-48f7-abbb-bdd2dd32a9ea"), 4810, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38983d64-84ec-4f78-a1bc-1b2a8bc97631"), 4109, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38a7f3e5-03a3-4097-965f-ac8ae64a66fa"), 4709, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38a918e9-dfc3-463a-864c-4dbc1eb17218"), 4203, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38ac9689-6074-41e5-ad13-0dc44f3fb55e"), 4516, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38b5b499-e3d3-494e-acd8-0dc0753d6dc4"), 4536, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38b8aea7-5b6a-4e9b-9931-9cc03188f79f"), 4709, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38cc5c0e-da33-40f3-8ba4-fbdd41601526"), 4400, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38d24430-799f-432f-95b4-54887e7ac106"), 4223, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38e03f8d-579e-4516-9288-47878e4cc0ce"), 4415, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38e8fb97-6ff2-4eee-a70a-6c23e15a82d4"), 4023, 2, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("390afdc2-7aa5-49d2-ac46-89da4606807b"), 4320, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("391bcc20-710a-42d0-b707-a438ac878417"), 4036, 8, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3924ddac-5d3c-4355-89fc-17eb925d83d2"), 4853, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("392809f1-a100-44b3-b0b7-1dde69ecd60e"), 4029, 9, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3933403b-b21a-409f-b910-a4ce59a9a611"), 4270, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("393bdb1a-6b77-4f4b-b2be-9bdb40435ebb"), 4612, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39764587-6589-4d10-ae50-28cddb76fd5c"), 4027, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39804a95-3b13-462b-85da-b27fb06b2ec1"), 4260, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("398f278e-976a-48b9-932b-dff3218da825"), 4720, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39bc6024-e1d3-47a5-a769-21bda4991dc9"), 4268, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39c37c9e-3466-4495-96f2-4a4ba37f3236"), 4312, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a29d01d-1eb8-4bec-a912-5fcaa44ecded"), 4524, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a3f3e78-14a5-4817-9b7e-a98185607b88"), 4853, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a43e16f-3a7a-4e70-bedb-72c08c08cb13"), 4252, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a7850d1-e463-4590-ad30-c567a6f53291"), 4714, 1, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a8a3744-abc6-4fab-bfe3-9f4f1469cc7e"), 4532, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a91f1e0-51a1-44c8-b0fd-1aa998671e09"), 4600, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a922732-c434-4258-ace1-cc70a846607b"), 4414, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a96eb92-7f55-47f6-85b8-2b5fc7c75b4e"), 4719, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aa565bf-69e8-4e46-985c-2f7544f4ddea"), 4622, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aabb7fc-f01f-4bf7-992d-d8eb7c8e01da"), 4525, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aae40c9-8107-463b-89e6-576567db8de9"), 4421, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ac9e0be-cddf-4c42-af15-71f9a492d8bc"), 4554, 1, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3accc984-3f9e-4323-8f96-73f56f73d278"), 4629, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3aee328c-40da-4d03-bac5-42de4c95c3b7"), 4414, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3af3405c-ea47-4a3d-96bf-1f7398029dea"), 4012, 1, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3afc4e7a-4aa2-4b49-975e-cd25a336e8c6"), 4703, 4, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b09a950-6921-44fc-97f9-967af3da429a"), 4025, 5, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b1678d5-beec-4387-9aa4-40cd90b33b9b"), 4515, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b1e9e6a-d1b2-4947-89ad-fa627db3353a"), 4856, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b245240-90f6-401c-8e6b-fcc34b782491"), 4404, 9, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b41a94d-c97b-4ebc-94bd-c4c1bb1347be"), 4809, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b51be9c-56fb-4f0b-b691-1a8683f8fa41"), 4018, 1, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b52502b-c539-4b54-b8f1-ce569b7275fd"), 4805, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b562f26-2c37-4bc3-858e-6cd950714c00"), 4560, 1, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b5c2df8-8f98-4a16-af7d-d52eda9483c4"), 4401, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b5ca9a9-2b82-4b62-82ed-134f7623462b"), 4105, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b8ee064-7cc2-4d8a-b5fb-550745419dbb"), 4602, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bbd7b1e-ad4c-435b-add0-1f0e1dd1b241"), 4230, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bda173f-fb9d-44ff-b725-6bfb908573d8"), 4723, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3beb734a-25be-44c9-b9fb-2df812d007eb"), 4625, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3beeae26-3f5d-4329-bd83-58177dbee5e5"), 4435, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bf3a3d8-b868-46a7-930c-84446dba0740"), 4222, 5, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c0a082d-b157-48cd-88cc-a3adf65e6905"), 4423, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c1d8853-57bf-4342-aa7e-665ff56c9f8a"), 4240, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c2894ba-5294-4bd4-9149-7d019ab46fb4"), 4034, 7, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c2d7344-c1a1-42ab-94e1-0e16d90d5e03"), 4544, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c3c7ac0-1fdf-4c54-b6e7-066e097d30f8"), 4500, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c4e9df6-8377-4aa4-bdc1-38743ebda19f"), 4601, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c8a7bf7-1d4e-44f1-b01c-70850ca210eb"), 4270, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c8eff2e-30d8-4cce-88a9-ddd62efee8f2"), 4620, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c8f58ca-1553-4ada-bd7f-d0c4692cdcc3"), 4012, 2, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c97c02d-45ae-4eee-b23a-902b0ca7f701"), 4639, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cb30839-c841-41db-b3b1-0d0cc466ab11"), 4714, 5, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cb48506-21b6-4cf2-a10a-8895f848d6fd"), 4618, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cba82c3-4e17-47bb-8d4d-7e0d537dd315"), 4411, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cbcde00-ee3d-42ba-9e55-1c8e073c1763"), 4462, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cd77f26-c2fe-493b-b696-c31480c4f5ed"), 4260, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ceac1bf-9535-4131-8d57-73594fd924c6"), 4557, 2, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cef4e81-8a38-4218-8923-2a075d80939d"), 4626, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d22276c-37c6-4ca0-9c2a-e33be8156abd"), 4654, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d256866-5684-45b6-a576-c78d65b2f2ac"), 4461, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d42a55d-7544-4c80-aa93-6b0d31f5d857"), 4511, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d449a16-44a9-4b49-8341-361e675cf3c0"), 4105, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d463914-c4d9-42a8-b5a9-f5d664ade881"), 4628, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d49f6b7-5be2-481f-83aa-df273203a60d"), 4556, 9, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d56fab9-38ae-49f0-a8cd-0d6f67f23453"), 4248, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d5c3997-f4d0-48c5-8623-92cd0b6a8849"), 4659, 5, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d93df8e-d4d6-4e7a-89e4-52e7870359a0"), 4234, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d94d042-a1a1-42b4-b96c-ddbf079df3fb"), 4215, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3da1b86c-39e3-4a8c-a04d-61fbcd6efad5"), 4802, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3da89353-c9c2-43d9-adca-03cfa065faad"), 4444, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3dab7ba9-4486-401c-b6b3-f3487f4484e6"), 4409, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3dc7bd63-6163-4e1c-8035-2feb17500a34"), 4703, 7, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e01de9b-47c1-4ac7-83ec-0568ffb4785a"), 4663, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e0c738c-94c5-4718-a44e-ac907c147bd0"), 4308, 5, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e16ba5f-1f6a-4f2b-9fb5-dd52de7ae7d1"), 4609, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e1e9a20-3640-4e93-a3ed-e27507aadcb8"), 4703, 9, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e2d5b5d-e89b-422e-b66c-fa86c1883a57"), 4435, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e2f1f48-c0d3-4bdf-aa54-e428c2f47072"), 4513, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e42fd54-a0a3-4f73-bb6e-540bc820b583"), 4442, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e5e125d-55c5-4cad-8842-1d7607206dbd"), 4619, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e7c5625-952f-4aa7-833b-2b03bb602509"), 4711, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e8a5ad1-2061-495f-bb42-e2b82512583e"), 4008, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e97d939-b6ad-4f5b-8d3f-1327d7554a13"), 4656, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ec44964-d8e6-4069-8c16-cdacff258ba9"), 4253, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ed44e1f-0096-4e87-8b57-3634a2a46c3a"), 4311, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3edd0cad-180e-4d75-b24e-614bbd1954ef"), 4400, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3eee48a2-203d-4853-a10a-6a675495e844"), 4701, 8, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ef04dd3-d3d2-47d3-a161-29bf7b278f4b"), 4614, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f00202c-08a1-4aad-b201-78dc815eeff5"), 4717, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f0510c0-0968-4889-8648-6c100b5f6112"), 4256, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f2d0220-6879-4842-bab6-68752f632ef5"), 4254, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f3036f9-9cdc-4d70-a4be-b9f7cb15ce68"), 4410, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f4d853f-fa94-4ca5-8c05-bc4503357a8e"), 4403, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f6f476d-c781-47e6-9cb7-830c3fbee5de"), 4501, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f793a8e-59be-4d0b-9fff-4719a49c064d"), 4628, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f7fe59a-dc86-46b9-9780-dc011dccf44b"), 4713, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fa01196-8c95-4558-bd51-0905eb83ee1a"), 4619, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fc34b31-2853-417f-ad4c-0d61834a1acd"), 4630, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ff148df-4876-4c40-9ce9-90f6935b7450"), 4302, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ffe7078-9fd4-4019-8c27-004744d3803e"), 4002, 2, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4005da3e-a340-47e7-bea1-49d35962aabd"), 4620, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("402540f8-a7bd-438a-b3cc-e668ce1a4adb"), 4245, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("402cdb8e-30e4-4e76-987f-7da5d63f0335"), 4604, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4030bc5d-c7dc-443f-b05d-e5c59a4f5f13"), 4419, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40b4a2d6-2a23-4740-9567-6d7b889fc78d"), 4641, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40c52e40-6f11-411c-b878-9546a69eabee"), 4419, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40e0ca0e-7844-4839-aeac-68dc0b2f00d0"), 4255, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40ed9bfb-1ad9-4a62-818f-29e4b1456918"), 4437, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40ee93c2-3d32-4043-959e-73ae78a99212"), 4222, 6, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41239860-6867-4421-894c-e3d686376334"), 4536, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("412f6e11-8a07-4a0c-898f-f098b30db565"), 4219, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("413ce410-303a-41fe-86fe-b961f66b7575"), 4516, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4144e1d8-3e8f-4375-a2d8-ab9560f92f84"), 4227, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4144f530-2773-49d3-b505-1e6eb28bb843"), 4656, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4149d129-729f-4147-b542-e7ab5e3bc0aa"), 4225, 1, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("415e8abf-6cf7-476b-b71d-c9d6dc99ad60"), 4252, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4160c04d-324d-47d4-a2ec-8140f41fc8a6"), 4409, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41631b50-dad4-4c30-971c-2c97a5c990d1"), 4455, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("417a3d82-ad89-4c56-a71d-e0c831be58f1"), 4509, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("417de028-4ceb-4e8e-b0d9-ef4b4af131ce"), 4802, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41837eda-5598-4c35-af88-8ebe8a5cb430"), 4106, 1, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("418528ed-3547-425a-b1fe-1fcfda746321"), 4442, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("418be272-b685-402a-8da9-6a4018725d1f"), 4400, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4194febc-4d17-4b78-b582-507d5b8211bc"), 4260, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41a3fe2b-6f00-4e7c-8b23-a7a97c270bc3"), 4602, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41d29a72-d792-4964-a4dd-9281992129ac"), 4803, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41f287c1-c20e-4d7c-ad94-68fecd3ee13a"), 4211, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41fbe44c-0f46-4c3b-b10c-762b1530321b"), 4559, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41ff8b40-d2ce-48eb-821f-a7adc65f42b0"), 4614, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42092fea-98db-430b-b5d1-4607f68c3f64"), 4244, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42144945-a4da-4227-ac60-27851e442d04"), 4803, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("421f0454-576e-4abb-84a3-0028f5bb9cb7"), 4244, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("424832c5-4f34-4c87-ab3b-f3402c721269"), 4634, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42542dbb-7a76-4ce6-82d0-3c5fdc95dfd2"), 4324, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("425be978-5257-4fdf-a06b-4127765a3e41"), 4241, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42675ac6-dbff-4217-ad1f-b76e8b391421"), 4017, 5, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("426b326a-8afe-414b-9ba4-d155a2ac117f"), 4263, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4276dced-af32-4b3f-8e9b-1728aa324987"), 4854, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42853bed-e313-4d08-9543-e6182aeb3f4e"), 4625, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42a6bfe9-affe-43c7-b30f-25d6a09a0a2b"), 4109, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42bbc784-c3a2-4fe0-be33-0260d0f4fdba"), 4540, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42e1f870-a1f9-4663-bc0d-64870df54c8f"), 4112, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42eba211-477c-4a5c-85c2-8e8463a32bca"), 4610, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42f88a63-a53e-40d5-9a63-de11e4a74cb0"), 4036, 9, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4309c86b-d096-4985-9923-ee1acb147867"), 4519, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("432c5386-0ad4-4213-9076-5a506ca770cc"), 4229, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4342e5e9-38b5-4500-b195-9498d3026fd8"), 4517, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("435814f9-6445-4d23-9f40-fe467cae8b94"), 4320, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("435d1f99-4d8e-4cfa-b221-7ead3c07b3d2"), 4709, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("438622fe-51b8-483c-96da-5d1112049bdb"), 4440, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43a9e559-65b7-4b9b-83c1-4815f93b53de"), 4251, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43c45464-282c-4912-964c-3a04861a04a6"), 4661, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43c5ed9b-1fa7-4bdf-8fc8-0a5c1b115e03"), 4639, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43d07a4e-fd88-4d89-acec-4685bb7f3989"), 4428, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("441eb4f4-8fab-459b-9ea2-b7175fcd43b3"), 4512, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44372b38-5c35-4878-947a-f48d2e02e483"), 4564, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("443c4159-67a9-48c9-b5db-7f7d12b63947"), 4113, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44568504-8780-4baf-822c-05b9251295c7"), 4306, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44886970-61bb-47c3-b628-228035bee1a2"), 4246, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("448ebddc-cc8e-4070-ad8c-f32566eb9577"), 4554, 6, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4495daf9-f49e-4a4d-b8e2-855cf98cb3eb"), 4221, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("449af074-3060-4df2-b1ae-44f88695f0e8"), 4108, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44b4b600-bc3d-463f-ba61-6319576c93ae"), 4610, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44b8bd44-81bd-489e-83b9-c2e0e5f8c875"), 4254, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44bfdf50-726b-4067-bddb-09fe3ad83caa"), 4459, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44c1b81e-95fa-44f1-9cc5-9822aa7a8350"), 4460, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44cbd8b0-a3d0-475f-9418-dfd441493cb2"), 4435, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44d016f2-1b52-4c61-9d5a-2f1adb3b66a0"), 4450, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4523b90e-2373-4fe3-bb97-5bedd3f18eae"), 4408, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("453774cb-7081-4f66-87bc-8090c437b1fe"), 4300, 7, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("453b3825-81ed-40cf-b5bb-34845cda67aa"), 4035, 8, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4553cdaf-f747-48ce-b821-691a9a1c2f03"), 4261, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("455fb01e-1512-424b-88ba-a7f1a3246307"), 4709, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45767c81-6a5c-4802-8c17-1f5f7f62125f"), 4266, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("457a9c74-0520-4add-ae56-35d0520326a4"), 4552, 5, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("458fe7ea-7b48-413f-b784-d9d1b4dcd2d5"), 4036, 5, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45a1e6a0-c030-43c7-907f-1367d1e20623"), 4537, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45a55982-7f7f-499d-b5e7-e80d1f0aceb6"), 4249, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45a94f5e-01d7-4f61-a1d2-3af26bfb4edb"), 4233, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45b5f201-7027-4271-aa3d-7d3df20e3c85"), 4259, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45baed78-bc95-4c96-af42-06db6a6c5e55"), 4537, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45ccf4da-7f78-4e88-a7af-8bf47e849899"), 4851, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45d7ba95-5d72-42a1-a2e9-75ed5f153783"), 4009, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45d89ce7-5cf5-4413-b51c-e3acc1b22b9d"), 4513, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4609bf6a-74ce-4337-b173-2a0b910518cf"), 4221, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("460ecd42-1b5f-4a0f-8464-1db0e8f98edc"), 4408, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("461ab60f-0267-449d-9fc0-72a7492dcc6a"), 4605, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4645ada4-7270-4989-b064-242859e5ba50"), 4722, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4646ef88-c394-4dc6-961f-6d2d57926425"), 4521, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("466ae974-3b5d-49a2-9d8c-e5dcda629905"), 4024, 7, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46796937-b76c-4ecf-97b2-d6ba8b6ecc86"), 4307, 9, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("469e072e-dfca-4197-a64e-32e84fd1fa79"), 4615, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46abc0a8-ae26-434c-930f-6fb7c7aaf664"), 4520, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46b85fe2-24cd-467d-b69e-453b0d21dc07"), 4314, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46bb8f16-8355-446f-92c1-d6f06e1bd174"), 4633, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46ced8fb-7f1f-4f6c-92b4-7b6d6ffd936f"), 4249, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46ddb131-0298-481a-b21e-63c81c21d762"), 4438, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46ffff9d-fa00-48dc-afee-f83ec74d4600"), 4402, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("470a0238-8648-44c2-b609-7078fbf6e0da"), 4302, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("470a04f5-8b49-41b0-9b78-0ffd044f3d6b"), 4609, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("470ce36b-63c1-4538-852c-3986ca9ce665"), 4852, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47170094-f30d-4cf2-81c4-5c1c581780c8"), 4033, 1, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("471d2800-83f1-4812-b44a-343a67c36efd"), 4856, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("471dadac-cc57-4577-88d9-5ab4691f1f3c"), 4661, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4742a368-99b8-490e-9f32-6aae20164baf"), 4504, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4750fa5a-2b23-4efd-9334-85d65f337d41"), 4445, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47521fe0-2dff-40e4-b8ea-1cdba125eb42"), 4722, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("478b138e-6ed8-4e3f-945a-ab9713d4d5a3"), 4608, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("479f477f-8008-4245-9b85-69acaddf0d7b"), 4439, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47b3ab93-f06a-464a-a637-1d8224e6deb2"), 4101, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47bcb624-cc91-4e4d-bcf9-f71cb7f78d72"), 4533, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47c50325-8225-4c5f-a7a5-a7e40e6a49c6"), 4441, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47c7213a-20dc-4eb3-a6fe-31a34f4a949e"), 4227, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47d55a7f-d48e-48c3-bdad-ef871bd9f9d1"), 4204, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47e613d8-25ad-47ad-b309-cb31ebcff58f"), 4272, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47eb0552-e80c-4f6e-9873-c102e9bca2d7"), 4030, 9, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4808c82d-dbcb-4e0a-ad34-d50211371670"), 4106, 7, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4809c27e-dcb3-4409-8f1f-7cc2b2aa4846"), 4114, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("480f07f8-b0a8-433f-a3f5-8f19abd242f1"), 4265, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("481eaa17-d484-4663-a129-195d31c213e3"), 4267, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("482256b6-a480-4714-91b3-f39e1f3873ce"), 4545, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("482e5c87-15d8-4815-aa47-037f8d1ec561"), 4457, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("482ff77f-ef3b-4f3a-a15c-fd4ab3a467ea"), 4412, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4836067f-75a8-4732-b2bf-de861deec4b6"), 4231, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48505e3e-df1a-455a-9030-8b8c9c7f5a54"), 4460, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4856bbf9-ccc5-4587-9c90-3765e44ca799"), 4641, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("486119f1-3f6f-425e-8e6f-779de680c491"), 4621, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48bb1265-a72b-4fc5-adba-c2e0097a6f67"), 4502, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48dd3382-f0c7-409f-8a43-4d4bbb1f61d3"), 4612, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48dee73c-8171-4d7e-900f-e8ef0b454ff8"), 4217, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48eded90-02b3-44d8-b2b2-8cd2c0e2ad75"), 4545, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4918ca7c-2d55-4d48-b794-ed597710dd54"), 4553, 8, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("491e63b7-5193-4964-9d68-187983e51c29"), 4316, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4923b008-06c5-4da1-8ee9-ea4f573cf600"), 4206, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4923d172-d09e-4544-bef0-8595d1e2faed"), 4565, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49346fcf-d9c1-4d45-a877-35a46aeffb02"), 4600, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49389ec0-50a5-4f6a-9f66-1ec763c4f6f1"), 4651, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("494002a1-c541-45a6-855d-8cdbc7177819"), 4213, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49443143-91e0-445a-8f02-4011ac16ad81"), 4552, 3, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("495e7538-9a22-4065-82e9-99cc78fefa6e"), 4850, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("496b1250-f834-499d-b6fc-2db2861a3cef"), 4301, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49793ab2-3d8b-4b18-a032-c0663a48f1bd"), 4556, 8, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("499be25f-5ac4-48ad-ab03-c047671b9a68"), 4520, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49ab24d3-9bfd-4719-bdd0-a94f739665d0"), 4509, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49c11cbc-8444-469b-a2a8-cf084a778107"), 4314, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49c20221-fd0e-4541-9346-f1dde52e4cb7"), 4004, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49e69aad-f958-4da8-bd0f-da093ba6deab"), 4630, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a035d39-255b-4279-b3b2-eb07403a1f3c"), 4425, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a4060bd-bd15-482d-a50b-00097a35a889"), 4621, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a504fed-225f-421b-ac1d-e76dca7d3cb3"), 4544, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a722b80-0ea0-4609-8e23-d6ead5a7deb3"), 4547, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a84ad34-b514-4ed3-be20-97dc2a80bae5"), 4414, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4aa3dd12-d7ed-4820-a02b-181579ee02e1"), 4420, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4abcbfce-3e30-4473-8e2e-8421999e971b"), 4604, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ac0dac8-d971-4602-a527-43db28782c32"), 4101, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ac5608d-edd2-4f2b-8fed-d5d4b137c591"), 4037, 6, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ad3b030-cab7-4d10-bb3f-b5f773fcd5b0"), 4233, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ad4acac-c9d2-4f6e-a379-244a1a64010e"), 4500, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ae0f9f1-f04b-4ff5-92f5-0d3deb2d3139"), 4632, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b04a52c-74c3-4b60-9418-7cd3eecb35fd"), 4217, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b17241d-51a4-472e-bdeb-136808d163e2"), 4406, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b21a4c2-046e-4f9b-9b8c-3f959c8f9fde"), 4421, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b2f2e77-1751-43e1-b6e2-031ffb8d12e1"), 4512, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b30f0f5-5202-40ac-8ee6-a57a0f0dea4b"), 4111, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b3fcbf9-78a5-4efb-ac08-f1eae8507eaa"), 4016, 7, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b51a35e-a080-482d-89df-5ea2ada479cd"), 4404, 4, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b71d094-1ee0-4644-baef-76e107f7b5f0"), 4524, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b77314f-2dc7-4d39-b892-ae3c799b8c00"), 4717, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b8a9985-f8d6-4b0c-af41-dd803fcd2389"), 4711, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b941c2b-fe35-4e55-a822-a5052c960c72"), 4541, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ba767f7-ace7-43a4-9141-0f8a49424ec8"), 4611, 3, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4baa0dcb-e811-4695-b1c9-e85eb1597a3e"), 4853, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4baea1df-9a9c-4d14-9244-1871dbc24110"), 4436, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bbfcdce-c051-4867-a9ff-150e541e7bcf"), 4615, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bc4aad4-f7e3-4ed7-9aaa-ad62bf686457"), 4527, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4be3fc84-470e-4c52-8d33-7690de7fabe7"), 4240, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c307612-4762-4ce8-8d2a-dd979f1bfb0b"), 4430, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c362d2d-129e-400e-bf1b-e0b2ebfe401a"), 4505, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c559cb6-0152-47bc-999f-69298f5a349e"), 4237, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c58e89c-2520-453d-b78d-65b6e7f6a347"), 4432, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c6c4e3c-f970-4869-8689-ebe9831035ae"), 4251, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c81f2bf-dae1-4279-9408-765fce29652d"), 4629, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c89e03c-ae17-463e-abcd-5aad26954dfd"), 4626, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c8f8542-220b-43e2-80ff-b4bd791d287e"), 4316, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cb86e06-c2be-41b4-9562-6184aedcaf22"), 4530, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cc1092f-eeb4-440d-8586-b6ffd385107a"), 4801, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cc69f26-9f0a-4ae9-b5bd-39a4f5be9da3"), 4240, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cc7d71c-1ec5-4c2a-9ad0-4e62167bf7b8"), 4529, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ccee01a-2653-4d63-9251-1cd80ae7ddde"), 4102, 3, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ce14f58-7c23-469d-a546-6037cbd80ea9"), 4603, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cec3304-c8a9-422d-b86a-f8cfe4dc9568"), 4213, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d14b855-426c-46f3-972e-382dc7d1949c"), 4403, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d152e16-f81e-4399-85eb-fc7f75dfaba7"), 4242, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d285a15-ed81-4c24-b467-26668e248be0"), 4406, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d4d24ee-a8c4-42bf-ab6f-0f984054b34a"), 4623, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d4e392e-8937-4f7b-9d58-ca4eab3d5497"), 4258, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d60e166-844f-4d84-930f-057e7e309d66"), 4518, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d74df83-c134-4cb4-84df-c932bf238166"), 4016, 3, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4da4781d-9dd8-440b-97a7-c7333cb2ad46"), 4203, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4dc3a9ea-65d6-4905-a7bc-703f454e23e5"), 4564, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4df00198-fd4c-4f8c-b96c-493d653dd5b7"), 4028, 7, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4df9e444-bae7-489a-b656-c983d842bb51"), 4521, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4dfb0c40-298a-4e49-a111-af548412f315"), 4800, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e04e6f2-6a36-47fe-af3a-ad0f38ba469e"), 4510, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e0b0566-31c8-4f57-8cbf-03abef75a131"), 4260, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e1f812c-a946-4838-986f-224c83064063"), 4237, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e300cd6-10f3-4f9a-b16d-9533d2e8df85"), 4216, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e368392-4970-427b-a626-c151dd0818eb"), 4034, 4, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e3a54d1-1e59-423a-b752-6ccd26318860"), 4627, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e454933-68a2-4288-9ca0-13ad4e2ba011"), 4111, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e7500a2-9ef2-44ec-8f58-aa48fa0e30f0"), 4454, 10, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e8d707c-c960-4149-a253-353f7d07e0ae"), 4518, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e90aa34-5b28-4046-ad87-c159017c119b"), 4503, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e937a76-3002-4dc6-a073-6099168cf9f9"), 4641, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eb3161c-3c7c-43ed-8c8e-bcb588b02320"), 4808, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eb7a693-0939-4f17-9abb-1fe298949f29"), 4224, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ec373c8-d878-4c05-b4bc-7e82cb9ded49"), 4265, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ed16272-1d64-4f3c-ae3a-839b1dc10b5b"), 4267, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ed66322-42ff-43f6-8abf-14a91b9b461a"), 4850, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eecb5e5-274e-4c4c-9615-e997f5ae0003"), 4227, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ef013b6-e11d-4215-8917-949e567345d2"), 4611, 8, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f06c429-653e-48ac-959a-7c8f799074de"), 4558, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f2cfdcd-f6b2-4343-9ffd-ffaea296dbae"), 4414, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f368613-0eaf-4a57-a2d4-0ae66bc8c4b1"), 4518, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f3a5012-8c82-416a-a293-462c6756d4d9"), 4231, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f3e0cba-d81d-4c5b-b07c-d27e3a0b5993"), 4212, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f5a6626-e1c5-4d50-b0e4-36ecb7c377f5"), 4238, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f6a3537-0fa4-4b87-a483-d604bd0822bd"), 4534, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f769688-c1ca-44c2-ba55-c2e20de7f0c5"), 4273, 9, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f7883ce-cfc1-4582-b0f3-f890a2374c57"), 4512, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fb7b707-2db3-4451-8b61-f67e257b10e6"), 4220, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fb9b532-7542-4d03-9e3e-840119b7f9db"), 4539, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fc9a24e-aeee-495a-a15a-5aa493651525"), 4565, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fcfcaff-1a69-489d-823c-c4e1ebf44cd9"), 4563, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fd13daf-7003-47e1-a22c-e852269c210c"), 4636, 10, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fd4f1d7-e710-47ed-927d-787ccae42e3d"), 4510, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fdcbb68-3652-4b2c-ac2c-4d42bc80d099"), 4523, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fe7f830-9904-4aec-b706-d361615577dc"), 4304, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ff6bef9-c5f5-4ac2-936b-bd55dce87803"), 4622, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fffec0e-1e64-4ca0-bb39-b0246e0f9799"), 4522, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5020d70c-3910-4a42-bb36-48f33fea65aa"), 4034, 2, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5037e527-1623-4983-9d2b-d8aff38bfe7f"), 4555, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("503c23a3-c880-4870-bf81-e21782139e1d"), 4232, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("504ca0d2-8442-4e6a-81ba-469e3f094f9b"), 4245, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("505b2cc3-6ac6-4874-9a31-682e8222259c"), 4624, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50665363-e319-40cf-9223-2483a7e7dce2"), 4418, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("507aab80-015d-44bc-800b-72f3f17e3063"), 4305, 9, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50844117-c532-45a6-ad56-93fa80436d41"), 4317, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("508469c0-9f16-43eb-8930-69790dd55402"), 4551, 5, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50a3f22d-f5e1-456f-a5f0-0964dd46daed"), 4704, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50ba2a82-ddfb-40ad-ae0e-a768370a1c60"), 4215, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50cd1b11-96bb-4a25-8087-66509384b186"), 4610, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50eb1150-d5b0-4c99-9757-150a8a895416"), 4708, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50f441ce-2e09-4f00-b449-0d8a27d0c022"), 4563, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5113fecf-91da-432f-934d-caf4899642b0"), 4715, 5, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("512a54dd-1657-44a1-9f87-d5a5f0eba538"), 4310, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51395dcf-34b1-4f2c-a6bd-bf1b70f181bd"), 4655, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("513aaadb-a698-43f3-bfd8-a1459aa65dc4"), 4805, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51474ccb-156b-4539-b211-e8fe0a5c2234"), 4528, 1, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5148fb26-a68b-408e-9f1e-561423bc784c"), 4241, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5164205e-0f12-4110-a1a9-c8836e445a3d"), 4501, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51a5ceea-193e-475a-b0a0-fea95bdb6deb"), 4561, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51a849c1-6af5-4f97-a0bb-2dac288c11b3"), 4432, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51b02a0a-c53d-42c9-8e58-ab12358df386"), 4032, 6, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51b169ee-1786-4637-b417-bb4146a5da09"), 4715, 4, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51b19935-aee8-483e-9640-093573e08d0d"), 4031, 4, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51bd7534-f40b-42a5-98d2-ac87116cac4e"), 4261, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51ed2315-c44d-408c-bc11-657de638208f"), 4015, 10, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51f7b526-00bd-48b9-b237-0391baa163e3"), 4004, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5206c418-8afe-4d59-9d1a-f4f16c8f3893"), 4104, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("520d23a8-5c2f-4633-a6d1-8080773c689a"), 4319, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52130ec7-2a08-4360-8243-be198b2c2722"), 4652, 2, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5214fdde-721c-4fa0-bdd3-f630cc3c75e1"), 4621, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5231220d-e6f4-40e5-80ac-2326e8b5787a"), 4311, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5251301b-6014-43ca-b0c2-2739a0cb5fa7"), 4613, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52530944-601c-4117-8d0b-cf6d3ae57914"), 4239, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5257d344-8e55-4471-a8e3-e0393afabc19"), 4721, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("529a6fd8-c510-46b3-879d-2d575cf5db9b"), 4810, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52a5b5b4-0aa3-4fdb-bc00-59df485d8cf2"), 4526, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52d98680-a96d-4782-b17e-1b38a0ba2a17"), 4621, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52e8fb1c-c6bd-4c3b-a5b5-6e62c788a327"), 4534, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("533f269f-1fef-4f1d-b071-d403d2c7cfa3"), 4460, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("535574c1-4dc7-4cdc-81f8-ca7107a66a71"), 4523, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53741ba0-b280-4a2e-a19a-bea436245fd6"), 4311, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53900df6-2ce5-4c91-8972-f4868d802a1e"), 4460, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53a43002-2afd-468a-8811-5a52553ebcc3"), 4558, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53a6c013-be88-4a10-a008-5d5306d85dd6"), 4808, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53aeeaae-6164-40fd-9822-781ccfd443b7"), 4657, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53af91d3-b104-4c21-bfad-134f98a98944"), 4539, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53b61d07-2e5d-461c-878a-dbcc02b8c8e4"), 4519, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53bbf50e-c1bf-4f97-9d22-6a0e9238c9e0"), 4661, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53c03a11-ccd2-47e5-9d6e-a17a8f8a3aa3"), 4002, 4, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53dc3b1e-365c-46e7-a518-9068ee71c272"), 4527, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("541221cd-9e09-43fa-9683-3515f9de7250"), 4617, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5417672b-7772-4c73-b781-fc1ab74e3523"), 4271, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("544add2e-096e-449c-b070-5d425c97d1ee"), 4458, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("544aeec4-dc26-4328-9ed9-a1e56d357cf2"), 4239, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5451b226-512d-4613-89ed-b806a4b93f0d"), 4537, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5463cda0-5806-4202-aa88-7b6272917772"), 4016, 4, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54662e4a-35fd-4f8c-a85e-abc3f41a82ab"), 4403, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54734cf4-f81c-475e-8f7d-63281190605a"), 4457, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54735838-8c34-40f9-b6ba-fae0c83d4774"), 4227, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54759603-e196-43b6-a73e-dce06b7d949d"), 4100, 3, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54a1582c-ae16-4ee7-b82a-30171b297287"), 4850, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54c7eb4e-32b9-42c9-92f3-212722432221"), 4205, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54e15576-acdc-4c0e-bff1-628dc6efc8fe"), 4224, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54ec4640-d214-4641-bba4-02a2d3e77979"), 4272, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54f55cdc-431c-48e2-ba07-fb884c5ae12e"), 4806, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55075b59-29fa-427d-9d28-46577379ce50"), 4453, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55093bd6-3dea-4785-926a-5355701521a5"), 4300, 8, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5509dad9-8fc5-4dee-933b-60977fd9e717"), 4805, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("550e65a1-f905-4ee0-b3cb-3e61edb7d01a"), 4301, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55121904-1935-4eb4-adc2-d3a1ce707f93"), 4248, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("554d8fcc-ae41-4b34-8e2d-c99d1e6c116f"), 4301, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5553ad23-61cd-448c-b654-e789bbdb0523"), 4803, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("556ec8ea-7329-46ba-91a9-345e6d6d7762"), 4854, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("559f213d-6281-4157-9141-07e0d6e32474"), 4651, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55a34d7f-ccfe-486f-b1d1-a9a818923d27"), 4419, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55ba3cfe-1c03-4081-8bb2-a270b9fc171b"), 4315, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55fb2afc-f3ad-4fc8-b582-32e9f8ce4b35"), 4853, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("560c075b-ca5e-47ea-8a40-05b6b870859b"), 4613, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("561cc36a-cb99-45de-8e70-099060304e85"), 4037, 10, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("561cfa49-cf5a-4e5f-a010-de8790aaffb2"), 4701, 5, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("562dd933-8e27-4394-9635-e3823fd4fecb"), 4612, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("563ad510-5fae-4688-b3eb-a0ff22946809"), 4032, 5, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56498b68-9068-4796-b7db-f4da328a07b6"), 4211, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5659c6ba-27f5-4ec6-9da5-7ed7ed548878"), 4109, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56604120-8b74-4d57-88ed-d7a39e001ab1"), 4017, 1, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5698c6b1-8253-4cbb-8e8e-dc1e77fc4c0c"), 4431, 1, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56ad0eb3-0b1e-4ba6-a2af-e212841ae3b8"), 4033, 8, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56c17b0c-a6ea-4b2f-b7a0-8ffecdd669fa"), 4456, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("56fb07ed-cf3e-482f-a155-054851c45714"), 4535, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57255303-88a4-49be-b872-28f6139aeb00"), 4704, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5725cdb1-174d-4c5a-8df9-689b17a44dd9"), 4651, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("572784e6-c517-4dd7-aefb-30a4c57ec9a4"), 4503, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("573e0a1a-3855-4f83-af8d-881178343be7"), 4711, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5743dba9-8453-4647-9de5-e56818c260b8"), 4637, 3, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57658ea9-e803-429a-aef9-7244a0d196bf"), 4263, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("576cdb9b-3528-4aa6-81d4-a28780fc2bdb"), 4302, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("577d34b8-98c0-43ce-b21b-8a0f901af8c0"), 4206, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("579bdd24-7ba7-4221-b919-62ad0dad20fb"), 4202, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57b16ce0-a983-45a2-b549-623da3dc208c"), 4260, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57c3ce30-e8e6-4493-ab9c-46dc3deb52d6"), 4261, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57dfc07c-9b10-4def-b601-85898fc6c8ee"), 4713, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57e99254-74fa-4d51-8eb6-7a1ea75789fd"), 4026, 3, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57f91abb-33ec-46f4-be13-b965a8626af0"), 4563, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58028755-94ca-4849-8df1-38afec853084"), 4237, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58134c8a-dce0-4775-9b90-d1912bce7c13"), 4710, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("581f865e-5765-4936-b4b1-902d5a2c17c3"), 4657, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5841e1b7-0903-42d2-bc87-48f088b0352d"), 4454, 9, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5844a6c0-4867-47b2-a939-780a2131cdf6"), 4607, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58608020-eb86-4e46-89ae-c562347edc14"), 4639, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58808642-41ab-4e65-85c6-ee1690ecd569"), 4272, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58900a48-5b34-41e9-a5eb-1cf635094859"), 4319, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58943128-8607-47e5-90ae-2f0e50e4e413"), 4722, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58a57472-a98e-4402-b657-cfb643134286"), 4310, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58b3d964-45b4-4418-8e87-4aa75a0a3b89"), 4410, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58b632ef-103d-4c0f-8207-3953d0e58378"), 4229, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58d8d868-fd4e-41fc-b059-2865d2eb957b"), 4250, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58dd55a0-de07-4c63-9931-c7a2dc55194b"), 4229, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58e0ec4a-c380-4df8-801c-ec8eadc7f122"), 4633, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58fa268c-6917-4fd5-8ab6-f35646cdef10"), 4602, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("592e5ae8-1f9c-47f0-af73-805d78b37cb6"), 4443, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5977cc20-382e-43c9-b2ce-3c9bec1e2ff2"), 4551, 10, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5979c680-9fcc-4706-a0ca-e8c0e85526d2"), 4809, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5981c2d0-fa5b-47e1-82f2-6a7c65c6b8b7"), 4417, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("599513ce-a81e-4c7e-8462-4c6fca9574fe"), 4417, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("599c140c-dc26-440b-977d-c36d5af823de"), 4413, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59b1ba5c-0d47-4438-8aa5-2ba49a6032c2"), 4704, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59b7fffb-a992-4ed0-bd54-f7dadbaa3ac8"), 4663, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59e1012d-6aff-4b5e-aa52-bdc6cf14b549"), 4513, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59eb2260-9cfc-4c3d-b325-4cc0e9ef449c"), 4425, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a00c484-0be0-4f1f-9a0d-cdc961fcf2a2"), 4856, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a124ba8-a495-4dcc-9c84-ff00391b5592"), 4025, 6, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a5ab47d-207b-40bd-b574-1594be4cea50"), 4434, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a704075-fb7c-4459-b8e5-6f4e64010f6b"), 4807, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a79d17a-9e94-47e0-84f5-afd305449dc8"), 4423, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a988f2b-9ee3-44c8-9bbd-667937eb8ede"), 4557, 6, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5aa24ae4-1d28-4873-8afd-e5587758430f"), 4444, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5aadca6f-ebb5-42aa-a6a3-cad313daed3a"), 4272, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ab103ef-af2a-4617-a2e9-2d01e85d34be"), 4543, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5abbac2f-2d22-4792-9a7d-26fe7985eab7"), 4273, 6, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ac14247-a0a1-44bb-9a32-8ee54a62d2e1"), 4501, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5aeb9f9a-4296-455d-9fcb-2f96ea59d4e4"), 4026, 7, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b0b3f9b-d3f8-40ce-8d47-b7fe1d4fda95"), 4443, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b1a944d-efdb-4004-a83a-1f0723ba2fc7"), 4445, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b1bb60a-7bbd-4230-8967-5ecc251c1aed"), 4515, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b3a1ca0-e715-4ecf-aea6-f5ae452b8cdc"), 4612, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b644dd2-dacb-4a76-a646-ca597862cf4f"), 4659, 1, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b704a5a-cb26-4186-8c9c-6113c38c4521"), 4512, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b7f4360-e8d3-4bd2-809f-533af9110385"), 4604, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bb3b780-4804-467f-acfc-78f8e9ec8522"), 4110, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bb43bc9-daf9-4502-b658-02a4e559dbbb"), 4110, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bc5bc8d-e247-426b-835c-1d9f07ecbc21"), 4300, 1, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bd2ffa2-8d20-46ca-8f07-89f824421f6b"), 4547, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c09a409-b0f9-45ca-b946-55d6dbb128d6"), 4323, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c1ef079-f67d-435a-b006-8fc15f65b5ad"), 4606, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c424339-8970-454a-b8d1-2423e41da1ab"), 4112, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c7242e8-1479-44aa-ba2e-8dc7da6ad2b2"), 4561, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c7503c0-2a24-4194-a4e7-29c827e575aa"), 4427, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5caa58bd-23d9-4c07-b8cf-f444661cf096"), 4516, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cb02158-67f2-42d5-a864-72f54a629c23"), 4410, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cb40f30-02bd-40c5-9f81-1659eeca58f0"), 4511, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cb41490-09f6-4113-aa2e-40d379632aec"), 4035, 4, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cb738ac-cdc8-40b7-9c6c-c002486bd891"), 4110, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cc6dd68-beb7-4c28-b276-30087a717658"), 4228, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d15abf2-f5dc-4c7a-a97d-80aa9ecb0992"), 4702, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d329b70-12f7-40b8-9349-0736119e43ab"), 4553, 4, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d529b1f-ec2b-41f2-9904-a9476c1d9692"), 4227, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d5f17a1-8d76-4dad-b147-06a550212761"), 4231, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d5ffcc1-d35e-446b-a498-27e662534c0a"), 4308, 8, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d95be6c-1c51-4d76-94b2-9e26d0412a4f"), 4651, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5da21be8-d7ae-47fe-96e9-09acf61bb158"), 4554, 4, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5da5db5f-72eb-4107-933a-484db39c21d7"), 4541, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dbc53a8-0871-4a2c-b22b-f3d2bb956dfe"), 4710, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dd2e8f7-b939-4cf4-a4e1-330406d5e6ec"), 4453, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dda88a4-a379-4c66-965a-859d49aa34e9"), 4404, 8, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5de3ef90-b89e-49fb-b283-f076816c14b7"), 4440, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dfa3e68-6ffe-4386-8247-08546053bdba"), 4530, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dfc4791-8c1b-4c86-83e9-953bc1317e4c"), 4261, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e1e81a6-f77e-47cb-8aa7-a59aed6e4cc7"), 4241, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e3470ec-996b-4257-8f0d-ef8562954250"), 4702, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e3d8c1b-1539-46fb-a2cd-8b54e6d505c4"), 4654, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e4bd9bd-4ba6-4ea8-8ca3-6b270ed093de"), 4612, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e4ef1f5-ccf0-45f3-8a46-dfcb9b6bc010"), 4600, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e62a1a6-e149-4e72-98cd-26847c455534"), 4656, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e6d91eb-a90a-4e6f-8d98-28377f5a9ca8"), 4032, 10, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e923300-2f33-4aca-9511-703b3e2a00d7"), 4012, 3, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ebf1e6e-4b55-4c94-946a-74dbe7df9cc7"), 4461, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ed2057d-c731-414b-90e3-f627712c9d0c"), 4537, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eddb95c-2b07-4105-b8c4-95b139e190fa"), 4032, 8, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f001000-6c54-4155-9e2f-912ea0614642"), 4113, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f02f6a4-a214-4e9c-8f43-51545fd968bb"), 4201, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f136eb9-7331-4cdf-b74e-4a8f3b84a874"), 4800, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f2aa783-78f3-4068-8a7c-711493ab74cf"), 4440, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f382629-8e45-41a6-84e6-90c732782283"), 4546, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f3c6198-ba19-4332-9aa5-1fe03a303deb"), 4202, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f4ba75a-0030-4611-9e5a-14049abaeda2"), 4544, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f4ccf45-4d48-46b2-9944-6051d1af4803"), 4412, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f6ccd10-172b-46d4-9d80-f12dcfa8d126"), 4025, 9, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f6d6a9d-cf12-4a87-8862-b793e77560bd"), 4465, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f720750-7d74-4694-8568-568bdaba5bcf"), 4434, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f7c6e87-ea3b-47fd-90e4-d5dd1ac5576a"), 4662, 10, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f99c412-6266-4345-bd76-1a592999746f"), 4620, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f9f83cc-254c-4cd8-872c-725c5e366635"), 4853, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fa7aac3-809b-4322-95f5-f4b19f6556d6"), 4440, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fbef9f4-7f82-496a-9d46-485a8fbd071b"), 4245, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fcd2eff-7b79-4ed2-8526-1f2c9a269cc1"), 4601, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fda531b-e5b7-4f7d-a4aa-902418b93d8c"), 4500, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fed23af-3fdf-4eaf-916c-14f009ac9a7b"), 4401, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fed3d41-db95-4c81-a1b6-567606475079"), 4032, 9, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6007d43c-128c-48e4-ad05-952e7f20e236"), 4712, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("600bd84b-b3ea-48e8-a183-3d013ef25b6d"), 4027, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6016a617-506b-42a9-a4e6-60b59a958024"), 4200, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6016fb28-6605-46ff-af39-3253e54c69c7"), 4241, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6041c99f-e1d7-4d54-b1fd-e6805a966acd"), 4600, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6042ca93-0535-49ce-b1c0-3e41c4848db9"), 4546, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6053b18f-803f-4c66-85b6-beb7b2f32b1d"), 4004, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6057f2d1-c950-4c41-9e80-47ff574d077d"), 4266, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("605967c4-13d7-4b29-b495-f25a7312bbaf"), 4506, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6065c271-c6b9-4abd-9f1b-62ef00ace69a"), 4258, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6071c703-d2f7-43ae-befb-10363f1fde2c"), 4255, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6082284b-62d8-4d5b-a4de-be7ff5fa381c"), 4447, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("608d239e-7952-4f67-b2c6-1da4ce148305"), 4201, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("609b4ef3-934d-43e7-9684-8bf5b97ecb02"), 4245, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60b254f6-495b-49b4-abad-0999c55fc68d"), 4228, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60ddcb8f-f7b1-49cb-8753-736ba19bf38f"), 4807, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60e8ca41-9c22-4186-94c4-746978a4375f"), 4556, 2, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60f1416d-6073-4750-b653-b8625926490c"), 4619, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60f624a0-ad2a-4cd3-b580-adffe019bee4"), 4562, 1, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60f722d9-d9bd-4b14-9cea-1d1e5523df99"), 4636, 8, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60ff2405-4cbc-4616-ab1b-a0b459aa73fe"), 4241, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6101f761-cbbd-4d60-a369-53e9561c635b"), 4405, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6106a5c1-ab75-47c7-8c8e-6215b4589f58"), 4318, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("613ae3fd-1ff9-4c83-9a4b-b5a20a894d8e"), 4007, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6169a1ea-ec10-4b57-a02a-17f7a250b881"), 4406, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6171a08e-b60a-412b-8c0b-7896d586b998"), 4614, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6177e53f-8f81-4875-a5af-240aaec61856"), 4009, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61a09b05-1b5f-47be-9c83-e6efe7bca0c3"), 4560, 5, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61a67012-2871-49f6-93e5-106dcc7e1e39"), 4532, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61bb7876-50c9-4206-85c7-eee72433d309"), 4304, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61c90bc0-f25c-42dc-b564-2cad25ed3a1b"), 4707, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61d28ebf-493a-4b9f-9cbb-1935fabc4f62"), 4000, 10, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61d917eb-45ce-4d34-a0c8-6893972070d4"), 4459, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61df3a04-0b68-448b-936b-271c9b8140c2"), 4434, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61e44d15-cd47-45cd-81c6-8b735c98f616"), 4315, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61eae98e-e61d-46ef-8553-ecf77cf4b22d"), 4445, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61eb9827-e805-4182-b26c-91058f9c67d3"), 4514, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61ec41ef-8d76-40ca-8c34-7f86338d721b"), 4718, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61f125dd-55f7-4a62-b64b-389a40efd1dd"), 4417, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("620953ee-7ff2-4c0f-8a95-81d7adc396af"), 4634, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("621270f6-1144-488f-ac6b-e3c08f7100d7"), 4264, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("621f01f0-1299-490b-8350-371695026473"), 4032, 3, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("621f197d-20ca-475d-976b-7ae74494c633"), 4601, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62220293-7e95-4a87-bd7e-c5128ecdda7a"), 4624, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6228e52d-d9f1-410b-a22d-09155d15e033"), 4273, 3, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("623185a2-c83c-4bea-83ea-5f4627cbe876"), 4103, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("623675ce-a020-4445-8407-db9a0a75b5f9"), 4461, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62492403-a5b3-4846-89bd-dc49e2e3249d"), 4316, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("624f1975-9b20-4c29-9eda-c28c00017263"), 4631, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("627a8e1e-47fa-42d6-9bb5-d8800609bc40"), 4104, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6283a05f-4be5-496e-b8ae-321de7bde697"), 4508, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62886c57-2438-4d2a-a1f1-c51de79369ca"), 4237, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("628acdd3-77d9-4918-95fa-70aa324b405f"), 4723, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62ab29ff-1fad-41f7-9811-bf22e03a193f"), 4556, 4, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b094ea-f012-4d49-a1c7-6dd729b737ef"), 4261, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b4c375-4f58-4d13-bafb-3c0a4ac569ff"), 4409, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62c7cec8-06ec-4235-acb5-42f743501c2d"), 4102, 7, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62d0ed16-4b14-4a76-867f-4416a6a49cf7"), 4271, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62d820f6-e6d0-4ca0-b475-793d44e6bb9a"), 4459, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62ef440f-d897-40b4-9d18-88f3cbb909fa"), 4108, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63413ef0-ce0d-48c9-b999-6741191fab44"), 4560, 10, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6371d0c9-2c8c-4f28-90c8-f669ccb0a4b5"), 4428, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("638e8d84-d8f6-4e89-b63a-f6621b23064b"), 4009, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63a154a9-d597-43d9-b536-e3302c9fc14b"), 4508, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63d30aa0-652b-455d-973f-e5ea75394b80"), 4307, 10, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63e1824a-bbb6-431c-916d-d93eff3f857d"), 4310, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64026a0b-a011-466a-9f52-b6eea68c0a8f"), 4033, 3, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64091504-ffa6-4676-8758-ebc796326963"), 4542, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6436fc09-1c6b-4d65-b4c4-470c723d6456"), 4323, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("643e9bd5-a522-479e-a6f7-f5b8cb9b50c3"), 4409, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6440747d-3abf-4bfe-8f77-c1d98c4dba44"), 4531, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("644317c4-6cdb-416d-8fce-0bff243bb1a8"), 4556, 6, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("645cbe5e-f635-4bdd-a6a6-5888162c72e1"), 4223, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("647f7c71-0a81-4b24-8f3c-715bcafef55d"), 4036, 3, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6489132e-a91f-4591-bdc3-55a2cba4b216"), 4517, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("648bf239-2951-491f-a01d-8a529df0e560"), 4415, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64a32fbc-27d5-4f92-8e17-4e358e30f887"), 4641, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64a747f4-b4fc-469f-98a3-97b8ff9db3ad"), 4552, 6, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64a817c9-0e00-4f3e-9885-860444c48c07"), 4551, 9, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64a945ae-30ed-40ff-8944-5b3a2c59e3b1"), 4432, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64cec110-e07c-4ae6-8e96-86569a1f5f45"), 4322, 1, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64d1ac6a-0045-4031-82bb-ea608ae32eae"), 4262, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64d4129a-f40c-41e0-821e-40feea113673"), 4659, 9, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64d6db88-66ca-4ad6-8fbe-30c387537bf0"), 4545, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64da6740-eb88-4a99-9280-4e1a378c815c"), 4032, 4, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64f29b13-8f1b-4157-93de-420deba28534"), 4264, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64fcaf72-fa05-4a1f-a585-f0e8d178f1f3"), 4443, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64ff5927-07b7-4af1-b923-430616bf1e00"), 4012, 9, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65077c83-72b6-4f81-b7da-b6baa31e50d1"), 4030, 8, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("651037a8-6a2c-4449-b383-cf5abd3d117e"), 4114, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("654746f8-b9f8-4b0b-96a5-4129fa030b9e"), 4714, 2, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("655c4197-b936-4a58-85f5-00249b2ce505"), 4407, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("657522b0-9aaf-4e4d-960f-42b4752c9c11"), 4432, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65a3dd6b-b377-47d1-ae0d-497c1428edf9"), 4627, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65a41146-72a3-4b54-9a40-160d912861f0"), 4304, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65aed174-9151-4784-8fc7-0e7e1a5b9c5e"), 4652, 10, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65b4d89f-30a3-43c9-967e-3567bf3011c9"), 4624, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65b4e001-be6a-40c5-90bf-c43fe09b754e"), 4417, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65d0e79b-d483-41e8-ab8a-76b3923969c7"), 4230, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65d525d5-3b6a-42b1-a4d9-d1d16ddc665c"), 4652, 9, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65f4c62f-5bc3-4cf5-941c-e1aa14a663b1"), 4854, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66000b45-1b24-4b79-b8f1-50e79935c42e"), 4320, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66079588-cc6f-4223-ab5d-bc1087a3f31a"), 4308, 10, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66239e1f-2a7b-4696-89df-919945c8dbd4"), 4511, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("664cc46c-7177-4c30-a5ef-a4810cea833f"), 4237, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("665868e9-e458-4ef3-9014-a13a013b862f"), 4115, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66640052-f23e-46ae-8508-bb2d33000e1f"), 4204, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("666be63b-5816-4e72-959e-0d13ea92df6f"), 4227, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("668befdc-820d-4623-992f-6873893ad2f1"), 4434, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6696a602-4af0-4892-886f-3eef8faf0ac9"), 4635, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("669ab79c-4e2d-4ea4-b017-ed08f381e2c2"), 4250, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("669cac8e-d986-4268-a1ca-12c7ef64d187"), 4721, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("669f79f9-bbc3-4529-bb78-cef535cabb20"), 4712, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66ac9baf-0200-4de5-8089-4b00857efe44"), 4304, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66b06c39-866d-49d6-896f-64ec9abada25"), 4205, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66b9596e-1239-489b-bd4d-bc6cfc94750e"), 4004, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66f7c138-d196-4d8f-8e81-62167462e7d8"), 4214, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67054f74-cf01-4101-a376-bfcfecfdc9a4"), 4652, 3, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67271dc2-dde6-4bf1-9931-b25e2bc9020c"), 4465, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("672cd5f4-7684-4526-9d2c-334e817b094d"), 4215, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("673e77ad-e0d7-40f6-bf86-f0fc512863e8"), 4022, 3, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6747ff4a-076c-4461-a921-aacee2ddf885"), 4528, 5, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("676ecdfb-b699-4aa3-95a7-2242d15aa3ad"), 4003, 7, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("676ff446-11d8-454f-b146-e9e4e9a3e1fe"), 4716, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67709757-3c83-4cff-806b-cbd599c552ff"), 4214, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6776b454-6f89-416b-adef-d52cad98d4fb"), 4274, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6789365a-3d35-49c8-8e7f-a081a8be8134"), 4517, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67cbbd01-56a2-40ac-869d-0b31974d380f"), 4529, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67d2bea8-a9f9-4f3f-8865-0c19a9edc24f"), 4220, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67d35a4d-e5e2-4ef1-b4bd-e6071674268c"), 4427, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67d60958-c042-4d0b-a0c0-f3976aa99d32"), 4006, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68296e5f-c494-4b25-ac30-899f11ba3ef9"), 4700, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("682af44f-33ac-4f14-bbba-b5e86f0cfe78"), 4305, 5, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68354e30-3c8a-41e5-971e-5f4d139ea51d"), 4319, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6858ef03-c098-456d-b21f-dce16882f570"), 4608, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6861c2c9-ccb2-4e72-bd34-89692b5c436d"), 4429, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("686e314a-9462-4d6b-975d-a2e041b7b316"), 4226, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68724a03-1db8-4d94-bcf2-e7e936fcd7eb"), 4223, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("687edfc4-fced-4a60-ad3b-1b433f2f2ce1"), 4620, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6882123f-a493-456f-8072-5a78d5355310"), 4240, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("689257f7-2ede-40aa-9378-a49d5f17829f"), 4307, 4, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68a82c72-dfd9-467b-97f3-1d9f3b319c01"), 4212, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68b74051-5a31-4715-bb38-17398439ad0e"), 4525, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68cededb-83ac-4136-a649-692951da9904"), 4537, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68cfa398-6105-4502-af26-18206d76d39b"), 4455, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69070701-4c00-41cc-aee5-86d67787ef61"), 4457, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69210fb0-9f58-475c-8cc5-d20b83b99f71"), 4522, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("692b2b43-fcc7-47bb-a786-8c16de915544"), 4110, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("692b798f-0d33-4238-a0cd-3bfc1f708403"), 4803, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69334c7c-3297-4ace-88da-9f9669b19119"), 4640, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69374a08-7ff1-4b99-9b58-dc09abf101d0"), 4542, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69448ea2-48b8-4a6e-a979-6de9fba83d13"), 4322, 3, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6968735d-42bc-4b16-8a86-2746ad259f74"), 4515, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("696b4e17-89ed-46d5-a3cf-8fb8df1c63f1"), 4324, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69731dbf-99b8-49ca-9dbe-da56b0617a50"), 4245, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69bcd6f0-bc76-48f9-87b2-410f4af20806"), 4416, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69dcd611-5094-4b31-ba3e-3e729d159c65"), 4526, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69e50cea-c237-4477-a924-b951cfdc7cff"), 4855, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a062618-a2d5-4ca4-8b0d-1cd93d3e6a7f"), 4446, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a0e59a8-e3e9-4015-a93e-17ae748cf7f5"), 4443, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a1a3144-0fac-4b6f-8f6b-bd8da870d9f8"), 4013, 8, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a1ad478-0207-4226-8522-99d71159f4dc"), 4717, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a3232ea-eb05-407e-9ba5-f249b420510d"), 4535, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a33e374-5ddb-4096-9bbf-ce3be81e4316"), 4503, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a674e5c-e3f2-4f27-8c88-e69f6954b72a"), 4318, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a77271b-bf04-4b8c-8c56-f8bc39fe15ff"), 4206, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a9d1c91-3206-4554-aee8-cac81e40878d"), 4808, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6aaa91b4-6c04-436a-bb74-7224d6e8e681"), 4723, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6aabc44b-5d17-4ee8-b6f5-eb3c9f014410"), 4263, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6acb50e4-54ef-4dde-9c34-33ab794837b2"), 4536, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ad2f1a8-c0bb-4c76-ae13-6fe6374db429"), 4433, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ae12c4d-bbec-43a9-9999-509f7f92a8cf"), 4221, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6af7d75c-1cb7-423e-a125-cdd4616aca56"), 4702, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b1e417f-6156-474b-a0f4-dd5a56c9b72e"), 4269, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b220f8f-9ba8-44fa-82d6-e290085b7cc9"), 4536, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b222e90-fe25-40af-9b70-1b6e45b31981"), 4008, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b379d8a-d08e-4873-9011-497fb02fc06f"), 4723, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b3e580e-d973-4996-9674-dc617118808d"), 4652, 8, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b47372b-2173-4116-870a-c68dbc123d88"), 4450, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b518da7-fcdf-4766-9fc5-d9f8c6b17b45"), 4660, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b59e6d7-bca7-4213-be65-d1b6c6ba10b5"), 4311, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b87e283-432c-4ec2-b71c-6d2c7054ad86"), 4529, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b8c9d8c-a0e0-4c8b-84ed-caf773f6d58d"), 4247, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b8eb294-1bd8-4f52-a562-f8380017cd31"), 4034, 1, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b9a0b1c-a7b5-4751-a119-bbdc9373e46c"), 4417, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bd86a30-e224-4265-9021-3931228e9eac"), 4412, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c042fbd-d33b-4e07-b57d-26c249131750"), 4007, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c0490be-049f-4e6d-971c-ff0f74033745"), 4411, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c069b5e-9541-487d-abb4-8d86d78c1fae"), 4655, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c2f9e78-fc47-4fd1-88fe-8b27af430fc5"), 4708, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c38c417-4ca1-421c-8812-c0ad89b9bc65"), 4403, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c40a15a-05ea-4ef2-a7a8-ff8585c888f0"), 4543, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c419e55-d00c-4dcc-aac2-9601481406c7"), 4444, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c48238c-7ef5-4919-8017-8ec5c134ec48"), 4313, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c6a624c-d7c2-40ff-b930-beabb3aed83e"), 4539, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c84bf67-06ed-4cfe-be4b-5a193ab96764"), 4606, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cb075cb-65b4-4c17-a182-e94aeefabc8f"), 4622, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cd753e2-4dce-4641-a175-5a609505fcd9"), 4710, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d05abc8-d908-4ee0-9fe6-cf3d1b4a9019"), 4036, 4, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d1a4198-2103-4835-9ee0-d73747733c6c"), 4111, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d35a859-3991-4cd1-a244-449cf39ffb40"), 4700, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d525a40-0ce6-40fa-a07c-5059e6375bc0"), 4223, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d6a8ef9-422d-4a24-8418-bf3f6d713b8f"), 4306, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d717749-68e8-4fa8-b754-8d208217e729"), 4013, 5, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d7bb1a4-c590-4a5e-a069-0d3ccf88e635"), 4426, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d8a15eb-5e4b-42e4-a7d3-df86b2b48223"), 4531, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d9375c3-de8d-4edf-ac67-702ed57d2f15"), 4037, 9, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6db106bb-7917-4214-9565-89fc1434114e"), 4224, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6dbadf23-f472-42fd-8ab9-45804b3573a3"), 4322, 4, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6de9815f-f0df-4bc2-bce2-f1ef4500214f"), 4564, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6dee4a38-a073-4121-8d9c-c3ff5c6d5ccc"), 4514, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e09d6fc-d834-4189-89f8-0681a25d0418"), 4228, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e0f4b13-c13c-47b6-92c4-0656b64d6640"), 4205, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e5370db-64a5-413a-899b-ae829e4eab29"), 4271, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e57d7e1-10f0-419f-936a-07085c93b249"), 4720, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e63113b-a572-4037-8c7d-99f9d1377fb4"), 4717, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e74ef47-5f40-42cd-9f70-5c661b491fe0"), 4004, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e7f5198-f039-477b-9d9d-12a3d610d374"), 4420, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6eb86bdb-e997-4f7b-b6b2-4f13a93480bc"), 4248, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ec81c9c-4d7d-4e2a-8d21-b537bdf9b70b"), 4317, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6edaa004-c130-47ef-acff-41fa1e7cd1f7"), 4550, 4, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ef06dab-51b9-474f-ac15-55104cd1b8dc"), 4805, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6eff3f2c-1a85-4d87-aa60-ce321ab6dc67"), 4249, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f0a02cc-d171-4e89-8a02-b157aadb1f11"), 4444, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f245e07-6464-4663-968c-94ead2bec799"), 4455, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f371522-c0a5-4c56-9168-20035ebe9a93"), 4441, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f3d871a-ee33-4ec4-8606-59feae31b33f"), 4307, 8, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f54500e-0de3-455f-a378-04c791e491bd"), 4101, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f55d065-509f-449c-8259-2a25759d5bf7"), 4459, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f5e0e4b-2701-4805-bba3-4eab1798f57c"), 4806, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f7c8f61-dc42-462a-a276-2da7af2449f2"), 4030, 10, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f8b5e0d-29f6-4db5-896d-4d80645f12eb"), 4306, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6feb14ff-9d5e-474c-9774-c6d76da1f0d5"), 4424, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ff51938-70b8-4963-bb28-e7dbf277d92f"), 4538, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ff8890f-d509-45ee-b72e-cedb18282cc0"), 4515, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("700d712a-61db-4789-a4e3-7442f9be456d"), 4802, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("700f73b2-5950-4933-991d-74ef5e7a6d36"), 4244, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7018457f-53ab-421b-9778-c61901a69426"), 4520, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("703980f0-a069-4ee1-8e28-39333fff7450"), 4463, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("704857db-a0c6-4eca-b9bd-ef0723513ef0"), 4659, 7, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7056e1f9-2df9-45ad-b75f-cfa346d13b32"), 4408, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7077f796-4ac9-4035-be77-e2b8894ea466"), 4003, 4, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("708c665e-2c7b-4e8a-8959-d1eb70ff1815"), 4440, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7091c510-d66c-458e-b082-05b90dbeab98"), 4218, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7098489e-cb63-44d1-a116-8df4c24f9486"), 4453, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70a51c4c-bcd2-4893-bf98-4e2988ce3dfc"), 4238, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70c03ee8-35b9-4ddf-915d-cc72cc7b4503"), 4029, 4, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70dc9cdb-c9e6-4672-9848-0e86ebcda2ca"), 4722, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("710345ab-ebd2-4415-bd40-641c3b6d7ef1"), 4635, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71075c40-0677-4fa4-9605-365ef2fc6a9c"), 4228, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("712b383a-21a9-41e1-b3da-47396e011e0c"), 4709, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7152928d-17a7-4119-a114-40550b3ea7c0"), 4631, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7194326f-f6e0-424b-adf1-f2c9fd228281"), 4035, 2, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71ab535c-4f25-4bb1-8c28-7bc60d04afd8"), 4104, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71c8df67-1724-473b-a522-844d5e07c71f"), 4226, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71f1acc2-0c48-4fc3-97fd-8bb099789026"), 4244, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71fdc288-e42f-4a88-b7f0-6b6c0f0a61f6"), 4505, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7207ceab-17a0-425e-9781-e7797af9eb2f"), 4437, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72153041-4dc3-4f4c-82a1-756906b8059a"), 4700, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7217a6de-200f-4dfd-b603-6456541b23f9"), 4300, 9, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72297a06-5a08-4def-bfcd-7b8e95b06093"), 4262, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7237b590-4db6-43b3-b733-61002ca8cfc7"), 4008, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7239c3c8-47e4-485b-ab0d-235b9f4cb9f2"), 4554, 5, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7274ee1b-00a4-4772-8b68-c9e775c58c16"), 4617, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72aba9b9-a30c-4638-847b-3f7cf474b491"), 4208, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72b99390-9747-4462-91e6-dc212c29f7fa"), 4323, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72babc42-96e2-4efa-8aec-62ab05a038b0"), 4540, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72d11675-d9fe-41ca-ad12-cf260500cc6b"), 4267, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72daecd5-ec8a-49d4-a381-916765b33f3b"), 4259, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73003494-a882-410c-9552-bb7b861b4d56"), 4026, 4, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("730c13b4-5cce-40b8-9ddc-ef0a8ba98d3c"), 4662, 8, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("731873ea-bc70-4498-a0bf-aea149ce53b9"), 4008, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("732de4a9-cb53-4827-a374-be42d4fb222c"), 4659, 10, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7339e649-c0a5-45c2-902d-dec4dd0eaad6"), 4257, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("734a0e8c-ca0f-4ed2-a021-22b6aa757f08"), 4107, 10, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("735431a7-e9aa-4af3-b347-137b60507aba"), 4641, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("737712ab-be87-4b4a-ac6f-b01ca796d5e4"), 4856, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("737b16fe-c53f-4d85-87aa-bc00ea068409"), 4801, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73884a33-164a-4e22-b68a-ef0f4c4add85"), 4718, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("739478ae-4839-4795-8566-e40f0ddebf8c"), 4612, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7394d1d7-c9fc-4726-9a58-b2d8abd0dc90"), 4233, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("739b682a-bb1c-45db-9093-aba2d7313cf3"), 4457, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("739e9374-9365-4ba6-9f16-e45b80eb048c"), 4004, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73aabcfb-3efc-404e-b4de-21a0b2ba4609"), 4715, 9, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73c20316-b04c-49c2-b8e4-87751a3acabb"), 4256, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73c4635a-1ac1-4c06-b044-b20779c44766"), 4267, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73ce6335-3d5f-4a3a-ba30-a55c3e9cf081"), 4246, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73d18c4f-d8d3-4742-85a0-b4e704e5971f"), 4229, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73d741c4-a76a-4cfb-a618-ccce71efe618"), 4627, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73ea902a-8e12-4b49-8784-97e39958c6d0"), 4324, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73ecae87-f2d8-4169-bbdd-0cb64318ac88"), 4807, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73fcd82b-a99f-412f-babc-74c671001e99"), 4605, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("73ff7938-d3ac-4622-9268-503fedc4a4b1"), 4453, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7421217c-94a9-48a0-9cf8-4345031f3053"), 4103, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("744a9e09-d8ac-47f2-a9e7-a381a72231a6"), 4564, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("745f331e-6c49-45ec-a5a9-247690c9c9bf"), 4640, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7462f945-3bde-4fe5-9ffe-d951431f5b71"), 4707, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7464849c-bd38-4a14-ae8d-3801cf78f0c9"), 4607, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("746822f9-f3f5-47a2-b971-16e9c3e138d2"), 4620, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7478d29c-2654-4f4e-83c5-e931b0dbf76e"), 4601, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74790dd9-c99b-4226-b427-055b6a628451"), 4312, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74af1620-28a3-4f88-840a-bea2a1f4448d"), 4005, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74bb5b93-0625-4108-b866-58f85ff14bb8"), 4423, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74d986b1-b9c6-49d7-a7e4-add07cb1986e"), 4212, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75099295-5199-4200-b31d-71fe31cede06"), 4545, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7509e86a-84a8-4db8-bcc5-0974c7c889da"), 4554, 9, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("752d8bc7-cc48-4f90-8177-cba3bd13d214"), 4528, 4, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("753ea6f6-155b-4324-a645-9ad029e60125"), 4422, 4, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("754beb7b-9b3b-415c-975d-682f9a3c4e5c"), 4111, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("754d2bae-136c-4274-91a3-72b95b541620"), 4526, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75546c37-d7aa-4ebf-aa05-1f17deec28a7"), 4439, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7584b3ab-605e-4436-92e0-b7eb2bc187f7"), 4625, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7587b936-a5ef-4f32-9e9c-d60bd7501fc2"), 4641, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("758bb877-97e8-4624-8375-12e840d384a8"), 4518, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("758fd98b-9a29-49ef-8428-9616b7b9ba91"), 4274, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75bf3d80-523d-4378-a519-858cfe58bc7a"), 4234, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75c68944-4849-40bd-8ac7-0a412fc08188"), 4808, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75cb7eef-8747-4143-89e1-b18c1db56e63"), 4620, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75e9721a-5172-44f5-9617-6b1e9c053049"), 4460, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75ed10fe-6607-42c3-a0b7-b39c475f7510"), 4536, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75fa3fd0-224e-4280-9dcf-1e839925f1c9"), 4416, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7622fc11-c37d-4122-a4df-1f98fb54d6d7"), 4624, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("762717bc-30e6-4809-b33c-6e38a96df1b3"), 4108, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("762b471a-fd85-46f2-9ec0-f3f80699b8f8"), 4232, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7636642d-75af-4982-87d5-8aa7a4739fa1"), 4263, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("766fa43a-0ebf-409c-96d1-ea0a6d603cc7"), 4520, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("766fd996-0b53-4fff-aa39-333e1b46b17d"), 4010, 10, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("767c6fe2-6351-4ac9-bd5e-3fe305deeaf7"), 4612, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76825510-34f3-46ba-977c-d8b2676a517b"), 4300, 5, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76876fbe-0628-4e94-be50-9dd623777664"), 4636, 2, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76938c25-6580-42f3-ae14-2155f53ef7b4"), 4546, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76b28213-31c3-4f88-a61d-241057a89a93"), 4264, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76c57c22-712a-42b9-9f94-d3289b061ace"), 4565, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76fe0ebb-3233-4f4b-b401-7acefda4c3fa"), 4506, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7703089f-ad6d-446c-92b1-efa5633e7358"), 4531, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7706526e-2221-4923-9db0-a26d4ce16b87"), 4115, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7737d1d0-16b5-48b8-ad2e-7b4ce30b18f4"), 4312, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7747984a-df12-4a5e-ba48-59a1e75a1159"), 4202, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7758b849-e6c0-42a4-bca5-cd49b3dabffa"), 4232, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7759869b-1733-4052-bdbe-42b80e211802"), 4852, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7771eda2-5f9f-408f-8751-13cef9087c34"), 4718, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("777e359d-1843-4be3-add8-75d2e5245d71"), 4314, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77a15390-02fa-42f1-a5fa-1e90fbbb4101"), 4719, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77a1cb30-77e2-4f84-b11e-9a2b0a7c78bf"), 4230, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77a8b4e2-5b51-45a4-8e00-08e368a8154b"), 4412, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77ae3e7e-096a-4fcf-8d1c-d0bb184b608e"), 4102, 6, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77bca901-2870-46db-9791-04f4c2fdc5bf"), 4316, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77dff145-87eb-40c3-8d7e-610e9f29b5ec"), 4511, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77f03b69-0852-48dc-aebf-a1bac9c00e89"), 4503, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("782bf007-02da-4bd2-819b-0eabf74748ec"), 4248, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("782f247c-1214-4623-b91f-fa0b6583eb5d"), 4307, 3, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78316465-44da-4453-a760-6d9e0ce42baa"), 4421, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7833e95b-9276-46c8-b384-2c65176629e6"), 4021, 7, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7834b963-9e48-4b1d-9e0a-dbf16cf4ac78"), 4258, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("784363ef-d030-43e5-8feb-98011bc893bb"), 4634, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78448837-b390-4c9c-aeef-d3dba6a8fa79"), 4606, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78619698-7bf6-4c1e-afd0-fc21a942b88d"), 4400, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("787bcbed-9a0d-47a0-8b31-cfa2339a6e10"), 4514, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78aec184-467b-487d-957a-d9c660f6c2be"), 4851, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78b17a4e-c3be-4002-ad4b-e3dbcc08b988"), 4805, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78b37261-2329-4858-a816-c236502b5168"), 4402, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78b7ee2d-486d-4c1d-b897-eaf62544f0e7"), 4503, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78ba96e3-94f6-425d-8a03-2e91a1566a72"), 4446, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78c0d96a-e8ea-4115-bb80-2899be19224c"), 4805, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78ca0ad8-3c3f-40fb-aba6-87bba1badfa6"), 4601, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7905f006-7d62-4084-83cd-edb08cb5a647"), 4713, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79082122-f2fb-4174-b71d-4bd706edf556"), 4228, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("791df792-eb17-40b9-b6d7-af80090a14d3"), 4424, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7931a606-7c84-419c-a669-6f44f83772cf"), 4274, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7935d4db-e95b-4ffc-a94c-2bf5b70cfe6c"), 4544, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("799794e5-7228-4ecd-9edc-bbf46dc75f53"), 4601, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79d4c8d6-0431-4a6e-b9e2-1e7fbb2fc4e9"), 4030, 3, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79d9961c-5b58-4e8e-b348-9a084e034f76"), 4710, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79e1b446-df06-4528-af17-7152069449e4"), 4423, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79e911a6-0f7e-4703-b06c-ed046b3e17c9"), 4014, 3, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79f3818e-94b7-4b8a-9d7f-062f5570dfb5"), 4214, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a03fa76-bd7c-441d-8840-37f93a385391"), 4235, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a19b1e2-e737-4cf8-b023-283763594cb7"), 4800, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a32d000-e62e-4e3a-8754-e49b9c9f2f1f"), 4421, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a339451-235f-4c7e-9ac0-1d59f70b79ab"), 4634, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a4df9e4-80b3-49c7-986b-a89cf255791e"), 4706, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a7195d2-2800-4f9e-be3f-047826ad0497"), 4246, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a939aaa-f68c-400d-9dd5-32c2aaf24e32"), 4420, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7aa94eee-d5e3-4a88-bae1-ef0154d8c6d5"), 4242, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7abb013d-a962-4c59-9887-0aa420510b31"), 4261, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7abb66cb-d10b-44ba-b127-c5b10dafe4af"), 4554, 3, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7afb117f-9619-4481-8bc9-23210ca4f355"), 4322, 2, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b03b3fa-6c35-439e-8424-48687b30917a"), 4203, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b166d11-5fb3-4ba3-901a-b4ba83c74b80"), 4205, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b1e2f9f-8707-4d40-ba44-f48ccb7aa2bf"), 4562, 2, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b1efc58-1b39-4653-955c-0ec55103c9c3"), 4537, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b21b981-009a-4f15-8d52-c5dacc970ac3"), 4015, 5, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b491d1a-95cc-4b72-ab55-89ee1d2caf11"), 4408, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b5115d6-2ce8-4484-814e-bc9b9da5385e"), 4650, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b6c1869-b113-4bbb-a32f-690dee18929d"), 4305, 4, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b8aaac8-50e7-4a7c-850a-179862e182e9"), 4431, 9, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b8f66ff-4125-4087-89f4-2b11ca047c98"), 4543, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b9533f6-7704-458d-b6ef-21956f32ef26"), 4107, 9, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ba77ada-d143-4e7c-bb88-d79b411be3c7"), 4530, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bbceb8f-0da7-4ac0-9dab-39911822465b"), 4514, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bc05812-6725-4cc1-aa96-d5edc20e946f"), 4024, 10, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bd15dee-8856-4129-b086-58140a3a6625"), 4419, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bd49842-32a1-4a28-af62-448e9237b77c"), 4238, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bd503dd-4bbd-4649-aec0-aee9fc49844e"), 4624, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7be0efcd-d747-4b99-b14e-08f40ece4e82"), 4235, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c006ef2-cf32-4292-b807-c7a23abd75aa"), 4801, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c23a057-77a7-45f8-b00f-8122feb60d46"), 4258, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c38ba73-fbf0-4c11-bfbb-ab906904a01f"), 4651, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c425d9d-d2eb-4472-a233-947d501e2f94"), 4524, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c43b46f-2e7a-4ead-b125-46d2951ade4d"), 4110, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c4fb566-0647-49e8-a96a-80f5676663cf"), 4702, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c8f225f-8a5b-442f-98ea-9f4b7eac7ca7"), 4506, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c90e4ae-b635-4984-b2b9-0d6aadcdfb55"), 4247, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ca9806e-cb6e-464e-a3bc-09c320cf2d7f"), 4659, 4, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7caadb7a-e1c4-4045-9003-e0fbc4fc6108"), 4204, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cb81723-6705-4432-9ad4-60103253c21b"), 4501, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cc6b3f8-917f-46db-b072-7e73c3310cd5"), 4512, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ccbb380-aeeb-4f94-a6a4-16bfd84e5a77"), 4252, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ccdf60f-3e98-4bc2-9897-373a87f4e4a3"), 4416, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cda005d-a340-40e4-9b5d-80259a7a7e9c"), 4444, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cfea54c-0127-47c4-90d4-dbd2daf92170"), 4316, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d03807c-6422-45b4-aa93-66a2fd819134"), 4256, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d03da2d-c8d2-4e00-8e75-8124e5eb9bf5"), 4225, 9, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d212126-ee64-4e49-b279-62e6048aa77a"), 4234, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d242792-8553-48cf-bd34-d95453fc3575"), 4710, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d32c3d1-6f8e-45ef-a336-219462b2a4c5"), 4623, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d3a62fb-aed6-4460-9632-3aa7a9db646d"), 4212, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d3e340b-292d-4c5e-a9c0-8be452705e26"), 4502, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d3f6741-fad9-423e-a5b2-881a16407639"), 4323, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d684573-1935-4e12-b1a1-c099c2fa5481"), 4254, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d6afd1b-fa44-4c88-8be0-f15c05c99a35"), 4207, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d759235-141e-4d71-bc9f-857fd2332c2e"), 4602, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d82683f-18d6-4cbf-b414-1ebdc403c5e8"), 4704, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d8d0aaa-cc1e-4f10-b0da-fbbc5bb93e1b"), 4451, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d916a77-d707-43be-a0ad-65f44991369c"), 4324, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d92cc60-f047-4af6-8a55-ef5f1a446d7a"), 4438, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d9666fd-c437-4da7-9aed-030fe576000a"), 4241, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7da9d5b6-e90c-450c-a833-5fb792ee8196"), 4625, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7db5dc0d-3968-4688-b702-dc61fd6574ff"), 4515, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dbaf1c8-c53b-46ae-b3ad-b080be789c88"), 4460, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e09bb35-89f9-45da-b6dd-294b3496aaf3"), 4007, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e0edbec-eae9-400e-a377-33786855fadb"), 4236, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e147cc5-95c8-4a1b-8b39-56cb6555328c"), 4037, 7, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e191129-770c-4d9a-b9b2-c7ff67fb9f0b"), 4542, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e1cff48-953d-44a4-8559-84e30f73222a"), 4538, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e22148f-e213-4cf7-9822-520254cb3697"), 4610, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e2f2715-43b3-410c-88e6-ece3c0b801f2"), 4537, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e3df295-db88-4df2-989d-8973a100d376"), 4554, 2, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e4bbf5e-9a4b-4538-aa14-2f332f9f92dc"), 4716, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e5f661a-5ddd-49e3-8199-85a31f97cde4"), 4809, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e5fa937-adaf-40a4-8701-3b9f16df0078"), 4200, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e8fc7e9-c04a-4c30-8746-a9b483026153"), 4563, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e9084ec-a347-4dfc-b7c4-3de724b3bc66"), 4614, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ea37d99-4d3b-4778-a9c0-7651496a87ab"), 4719, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7eab7da0-6814-4634-9181-c7b7337dd06f"), 4255, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ec2b5a3-42dc-4ffe-af4d-9a9b788dd5c1"), 4250, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ecf3719-d687-4a72-bad7-65926eddb2f3"), 4808, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ee492f8-d340-43ae-803a-477ba99be6f5"), 4318, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7efd915d-6d5e-4817-99ef-376793ef8328"), 4613, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7efdc79d-e987-4cb1-8217-efe60531cf63"), 4031, 10, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f2e4ec9-054a-4ae4-a1f6-2f8aa722b674"), 4614, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f63877a-4cb5-470a-8edb-f51fa5014cb3"), 4220, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f7aa2e9-b87a-4d5d-9d93-b5ad88ee1b1c"), 4720, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f81a37b-ff88-455c-a775-b57ed1dbc52e"), 4305, 10, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f92ae94-0daf-4ab6-8440-d6b384ccf032"), 4249, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f9fb808-d1fa-44f7-8ec2-fdfeea7806ab"), 4002, 5, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7faf379d-236e-4652-99c6-12f8798f4396"), 4713, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fd4def0-7080-4fdb-a8ea-7e8878fc3afc"), 4259, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fd70793-6311-4ae4-b82c-83fa4f02910a"), 4435, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fd95525-a551-4a40-ba7b-288e3313469a"), 4011, 10, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fe0be14-bb4a-43f0-b1df-dd4c5bc7f064"), 4702, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ff85e05-2503-4e67-a9a8-e67134ca3ccc"), 4458, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ff8e884-1b80-412d-8992-245899ec6d5b"), 4008, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ffd82ae-70fc-4b45-b191-dc93cdc6cbc5"), 4031, 8, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8000cad1-7ce7-437f-8014-316695d2b998"), 4422, 1, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80011589-f2f0-4bf9-8f31-ffa568fc2cf5"), 4453, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("800bae9c-11d1-44d9-9137-9572e430f9d1"), 4805, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("801705f7-c658-4700-80a3-9a82f0e0ce26"), 4101, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80220918-ce97-4bfd-b494-9cf669bfa43d"), 4102, 5, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8028b201-7045-4c83-bdc3-1b16a06dc267"), 4542, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8029b1d4-fb1e-4916-957b-169cb53cb6ec"), 4112, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("803edbf1-f66a-4f76-b5c5-60d6c682fbd4"), 4721, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("805b093f-cd3d-4c92-9c41-b5db016bf4fc"), 4515, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8090268e-9adf-4201-a948-0ef945d2f8f6"), 4003, 1, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("809b2131-6f37-4c46-8979-c7580b65e7dc"), 4021, 6, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80b70a91-bdf4-4cd1-9a7f-eccc87ccef78"), 4663, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80efae14-755c-4e78-b271-b1fb328f538b"), 4605, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81096b52-dc19-46eb-a8f5-b210a20e9b70"), 4270, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81253b7d-dca1-43ca-a650-27e3cdcb2f6c"), 4661, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8125ec35-a728-4b3f-83c8-b1790dc51053"), 4422, 6, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81293217-3943-4dca-88d2-4ff9891444ca"), 4231, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("813b6a14-04c3-4496-8ee6-9611eb765149"), 4509, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81433028-7ab3-4a67-9627-2a914954cc1a"), 4321, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("815e2801-5faa-47b0-9b7d-30a81d289737"), 4806, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8164df06-0620-4f59-b201-c70554493064"), 4453, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("817da859-b278-4b57-a8d8-9d5763811f76"), 4322, 10, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81c512dc-4ae9-4ce0-b2b3-d2b0e9a11466"), 4032, 2, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81c8d4da-b10e-4720-9d26-d508e2f06210"), 4021, 9, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81cc8b9e-1800-43a4-9284-8b9fac71ffc1"), 4810, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81d57936-d840-4a4a-ae83-15d6ecd5b577"), 4316, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81d6be0c-e95f-4e97-94e8-f78068cc7a08"), 4440, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81e810f0-b681-41ab-a90d-0b962cc31f34"), 4434, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81f0bc49-49a5-4795-bc4b-866e37155788"), 4661, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81f27211-6acb-4262-b57d-4805e2cde646"), 4437, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("822da004-2a92-47d1-bc10-60117d46f27c"), 4210, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8241a892-0bc6-4b68-a62a-a6dd92eba48f"), 4201, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82494084-e026-4c07-a596-4b98a6f069c5"), 4559, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("825b3203-dc85-4634-b98b-b01f743e5157"), 4401, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8275d2bb-ef66-4de3-9ce3-117efc63f88e"), 4111, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8294767e-dc91-435e-bdb4-3ce6393409cc"), 4320, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("829d60b7-a671-4411-8fa4-ba3119127f37"), 4463, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82c66fcb-5b38-4457-9fa7-d4d042efdff1"), 4635, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82de139a-a496-410b-beca-50497cc4c674"), 4428, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82df3fae-6bcb-4ccd-9b3b-eb90700248f2"), 4037, 2, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82e0e6af-3f73-41ce-b2ca-e1cda8c59ed5"), 4272, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82f6763d-c777-47f1-bdbd-31e99668eb52"), 4716, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("830b72ad-3eb5-41d8-95b9-85d7e456d92a"), 4302, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("832198e6-59f6-45ff-85f7-aae96f13938c"), 4273, 7, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83356acc-0c6c-41eb-86f5-2f4560922f1d"), 4717, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83537547-5b2d-4a1a-80d5-36b323e3002f"), 4510, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83785565-b413-4e9a-ac8f-9c6e6032b3e3"), 4437, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8388b900-1bc1-4eee-9cc5-6e57e96556cf"), 4268, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("838afa8c-035c-45ac-9d0c-cc412283c54f"), 4445, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83926c2b-5ad5-4861-a83f-43e212f589af"), 4622, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83b4a4ce-2f39-401c-9a7d-f14fe199f502"), 4432, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83b5cfb5-fab5-4a21-a22f-98c38a15ff2b"), 4852, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83c97af1-6562-40b7-adca-25b4886df362"), 4608, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83ee1ee2-4de4-45ea-b63e-aa4b21605906"), 4259, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83f1cd80-83be-4819-8862-a26198f63920"), 4527, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("840849a3-b211-46af-8531-8bfcd8e55a62"), 4203, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("840afea2-f4dd-417a-9faf-2cb6822d7515"), 4807, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("841476e9-c443-48ec-82de-2a2a6c780540"), 4405, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8417696d-6340-49b1-85ad-b223bcd72b8b"), 4019, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("843794a1-715d-4a23-a20c-5d7a96b3d0c5"), 4251, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("843940ea-527c-4b89-bf03-7b982a66ad2e"), 4603, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84486dc8-7ac3-4327-98da-94509be619ed"), 4236, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8450abc9-4e13-41ab-8d68-3638fd897a4c"), 4545, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("845d3911-a6cc-4dc4-886b-ec5005a7ec57"), 4556, 7, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8460e6d9-63d1-4085-b9d0-7d0946d6cd06"), 4706, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84743c0a-94f1-497a-b624-44838f75deca"), 4306, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("847a6771-0b49-49a1-8d48-430fedb4fea3"), 4210, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84c75bbb-d81b-41d3-9d7a-a216b08eaa92"), 4110, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84c878a1-2515-433e-9cb5-a0e01f52e020"), 4230, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84d0c0f6-0aa3-4c9d-9503-d2c08192af5a"), 4714, 7, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84e8100d-d927-4c54-b96d-0e69d17efc40"), 4555, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8507d575-9ab5-4ba1-b5d5-7a24cf9ed592"), 4630, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("850c4af2-07cd-44bc-82aa-54ac252649f2"), 4114, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("852a1876-1b70-4ddc-839e-d657c464ad19"), 4636, 6, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("852a6b58-8444-46f8-ae82-edb6e5d8dbca"), 4854, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85328c40-799d-4139-8327-0c5ce306fdab"), 4252, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("853a1fcb-f658-4e89-aded-4ee25770e445"), 4446, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85478924-bba9-4776-8b80-093d939e2949"), 4304, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("854a8068-4248-41db-9c2a-5d6453d5b758"), 4804, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("855d168e-0b29-4145-8d62-a43e17d622b4"), 4565, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8590c840-e08e-4c30-b990-46dc0edffe95"), 4234, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85a5e332-49a0-4a0d-a668-59df376a7f16"), 4204, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85ae4f57-1ad1-4869-b30b-cc7225371b45"), 4536, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85c5393f-9be1-4be3-a548-88977b342338"), 4258, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85cc80d4-47b7-40a2-b556-98530885c9d5"), 4546, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85d1a230-a2c1-4378-9741-65962e34ffe7"), 4256, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85de01f3-49be-4ee0-9620-90f0b70abf3a"), 4547, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85e2feee-bd94-4804-b0e9-1f7c85c50851"), 4609, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85e602f0-6ee5-4771-9118-e7dcaa5145d5"), 4419, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85e86f1b-4eb3-4f3a-b227-ec7ce002bdf3"), 4500, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("861095c2-268a-4748-a0dc-49f53b3cf0e8"), 4559, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("861c105f-d506-4fd3-a105-d1bee7d9c450"), 4802, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("862ab112-6847-4a3a-8fc4-057bae43dfff"), 4229, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8637d010-609d-4385-9982-5d27c5486fa9"), 4255, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("864464dc-49f9-41bf-aa10-c684f4f3beb8"), 4525, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86475bbc-88a7-424a-b90c-5930f78d224e"), 4626, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("866fdab3-7c68-4f85-9209-80431d7b78d9"), 4269, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8683f9ff-3c2c-413a-ad46-c5693e2ae193"), 4455, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8691cd6a-994f-4d2e-b8bf-55b04a42e550"), 4102, 9, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8691ce8c-8e5f-45a9-8529-bf2038583965"), 4430, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86a5c4bb-b2d0-4260-9186-f6ab60a5360d"), 4653, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86b5aaf4-44a9-4241-9700-f95737075334"), 4312, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86ba288d-238a-4534-b0fc-1bc77c15d8bb"), 4034, 6, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86dd2cbe-7b83-4e40-9f0e-6551910cbd6c"), 4601, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86dfc70c-aff4-49ba-bab5-e59ad55bf4a1"), 4257, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86f43180-05d5-463d-bf7a-67222d8ec541"), 4722, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("870195c5-0cf9-4035-b4ea-f27e0f0487f5"), 4023, 6, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87296eff-cae4-449a-aee0-e75f73fa2985"), 4228, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("874c3f66-494c-4c56-8ef8-df7b322717fb"), 4718, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("876100ed-dc35-4544-824e-b1957175ba1d"), 4213, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8761f0fc-0e1a-481e-a103-cec3dcc3864f"), 4525, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8763ef7c-20d5-45f1-be2c-bc827f21ba77"), 4700, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("877fcbae-164e-449f-8da1-148ae14c8b87"), 4459, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87896feb-dc02-4b9c-bc41-ac3a6c562e5d"), 4313, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8789f499-41b8-43f9-bf53-df2b40a9dbe4"), 4452, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("879388fc-22e6-4870-89a5-5bcb3a620a9c"), 4560, 8, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8797a2fb-857b-4103-a5b1-00f68a02bf7c"), 4026, 10, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87a30dd9-d7ed-45d4-9455-3c6d629067b7"), 4003, 2, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87aed923-63ca-4452-813e-ebf111b7bf18"), 4429, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87ddbf58-c334-4034-998a-074f178bb4a4"), 4600, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88001bc4-62c6-4144-a0d3-1eab3c5a0215"), 4235, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("881f47b1-2679-4716-b3d6-b8bcb3d23463"), 4023, 8, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("884543b6-a2d9-4035-8680-a3b134c1fbe4"), 4267, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("884a63e6-1363-41ec-8f20-e7f48cf31de1"), 4632, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8853cfa9-8421-4be5-89ff-50125ad06490"), 4312, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("885932ae-3fc7-4b2f-b1cc-78b3e0bf4c2f"), 4112, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8869cc4f-9841-43fe-a6b8-bb51f4ea5eeb"), 4531, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88750b6f-d48b-4e8a-90e1-83f4be190182"), 4459, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88831ec7-4138-4157-b2a2-06a0cfc5be38"), 4630, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("889dc8d4-5ec2-46ae-a06a-19ee385eca22"), 4852, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88b35092-660b-40c5-8bb6-0481be14cd75"), 4253, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88be70b6-e029-46d2-86cb-6820f1d7f4db"), 4430, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88c52fb8-eb4f-48d7-8a9e-f5177bf66457"), 4638, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88c549a8-a27e-4d4c-958c-cb7b3ed5f4da"), 4233, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88cc5230-9169-4ee1-bc15-8cda84054008"), 4208, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88d2b69b-5ad9-429a-8e61-c8a684727dce"), 4021, 10, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88e81fe5-ea99-499b-b5d5-f65c6fc80267"), 4522, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("890e3419-d62e-4591-a2e5-fd4e9a89aea3"), 4035, 1, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89284191-b7a6-4648-8851-32fd26e4c567"), 4009, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8938a914-3b34-4f43-92cc-a0e092269da9"), 4501, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8939f8e3-883c-4221-a5e2-117841933c4f"), 4616, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("894d6d76-6400-4aba-b854-314c17810fd9"), 4719, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8960041a-e0d1-4eff-b19a-1172840d1ef2"), 4246, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("896153ea-ac6f-489e-b533-0a06acc202e3"), 4544, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89a5aad8-1acc-4759-843f-0592bbbc6a01"), 4013, 6, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89f3fe58-0897-4800-b656-00848cc2b7a5"), 4224, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a15cfbb-a171-4384-acf6-27af9cba3113"), 4708, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a963c0b-fab0-47d9-a819-552564de6e54"), 4211, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a9ad50b-0517-4e0c-94ed-3a6dfb4e57d8"), 4300, 10, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a9f1743-64c6-4f46-a11d-bcba1bcf242d"), 4272, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a9f94f7-dd37-4939-b0cf-8f40b52389bb"), 4308, 3, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ab240dc-9e5d-4bed-a387-df7484323396"), 4212, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ac67ca0-267d-403e-b768-84de353138b9"), 4547, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ad2d3fa-4c58-4b18-b860-edafaec03b5f"), 4407, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8aede507-1b6a-45af-b9c7-82fb1788734d"), 4208, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8af08021-f18a-44cd-b179-6e8df54496ea"), 4706, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b12a9be-c32c-47bb-9d0e-119e5308cc74"), 4209, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b25ce64-f0ad-40e7-a687-cce4a0481cc5"), 4457, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b3058b6-64aa-423b-a1b8-401cbafcb8d7"), 4623, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b40615f-da24-4871-9e7e-cef9deec78ce"), 4012, 8, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b52a99c-19cd-4a47-8c9d-7731b7b7adf6"), 4217, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ba3c927-f3d0-4e71-82b4-8cbb99e427cc"), 4022, 1, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8be8a08d-2064-429c-9e68-1cae483780e3"), 4221, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bf9b2e2-deac-4c8a-aaf6-f18dbef64c8f"), 4100, 5, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c184b42-d14e-41e0-beda-4b437a13c9d4"), 4522, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c19eeaf-8d00-480c-9c7e-fd2412f0f404"), 4419, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c3e259c-1edf-49d3-b3ed-597feb60b2d5"), 4415, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c4bc9d4-b76d-462b-96f3-e219e1b82dd8"), 4500, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c636318-bf3c-4b42-a9a0-5ce33d3c92f1"), 4550, 2, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c68fbb7-96fb-45fd-8b9b-ecf9fdfd7ce2"), 4810, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c69f7fe-5176-4c03-a394-47f673a26ecb"), 4204, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c783531-c6aa-494e-99d2-645913d68085"), 4539, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c967968-f614-49d7-828d-61dcdd4c5faf"), 4807, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cc5de39-f9f0-483c-ad1a-32b2f102fbdc"), 4526, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cc82537-adde-4069-a1c7-857c86fa47f7"), 4456, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cce0395-c42a-4719-ba89-b6426edeaf66"), 4605, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cdcb1d2-7801-40b0-8c03-a7d1945cbcf6"), 4444, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cea9df1-bcc9-4879-a34b-d2d131b0c011"), 4033, 2, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d02612e-0a81-4c58-8101-e9952c36627b"), 4252, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d17ca49-d66b-4b18-a60b-59f583589cb7"), 4629, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d5129ae-88dd-41ce-8e74-3476ee1c277e"), 4532, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d56d9aa-76a7-422e-932c-114e58e0deb9"), 4210, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d599f27-a0f7-4e5a-a317-88648386f366"), 4660, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d5f238b-e28c-47ef-8222-19293761be7a"), 4109, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dabc5e8-f4ab-45f9-9943-d5c684ac2844"), 4100, 10, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8db1c505-8d17-490c-b5d2-3118844e3656"), 4552, 4, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dd3b492-cc36-42e4-8f77-8b5907d087ab"), 4453, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dd6009a-7916-45b5-bf4f-bb482ca45cd1"), 4404, 2, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dde2146-ce8b-4c73-a621-87307ed775c4"), 4312, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dde70bd-d9a5-42b7-8877-9f632c21ec89"), 4200, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8deb268c-2a7d-41e4-9974-c5d6f3446281"), 4525, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e047b66-81da-4c62-8508-bdb6dffb5d36"), 4600, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e1aefed-ee8d-41a2-875b-b81bf7025b12"), 4307, 7, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e23ec7e-8939-40c9-8fe5-76e4cfe103aa"), 4267, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e2bfb6f-9dd1-41b6-9210-7601e3093592"), 4553, 10, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e35765d-25d1-48d8-bc26-50ae4fcae40c"), 4527, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e40231d-dd57-404f-8718-71d942e01e82"), 4702, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e437beb-2500-4239-83c9-0a6da6a597fc"), 4506, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e494fab-1cae-43fc-b47b-5895cd1c4801"), 4012, 7, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e63c188-5d28-4af0-b87f-89a706dab1d5"), 4253, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e67b383-2d5f-42b1-8214-c7d0ba234a30"), 4801, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e700475-59c6-4149-b09a-72406411e4b5"), 4635, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e7f18d1-027f-40ff-b340-34d02eda73f6"), 4210, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e80f5fe-e582-40f4-8ad2-0855e355e9bd"), 4627, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e89b44d-a6a1-4514-b964-cfa0b60ed2ff"), 4216, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e8e4fdc-9c3b-4634-983d-277a3384ee62"), 4254, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e96782b-094d-4a27-b918-09d68d687bd2"), 4851, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ea271d5-7582-4ab5-aa85-7079925e4301"), 4257, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8eb8b61e-18b6-4266-ae14-29e1494d1f02"), 4611, 2, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8eb944ea-4308-4459-9345-c9f7c66bd497"), 4807, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ee1ab96-7eb8-4058-a142-c485b85d54e5"), 4254, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8efb9e51-82de-433a-bc3c-eb05a0553db6"), 4617, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f088df8-6293-448e-ac5c-0b0abb693550"), 4411, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f1d05d2-0b95-400a-ad3e-f2f6a0a6106f"), 4004, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f1fcadd-dbea-4334-b9d2-4b5f3ad7f22c"), 4853, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f63451a-9507-47de-8a12-6f41b79543ee"), 4419, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f678fd9-0334-4cfc-8061-9be63781fd90"), 4027, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f6ac405-546f-444b-90b9-82abc9d49b5a"), 4855, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f6db50f-8a8d-40dd-90b5-747481540524"), 4602, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f8d2ece-a977-48dd-bbd2-447d479f59ea"), 4271, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fd66e57-06fd-4430-9bab-3439d69481eb"), 4713, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fd8f9dd-6b9f-41b1-9039-4a1273454d11"), 4540, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fdff6d9-b24c-44e0-b270-81e1f6358fb2"), 4454, 2, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90258e70-535a-481f-9160-4e6b68effac5"), 4621, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90325830-dee4-4d89-86db-e88dc32725c4"), 4641, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90345226-7ff2-4cb2-b2a7-56dcb37626c2"), 4244, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("909ca227-0537-4f1e-822d-94cc85482a44"), 4423, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90a8e90c-af5b-41cc-823a-7083cfc418f7"), 4205, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90e4ee93-519c-47f6-ad81-166ccda651bf"), 4551, 7, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90f882e9-6cec-4b4e-9ea2-36d33c4fc278"), 4002, 10, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9107725c-405b-4591-8b66-1dea69e3a3e2"), 4854, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91105cca-5893-4c7d-89bd-40e024573338"), 4105, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("911f104a-b272-4395-88b3-024cc2536fc8"), 4268, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91273150-8f06-4f9e-b26c-a92fa281823e"), 4852, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9138bc61-b314-4227-902e-1c757450f37a"), 4565, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91469a43-bac4-48e6-89d2-1f8056d3f572"), 4556, 1, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91498832-dbae-49c5-923c-c6ea75f113fc"), 4274, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("914f3394-55ee-4a4c-943c-25b915073a47"), 4212, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("915664df-c049-452f-8be1-ef7772136850"), 4318, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("915a14ee-612a-4b64-a30b-b2f2219e7939"), 4226, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("915d240a-79af-49c8-bb8e-bdf7ad183100"), 4443, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("916bdb3d-9348-4252-bf0f-0b71668ec31f"), 4232, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("919a79ab-bf0b-4889-b775-19a8bb5ee3d7"), 4611, 5, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91a4ef5b-5604-44c8-bb6f-beed6c00dc9b"), 4214, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91c2771e-1c34-4fb5-881a-aa22b142a1c8"), 4600, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91c3040d-fece-408a-9115-37733dd65d37"), 4563, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91c5e458-8a10-4038-aaa4-6e2d08b847da"), 4112, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91c70549-cda9-483f-b0ad-45b2e14d1cf5"), 4632, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91cb5887-9e7d-4262-9776-92987c3cd4f5"), 4461, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91d79ed1-e482-48dd-b47b-d1a1f4aa1079"), 4237, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91ed8a7f-6a73-4fbb-8359-4da879f883fe"), 4533, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("921526d1-b030-4d09-bc94-fd9fbe4071f1"), 4624, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92421ffc-b4ff-402d-ac7d-48b61d112dc7"), 4717, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9262279d-f828-4456-8008-64a408bb76a8"), 4231, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92738d71-8312-45d5-add5-009b84d1984f"), 4270, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("927c9ee3-5618-43da-9b89-94bac8d5eb6d"), 4701, 4, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("927cd2d8-f155-4e22-a3e5-edec4406b88f"), 4103, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("927dab11-3f60-4f12-b4b5-8ec506b146ed"), 4221, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92a15058-3e10-4995-933c-8675323bf7ed"), 4717, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92a526de-ef8e-4328-8334-902d69f5607d"), 4221, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92b31ce2-57df-4a22-b3d6-70a85ff82672"), 4316, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92b7607b-9021-4889-a50e-a9574b584308"), 4008, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9343512e-6e09-4ff4-8bd4-4028b344dee6"), 4809, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("934b1784-e24c-48f1-93f8-b8ee24dba317"), 4004, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("934de6cb-87d0-4370-b50c-8c037d8f5727"), 4020, 6, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9352ce0c-0f08-4297-8fd1-e7a9a682bed6"), 4533, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93728b9f-9af8-430d-9ad0-512ccaa44830"), 4417, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9375b0bb-219d-4d58-8513-f7e9fbae5047"), 4708, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93b7b973-449c-4fb8-9951-714b84e217ef"), 4008, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93bcada5-cefa-40f5-b7ab-82128a7dff81"), 4312, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93bdb7f6-3408-4e4b-948e-d338966c310e"), 4511, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93c848a9-8a41-4702-9f83-e88ecdb8ac42"), 4433, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93eb7570-9c0c-4525-9fa5-2f1fd7efbdaa"), 4239, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9421a25d-eea6-4270-a491-5f5f0c7123bd"), 4452, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94498cf7-f1b8-475e-90e6-951e5d0f537f"), 4659, 2, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9453eb0b-ea64-4b49-a02d-47f629d657cd"), 4028, 8, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9480a427-efef-4e00-bd5f-96998e5fd6af"), 4401, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94939eca-6e52-4c74-b7e8-66f12d39933e"), 4455, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9494648b-535d-49ed-b29b-4643f3b61881"), 4610, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("949d661c-5a78-4aa6-81dd-224995b56972"), 4723, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("949f1396-0911-40b9-8189-8dcdd03843b5"), 4240, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94be38f1-643f-4a79-ac53-d9f6f97c3ee9"), 4651, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94d65ad0-5f81-4417-b4a2-602ec666b8e5"), 4565, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9507bc2e-53b6-4414-8517-580c60d1b9a3"), 4703, 2, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95122efc-b62f-4e24-a9ae-13f253173a1d"), 4461, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9514f694-1472-43f4-985a-0743e9dacca8"), 4210, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9518749c-8919-4792-8e0c-4e645959edf5"), 4306, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("955bfa68-6e9a-476a-aa51-5d435a3f37ea"), 4024, 5, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95683607-e9a8-43a4-be4d-ffbb7f13e21d"), 4508, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9573c3d5-1bf9-40a4-9637-0cf7f7e2e2b2"), 4565, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95a451a3-75e4-4d80-9f67-22a7244b104b"), 4207, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95ab6d83-c896-46c5-9dd5-4e4b84f99115"), 4708, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95b4d207-94df-42db-a490-3ce08c14607b"), 4528, 2, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95c05dc7-34db-4db3-9713-09b90ff14c0c"), 4030, 7, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95c43611-cbf0-417e-b321-3f509c3050fe"), 4236, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95cfd490-7913-49ac-9759-1db5391e6f38"), 4318, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95e8c2d6-a140-4063-836c-1cde68429a5c"), 4425, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9609932f-0569-4450-884f-4e4f2daede6f"), 4319, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96250aeb-72a5-44f5-ae9d-d5b2f86eb650"), 4605, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("962593cd-3a6f-4b8f-8aa7-6053220f15c3"), 4603, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9626f1e8-4bb0-47cc-8e2c-02092402cca6"), 4464, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9644d710-1af3-466b-8077-813ea0890b2e"), 4407, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("965b4e77-ae9c-454e-8582-87a6c2062107"), 4225, 7, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96a127dd-c484-4667-a6c4-c04340bb91fe"), 4532, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96a15b32-d74b-4887-a2f1-25112c177c79"), 4233, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96ab6db2-a221-4845-aaeb-ac93f73a2417"), 4543, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96ecfea6-1398-43cc-b129-0781cd80fe62"), 4022, 7, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96f6b1d2-36ca-49ea-a11e-acdff1ea9786"), 4231, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97057b99-648a-4888-b688-8909b44639fd"), 4447, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9707aa41-bb8f-404c-882d-56998375a8d0"), 4323, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9708d645-7dda-40e1-9be8-f34da5e10a51"), 4711, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("970e0b82-d4e0-4d47-ac1b-46ef26ab5447"), 4037, 1, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9721c501-44cc-4b7a-8688-1b7baecbe060"), 4562, 7, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97223fa4-cb77-44d0-b429-7b6bb1555b17"), 4429, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("973402f7-0644-4794-beea-35f14abcc7e0"), 4854, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97344441-bf59-4b6b-92f7-0ec648aad3fd"), 4250, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9745943a-842e-49ee-903f-68841f397475"), 4243, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("974f72a7-c18d-4f4e-81b1-2dea35455272"), 4660, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9767db9f-81dd-4bee-b22e-1c4e40f2db00"), 4015, 4, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("979339b5-ddc2-4997-be68-d0fc4bf7f9fc"), 4702, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97a02aaa-6caf-4204-9031-bf75434a3aa9"), 4529, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97af1133-83e2-4342-99d6-9deef7f6d3ae"), 4720, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97bc15f0-d166-4b7b-9ed1-91ad47328045"), 4241, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97beb5ee-52c4-40b6-873c-d5c1cf461b45"), 4707, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97c42e4c-c551-4064-bc10-5821048c220f"), 4113, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97c6aa67-44d0-4e9a-b2ff-25496122b077"), 4519, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97e2766c-d572-4c96-923a-adef737210e1"), 4248, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97e4b62c-7163-46f2-a1a4-9b017475f875"), 4716, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("981dbdcc-4381-4d2e-a999-ffa13dbbad1a"), 4106, 9, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9821dbd5-becb-485e-b05a-329f4e7f49ab"), 4262, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98263d5f-30ce-4382-a01a-b1985082b23c"), 4558, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("982935ea-c064-47d5-980e-72d17cc1b993"), 4451, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("982aca02-1c05-4c1e-aef7-ee4600b9c5f1"), 4210, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98457147-3b94-4e66-9610-bfa27aa7921f"), 4459, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("985fe5b2-2ce0-4507-83d4-de76476f0e3f"), 4408, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("986038da-3c5b-43fc-886b-f6b7f0d84eb2"), 4026, 5, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9878c9c6-9a10-41a1-b099-b524041df9f4"), 4561, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9892e2f3-5bea-449c-85c4-fc63332b0c9e"), 4263, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9896f848-d0d4-4ed4-9353-312e04f393c9"), 4455, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9897b58e-cff0-4715-b42c-9dfb8cdb4cf2"), 4408, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98999103-a19d-4fc2-aad7-da3cd8a7123d"), 4201, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98b15149-1bcb-43ab-bf8e-a3fe8a7ff930"), 4434, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98b3188e-ed8b-47ba-ad8f-23e98cf9f1c1"), 4303, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98bda263-070f-45ec-92f4-e3873da56343"), 4207, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98c1246b-813b-4f28-810a-feb15a9c8fc3"), 4662, 1, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98e8e80c-ba32-4e51-a6b1-dc8b15007b9e"), 4463, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98f2d69c-3957-460c-9451-949e2f3b5346"), 4614, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9901357d-73f7-4d31-a244-414c0c8a429c"), 4247, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("991d1d48-1cab-4185-af0f-d4f667b1d69f"), 4458, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9956facd-fd19-40a3-862b-b34247a35a52"), 4618, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9970dfe4-3b84-442e-8c32-8c4b5ba8e6d3"), 4273, 5, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("997682ba-9c16-427c-9851-28de5d7b62fa"), 4208, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99972038-f4a3-407c-9296-525255f66d2d"), 4622, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99ae0c9a-a52f-42a4-a0f8-52699bcc17c2"), 4519, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99c3743e-f125-4e06-bd1d-1e4f9bc90fc8"), 4321, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99d691ca-4ea7-4c5b-97a9-b5622e90a07c"), 4302, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99f431f4-7933-4886-ae89-4ebdc7f10668"), 4601, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99fbc4b8-f592-4064-8f35-4999b6387b36"), 4810, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a0592dc-6e6f-42d2-8a06-ca903f992f1d"), 4302, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a271ca1-6dac-4a05-a7ea-a78dadb3414e"), 4205, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a297c6a-11e3-46ad-9210-45e6958d4db9"), 4450, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a383861-cdcb-454b-9c29-b358925d30f6"), 4661, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a5e56eb-3aff-48e7-9df7-c31c64539aab"), 4509, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a748ba3-b7bd-4243-a313-3869c985a5b8"), 4311, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aa22a52-c983-4df2-a1c9-3ffc7126d579"), 4318, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9aa741bf-c622-41b1-828c-b315487e9fb8"), 4311, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9abb27fd-8b0b-4f7c-b669-1077d6370bb1"), 4217, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9adeebde-5657-41d8-a69c-35cba832dc6b"), 4523, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b00715d-9e4f-40eb-92b7-edee8ec0d8b8"), 4015, 8, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b077273-3e9b-478d-b344-22e0c77bfda4"), 4304, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b0d566d-2a3d-45dd-9e35-e26fbca1d148"), 4251, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b0f90bb-1634-4512-83e1-77d0c37d1b13"), 4442, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b1d0d9a-8ad1-43ab-8955-44d55f944a4a"), 4706, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b5eca9b-742d-4ecb-9de5-555653c0c8e3"), 4463, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b64c8a5-a78f-4c15-b765-4dbcbf0c5d85"), 4438, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b84fba4-96ac-40c0-bda4-7b4a2a3dbea1"), 4619, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b9312ea-83bd-4826-a16a-0954d19fcbfd"), 4633, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b9caa08-12e3-4ed1-9f40-0f71c2adc6e1"), 4036, 2, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bedf988-831d-4245-a458-b0d0729c9fc4"), 4010, 6, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bfa8cea-f7d2-4ea5-bbce-44ea4f7ce00a"), 4005, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c033be7-6f08-4dc1-8b34-76b82afe12c4"), 4413, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c11b371-345f-402c-9835-690bf35521be"), 4269, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c12ee10-babd-4d48-9ae8-d4562a651729"), 4237, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c17bfdb-3960-4014-b4c5-ae2497849396"), 4464, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c1ba293-9d99-4ce4-8ae6-815803d8a622"), 4316, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c30f376-f82d-4330-b1a2-ec4b2b4b7166"), 4415, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c368971-e778-4631-b73f-67604cd2fde1"), 4650, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c378591-af4e-436d-bd9b-0f0a2796895d"), 4602, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c3b1932-8ce8-49e5-a579-bf354bf3610d"), 4431, 10, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c3df388-2cca-4b3b-953f-7671c7dc9ca0"), 4115, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c6e1848-b741-4641-90bc-95ad61807690"), 4523, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c6e2d6f-9fde-426e-a143-a09691c02ece"), 4003, 10, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c765931-9613-4b47-8b7a-3e07ed6a2ddf"), 4005, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c82590a-f549-40bc-9bc7-6bb50bc0f397"), 4459, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c90e28d-804b-4e50-962e-506c5655b01e"), 4541, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cdd084c-620b-47e6-a950-4c8ea2f83fa1"), 4531, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ce755d1-d7ee-4f90-9dda-67ba6c007336"), 4451, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d1e5053-678c-419b-bd59-328af0501167"), 4502, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d2bd17e-9db9-44bc-af3f-e653fe94f4e2"), 4437, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d37c8d0-4ed6-4fcb-bf4b-a18a350cf0f2"), 4545, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d442c35-cecb-498c-be97-f0770fa6abc9"), 4703, 1, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d73bb64-923f-4e81-a8b4-fac15fb63a5b"), 4234, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d74439c-368f-4cdc-9e9a-c86f71712462"), 4631, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d7bcbcf-61ad-429f-9581-17c6979049da"), 4101, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d8e900b-93f9-478d-8842-321c310df2c0"), 4232, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d9bc18c-14e2-4ade-8d83-be01952af0ec"), 4265, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dab1671-be91-401a-8c64-c33d4c405d6c"), 4208, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9db19a03-c7ec-4944-8e34-f8e6ebe34ed5"), 4436, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9db5299f-d10d-42b7-a0d7-7f4690175460"), 4657, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dbaf45c-ea8b-4767-8b84-0ab332f905fa"), 4712, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dde0d5b-8eec-49d6-b8a1-114f325d387f"), 4420, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9de39e8d-0172-4afb-8e29-97875f0a2211"), 4630, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e19fe09-2bc8-4065-b345-5e35fed8c491"), 4213, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e203749-3b77-4189-b51c-95aba554086f"), 4405, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e2048c6-5343-459c-ae0e-7486c535a7fa"), 4517, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e3be833-4ca0-450a-9d29-67d5c55eaee5"), 4026, 1, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e4656b7-3fb9-476a-8ffa-6a1d937ff244"), 4400, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e6a75aa-d2af-439c-89b8-4aead3e5d6cf"), 4031, 5, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e76d16e-b66e-467e-95d5-a9ed8c214fa4"), 4105, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e7a77d7-4790-40aa-ad91-2c09ba5b6bfd"), 4253, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e7ebdaa-8765-4eb0-8a92-f1c6510ea259"), 4712, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e8dc0be-badc-4f4a-b4a6-cccd5b891ffd"), 4115, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ea70fb6-f898-492f-b772-721a2ec37591"), 4218, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9eb29772-5aea-4b1c-838f-f676a5e07872"), 4237, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9eb30ce3-ef76-4500-98f1-0011e4a7c55e"), 4306, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9eb6a1b6-fcee-409e-969d-ffbd17506833"), 4101, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9eba92d7-4437-4105-867e-0dacca21e1ce"), 4011, 1, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9edfb992-222e-48f5-9989-fe3edbf6e848"), 4422, 3, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ee95a97-e9b7-44c1-af5b-8be95c62af7e"), 4310, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f0829e2-d110-4f7e-b8a0-914f2ef6c4e1"), 4402, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f0f0d71-d7be-4089-bae2-336408f83a02"), 4560, 2, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f176773-6740-4ad4-85c0-6d3f042c201d"), 4436, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f1fc188-aba1-400b-b865-39282ce8fb9f"), 4525, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f2680ea-ae7c-40e5-80ba-37e602f8c815"), 4037, 5, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f4d0658-16bf-46d0-b2e7-05fff973ba2c"), 4268, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f6741d2-4e7f-4cab-9a2a-90aec1df8064"), 4614, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f7af703-24d9-430d-a4fc-5b2e9518dda2"), 4458, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f82a97c-91a9-4229-9036-188364158931"), 4405, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f914451-b005-4256-9851-495f7ccbce35"), 4311, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fb0521d-1d9b-4200-adb0-db7cffa83426"), 4250, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fbd2321-8345-4322-8744-49f7313e8e16"), 4207, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fd9eb11-149e-4dfb-bc70-1e0a293aec1f"), 4318, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a00b6646-25f4-4962-8bf2-09ba56c34315"), 4558, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a00e3e6e-b436-496a-9950-8d2823179d97"), 4443, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a025b369-e35a-4c92-b965-3141c76a0e8a"), 4430, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a03181db-7257-4d7e-bd86-26d87a108945"), 4217, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a047ecc5-c25a-4755-947e-2034ce787a49"), 4539, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a04c74a0-241b-4297-a363-e0ba04a27ff4"), 4206, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a04fd429-b9dc-4298-9af9-6190b40eb5c7"), 4437, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0656cb1-4071-4f79-b291-883a097628ea"), 4557, 7, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a09c61d8-15a3-404f-87a1-4ec06012cc8d"), 4403, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0af1762-360a-4539-8836-d37aa622323e"), 4100, 7, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0ba0863-43ad-4b5f-82a7-621a7f5ccaaf"), 4022, 5, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0bbcd0c-1287-4f5b-a751-649aec297139"), 4523, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0d4520d-db90-4b6e-b01d-7b8332db1ebc"), 4650, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0d99b47-6cef-4aab-9023-fffb8af9d9d8"), 4634, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0e3bd5d-1bca-43be-ab5a-876ea7620f0b"), 4240, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0ed21fe-8af3-46d0-ab6e-93c10610afee"), 4601, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0f77294-e687-4a05-a8e3-c470846f0b9a"), 4021, 3, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1045f03-e86b-45b9-a0b3-207b2e9131ed"), 4105, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a10f68e4-6015-4731-bd8a-fe5a13c89c8c"), 4714, 4, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a11dac08-e68f-4c21-924c-8a6ae9c82e4a"), 4237, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a129f638-41ad-4e4c-88d5-37790a64ce20"), 4610, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a12a2b55-4181-49a3-9b54-67440b951615"), 4209, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a134c52a-97b0-4e27-bcf2-d21c45f7e1c9"), 4803, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a13932ab-76a7-41dc-8c1f-d088b6f61202"), 4527, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a144032e-704f-4ae9-983c-bf02b5f1407c"), 4631, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1522778-8633-4b19-996a-6190192435f0"), 4443, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1532a49-5c52-4b77-8e5d-6da534f54e81"), 4406, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1564e10-bd7b-40a7-9d70-6ca2100a3c60"), 4622, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a16b6b10-4b63-4b0e-a739-4f3d36c7e4c6"), 4017, 2, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1710780-ad3a-48cb-9f38-82227267ffa9"), 4456, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a17c33da-8b28-4744-80b1-2eab7fcc0330"), 4428, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1861ccd-396a-4dbd-ad2c-ce2c7d240d35"), 4809, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a18d4c72-7808-4040-b841-adf636b8373b"), 4719, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1a72c77-cecd-4b0c-b430-043d696744a3"), 4240, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1b07c63-8f27-406f-9f59-50d1948de494"), 4261, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1b559d0-c754-450b-a1a0-0c6b8d00f443"), 4534, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1bdfe98-796e-4f33-bfa1-024fc7567edb"), 4426, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1c83464-e324-4017-b442-640bff66fd3d"), 4713, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1fe181f-e550-4291-be59-3696eb8c485f"), 4542, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2038c3d-638a-49e9-a49f-35de09ac5c9b"), 4656, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a210570c-41ef-48c5-863e-514d5eb00667"), 4420, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a221ff4b-2fb9-4305-bee3-2ca21e1804c2"), 4441, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a22c182b-8978-46b1-9ec3-3563fec1192b"), 4262, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a245da53-e656-4611-80a6-d60351a7710d"), 4211, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a25181d2-dc5b-457f-84e2-b217de046267"), 4228, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a26a2c71-5353-45f0-842c-9a85f41474b1"), 4023, 9, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2860bdb-d877-4404-aab0-0ea7e902774a"), 4721, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2a9b2da-7b46-46cd-8958-21a7562aa94e"), 4005, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2b035ac-d9b5-456c-a320-e22d303ae43d"), 4406, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2bd38e1-8869-444f-870e-ef56134afc5c"), 4224, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2d278eb-6013-4a15-861c-475d69111dd6"), 4417, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2daf6ed-07e6-4e54-a2b4-e898e4bc1319"), 4260, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2f09227-4075-4307-8a9f-cbefd6b903fc"), 4242, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2f37929-3e2d-48c8-b941-146cb1415e3d"), 4319, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a300ed71-64ae-42c0-a9d9-d02b944b1576"), 4011, 3, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a30fd61e-bfb6-46d5-b017-25dbdd324cb1"), 4615, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3152e6a-59f8-4f4e-9c21-c2a5013ee7ba"), 4441, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a31f373e-2cf8-4fdb-b5b3-e41d68adec1b"), 4852, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a32d458f-8011-445f-9b51-bedcfacc20d2"), 4721, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a33f64ec-5ea2-4305-9398-31a8ff890f5d"), 4019, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a34d41a6-32aa-4d31-b4ea-0f9aee199496"), 4442, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a364ad2e-aebd-4c8a-8136-e83192d27471"), 4722, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a369c5f3-1b02-4875-84cd-30dceb0a17f5"), 4852, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a36c9991-e256-4b41-8e4b-cfe4f36426e4"), 4025, 2, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a384a5ec-b7d9-4169-b580-6f3bfcf374c9"), 4627, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3898fe5-5aa3-4d7b-ba51-80ead564caf4"), 4628, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a39239d7-74d5-41d6-8c1f-6c7b312da96c"), 4409, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a39a3099-5f7c-41b0-82a3-76fe973cecb1"), 4855, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3a80325-ad42-4198-83a4-dba56457fe76"), 4632, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3bb98d9-712d-4aa5-9c46-73b27106f852"), 4461, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3c6675a-1052-41b3-8173-868d3ec307a2"), 4505, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3d453f8-8ad4-4d90-8f9c-6b07a8c8a80a"), 4616, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3d58d53-9d7a-4def-9a92-c59244de6467"), 4034, 8, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3d66484-c3cb-4761-a8f1-491b70378080"), 4249, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3df74ef-2ec3-40b9-9397-20a075eff2fe"), 4616, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a40f8f53-f1cc-418a-aa8d-b385e3087f68"), 4250, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4236da1-6bdd-4a56-be64-730d8f9b3760"), 4852, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4305d6f-0077-46ed-aae6-162b856e0b67"), 4465, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4403d53-41b8-4948-81d1-3ee556ce4be8"), 4559, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a44c7321-dc4e-4620-89c6-b72bfa15920d"), 4023, 3, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a451ceb0-ce0d-4238-aa06-0a6fc03cd110"), 4444, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4764ca1-9752-4e96-80c0-4b28820bd474"), 4424, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a48fef65-89ae-4c61-bf82-cfa7d9765a5b"), 4617, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4923b85-b494-49f8-840b-e419073fcee8"), 4220, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4c4784d-eb7d-47e0-9844-45e82458a40d"), 4012, 6, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4dae571-f906-44b1-b06d-162c1198cb4e"), 4220, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4db3bd5-e305-4f07-b364-02f0881374df"), 4232, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4dcacf6-7583-4e28-9b07-4d90b2be8dc5"), 4305, 3, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4e62214-f1e3-4bfc-9b3f-166700c9b2e7"), 4709, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4e67b5e-0b60-4350-ad7e-8a70dda69616"), 4534, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a50d1b98-564a-46f2-b7a9-71d1468baf17"), 4628, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a520db3a-8666-4b80-bbe6-f4bdb50b78b0"), 4606, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a52dfa1c-9019-47fa-8f58-f67fa9233b4d"), 4409, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a54f201c-0b68-4a8b-bd91-0db356edc629"), 4029, 5, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a55d90f4-93e5-405a-a375-171a910800aa"), 4436, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a57b1daa-7b3f-4403-9beb-0d21e2fd4436"), 4308, 7, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a581e8e9-fd94-4be3-aabc-a663f472eff1"), 4545, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a584ee8c-b845-4b78-96bb-2cc4d6f12b6e"), 4612, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5853721-0226-4996-9615-7932d4398a44"), 4263, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a59e883b-4764-4111-ab9c-de2b903e48ae"), 4424, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5a8ee51-9a3e-44ab-bdef-f7fe33d46003"), 4034, 5, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5c33cc3-a964-4e2c-a904-953f50d5779e"), 4550, 8, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5d10a30-d4f9-4f55-a130-eb957cfe643f"), 4108, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5d3e368-500b-4b8d-a1ea-114f44b22c14"), 4707, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5d523b8-aa93-4cb5-95e1-cbb249ee4a76"), 4317, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5f005d9-7a64-475d-ad90-cc755fb54049"), 4557, 8, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a619e8b7-08a1-4491-872b-5243a8a94bb6"), 4263, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a61c916c-0a90-425b-8065-9d0691f9ca4a"), 4236, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a62707f6-2d15-431e-9b83-39972b77e084"), 4008, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a654801f-fe8c-44c7-bc60-722effa128a7"), 4445, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6558aa8-f94e-4e3c-adbd-cb3a8a443972"), 4114, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a664e46a-71ab-4128-9c89-446f13a2867d"), 4808, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6690cd0-42a9-4357-857d-d2c5d94ecd8b"), 4856, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a674c6b3-87b6-4e81-b08c-2255359abbec"), 4702, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a67a234b-0d44-4f00-b526-699d0c0c9bfd"), 4606, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6a5b14a-dbbc-45e2-84d3-0000e1a2f276"), 4205, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6b44e34-4a52-41a3-84e4-27a333ad3600"), 4421, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6bc1b13-b862-4981-845b-7a98b03879c2"), 4412, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6bd6968-c0c1-4a02-925c-1a559d4dcbe2"), 4403, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6c05ff5-7b0b-468e-834a-d1bb28b31bd3"), 4226, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6c6f1ea-b3b4-4101-ade5-233215a8c108"), 4804, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6e4c693-5c43-4649-baf2-8b43ab477a86"), 4508, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6f4067d-3804-4150-94b7-783aefdf5d1f"), 4546, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6fcd1a9-75ca-4eaf-a88c-65f816f751bf"), 4111, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6fe5cde-aaaf-4c9c-bf90-dbf391267359"), 4439, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a71776c9-24c4-47c0-ab87-59571a879f57"), 4534, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a71fe662-2efc-459f-ad05-8a6b750d2baa"), 4603, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a729a78a-61d8-4cc6-8044-8ebfd8281e8e"), 4201, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7397ca7-22a0-4abe-bd8e-6cf3abcab196"), 4109, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a753de33-0c26-4f03-aba5-e8543ab20a87"), 4705, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a75403d1-d144-445f-ac3a-110a133878b3"), 4706, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a771fcf0-7b03-43b1-8ed5-cfe736191ae2"), 4206, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a78c7f3c-8db6-4e7b-a32c-a1daa54f9755"), 4632, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a79cc2c2-cdf5-45f9-9e20-5896f3cc45e8"), 4308, 2, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7ab4148-d9ba-4d9d-b0a2-71efb8061031"), 4634, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7b5808b-01ce-4772-b615-3c70be32d2c9"), 4660, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7bbc99c-24ed-4524-bf54-a5daf83968c7"), 4106, 10, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7bd30aa-4cf6-4bd9-95d3-a0a982bef65f"), 4602, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7c71a7d-dd96-4219-88da-ff8d9388c9ed"), 4553, 6, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7c8bbe4-7ac7-49c6-9f03-6b3adc45d31e"), 4230, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7d3dc9d-563c-4e43-834d-34236babe609"), 4558, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7ff890b-a93f-4e2b-a88e-c8b819894574"), 4441, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a81f722e-7f8d-4fce-bc6f-91c2873a0930"), 4457, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a81fc8d2-6430-48dc-af8a-ecfbac52edf3"), 4640, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a83258fe-25c5-48d9-8b92-bcb3fe6bdcea"), 4262, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a88a5fac-6791-477e-8b71-23706a2fcae7"), 4514, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a89dae88-fc08-4f0f-b04e-25d641973fb7"), 4535, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8cd1f0f-87da-4c1e-a0c0-a38c07274e7d"), 4540, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8cf7bb2-75fb-4973-913f-8bd2e46b4c67"), 4007, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8e4c137-52e1-436d-8857-c9317fc5a305"), 4553, 9, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a90dfef4-b32e-410d-8bcb-16891ec987c5"), 4632, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a911a9f2-e87e-4061-b40f-fed9431268aa"), 4638, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9175f7f-d06a-4c8b-af6d-b3deaa778a89"), 4547, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a92bf2f2-7613-484c-bd6d-892cea6a452a"), 4720, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a94c57bb-56b6-441c-89e6-5ea273852cd9"), 4419, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a94dcf89-ecba-453d-a58d-76f116068c75"), 4616, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a95241af-42c3-40ef-b26f-b4e3b171296d"), 4020, 10, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9587c70-10ff-44c3-82a0-7d66d77c7090"), 4801, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9610187-ab40-421b-9678-36880012fb1c"), 4113, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a99517c9-8b08-4863-beb4-25ebb57bc600"), 4462, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a99c873b-a74d-41d5-ad91-e348030b3e23"), 4500, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9a4874e-2f67-4fab-a5c1-41b2985b0e69"), 4562, 3, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9b8cd97-04e1-4578-a956-e526ff251882"), 4201, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9cd59dd-0d0b-43c0-a90d-037872a030b9"), 4714, 6, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9e8189b-efdb-4aa5-b5ca-3ba866de0a26"), 4563, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9f1a339-ef76-4f0b-bc52-c92ea7fb13b3"), 4605, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa1a1d6e-9ebf-4f43-a211-8796e577dd2d"), 4516, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa1a663b-cf55-4530-9715-b58178cb827d"), 4007, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa3ac2a0-357c-4ff6-b5fb-49ef16b86947"), 4807, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa3f331b-5894-43ea-8ed4-01c6ddc706fe"), 4413, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa483fda-458a-4efd-9294-9b083d5411b5"), 4009, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa487025-bb7b-4e07-a321-434d3a3df57e"), 4255, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa53a80a-de2f-4096-94f0-38b98247a3bd"), 4264, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa5666f3-cf18-47bf-9a01-4c224acbefc0"), 4706, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa6881f8-c80b-4b58-93d2-ae380dfdc180"), 4621, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa86ed7b-f4d0-4843-ae0f-03bfed2676c4"), 4627, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa8f7b23-ba49-46bf-9219-6e2505fe6926"), 4239, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa91943a-7f03-4569-ab5b-1bc279a8e3d4"), 4209, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaaea032-f56a-4e60-936c-240f852d3d34"), 4257, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aabf0ca0-120b-4949-99d9-6fd7a2d29a6b"), 4455, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aac1ded5-554d-40e0-ba93-34bb35475ed3"), 4561, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaefb18a-e6e5-46d1-b378-7e626ce47c6f"), 4551, 1, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaf0fe22-4083-4725-992c-289d112d3e21"), 4436, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab14d439-9c23-4dfb-9ac3-3f8ab1923577"), 4024, 8, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab14edc3-712c-4858-9b9f-6bb9c28a7b48"), 4230, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab177f77-537b-464d-9376-6ea0c6ea48c4"), 4264, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab18f48c-4ce5-4b23-afcc-1c4710713f0a"), 4442, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab29003b-bb4f-44f7-bb89-1c924df8e3be"), 4235, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab42d28f-7d4d-45ac-ba1e-45fe362befd7"), 4256, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab43f085-0c63-46c9-8a4f-c56031818426"), 4425, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab4cdca0-b27d-4d9d-95f7-b59b69230822"), 4521, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab5124ef-2b53-427e-9fe8-516f44ce4a22"), 4501, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab59af79-c085-4059-8616-e5a69f9a4f6f"), 4433, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab5dd1eb-b6af-4d5d-ac5f-f894dc027f18"), 4563, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab64bd1d-95bc-4cc4-b77c-22d054a6c08b"), 4322, 5, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab72ace9-d26c-4c86-acdc-3ee3189041d0"), 4460, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab80a2b1-34d0-40b4-b1b4-b46855b32dff"), 4653, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab8fe7b6-074d-48b3-a2c7-dcca1a2cccf6"), 4231, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab9c66b5-9fe4-458d-bd4b-a2f8aaa6e728"), 4536, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abaab452-bc75-42c4-943a-524dddcf6807"), 4030, 6, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abb774f1-d6c9-48e8-9949-145331fd5be3"), 4221, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abbb6496-25da-4a0d-b8e6-7905e78fdcc4"), 4516, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abc510d5-04da-41fc-8b00-a1c664fc783e"), 4209, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abcbb13f-8247-49ef-af48-1f028a81e87d"), 4223, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abdb5b55-0b68-4761-9c9b-791feebd6b80"), 4200, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abdcc336-63b8-4afe-87dc-b2344eafc013"), 4435, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abeba34b-5c18-403f-b5a9-c4b6ff5b2c74"), 4317, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abef7bb8-f021-44e7-8312-36862fc08645"), 4609, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac1413da-c7b5-465b-a77a-ec3a939fd4ce"), 4017, 9, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac16bc91-8d42-4d0b-8c4a-1dfd2fdffc6d"), 4211, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac1d5296-77de-4827-ae0b-dcb94dac7f54"), 4026, 8, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac21a0b4-7e67-4081-8e2a-4d55b45885d2"), 4401, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac2cf710-9f60-475c-82cd-adda485395bc"), 4427, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac37c1bf-edf1-4e20-87a9-8bc22e3a4f3a"), 4266, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac5edbb2-88fa-4bde-983b-48369894dff8"), 4266, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac6c732a-ab19-48bc-a6c6-da175b0c54ad"), 4623, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac7ace57-8d74-421f-8343-4add9c23dbcb"), 4319, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac7aeb49-d337-46d4-a963-d93ac3ab1cba"), 4721, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac89dd78-64fd-4df8-981c-9f3b7dfef592"), 4426, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac9be883-cb02-4647-ada4-8e7a8d5a7327"), 4604, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac9fdbe4-6c0d-4e8a-b24d-a6521def1862"), 4460, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aca64dec-c2c5-48cf-9e06-8d457823c6d4"), 4239, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acb79461-eb67-4a44-81dd-18c8453d7b23"), 4651, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acb9ac0e-0c1d-4d2f-9148-b730df6c3df3"), 4808, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("accc4aa1-37cb-4bfe-ba95-455ba25b4b8c"), 4446, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("accdb4cd-8075-4d4f-80c6-cbc4b8b4b713"), 4215, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acd11db4-5d1c-423a-9e81-389a3fe49a56"), 4226, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad1684a9-f310-4110-8d5c-dd0f34b04fd3"), 4513, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad185212-5f37-4d3e-9227-0ef9ee457049"), 4528, 9, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad1a979c-5029-4aa4-a83b-517e681da4a4"), 4401, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad402a51-c2a7-482a-87bf-4a27bc2d86fd"), 4661, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad7da5a3-1f59-4cb3-9d99-6ef41eee077e"), 4506, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad97d618-17f7-4a2e-b33b-f878b773e770"), 4015, 6, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad9b04ba-efde-4cd8-a693-7ce7fd74b512"), 4224, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad9f6ea9-49e9-4367-96a0-095c851330ea"), 4252, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada89e2b-fceb-4ecc-8485-69db7a872e96"), 4225, 8, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada8ef9e-79ee-4c07-89d6-ac115723c49c"), 4652, 6, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adaad57a-2b8e-4f3f-817a-a0a2e2b3711d"), 4537, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adbb5142-09bc-4193-a30f-1e3fff8e3cda"), 4412, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adbef89a-e82c-4ec9-9def-fb910d273df8"), 4108, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adc12ed3-582e-497e-9c85-8299849ddccb"), 4628, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add0254a-1656-4d0c-ab8a-072943a6d78e"), 4403, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add200ae-97d8-4c33-93d8-de499a695cbe"), 4603, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add87dfc-708d-45e3-8483-cf93a160f835"), 4107, 8, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("addc6759-8efd-4eb2-9e49-cb84427408a7"), 4006, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adff166d-a225-4324-b2a5-4a63bc4a225f"), 4108, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae0b2a20-4f7f-40d9-bbf7-eefdcdac7a07"), 4514, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae104bd0-9092-4306-981f-b6860b7669af"), 4248, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae50bd1b-a84d-415a-823c-e06c50bd46ce"), 4028, 3, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae534392-ac67-4e7d-8967-6d4dc4cc596b"), 4638, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae867d47-ac3b-4505-942f-ad7eaf3b7e58"), 4638, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae968f3a-3ec1-4c93-b384-8b988ca8345f"), 4426, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aeabe1f3-622e-4e55-8336-fe5f67d7c6ee"), 4620, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aebb74ce-eb32-47d5-a1d5-ae2ec7d2644e"), 4251, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aebc89e2-04e2-4b66-b54f-56180a9cf8cb"), 4250, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aecc7536-309c-4199-b2ab-24122502d6c6"), 4540, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aeecbbd1-5087-44d1-935a-fe8637240ffd"), 4115, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af2780d8-0e0c-430d-ad73-9e4b5af432bf"), 4248, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af325c0b-9ac3-4eaf-970d-47854423cf07"), 4459, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af77d3d0-cc24-4768-9df0-46503e0d6ca6"), 4314, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af7db10d-4f23-4ac3-bf6a-895f8847fd32"), 4854, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af9c44b1-3e28-42f6-9cc8-8ae2bf074046"), 4405, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afac3f81-7f4e-497b-a568-ac8671459120"), 4552, 9, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afaec942-799a-473e-9833-2b8fd8c92e39"), 4722, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afb32318-e0d1-49a4-bbec-23b8e47921f5"), 4429, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afc6f79f-67e2-4273-83d7-6d1a7d99e44b"), 4323, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afc748a0-1867-4262-a1ef-3d99926522f3"), 4618, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afe7b86b-f572-48a8-9279-f072183b1a6d"), 4524, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afea331f-5731-4689-a568-672b570f1bb7"), 4028, 2, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afed8390-5cfa-4c6b-9fe2-52d9668391f1"), 4550, 7, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aff22ccc-8621-44ce-bdf6-b73a79f2b0e7"), 4515, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b025c567-ce92-49e4-a26e-a6995e6294b3"), 4202, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b03abf85-f436-46ef-965e-5ae7ddbb4d79"), 4315, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b04b7081-0b58-44d1-b36e-2d19a3617f9c"), 4431, 4, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b05c6c55-c816-4e39-a139-8035540495a5"), 4719, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0628467-39df-444f-99cd-4ccaacf4e872"), 4015, 9, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0645009-3987-4c1a-b613-77b54aedd023"), 4002, 7, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b06ccd84-e3b8-4c04-ada8-7b504f45caf2"), 4025, 1, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0954f21-c2c7-43a7-a346-b11edf8af333"), 4424, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0d5403d-a979-4d9d-86d4-906f6fc4c93f"), 4019, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0d72721-0080-45a2-8498-ad6b7de29718"), 4560, 4, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0fb3690-f4b5-4d6e-83ab-1313b5bf09e3"), 4227, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b107f6f8-27e4-4060-b72f-8d2d331abb0d"), 4108, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1093f62-72fd-428a-9c19-5753a3d1892d"), 4563, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b12102f8-2e8e-4c45-98ed-3d8a2aca39df"), 4016, 8, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b123d673-d598-4de2-a3f6-5ded8b71926b"), 4315, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b12b652c-a5b7-47f2-a2c7-ba18b6defeb1"), 4553, 5, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1483ea4-d1a0-4645-8e85-47950f9bf3a0"), 4102, 10, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b158e27d-c767-41ce-9b7c-4450d9855812"), 4233, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b162b21f-d45e-450b-b3c4-58260941bc18"), 4238, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b16d9777-2267-462a-a595-ab3c880700e6"), 4229, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b16f6555-4c0a-4b70-8574-8c29a661e869"), 4719, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b17bc095-2b04-4286-a92c-57a2cb19eda6"), 4029, 7, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b185ec65-de3b-41d5-9bc0-3764f67b42fb"), 4226, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b19d2910-7ec4-4746-be80-b2ce4ed79941"), 4564, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b19e5f96-1906-432c-bc99-36ee5e9098c3"), 4115, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2124bd0-e4a0-46ac-8320-2dc3142f2090"), 4026, 9, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b223ddc3-0ce0-4b3b-891d-b60e0e3359b9"), 4543, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b229db53-62f3-4b6c-b7b8-4dc59f00113a"), 4661, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2347c79-2c76-4503-82da-a274ce7b3618"), 4403, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2395745-c2f1-4f35-812a-2c65a16eb753"), 4418, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2469a6e-a9e8-41da-b1c5-15acbac302ba"), 4014, 9, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b24d27d5-0580-4114-b538-fded7f2aa969"), 4256, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b24edbe9-0119-4029-9c00-361857fd6f15"), 4427, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b25afaa0-e882-4ad1-8224-f4fc5ec1a217"), 4540, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b25e96cb-79da-497d-b8e0-5c2a5ef5c2f2"), 4251, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2645562-d8eb-4e7b-a858-1ce0cf6ac250"), 4632, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b28fc39a-f6e1-4b27-84aa-259919f4a5d4"), 4274, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b29533ed-ce00-47d6-aca7-2eb68621d963"), 4242, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2956395-8cdc-441c-ab29-9f352dbb420d"), 4718, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2b2ba03-f632-4730-9c2b-be795363615f"), 4652, 7, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2d1c13c-a00a-4eb1-93b4-6fa22ea4bfb3"), 4314, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2d7fc3e-9e15-499e-9eae-a023ec3a73ce"), 4535, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2dd9193-9863-4317-9705-df0f54425784"), 4000, 8, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2dfa828-287a-4dc0-93a6-0b209da8e33c"), 4804, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2e06b7a-67b9-4139-82c4-f3514cd440f0"), 4636, 3, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2e1465a-987f-4587-9364-75faeeb91e80"), 4610, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2e7e505-af14-4760-aa31-807d6eff4d45"), 4655, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2f153a6-24cc-43c4-87c7-183f0cf927e3"), 4209, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2f66cb7-de93-45a1-b550-c86139751971"), 4208, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2fa1a1a-09bd-4133-a92d-180a030b06e3"), 4429, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b300e15f-2ff9-4372-bb71-9a44b1369a91"), 4313, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b30c6ea7-6026-4d2e-9261-9452ec4e66a4"), 4611, 1, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b313d097-f90c-430b-8c82-8ae9de8575e8"), 4638, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b31fa588-b538-4467-9e24-cb0b8241190d"), 4544, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3289f13-27f3-4a89-ae9b-aa446fd0b082"), 4637, 10, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b332a8fd-541e-4606-a757-ce88a66294e6"), 4458, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b334d90d-4f86-4193-9771-e3e1ac1fed24"), 4438, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3442001-ebf7-45e9-bf3c-77e8e2e9d249"), 4441, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b35b7d48-4a17-49f4-8697-dcaa7fe00039"), 4413, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3614360-5b0a-4e74-bea8-b6b2cc2dc729"), 4413, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b36b8f1c-5615-4863-8117-05591dfd4087"), 4521, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b37288cd-8a32-47f5-acf8-554a7991140d"), 4525, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b37e4d88-73a9-4279-b003-781473c4cef5"), 4611, 9, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b37eda41-8a33-4568-8501-e1cfb69b5e72"), 4414, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3841c2c-75b2-497e-b52b-8e5c35df874e"), 4504, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3a1c2f9-b7cd-4621-a295-44d477893767"), 4452, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3d1c35d-8bd1-4d09-b839-9e9d8a4a7dd2"), 4564, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3d80614-72ad-4fd6-81fd-a7c4650f93e5"), 4618, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b40a1c7d-a698-4c74-a70f-eddbea0285c0"), 4017, 10, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4290e6f-f369-468e-a882-e807a05c616c"), 4010, 2, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b45794f8-5489-47a5-a1f0-d50d1a167b6f"), 4542, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b45e8c14-aee3-420c-8b35-71541e1a2d8b"), 4640, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b46341b7-5c66-4542-8c8f-f68513a46a6b"), 4653, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4735178-9031-4e22-9829-8126e888154e"), 4255, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b479761b-7e1b-4875-9401-e9b3de08e4a4"), 4853, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b47d8b40-4958-4bb2-9e81-c1eb34482131"), 4207, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b484260b-b675-4ad0-b12a-58e08caad171"), 4028, 9, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4adbcda-31e0-4797-beaf-80f33f42b77f"), 4523, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b50cefd6-15ed-4820-8c58-a5ad03faec41"), 4541, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b51c6c7a-73f4-4c9b-a8c8-8f9c339f0cf6"), 4246, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b525bc82-f447-457a-87d8-0f140929c6b3"), 4010, 4, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b542e53a-e786-4625-91cc-e89530593858"), 4446, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b550de16-6706-4258-85dd-4abfd201c8a8"), 4260, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b55a0202-8d6b-460c-801e-cd8e2e760836"), 4511, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5619272-cdab-4223-a9b4-75943d0c3455"), 4104, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b56c3ed6-76cf-47ef-83ee-9332489404c5"), 4808, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b58d755e-a00c-48d0-91df-b1ccda4778d1"), 4253, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5968b59-4ef3-405b-a478-b19ee263ed90"), 4012, 5, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b59a00a3-023a-4d50-afcc-e5345a46a640"), 4609, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5bd9b47-a6a2-43a9-96ab-b876f2d891f7"), 4559, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5c71183-2536-48d6-9cdd-f38e8d3f9a9a"), 4244, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5d292da-3022-4a8a-a4de-64a06e82e69c"), 4406, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5df1518-ad50-4b1c-a8e9-f1d81d871af2"), 4001, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5ecfe39-8622-4c50-8cd4-9900d5db1402"), 4233, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5f97401-4f77-4a05-84af-86db0428e957"), 4300, 2, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5ff82ec-c72a-48af-82d5-fc7f4f94679f"), 4721, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b60a4ee7-eb13-45e4-9398-568329318452"), 4658, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b60c3d6a-1de1-4687-8de8-bf47118e032e"), 4523, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b60ddf20-9283-4cda-bdd4-09ebec7515d9"), 4800, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b61da445-9093-4bb9-a0b4-f9a025bd6f93"), 4030, 1, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b622f4f2-2a81-4707-89c5-2d79e14a8666"), 4265, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b62597db-434d-40a7-8b79-b7fb048a0c9e"), 4406, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b632d85b-2ef1-4c35-a331-5ac969693594"), 4803, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b651ff8c-2a31-49b0-8391-5b0e5b52cc21"), 4639, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b659c0f8-cd58-423d-9261-9cdb2fef9139"), 4663, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6643d2c-0245-4410-bc94-e87cee61b95a"), 4540, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b671cc48-a281-48e8-b967-f58f4eaf1da0"), 4431, 5, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6721943-6cf7-466d-aca9-259b592a8d36"), 4029, 1, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b68342e0-30b1-46f3-a4f5-cf725c114ae1"), 4108, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b697b17e-01b4-44d3-9db5-cde5cf9a720e"), 4032, 1, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6a94df7-ef8c-4b33-95f9-6a1519c51ef8"), 4663, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6abf53f-0202-415e-873d-61e10740df64"), 4218, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6af7c09-9e10-4179-a133-17d2581ae864"), 4625, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6b07154-5676-4f5d-93db-f0403ad9ead4"), 4425, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6bc6535-cde8-472c-92eb-34cb091083a1"), 4544, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6f762a7-1d87-4dfa-b110-d2e6b6c1b11b"), 4234, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b703c804-f60f-4fc6-819d-0a35c0263c61"), 4234, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b71e6a13-983a-4a51-ade3-081a070f4d81"), 4323, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b72abdb4-90ba-4eda-952b-a241813c90f2"), 4273, 2, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b72ddaab-7a87-486b-a571-f33acb9b1d5b"), 4455, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7363814-c261-4b4a-926f-7c9e3dba36c4"), 4301, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7587192-d3f9-44a9-887e-7c221262fefe"), 4635, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b77497bc-eaa2-4908-99a1-973ea6565cf5"), 4022, 9, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7941c03-6bf7-4ab2-8043-b573eae13b63"), 4655, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7aea041-3b01-483c-b189-1a62dac5177d"), 4019, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7b0462b-975a-4436-a00c-e46ca36e2b40"), 4715, 8, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7b4855c-1953-4923-b3dc-9ff05d086c3e"), 4723, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7b8a350-9877-4b38-a68e-003b0c982e37"), 4538, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7be2f1d-7c70-4bba-b069-dee984258019"), 4654, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7ccbc2a-6f79-4644-b1dc-59d791690b47"), 4639, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7ea8776-3148-4ffa-b7fb-1bc58e7a2cc0"), 4000, 2, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7fe2d3a-4877-4c2f-8f0f-4bb451d05d2e"), 4409, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b80fc468-c90d-4b08-bc46-a0a924b86b48"), 4659, 6, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b81ca64c-e92d-4ca2-974c-a6f7a514f8fc"), 4454, 6, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b847e57b-9da4-4ea9-9d24-79aa1d8e0511"), 4854, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b851617f-5e06-4d21-9f46-c264ea57ff84"), 4269, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b853b1de-ed9c-4086-8a9f-bbc56b841df6"), 4809, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b87fe899-9339-4d2e-bc74-62c5cfb2e34a"), 4809, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8b04b80-a064-4e0c-b671-943f596b929a"), 4541, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8b22625-0df5-40ea-bd15-2b53fcc88237"), 4225, 5, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8b4289d-347a-4c23-af0f-5ac2091bfe86"), 4321, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8b7d7fa-ea1d-43fa-ab35-5293d8e7bcbe"), 4420, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8cb4c5b-d1cf-4ee1-a47f-1193732f39df"), 4533, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8d34654-01aa-41ad-bdc5-656c222079b5"), 4704, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8db721d-9565-40cb-af21-73bb5e862617"), 4215, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9334a55-7fec-4b53-af4a-e41f054ae094"), 4637, 9, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b948b6fb-73a1-4c2f-921e-ee5dfcbf2024"), 4219, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b948f0bd-181e-4d84-8675-473508122225"), 4024, 6, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b94b422a-2b83-4c17-a92d-8b6dc8e05792"), 4510, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b95e61ec-842f-4d7e-b526-961106c8ae42"), 4103, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b965f1f0-ab38-4819-bbb7-207ebe264a76"), 4436, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b96c9e45-8599-486b-ad23-c854c3fd3ff7"), 4247, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b97a5438-014c-4521-95da-69aa3c1c417e"), 4261, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b97e1975-f202-4cb5-966d-90ea4595b62a"), 4104, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9930ad5-5f8e-4d4e-bbb2-1d1367810544"), 4546, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9b7f962-d9cb-43dc-b021-f09d485027ca"), 4266, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9be0bdf-67b8-4c14-abcf-03042140f159"), 4663, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9bf843d-ff21-4ad4-bf84-62c2db941744"), 4706, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9c1bf80-f70c-49b9-b1c6-7162898b22df"), 4533, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9d7c9bf-1930-46bb-95e6-63934db9190a"), 4443, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9f08233-b762-4542-8acb-2a3a60895fa9"), 4601, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9fa93ce-2d8c-481d-8460-0e5a79ab3dbd"), 4639, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9fdf1be-c028-47f1-ba45-267294ca2a23"), 4103, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba072e04-574f-47f7-8e86-41e306b926b9"), 4250, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba0960c4-6676-43a0-b324-2bc36db7782a"), 4005, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba398106-08e0-45c8-bdc5-2b6215e91fac"), 4623, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba6787d1-2140-4a1e-829e-8e5be18a143e"), 4028, 10, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba725f80-c66c-4895-9bf2-68427af98a4f"), 4407, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba7264f6-3490-4bbe-b981-bc3332ca926a"), 4000, 3, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba85e4be-9aaf-489a-b7a2-2b4439e7e213"), 4531, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba914ac4-d84d-48f9-a55c-250b1b144ace"), 4317, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baa11499-0a74-4dab-b695-c0c0f3e17b29"), 4302, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bab9993f-870a-46c9-a571-fae3b92cd8fe"), 4429, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baf05130-4892-4188-b001-c62d2e175c32"), 4634, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb02e5c7-7442-48b2-8d50-248883ec9ddc"), 4024, 4, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb03065b-fa08-48e1-8fc2-d54ac00a58ae"), 4016, 6, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb091f46-78eb-4f71-8a73-34f030f4f2b6"), 4532, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb0a3845-a9b4-4157-b292-5639076f445e"), 4232, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb18d56a-c155-423b-8ded-70fff0a139f5"), 4203, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb4366b2-f7fb-4fef-9001-098122c29490"), 4701, 6, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb4e0ffd-5790-445c-ade6-fc582a6aad57"), 4715, 7, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb63e14f-66f5-4ab0-8e75-6f05458b1399"), 4501, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb9ccf8f-addc-430d-b22f-ae0f58073a4f"), 4013, 9, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bba7130f-8973-4516-8b08-8c3be94fc084"), 4309, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbb46a8c-6ce1-4374-978d-f6513bdde792"), 4028, 4, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbf31c8c-b7d6-4e62-bf04-ab4b27930975"), 4635, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc014c06-3d03-4d7e-a8a7-bcc1daf58e3f"), 4414, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc03bd20-701e-4fcb-b52a-53772f60d2c6"), 4628, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc06dd74-2470-456c-8794-f241b3b8e09b"), 4442, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc09950c-0275-4e06-81cb-c1c1a97afd16"), 4701, 10, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc17b2b4-15e7-423d-a1b1-4f42f756ff54"), 4246, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc1f290b-7f3c-41b7-8033-01bfd1afdfdf"), 4656, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc42beb8-4465-4ba9-a183-4c86f7fa634b"), 4427, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc64a118-d3db-4ea1-ada4-5c17b8de2b49"), 4011, 2, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc6c3366-fca8-445c-9beb-39d2d20c51da"), 4445, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc7306b8-8322-4901-9e79-ccde58c330d7"), 4650, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc7bcd5b-b940-4fcf-9151-f7a1b2d1308a"), 4254, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc82ac5b-beb8-4630-a669-fccf9587798a"), 4654, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc82d5b3-bcf3-4bba-9828-e6aa5d941c8e"), 4432, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc8fc2dd-e874-44d0-9987-13f179f68440"), 4107, 7, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc944202-2f8c-4705-8c96-b88dab78578f"), 4431, 8, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bca3a280-3be9-4607-9744-355bc976959d"), 4324, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcb54a1d-8f9e-4793-8eb8-f5de42bb4c25"), 4229, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcc3a8dd-3467-45fb-9995-142ce9ee041a"), 4452, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcd49d7e-8790-4c28-bb08-fb6703150517"), 4202, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcd5d462-ce42-4cf7-9928-fed0c93eccf4"), 4012, 10, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd0ba3f6-c694-455e-93e8-36254b348fbc"), 4626, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd100c88-e9a5-4637-8b37-6596cc31534d"), 4421, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd1f88dc-460e-42b1-a465-711005130c48"), 4462, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd2765c5-dc5f-4fdb-8123-0949587714c8"), 4018, 6, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd4a2eff-d54c-4bed-ab69-6c707ac5e04b"), 4445, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd564de7-4b48-45f3-9078-ed78d792f17f"), 4437, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd61f80f-9d81-47eb-ae07-fd4a2688ef3d"), 4416, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd80d264-454e-4cde-b5c2-c075b3134930"), 4226, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd824a63-64e1-443d-87ac-b67caf802dd2"), 4504, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd87649d-a533-4d12-a570-aafb2c3dd275"), 4274, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd9e8bec-6783-410f-acba-ab6ee41d288d"), 4239, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdafe1bc-38ac-46c0-b7d1-64b8f3711fc0"), 4214, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdb8058c-1fdb-4bd8-9be1-361147211707"), 4201, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdda4f3c-daba-439f-9c30-db845c59f867"), 4510, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bddd53dd-d7de-4830-9105-a66826c0addb"), 4219, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bddf3a0a-0375-4900-95fb-b2c690d3d40e"), 4247, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdf1c6fa-d631-4409-b229-789023b919b6"), 4244, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdf1cab3-1030-4c04-8b78-7b5faa101c55"), 4615, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdf42b41-748d-4cc2-bfab-7bb79f403db3"), 4465, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdf527d7-46b1-4814-b8bc-3248b619c560"), 4439, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be002f86-b743-4059-b671-a588af9748ab"), 4407, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be04c72f-d9bf-45fd-ae43-307fa036635a"), 4027, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be129a14-e670-47bc-9c6a-948dad68d56d"), 4614, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be342c9e-4f60-40ad-b752-9b4f9d0c1524"), 4418, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be4a1034-a33b-4351-95ea-2ebc5e90cabd"), 4102, 2, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be610d5f-32d6-4aa5-8ad8-9aea96f7dc09"), 4462, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be64f075-427c-4448-a562-4eadf9d0bc68"), 4626, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be6521f4-7734-4e2f-a524-72f1d4eb3454"), 4207, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be71ce5f-1b44-4cff-8670-99d64d07992d"), 4103, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be8f28f7-8674-4f9b-9ee5-35c4139e147c"), 4264, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be9392cb-e7e0-4045-9dbc-7bcf12ef9309"), 4203, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("beb9b77f-37da-4e02-8b8e-0826c3740f68"), 4104, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bec9609b-0df8-4d29-be9a-6330374c43c6"), 4465, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bee1a717-41e6-4256-bb25-4e359dfc92cc"), 4454, 8, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bee481fa-46e2-48d5-9be9-e7de28ca406a"), 4262, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bef7d316-d093-4f6c-bc38-f107871fb1b3"), 4607, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf060321-dca6-4fbd-a71e-adb061304e8b"), 4810, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf187383-caeb-4da4-9d62-2d4a7621e062"), 4407, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf241535-9c94-482a-87cf-a678724cca1e"), 4030, 2, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf3a0293-ce85-4533-814d-aba769aff52a"), 4259, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf3a07ba-eab3-4768-b458-96da056a8b46"), 4200, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf558135-d600-4de8-bf17-70af6927c582"), 4810, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf6f76d6-6d09-4699-9af4-11ab742f4f43"), 4507, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf74c544-e8d5-4ce7-81ef-b1d3f635329a"), 4220, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfde8305-7fcb-4004-bd36-7b0153f02286"), 4527, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c004fcc4-5bae-42a0-be3f-3f049b5d8510"), 4246, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0259d01-53df-4807-a543-6173eb569708"), 4219, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c068c145-26e6-4d6b-b82e-8baefb3e6546"), 4707, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c08473aa-d745-4f67-a096-fdda986ba201"), 4212, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c08b0cbb-7831-4cbe-93ae-65baf3d10d8a"), 4557, 1, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0b8019d-85fe-4411-a038-9fd42a090a4b"), 4031, 9, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0c75a92-3d46-4505-82e5-5daa574f2a06"), 4222, 1, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0cf68ee-1c08-4ade-91dc-f67fe36257dd"), 4410, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0d1bfca-9af8-4689-b32b-9a689bfec22a"), 4029, 3, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0e73383-ce5d-4977-9c4e-ba2d14269855"), 4423, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0f11c3a-40cd-412d-ae7d-0a589846c92c"), 4305, 6, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c101ddea-05a3-4826-90f3-0670b8b3a27e"), 4011, 4, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c125611e-5771-4cfd-a6ef-233a50902191"), 4637, 4, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1461985-05df-4598-a3ce-1da2931c5dac"), 4404, 10, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c15aa8c1-6024-40c0-b41a-aaf93ec38101"), 4463, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c16a8706-3ddf-460b-a1de-cc198a4745b1"), 4710, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c17bbdaf-3d1c-4fbe-852d-580c8f15f937"), 4660, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c19f0cc4-b31a-480f-b45e-4d191e4affe0"), 4010, 9, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1a0d38e-c690-4c33-ba6c-beaee6bb99e1"), 4853, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1aa39d4-4987-4dd4-8edd-c76942dad750"), 4640, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1b98a71-37d0-454a-8223-2e2ca7a7d28b"), 4606, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1c0b5e3-d6b7-4087-9352-9b13a8c72c41"), 4804, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1d15575-9836-40df-ba62-075f8cdd46fa"), 4206, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1fcfced-7844-4b56-a505-081b8dd0b0ec"), 4033, 9, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2117374-bbcf-43fc-9aa6-17327334817a"), 4452, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2157400-3884-4059-8179-4d244389654a"), 4411, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c246f3d1-9a1e-481a-bfee-fb5e8adcaf20"), 4235, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2563354-55be-4912-b677-65363f66ce69"), 4802, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c288edd4-948f-4e4e-bee9-11725370007c"), 4633, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c289d991-0061-4f5b-8e7b-ff83c0836842"), 4446, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c28a8ef9-dfc2-46a5-a14b-15a0d03e94e1"), 4716, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c29f2418-6e41-406e-8a23-47c4044c0793"), 4508, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2bd4f5d-589f-4b39-b258-3aef61cd673b"), 4201, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2d47075-1991-47f2-8ae2-5c1989898a8a"), 4239, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2f32221-66ae-4abc-a508-254d33bdc3e0"), 4014, 2, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2fc4011-a978-4037-9b05-12b3698c173b"), 4308, 6, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3057afc-09b2-4214-9a75-1511203a216c"), 4706, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c30a4a79-76f0-4f1f-b7dc-6736b1cc8b82"), 4258, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c30c2d0c-dd80-4a69-9b2b-657588dc6fe6"), 4721, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c30fee6d-5bab-49f1-b85c-ac83c83aeebe"), 4203, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c339a989-b8e0-45ad-9341-774c3879defa"), 4004, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c362761a-15cd-46ad-baf0-de645c2372e9"), 4527, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c38228a3-4def-4d0d-b950-c058f4a1b62c"), 4259, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c38a12d9-8c0e-415a-adfd-07cb92b93a34"), 4521, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c397aac4-710d-419f-bc73-969756ca8aca"), 4850, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c39865b2-53e0-46fc-b324-819e0023fdf2"), 4412, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3a923c4-f047-4723-949f-b111fe864a2f"), 4558, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3b6b4cd-1d2e-442a-b1ce-3fcdd4124299"), 4630, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3d6ac58-984c-4646-a84c-34c0e22c05a5"), 4105, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3e1afe4-b712-4452-b07e-8a9478b8618e"), 4652, 5, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3ed67ec-7847-4b53-b332-e803b0322389"), 4422, 10, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c40429c0-c092-4b75-a3ef-8e51d28b84d7"), 4708, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c406bfb9-ec1a-4a00-8d01-47f67acd12b7"), 4226, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c40eac13-71bf-4ecd-8204-679184058231"), 4810, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c41dbce0-97c7-42ee-be9a-e2100244b58f"), 4650, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c436f1c4-df64-48a7-aece-cbd5858063ef"), 4100, 6, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c481b64c-fee5-40e0-a0df-d7edbe567b59"), 4851, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4908c2b-378f-4c1f-9207-cde6a46b0068"), 4009, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c493e667-373e-4e43-abc1-15ccfa34a135"), 4851, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4b4a774-9ede-435b-9810-40189d466322"), 4607, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4d53c37-c22d-417d-8a6f-bc9a092b42e8"), 4461, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c526f91d-8405-4e07-b642-8395becb84ad"), 4426, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c52c93fc-cd9d-4804-863f-2f60c49050e3"), 4413, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5343ad0-2235-462c-9740-27121e8cc42b"), 4565, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c53ea0be-fab0-4f35-b657-421e4ea07cc9"), 4513, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c550464c-b5c6-4825-98cf-08d998ee1a80"), 4270, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c55dab9d-5b01-4488-8f28-10beba6b28c1"), 4447, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c598c4ae-cf8a-4176-b961-80fa20b057b2"), 4445, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5ca09c3-a9e7-4eac-a5a4-78403997bbd4"), 4111, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5eff2db-c55b-4401-9fbb-e28b1ae4a453"), 4002, 6, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c60fdf15-1851-4403-820e-a7f78df8162e"), 4236, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c61110c5-db44-47e0-a76b-42d14988a845"), 4608, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6224b0f-ad20-4368-ac37-e2a0c07bc52f"), 4509, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c640988e-e196-4ad9-a716-da6f7e89dac0"), 4640, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6438a5c-890b-4d3b-84f4-4f0a6595efb3"), 4406, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c69f9c6b-4098-4849-a5de-d5f9c968456d"), 4268, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6a30dad-c2aa-4f65-9c51-d5f529aa0541"), 4517, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6b2d106-e9be-4a36-bbf5-9ef9cc108f75"), 4213, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6b7c906-b9cf-426f-8ace-83f8bed4a619"), 4308, 1, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6d95a6d-daa0-462f-ad98-fab4b7d328c7"), 4633, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6dd1697-5679-44d9-9ba0-4a6430a646a5"), 4512, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6e9ac80-218d-4743-a374-2bb91d3dac6c"), 4456, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6f3a9b8-d98d-4f11-8ca1-27ef8868e10e"), 4529, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6f83960-837c-4d92-ba56-d30d09ee1d12"), 4427, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c71ae18e-0a9d-43f6-95e2-5561151643fb"), 4503, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c71f5dc6-7571-4c6d-8c58-ed381819dd83"), 4700, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7219b86-5d33-49ab-8232-92027d8791fa"), 4533, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c736e2af-1a5d-4d5e-8b34-6e4463c902eb"), 4436, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c73afe50-bbc1-46a6-9e6e-7a84d724235c"), 4705, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c75987a6-259f-4611-b471-ef6b8b7023b0"), 4559, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7e77d78-abde-4466-a032-3a1211e946e5"), 4224, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7e7a693-663d-4940-b535-de80bf933406"), 4223, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7fd8630-a6e0-4b1e-beee-b5bbadd76b57"), 4035, 7, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c80acefd-3dfb-42a6-9f2f-d9b9cec2c35e"), 4463, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c81f3f49-493b-4d4b-a1fa-a2be71b5444d"), 4114, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c828e326-8662-40ae-881e-413af396b3be"), 4320, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c83b5f6a-1b28-4f2e-8836-1f0beb377474"), 4504, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c848ffe9-43d0-4cdc-9fa4-90dfebe31ce6"), 4111, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c84b7832-26cf-4fe4-9c18-4e3b9481c001"), 4102, 1, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c86058f8-d48e-41c5-b1f4-0050c01de438"), 4608, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c86bc596-be6e-41ce-9dd6-d145d14b7f74"), 4457, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c87556ed-63bb-48f1-91da-8c73b652844f"), 4810, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c87b810e-657e-473e-a063-4c46cc656aeb"), 4311, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c87c0483-329e-4a04-a692-da3f19a0574d"), 4415, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c880e0f0-39b6-4e66-b03a-9d9ad2445267"), 4538, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c893482e-9aae-46cd-a8aa-298ebba75359"), 4633, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c89cfd7c-683a-4aa5-8aec-51139635d827"), 4447, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8a433db-8218-4db9-aef8-a4a7fe0ea3d9"), 4262, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8bc9b7b-5e85-4821-a351-6e2ba52eb9a1"), 4540, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8cf9a4e-5265-4bcc-b95f-30b19fcf3001"), 4851, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8e54990-f431-4179-9152-095c8a0fc6c4"), 4305, 7, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8ea46fe-d864-4caa-bdc2-c8eb141d9f0b"), 4528, 10, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c90397c8-1516-4ef5-8486-447151c243c4"), 4266, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c903a61d-a484-48ee-a121-7526bf472be4"), 4445, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c92aae34-f81d-4eee-a071-1fe0a6b224cf"), 4270, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9310617-a128-4afe-9489-6b2be786b3a6"), 4624, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c941a1fc-f6ca-4dad-8949-2c5572782c2e"), 4309, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9714a31-cdcd-4998-a17f-7d09201b88ff"), 4014, 1, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9bfd929-6f36-4c17-a812-2be3c99d862d"), 4522, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9cd34be-00b8-4a10-83d0-07a8c3134d84"), 4663, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9d17dc9-5b41-4725-8cba-c08328a1e44c"), 4006, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9dd654b-bc2b-449b-b6bc-46c42ab05bc2"), 4543, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9f16467-0ade-4363-85c0-e232eb3ab169"), 4324, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca1056c9-f2c4-47eb-8212-3c9b56598fa3"), 4436, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca2c54c7-148e-4a3f-8621-9a224c56016f"), 4115, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca39a7e7-55a8-4636-a9e4-e13f6338d54e"), 4616, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca4742d7-bd1d-4647-84e9-2bad3c2cefaf"), 4607, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca6c4f60-6a69-40ca-9239-c0a8452160b4"), 4627, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("caafe24c-290b-4f44-967f-8672b4639f30"), 4556, 5, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cab22b53-ff96-4853-973b-146533d6e964"), 4253, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cae6842f-9d72-4a88-858a-e3324b87635a"), 4622, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cae7c282-3012-498b-9e50-1587c8d9b785"), 4530, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb1bafde-c6ae-4493-9259-a20e73cd151c"), 4432, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb36955c-270b-48ac-9d36-a1df7010312e"), 4660, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb52b031-f999-4b66-acff-b4c38e52a904"), 4102, 4, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb5a6cb2-7a30-4f14-9ed7-cddbc016017a"), 4220, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb6b137d-2f38-4cc2-ae92-ac54c9e851ed"), 4243, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb9dcc8d-0e74-4f4f-b401-eaf6f37d52e1"), 4509, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbb61b78-bbeb-45a9-8522-3b671f551660"), 4000, 1, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbb67cba-da8f-48af-a920-d32c260747b0"), 4016, 1, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbd68370-6ecb-4d12-b220-096253c95ae4"), 4718, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbdb79ef-0349-4006-9497-4766c92de753"), 4428, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbdc7458-5766-4f5c-90b9-637fbc1631a0"), 4304, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbec5014-6e93-4a97-a322-5f8140456c65"), 4214, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc0aa808-7e1b-4bcf-9a6a-9c50fc749a83"), 4303, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc23835a-c029-4bfc-a2bc-a0d2027a5696"), 4657, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc2f2ecc-a0d2-4ffd-a7ab-11b53666cb14"), 4805, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc4a8585-4f77-4ef4-ae74-11fa7a94ddd7"), 4243, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc5ecee8-a90b-48d3-bafb-4b4ebd4686eb"), 4218, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc6af5df-9c7c-425b-9029-9557d7be0786"), 4623, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc7fd0a1-99d4-4134-9766-c4b1a4086145"), 4661, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc84a98b-9b3f-4984-a2e4-bac02c955c05"), 4855, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc9ef802-a3d5-41d6-848d-490a8ea61020"), 4618, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cca1b277-e0e8-438e-9961-939aba64e054"), 4324, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccb7c754-e923-48df-87ad-57d6eea9e954"), 4552, 2, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccb90a0f-2846-45a1-a0cd-6a2fe0221314"), 4020, 8, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cccc2aac-389d-4954-9562-8b5f8906d823"), 4536, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccd8f254-8052-4f81-8026-0a2241d451bd"), 4546, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cce2142c-57b5-4f43-9bae-fcc1eed53bcf"), 4106, 2, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccf18670-ea45-42e9-b936-70de28d162d4"), 4315, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccf737f1-005c-4b3d-bd84-8aa8bab7fad4"), 4025, 3, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd08e4d4-dcb1-467f-a759-1ec9fd29447a"), 4502, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd1d8ee1-16d9-4f7d-ad6f-a4091e80224e"), 4801, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd209bc3-d293-48b9-b7af-5b653548151d"), 4108, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd3b184f-1d43-434f-90ee-5a3c64a12658"), 4809, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd3b57b2-8bbc-4894-bc25-1e5d14b2ae27"), 4304, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd3c9ccf-8a6c-497e-a881-a47ef5fd9a67"), 4529, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd3cde12-8dcb-425b-8e00-e08ecef79a3c"), 4700, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd3cdee3-830c-4462-a9c6-6bfeee80309e"), 4551, 4, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd49c4d2-415d-4d04-b7d6-781eb7299526"), 4447, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd5953ad-6101-41f4-b944-a622a5105cef"), 4705, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd5a6d04-a1bf-4783-9760-c791b2dc579b"), 4457, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd641309-598a-45c1-9d40-3141651eaec8"), 4654, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd6ad708-e9bb-4d43-b765-3581e613328a"), 4227, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd6c7e93-45a9-4dc2-932b-0390703c02f2"), 4446, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd70ebd9-4d76-482c-8c77-660641a79e15"), 4105, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd787df6-14d1-44b7-8396-7321a36ae44c"), 4024, 3, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd82d8c0-2648-4649-8b81-b6a3d050e6c2"), 4712, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd97f154-7ac5-4576-bd9d-0982ac42a23d"), 4270, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd9d035f-941a-463c-995b-546c79b4b284"), 4018, 9, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdadbb30-2abf-46f7-9272-8d382dd1017a"), 4438, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdd44a76-69e3-4d28-9ebe-f6a9597782ab"), 4318, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdd67421-0bc3-48f0-a5c5-db9b8de5b460"), 4626, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdf1020f-95bb-4cea-b4cd-4a72e325377f"), 4555, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdfaae66-e39c-4030-a96c-aed5f4e176c3"), 4200, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdfb264c-b439-4b6c-8310-01068ac0d20b"), 4316, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce01f695-202c-4102-bb2e-2729fd7d9e08"), 4109, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce176e54-b78d-4006-b37c-d5e204e06f14"), 4270, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce1a00cf-6a44-4da7-a64e-b8a1d6ce602b"), 4411, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce2d1d37-713d-4bac-b066-f1397c4f0975"), 4101, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce473983-95bc-429e-a02e-3d23ae174bdc"), 4718, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce4c5f06-cfd9-4420-9846-257306b1300b"), 4501, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce65f0ec-7014-4c05-90b0-b1a8d3a7d822"), 4217, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce6b6ceb-6f84-4e2c-9126-bf4b2b6b8cbe"), 4033, 4, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce85d54f-e1f7-4392-add5-97c409de0a70"), 4632, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce88cc1a-902f-44b5-8e3e-e39b58479b2f"), 4036, 10, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce91e212-2036-41ae-9fa3-602e8b8350f7"), 4654, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce96d98f-7392-46f4-9fff-ddd5258af7d4"), 4457, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce9f96e4-6272-4c3a-adc4-7a4eadcf6e86"), 4628, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ced00b8e-e92a-4982-b64b-e633f7c60e89"), 4405, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf074752-7779-491c-b77f-db21927bc54b"), 4519, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf0ac3e8-7f1e-4698-bfb9-cda20551533d"), 4210, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf0ebc2b-c288-4eb6-a94f-42e0d430dd64"), 4462, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf348fd1-ab3c-4dbc-a40f-73b49f231985"), 4310, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf5adf39-6ac8-4cfd-95c1-6925c3c2fc01"), 4407, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf71f75f-e14d-48c7-badb-04345e79226d"), 4211, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf8c8c63-28cb-417f-8272-093e35a06f97"), 4516, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf9ea2a2-091c-4d08-9a52-28ec27bdb3cd"), 4463, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfa2ce76-872a-4a5a-ab4f-3cfdc08ed1cb"), 4014, 6, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfad33a3-66de-405d-8a8e-742aba51d382"), 4320, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfb27166-2460-4fa4-8706-1eae1e6141e4"), 4708, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfc82a88-fba6-4d8a-8981-aaee73fe8ffd"), 4800, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfe15cd4-75ce-4d87-bd3d-3763ac8aae0a"), 4000, 7, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfe8172c-e983-4f5c-912c-e8208619ea4c"), 4303, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0064677-8359-4464-81d1-ebcd72c183e2"), 4656, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d015fc7f-eaab-4cb6-858a-4ed87287b398"), 4439, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d02d118a-d111-46ae-a3f4-5501735f6659"), 4310, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d03e09b3-efba-4499-8ccf-226aab335b5e"), 4301, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d05e3651-536b-4cfd-873e-d4cf4b0ed47a"), 4216, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d06006f9-89ef-4a15-ba98-78a823759185"), 4541, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d060109c-f976-4632-8bc0-e5eda32dd68b"), 4655, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d068f276-c6a2-42b6-afa0-8877d612cd39"), 4555, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0771e0f-bdf3-42db-9bb8-21cda1d09c0d"), 4013, 7, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d07bbcca-3cad-4a17-812b-ab8d27eb4744"), 4101, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d08002d4-1eb8-48f5-a3aa-f8ea70dffd62"), 4030, 5, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0887529-3c91-4527-9a0f-98ff6c7848a4"), 4610, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0b361c3-b60a-4d60-aa0a-187e7ea688a7"), 4560, 9, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0e74d4e-8f93-40db-852a-95ccef316704"), 4530, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0f844d3-cb70-4743-82aa-a035dd89e644"), 4804, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1118430-a15b-4525-8a5f-339b45b404e3"), 4216, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1119a77-4ca4-4e2d-9a7d-692dd344b904"), 4017, 6, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d13c75e0-ecc1-4bb6-8e61-da7509d113c0"), 4463, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1595edd-31c5-403e-aaff-1b1b29117311"), 4433, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d176082f-ec51-4ebf-8707-939b25aa2dc7"), 4711, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d197d2da-144e-40ee-a59b-b4c69eebe3cb"), 4519, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1a25be1-bd1c-43c9-859d-0d597a966ff0"), 4524, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1aab919-725f-4c3b-b0f3-376a6c6d1939"), 4411, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1adda0e-485e-4635-bb88-1a217da401b5"), 4028, 6, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1b239bd-b3f5-4115-bf65-006b4b74db7d"), 4264, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1b37531-7e99-4970-a5da-c54122ad6d37"), 4629, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1c0cddc-2dd7-4504-bd29-7d10844b6d68"), 4526, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1c75374-c3a4-4399-aaaf-99918f58d97e"), 4801, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1cec09e-753c-410d-b826-7f47050760c2"), 4216, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1e6b85f-7716-4b51-a901-1ee20ccc9601"), 4238, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1ec5a92-82a0-4707-a12c-1e6362c6e7b0"), 4321, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d22134a1-a374-4075-86c0-45b7d3240867"), 4545, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2477030-196e-4aee-b5e1-8efa3ff7e148"), 4215, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d26ff084-0f1a-4c50-b2da-db471d2778d9"), 4442, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d29463da-65cc-41dc-a2e3-75fb8d2eec7b"), 4422, 5, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2cacd63-90af-4393-8c0a-c417a6e8f7ab"), 4214, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2e7338b-8290-4566-a3cf-385e0ba4b1f1"), 4109, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2f434b4-ffe2-448f-94cd-d2242a0bcc17"), 4527, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d30182a4-7f97-4304-aaf0-62187191ab5a"), 4411, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d302c577-2490-405b-b039-b90fda0ea36b"), 4274, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d328f543-9c91-4ae5-b12c-1bf930587825"), 4107, 4, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d329add9-c7b7-497c-93e6-078216ba1fc0"), 4200, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d32b1200-c61b-4421-a43f-04a47b7d73a0"), 4603, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3310703-43be-4d6b-9b76-37098b09438e"), 4454, 7, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3387716-c9a8-4be8-b475-9ae6adf3f53c"), 4502, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3473c79-f30c-4efb-85b1-ab7543ecc0ad"), 4851, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d358901c-83b0-4386-a049-5c17d84eba1e"), 4027, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d367b71c-23e5-47dd-a519-3f2e0e952232"), 4508, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d39ce8fe-3661-46b0-96c8-b4575c2e8bf9"), 4103, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3b3d6f8-96e0-4068-b536-7a822efc2ec6"), 4439, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3bb656b-dc7d-4557-9d54-fc26addfb444"), 4631, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3bc6cae-1453-4909-8d2c-ab97c93ea412"), 4213, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3be07b7-0df1-4d7f-a923-d2e5a0227300"), 4306, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3bf7d6a-802b-4c4c-83eb-b506da42eafb"), 4324, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3d789af-034a-4c20-8757-3f6d127f7108"), 4629, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3fc8a65-9436-4531-8335-96c7ba6983e0"), 4604, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d41feacd-7f58-4002-8e3b-b0a540638016"), 4807, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d42e45ee-57eb-4a29-b30f-5c024b1f518a"), 4565, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d43a1e70-7d4a-43f4-a2cd-e8ad3438922c"), 4023, 7, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d45820a4-54e2-47a7-b04d-46603950998a"), 4715, 10, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4654d86-5818-4dae-b20a-8b2e9bd3c126"), 4651, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d46ba9f9-fc29-4b0d-b90c-fc63fed7c3a1"), 4214, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4a75dfd-c414-447a-aca4-5721608b28bb"), 4202, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4acbe16-6a7a-405d-87bd-46a5ea5fa84c"), 4509, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4c39f26-4c61-48a6-b790-931000f774b6"), 4309, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4e50b7a-8d43-43f9-a9d1-3ba5c2b10637"), 4104, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4eb6fa7-033b-4e25-8e52-bf0f88e88150"), 4313, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d51d5488-d539-402e-9d8e-e9a2e58c3480"), 4415, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d525e574-7197-4960-af85-f94cff3deac3"), 4441, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d548604a-6d53-479e-8715-3903ad6635d1"), 4218, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d54912a4-3e79-410d-96ed-d7121b1437ca"), 4247, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d552b816-9583-40a7-b51b-0297a3c2dc30"), 4632, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d55cc153-589d-44e1-bb0b-64d15d336805"), 4638, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d56212e1-5d61-4b5d-9ee0-8aa963887701"), 4453, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d566cb63-1708-46a2-a81e-dd1b00611853"), 4428, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d56dd19f-2fc4-45e6-9f92-b0520d9cf1cb"), 4553, 1, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d58b5398-20a5-4a16-8d09-6c0b7208982e"), 4439, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d58f094f-d0b8-4b36-81aa-e5b5367bbce9"), 4559, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5905c93-3f34-45f2-9c2d-1fd5d3a78c0f"), 4011, 8, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d59b0b79-9ac0-4cdf-a1bf-28c400b9d400"), 4550, 1, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5a846b4-d3c3-4489-b7c0-1482b0bde904"), 4248, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5b59ba6-3b8e-4eb9-a343-ad78d1c49894"), 4657, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5b5d7b5-0fc3-4f7a-953a-372d668c64d0"), 4615, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5b93cb3-4afa-4886-8436-0be3a47b3b36"), 4605, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5d11375-5ab1-4935-a920-bae9ebf34a6c"), 4707, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d60406a9-dcc8-435d-a506-c729c3677fef"), 4626, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d61b257b-4733-41ef-8e5b-1c2041137c9f"), 4464, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d61c373e-8999-4d57-ad0a-d13b742e00fc"), 4850, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d63c5606-0879-4bf2-b88e-2ba4fea39fb2"), 4227, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d64fe54a-3145-45ef-a365-c8aca87042cb"), 4626, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d652d1f5-6a44-40ec-b99e-58d5b1cfc644"), 4418, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d65a6898-541e-4462-96fc-2187231a6377"), 4717, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6a69246-574f-48e7-82a5-8245f8c6ea68"), 4800, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6b1bcae-086d-476d-bbd1-5346ce9ce4a6"), 4251, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6bb72ab-bc6f-4273-bf2b-7853611968fd"), 4562, 10, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6e69763-28ae-4679-b43d-50d0aeda26e1"), 4619, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6ee9b78-4d6b-4f04-845e-7b719079106f"), 4271, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d70dc2ce-a010-4dd8-a3e4-8729c8c272cb"), 4211, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d72f389f-0dd7-458f-a813-1c2833aa62fc"), 4713, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d73920a7-8049-4596-979f-cb57e85f8cc2"), 4008, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d768a5db-3b8f-434b-ad06-84dfa3a3671f"), 4613, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d79e4f18-cbcb-498f-943a-43a598620a2a"), 4317, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7a990a2-3223-4348-8982-94cf6dc7c0e1"), 4533, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7b816f6-367a-4c86-99c5-ae7bf33c4197"), 4714, 9, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7e2d492-39d9-4fb7-bbe0-3f9ac2716580"), 4635, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7ea3c5f-1fa6-4134-af65-03679eda429b"), 4322, 6, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7ff68dd-bb2a-4169-aba9-36a134de2a7c"), 4719, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d80e1a38-84a2-4a2c-a4e6-532e168f5f78"), 4431, 6, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8191218-f7c8-44f9-8aa6-425981f819ab"), 4702, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d81aa3f6-6d5f-4bc8-92d2-9dce5f51a1f7"), 4015, 3, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d825a811-3fc2-47c1-ae53-73990f766c60"), 4309, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8313390-a1f0-4fee-b47a-5a600c740f68"), 4619, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d83f8bac-e871-4679-8537-0e0adab52503"), 4111, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d858d509-7373-48fb-88e9-f7d0f0d4bf8a"), 4417, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d88389e2-8946-42ee-bc09-408a5a4120cf"), 4427, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d88dfc9a-8413-4749-8441-478d01b8dc69"), 4704, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8a07532-b9c7-423b-9b81-6d6a4ff34bed"), 4271, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ca86e0-3669-498b-8f3d-30729aab046f"), 4559, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8cb018c-9197-4b2b-a9d8-785df6eaf0ca"), 4545, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ce9e69-c90b-4b14-889e-fcf2e07e7554"), 4212, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8e20900-4d5f-498f-a714-066c298782c5"), 4261, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9067ebb-8c5f-4159-a334-ca8fee7b1618"), 4001, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d94aa154-ff70-415f-a756-eab5a2cfa9c1"), 4021, 4, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d95e0391-dea7-435d-af61-c0dc1b2cac31"), 4557, 4, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d972ef6a-7da2-4b8c-9138-7711f22f45c6"), 4650, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d97d2ef5-aeba-4a95-9cc9-3a2dbd1c5d78"), 4653, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9838c7a-5b52-4ec4-9044-49964cc8f65d"), 4414, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9a829e7-7d1d-4116-95d2-9384de8a9806"), 4518, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9aa21e5-095b-4059-a00a-cafee9b7a41d"), 4232, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9b32f2b-cc57-4d2f-b43d-70390f42d159"), 4508, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9bc1ab8-76ee-4703-b82f-c40c59f2f19f"), 4856, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9d3cdf9-6d75-464a-8fd0-a1e69d637993"), 4607, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9d417a4-aa34-412e-b895-cdb7b11076d2"), 4611, 4, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9f7d429-e84a-4a98-9182-6675ea179c9b"), 4660, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9f9dac7-40e9-43cc-9147-9a36b16131f2"), 4546, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da065eab-41dd-43a9-b8c1-182c4bc77664"), 4658, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da26618e-7529-4d98-b715-4b056b8eceda"), 4256, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da2dfd1d-e814-49b8-8791-b29f618e8441"), 4273, 1, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da2e45d7-2658-463d-96eb-7ace73dd570b"), 4438, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da30dfdb-1356-4ec2-a920-9d650f46233a"), 4107, 2, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da3f571d-1526-4be4-bfb4-9825476fffaa"), 4618, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da53a4af-c0cb-4574-9312-77e9e64ddca6"), 4219, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da5df4b2-1d93-424d-badb-c6ff24d9c1e2"), 4307, 6, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da68e6a8-60a2-4607-8107-d1e138574ee2"), 4663, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da6d9f2f-662c-41a9-b969-0451781aeec1"), 4557, 9, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da7af1c6-6d87-4758-9204-c8b07d35f984"), 4627, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da83c747-a0e1-4f9d-8ed8-1c4608b441d2"), 4550, 10, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("daa3efcf-58f9-42d8-a50c-73c1c7dfc4b5"), 4564, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dad8665c-41d4-4034-a2fa-4c2548acaf60"), 4615, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dae03d2a-5224-429c-a0bc-aae9588b8b35"), 4538, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dae10bbe-1a93-475c-ae8a-2daba5e295cc"), 4515, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("daf05e41-82aa-49e9-bfa2-2eefa6ab3e12"), 4721, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("daf113de-2e5e-4d40-adcf-86058ee21c5b"), 4239, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db0a4458-96a9-40e6-b05c-db571ed300da"), 4437, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db33d7e8-f26c-411a-bd07-88433039429c"), 4507, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db4d720b-6194-4cc4-82e2-65a92fd59553"), 4502, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db5f4f79-4e61-4961-8a21-83a7db5caf44"), 4520, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db6b7fe1-9d0a-4ef8-840e-42fc4c44db92"), 4629, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db7c34dd-b447-47e2-aed7-bcd09821e6f1"), 4712, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db8d0b0b-927e-44de-897d-74c72abaabbd"), 4238, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dba80241-7470-45c5-8020-6fbedcbdc599"), 4234, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbb82c7d-f4ff-41ed-b75f-6ec62395b5aa"), 4260, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbc06b3b-818c-4966-a826-b54c5c8cd51d"), 4525, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbeef0f7-074f-4d3c-8921-e7d1cd38e193"), 4538, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbf10ee4-ab5b-4350-8b5e-f83aebee2af4"), 4219, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc2bacd3-2a1e-4ab6-a1d6-dc0aa695be04"), 4434, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc365db7-2d1f-45a2-9eb3-9141f5555b3f"), 4231, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc3cd45c-9698-4c80-ba16-8cab51d6ba2f"), 4022, 6, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc5821c4-49e8-4e83-bf5e-2014fa74fcd2"), 4006, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc76da51-8126-43ce-b02b-d8857c91988a"), 4657, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc878d13-deed-4e0d-b097-dc520cf5ea98"), 4460, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc94bd11-3288-4782-b41c-680137a593c7"), 4410, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcb383f8-2dc8-4567-9c42-4c908ef85b31"), 4637, 8, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcd55f6c-568f-4ca1-8aec-3e3115161940"), 4529, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcda7f2c-06e4-4236-bb56-11d839e6ee93"), 4528, 3, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dce8f9fc-382c-44ae-a537-0be3b3f9db0b"), 4002, 9, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcf66fcf-c6ec-43a7-b490-7d181d865818"), 4423, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd063953-552d-4d8f-9b82-e9ea1a555c83"), 4200, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd1d4d8a-535a-4a66-9579-f24c53e02488"), 4443, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd629956-b692-45e9-b7c9-c35f9b8a4e6a"), 4515, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd656a79-52d7-409d-8503-9569fd760b37"), 4319, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd75d8ab-83cc-4143-b59a-6dd02c5576bc"), 4458, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd75e28d-96db-4fd1-97a3-854c8e1b60f5"), 4712, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd769227-b60b-487f-87c3-47bb0bd729b6"), 4516, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd9effdd-54a3-4118-be29-5ec91e9dffdd"), 4272, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddaa0f76-4458-43cf-955a-f44e608966b4"), 4850, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddaebaa7-478a-48ec-a836-d12d36708005"), 4009, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddca7b09-e081-4264-8d6e-ed7810e611c9"), 4430, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddd9f4d3-ccfd-483a-9992-3416ca18e559"), 4423, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dde3b2db-1fda-4222-8d37-443ad6ab6420"), 4215, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddf00415-9107-4620-a637-a6ffb657efaa"), 4444, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddf66b22-96d1-462b-9cba-ad20750b93fa"), 4650, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddf8fb4d-c000-4547-890c-45de017fb5aa"), 4019, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de1bd92b-fa8b-4ba2-9c7e-c007447ca882"), 4653, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de261ccb-ff2b-4c82-a101-50e7e046acba"), 4705, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de350ea2-5526-40ef-9dbe-45085a10da1a"), 4563, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de4111b0-e2f8-45f6-9be4-52d3a23de56c"), 4806, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de41b4b4-e7e5-4e38-bbf6-ded5b5f38dd7"), 4442, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de4404b6-ab64-4463-8bf3-ab99ebc361b4"), 4269, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de442b67-dfe7-4021-b732-713ea788eb11"), 4216, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de5437b0-2f80-402f-8dc9-c7972a2d5adc"), 4204, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de726ea9-a49b-4d3f-82fc-921fb3a52dc1"), 4213, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de8b1420-5764-4f94-a4b5-c448e2857d0a"), 4706, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dea80462-364f-426b-9ab9-0b7896ad26bf"), 4231, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("deabdc34-130b-4269-97c2-8c7ac391e0bc"), 4532, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("deacd3e6-d73a-4cd7-b7c7-7886c927bd9d"), 4413, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("deaeff6e-e274-4f29-9fa3-3b6839f7e0d7"), 4539, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("deb9e6dd-bbf8-4c14-b879-6700e5e0d2bc"), 4517, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("debda026-27ab-4426-873f-b45eabc7b4eb"), 4211, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("decb2483-a0b0-4883-a816-14337ee0cefd"), 4714, 10, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("def448b4-f7a1-412f-ac60-d5f66c6c7697"), 4301, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df272c80-391b-434d-bdbd-322d1d37ead3"), 4543, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df416eec-36d0-4466-82e6-393a9fd2ae39"), 4321, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df68c2e2-4238-4b91-9617-66f74b4f5cce"), 4615, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df8fd33f-2bdd-49d6-a4e1-21f2a48ad661"), 4705, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df904ff1-4189-4bc5-a856-7fca91acdac6"), 4000, 6, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df920994-d922-4bec-8cd7-903a34cee054"), 4254, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df92cab9-2cfa-4003-beaa-ceec5c3ad26c"), 4447, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfa4eefb-1ccc-442e-99bd-0c3a7f2074ec"), 4562, 6, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfab8b7b-91ed-4e9d-a29a-41abba420bf2"), 4248, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfb040fc-6980-40a4-889c-cb642508e15e"), 4436, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfbf11b8-130d-40c0-9fd0-d21195cbf0fc"), 4005, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfd95095-a04e-48a9-a7c2-e4efc0c5066a"), 4242, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfe3cbe3-6df4-4d3c-a99b-7c7ded06d678"), 4207, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dff77edb-537d-4b83-a238-34ad783a3c96"), 4653, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dff9be69-7973-4c2d-a6c6-f19f3ed0dd1e"), 4031, 1, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e031cfef-85f3-422b-a6b5-03d27010c380"), 4513, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e036ceda-8737-4ed9-8f23-f18fe2af3a85"), 4010, 8, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e04add54-fa05-48be-bb63-c6df408f4629"), 4700, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e04e8b02-35d2-428f-9001-c4e70252c532"), 4610, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e05901e9-4d25-4b88-845f-ec2a8e1dfefb"), 4806, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e064303b-d829-46cb-a76c-f6573d962141"), 4218, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e067e512-1246-4bc6-a0c1-21d84d70a8d5"), 4454, 1, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e06da560-ad04-4a63-87cf-17cba308317f"), 4803, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0867e17-1612-418e-b0eb-e128d6a9676c"), 4215, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e08dafc5-9d77-49c7-a7f8-4b058d19e52f"), 4617, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e099c1f6-7807-454f-b307-ecbfa85668ce"), 4402, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e09c2f34-7e32-4e34-9ecb-076315f0d1e0"), 4617, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0a10f25-ab25-4a2c-9a00-f76378e3c63b"), 4807, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0ac32ae-c7f7-4d46-a4f9-41ba9e4874fc"), 4638, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0ac867f-d060-4590-9b1d-3b126e9465b7"), 4705, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0c55e9c-85d7-4f82-803c-434747292524"), 4636, 5, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0d03210-7db6-4cec-9e5b-2c53c6a71880"), 4236, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0d0e5c0-7981-4b6b-af22-6ada9b69ca0d"), 4716, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0ed21e8-cd41-4456-bf46-6e8afc7ccdf0"), 4461, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1160211-1ca3-4f3e-8fe1-81175df1bed7"), 4602, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1184f7d-63be-44dc-a840-c7eb599b2187"), 4556, 10, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e11d476e-7851-4729-aa7b-d562c480dc64"), 4658, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e12ddab8-c1e5-4a43-99db-3259243e1588"), 4628, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e130b70f-8bda-40b7-8cc9-20b912e6afac"), 4464, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e13fa1ba-516c-413a-8f42-3f02a2253726"), 4521, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e13fd426-1e2c-4d47-95b6-8fb17b0fa6f9"), 4240, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e14095bb-91f6-4bf4-935e-44f41e11af06"), 4618, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1444762-a961-455c-99ce-5241b9638359"), 4616, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e165d9f7-d406-4e7d-9f95-0870a7fe8a3b"), 4616, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e16e6870-772e-4da5-a3cd-992f852f9ed3"), 4636, 4, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e170d715-a72e-4249-a5ab-609fb24a3651"), 4034, 3, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e17c2969-990c-4b9c-95dc-54479059b8cf"), 4604, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e182756f-2966-4815-a984-59d900a9a4e9"), 4518, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e18707b1-d3f7-41dd-9b8a-10872013af95"), 4110, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1870b5f-afca-4a1e-b355-25505b773814"), 4505, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e18a103c-b050-4620-8de5-7907411386dc"), 4322, 7, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e18de064-4a66-4a0f-b206-e6012a675876"), 4410, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e190f442-4952-4e42-b1dc-be964c67a5ca"), 4464, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e191ae80-515e-42f0-a66f-6f34e5b4632f"), 4639, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1950f2a-991a-47eb-a562-f3fb62c75297"), 4021, 2, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e19cc89f-73e8-439d-9f98-0f6f0bfade85"), 4225, 10, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1daf9b5-3843-4c7c-bae7-5907c4b61530"), 4421, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1f39f3b-baaa-4674-9125-bdb9dbf3ca47"), 4651, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2087d84-bce4-4366-8b60-b4866a1ea63e"), 4305, 8, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e22a8eea-f001-4981-8240-8a4e4f217046"), 4406, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e23008d2-8772-4ff6-a246-778f70507511"), 4400, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e24a78ab-35a9-4c5e-9b85-12e32534574f"), 4425, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e24dfc99-045b-479b-952c-2d9eefd5a703"), 4711, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2533898-d343-4cbd-bc47-2ee3a21e99e3"), 4204, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2535cf5-6c8d-419f-bae0-331dbe44b973"), 4513, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e261d323-9161-4453-9928-9e61d76b010e"), 4202, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e26a29c1-aaa5-430f-b42d-03f6ab15b7ff"), 4002, 3, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2805f82-27c0-43a3-a8b4-74eb8c01709e"), 4564, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e28b9d89-02d7-4869-9d7c-fda8b92504c7"), 4451, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e28c45ae-bf95-4e13-870d-6421876e81b6"), 4418, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e28fdc09-1556-433b-b31a-7626fb362a68"), 4221, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2a391fe-f493-49ef-80f7-79e21cd0f05d"), 4463, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2ab1f93-8586-43c0-97e9-f87d27b6bcd9"), 4850, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2b78cad-bff1-4700-a894-afbb91501bc4"), 4253, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2ba4bd5-3390-4194-b648-0fc7652f4a9a"), 4256, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2d5cb89-b775-4561-813a-51345b986f72"), 4003, 9, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2dde945-9a18-4686-ad64-02a031c525a4"), 4631, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2ef35dc-253c-4c93-b78a-e37b48529819"), 4627, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e306b828-76b2-424f-9bc0-811cebd943b8"), 4229, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e313c61e-ca70-4b60-bf7f-38c6bb38ce37"), 4209, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e31db814-a8f2-47ff-bceb-77afa5fa44aa"), 4113, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e320696f-1935-447f-a09a-be34d17402c9"), 4222, 7, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e32a58d1-abfb-4f3e-9088-fc9d484d00b6"), 4641, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e32e6350-7437-46fc-968e-9b86bba873e3"), 4404, 7, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e338543e-07fe-4426-a4fe-ae4277670bd0"), 4268, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e359c937-4765-4fea-8af9-deab35d95add"), 4629, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e36a8057-0b1e-4bbb-b0c7-a974534459c5"), 4522, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3711cd3-940c-4b87-b591-816ee03fef81"), 4437, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e374b994-9be0-4e91-b1ab-843467388ef8"), 4518, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e377fba9-32fb-41a2-80b7-9978aae39ded"), 4555, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3855564-2930-4967-8fe7-0bc84665967a"), 4416, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e38cb33f-49f2-4831-829b-c47d670181cd"), 4415, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3aacb48-0ff8-44dd-867d-8f95a6926bb6"), 4459, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3b1a6b6-36a9-4eb6-99bf-a32479c29b99"), 4626, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3c03f25-1962-48fd-8016-a76ccb2c7d0a"), 4441, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3c16631-6426-4fbc-a734-b6ab1d7bdd4b"), 4641, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3ded9c7-c6d9-45c7-8553-8214cac65603"), 4228, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3ec883e-998e-44d4-b603-e9ff1ba81967"), 4631, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3ef79ad-d5ee-41d5-aa61-82ccc0ffc419"), 4447, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3f19d5e-9651-4657-8f97-ef59d1a01ed1"), 4510, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e41092bd-c08a-46ed-b327-c8b6fcc93770"), 4114, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e414e28a-bc95-4b79-a443-785aff5f1db3"), 4419, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4191194-da82-4084-a79f-82b001de52e3"), 4206, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4304bf6-588d-465a-a9ee-cb84175e5ff1"), 4805, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e432f4c9-cefd-46f8-9d21-a83c955d8b77"), 4231, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4366d05-8e39-470d-8b00-a40ce878298c"), 4516, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e44209b6-b3d6-4c69-98e3-de934d1f89e1"), 4718, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e462ddca-9aa0-460b-ab96-d1df1c60d3f7"), 4512, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e46596be-93e5-4531-b30f-cd7f99d316c3"), 4636, 9, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e46bbe1a-02d0-4707-95e2-6edc5ba5c2be"), 4425, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4987736-cfcb-4a8c-9147-602fc192409f"), 4523, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e49a2dde-80b9-4779-b753-f24733c00fc9"), 4704, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4a18f90-3c7e-4e2b-afd2-62acc2644c09"), 4017, 8, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4d5b9a4-497d-4350-95c6-e1aaa71747f6"), 4006, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4e2b4f1-6f66-436c-aa8b-c739339b08de"), 4542, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4eb24f9-c153-4823-bf23-3be408068896"), 4252, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5002606-e7bb-48e4-ad09-873438adea78"), 4524, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e51688bb-8693-4180-97a0-0a7582a80ef3"), 4215, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e517aaf0-86ce-4871-a27b-ad5fbc0f3fed"), 4805, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e51aa371-365c-4a1d-8df4-c94eb9d2184b"), 4110, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e52d21cd-b817-4827-b9e1-6d7a3dc019fa"), 4224, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e53ed43b-4f94-40ee-8f42-8169803b89e2"), 4552, 8, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e567377d-eb09-49ff-afab-f55eea2aa68f"), 4437, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5687e2a-0f61-4d0d-b3b1-ba72996b4b7c"), 4018, 3, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e56d9bf9-2d28-478c-8376-c91cd1e13975"), 4640, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e57915d1-3810-4ff5-8f00-ca0878797e9b"), 4015, 2, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e59096c0-e95d-4a72-9359-a84c41d2886b"), 4423, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5c5a35c-1005-4b9a-b38f-de42f2b897fa"), 4409, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5cba0ae-3210-4884-b693-f2c9c6155140"), 4211, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5d0bc7b-bfc1-497e-8f2b-c18a0b9459e2"), 4616, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5dfcc7b-b81d-42ec-a917-5d68cac9a377"), 4426, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5ea5d3a-cbb4-43d8-b24c-7e8b8d0af094"), 4544, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5faf269-a2d5-4634-9ed5-bb9ad9f1e9b0"), 4414, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e60ab2d7-8f76-41dd-97fb-c6362eeb51e6"), 4439, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e616d7f3-7a22-4ae1-8a7f-0e0b39b20a4b"), 4313, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e61be714-4680-4430-ae04-8f5aade3d476"), 4803, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e64625d2-13ee-4203-8b96-d1cbf4517208"), 4558, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6467ebd-7add-45b0-a60a-c02b4889e1ed"), 4249, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e64f3731-6e2c-4c6f-a4ef-e97bb2ed1fda"), 4623, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e65d8c7a-c97b-41f5-bf66-027160b1ebd1"), 4561, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6604b42-0a8c-4a1b-bfdf-5cf6bd2f12ba"), 4709, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e67d8520-cc62-4fba-9e7b-250615c3ea60"), 4613, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e69549fe-8f31-4e69-afee-13ea58651923"), 4005, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e697267d-de0e-4ffd-96a3-66bb549746c6"), 4447, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e69be9ab-642c-4ca4-ab0a-c359c492ef2a"), 4804, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e69f86a5-6d5a-426f-9f75-3867acf3d68d"), 4001, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6cc88ae-8654-4c02-af1e-2a62575dd355"), 4605, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6de867d-b56f-4861-b570-ddf70856fdd2"), 4603, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6df39b2-a375-49d4-b373-58d097aa3d37"), 4631, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6f3e790-017f-4008-a6c3-884f88a451b6"), 4450, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7077464-64cb-485b-ae87-3a52208675dd"), 4439, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e737d8a5-435e-4f7b-8c9e-89b878a1d8be"), 4800, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e769bc09-8540-48a8-ae8d-ce9e25d0bad4"), 4424, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e76dec7a-d9d0-447d-b2b4-01cd05fb01e7"), 4000, 9, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7aea3e8-f2dd-4657-a6f6-c263dad6793e"), 4534, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7b69540-1adb-4f13-a363-503268196698"), 4250, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8218c86-071f-4289-a89c-10636532ed05"), 4535, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e833cc52-23cd-496c-a560-a90cccc1a9f1"), 4312, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e83decfb-94ee-4a93-8e78-f51ebf81df83"), 4236, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e83fa6e7-a362-4e06-9d60-2014d0afea61"), 4511, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e87ef953-cd5a-49d2-a8ff-b9414620289b"), 4464, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8a5bc70-658f-4233-9b9d-5d04e51f83fb"), 4807, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8fbe205-8325-416b-8bb5-fbf83f6a006a"), 4430, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e90cb96e-753e-4b19-8bc1-d8fc0d635ccf"), 4624, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e929eaae-8909-4637-a5c0-7931eb934f64"), 4428, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e94d9632-5899-49f9-92df-fa19c3f6964c"), 4617, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e963da41-0e54-4766-b014-c0ce1e74016b"), 4657, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e96d54b4-e954-4438-a572-16cf7ca2306c"), 4638, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9952852-7bdd-45de-baa4-62195269bef4"), 4016, 5, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9a9741f-f996-4b5c-9b83-37a0d8ecb2a8"), 4273, 10, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9b7bf05-e4ce-478c-ac5d-bc3f534a9fe4"), 4530, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9bb7a7e-e19e-4bc8-b69d-c244cefcd014"), 4450, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9c6b2f2-60c6-4bb1-bb2e-bc056130f0f9"), 4641, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9e2be7f-2e21-4be7-ae68-4eb07fc8becd"), 4318, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9e667ed-e998-4e3b-ad4b-0448792c872d"), 4446, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea0222a2-ddd0-4427-8290-df80cb932fb2"), 4023, 5, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea0fd7a8-8ea9-4fd1-b4f6-bba5c8715851"), 4553, 2, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea13f0f7-ae34-4c1c-97b4-5285f3a0f954"), 4443, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea264f54-a815-43e7-b6d6-03f58540b824"), 4253, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea412359-0b56-4ec5-95bc-eadc515fe775"), 4109, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea85ad6c-3b3d-4540-b987-6c830fb2f84e"), 4514, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea9004fd-2dff-46fb-abc8-de320b2f7b08"), 4274, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea96426b-e095-46e6-80d3-85fbc50e2b69"), 4851, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaa947df-9e04-4395-919f-add6e3da12b9"), 4220, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eac0c93f-ddea-4d35-afa1-b5693181157a"), 4453, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ead9a3e4-4f45-4c96-baf3-7097957d59f2"), 4519, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaf093ee-6cd5-4cc2-aae3-a2ee5703e927"), 4456, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb160dd3-5d80-4f1e-b8b8-5b5bc281cdb3"), 4319, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb1f00ec-2cbf-46b9-8908-b2ef56428119"), 4555, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb2dfb44-a692-4bcf-8f40-927134564c2b"), 4703, 3, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb38e7f7-27f8-4351-beec-72685b7e4f61"), 4435, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb4b64e3-549b-4342-bdd3-878097bbbbad"), 4662, 7, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb5cf3a1-746e-4564-9a43-09f596aa64d8"), 4539, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb682850-d2d6-48aa-af8d-cc1d1ff321ea"), 4305, 1, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb7e28c4-ec92-47fc-a32f-6ef9e5473969"), 4663, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb82ebd4-1010-4a49-aa3c-7581c6501d44"), 4619, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb8ca730-d8f9-4fa9-88f9-422e29710c91"), 4538, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb99f611-ed6e-41dc-99f5-ccd5e362fd2e"), 4554, 7, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebad83dc-889c-4016-be10-9a64fb765927"), 4701, 3, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebc86b81-7624-43ee-8d5f-2320d3d59007"), 4013, 1, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebcc450c-f1fa-4bb9-832f-e5d980de35cd"), 4027, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebe002f4-60f8-491f-bc3d-7e3c8ecf54eb"), 4806, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebe892b6-ce16-4804-a91f-b6954d5c5400"), 4274, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebffc71e-1aea-489d-afc4-3ebe0281f02e"), 4612, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec07cc1b-2f4a-4e22-b57c-ae244530eba8"), 4462, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec136a7c-5ab8-4995-9316-6562f18d4344"), 4638, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec25fd2c-272f-418b-8d52-bb1199aa48a8"), 4243, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec39e27e-a62f-48e0-bf8a-130b15366d8f"), 4021, 5, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec3b3653-0f63-4e35-a92d-44506f4071b7"), 4013, 3, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec5c7890-0c4a-49e4-991d-fde25df6b12a"), 4512, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecb41534-ddfd-4552-8848-2927384beacc"), 4541, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecc6905a-4116-4189-84df-abb7903af0fd"), 4301, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecca5a96-3972-4209-bedb-2611d38c6bf2"), 4543, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecec402b-22a0-478f-bdc4-59ee4182f223"), 4550, 5, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed08fd97-3e9f-41f0-aa64-6f376e9efbfe"), 4657, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed0d67b1-fd9f-41c1-884f-93c30f709193"), 4802, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed293f11-8ae1-432e-9cab-b921b983d197"), 4634, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed2e9d68-ef83-4c7b-9b29-0168078c5380"), 4561, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed3f55e8-0922-4eaf-93c9-3b07e33b3793"), 4524, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed4d1ce6-e80b-44b7-b8aa-abec94d9a595"), 4106, 5, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed5bac92-87d8-4f04-87e3-e23a5700ec48"), 4302, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed7fcccd-6acc-4117-b534-1e9a320800b9"), 4202, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed810f75-5f2c-4f95-83bc-6ea810c844b2"), 4253, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edec615b-ed9f-4bc7-a7bc-e4096d1afc9a"), 4715, 2, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eded4c35-1230-4f4f-84b3-365c61d7abff"), 4271, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee089068-70fa-4900-a740-78b5e87bc44d"), 4108, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee1282a9-9364-4d7a-a03e-33ff6a8e359b"), 4705, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee39587e-6f87-4b79-9d0d-d10545ef7d48"), 4249, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee4b526a-8b63-42cb-b7e8-c4706f185fac"), 4255, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee4e9e95-b4c6-46ee-a39e-af665613cc23"), 4003, 6, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee51823f-7c84-4077-9989-bfd9f0eff95c"), 4200, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee5ebca6-7ab0-422f-88b9-b959abe17116"), 4507, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee7059ab-8627-4236-98ac-e46d917dc752"), 4623, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee904937-2470-4ab9-9418-3ace1c78a495"), 4262, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee944889-a972-4b94-863c-3d89ac858094"), 4507, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eea793db-ae6b-4a01-ab06-a7f4fccfe511"), 4015, 1, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eeadce84-9b17-48a6-849e-fd4ee1a6d1f4"), 4224, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eed82595-0ef0-4746-87a5-95d44852bc29"), 4650, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eed851af-1fca-4f10-9f5d-d9fc10f5e53e"), 4315, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eeddebcf-f163-4840-b60e-520a538b575b"), 4658, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eee65fcb-966b-4930-9b75-a3ec24db3432"), 4621, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eef1f759-afef-469a-9e32-a73c2f532a22"), 4534, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef15783b-bedd-409d-8531-03f0101db432"), 4001, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef1f6b89-15ce-47b4-a577-444906aec714"), 4421, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef3a37e1-ba52-4124-9ce3-ee060f45e635"), 4804, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef57b73a-dce2-46c5-a023-bc740c5d48dc"), 4660, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef616c22-c187-4f12-b9c8-a26ad2969271"), 4247, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef61acd1-ae9a-48a2-8835-8f4d8643a607"), 4400, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef6aa565-2a9a-4df0-afdc-246aa266b9bb"), 4711, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef6d5dfc-f477-46b2-af9e-db1dac814318"), 4512, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef780c39-d202-48d8-9509-75fb2706659c"), 4546, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef7d965f-df87-4bcd-a4af-a7609412d9fb"), 4032, 7, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef9a72e4-5f7f-4962-aab0-4631518d933f"), 4524, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efb1ddb9-49ff-47cd-bd0f-f9d548ef0b3b"), 4542, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efb59635-d3db-4a38-9599-822a94c790a3"), 4458, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efb71c35-0f76-404a-9dc4-03edfaa3a253"), 4456, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efca7e19-33b0-4373-9639-0f0d99892f4f"), 4640, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efd324c7-fb27-4be2-a5c7-b1cb69f7cc26"), 4655, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efe3f2cf-dfed-464e-bf55-ef41b1966bee"), 4302, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efe5a4fc-bff8-4191-a608-06f71eb108fb"), 4561, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f01c3e42-f2b0-4628-bf15-c0538e979980"), 4103, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0233f93-19c7-48a7-bead-6b1d7c43e811"), 4657, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f023f0ad-4ee4-417a-9724-a525f890e23f"), 4418, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0313a0f-eabb-4d80-98f0-31ad60e53ac6"), 4502, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f03d11d2-38de-451e-876a-573a1ced0359"), 4547, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f045d98c-8b3a-40d4-96ed-9aaf85d31bdf"), 4505, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f04c7d56-27ba-45a1-aa56-4e7104de104f"), 4212, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f06c9d1b-6d0b-45d8-ac3b-a61ccf00401c"), 4562, 8, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0705ef6-5a4c-4545-ad8b-92a7d495e888"), 4112, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f07deefd-fc0e-4ae8-8bfa-ad7205737f66"), 4246, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0c1d0af-ea60-4628-870e-a386e6e2a30b"), 4020, 1, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0c46b38-1e1b-4ab9-851c-311a46eb6000"), 4509, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0cbf483-0ce3-4512-8152-4e8283153e86"), 4425, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0f0d81e-8715-43b9-8140-2a55ac33b4b6"), 4265, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f10d3af5-b5ac-49d4-969d-321975ce07de"), 4115, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f127b738-5855-46fa-806e-c79a6348b33b"), 4233, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f12a7e19-5333-4008-9c8e-ec3c6efac4c2"), 4507, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1451963-db1f-487d-b38a-c9fb15f6afc5"), 4318, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f153ce9d-1140-4266-b2fb-de356b543e87"), 4531, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1757c21-b375-4ce4-8339-41de3e1f6252"), 4252, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1b678df-82a6-431e-b40e-ac551bfc9c89"), 4403, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1bab132-daec-4c2f-8f62-3c34f4717d8a"), 4855, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1e2ea65-694d-41f8-b92f-10cb91bb1c22"), 4462, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1e3ad27-ed93-4a3d-a70c-9ce7a9d7787f"), 4107, 5, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f22549c0-d25a-40eb-80db-6910c25653c1"), 4532, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f22ca3ca-d8f7-42e0-9848-6281f1ee4d3c"), 4022, 8, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2410c53-7713-44f4-ba8a-972d91f05d02"), 4500, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f241e8c0-9572-4c2d-8ace-25d716b5ba9f"), 4025, 7, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f24a42b8-0b76-42c8-8518-46a348c998a0"), 4504, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f24c3479-24db-4c57-9804-844c9f8a0e83"), 4201, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f251834d-22f5-4347-9625-9af7f4260c61"), 4524, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f25b337a-e64f-4780-81a4-dce26f1f3e23"), 4248, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f262ebad-ee3e-4400-8878-2ee6f64f5175"), 4000, 5, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2636d66-c804-4ae3-b8b1-8389edd9ee46"), 4710, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f29f2f02-6dc2-4e8c-beeb-5d51703f1848"), 4619, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2aa40c0-367a-4ffc-8694-7e21b43165f5"), 4241, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2c59a17-b51c-42e3-ac2b-95be6e6683c9"), 4210, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2d7ea40-8133-4bce-b40d-f659e4d92eea"), 4663, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f302a4f6-1fb1-47e4-ad97-7713995b460f"), 4452, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f30f2409-cf90-4039-95a1-98cae012ca6b"), 4405, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f33ba7a4-8ff7-452c-a0bd-59ce60b9880c"), 4617, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3466a79-9140-46af-b55f-28f0b15e4dbd"), 4217, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f36670c1-a1bb-4fb1-8ef9-6975ddc4117d"), 4006, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f371b9f4-9319-483a-a854-318a6e38de55"), 4007, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f377b19f-8f18-487c-a60f-778b7abfcda7"), 4464, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f37bd986-38a3-4f64-860e-8e901a6bb5a7"), 4027, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3849d5d-89b6-4f97-b13d-1d24a44d3642"), 4439, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f38aacca-94a7-4635-88ae-1d33d5bacbc5"), 4402, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f39aafa7-9503-465d-83f9-3ac7e93c94b3"), 4806, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3cbde6b-e867-4bc3-91c8-8428d14358aa"), 4113, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3da1cdb-ebfa-4196-8557-71439c43376e"), 4410, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3dd6728-c176-4023-ab8e-b7d813dad73b"), 4458, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3e53548-620c-469d-8b94-1ef986baeba3"), 4218, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3ed14fc-ff48-4772-8807-4e0053f16674"), 4019, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3edcdda-df66-4d95-9341-af794ec536b5"), 4637, 1, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f40b4bbe-b755-4098-8e35-6d881fa3f36f"), 4503, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f44062bc-1dcc-4064-be1d-f9ac2c3383fb"), 4204, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f442dfdd-1553-43e9-84ac-8a105606bfe5"), 4500, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f44350c6-b458-4d3e-a6a7-a3f1cf5670ee"), 4018, 8, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f46816cb-1df4-4790-9076-fda8b4a54b60"), 4715, 1, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f46c9faa-ad71-426a-be51-a7b22307772a"), 4242, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f473ed29-e5b9-4bd2-b2af-4995d74686b3"), 4035, 3, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f47dc52c-41cf-487e-bd56-41f0033332d3"), 4804, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f48a32e9-e090-4979-85a2-ecd0911ac7f2"), 4431, 2, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4930e26-2ad2-4be6-9490-307f840026ad"), 4656, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f49fce15-7cfb-4a71-94d2-f64fb10a1480"), 4562, 9, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4b57ce5-b116-467e-b65d-6b5961fc0acf"), 4432, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4b6b684-e501-4630-93f2-3dc58245cde1"), 4714, 3, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f50eeb28-002e-4359-8744-8591f9412986"), 4265, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5389971-abe5-484c-9421-db229b62c861"), 4517, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5495e6f-cdb3-4cba-8455-d69f1d51deeb"), 4545, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f56dee3c-351c-41e7-b4b9-ef1c28bfa9e2"), 4000, 4, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f587d083-deaa-4dd8-a450-2a9c06c88031"), 4004, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f59fb771-0c05-4de5-b619-0fd3e67a0d1b"), 4217, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5d30ef7-8bb2-4bc7-9bd8-684781b856b1"), 4300, 3, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5d8fad2-2aad-4ce9-b0a8-1f8e8cbdf78a"), 4427, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5dc3c51-e9a8-4827-a549-24694a4f887f"), 4408, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5fa7dd4-4e66-4f2a-9ea2-a59510a21ff7"), 4804, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f610409e-b8f3-40d9-a5d6-63bc3b9f4e20"), 4632, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f620d9c5-7b13-44af-ad93-c0a6516b7c8e"), 4500, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f623d3f1-46de-4e18-8fb4-758ed749d269"), 4455, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f64d1770-8865-419a-a59e-7b52cfe52524"), 4273, 4, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6805d66-2a88-43ef-b3ba-4f63ce2e5fcf"), 4216, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f68e5f8c-4555-4889-a86a-6be93af1156f"), 4011, 7, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f68e93fa-fa89-4de6-823e-5b25d85a1fee"), 4856, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6a51b39-8f22-4332-9b8f-6d34f7dc3042"), 4113, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6abbbc0-e370-43d2-a7f2-afd894aaa77d"), 4011, 6, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6c2db87-6c0a-4027-b732-fc7462e868c3"), 4019, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6f7b6a2-5b69-4a71-af3c-a6f162e6eb32"), 4013, 4, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7197377-2487-4c1f-b550-f8b28c7d20b3"), 4307, 5, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f73e4bad-8683-450a-a32f-dee196e574d8"), 4558, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7414e9a-10ac-4d69-a327-9497d139410b"), 4426, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f744b159-9c71-471b-a5e7-1972c01e3a6b"), 4401, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f74c6712-5548-4aa9-81a3-627be41751f3"), 4554, 10, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7610ab4-ad75-4acf-9e99-c06faa6b449b"), 4855, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f772b52d-e8ec-4c16-9a93-5b138f376fc0"), 4261, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f775e4d9-dc17-4f1b-ba92-ceec966704bf"), 4434, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f77e953d-f501-451c-8395-a796978aa100"), 4203, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7989c6d-6392-4f5a-9646-884a23ec93a3"), 4225, 6, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7aaa395-bcda-46a0-a7e5-52e9cd6dfd01"), 4104, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7c60e0f-ab97-4e5e-ac0d-602aea9df5e5"), 4258, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7e347d3-0bf3-4066-bfbf-a9b6d7f5101d"), 4713, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f82fca84-8d5f-46d4-8aaf-56ac648ba9d7"), 4504, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8398a31-cb1c-4d5d-80c1-6d07601b6a95"), 4238, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f843ce2a-627f-45e8-b0e5-687d5144958c"), 4852, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f84650b1-98d9-45c5-b443-2154fd332c7b"), 4109, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f849a775-1228-44c6-9b35-fe1056c1a649"), 4306, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f84ff0bb-8014-4af1-bfbb-06de0fe0728d"), 4504, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f852b1de-3d8f-44a6-9a7c-d4eb8003d8e4"), 4266, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f85c021d-a509-4b8e-89e7-57ddabb47f93"), 4239, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f85d2226-60f8-45f7-9b81-1c07ef684bd0"), 4551, 8, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f86903ae-7ddb-4d89-9659-e98958b0e20e"), 4244, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f881b6db-a025-4a54-aff8-c35f9442fbbe"), 4409, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8881a4c-8db7-4537-8ba0-dd26030b9736"), 4709, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8a5b260-a55b-45d8-b2f8-1b7225d2c12f"), 4529, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8ab7d1c-3491-4b18-a341-094d5ad2dcf5"), 4223, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8bbfe44-caa9-490e-acf0-35a8c59367b3"), 4270, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8e4e867-83d8-4071-b1d5-0b080e8bb97b"), 4418, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8e9793f-0db2-4fc1-a231-4256c16cac5c"), 4501, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f90bb922-0c08-43d0-9eac-ac4884bf0ccb"), 4247, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f91a8f93-c487-4328-b540-98f2b86d8656"), 4518, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f922de19-a377-4297-ada2-42245f85a532"), 4630, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f94f63c1-ad45-42d3-ab78-3bbc6bc76ac7"), 4301, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f955273f-1630-426f-979b-6ab5d00adf02"), 4613, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9757831-9557-4790-a179-34100b170a71"), 4534, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f97e06ee-946c-4c3b-a55c-71d244d1fba0"), 4035, 10, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9885569-53a7-4b51-bec9-42dd4adb65c2"), 4426, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f98e6293-333a-4608-9b45-69b46324db13"), 4527, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9943760-0978-4920-86cb-e7ebdf8bfe45"), 4245, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f99fa8e3-cbb5-40f1-a0e6-9f77b5fb9992"), 4202, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9bb8e70-44cf-413f-9ba2-ea094954a253"), 4100, 8, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9e0ae99-62cf-4ee4-a8c6-27f3efdb6e7c"), 4707, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9f0972e-1bfe-4e18-930c-4588a5adae94"), 4025, 4, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9fd31b2-5401-44a7-ad66-18171529b147"), 4516, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9fea255-a695-4f38-b7ef-bc4ef64b4ed9"), 4636, 7, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa0ad4e9-e5bc-423c-b3c2-5f77a5200e0b"), 4519, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa2fcef5-d371-4bd0-b31b-129190db2689"), 4507, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa4a2e57-f947-4dc5-928a-daba1ef6a381"), 4658, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa5a9172-7dad-43c7-b96f-0093c136594e"), 4801, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa60ab05-2dcf-4493-92a4-3d4ea191b04d"), 4112, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa85975d-c940-4fc4-8038-3c4c20b12b6f"), 4268, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa966219-648d-43a0-90fe-7c82307a9533"), 4233, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("faa09791-060c-48c9-a3ee-dfedfdf11d9e"), 4223, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("faa9bd44-c9fe-469f-96f3-cb142f08f9bc"), 4212, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("face1ef8-26cf-43ee-9dc2-30737ab963f2"), 4321, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("face822a-2d74-4edc-8f4c-fa32ddf3ffc3"), 4461, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fad33bb9-0484-4a79-b9de-d47430434310"), 4103, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb2f9e31-0d84-44a9-a802-784ab5fc6b4c"), 4700, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb3bf077-c0ab-4496-a426-0b375a01ddcb"), 4025, 8, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb3c3216-9a15-4967-8e19-4b45ea5f678b"), 4428, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb41d374-1ce3-44c2-9d31-aac79ad0bb5c"), 4012, 4, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb665a33-e27c-43ca-afff-9d98e66b35af"), 4310, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb70da26-9bf6-4ab8-8ebc-ebbde7c84788"), 4233, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb771165-70dc-4cb2-917e-9f7ad4bb2c6e"), 4456, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb79747e-6747-43b3-ace2-4f29d80e00a5"), 4539, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb84e0f9-05dd-4b04-9d8a-a0823bf2c9ff"), 4109, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb89175c-feab-4dbd-a240-0a01c8fe9fd5"), 4315, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb89cddc-1043-470b-9349-52b69daa8a27"), 4501, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbaef4b9-08f6-4230-80b6-751cecf35b0c"), 4420, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbb29b70-5c5c-41ba-91ae-3d00b10d6617"), 4222, 3, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbcacbf8-bb2d-4e3c-8505-7368bf333890"), 4613, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbcb0fe7-b20c-4475-8107-fa66dba6703f"), 4530, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbed2eb9-fedd-4a39-8964-0903e18f9bd0"), 4020, 4, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbf2f631-375f-4f32-a5c9-edfca4f7d60b"), 4636, 1, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbf8726d-b038-44ab-bddf-8a302a2090c9"), 4430, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbfd518a-c8ee-46ce-94b3-c88713faf8c2"), 4512, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc17d67a-b789-461a-81bc-882c41bed2fe"), 4112, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc212661-8cab-4e00-8ba5-dd2ab9828df3"), 4424, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc243428-60d5-44e6-81dd-5cf7ac7d5156"), 4619, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc2a7422-0f29-40d5-9303-f47aefb77689"), 4662, 5, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc42efcd-9561-4421-a03d-3b11041e0eaa"), 4252, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc59e98d-461b-4df1-bd3c-4a970a8ffe8a"), 4303, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc7b0625-e6a9-48a9-861f-526c9575dc26"), 4628, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc9535ad-f111-415f-9f6e-7d171fe76f99"), 4454, 3, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc958538-bf19-4cf2-a0dc-4733b664fd4e"), 4616, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc97c318-ac37-4029-95b0-09e2aedb207d"), 4629, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc9b4a61-ea5c-403f-9097-62a2540e933c"), 4507, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fca0a464-00b3-417d-a843-2aa430fd5ac4"), 4716, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcb19166-c3f8-40d1-894e-fa83eebe5fa2"), 4552, 10, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcdc9d76-e9b5-4692-bb68-18fdaaaf8694"), 4621, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd001146-c314-4a81-bd9d-9fbe968c33ca"), 4662, 6, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd0434c2-c797-4d89-9bf7-111a75f957cd"), 4303, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd15c4b4-8bac-49a6-8194-a600b731d34c"), 4451, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd1fda6b-24f2-4a3f-b206-099fce755e75"), 4537, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd23f67d-9516-46ec-ba45-60a794218bbd"), 4216, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd29d75f-0b71-4796-b50b-e9c1e20331f0"), 4209, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd2a20db-78be-4ed2-b593-9a35d9f1f867"), 4603, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd2d679a-50bd-4528-afb2-9e125cce6582"), 4208, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd4a8bbc-7fe7-42cc-b934-6ccb16989da6"), 4020, 5, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd5af8f5-73fd-40d0-8bb9-4bf0da52e3c5"), 4604, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd706794-f1f5-439c-9b09-dde654f58b8b"), 4561, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd713ac2-443f-4ea3-961f-f4d0b4fb6fc8"), 4608, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd76348b-fbdd-4041-9f07-1c3e74af4e23"), 4313, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd7a8cd3-ec7c-436d-b0cf-5162aa895daf"), 4411, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd7c094f-32a1-403f-9d36-853ca1bd7f1d"), 4252, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd7e5ac5-b4b7-45e1-80ea-e1c31b03a2c8"), 4309, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd88cadc-e906-433c-ab55-4f4fbab618fc"), 4007, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fda28166-c858-4e2e-8306-0b06835fd1f9"), 4020, 9, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdadef84-11c3-44be-9051-7ffa6acdb11e"), 4259, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdc7937d-a46f-45ce-9bb1-72c32f0a1f8b"), 4706, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdc9cbbf-7e1e-47f4-97ae-e8cdba6c53aa"), 4263, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdd7809a-fb5e-4adc-b622-bc4d9b8f76fb"), 4022, 2, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fde59dc2-0c7b-4604-92bc-9cde942bd4e6"), 4209, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe0b07df-84df-4593-9ad8-b5415f1af83b"), 4314, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe161730-f594-40f7-81f8-9dc655880664"), 4654, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe39df84-915f-4087-bcc1-aa4357648a93"), 4200, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe3acb17-42d2-4c8a-bd6c-440d2e4e4f93"), 4312, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe3e19af-ec2d-4a99-aa01-6e74bedc8841"), 4855, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe72fc66-37f2-4a4c-9707-76ee2f620767"), 4033, 10, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe913ae8-16bb-4b6d-884e-c766ae95595c"), 4615, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe9483cc-11ef-4683-b299-808390bd2a5e"), 4722, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feb1fa2a-5396-47ba-95de-d97ad5a54f07"), 4020, 3, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feb4dab4-6fb1-4382-9ec0-15eee8d22fc4"), 4613, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fec0c5d8-3fa3-4136-ae29-d04082621fd0"), 4550, 6, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fec7bd1f-a808-40bc-9e11-badab32197ac"), 4851, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fed98dd4-eca2-4fb3-a2c0-eaee54583233"), 4655, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feda53b7-6374-458c-af61-2728578f2dc6"), 4622, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fee2f34d-170c-4de5-ba22-e791dc873d80"), 4618, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feeb2ac1-e0af-4884-b71e-6f171e904287"), 4801, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feed905f-e79f-4df9-974f-543877e5bdd2"), 4451, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fef10901-73e6-4a22-8c0d-7940614a9216"), 4272, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff249e2c-eff9-44ed-b2be-c12f8ed4cacc"), 4609, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff3d6a43-054e-4c1f-b5c8-2ddf8af1d1e2"), 4259, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff446cf9-c07f-4f64-92e5-f9faf121f70c"), 4723, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff57c45d-9891-400d-8b59-216a7e64aa72"), 4431, 7, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff5c1ba9-3c7c-4ed9-a148-c808106bb6c5"), 4203, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff86faab-57d0-4c67-974d-6ea88b48df76"), 4522, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff9e85de-78d8-4b65-83b3-c872fd85c578"), 4656, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffd3ce05-05ef-4a70-b5c7-9fb72b5b51c4"), 4204, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fffb6cbe-e19d-4525-a0a7-46cf44100410"), 4462, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("095d2f26-52c7-46b9-9e62-a58530c08982"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("0eef2a06-e7d4-449c-b135-d2ac7b857f00"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("1abfb834-edeb-4ddb-aa13-27ec4b1f9018"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("1dd763c2-5e54-467b-acdd-460eba501180"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5c21eec6-04df-4fd9-8f82-4dc981372009"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("7f74528c-d8c5-4599-a810-bb6fe7084852"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a9609bee-7403-4f9e-ae3c-27039d4d2b31"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b6b0d6f7-f47a-44ba-9ff7-5c0ac31ff50a"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ebead151-0b9d-4ada-80c8-ac202a6eee13"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("f3735cb5-d701-4dcd-a64f-831464b94499"), "APCDevice_8", 8 });

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ConstParamsId",
                table: "DynParams",
                column: "ConstParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ParameterDataInfoId",
                table: "DynParams",
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
                name: "APCSimulationDatas");

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
