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
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0099bd9c-3719-402c-b626-c5c48355aecd"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("010f3896-1557-405f-bd1c-b929fabc6e66"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("05e2f759-2237-49f7-aa36-e7bfb01068f8"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0d9fd956-1c89-40d4-b6a2-3ad8769fc513"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("11e689c4-8644-47dd-85fc-551793a99d71"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("144c26f8-c510-4182-911a-cfaf335c3982"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("15c2a76b-ba6c-4a74-8ca9-1d3d4ddb3e55"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1681d05c-4ad7-447e-879e-585bbc30e72c"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("176f205d-b19f-4c08-bcc8-873b23f65fd0"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1a3a86f5-9bc8-4c3c-a5a0-8d5d15638300"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1a3c7d7b-d18c-4cec-8650-392889080fc4"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1bc16eba-fdf2-4b25-8744-b29a27071f0d"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1c7768af-d14d-47f2-975a-491b80293d81"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("203c9a6d-c048-40d7-8461-9270f7e70d8b"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2676fb65-09af-49b5-b183-5ba9b4bd1dd0"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2bebb683-68d8-4f55-a205-fbf9c6a1269b"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2c846445-8eef-40b1-b1d6-cbfdf8e639df"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3287f05e-5839-4c4b-8a16-d881562babb6"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("34de17f8-469f-4ff0-bcb6-f8b6d32f21e1"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("34ec2e40-eeeb-44dc-984f-caf58b1fede4"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("381562d6-bf15-41b1-a154-dcccf60c9f1c"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("38705535-c98b-4a77-94b2-5b301bd85f69"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3c24fe8e-5c9a-495d-9eab-fa18f49151dc"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3cefa271-bd00-4d53-ac28-eb09ca985771"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("47b932a5-42f3-47b0-9563-9fa450de5b45"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4a840774-3b7b-4d29-8011-e0d16c31d4ec"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4dc07e68-827a-4f29-aa10-1d9574950de5"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5235b92f-dd34-4786-95c1-ac614cee2901"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5315bdbf-6325-4db7-b56d-e7bd1a8d1818"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("53ed3adf-3f25-4548-a492-cad98f21c562"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5407ee45-fa3e-4350-92a8-683a881104ec"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("58e9c175-b9ed-468a-990d-e0c29109e002"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("591b2dca-46c8-4941-a122-bdbed50d9dd8"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5e8af8c9-5e96-486e-af41-8a0fab35b032"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("62b569a3-9a32-48a9-90d8-b86e2287d5ab"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6936069c-bb73-48c8-9611-9778d266c6fa"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6b457d7f-a9b3-4a60-9e5d-c1c59e5e86e7"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("70115302-908f-4a34-88c1-97a0879b4cea"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("745ed6b0-5536-4ec4-b311-c1d00c239d84"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7b74647a-9d4f-4675-8ee7-ba86b479aafd"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7d8ee1b6-6cde-4600-9f81-4910629f5426"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8066ed71-2789-4ead-9b17-5fe8a58d6f5f"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("81d9487e-eb8f-4683-be42-8f233ab65b87"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("88f8fade-ed8d-459f-98f8-6ce76d5d59a2"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("89c47b40-b6ec-4307-a130-e298698fcb3b"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8ab9002a-bbf1-4758-a88d-55f90a755d95"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8bd30f0d-64ea-4f23-b4e5-abf59fc71216"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8cc34500-93e6-48eb-b2bb-42539f1dce2b"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8d7f4031-bfd4-4a1d-b1cd-fec40d136b58"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8f098808-9d04-46c6-ad8f-1b74e81e509d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8f31deb7-4456-48cf-aa48-8d41bc1aa917"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("962db82b-da8d-4ee2-9df7-fe80176bca35"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9a2db6e1-89fc-4dd5-be37-33a1f6b9f288"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9c830ec1-6ee8-41d8-a98a-98d3c95f53d1"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9d0ca6d2-fa95-4714-a41a-1cf9178147ff"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a7486daa-219e-4a13-8ce5-6922e84797dd"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("aa477617-e725-49da-aa40-94829905d887"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("aa9be140-69dc-4bb7-8518-88a89cb95005"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ab21d0d8-2d64-4a38-8316-c3dc00f8bf28"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ae4e899b-4957-4cae-82a6-c5a8a0d18f7e"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b18a5965-64bf-46c8-87b9-dd621a4d443a"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b26289c5-e52d-4fca-9ed4-6f2ffa671ac2"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b82c8ab9-4d74-404e-a033-9f5ceeef546d"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b8e41166-032c-484c-902a-46ceb40fb7bb"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bb9a5a81-0265-413d-aa14-9b5e8a7f052a"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bdbd5f52-8760-4313-afc1-18af0206a962"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bf106332-8f51-4151-92a0-73873d056557"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c8b93ecb-0695-498b-97fd-37524e1b8a8f"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c9c92615-3948-4b9e-964e-81975582c439"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cbbc70c4-9638-43c5-8876-da053e58c76f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cd6f66c9-60e9-400a-bc36-cbf50388402e"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ce9a62ea-e527-4f01-9e1c-931f971ba56b"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cf38f7ee-fc40-406c-b9fb-1ef447089518"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d19ba105-1fd9-48f8-afc2-1bf7cf8a5466"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d56e9cd6-ae3f-464f-83d1-f7c6c05b660a"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("eb2ccaa1-d170-42ba-a551-6162cbaf9b2e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("eb514aba-3a56-423f-8b17-2157e079d2f9"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ebfe5f1c-10d1-4f89-9d34-7fc1f94757e6"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f021fc5f-bbc1-4967-a561-e0b674afbf66"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f3b445f4-e102-436a-b0d8-63735980e94a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f77354a8-77b0-433c-89ec-7b8cdd79a575"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f8569a9e-9d0d-4c62-842b-59c45743361e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f98c777d-3957-4084-b5cb-cebdf3f2149a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("fd8981db-b34e-4651-bae7-2cad402e71ce"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("021348bb-85c4-4576-9e38-700c7f168712"), new Guid("4a840774-3b7b-4d29-8011-e0d16c31d4ec"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("035d584f-5153-4cb4-b156-618ba69ed4ea"), new Guid("745ed6b0-5536-4ec4-b311-c1d00c239d84"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("09888231-7181-4b53-b8e1-8672db7343b6"), new Guid("11e689c4-8644-47dd-85fc-551793a99d71"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("105f689e-21c5-441e-a0d0-71c79d3b2b8b"), new Guid("1a3a86f5-9bc8-4c3c-a5a0-8d5d15638300"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("10df29cd-7930-4f6b-9761-4744672c2dcd"), new Guid("bdbd5f52-8760-4313-afc1-18af0206a962"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("11e2d26c-7468-4e36-811d-3e16c071f6ff"), new Guid("05e2f759-2237-49f7-aa36-e7bfb01068f8"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("12947a0b-b8ee-4aa4-b84f-ffe8eac2e675"), new Guid("fd8981db-b34e-4651-bae7-2cad402e71ce"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("12e3506a-9f78-45e5-8111-961279412de0"), new Guid("b82c8ab9-4d74-404e-a033-9f5ceeef546d"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1dda19c9-849e-4f39-bc4e-14461a0ae1e2"), new Guid("f98c777d-3957-4084-b5cb-cebdf3f2149a"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("201512f0-fa4a-4202-9e4e-e55528f23f91"), new Guid("58e9c175-b9ed-468a-990d-e0c29109e002"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("24cad5f1-d057-4a3d-81bc-17a91e9a2318"), new Guid("d56e9cd6-ae3f-464f-83d1-f7c6c05b660a"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("25fbfb79-0beb-4645-9287-447a7f12acb5"), new Guid("b18a5965-64bf-46c8-87b9-dd621a4d443a"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2825a428-c925-4904-a1dd-80b023fdb578"), new Guid("15c2a76b-ba6c-4a74-8ca9-1d3d4ddb3e55"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2db65a09-a5d6-452d-b104-6a0d8c563506"), new Guid("f021fc5f-bbc1-4967-a561-e0b674afbf66"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3235ba13-f554-477c-a4b5-89cbfacc22f0"), new Guid("53ed3adf-3f25-4548-a492-cad98f21c562"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3744e243-0d8d-4596-af04-77e20f77d470"), new Guid("176f205d-b19f-4c08-bcc8-873b23f65fd0"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("37c6c121-4fc3-44b3-a89f-f4233ac62006"), new Guid("962db82b-da8d-4ee2-9df7-fe80176bca35"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3862bd58-f89d-4003-988a-61e61f8196fe"), new Guid("8f31deb7-4456-48cf-aa48-8d41bc1aa917"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3af63192-931c-4953-811a-9524692f9847"), new Guid("2676fb65-09af-49b5-b183-5ba9b4bd1dd0"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3bba13ee-7c53-48b9-8a08-77e41cc05461"), new Guid("a7486daa-219e-4a13-8ce5-6922e84797dd"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3bd959f4-b7b8-4ccf-88a6-de59b3e03889"), new Guid("bf106332-8f51-4151-92a0-73873d056557"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3edd944a-3c14-4807-9cf0-dd0f2ad5a247"), new Guid("381562d6-bf15-41b1-a154-dcccf60c9f1c"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("408eaba4-c768-4f7a-9cd1-a39651854e4a"), new Guid("cbbc70c4-9638-43c5-8876-da053e58c76f"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("40c832cf-cabc-4443-b232-41ade6d008c5"), new Guid("81d9487e-eb8f-4683-be42-8f233ab65b87"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("417cd939-a212-459a-ba35-42123e6a85a8"), new Guid("ebfe5f1c-10d1-4f89-9d34-7fc1f94757e6"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("42c5c217-8faa-440c-8fc8-95f5a389262a"), new Guid("1c7768af-d14d-47f2-975a-491b80293d81"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("432bc361-6c46-4342-a3ff-c2bdd04cac48"), new Guid("88f8fade-ed8d-459f-98f8-6ce76d5d59a2"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("45099776-32b1-4613-89ec-6f7692b29d5b"), new Guid("34ec2e40-eeeb-44dc-984f-caf58b1fede4"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4569d40b-0aa4-4945-8f1f-4b0a776b7c29"), new Guid("c8b93ecb-0695-498b-97fd-37524e1b8a8f"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("46e45045-8137-4e19-bfc1-49efc7eeacb0"), new Guid("591b2dca-46c8-4941-a122-bdbed50d9dd8"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("48d6423b-b031-48c5-a921-91a69e13749c"), new Guid("6b457d7f-a9b3-4a60-9e5d-c1c59e5e86e7"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5066aa84-11f4-49b4-9298-20d7a565f16a"), new Guid("9d0ca6d2-fa95-4714-a41a-1cf9178147ff"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5409a39f-d7c2-4b88-9da6-575a59ec7d58"), new Guid("b26289c5-e52d-4fca-9ed4-6f2ffa671ac2"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5482848f-f4ba-41d4-95cb-286fc99616b7"), new Guid("8ab9002a-bbf1-4758-a88d-55f90a755d95"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5adf0f95-586f-4486-b969-7ceb6a7d8b06"), new Guid("8066ed71-2789-4ead-9b17-5fe8a58d6f5f"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("630e2036-9b88-4a9f-85d8-e9f8d1d625b6"), new Guid("bb9a5a81-0265-413d-aa14-9b5e8a7f052a"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6a3a03e8-7bc5-4469-99f7-a44fd60567ef"), new Guid("9a2db6e1-89fc-4dd5-be37-33a1f6b9f288"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6c6979fd-1e03-42ac-89cf-d0c8ac81267f"), new Guid("89c47b40-b6ec-4307-a130-e298698fcb3b"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6e163a2e-05c8-4c0e-b9a4-9aa08db55e3f"), new Guid("eb514aba-3a56-423f-8b17-2157e079d2f9"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("76df4084-5779-4e65-82b1-52b573a8f1e3"), new Guid("aa9be140-69dc-4bb7-8518-88a89cb95005"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("78eed580-497c-4994-b36d-d55e9d45b92d"), new Guid("ce9a62ea-e527-4f01-9e1c-931f971ba56b"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("7e8eed89-7842-4df5-ba35-b797fddf3048"), new Guid("ae4e899b-4957-4cae-82a6-c5a8a0d18f7e"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("81ec74a3-22e0-4c91-8ccf-f5149c6263e3"), new Guid("2bebb683-68d8-4f55-a205-fbf9c6a1269b"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8a2336d0-9f24-4a5d-8310-3c15fe9ce9be"), new Guid("c9c92615-3948-4b9e-964e-81975582c439"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8bf47c4f-947d-4ecb-b42e-fffc2408e360"), new Guid("8cc34500-93e6-48eb-b2bb-42539f1dce2b"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8d7ff1e5-5ec6-4dc4-a2e9-2d3769783178"), new Guid("9c830ec1-6ee8-41d8-a98a-98d3c95f53d1"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8fc5c6d1-91e5-4331-9e50-4c9698d84f1a"), new Guid("010f3896-1557-405f-bd1c-b929fabc6e66"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("964afb49-c2d2-4649-b50f-39e2658109dd"), new Guid("1bc16eba-fdf2-4b25-8744-b29a27071f0d"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9a20b4b3-2c16-4431-9806-7c2b2b5fbfdd"), new Guid("5e8af8c9-5e96-486e-af41-8a0fab35b032"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9a35f3df-d8fd-48ee-a572-4b588085ed27"), new Guid("5315bdbf-6325-4db7-b56d-e7bd1a8d1818"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9cbb7780-a67a-417b-819a-a213524a081b"), new Guid("8bd30f0d-64ea-4f23-b4e5-abf59fc71216"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9f107e5b-9cfd-43e7-9ea3-a4dd6c6d0036"), new Guid("7b74647a-9d4f-4675-8ee7-ba86b479aafd"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("aa24dffa-5498-4fea-a090-96cfd9957e68"), new Guid("6936069c-bb73-48c8-9611-9778d266c6fa"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b05a3d71-e2c6-4cad-9777-c2a35d12a511"), new Guid("0d9fd956-1c89-40d4-b6a2-3ad8769fc513"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b4ce3401-0d55-4704-83cb-d72004332471"), new Guid("1a3c7d7b-d18c-4cec-8650-392889080fc4"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b818ced5-08e5-44d0-845c-9313f5d247a0"), new Guid("203c9a6d-c048-40d7-8461-9270f7e70d8b"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ba58baa3-25a0-4036-960f-46e5e1fa4ece"), new Guid("cd6f66c9-60e9-400a-bc36-cbf50388402e"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c11ee388-e985-4064-8c78-394616111a32"), new Guid("aa477617-e725-49da-aa40-94829905d887"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c270beea-dff3-4342-ae4b-34d4f9a61dd0"), new Guid("f3b445f4-e102-436a-b0d8-63735980e94a"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c39a255f-b68c-4fe8-990a-920f6fbaa5a8"), new Guid("f8569a9e-9d0d-4c62-842b-59c45743361e"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c46ec817-bb06-4c74-9821-5a7da2f93a0d"), new Guid("4dc07e68-827a-4f29-aa10-1d9574950de5"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c9b794fa-7ece-4684-9cec-070b39f8180f"), new Guid("0099bd9c-3719-402c-b626-c5c48355aecd"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("cb60a8f7-2741-4253-9fde-5b7946c4e136"), new Guid("8d7f4031-bfd4-4a1d-b1cd-fec40d136b58"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("cccfd829-e3af-4c50-8834-45d4d41265e6"), new Guid("7d8ee1b6-6cde-4600-9f81-4910629f5426"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ce28d2e4-7a84-4a6c-808c-8bf7b20f9716"), new Guid("3c24fe8e-5c9a-495d-9eab-fa18f49151dc"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ce2f68ba-24fc-44a1-8549-a9cbc5144040"), new Guid("38705535-c98b-4a77-94b2-5b301bd85f69"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("dad65063-3d8b-4a4b-9b3c-0fce5a7f6780"), new Guid("b8e41166-032c-484c-902a-46ceb40fb7bb"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e1741054-5897-4b23-92f3-3dabd38f24f3"), new Guid("1681d05c-4ad7-447e-879e-585bbc30e72c"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e34e4764-d820-45bb-a1e7-74e1a0c87b42"), new Guid("ab21d0d8-2d64-4a38-8316-c3dc00f8bf28"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e402ea6e-4919-406c-b5dc-f29aeff9841b"), new Guid("8f098808-9d04-46c6-ad8f-1b74e81e509d"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e96a802e-86fc-402e-91de-4845cdcf5008"), new Guid("34de17f8-469f-4ff0-bcb6-f8b6d32f21e1"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e9843228-bd93-4bb2-b3e8-493884c5798a"), new Guid("5235b92f-dd34-4786-95c1-ac614cee2901"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e993b4e3-9bbf-49c9-8575-e03344db70a3"), new Guid("62b569a3-9a32-48a9-90d8-b86e2287d5ab"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("effa541c-eada-457d-8a77-1d16b8d3ef46"), new Guid("f77354a8-77b0-433c-89ec-7b8cdd79a575"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f029d121-c67b-46f2-812b-563f9812632b"), new Guid("5407ee45-fa3e-4350-92a8-683a881104ec"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f1af71fa-8447-4edb-b118-dffc8c5c1053"), new Guid("cf38f7ee-fc40-406c-b9fb-1ef447089518"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f2f7a87e-c78e-4f67-b9f1-f301b9625079"), new Guid("2c846445-8eef-40b1-b1d6-cbfdf8e639df"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f397c340-5dec-430a-80ce-c8a65ebaffa2"), new Guid("47b932a5-42f3-47b0-9563-9fa450de5b45"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f3d0d99b-b89b-4e98-a7c9-3677dca2d1e6"), new Guid("70115302-908f-4a34-88c1-97a0879b4cea"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f47a925b-b4e0-4494-ae5d-778273c2f69b"), new Guid("d19ba105-1fd9-48f8-afc2-1bf7cf8a5466"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fa21a303-2b82-4f70-977d-f7f6f86eb647"), new Guid("3287f05e-5839-4c4b-8a16-d881562babb6"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fa243440-b85f-418c-a0bc-f7d5eefb4b6c"), new Guid("144c26f8-c510-4182-911a-cfaf335c3982"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fd650559-6bea-45ef-9163-1211f8a32a40"), new Guid("3cefa271-bd00-4d53-ac28-eb09ca985771"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ff3f8fb8-4089-42c7-acfa-0606ff50e47c"), new Guid("eb2ccaa1-d170-42ba-a551-6162cbaf9b2e"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("049e448b-f6e9-4b81-8075-15520569552a"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("e34e4764-d820-45bb-a1e7-74e1a0c87b42"), 1, "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0cc73291-2e5e-4ab2-86fd-a112e7752862"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("3744e243-0d8d-4596-af04-77e20f77d470"), 1, "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0ce9f6f4-d55c-45f3-8386-43199e33d58b"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("630e2036-9b88-4a9f-85d8-e9f8d1d625b6"), 2, "Device3_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0d87a0b4-9124-4928-838c-86e7f43f4166"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("12e3506a-9f78-45e5-8111-961279412de0"), 8, "Device2_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0e37d3ab-543c-4d43-b1f8-d424e9adc9f4"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("2825a428-c925-4904-a1dd-80b023fdb578"), 9, "Device1_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0f013373-eaeb-4b1b-ae2a-838a6bfb081b"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("6e163a2e-05c8-4c0e-b9a4-9aa08db55e3f"), 3, "Device2_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("123ca1a0-ca95-440b-b3e5-239265d04fb4"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("76df4084-5779-4e65-82b1-52b573a8f1e3"), 9, "Device3_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("130ab57c-d713-4621-a4a0-98e7a4a38ca8"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("7e8eed89-7842-4df5-ba35-b797fddf3048"), 1, "Device1_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("132ae19c-00cc-4ae3-bad7-6781fab1922e"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("e402ea6e-4919-406c-b5dc-f29aeff9841b"), 1, "Device2_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("13673497-7513-40fe-ad34-2905f5d864b1"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("c9b794fa-7ece-4684-9cec-070b39f8180f"), 2, "Device2_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("157f7094-b174-436d-96d8-df9636d11de9"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("e9843228-bd93-4bb2-b3e8-493884c5798a"), 9, "Device2_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1a3824e8-f97b-479d-b62f-2272e74ef1e8"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("b05a3d71-e2c6-4cad-9777-c2a35d12a511"), 9, "Device2_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1a852e0f-179f-4299-9ecd-eed256dddfb4"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("42c5c217-8faa-440c-8fc8-95f5a389262a"), 1, "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1d053317-c9ba-4caa-af44-f4a5a39b5568"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("105f689e-21c5-441e-a0d0-71c79d3b2b8b"), 9, "Device1_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1d1078b4-5ba2-4480-bc8d-c6c659b58548"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("e96a802e-86fc-402e-91de-4845cdcf5008"), 1, "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1d78a1e5-95eb-41ad-a09c-0dbb374c3573"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("5409a39f-d7c2-4b88-9da6-575a59ec7d58"), 1, "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1dd3bebc-26a8-4b11-9744-54a951962c02"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("035d584f-5153-4cb4-b156-618ba69ed4ea"), 1, "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1f510181-aefb-4638-b93b-74cc552776c9"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("fa21a303-2b82-4f70-977d-f7f6f86eb647"), 8, "Device1_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("202ce7f8-bd9e-4bac-a0be-710e236f98f7"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("9a35f3df-d8fd-48ee-a572-4b588085ed27"), 9, "Device2_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("2b3c62d2-e88b-43a1-b7fb-c69a78f8436c"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("40c832cf-cabc-4443-b232-41ade6d008c5"), 1, "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("2e75f8f8-9633-413c-bcae-d35ddbff9689"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("10df29cd-7930-4f6b-9761-4744672c2dcd"), 9, "Device1_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("32c3e788-c978-4f57-8e84-bbd91eec31e4"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("ff3f8fb8-4089-42c7-acfa-0606ff50e47c"), 1, "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("377f369c-fce4-46cd-9681-10f58f9a6c27"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("fa243440-b85f-418c-a0bc-f7d5eefb4b6c"), 9, "Device2_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3b035efe-7467-44cb-829f-6ef28fe186f3"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("78eed580-497c-4994-b36d-d55e9d45b92d"), 8, "Device1_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("40ce942a-f987-4feb-ab34-f367c5ac3a6e"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("8a2336d0-9f24-4a5d-8310-3c15fe9ce9be"), 1, "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4349aab7-3ff6-48d1-9d45-76f79e395ae4"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("cccfd829-e3af-4c50-8834-45d4d41265e6"), 4, "Device2_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("462c71e8-039e-477c-a703-7d4e9d33603f"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("f47a925b-b4e0-4494-ae5d-778273c2f69b"), 1, "Device1_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4b5f3c59-1e2a-49b2-86fd-70b4a5324ad7"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("e1741054-5897-4b23-92f3-3dabd38f24f3"), 2, "Device1_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4d7f2981-3bef-4882-a568-05c6d6899b92"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("09888231-7181-4b53-b8e1-8672db7343b6"), 1, "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("513b0f6c-275a-4020-930c-b7d7df55edf8"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("b818ced5-08e5-44d0-845c-9313f5d247a0"), 3, "Device1_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("59f96606-c479-40c9-950b-f886eed30e90"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("fd650559-6bea-45ef-9163-1211f8a32a40"), 3, "Device3_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5a12b503-2b20-4072-b0a3-5b9b06ed53ed"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("6a3a03e8-7bc5-4469-99f7-a44fd60567ef"), 1, "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5a2a0ab4-2575-4b23-8a9c-9b5a33f63219"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("c39a255f-b68c-4fe8-990a-920f6fbaa5a8"), 1, "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("607599e9-06be-44ca-a76e-e873b6f4dbb1"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("2db65a09-a5d6-452d-b104-6a0d8c563506"), 3, "Device1_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("63011a9b-34ba-4a4e-a95c-165f1b5818e4"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("c46ec817-bb06-4c74-9821-5a7da2f93a0d"), 9, "Device2_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6508bb62-d92d-43c2-afff-3515b956300c"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("81ec74a3-22e0-4c91-8ccf-f5149c6263e3"), 8, "Device2_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("67732d61-111f-49d8-85a8-204d77e025f3"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("9a20b4b3-2c16-4431-9806-7c2b2b5fbfdd"), 1, "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6dbbff4a-bf7f-4b76-9e9c-086242638cc7"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("ce28d2e4-7a84-4a6c-808c-8bf7b20f9716"), 8, "Device3_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6dfecd49-4da7-4a7b-b3f1-e5a63833dc51"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("9f107e5b-9cfd-43e7-9ea3-a4dd6c6d0036"), 8, "Device3_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("7ab67884-0482-498b-93c6-9c42f25f7a0b"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("6c6979fd-1e03-42ac-89cf-d0c8ac81267f"), 9, "Device1_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8074c60d-f348-4df7-8694-69b6a802aa97"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("4569d40b-0aa4-4945-8f1f-4b0a776b7c29"), 1, "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("80f53def-2a26-4086-adcc-0f63eac49477"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("12947a0b-b8ee-4aa4-b84f-ffe8eac2e675"), 2, "Device1_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8109b636-066b-4b52-9aa8-69c73ca38d98"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("417cd939-a212-459a-ba35-42123e6a85a8"), 2, "Device3_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("85bb4f34-ec0b-4fca-942d-8f3a811a572c"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("3bba13ee-7c53-48b9-8a08-77e41cc05461"), 9, "Device1_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("877e6aee-ef53-4c45-8914-d69c628d9894"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("e993b4e3-9bbf-49c9-8575-e03344db70a3"), 1, "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("87be44f9-9019-4d4e-a021-de41b93c412d"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("3862bd58-f89d-4003-988a-61e61f8196fe"), 2, "Device3_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8f9ab042-d52f-4145-9e6a-cc9e6d95cd17"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("5066aa84-11f4-49b4-9298-20d7a565f16a"), 1, "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("934fee69-a2f0-4ffc-b53e-81452c4de127"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("45099776-32b1-4613-89ec-6f7692b29d5b"), 8, "Device1_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("93c676de-2b34-4e3c-ac46-1bf66ad82d14"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("ba58baa3-25a0-4036-960f-46e5e1fa4ece"), 4, "Device1_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("963b2d6e-f9ff-46f2-a670-4d515fbbda72"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("f1af71fa-8447-4edb-b118-dffc8c5c1053"), 1, "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9bbbc07b-1034-4bc2-8d65-6842ed2edc5c"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("f397c340-5dec-430a-80ce-c8a65ebaffa2"), 8, "Device3_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a8072178-6543-4fe6-b53a-416088434cd9"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("ce2f68ba-24fc-44a1-8549-a9cbc5144040"), 1, "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a8644a97-a541-4c66-a59f-3ac52b2f48ed"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("b4ce3401-0d55-4704-83cb-d72004332471"), 2, "Device2_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ad634707-cb05-4090-b6d1-d0290297742e"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("964afb49-c2d2-4649-b50f-39e2658109dd"), 8, "Device1_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ae3f3019-abaf-4f95-8fc6-6bbce965bd6b"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("dad65063-3d8b-4a4b-9b3c-0fce5a7f6780"), 1, "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b04f3901-bf73-4e26-b415-cd23f91d96ba"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("25fbfb79-0beb-4645-9287-447a7f12acb5"), 1, "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b2b5792e-2c39-4827-b87d-a0f1efff98c1"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("c11ee388-e985-4064-8c78-394616111a32"), 3, "Device3_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b3af086b-68f7-48f9-a20c-2a16c3d5d226"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("37c6c121-4fc3-44b3-a89f-f4233ac62006"), 9, "Device3_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b8532389-ce37-4ba8-942f-73ad94e76231"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("432bc361-6c46-4342-a3ff-c2bdd04cac48"), 9, "Device1_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b8834187-7071-4d5c-bbce-154e97e2f3e6"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("48d6423b-b031-48c5-a921-91a69e13749c"), 9, "Device3_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("bb39e820-9810-4f78-9249-bb54258223e0"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("201512f0-fa4a-4202-9e4e-e55528f23f91"), 1, "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("bca6411b-2bd9-4934-84c5-ade7858503b3"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("f3d0d99b-b89b-4e98-a7c9-3677dca2d1e6"), 9, "Device2_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c4910704-c876-44f7-8657-43043109102d"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("5adf0f95-586f-4486-b969-7ceb6a7d8b06"), 1, "Device2_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c946c6e1-f5ec-427d-a6dd-fcaffaad50dd"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("24cad5f1-d057-4a3d-81bc-17a91e9a2318"), 1, "Device2_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cacf094f-e2fc-4aaf-b4ed-f3249fad8e11"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("1dda19c9-849e-4f39-bc4e-14461a0ae1e2"), 9, "Device3_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cc0978c2-1b8c-46fb-a74d-2a7970583157"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("8bf47c4f-947d-4ecb-b42e-fffc2408e360"), 4, "Device3_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cd56b7ac-48e2-4f92-9987-35d972b46178"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("f2f7a87e-c78e-4f67-b9f1-f301b9625079"), 9, "Device3_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d74555f7-6005-4922-a8fd-c4f7c38c2b1d"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("9cbb7780-a67a-417b-819a-a213524a081b"), 2, "Device2_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("da15fdb1-659f-439b-a847-cf4891028485"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("3edd944a-3c14-4807-9cf0-dd0f2ad5a247"), 1, "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("dcc2737f-73f2-4e38-b1e5-52817ae47298"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("408eaba4-c768-4f7a-9cd1-a39651854e4a"), 1, "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("deb215e1-9c5f-40bb-9d62-7234717b9b88"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("3235ba13-f554-477c-a4b5-89cbfacc22f0"), 3, "Device2_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("def45010-6626-4ba7-9642-2affb33bcbae"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("8d7ff1e5-5ec6-4dc4-a2e9-2d3769783178"), 1, "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("dfde3203-b0ce-49a4-97ac-207ec1597d59"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("46e45045-8137-4e19-bfc1-49efc7eeacb0"), 1, "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("dff7a178-e863-4f98-8b52-56f46f82f28f"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("3af63192-931c-4953-811a-9524692f9847"), 3, "Device3_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e6cddba7-5b7f-4267-be92-1e46f62eddd3"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("aa24dffa-5498-4fea-a090-96cfd9957e68"), 1, "Device3_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e744b3a3-52ff-4ae6-9fd4-76266837297b"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("5482848f-f4ba-41d4-95cb-286fc99616b7"), 3, "Device2_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ec93c17f-9a23-48ee-a97f-f2671a4e1a5c"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("cb60a8f7-2741-4253-9fde-5b7946c4e136"), 8, "Device3_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("eff642d9-5b29-488b-b5b8-190d7afcc6ce"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("021348bb-85c4-4576-9e38-700c7f168712"), 3, "Device1_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f2591cf1-4845-4901-be46-ec84f2234847"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("effa541c-eada-457d-8a77-1d16b8d3ef46"), 1, "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f65ea768-2013-40e3-b0ee-4e1ccad3fe9a"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("3bd959f4-b7b8-4ccf-88a6-de59b3e03889"), 8, "Device2_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("fa1f0994-b095-41f4-96d5-b06835e35417"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("c270beea-dff3-4342-ae4b-34d4f9a61dd0"), 9, "Device3_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("fb864cbc-8e7c-48e4-8c22-a920e8d99294"), new Guid("781e29f9-47bb-4067-845c-7b370eaf6d47"), new Guid("8fc5c6d1-91e5-4331-9e50-4c9698d84f1a"), 1, "Device3_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("fe49e267-1004-4110-a2ca-73211a633f6e"), new Guid("d5fe2322-0e2a-47a5-83b8-83b1f8dd0595"), new Guid("11e2d26c-7468-4e36-811d-3e16c071f6ff"), 2, "Device1_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("fe763930-ffc3-4268-bfe7-e864c47b37bf"), new Guid("a8c4f5cf-72d9-404b-a82a-4d127e138612"), new Guid("f029d121-c67b-46f2-812b-563f9812632b"), 8, "Device2_HeightCut" });

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
