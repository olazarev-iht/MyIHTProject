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
                values: new object[] { new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("05638997-6a4a-479c-b700-68bfcaf18892"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0be65824-c49c-491d-92c4-ba267ff6fc23"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1f3329a6-8737-4b99-9213-8b835d3325aa"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2114653a-d33e-4af0-8967-894d3c2ec318"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2c5c86ef-ec34-4780-b3cd-2b8ed9300bd3"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2ee575ad-5cfe-4bbb-abf1-f19a184ddffe"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("38b6095f-2336-496e-99fb-aa046d3fa9b6"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4165a408-2f9b-495a-9dc7-914678ef7e55"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4d99581c-5963-43fa-9b31-053ac74a1e38"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6c689014-f5eb-4ff5-9b60-29803ab45c23"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("734c9d13-02d0-41af-be0e-39d52315ced3"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("83351af8-96d9-4e42-aa4e-287edf375e88"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("897f59ef-effa-49f1-b461-33d90be610f5"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8ab3af88-03c9-469e-9de6-d4c2108dfe7d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("95c3c24a-c652-4655-b9f9-015b4167aaaa"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a04d178c-5cc7-4c54-b0cd-7671a7be03a3"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a6e5bccd-b6de-41b7-a5fb-a1b8bfa5815f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a7b54bae-d9a2-4058-9a5c-5862ffa4522b"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bace22bf-74ee-4a21-9eaa-f5164a63fa2f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bbdb3bdb-fb02-4aa3-837d-49e43b185bec"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c3a5db6a-981b-4038-bd56-c30abccc32f7"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c7bb414f-c75e-4af3-b25c-4ccbb3883fc9"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c8884f45-14b4-469d-b65f-e980bc1b301d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cb0e3c1f-924d-47cb-82e6-fd791c714e7e"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d1e48584-8ec2-4271-9bb9-b839065b0e9b"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d3d0df5d-d888-4cd4-a31b-cf1da813d085"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("df10ccb1-3393-4bb2-8b83-6fa719537de6"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e4a87cb0-21af-4ed5-89fd-3946c5589cf6"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e93a1f12-eb6c-4b73-b5c6-17516e80f56a"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ffd80daf-bf7b-4e31-be10-f4758669d1f6"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("071b8fc5-0685-4f1e-b115-7111f4bdd123"), new Guid("734c9d13-02d0-41af-be0e-39d52315ced3"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("11bbded8-2af1-446e-8d3e-a5176dc8940e"), new Guid("df10ccb1-3393-4bb2-8b83-6fa719537de6"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2825d4ce-1b5b-45a8-bbc1-3ebb187ced3d"), new Guid("83351af8-96d9-4e42-aa4e-287edf375e88"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2ba8691a-470b-485a-a9ce-4b1110319284"), new Guid("ffd80daf-bf7b-4e31-be10-f4758669d1f6"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("41048045-21a6-4716-8f0b-bb06b8576fb0"), new Guid("2ee575ad-5cfe-4bbb-abf1-f19a184ddffe"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("41087314-d54f-451d-9db1-ac398a0bcc3d"), new Guid("38b6095f-2336-496e-99fb-aa046d3fa9b6"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("555773d5-ad08-4f69-8aa6-144246a27b7e"), new Guid("8ab3af88-03c9-469e-9de6-d4c2108dfe7d"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("55ad7f74-b073-4486-8626-50c21280cbef"), new Guid("a6e5bccd-b6de-41b7-a5fb-a1b8bfa5815f"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5d93d009-d1f9-4225-8954-c8862fad48d8"), new Guid("a04d178c-5cc7-4c54-b0cd-7671a7be03a3"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("64f632f2-a1c9-4f36-8223-c400beeecaaf"), new Guid("c3a5db6a-981b-4038-bd56-c30abccc32f7"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6b387293-f29e-4d3d-a09d-ea47fc80fcb9"), new Guid("05638997-6a4a-479c-b700-68bfcaf18892"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("838d37e0-65aa-4d9e-9522-4e8cda89eb64"), new Guid("cb0e3c1f-924d-47cb-82e6-fd791c714e7e"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8b98b54d-a48b-4c18-a632-84b7b48930b0"), new Guid("bace22bf-74ee-4a21-9eaa-f5164a63fa2f"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("980479ff-6fe1-4af4-a565-9fdf22ddecc9"), new Guid("2c5c86ef-ec34-4780-b3cd-2b8ed9300bd3"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a89e95c6-a65d-4467-897a-aa89a227c23a"), new Guid("d3d0df5d-d888-4cd4-a31b-cf1da813d085"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a957ba4b-5ce1-4deb-ba66-34597c14b9f8"), new Guid("bbdb3bdb-fb02-4aa3-837d-49e43b185bec"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("aec4fba4-594f-4250-aa9a-dbf7df3cf84d"), new Guid("95c3c24a-c652-4655-b9f9-015b4167aaaa"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("aeed17c8-1a4d-442d-b5f0-5862033c191d"), new Guid("c7bb414f-c75e-4af3-b25c-4ccbb3883fc9"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b54159e0-cc52-4f93-950b-39e1b25b9876"), new Guid("897f59ef-effa-49f1-b461-33d90be610f5"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bfa9cd27-9d13-4527-81a9-70433ebb4a26"), new Guid("1f3329a6-8737-4b99-9213-8b835d3325aa"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c0ad4a76-f5c7-4800-869b-614d943bae4b"), new Guid("4d99581c-5963-43fa-9b31-053ac74a1e38"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ccccadcd-ab4b-455d-b617-d81d66ec3f67"), new Guid("e93a1f12-eb6c-4b73-b5c6-17516e80f56a"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ceb35341-afb3-4d6b-84e7-8eef8385317a"), new Guid("0be65824-c49c-491d-92c4-ba267ff6fc23"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("cf1d0a44-5113-44ee-8aeb-7362c858e14a"), new Guid("a7b54bae-d9a2-4058-9a5c-5862ffa4522b"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d3ca04d4-0de0-4d19-b457-2a56ee530311"), new Guid("6c689014-f5eb-4ff5-9b60-29803ab45c23"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("da5cc717-8e7b-406f-a1b3-563134496754"), new Guid("e4a87cb0-21af-4ed5-89fd-3946c5589cf6"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("de91886d-6282-4b69-a277-5b19ab154327"), new Guid("4165a408-2f9b-495a-9dc7-914678ef7e55"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e719756c-e021-42d2-a288-ea92ca837f6f"), new Guid("c8884f45-14b4-469d-b65f-e980bc1b301d"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f2eab00d-03a4-4251-bd47-a582fb16d77f"), new Guid("d1e48584-8ec2-4271-9bb9-b839065b0e9b"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f82d0ca8-fc83-4fdc-bff1-679fe8dd08af"), new Guid("2114653a-d33e-4af0-8967-894d3c2ec318"), 10, 200 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("0348419b-97ab-4d04-ab04-270cf98d4f78"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("aec4fba4-594f-4250-aa9a-dbf7df3cf84d"), "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("062d87d6-abbf-47fe-be59-e18cf85e2ac7"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("a89e95c6-a65d-4467-897a-aa89a227c23a"), "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("0896e1ad-eb97-495c-9e23-31fac38338ae"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("2ba8691a-470b-485a-a9ce-4b1110319284"), "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("0f6c936e-95ca-441e-aca8-cbf61edac47e"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("64f632f2-a1c9-4f36-8223-c400beeecaaf"), "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("1ad303a0-5f5e-4eb5-a61a-9a7e4327219a"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("071b8fc5-0685-4f1e-b115-7111f4bdd123"), "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("436b8f76-2c13-4c86-b88c-9f56ad04cb88"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("41087314-d54f-451d-9db1-ac398a0bcc3d"), "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("47690af8-a850-4e98-8aa6-6d02cc4ff4a2"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("de91886d-6282-4b69-a277-5b19ab154327"), "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("5771a89a-6ad5-49b3-86f1-54a2de5d126a"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("b54159e0-cc52-4f93-950b-39e1b25b9876"), "Device3_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("5c9c4d19-db3c-4b38-8bbb-f2cc3704b854"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("cf1d0a44-5113-44ee-8aeb-7362c858e14a"), "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("632bb5f9-83af-4540-8554-ffc57670a37c"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("55ad7f74-b073-4486-8626-50c21280cbef"), "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("63a7fad2-0ca7-41f3-89f2-d39d2753b07c"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("2825d4ce-1b5b-45a8-bbc1-3ebb187ced3d"), "Device2_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("70819535-94e3-4674-807b-27dab04c8750"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("838d37e0-65aa-4d9e-9522-4e8cda89eb64"), "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("74ff28f5-a1dc-4d80-93d1-84ac46468085"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("6b387293-f29e-4d3d-a09d-ea47fc80fcb9"), "Device1_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("7b532663-d537-47c2-b463-5a5924de7221"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("ccccadcd-ab4b-455d-b617-d81d66ec3f67"), "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("7b736df4-c63a-447e-96be-ccc57e73d469"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("555773d5-ad08-4f69-8aa6-144246a27b7e"), "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("8890c57c-3bb6-4fd7-9ae3-0c86b3daf276"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("aeed17c8-1a4d-442d-b5f0-5862033c191d"), "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("8bbc8bca-f271-4063-9c37-306820696c1d"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("980479ff-6fe1-4af4-a565-9fdf22ddecc9"), "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("8d6462d1-6520-471a-ab2c-21efdee20710"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("e719756c-e021-42d2-a288-ea92ca837f6f"), "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("999cd36e-34a2-46d2-8d97-34ddba8aa1a0"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("c0ad4a76-f5c7-4800-869b-614d943bae4b"), "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("a6594eed-7f11-4c56-830c-54364a030fba"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("f82d0ca8-fc83-4fdc-bff1-679fe8dd08af"), "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("a71aca2d-7b8f-49f6-8452-de40611bd1d8"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("da5cc717-8e7b-406f-a1b3-563134496754"), "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("aaa2fd9a-6270-4bfd-b253-0471b5bc1926"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("d3ca04d4-0de0-4d19-b457-2a56ee530311"), "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("b772226f-7556-4229-a49b-14854139381d"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("a957ba4b-5ce1-4deb-ba66-34597c14b9f8"), "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("b97a844c-e975-443f-abe8-3e755291405d"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("5d93d009-d1f9-4225-8954-c8862fad48d8"), "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("bf04516f-2fc6-46f1-8605-8c4384d1c11c"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("f2eab00d-03a4-4251-bd47-a582fb16d77f"), "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("c370f21c-80f0-4099-944c-6e5faa95359f"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("8b98b54d-a48b-4c18-a632-84b7b48930b0"), "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("ca3d7c69-6682-4c99-9ffb-40d3da62d12b"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("41048045-21a6-4716-8f0b-bb06b8576fb0"), "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("d259ce56-dcea-4c81-832a-b463a098d4a5"), new Guid("fe67c069-534a-4896-a021-9b1279d740b6"), new Guid("ceb35341-afb3-4d6b-84e7-8eef8385317a"), "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("e47c05e3-cb4a-4311-aac9-032dde0cefac"), new Guid("8eed3876-5034-4ed0-b1dd-5ca9128c492c"), new Guid("11bbded8-2af1-446e-8d3e-a5176dc8940e"), "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamName" },
                values: new object[] { new Guid("fbf513d0-320c-4cb2-ab53-fef16c4fdbcb"), new Guid("c13121b4-9d76-48f8-80c7-b93ca268ed87"), new Guid("bfa9cd27-9d13-4527-81a9-70433ebb4a26"), "Device2_CutO2Cut" });

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
