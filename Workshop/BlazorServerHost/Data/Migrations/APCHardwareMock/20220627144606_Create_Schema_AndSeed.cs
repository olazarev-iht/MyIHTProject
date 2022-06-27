using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardwareMock
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
                values: new object[] { new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("025fce1b-c0a9-4fd0-9353-f3796ea4707a"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0855d37a-49a2-44e5-ba25-6742b562307b"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1bbff2fd-de51-4941-8291-6dc12c3006ad"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("22340841-bc7e-4a93-a5d9-17b75fae04c6"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("249ad0f9-d2e4-4da4-981c-09e5fc33af91"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2a7bc61e-44fe-4380-ac0f-056cc0aebd97"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("304495c1-fedd-467b-bed7-8378154bda87"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("34e0f9f9-d353-4588-82c2-a5a2e6782aee"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("411b507a-76c8-4158-a9c0-0405690d1947"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4c31ddaa-a9b8-4e8c-bc74-5d0abe253d05"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4e8dbe95-60a1-42bb-b9ca-1f979e6b2d25"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5086cb77-5121-4042-adb6-9171c0d584e4"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("62c9a576-40bf-419e-8359-b7d2f5d3408b"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6372f193-7163-40bb-a1f3-eb974c69477d"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("66581409-ff81-4fa8-a3ca-ea9445f86eba"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6c050c73-e32e-435b-9606-65e6294eeb6d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6d27ec27-5ee5-466d-ad95-38b2c5b6f819"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("71f62801-e2da-4f50-acab-984e70109d49"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8314b8e6-71f1-4f9a-a893-f671ab3d7b38"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("83811fd5-e9d0-4139-b039-a3a058a6f83e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9b946901-a377-488d-a894-6354a89c931b"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9de6cb89-270b-4d1b-8834-475bb1eff1bc"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9e2082fa-4419-4ae6-8354-0abc74ea8a3c"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9e82b924-7963-4321-afee-e990ca31253b"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a7e0e00a-bbab-45a5-a208-998b5a2e0d39"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("abd0bada-3932-4292-aa19-c1fa8f0f9c2f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ae2c1727-17eb-48a3-bd12-9e691982e335"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ca93f9d5-a401-44f4-bb5b-d8d492b61fb4"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ce456279-2e1a-47be-a93b-2507dc0ac374"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d8626611-2945-414b-9d7b-f0ff915eb80e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("df85dcd9-3e55-4e0b-97bc-585514535052"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e758f18b-3c3c-46e7-b2be-725a9c549ae1"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ee9c5ae5-ccf4-4ecb-bc8a-edc6894fab73"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0e56b3ed-e8b1-470d-860b-0aa38676f186"), new Guid("249ad0f9-d2e4-4da4-981c-09e5fc33af91"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1817805c-f9f7-476a-88d1-e762d0cf0b81"), new Guid("83811fd5-e9d0-4139-b039-a3a058a6f83e"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1dd1edf9-c049-459d-9862-8acf3c73df9e"), new Guid("304495c1-fedd-467b-bed7-8378154bda87"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("26564483-4e87-44c5-aa1f-08c929b0933d"), new Guid("9e2082fa-4419-4ae6-8354-0abc74ea8a3c"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2e7fa486-65b4-410b-b378-241112bc436b"), new Guid("5086cb77-5121-4042-adb6-9171c0d584e4"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("34413dde-b182-4562-a339-34d0674512b3"), new Guid("9de6cb89-270b-4d1b-8834-475bb1eff1bc"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("391d0b37-3500-44fb-9e21-832078b6748d"), new Guid("6372f193-7163-40bb-a1f3-eb974c69477d"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("462fd30d-5998-45f9-8eb8-2f207df2b2e3"), new Guid("4e8dbe95-60a1-42bb-b9ca-1f979e6b2d25"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4e347357-d5c8-42af-a531-6c24e64828cd"), new Guid("411b507a-76c8-4158-a9c0-0405690d1947"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("57792d65-24d6-4b87-a926-7a15f837c442"), new Guid("e758f18b-3c3c-46e7-b2be-725a9c549ae1"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5b2ca97a-0cf1-47a4-a3d5-32b3976e70c3"), new Guid("34e0f9f9-d353-4588-82c2-a5a2e6782aee"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("61bdfaa0-f138-40bc-90e6-ad518b777f07"), new Guid("6d27ec27-5ee5-466d-ad95-38b2c5b6f819"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("63c66b52-7ff9-4db3-9a75-86d60f72b655"), new Guid("2a7bc61e-44fe-4380-ac0f-056cc0aebd97"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6759bc3b-6e04-4c66-8dad-97557f85b0c0"), new Guid("d8626611-2945-414b-9d7b-f0ff915eb80e"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6c113bc4-9a13-4490-8151-f95bb0df0b42"), new Guid("abd0bada-3932-4292-aa19-c1fa8f0f9c2f"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6cc234ee-7ad4-4daa-9d93-50731f0bbd06"), new Guid("62c9a576-40bf-419e-8359-b7d2f5d3408b"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("7420daab-942c-4522-bea8-55eef89d23a6"), new Guid("22340841-bc7e-4a93-a5d9-17b75fae04c6"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("80cde3e1-534c-448e-bb93-3f725d5b7c35"), new Guid("9b946901-a377-488d-a894-6354a89c931b"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("88399f09-01be-46c9-98ca-183e37811cd8"), new Guid("ae2c1727-17eb-48a3-bd12-9e691982e335"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a3ab3e61-28ee-4cf0-af50-593a97ab66bf"), new Guid("6c050c73-e32e-435b-9606-65e6294eeb6d"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ac04fde6-761c-455a-a457-6037a9d9981a"), new Guid("0855d37a-49a2-44e5-ba25-6742b562307b"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ad90b0e9-3098-4836-8595-87ab734a839e"), new Guid("71f62801-e2da-4f50-acab-984e70109d49"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b2174e27-f7ea-4fd4-9d12-6cca5d78aa84"), new Guid("a7e0e00a-bbab-45a5-a208-998b5a2e0d39"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b2613df3-1c53-4f48-9c20-ecb9b5b8e203"), new Guid("9e82b924-7963-4321-afee-e990ca31253b"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b305ab5c-5664-4a21-9374-65a8fd2922a8"), new Guid("66581409-ff81-4fa8-a3ca-ea9445f86eba"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bc3782c5-9993-4dfb-93e0-d9e5fc03c462"), new Guid("df85dcd9-3e55-4e0b-97bc-585514535052"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("be9b7fc5-2cbe-4762-a740-759a56962c36"), new Guid("025fce1b-c0a9-4fd0-9353-f3796ea4707a"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d9aac3f7-2975-4921-9f5c-8445711543fa"), new Guid("1bbff2fd-de51-4941-8291-6dc12c3006ad"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e1da9a7c-fa97-4ecd-8191-62b4bf63eea3"), new Guid("8314b8e6-71f1-4f9a-a893-f671ab3d7b38"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e39ce774-3302-4556-8a3f-15e618abd035"), new Guid("4c31ddaa-a9b8-4e8c-bc74-5d0abe253d05"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e5418611-29b0-41b4-ae77-f4e0ebc9a48c"), new Guid("ce456279-2e1a-47be-a93b-2507dc0ac374"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e6465950-ffe5-466f-bc04-e13e5b2b595e"), new Guid("ca93f9d5-a401-44f4-bb5b-d8d492b61fb4"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fab75120-ef58-4c06-a022-8cc3aa4c0edb"), new Guid("ee9c5ae5-ccf4-4ecb-bc8a-edc6894fab73"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("001d6f47-50c6-429c-806a-bf0be07e8579"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("e6465950-ffe5-466f-bc04-e13e5b2b595e"), "Device2_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("041475d0-9dc1-43a6-bf42-a793b86b4878"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("63c66b52-7ff9-4db3-9a75-86d60f72b655"), "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("09f6b35d-e08a-4421-9f5d-36631228cf8e"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("e5418611-29b0-41b4-ae77-f4e0ebc9a48c"), "Device1IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("169d9efe-8256-4fde-b061-405aa8a596cb"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("61bdfaa0-f138-40bc-90e6-ad518b777f07"), "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("1722d702-04f4-46c9-9f9b-8160c01c0bfd"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("1dd1edf9-c049-459d-9862-8acf3c73df9e"), "Device2IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("173d2275-0e36-40c8-85d8-eb40fe016c3a"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("6cc234ee-7ad4-4daa-9d93-50731f0bbd06"), "Device1_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("25f225f1-5621-46e1-b87a-c2d4d96bfbbe"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("fab75120-ef58-4c06-a022-8cc3aa4c0edb"), "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("2649d3dd-be59-429a-8c4a-ec81bc42948e"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("2e7fa486-65b4-410b-b378-241112bc436b"), "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("2ff2a553-0ec6-428b-9605-4a0d4be99068"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("6c113bc4-9a13-4490-8151-f95bb0df0b42"), "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("36fe0036-c33a-4ce3-9afd-e73b7376d322"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("b305ab5c-5664-4a21-9374-65a8fd2922a8"), "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("485fcd84-bcd2-4214-96c9-7f547a640b21"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("5b2ca97a-0cf1-47a4-a3d5-32b3976e70c3"), "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("56187ace-3589-4f13-9b51-6dc68ecd14d5"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("88399f09-01be-46c9-98ca-183e37811cd8"), "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("5ae2cdf3-4034-4693-a514-60c7177f195f"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("b2613df3-1c53-4f48-9c20-ecb9b5b8e203"), "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("6084ecb0-c3e9-4f18-864b-40a755060074"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("26564483-4e87-44c5-aa1f-08c929b0933d"), "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("6977cfdd-0448-45e0-9d1a-db30b779d7ed"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("0e56b3ed-e8b1-470d-860b-0aa38676f186"), "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("6bbf14bb-71a7-4e08-a49b-67e2469ead7c"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("462fd30d-5998-45f9-8eb8-2f207df2b2e3"), "Device2_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("74f34648-3f2e-4fa7-b53a-6745e4bf452f"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("ad90b0e9-3098-4836-8595-87ab734a839e"), "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("818ceb88-7229-4a79-a801-31afd7e2d136"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("ac04fde6-761c-455a-a457-6037a9d9981a"), "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("8b0a6717-79bb-422c-a3d6-203ef3bb9c01"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("b2174e27-f7ea-4fd4-9d12-6cca5d78aa84"), "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("92b65e8b-2da5-430c-a1ed-2e0a9ea95dab"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("be9b7fc5-2cbe-4762-a740-759a56962c36"), "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("94d58f57-e013-4968-83bb-2254900d26b0"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("e39ce774-3302-4556-8a3f-15e618abd035"), "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("a470f116-cfc6-42ed-a71b-caf645a869bd"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("a3ab3e61-28ee-4cf0-af50-593a97ab66bf"), "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("aa119ea0-d1ec-4bdf-9244-479080422350"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("bc3782c5-9993-4dfb-93e0-d9e5fc03c462"), "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("ac8b24ca-7c10-4013-bb41-3847d32c4ac0"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("80cde3e1-534c-448e-bb93-3f725d5b7c35"), "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("beb4f00d-5bac-47fb-80f7-470b312a258f"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("34413dde-b182-4562-a339-34d0674512b3"), "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("c3ac0316-9b40-40a8-b65a-520b13092f59"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("391d0b37-3500-44fb-9e21-832078b6748d"), "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("c537a104-d9a1-4a9e-a302-4541d75d4a09"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("6759bc3b-6e04-4c66-8dad-97557f85b0c0"), "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("d0101f02-5ff4-4f1d-b473-2a55d6980292"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("57792d65-24d6-4b87-a926-7a15f837c442"), "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("d3951ceb-2b79-44c4-9817-a01c1f09fc20"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("4e347357-d5c8-42af-a531-6c24e64828cd"), "Device3IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("d651130c-cdca-4c7b-931b-31de1c286932"), new Guid("5738f1cb-bf62-4884-9212-b758a1bbf68b"), new Guid("7420daab-942c-4522-bea8-55eef89d23a6"), "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("e499612e-4d9d-42f9-96ac-7ec14f067cd9"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("d9aac3f7-2975-4921-9f5c-8445711543fa"), "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("eaa35fff-4d20-49a9-b2d4-9da9b0616f58"), new Guid("758a0f68-8677-4071-b8b8-c2919112fc23"), new Guid("1817805c-f9f7-476a-88d1-e762d0cf0b81"), "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("f3ced4de-2214-4fd8-88d4-7de7b9060c22"), new Guid("590f87c6-f007-43e6-a9dd-cd8c674f86dd"), new Guid("e1da9a7c-fa97-4ecd-8191-62b4bf63eea3"), "Device3_FuelGasIgnition" });

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
