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
                values: new object[] { new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), "System", 0 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("01037183-d84e-4c57-b60c-5ee378162bd2"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("04b0ba3b-c8df-48f3-91fb-5e3654dee29f"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("07d50358-35cf-4de9-a1d4-dca21d605516"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0c5cff4b-99e2-4e82-82e5-f543762b5dd7"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0e7c7471-e903-4444-a85d-f8a047af9540"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("12f39af7-12bb-4983-a2fc-2a968c92ccc2"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("16f4a8dd-0b4d-4cdb-b6e2-f4c8ccd27d26"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("17a10e66-7050-402d-a651-1aa9e420294d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1ddcd4ab-46f7-44e7-91ad-566a7c98cf24"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2470a24b-1aac-4cd5-9fb1-65ef527c0a80"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("268a199a-fa99-4619-b402-71f66910f6c7"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2cd2b33a-61fe-4f8e-b10c-109676c43f87"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2d6d66ee-fbb8-4cb1-a675-7bdbe10be6bb"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2d7343f9-f87c-410b-ba30-44466feda2b9"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2f3ad69c-a671-400a-ad89-159a14ec0c84"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("302cf3ef-80a2-43c9-8d3a-51a478cdf56b"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("309fe732-860a-4925-9670-b5f5f7fb5284"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("30da327a-fa2e-4260-b11d-b1a4dd3c4159"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("35414ce4-a6a9-4060-88db-bddae8c469e4"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("35f2efb1-5acd-44b9-89f9-a38e6e856092"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3a48d048-7938-424c-8fe7-5f4734caecbd"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3a6ae67c-b76a-431a-9061-1e96d2ad638a"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3b7175ff-31c7-4ca2-b509-645070233e18"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3bb95b53-b00d-4b9d-8807-236190e22e89"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4842636d-9300-493b-ac34-f341dc09d304"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("55549187-b601-4665-92ab-1e05f1e8621e"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5735908b-65f9-4097-ad39-d9a867f19aa6"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("595293ca-26b6-40bd-8508-9c13e1e86f1c"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("61e0bf05-4084-40cb-a765-104a782d3964"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("629e3d4b-6c02-4ece-a418-8055c7af3779"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6b742bf2-08a2-4255-bcbc-457ed4194ad1"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6d8a5a95-dc09-4d95-a933-2348e1e0b83a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("736b62ce-64cf-4bc0-838a-c557e40d468a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("796adf0a-b85a-4be7-b9e2-f76c604d0d99"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("79b018cb-0054-4c6c-b0a2-c17da6455fa4"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7e86f23c-6599-47da-99f3-4d2cb8ed87df"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("803d501f-9fbc-41cf-80a1-a34f57a88cb3"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("81af64d9-39d9-4df3-ace6-91a2cd16196a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("82dc7cb2-b0db-4c6f-bab5-ebe038911829"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("850853d4-b12a-4bb5-980e-3d45a14dc574"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("85779ea2-05f8-4198-9899-4cfe05a302b9"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("857b3f33-16a8-4fcf-9eb6-9da25ddb406b"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("87e93ce2-20a3-43d1-aa9f-d6747efc2079"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9511c7da-4d6d-406f-bee3-3ae0e41adbb4"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("998ecc3b-ed42-4f24-846a-508fbd052400"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9eab57d7-8775-457b-90b5-b57457b802df"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a0eb2dc1-51cf-4948-ba6c-227535dce9b2"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a8715119-26b9-4e48-a14f-40ce49ccffc8"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a8840ccb-28da-4a84-ba50-d46e529dc760"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b9d0fb6d-8e6f-4f35-81f6-809df2182688"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bbfb513a-3223-4c26-8633-e624c40c25f4"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bf2dfb8b-38cf-4c24-9f7d-8bc22b396f93"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c31813f0-670f-410d-ab5e-d52b8c2063ee"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ca08e9c2-da79-4124-9cce-3d2675462a18"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ce0895c1-7a59-4c27-872d-0d006a11f2aa"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("dd3e6832-b422-47af-b43d-e3257213b4e4"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e7233157-65f7-4435-8bab-846900de6181"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e7d7d91b-efeb-4b46-9ab7-2754c9a0cca3"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e95d60a0-f5bd-43f2-96bb-71c176942503"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ec5268b5-f45f-48c8-b6ed-d38f5393e889"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("edcc944c-50cc-473d-8f04-c6adad734b2c"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f1fda7ed-16ea-42bd-aa31-bbdb0f2af6c1"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("fb90317a-4dbc-4dc7-80af-46716e34a2d0"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("fc836be1-dc04-4a02-b51d-12ec6aa9b4f0"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("fdb346c8-c24e-4806-baa4-d67c974e6687"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ffee8877-7552-403a-83a4-269df0bc992e"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("006d7287-6eac-416a-b736-98043f4c9c42"), new Guid("01037183-d84e-4c57-b60c-5ee378162bd2"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("05d06dd5-9c03-43e5-b9ac-c99baa414058"), new Guid("ec5268b5-f45f-48c8-b6ed-d38f5393e889"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0736800c-d2aa-41d6-9c69-af21b1d666e1"), new Guid("2cd2b33a-61fe-4f8e-b10c-109676c43f87"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("07431172-2134-443d-a786-371c02c93d62"), new Guid("fc836be1-dc04-4a02-b51d-12ec6aa9b4f0"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0aacca5b-bb83-4947-9571-947e2ef9f70f"), new Guid("7e86f23c-6599-47da-99f3-4d2cb8ed87df"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("15b23a1b-0b77-4071-86fb-d95e96db1497"), new Guid("87e93ce2-20a3-43d1-aa9f-d6747efc2079"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1687d4c8-c968-4177-a2f5-c98e375b2239"), new Guid("ca08e9c2-da79-4124-9cce-3d2675462a18"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1773e2be-3151-4fb3-bfde-176e3ef750cb"), new Guid("17a10e66-7050-402d-a651-1aa9e420294d"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1eb8908a-1968-4f7a-8904-fd683da0961a"), new Guid("4842636d-9300-493b-ac34-f341dc09d304"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("1fcf6d0a-5651-4daa-9b13-5c8c4bf9d12b"), new Guid("0c5cff4b-99e2-4e82-82e5-f543762b5dd7"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2b71293d-d4a6-4df0-88aa-5c7d02a2790a"), new Guid("850853d4-b12a-4bb5-980e-3d45a14dc574"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2f9c2b2b-3858-4523-b90e-248ea8a1db0d"), new Guid("61e0bf05-4084-40cb-a765-104a782d3964"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3095b08c-0fb9-4177-a511-77d842412710"), new Guid("55549187-b601-4665-92ab-1e05f1e8621e"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("32e1f3e0-b804-4c21-99f7-82f39c580417"), new Guid("bbfb513a-3223-4c26-8633-e624c40c25f4"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("36517e32-d592-4c96-a4d9-49c52da819fc"), new Guid("9eab57d7-8775-457b-90b5-b57457b802df"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("37425a3a-0fcf-41af-8584-88eb5d720629"), new Guid("0e7c7471-e903-4444-a85d-f8a047af9540"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3bb4d636-9373-4584-8a30-65b1f7044099"), new Guid("a8715119-26b9-4e48-a14f-40ce49ccffc8"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3bf5ea1a-4aeb-482a-8c8f-7aa4ffe0729b"), new Guid("595293ca-26b6-40bd-8508-9c13e1e86f1c"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("44c772ad-22d2-4f02-a418-9b746766ed2a"), new Guid("35414ce4-a6a9-4060-88db-bddae8c469e4"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4b98e3fb-cb13-4974-8ad4-599776a1a3de"), new Guid("803d501f-9fbc-41cf-80a1-a34f57a88cb3"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("59fc04e6-96fb-4156-a6a1-8e3445534945"), new Guid("ffee8877-7552-403a-83a4-269df0bc992e"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5b981638-4462-47f9-8390-8483fbb6a819"), new Guid("309fe732-860a-4925-9670-b5f5f7fb5284"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("63b78f1a-4831-4eaa-a2a2-e64540a3ae3b"), new Guid("16f4a8dd-0b4d-4cdb-b6e2-f4c8ccd27d26"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("65bde5c8-77e9-4166-b7b2-3029d2f2e866"), new Guid("9511c7da-4d6d-406f-bee3-3ae0e41adbb4"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("67de7b28-2615-4e05-9a18-7d0709ed92cc"), new Guid("b9d0fb6d-8e6f-4f35-81f6-809df2182688"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("691230d6-86cb-4f1a-9ca9-affba7be70dd"), new Guid("857b3f33-16a8-4fcf-9eb6-9da25ddb406b"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6a91bddd-7720-4f5d-a677-a0eca0488814"), new Guid("6b742bf2-08a2-4255-bcbc-457ed4194ad1"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("722cfe71-d7fe-4721-bf37-169451617855"), new Guid("82dc7cb2-b0db-4c6f-bab5-ebe038911829"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("72671a0c-f182-4ee7-973f-0971c2191086"), new Guid("a8840ccb-28da-4a84-ba50-d46e529dc760"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("76f8cde7-7e2b-4816-a953-26b69ecc031b"), new Guid("998ecc3b-ed42-4f24-846a-508fbd052400"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("7e1f090e-7366-42ba-a11d-d3853d97f7a5"), new Guid("ce0895c1-7a59-4c27-872d-0d006a11f2aa"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8436b716-b197-469c-bdce-894173d336b0"), new Guid("1ddcd4ab-46f7-44e7-91ad-566a7c98cf24"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("84a52d5d-6719-4985-9631-32076e345a4c"), new Guid("fb90317a-4dbc-4dc7-80af-46716e34a2d0"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8ee97e31-ef78-4aa8-b48a-9cb998b1bc14"), new Guid("6d8a5a95-dc09-4d95-a933-2348e1e0b83a"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("90863bad-eda3-4320-858b-a8a84a5b0974"), new Guid("07d50358-35cf-4de9-a1d4-dca21d605516"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("96c95aee-c377-4c12-85d4-3fd61f94a16b"), new Guid("85779ea2-05f8-4198-9899-4cfe05a302b9"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("96cf84ad-6ec2-482a-b9c6-222b7f8ae1fe"), new Guid("302cf3ef-80a2-43c9-8d3a-51a478cdf56b"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("98391455-cb1f-4284-8f19-c8ad4f7951ad"), new Guid("12f39af7-12bb-4983-a2fc-2a968c92ccc2"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9bb7baeb-c1a9-42a8-b23d-fa8a7b641516"), new Guid("2470a24b-1aac-4cd5-9fb1-65ef527c0a80"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9d3ecf58-222e-446b-addd-7c013ca96634"), new Guid("2d6d66ee-fbb8-4cb1-a675-7bdbe10be6bb"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9d6487eb-d3bc-4687-9b27-45c5339a8f52"), new Guid("fdb346c8-c24e-4806-baa4-d67c974e6687"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9e09daef-4a50-4d70-ae01-5aa3c8028b67"), new Guid("c31813f0-670f-410d-ab5e-d52b8c2063ee"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a2dcb6b8-963c-4823-b188-941a01f2bcac"), new Guid("bf2dfb8b-38cf-4c24-9f7d-8bc22b396f93"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("af648d26-0fc5-4c1a-ba11-97520306c41e"), new Guid("e95d60a0-f5bd-43f2-96bb-71c176942503"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b38d97c5-1a56-4448-a457-36ce9ae21539"), new Guid("f1fda7ed-16ea-42bd-aa31-bbdb0f2af6c1"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bb96576d-dd41-4776-ae6a-927097057dcc"), new Guid("3bb95b53-b00d-4b9d-8807-236190e22e89"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bbd3cb20-577d-4e38-a80b-fb507e8e8d89"), new Guid("2d7343f9-f87c-410b-ba30-44466feda2b9"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c8f8d3ef-b4cb-46f0-a5e5-d9b5e320b68c"), new Guid("79b018cb-0054-4c6c-b0a2-c17da6455fa4"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d1a5797b-f0ca-42bc-8af5-2ca52e25ff19"), new Guid("04b0ba3b-c8df-48f3-91fb-5e3654dee29f"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d30a120e-53d8-4652-8ca9-174960e746a1"), new Guid("a0eb2dc1-51cf-4948-ba6c-227535dce9b2"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d3e0f5ba-5f06-4b3e-b283-0b3047209fbc"), new Guid("796adf0a-b85a-4be7-b9e2-f76c604d0d99"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d3f5b3f0-097f-4652-8938-deeae91da1e9"), new Guid("3a6ae67c-b76a-431a-9061-1e96d2ad638a"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d4808111-46b4-4310-a30b-2f0bc5e66bff"), new Guid("736b62ce-64cf-4bc0-838a-c557e40d468a"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d63c2661-3215-4436-9255-8e62668951ea"), new Guid("dd3e6832-b422-47af-b43d-e3257213b4e4"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d6527850-1dca-4ac5-a220-0f4ef927c5fa"), new Guid("3b7175ff-31c7-4ca2-b509-645070233e18"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d9d65f61-b07a-45cb-b513-eeda945023da"), new Guid("30da327a-fa2e-4260-b11d-b1a4dd3c4159"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("de174409-1c4d-45e2-abe8-0d6c19dd9856"), new Guid("3a48d048-7938-424c-8fe7-5f4734caecbd"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("de94ded5-eab9-4ec7-bf24-cc75c4a07f81"), new Guid("2f3ad69c-a671-400a-ad89-159a14ec0c84"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e62f9be3-4530-41f6-ab7f-481a3ff36169"), new Guid("e7233157-65f7-4435-8bab-846900de6181"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e84acbad-2150-4f9e-8e7f-07ceb4e1b910"), new Guid("edcc944c-50cc-473d-8f04-c6adad734b2c"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e8543019-4f1b-4527-a4a7-ba32450105fc"), new Guid("629e3d4b-6c02-4ece-a418-8055c7af3779"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f02c2c84-8bd5-4b85-b137-4404b2031947"), new Guid("81af64d9-39d9-4df3-ace6-91a2cd16196a"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f99b7a6e-25c9-40ae-87c2-af300228fc09"), new Guid("5735908b-65f9-4097-ad39-d9a867f19aa6"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fb9b52e0-54c4-4c15-aa64-e542bea25a75"), new Guid("e7d7d91b-efeb-4b46-9ab7-2754c9a0cca3"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fdd9435b-5cfb-408b-bc08-8ba84cbf9aa2"), new Guid("35f2efb1-5acd-44b9-89f9-a38e6e856092"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ffb7793f-b0a4-450f-9f0b-419eab5e74d5"), new Guid("268a199a-fa99-4619-b402-71f66910f6c7"), 4, 35 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0252b771-450e-48aa-9248-cc72c4a86c2a"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("1fcf6d0a-5651-4daa-9b13-5c8c4bf9d12b"), 1, "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("04f109d6-354c-493a-a35d-8f77057168bb"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("98391455-cb1f-4284-8f19-c8ad4f7951ad"), 3, "Device2_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("075f4af0-5e8a-4286-8804-3cd136bf7ac7"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("d3e0f5ba-5f06-4b3e-b283-0b3047209fbc"), 1, "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("078cbefc-a938-4df9-aaa1-efde937738d4"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("90863bad-eda3-4320-858b-a8a84a5b0974"), 1, "Device3_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0b8d3aa9-5eea-40a7-85c0-5760201c6cdc"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("96c95aee-c377-4c12-85d4-3fd61f94a16b"), 9, "Device2_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0bd3de3c-958c-4168-a317-a6c435b2393c"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("84a52d5d-6719-4985-9631-32076e345a4c"), 3, "Device3_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0d6cd1e1-a72e-408f-9373-84ea7fa3f50c"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("d9d65f61-b07a-45cb-b513-eeda945023da"), 3, "Device1_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1d1c4790-9646-41d8-97a5-8c1e94ae9881"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("15b23a1b-0b77-4071-86fb-d95e96db1497"), 9, "System_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("23d22d7b-fba0-4f8e-9371-2bd1ada4a5fe"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("d6527850-1dca-4ac5-a220-0f4ef927c5fa"), 8, "Device2_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("26c6a62e-6bc0-4398-a29a-0a520a7466ae"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("f02c2c84-8bd5-4b85-b137-4404b2031947"), 9, "Device1_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("29fa505b-c300-4ff1-b1e8-ebe4e12bc94b"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("3bb4d636-9373-4584-8a30-65b1f7044099"), 1, "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("30d68784-5eea-4161-9e99-dd5193c62b3b"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("2b71293d-d4a6-4df0-88aa-5c7d02a2790a"), 1, "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("32795787-2d7a-4c5d-85eb-a657ccab8555"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("0aacca5b-bb83-4947-9571-947e2ef9f70f"), 1, "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("41936b31-3fd4-4c84-bc7a-035a1a5038cb"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("d1a5797b-f0ca-42bc-8af5-2ca52e25ff19"), 2, "System_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4a127d3f-938a-4f63-bd23-b83b72c38dbc"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("1eb8908a-1968-4f7a-8904-fd683da0961a"), 1, "Device1_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4a2b304e-3fe1-4911-8426-81535e3b3dd9"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("07431172-2134-443d-a786-371c02c93d62"), 1, "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4a45e3b0-ad48-4fd6-ab38-fe3e84518111"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("65bde5c8-77e9-4166-b7b2-3029d2f2e866"), 8, "Device2_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("57a36bae-445a-4a92-8774-9463c02786f6"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("0736800c-d2aa-41d6-9c69-af21b1d666e1"), 8, "Device3_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("59cada09-a4db-48d1-9532-02a83247f019"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("bbd3cb20-577d-4e38-a80b-fb507e8e8d89"), 1, "Device2_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("59d2c21d-4655-46c7-9014-ab216c0b7d61"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("76f8cde7-7e2b-4816-a953-26b69ecc031b"), 1, "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5e5f3a7c-1c40-4082-ab44-0a102ea95f45"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("9bb7baeb-c1a9-42a8-b23d-fa8a7b641516"), 1, "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("63add317-49ae-4f0e-b00b-d4d2dc383666"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("722cfe71-d7fe-4721-bf37-169451617855"), 1, "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("66ade3a4-1f75-40fc-82cc-1a2e503b40d4"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("72671a0c-f182-4ee7-973f-0971c2191086"), 1, "Device2_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("695ce38e-8a25-4ae2-8aea-5316e5c2b678"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("7e1f090e-7366-42ba-a11d-d3853d97f7a5"), 2, "System_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6c4cf865-74da-4bac-a0cc-65b827b8cbe0"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("67de7b28-2615-4e05-9a18-7d0709ed92cc"), 8, "Device1_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6f5201e8-954d-4e2c-ab7b-93af95c40e9e"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("c8f8d3ef-b4cb-46f0-a5e5-d9b5e320b68c"), 1, "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6f8bf121-4cdc-463e-9788-b5ae55cdbbfd"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("de174409-1c4d-45e2-abe8-0d6c19dd9856"), 8, "Device1_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("76281600-0621-4f12-b540-df663a255593"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("b38d97c5-1a56-4448-a457-36ce9ae21539"), 1, "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("770b57fc-7663-4931-a36b-c0a1e9b7ba44"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("fdd9435b-5cfb-408b-bc08-8ba84cbf9aa2"), 1, "Device1_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("79250f63-f14d-4691-ad89-3d39e6bc55e7"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("9d6487eb-d3bc-4687-9b27-45c5339a8f52"), 1, "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("7abd1da2-792b-46c3-9602-8477dbd96496"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("e62f9be3-4530-41f6-ab7f-481a3ff36169"), 1, "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("7be043a8-7d41-4acb-8da4-436227d038fe"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("3095b08c-0fb9-4177-a511-77d842412710"), 8, "Device3_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("7f45a2ee-c104-49fc-9dd0-dd040b1e24b2"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("6a91bddd-7720-4f5d-a677-a0eca0488814"), 2, "System_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("88797512-6765-4ad3-82f2-2aeed21fd797"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("d30a120e-53d8-4652-8ca9-174960e746a1"), 1, "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8aa82f03-a86c-4edd-b3b8-da47144ebbd0"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("9d3ecf58-222e-446b-addd-7c013ca96634"), 8, "Device1_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("921b5c63-b279-4018-812d-c4732b233e81"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("8ee97e31-ef78-4aa8-b48a-9cb998b1bc14"), 9, "Device3_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("96efa905-f198-45d7-b7ef-a333f36253d6"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("e84acbad-2150-4f9e-8e7f-07ceb4e1b910"), 9, "System_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9ba57194-23d0-48a1-ba7f-33d489e628e0"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("de94ded5-eab9-4ec7-bf24-cc75c4a07f81"), 1, "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9c5abf86-2f9e-4b11-b827-a21c4236a0f2"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("5b981638-4462-47f9-8390-8483fbb6a819"), 1, "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9d585e37-ebd5-4b07-be3a-dacab3d60d8a"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("ffb7793f-b0a4-450f-9f0b-419eab5e74d5"), 3, "Device2_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a1c1f23b-1385-4ee5-9380-11130cd6fcb2"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("d63c2661-3215-4436-9255-8e62668951ea"), 1, "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a571ee11-5a2d-4ee9-bef5-fea23eb9ec3b"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("9e09daef-4a50-4d70-ae01-5aa3c8028b67"), 3, "Device1_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a636b597-82b6-4411-9b6e-facc1ec34add"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("44c772ad-22d2-4f02-a418-9b746766ed2a"), 3, "Device3_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("aa9f2f8c-a8ab-4de7-a5a9-eef375b274cc"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("3bf5ea1a-4aeb-482a-8c8f-7aa4ffe0729b"), 1, "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("aac907ef-8e09-413f-a7b3-f3bd444c917a"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("8436b716-b197-469c-bdce-894173d336b0"), 1, "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b175e552-bb8f-4f9d-97d7-2b5c5d9e64c6"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("fb9b52e0-54c4-4c15-aa64-e542bea25a75"), 4, "System_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b3bfff98-aa82-4833-b3b3-3d0bcb534e13"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("4b98e3fb-cb13-4974-8ad4-599776a1a3de"), 1, "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b43c305d-1e7f-493c-b876-f41d661175dc"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("d3f5b3f0-097f-4652-8938-deeae91da1e9"), 1, "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b5334f8f-5f3d-4674-88b3-e49e40d4f5c1"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("05d06dd5-9c03-43e5-b9ac-c99baa414058"), 8, "Device2_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ba746216-b9cc-4175-90bf-7864cd77d5d4"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("691230d6-86cb-4f1a-9ca9-affba7be70dd"), 9, "System_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ba7e58e7-9dac-427a-bbfc-d3400af0b39e"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("32e1f3e0-b804-4c21-99f7-82f39c580417"), 9, "System_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("bcf67ed4-5dd6-4190-9cfe-54990c664be1"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("bb96576d-dd41-4776-ae6a-927097057dcc"), 1, "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c95cde9f-55a5-4a14-9561-f6a4b35687ce"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("af648d26-0fc5-4c1a-ba11-97520306c41e"), 1, "Device2_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cacc2109-2429-4cd7-b005-c8532fd3c4b3"), new Guid("77136ba4-8b3c-488d-b020-f8a8bdb396d2"), new Guid("59fc04e6-96fb-4156-a6a1-8e3445534945"), 9, "System_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cd7e4da6-e68c-4a7e-a799-5d6edfbed3e6"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("1687d4c8-c968-4177-a2f5-c98e375b2239"), 8, "Device2_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d07b4a19-702a-47c7-a38c-110093a4c623"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("96cf84ad-6ec2-482a-b9c6-222b7f8ae1fe"), 3, "Device3_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d11dae75-8a02-4889-a477-c28b594fc571"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("f99b7a6e-25c9-40ae-87c2-af300228fc09"), 8, "Device3_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d5db0bd6-00ff-4aaf-adae-ee37453ed271"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("37425a3a-0fcf-41af-8584-88eb5d720629"), 3, "Device2_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d5f29528-a4da-4084-98a4-6efa109f4fb8"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("36517e32-d592-4c96-a4d9-49c52da819fc"), 1, "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("db631dd8-f32b-40ad-91d3-0d5c7ada6c5a"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("006d7287-6eac-416a-b736-98043f4c9c42"), 8, "Device1_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e2f26639-2ad7-4c84-8160-3aa693afba91"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("d4808111-46b4-4310-a30b-2f0bc5e66bff"), 3, "Device1_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e5ad7afd-dbfe-49fb-900e-0431560b1f4e"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("1773e2be-3151-4fb3-bfde-176e3ef750cb"), 1, "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e5fecc6e-018d-47d4-8da0-39d600dafb72"), new Guid("6b48ab2e-b156-49d9-bcb2-2ada69ce06f9"), new Guid("a2dcb6b8-963c-4823-b188-941a01f2bcac"), 1, "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f3933ce4-c55a-4a92-8e42-aea175feef17"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("63b78f1a-4831-4eaa-a2a2-e64540a3ae3b"), 8, "Device3_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f6ee0b50-9eed-4683-823d-939b5bd04f5e"), new Guid("0e102fcc-cf3a-4047-9833-ba1c14bb01e6"), new Guid("e8543019-4f1b-4527-a4a7-ba32450105fc"), 1, "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("fbf73015-eeec-4bbb-a0f3-9fdf7d4af851"), new Guid("cec3f11a-59fc-4788-bb49-8585c94833cc"), new Guid("2f9c2b2b-3858-4523-b90e-248ea8a1db0d"), 1, "Device3_IgnitionFlameAdjust" });

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
