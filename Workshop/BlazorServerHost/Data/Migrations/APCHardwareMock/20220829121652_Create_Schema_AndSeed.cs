﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardwareMock
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
                values: new object[] { new Guid("00007a8c-57fb-412f-bff8-f53f59dde0b9"), 4417, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0026454c-c4fa-4ec5-b2e8-6291f3e11e51"), 4252, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("002d4993-f53d-4348-a410-a4fffc9000e0"), 4606, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00429331-ced2-472b-8c74-38da1dcc75fd"), 4410, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00454ebe-a2ce-402d-a5d0-19afcbd703e5"), 4612, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("005b3a00-6c58-46b8-8510-d0d111fdc8d3"), 4621, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00833247-22ab-4809-bfcb-4cd1c0c93813"), 4214, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0086ea0a-7bb1-4856-8cc9-b1ed30ba3442"), 4622, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("008d3ecb-11f6-4dc5-9e43-8a501edb4681"), 4019, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00a19720-f75d-4ad3-a3ea-9a8291fe5b2c"), 4516, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00aa44fb-5154-4d52-812f-929c2fdc66c1"), 4531, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00b7202f-ea28-435c-bd52-86dd4ddbcd18"), 4015, 8, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00e0dc39-1d7b-4b74-9441-4903d1db152b"), 4020, 1, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("00efe2eb-7bc6-48d2-a815-deb4b4f7baa4"), 4249, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0105aed7-f67a-4aa1-8966-5718b0e9d252"), 4651, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0109feaf-f357-4ca9-9614-3f50eddbdb3c"), 4231, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("010b7428-fe89-408a-811c-5e9f17de9106"), 4806, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("010e13c3-38de-47ab-9b7a-297ef518c469"), 4719, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("010edf1e-5c9b-471a-9e8f-3550a74f256c"), 4701, 5, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0127bd67-deca-4ea3-b1d9-c99fab4b9768"), 4274, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("012ce14b-fdb6-4713-bea3-229f36d2caa3"), 4269, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0165cc20-e7c9-4c4f-a0c4-60850a84b5ef"), 4309, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01663b57-a826-4085-ab75-024616fb244b"), 4422, 4, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01998846-3afc-4c54-981e-18234c719026"), 4704, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("019b0646-a9a9-41a4-912e-76f56fff9e5b"), 4660, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("019c5514-6d03-44f5-a6d8-0335e62e8b86"), 4600, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01e1c453-5484-4d6f-a24b-e1eaf760ad13"), 4511, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01e46f82-f268-477d-8b00-f49ea7f3eedc"), 4657, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("01fe8104-023f-472f-818f-f9cc9ddc0375"), 4514, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0203129a-ad82-49a3-8fd9-02ee978d4caf"), 4244, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02066569-ad72-4e53-8e30-d510c4b7e662"), 4210, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("022dd623-e70c-4b1e-b1f2-62ebefed9184"), 4214, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("023f0455-3d0b-4229-a81d-c46614d5b536"), 4636, 5, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("027cec8b-a084-488a-934c-aed22ca9ec8a"), 4113, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02b5e00f-9a64-42f1-a11c-93dff82ba41b"), 4218, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02c273e0-6251-49bd-ba92-27549153e94c"), 4266, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02c47ce1-5dd8-4d13-8310-a865f42445a8"), 4219, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02d899b4-15d8-4670-bafc-a1576b6ed450"), 4250, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02e181dd-f9ef-4bce-bfbe-f31090dc04a8"), 4456, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02f2b776-d41b-41fd-8d2f-984f05db9590"), 4541, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02f535cf-3d1b-49a9-ac31-7b198cf9bf37"), 4250, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("02fe9990-8113-45c1-943b-06bb635a9f40"), 4112, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0307d03d-5faf-4cd0-bbe3-6c881666e57f"), 4248, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0315312e-f006-4a58-be8c-b4ed71067235"), 4510, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0350a2cc-76e6-4f5e-bca8-0ce57ecc2d3c"), 4021, 6, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0350a32c-bd19-4e6c-b969-4c0a3b8d2ee7"), 4722, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("036b95b0-cbb6-4e7f-9cfb-a713203f22aa"), 4561, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("036fb463-0d3c-4f1d-bc8b-05df9e2c7949"), 4243, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03950f4f-66e8-4813-b015-ce06e59db13f"), 4204, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("039e65a1-f0c7-4764-95bb-5c7828dec40f"), 4267, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("039e8b5e-ec24-4fd7-aa5b-d3cd99a025cb"), 4240, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03a77c5b-f8a1-4400-99a0-7338c9e320e6"), 4002, 1, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03a94add-9a58-4e13-aefd-fe3f05290759"), 4217, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03ad57e6-846b-4e2c-9ac1-ef9665d883de"), 4225, 10, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03b7fdba-028e-46a6-a452-c2879d33038e"), 4028, 1, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03cc6958-b028-4c9e-ac13-7ce7a201e379"), 4714, 5, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03e81549-d17a-4f6a-9a7d-3250a01d3142"), 4421, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("03f3a65f-2cfd-4150-9c3a-08d09f20de7d"), 4638, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("040cf211-4f7e-411f-851f-040344e1b43b"), 4809, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04290cbf-d998-4660-9fa1-2f7417f6fec0"), 4014, 9, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("046ac73c-d369-4e99-9104-e57c34d6c4b4"), 4547, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("047a0c4c-4b4c-4a6e-b8af-19eba4d37df6"), 4803, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("047d0aee-6323-416f-9b18-8f14c910183c"), 4242, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0486dcb0-e7bd-447d-bb7d-f9c05695b867"), 4544, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04a3d7c0-dbf3-45f2-8151-9d385a4972d0"), 4019, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04b271f0-3737-4fa9-956a-a6f115a237e0"), 4435, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04c0f8d0-247e-4c79-9e39-1e23a4d1522a"), 4257, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04cfc522-1643-45ac-8718-39e16eb69c3a"), 4633, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04d14abb-0174-4a54-96dd-0610dc14736b"), 4101, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04d6440e-4c58-4c25-be24-19afe0ada2ca"), 4654, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04e2a57c-657f-4d05-b3b8-d1b39702446a"), 4310, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04e391e1-ecfd-4f20-8d26-0bf4e1803ea9"), 4260, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04e970cf-82d0-47db-b9d2-2b2f81b840e8"), 4231, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04ec5cae-8a64-4e5b-8a97-47acb9fe8660"), 4532, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("04fe68f8-41fb-4cb3-b137-53555dc2036b"), 4032, 1, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("050057f4-c33d-4a1d-91eb-4c026456f384"), 4717, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0516d116-0715-42d8-936e-2eff4c648bdd"), 4225, 2, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05181719-900b-4fc3-82f0-5951681b6424"), 4543, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05247553-020f-4cbf-a8ad-3742905d6630"), 4635, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("054ec5f5-b6ad-4eba-baae-c36b71756517"), 4269, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("055be856-4b5b-4371-aedb-356802003f22"), 4565, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("057b2ccc-cd80-48af-9770-6c4ae48f9c9d"), 4636, 3, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0587ef1c-9668-43ad-bbf7-c1c056f8e1b2"), 4206, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("058c2181-d431-438d-91c6-1dcb5f0d3bc6"), 4033, 2, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05bb372b-2d74-4fb1-bfe4-694a8edd299e"), 4009, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05c04562-cc60-4136-b671-e1e2abd1c15e"), 4561, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05d1d9dc-49c7-448b-9d95-caab97d1946e"), 4604, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("05d4f834-7199-4f08-9060-cc484489705a"), 4716, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06061567-1b75-4e65-8598-e2b3f5a53665"), 4443, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06194579-5a95-4a0b-b179-b13bcb30278a"), 4541, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("061ffe06-5151-4192-a65b-53264e718b02"), 4659, 4, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06405380-2368-4b51-bec3-e983c1ab276b"), 4009, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0670bb78-9cbe-4a22-8bcf-e475ab6e91c3"), 4625, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0683f2af-1b5f-4993-bace-1861566f73a7"), 4258, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06aa84c4-6ac9-4882-9d2e-681bebf854d9"), 4315, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06c39441-33a3-4fec-a176-18c4589f332d"), 4524, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("06e3c5c4-40e0-4e7d-8eda-cb7981851e8d"), 4800, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0705f569-b3a0-4ccd-8bc2-a555064a1e94"), 4302, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("070ef38f-e6c6-4326-b5eb-5c91691ae59f"), 4559, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0720caac-5a78-426f-bed1-154632f4ec79"), 4266, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0734bbd8-da09-47d3-89b6-b37dbd75f926"), 4435, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("074ab27f-c788-4af7-a02d-013ab60fe0f5"), 4706, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("074ec471-abf6-41e5-a37d-1a0d6a759e53"), 4272, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0759ebbe-4cf4-4d0e-a625-11e2a253a392"), 4243, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("075ab9e3-6982-4e5f-972b-04058f822631"), 4222, 4, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0760d737-7d89-475d-84c5-5b6c5ad5fd44"), 4603, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07648c92-36cf-45a3-8527-235c7a5403fc"), 4208, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07732a9f-327c-441c-904f-8dbc21e8dc3b"), 4855, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("079739ce-d982-4cda-a5c4-d2f24f248b16"), 4640, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07bac790-f79b-4341-95de-7288090f5830"), 4111, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07d44364-fa85-4bb6-a3ef-ee4f441d0e18"), 4112, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("07f68a9b-8446-4422-b8b3-8b10ae613169"), 4702, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08044145-7e93-414b-87e6-231c11c53b9a"), 4706, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("080bd20c-4c54-4258-8f83-7073d003b1be"), 4552, 10, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08287f76-7ca8-45e6-950f-9a1071e396f1"), 4800, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0829da08-df00-4319-b6f7-0176c5323831"), 4628, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08798f5f-6404-4b16-863f-b15fef8a84eb"), 4416, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08815f50-0474-48d8-b275-251c888f7768"), 4112, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08c25bb0-e7c7-4da4-a649-e881bd3a4244"), 4402, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08c30280-85fe-4319-aedd-8ee3d2381208"), 4011, 7, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08c7b653-60a3-4e3b-a62c-d75282542f49"), 4273, 9, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08e59aa1-8ab2-46d0-9c1a-c92c6140d172"), 4640, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("08f5b35f-37a2-43b7-81bc-b7407f148490"), 4537, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09072cb4-1cbb-46bd-8036-3beb4d3c8355"), 4439, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("090a186f-88b1-4e12-931b-a3ea9382a18a"), 4511, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("090f601f-f001-4873-9564-00d57710d031"), 4851, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09134b1f-0333-4143-adbd-e05c3e246bf5"), 4316, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09136fe6-afb9-4ff4-8fea-ca9206e4868c"), 4656, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09140f31-adcd-4229-9e37-dab0d83feddb"), 4629, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09151d23-6919-43c7-8c75-2c3361f2276a"), 4222, 6, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("093a6f75-2970-4aae-b756-3f014d1e43cf"), 4652, 9, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0942003d-c59a-458b-93da-7a64a744ed11"), 4227, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09493884-1077-444f-8195-d5777d8dd7c2"), 4100, 10, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09608ee1-9bdf-454a-ba12-c8f020033bdc"), 4528, 6, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0962ecf1-2986-43a9-9aef-33892abe5a48"), 4446, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09696835-307c-4621-9869-a91ecd03699a"), 4651, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0986ef15-ba19-4dda-8d3a-71381ac1508a"), 4505, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0999d68b-9227-4cbf-98d8-07802df039fc"), 4509, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09a05892-4bf4-4343-b73c-a7d6daa4ffa2"), 4511, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09e37ae2-3cb1-4420-a074-2ecd41d8affc"), 4261, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09e62ee5-0ab9-4739-970d-65b6757dd487"), 4208, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("09e6847d-cfeb-4bcc-82ca-9adbce5a6451"), 4543, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a189c8b-99be-483b-89b5-2f371296236d"), 4621, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a2d3a01-dab0-4246-b9df-c6cd5b788005"), 4465, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a39bfc3-25ec-42fb-aa93-25c145e2e145"), 4010, 1, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a46c5cc-007b-41d4-92f2-7a08473f391a"), 4270, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a580e42-5993-40b0-8d5f-eba1b3dbc963"), 4854, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a618cc5-9f4b-434e-89d5-dc8b13cc4a2e"), 4517, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a79f234-575b-462d-b47e-73581e387693"), 4251, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0a86825d-2544-4e8a-a4b6-a234b1be236b"), 4222, 10, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0aa177a3-3b19-4ebd-85c5-af391e274a88"), 4114, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0aa99e93-6f1e-40cc-9874-4cd89b0717c7"), 4240, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ab77266-2935-4c4f-82d6-cfe4ea597cd0"), 4268, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0acead65-6d80-4309-ab5d-098edf4d0f6a"), 4322, 5, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ad2489e-21e2-4419-b220-9b1cb344b8b2"), 4005, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ada810d-cb07-497a-b31f-774a75eb48f3"), 4715, 3, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0af2e340-46fc-47ab-acdb-5cf074333e2f"), 4312, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0af82b9c-d991-4b9c-8aad-51ad41d5a13c"), 4250, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b071e6c-351c-4621-86fc-bc6a10071294"), 4321, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b0e4ef2-14fc-4a34-9a58-bb7124ba2944"), 4404, 7, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b19392f-f4d5-471c-9dfb-cf5ed959c7d2"), 4526, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b1abdc3-a208-40c0-8837-3ce8dec0121c"), 4311, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b28f0e4-f095-4ff7-b414-cf89d9352100"), 4218, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b4aa9ce-e44e-455f-9af4-9261f78846e2"), 4446, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b5dc914-1a44-4c83-9d43-09ed5ced29ec"), 4656, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b60b804-0be4-4660-9baa-589c5c1dd230"), 4009, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b7003b9-e0f1-4a78-ad08-0db67842f163"), 4635, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b89ec7b-712f-4bb6-9a2c-dc991788ac9e"), 4661, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b8e7c4f-ff5b-437e-8e16-390ddb715562"), 4400, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b959c2f-1e90-4300-b273-16bf6faddc85"), 4252, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0b9bdcbe-4583-4269-8381-c5793b28bf33"), 4225, 7, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ba2a047-f5f1-42c2-b108-56833af68711"), 4200, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bb7ba90-de4a-427e-a89d-b7244b70fc82"), 4638, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bbf357f-8483-4d7d-b15b-c2566fa9c880"), 4531, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bd93ff8-da99-40fe-b4db-b8caf709fcbb"), 4658, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bdaf305-f981-4b80-b294-be9c77146c58"), 4624, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bec6be6-448a-44ec-87f4-fa95ec0b1d51"), 4249, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bedc3a2-daea-4b68-b709-089ea8049066"), 4631, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0bee5ea0-8280-4198-88ab-da5ae3dabb7a"), 4415, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c072a77-54b7-45a7-b447-ff5f4aef3ed1"), 4721, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c19343d-8196-4609-b464-1c34c7eb56cd"), 4404, 4, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c2592da-e197-42c2-a1fa-4d5a929f4af2"), 4434, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c4fea2e-0460-478a-a8ab-e45f12fea3a7"), 4243, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c582e23-adfc-4a6f-b251-677843774332"), 4316, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c603820-3963-4ee9-942e-3d6bb6b8db78"), 4515, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c75de01-98bd-4a11-9d89-baad13ce1227"), 4216, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c77f8c8-cd27-46ba-a430-a3231ba10703"), 4627, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c7f9c84-97eb-4bd1-8d4c-5af3fe1a996e"), 4239, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c81537d-4547-44c9-9f15-0bddc3e89adb"), 4553, 8, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c97ff6a-4878-42b7-81ab-96e14fa4d760"), 4713, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0c9f242f-d9c4-4f8b-8d75-8243c9f171b5"), 4501, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cbf8c34-71b5-4ad7-8c92-b00adf065c54"), 4641, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cd36028-73bc-436a-adae-a32a4dbc5bd2"), 4315, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cd6a831-4cca-41d3-800b-1b31c8a6f29d"), 4616, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ce82951-18f5-42b8-bf6c-b695a8995b0c"), 4535, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0cebfda4-4812-4042-b8cf-908fd2fcf81e"), 4718, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d01672b-b7fc-4b40-8158-ba6105206469"), 4018, 1, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d056412-f113-4092-ae8f-a355343a57d7"), 4210, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d13af9a-7496-43d4-9411-203261be2608"), 4105, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d152114-39b9-4800-b42a-5d5903e8ecff"), 4254, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d1816e4-f570-437c-be6b-44797c19e7c6"), 4529, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d1e5024-4816-4b60-89e7-5d9abd1855b1"), 4257, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d20eaab-388d-44a5-b257-969a55f82ed3"), 4704, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d229f2c-a3b9-439f-a7d6-16e42d1e7f10"), 4450, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d25a79d-4ce3-4a4f-a2d5-1bf8fbe8f9c5"), 4027, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d28477d-2dbd-4b9f-af09-c6ecb7f063fb"), 4229, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d4e69e7-c307-4732-a103-ceee81c7c902"), 4316, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d640ada-09d4-4ce1-9e37-4fff9ae05623"), 4415, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0d9b39b0-ff49-4159-bc9e-4cf6d7d82c55"), 4262, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dab2fa0-9413-4bfa-bd78-0a1e8586bdb6"), 4430, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0db97eef-de03-491d-87cd-07b5c0c3fcfb"), 4532, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dba9b6f-5e2f-4198-bfef-8461e086aca5"), 4414, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dc36250-d75a-4fab-a4bc-152bddd4428f"), 4509, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dc85363-a905-4c7f-be39-e51dffcf0ef3"), 4322, 10, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0dd12b84-0d24-4753-8bb1-698c378ae6a2"), 4554, 6, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0df2ee73-5796-4837-8d98-369e17dd8045"), 4519, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e018e76-1c5c-4d66-a615-a2e3f448db14"), 4517, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e071ef6-9ac4-4026-a45f-c10159945c3a"), 4037, 4, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e0e0bda-ef62-444f-a02f-84433c0195af"), 4447, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e17a65e-8041-4a25-87d5-ca855b8a26e3"), 4236, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e368ad7-c961-4dce-99ac-84e558a979f1"), 4238, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e3713da-2823-4665-8287-89778b90410c"), 4625, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e3a4ab9-627f-4a9c-bdf6-e81ecb497de9"), 4509, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e46932e-6987-462f-a0eb-03b93c2f8033"), 4115, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e5eb5f7-fd42-4c0a-84a4-d41c6e3b01db"), 4525, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e65b5fb-d7b3-47bc-91cc-efc72111cb34"), 4428, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e6ba789-8d01-4cfb-82c0-be28ca4f43c3"), 4268, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e858ef7-7f22-4a31-8ac8-e87969310b52"), 4416, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0e96f299-c753-4c8a-b936-0583b0a6fc80"), 4417, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ea1073d-8840-4d00-9196-e88f65b592f5"), 4426, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ebc311d-18d0-4c6d-91d3-3a889ef75892"), 4560, 10, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ece10ed-2dea-4ddc-853c-5cbaab89eeb2"), 4661, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ed6fc91-e8be-4815-8965-17d3b2854fdc"), 4803, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ed70b69-1ca2-4b10-a7d3-b617c43423f0"), 4421, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ef85e72-a86b-4a47-ae24-f9e6a09c39d4"), 4306, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0efca169-e417-4809-821c-0933d335d757"), 4424, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f0b7021-ae89-4035-aac0-9f6f4a3bd92c"), 4426, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f174fb7-ae91-476b-a5e2-168ed8c6c3ac"), 4618, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f2bcb70-c926-45f0-a057-98b4a65a0b43"), 4310, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f53d182-09ae-45c5-a687-bc18ae98030e"), 4232, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f74d7f0-52ad-4015-8520-fa48dcbf5d55"), 4300, 6, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0f902d0c-4a5e-4a25-975f-6976e428fe98"), 4413, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fa14882-1cd1-4f33-b981-90aa03d749b0"), 4544, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fa55583-76f6-4a75-a559-66d2cbd14f65"), 4509, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fad5625-c2b3-4e81-8645-ab1ff383054e"), 4565, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fba27b9-2fc2-4ddb-a4f9-54d67a6a4a16"), 4609, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fbfb272-c43e-43df-871f-ce0fb880b33b"), 4405, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fdd8745-d0d9-4d27-9fcf-07d25f77265a"), 4443, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fef7596-3590-4b7b-b831-29014f3c2f20"), 4032, 5, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0ff68aee-761d-4d54-b9e1-e2a8de7d6ad7"), 4007, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("0fff9d7d-16e0-4d61-ba32-e05f45bda931"), 4630, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("100145e2-2036-4b13-b74e-d0d62244c9d5"), 4522, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("100d5daf-c081-45f6-a043-1d7b837351a3"), 4417, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10113e49-1c3f-4ddd-85ce-d62109b81da6"), 4464, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1014694f-14c3-4dbb-9df4-cbea50a66b1f"), 4808, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1024a0ac-a93b-4b55-a31c-6b321a0811d6"), 4104, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1028096c-fde2-4861-aa71-f6d2c5a2c295"), 4008, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("102e7dba-2f3c-4a13-80ef-e131d846d3c7"), 4565, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10525a62-e01b-46a6-8671-718c170db3ea"), 4428, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10564e17-a1c9-4828-b3c9-640a1ac42789"), 4444, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("106ac052-9154-47d6-80dd-1a7e663b8885"), 4635, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10777b99-0ffc-44a7-abcf-3c17ceaaa3ab"), 4256, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10d02577-e907-4828-b1ca-abab3f0f7e81"), 4274, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10d7eef6-b310-4885-a740-9612838579f5"), 4418, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10e0ca74-efa5-4a95-9f19-7506cb1b942b"), 4242, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("10f735f1-498f-43ae-8fe3-3b645ac68eeb"), 4530, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1128406a-40c5-41d7-bd60-8e8eb9b41bb1"), 4300, 5, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1143a9c7-df84-4d8f-8edf-e592dc65f952"), 4258, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("115c1b12-b412-492e-a0da-87e1870dc0e8"), 4236, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("115e23e1-4589-4330-aa60-1c0c13b0c5be"), 4221, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("116ce699-f7df-4cb0-acde-bedc47c2e1b0"), 4463, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1180cd03-d61a-4f9a-a407-26b6c16074b4"), 4269, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("119c08d7-d103-42d1-ae04-587d66c5a9cb"), 4115, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11a8558c-4e8a-4168-aef1-74e489a1a089"), 4203, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("11d7c87e-348e-4bf2-96e1-639fc757d027"), 4638, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12154da0-1744-420d-9fc6-b8910a5f4f9f"), 4029, 2, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("121cc9d4-d8df-46df-8577-8b3a8df4d2b4"), 4232, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("122871c2-b2e3-426a-8513-0f4f4c1224c0"), 4630, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12310053-d586-4efa-930a-aeed7e4b589c"), 4455, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12527827-445b-4f35-bf48-9144204ecf48"), 4317, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1282f600-4743-41a5-9dc0-e2ebe1e4871a"), 4302, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12c0ebee-8353-4323-b8e0-7ab470a20ea4"), 4512, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12cec265-5a02-4c83-859b-ec10aae1a03d"), 4559, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12d83455-d541-4b23-9d2f-601aca7ed1b8"), 4103, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12e2476f-59b6-41b6-9497-d941a18046dd"), 4541, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("12e966c7-bd18-46d8-a488-76c2adc448a0"), 4304, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1305f689-1461-415a-911b-ceb39c0a4019"), 4550, 8, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("133a050d-20ae-4fad-ba3e-bdb0b4a64efb"), 4414, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13587fa4-7090-49cf-8492-554a9fb9c444"), 4417, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("136d682c-5640-4d0d-bbdf-e7b0c754f2f6"), 4028, 5, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("137d791f-64da-4b1f-991d-80bb17aff827"), 4450, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1383eb7c-b31f-481d-9344-3b0e840ee1ed"), 4626, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("138ec0bf-c232-48c6-84fe-24a13ed20019"), 4413, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13a8e27b-f5e5-4198-b83c-589509e89dd8"), 4716, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13e534c9-58d7-4458-84b6-cef75e09a0aa"), 4609, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13f05f97-0397-4357-a361-522c31dd46fc"), 4518, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("13f14901-c5b7-4f3b-b354-6dd500cdbc61"), 4302, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1427e1c3-f5eb-404e-b4bf-744c00d26f82"), 4804, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14316960-9aff-4e42-a000-7846f8225f59"), 4026, 8, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1442d3fb-5e6d-4335-8d2b-d1219d3cdc03"), 4114, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("146fe8db-0454-4165-a19b-ace43f9279e5"), 4706, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14915669-1ddb-45a5-b7fa-0adc3bb50ea4"), 4026, 4, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14985b24-8217-439d-93c8-613ab6a02213"), 4559, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("149af469-33d0-4744-87ab-9e1928da804a"), 4036, 5, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14b80ace-d3a8-410d-9f23-3c5a5fc411df"), 4624, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14b8a7ee-ff52-4059-968b-af83e8e249a4"), 4425, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14d4a9f2-bfc1-4f14-9506-da89d0954418"), 4427, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14f3f371-3e2e-4c58-adb3-b273682d65ea"), 4538, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14f43d7a-ed28-40dd-94c5-66c41aeab342"), 4527, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("14fa9b09-03ca-4803-b079-f29674c58c7b"), 4206, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1536f37d-49e4-4fe3-878b-4624e57ebd96"), 4314, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1550f619-e0f1-41d4-86e2-f5191fb52a7c"), 4106, 2, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("158f921d-d000-4027-a3ab-1aad81fb5562"), 4401, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15adc1d4-9d16-4ce3-9417-38bf6c354093"), 4800, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15c16fd6-850b-41e9-a476-2e909cfd86c6"), 4323, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15dbdc8e-9c08-40dc-86bf-edc19c3dd2f3"), 4225, 9, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15dce846-3068-4baf-81be-949b4761bdbc"), 4240, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("15f6b45d-6ce2-4899-b7e8-3d8682c89197"), 4427, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("160eb716-6b22-4999-98fb-8640ca916546"), 4656, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16264857-70fa-40d6-9b5a-e0a99e70bf8d"), 4659, 8, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("162ee746-4d6a-48e1-8f28-4a33675e0e22"), 4712, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("164b9128-629d-4680-b748-fb7b9ab249de"), 4410, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16600bbb-48dd-4737-a5c6-3c5f349ea4f1"), 4030, 5, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("168d0bde-eb57-4211-b84e-e9b82f5b7358"), 4526, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("168e3a3b-cc61-4af7-b085-723d6b5ac25e"), 4305, 6, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16af5fbf-70e1-4b94-8fd0-f40f76430e1d"), 4270, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16e07dba-f542-44cb-9666-3a7a6e330575"), 4407, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16e0e739-15d1-4b67-aa87-2de6357f98a1"), 4001, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16e5743c-e136-4218-9f0b-982396513705"), 4219, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16e57484-8574-43f2-a463-52612e6ed7d9"), 4009, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("16ed25f8-e96f-4bdb-abff-cffe68b69a19"), 4524, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17073343-9a80-45e4-9462-ea84cc3a319b"), 4411, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("170bb681-ca9c-4e31-8ecc-4006a05fc0f9"), 4716, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1718299c-55c2-41d9-8144-267157c09813"), 4037, 9, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("172bbc5c-0463-4b07-ae2e-8a3435f76a8b"), 4236, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17402482-a66d-4e12-91cc-f3bac2265589"), 4624, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1742489c-0eab-4b55-96e4-b66a388cdf84"), 4555, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("174392fb-6f8a-4144-9502-221d1e744940"), 4850, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1750f813-89ad-4130-ac9f-625763feb324"), 4803, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17515f57-15e8-471e-9de6-05456bf93bf1"), 4454, 4, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("175a480b-12eb-4ee4-b15b-6b1b7c9878b0"), 4709, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("175c64ea-24f9-4b4e-b5bd-98ce7f404caf"), 4036, 8, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17955770-ffb5-45e4-976b-0eeb0e49b8d7"), 4105, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17a5ab88-17df-42fa-914f-3a14239993bf"), 4615, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17a5fdd5-3681-4ddb-9d15-77c9d90e4da2"), 4305, 8, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("17d7ea8a-cd22-4c74-9a0e-d77d49a8a590"), 4017, 9, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("180db951-a4aa-48f3-90f5-8ad26e63a5bc"), 4248, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("181156b8-6f18-4750-8880-2c4dfb81640e"), 4316, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1839836c-c753-48a6-a266-6952a112add0"), 4016, 3, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("183abc59-d8c1-4b19-aed8-739147fe4494"), 4400, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("183e3e90-833b-4446-91ad-d01b49ad4376"), 4009, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18459c48-e9a5-48c4-979a-10909f80c961"), 4103, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18495f56-9fa5-4a9d-ae81-cc9c7871c525"), 4224, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("184eb0a9-9a3a-40d7-830a-e4d3668cf3de"), 4463, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18535faa-72a0-41c1-b6ab-b5462886e318"), 4255, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18629edf-9bb3-419d-93b0-eae83197e7f9"), 4265, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1875d0a6-1c4e-49c1-b5a2-f8a0288db6ca"), 4506, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18a5ad63-2a20-4ee9-b70b-84e3df14661f"), 4606, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18accd11-f0bb-41e3-a45c-b89b0b723a60"), 4533, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18c387bd-a2b5-4de2-83d8-1904e975d9c2"), 4402, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18e1a9b8-df6f-4455-8f5d-dcf8de692bd3"), 4311, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18ed5bf1-005a-409e-8c51-13a616481a0c"), 4227, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("18fe1060-35e2-48d4-b67a-54b9d8df195b"), 4633, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1900e5d1-2603-429f-b537-e5d4ba5d8238"), 4561, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1917f8ed-dc03-4b46-9ae3-b389142cd396"), 4247, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("191f6741-6858-47df-a52e-aaf1834ccac3"), 4237, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19250a01-bc25-4502-bc26-97845207fbf1"), 4240, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("193a1362-9cc9-43ff-b979-9825dd0acac5"), 4505, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19418b53-7fac-425e-b895-2ed835f13b26"), 4028, 8, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1943a11f-f8c7-48ab-aed7-aa7e27ded9a1"), 4215, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19581f5b-a754-4d7b-824c-9dc456bcd64e"), 4609, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("195c4212-5751-4bf9-b823-998f4b336f14"), 4532, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19a3c59b-6687-4f7c-b991-60f22979c573"), 4112, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19bb9f7c-6a26-4ee2-bf49-576ac9c28d1e"), 4663, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19cbdcdd-190d-4eb4-bfaf-7185db317039"), 4412, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19d608de-0dba-4ce9-ac16-fd53b4991cda"), 4518, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19e873b2-44f3-48e3-ae41-9e5d02bd01e9"), 4807, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19efe89a-a648-480b-85c8-fb76f58a7d9e"), 4222, 1, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19f3fc7a-0d04-4aad-8394-9dde674ae021"), 4249, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("19f92cdb-f19e-4570-8e96-bfb0377399e8"), 4558, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a06b381-e5df-4228-8a14-fa0aa6e10ef9"), 4035, 6, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a12aa2e-a051-446a-83a7-7feeda27fb56"), 4562, 10, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a1a34d0-fd5e-46cc-8e5f-1dfb71a1fb45"), 4456, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a32eb96-7343-4c4f-9bf5-42f0bedeb21f"), 4404, 3, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a34cbd9-9376-4142-b658-a9337b735a31"), 4004, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a4dca28-abe8-48ad-84ed-8a3515fe4fae"), 4660, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a65b623-fd07-43b1-9aa4-6cefb09f67f7"), 4853, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a6d274e-3846-413a-85b6-72d02e0cca59"), 4441, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a6ec1eb-813d-4f91-a45d-20a09461642c"), 4455, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a725408-8552-4019-976e-3b3f33be521c"), 4248, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a748ec3-7bcd-4388-8762-801c7cac9d4f"), 4252, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a750b3d-48b1-4bc0-91c6-4528b08708af"), 4612, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a842bc8-2263-4686-ac6e-9f8fb9ee4cae"), 4641, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1a8562ae-6caa-4c9c-a2c3-48bc65755f2a"), 4629, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ab0e719-2ab9-4f41-be40-70bf744ec05d"), 4806, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1abb7430-e648-47fc-a758-dac9c3266df4"), 4662, 10, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1abcac35-7292-44bc-8819-463ec03e5f34"), 4240, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ac4d354-0661-4ba8-9ff6-0e9e25c7597e"), 4245, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ac716c5-0e7b-40b8-992f-a82d057350ba"), 4519, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ae89c7a-25cd-4bb8-b350-28e013d7122a"), 4500, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1aea8705-e859-4eea-afcf-c7f6783ee9b0"), 4217, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1af1bfe0-0b7e-4d4b-b33a-1e116d8871e7"), 4453, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b0e4303-cb34-48e6-850e-5e99cecbd0a5"), 4014, 10, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b15a8b6-2f86-466c-85a0-c54617803990"), 4525, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b4bcfdb-4528-4cda-88dc-2a6d531b0003"), 4662, 9, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b567168-b890-4be1-bbed-628fbc07a260"), 4270, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b5df9d1-1bbf-426f-8ce8-2e81aad06c5e"), 4200, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b5f6216-67df-4ce6-81b3-5f7e2693488f"), 4206, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b68820f-bc40-49cb-a98e-8f1760d4740c"), 4523, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b814c93-5a84-4a8d-9e32-a12c9ac74e98"), 4107, 1, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b8d6cf9-d4eb-4df6-87d8-672389bc3ac4"), 4555, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b8df547-5468-44ab-82b5-f708b6a01b62"), 4031, 7, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1b980c4c-b065-45aa-9536-ef86f142f44f"), 4232, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bb5ea8d-41de-453f-b2bf-f47c767dba34"), 4408, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bca50eb-2c10-442d-9b4c-616eb8994e14"), 4000, 10, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bcd4372-1b54-4728-8a4c-bb6f37838762"), 4654, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1bcfe9d0-92eb-4569-a373-16cab74cca91"), 4016, 4, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1be12735-3016-4aa9-864c-84ae65b61e8c"), 4011, 6, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c08e8ac-15b6-44f0-a83f-58750d6fba7a"), 4213, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c0a2b3d-7719-42e9-b301-6467e42148cc"), 4654, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c12484b-a419-4e96-9f12-4a6a0ea6e263"), 4033, 9, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c127419-e577-46f2-b5bc-9b2accd16d4e"), 4102, 8, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c1484da-e7a6-454e-96ef-096d98e3d2da"), 4324, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c284dfb-6138-41c5-8850-68fac719780c"), 4460, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c3b3edf-3d36-4efe-aaac-b65e8facfe5a"), 4442, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c3df8f1-8881-4344-8bc4-1817b4c7ec0e"), 4101, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c58de3b-4e9d-4b4f-a77e-2fa76375db1a"), 4267, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c6afdbb-83b8-42f3-b152-80b30cf52b06"), 4318, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c6b442a-62ae-4b4c-b755-d9c6774951a6"), 4260, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c7b0281-29b1-4da8-814c-9a082ddc8e42"), 4720, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c8723d2-72c9-478f-80eb-e447cf6e5091"), 4424, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c9c4a48-60ee-49f3-ad94-63c6ac44c363"), 4412, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1c9ddfdd-7084-4883-9067-48ded9072a03"), 4810, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1caf1454-daed-4628-91ef-0a9fb3163843"), 4853, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cb018ce-c26b-4378-b986-a5ed00e46f66"), 4212, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1ccb3e01-3164-4109-864c-57dd66c7ad7c"), 4519, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cd9914b-1c50-46eb-9421-f59c4e038a2f"), 4109, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1cfba1c1-a4db-4772-9dfe-5976dab5989e"), 4630, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d0ce622-1f3d-455f-b4b4-afe56803e8cb"), 4430, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d10c679-e665-4d41-87e3-a67fdc1578e1"), 4619, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d1d67e8-ec14-4596-bb24-312ea33bb362"), 4218, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d209c7e-cd48-438e-a6a2-bacfc9946ec6"), 4463, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d291147-53c6-46be-94ef-dddbaf53e3a1"), 4433, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d366ca6-7fd0-4935-8c28-d4de9e579711"), 4312, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d3f877e-6896-41ee-a5bc-e0bbb3f2a51b"), 4300, 7, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d420f3a-e859-45f3-b32b-10d6f01bc647"), 4810, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d5e8542-1d01-4e24-a77f-f28a70d78ea8"), 4208, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d6d66a3-fd5c-4da9-a3b9-6c277376dddb"), 4854, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d7e373c-84a6-4af4-8938-c36d52c3ff7d"), 4625, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d7eeb06-0838-4b03-b80d-5b09fb34d0f8"), 4232, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d8d6931-8ca9-49e9-bbf7-4ee30c79fc57"), 4003, 8, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1d9da2bc-cee6-46ae-86df-13de82af908c"), 4802, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1db64800-180b-4baf-b38d-14db756bf8b0"), 4305, 5, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1db8d47a-0f07-45f5-a33b-7e83c7892ba0"), 4806, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1dbcc2e9-1bb2-4e86-8700-9fd6e032dc07"), 4633, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1de3de00-495f-408b-9028-0a3f08c19f73"), 4323, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e06d0c5-91e3-4961-9a18-3478ecc52fb9"), 4558, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e08e1b4-ceae-44ad-a8fc-0d99e4d7a301"), 4438, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e14dc39-226f-4657-9495-6fdceb573675"), 4722, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e194489-91a0-4eda-9cf9-641fd23ab1f7"), 4660, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e1f4e67-53f9-454d-a1b4-cc66ded344f6"), 4113, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e4b0556-6a5a-4026-9ff9-7aaf3bf34ca7"), 4246, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e5c8d91-8027-4ad5-a9a4-aa95c0a46e5c"), 4620, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e70b477-ce40-468d-aeae-573fee5ecda4"), 4650, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e7aa834-445b-4545-80a8-3a1898551b80"), 4203, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e7ed143-0ed1-4f51-a8fb-43ea19d19d8f"), 4436, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1e90eed3-b774-420f-8375-630662cf4ae4"), 4629, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1eb3b70f-c575-4a3b-9914-654b7daa0b49"), 4227, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1eeab4fb-b080-42ee-adba-5a6bc808a971"), 4552, 1, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f02061e-6b6d-46bc-a241-623a11f8f6e6"), 4513, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f1cc442-5bab-496f-b79d-d958f45f3410"), 4507, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f20e7cb-6c73-4c4c-a3d8-5d155e7eb2f2"), 4031, 3, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f591e2c-2507-441f-b216-97cd53dd6a03"), 4521, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f6bfa8b-2604-42f5-9709-0b2d1303ecc8"), 4223, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f6cae23-361a-459c-8e54-2d38652349d0"), 4632, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f774774-d527-4b79-91d4-6343aec92b26"), 4853, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f7aab21-eb03-4f17-80bd-410bdcf6e7e9"), 4418, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f7bc352-2678-493e-bf29-4728a6b41da9"), 4036, 3, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1f917c9b-49f2-4140-9e6a-5969c3ee864c"), 4856, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fb08384-46e2-4d31-8d7c-bfa3d10ee92d"), 4423, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fbdfc5b-ed7d-4e0b-ad5c-832c1b6dec02"), 4017, 6, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("1fd0bc29-1b31-46c2-8e37-955163120d53"), 4610, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2006b06c-b1f3-4712-9088-787ca507c387"), 4708, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20073624-aa79-482d-a498-ff6673553770"), 4010, 3, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("200892f0-7072-4a9f-8eed-4b4efd2b5330"), 4251, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("200d9247-1fe2-4115-9b34-2362925585ca"), 4006, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("202be37c-d9f6-46d7-95cb-e9ac8102f361"), 4508, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2031dbf0-2187-4056-a5a6-7aada54bb592"), 4515, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20402d32-706c-4244-b8c7-fa4f77725327"), 4621, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("204f73d8-c5f2-4fc4-8c64-32f03781c54e"), 4515, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("205320b6-57e2-4f4d-9b25-4ee5ce8fa3a0"), 4703, 4, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20557202-df98-421d-ab43-fe1a6f7a103f"), 4602, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("205abe58-642e-4e50-b118-9b807e268781"), 4539, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("205b5082-3f22-4391-8fbc-f3f09252ed9d"), 4614, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("205bf212-32c8-445a-ac18-02434d584fa1"), 4604, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20612d42-ea3c-4604-9993-99d970fa0fad"), 4610, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2082c35a-940b-4dd1-85ea-843b88df8062"), 4543, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2083b149-c99a-41c8-94ad-5298c5d50371"), 4461, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("208f0fdb-8687-4ee0-b16f-453d5dfc9e49"), 4560, 1, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20b80572-3b43-40ef-b9cd-7da504630c30"), 4435, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20d05ced-7143-439b-8887-6ebdf09faa35"), 4540, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20df739d-15f3-4535-b557-d62e15d74972"), 4503, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("20f0d3e4-45af-4ede-9e9c-388e92b530ab"), 4800, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21130b3b-6e3f-4ab7-b6c1-cca32b9a279d"), 4445, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21160a2a-cfdc-4cb1-bd03-8a0a34ca4dbf"), 4228, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2129c374-dcda-4b06-817b-e895b2116049"), 4006, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21334729-0226-450c-b760-174e3a6e5c6a"), 4413, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("213f7009-7c41-402e-bd7f-e9f135e7dafa"), 4712, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("215e2e49-c671-4c54-a1f6-8ca990e39a65"), 4421, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21699224-7e8a-42a0-86f6-0de8083a8c63"), 4202, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("216c0f27-c272-442c-8ade-e17c542b250c"), 4700, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("216cde85-0450-4b43-8fae-20cc7a2b75cb"), 4028, 10, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("217e3319-aa58-43ba-909e-b1ecc28667a3"), 4529, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2186b720-2820-4bf7-ab01-88ccbcf482bd"), 4537, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2191f698-63f9-49f4-a187-ca22520a04fc"), 4438, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2196aadc-916c-4e94-808a-014242bf421d"), 4028, 7, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21a6c9b5-f670-4362-9798-1da2ad47c191"), 4607, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b2fffd-34f6-4531-95f1-e7d7724b8721"), 4263, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21b7d184-3508-4ab1-9929-33785628a8d2"), 4637, 8, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21bc873f-54aa-43cf-aaf9-7b99a5fcfe6e"), 4233, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21bfd3bc-dd81-41a0-98ac-a0510d2548c2"), 4546, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21df6b43-3a5d-4d10-b4cb-285da55c7b60"), 4228, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("21fccc31-0d56-4e18-aae7-3a737ea4d0b5"), 4519, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("220af7c8-e818-4396-84e7-697adf0e7afd"), 4222, 9, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22104d64-71b1-45f2-af89-5e6a4ea1203a"), 4004, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2236ccae-baf9-4852-98cd-1e53a85aba9c"), 4803, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2241427a-7f26-4ca6-b466-16dfd54c3452"), 4852, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22440c76-d394-4590-8905-bec2fa79b63d"), 4315, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2249b1de-6279-4175-ada1-4ac00ed74aee"), 4461, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2250c0a6-06ee-4862-ba41-41e4cb7cab65"), 4532, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("225bdb38-8d27-4e90-8cfa-29d1ef24d2d4"), 4036, 6, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2271dfe9-b382-4867-81f6-742c15bcbc59"), 4525, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("227fa20c-ea0c-492d-8099-37ca4e97a43d"), 4611, 3, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2285a9bf-f263-4c68-b197-02700169ba7b"), 4658, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22bea4b8-95dc-4e78-904f-b9b904874909"), 4261, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22d58601-7ac6-4ba2-b743-a2c83c30c3d1"), 4228, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22d62e0c-8198-4458-a382-0badbaeebd57"), 4715, 8, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22d76b2c-93aa-4739-b35b-c62051a2d949"), 4442, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22de3dfb-e8d1-43ea-b7c8-630f178edefa"), 4106, 4, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("22f7a7b3-38b8-4f45-8115-6c5ce856ee48"), 4527, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2316cad2-c97c-422a-95e1-c9c591c4781a"), 4556, 2, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("232ea2cf-3c2c-4287-a7d0-156d1341b530"), 4107, 4, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23306678-dc13-4f5a-a39d-70ce63ade131"), 4410, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("234f2d85-b223-4328-9664-adc6f8ce7fd5"), 4318, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("236e36fb-5c91-4b9e-9bd4-e014af4c03d0"), 4109, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("236fefbb-31eb-4bee-a4bd-4838ac698968"), 4215, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2376e220-38b6-4350-b15c-31acfcfcbc5c"), 4556, 3, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2382d24a-09c5-47af-a192-fcb3cfb7e077"), 4025, 1, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2395269d-e206-49a9-a93e-ff0427f58552"), 4516, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23aac2f4-6ea3-489b-9f01-c27709e7e38a"), 4708, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23c220da-4d1e-4295-8467-d36433d11545"), 4560, 7, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23d3523e-180c-413b-bdce-75d6c6ec1e45"), 4415, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23f2808c-3368-4170-bc3d-86ded5d2d3e1"), 4427, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("23f81cd1-7102-4ebc-8f08-c15a19df45be"), 4510, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2434bf5e-d6f2-4bd2-8e37-d5fb81cdbaa0"), 4112, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24672df9-7835-40d0-8630-66e31a5c9aa6"), 4247, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2472dc73-85ae-4cad-81d2-828e4bad15a9"), 4721, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2483a2ec-24ea-418b-9be0-9c06b841ca75"), 4323, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2484e6dc-c702-4a31-804c-8f9a2509324c"), 4628, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2485baac-a50f-4141-aa7b-fc9db3d1392b"), 4851, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("248a8668-1b64-4c44-bf18-3ae770870d66"), 4409, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2493370a-09ec-4ad5-9618-23190144c705"), 4457, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24b02470-586b-4a00-8146-f0e15fddc520"), 4210, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24c3414f-a83e-4f9a-8b25-2adc575cdc6a"), 4031, 6, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24cd875f-7b73-4ed3-a9eb-4f8b2e31440b"), 4307, 1, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("24fae6f5-248f-4142-bf1e-28a00ea9bd57"), 4203, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25004f40-6b41-4f23-80f7-d363a58fd3f7"), 4443, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25057e47-7dc1-4177-ac12-687a032a5d7c"), 4115, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2525f079-cde8-4f53-ad82-d7e564528ebb"), 4021, 8, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("253131a4-ee25-4021-9d1e-d148a4fd7720"), 4657, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2535558f-2b04-4d87-aad7-2df4eaf3662a"), 4110, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2555b0ea-8f00-4236-b0de-19a7e3218083"), 4218, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2561b662-84f3-469f-8dfa-bc6990ce9b1e"), 4033, 5, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2565d55b-2aae-44b5-b6a2-a29156c0f377"), 4622, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2573fc03-a11c-4941-a54a-0f11d61b7102"), 4232, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25780cf1-87dd-4922-b058-aa9db0cee047"), 4511, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2598d67f-515d-40d8-b09a-b0d4852bae75"), 4601, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("259fd8c6-a2e1-4a5f-8eb7-609430f99252"), 4627, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25a8fd58-bbae-4c58-9670-5c9f1a4c82eb"), 4639, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25ab2806-581a-4fea-a651-8db7aaecf150"), 4600, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25cd595e-7d4d-472e-a530-a02af9e4a823"), 4023, 6, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25d9fabf-ae10-4f4c-a88d-b0ad8e28fa74"), 4624, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25dc951d-a0b5-4579-a87c-1471709caa57"), 4308, 7, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25e10136-2d10-498a-b3bb-148915ad91ff"), 4530, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25f2ace3-26fa-4634-ac12-86948655144d"), 4517, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("25fcdc99-ac3e-40ca-b649-a9c021fee92b"), 4022, 3, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2609e2d2-4701-4bd5-8888-edc2363c9010"), 4221, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("260b85d4-4c64-4d74-b3d1-06cbaa9e0233"), 4429, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26275d37-9c80-4d2d-b668-3ed7f2d64582"), 4461, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26334aca-4357-4f62-ba37-ac18c10bbc11"), 4408, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26340101-4587-46eb-a679-2ad5f26761d8"), 4267, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26524695-aca3-4aa9-8cd0-2ec65c5a25f3"), 4270, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26577cb3-3e3c-42ef-949d-b1c2b53bc634"), 4403, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2680f8db-9406-4ad3-bc7a-fbbe1394a1f2"), 4228, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26c3cd00-e95c-400c-86c4-862f67e941ce"), 4240, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26d259c1-a51f-4087-b1d1-5880961e7fc4"), 4522, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26d53fe6-669b-47b6-9e88-2841629be9f6"), 4465, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26d622e7-f7ad-40ad-896b-60010504295a"), 4106, 6, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26db7a32-be1b-42c2-958a-9705871ae390"), 4418, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("26ead95c-087c-4a18-a2e4-afd3348e1b30"), 4604, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27093f76-9ed4-4ec7-bcf6-2823edbc6ee5"), 4200, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("270e2a41-78a2-4b55-97d9-2293ef9b3893"), 4324, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("270fcef7-81d8-48be-9ae3-5c505f2248eb"), 4635, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2710ea03-7f4a-4238-858a-7ba5ecb2b0f7"), 4273, 4, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2738dfb4-b01b-427c-bb1b-5031db4e4b01"), 4029, 8, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("273fe93c-e57d-43d5-a551-ebad73ffd5ab"), 4413, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2745d787-0a1e-42ea-92fd-a89250d877c7"), 4602, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27696eb1-832a-49a6-a038-4580b5bab594"), 4444, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("276de168-d37a-49e7-939f-43aeb894e9c6"), 4542, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27826c1c-c245-4f6a-931e-b9e26b4e0490"), 4024, 9, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("278ebde1-850f-4818-af66-e4589c1f057d"), 4426, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27b41f7b-d4db-479e-b7a7-5ac0f565bdc1"), 4212, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27bbc71a-27ea-45a9-8b6c-321125ebec17"), 4102, 7, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27d06d94-e270-4543-8b0b-550fc0c09e17"), 4705, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27d0775e-ed70-4adb-b86d-b1d27b0f70e4"), 4403, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27ee17e8-5fb5-4995-967e-cc7585f9825c"), 4102, 2, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("27f4b5f7-98e6-47cd-ae6d-ba30b187302e"), 4636, 6, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28013707-8c2e-4bca-b3be-718e3505ecb4"), 4251, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("280a6ceb-31ac-4202-8b5b-c3df38829a11"), 4608, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("280cace7-a9bf-437d-a224-686ae184d35d"), 4631, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28112f69-4be8-4e4f-9f71-7b76105fb2f4"), 4246, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281a9c99-6776-44eb-83e5-33ba6f395d63"), 4207, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("281d9889-a682-4ffa-9079-7b778b77fdaf"), 4019, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("282b13eb-25e2-4465-b2af-150a4b328f2f"), 4519, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28327feb-94a1-4c13-acec-ecec1a677857"), 4220, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("284586a0-6b49-432a-bd2e-6d296038c1fb"), 4255, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28472fc7-6850-46f5-9030-f36a8b774561"), 4273, 3, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("286b9e2a-a966-4be1-8925-9dbae2e0e331"), 4663, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2874685f-cba5-4834-9842-4f7186eb8d16"), 4510, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("288372fa-66af-4138-8ed6-8b863ab19b99"), 4244, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("288f6b3e-6e05-422b-8dd4-90664d817ac1"), 4020, 6, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2895527e-c022-4dd6-aa11-824361d9bbd2"), 4620, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28a4f66c-10f1-4853-b466-2095a43aca49"), 4463, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28abbd81-1675-46a8-a818-34577d0c8cce"), 4525, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28bc9206-e82d-41ff-96a6-857099b0cefd"), 4810, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28c738ce-af44-4e00-b08c-19b9d4f2a176"), 4550, 10, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28c7a701-d86b-4078-a950-4b364566b046"), 4219, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28d41c2a-d1e6-4d0b-9ad9-3299514cba6e"), 4543, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("28f83eff-844e-46fa-adf1-6f507bb79163"), 4036, 2, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29257776-e10b-4483-9aa0-fab3238f8b42"), 4210, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("293c55a1-a5ca-44bc-90bf-e7998a696b59"), 4026, 6, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("296a82e4-7053-4661-83d1-4dcd04239c85"), 4556, 6, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("299b9f39-6ae9-4107-b8a7-a3518c2665c0"), 4454, 9, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29a58b4b-85e7-44ce-8324-fb893ae3e59e"), 4006, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29d1546c-eb49-4e6c-9e60-1bf3a85e7bad"), 4315, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29e38526-666d-4329-85bd-a20659246601"), 4436, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29e97bb7-9a81-48b5-abe6-67a6be05ec6a"), 4303, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29f65461-4faf-4545-8f9e-50ce3547c25d"), 4307, 6, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("29fa24b0-10ed-4a5d-85dc-95d4b81f3e85"), 4417, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a0f6eca-31b2-4760-942e-ef01cae32f46"), 4606, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a116cc1-bd80-4c20-954f-42ccc7e2f820"), 4109, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a125d47-9795-4ea4-ac9e-7df28601f578"), 4254, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a174bdb-4130-499b-bfa1-c29e9d451c6a"), 4639, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a25a668-58db-4eda-850c-425b1672a977"), 4544, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a2bc827-4fa5-4b85-9eac-ca83453d49e3"), 4415, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a325eeb-b333-4f17-bc46-c7188be6f914"), 4520, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a35ffc4-1bea-495b-8bf3-aa5d8a16030b"), 4538, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a36eb64-2aee-4b38-b1b8-2ba2634536fa"), 4710, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a417b0c-4328-4265-b782-5ad5b971c811"), 4418, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a4372c4-963f-4c00-99b4-dbffc7ed674a"), 4430, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a54ac14-1d11-4b0a-be01-3989f16e7c7d"), 4031, 4, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a595449-e512-4761-8395-c24efabc7f98"), 4034, 8, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a5f3fa0-b067-4e35-acad-194d885fc2bc"), 4710, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a71fe84-2246-44a4-a283-33402505ea53"), 4618, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a7bdc9c-3af9-4a5d-b087-5947f9df48ed"), 4458, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a863aa6-5735-4613-9700-b5be32e97c48"), 4452, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2a982eb0-5dec-4f9b-a888-786cb27290a6"), 4236, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2aa51f35-081d-4577-b10f-f0060b66817f"), 4233, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2aeea734-5940-4a9a-a6ea-d1697484e7ce"), 4259, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b6bee15-4fb9-42b2-81f2-785472148dbd"), 4408, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b770ad2-ef86-4e78-9fb9-c775f3f62b0b"), 4304, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b88d3c3-dee8-42f6-aeb8-a3dd5cf19a27"), 4313, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b8b5dfc-4698-4d2b-af7b-428cfe9badb6"), 4506, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2b97c8c5-1577-4286-9d58-39f58dd1616c"), 4202, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ba6ddb8-704b-4f0f-9dee-5d0c927e4885"), 4638, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bafbf46-b34f-44ed-9703-ec1fd724fe00"), 4420, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bbbf6c3-0191-40ce-9090-98fa6e1f15c8"), 4555, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bca882a-cfd6-4528-a1d4-c58d72da457f"), 4113, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bebf08e-bf03-4d00-8b20-e24ebfe55eaa"), 4804, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bf025dd-85e5-43a5-b5fb-6d80cc8f01e7"), 4521, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bf86a57-3b64-4e03-9e6a-c10ec5a185ad"), 4504, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bf877bd-bac4-4de6-a1b3-82cebbe6ead0"), 4722, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2bfe2b8a-c88d-40ae-9d13-2014d9c266cb"), 4002, 2, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c0c9e8e-d438-4a55-a727-7ebaa8d92f1b"), 4233, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c12decb-cb4b-4762-b26f-5dc8d77e6e76"), 4106, 8, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c3db291-2acd-46bd-a9c1-2672fe64eadb"), 4434, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c6b2b69-9f3f-485a-b73d-8456c029fe2a"), 4104, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c7824db-ce49-4f89-962d-c0e01b68c758"), 4235, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c79a5f2-480b-49fc-8d73-60e596df9d5a"), 4563, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c7a6422-09c2-4b5c-b7d7-a21e6f4b2e00"), 4405, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c8e7f2a-a3fe-49c4-87c2-3ba8a939f198"), 4017, 3, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c946d3f-df02-4428-8289-a4c93a99df63"), 4800, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2c9b6cbc-93e8-409d-b27e-e39b88957b1b"), 4545, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ce45013-7ef3-4211-98e6-7397e415bb40"), 4622, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d0ac134-7695-4eb1-81e9-96c424cdc53c"), 4425, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d0cce4e-016b-4c36-a499-e416a8b4ba1b"), 4221, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d1987fc-c91f-4fce-afc9-330af11818f5"), 4409, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d1fc9d1-5365-4d3b-8b25-a35d717c8fb2"), 4225, 4, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d25738b-c189-4da5-880f-e28af8c0b487"), 4639, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d348d59-7c10-4f76-a60e-31603302ea45"), 4441, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d39e16e-8e9b-4b4c-8c4e-4ef68f3ba5b2"), 4534, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d59678b-2863-49e7-a92d-09f325cd7495"), 4220, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d5a4fa8-b839-4f84-81f7-2e6020e205fb"), 4521, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2d939a11-44ed-470b-a9d7-2ba66493f9bd"), 4611, 2, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2dbc873f-80f4-4923-862b-f7d28f9e0c67"), 4542, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2dde1af6-8370-4e79-aee7-5604b682bf55"), 4018, 9, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2de68fae-e6fc-48e3-b413-741872f9038d"), 4641, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2def479c-b40c-4262-a84d-3fe3ca0164f3"), 4012, 5, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e2cda2e-6018-4b9a-aa28-d187c61b4893"), 4267, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e3991e7-7e02-44ab-983a-0a9e3edd3611"), 4103, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e4edb81-0b3c-421a-8418-240753de393f"), 4432, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e63f82b-f222-41e0-8d58-705fb8ee7276"), 4710, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e64e769-7889-452c-a7cb-f994a95937b6"), 4611, 9, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e8848cc-0b7e-4f97-8d95-10e93997e7d1"), 4421, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e8e694f-8a5f-4fff-88c5-5111681dcd20"), 4516, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2e91199b-bc8f-4f63-94e8-e1c222ec5798"), 4450, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ecc42c6-b188-4a51-9b6a-9ba9f0400d55"), 4451, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2edae0bd-c5e9-4390-b56d-5fcad9ac162c"), 4538, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ee34a2a-16e6-4af5-a0f2-013fbd9825b3"), 4520, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ee95eae-f47f-4524-a72f-4a81a3aad5b4"), 4029, 6, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ef932ab-f06c-43bc-b306-cec7ff69d5b0"), 4565, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f02947c-13e1-4244-9e5e-1a1cc2eee989"), 4021, 3, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f1807cd-4b78-419f-b1a3-ebb9e79312f3"), 4433, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f25bbe3-9408-40f3-b225-feab2a8d9de0"), 4221, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f2769f9-9695-4a55-a2e8-ff17fabc7109"), 4540, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f4558e6-5ddf-49c3-bf0f-64505acdfb8b"), 4266, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f46e943-e137-44cd-8c9f-6ae03223554f"), 4207, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f6656df-5f05-40dc-bb8c-4158b2675fbf"), 4800, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f6dedb3-6434-4197-943f-7df8440aaa42"), 4553, 9, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f6f8834-fa86-4f34-8e77-bbd7b3ce495a"), 4447, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f7fae7a-796e-4e25-8feb-40c642949e3c"), 4214, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f8d7ca3-a476-4eea-8ac4-c8a0f26c4bda"), 4564, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2f9ae70c-25b0-47ef-b7ae-9db57958b3d0"), 4207, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2faeae8e-02e2-4b07-a1d0-9e2b77054531"), 4607, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fc3cf0a-7a4d-4515-b7b2-1f706fbd21d4"), 4543, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2fd28bc3-407f-49f7-bb56-42f185a8cb8b"), 4459, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("2ff65eed-db68-4eaa-801a-fa3b175a0b3a"), 4623, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("300e3e94-ab43-4b02-a180-1bad54b7dba8"), 4265, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3018f49a-adf0-496c-83ad-26230b5f9016"), 4560, 5, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("301d7ed0-0d4d-425e-941d-d59a395f787c"), 4504, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("301fc3fb-4f27-48b1-ad99-368917bc09df"), 4520, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("302c0f28-a377-4846-a836-c5faa8d100d6"), 4660, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("302c11e3-440c-43c9-b8d0-1f1a738603b9"), 4421, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30348b06-bdcc-4009-83ab-3c985d1b1572"), 4547, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30535c7b-b99a-4fe8-9b9f-2e36391b13d1"), 4251, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3075cff3-b112-4181-b0a5-7f09c31e93c1"), 4802, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30768ead-7a31-4157-aa44-8324c7dccf94"), 4612, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30888f70-3281-41ff-a6e2-8c77ad6570a7"), 4600, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("309a2c43-563e-4050-8d30-e63a8ed0c3e2"), 4658, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30a018c1-bb7b-4877-93e9-0173f9260c08"), 4636, 9, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30b003db-79c9-46c7-9f42-a016c3b86643"), 4309, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30b18110-68ec-4dc8-b046-10f0cf2137aa"), 4107, 8, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30bdff9a-4d2b-4c89-89fa-03c6c9ec5a43"), 4652, 10, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30cebe0d-f144-49ac-88ac-aacc4757e27b"), 4523, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30e5f347-3fb2-45a5-95a8-665c8f8acbde"), 4260, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("30ff37b1-15c7-40ee-beb6-ac4190a722f1"), 4431, 8, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3156b90b-04e9-4666-9749-4c0799f5175a"), 4713, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3168304f-bef2-456b-8911-959d8cb1b1b3"), 4269, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3172df8c-9257-40b5-a166-bfaa5174ce6a"), 4440, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("317ae960-a0bb-44c8-8f1f-3af2ce9457e4"), 4527, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("317e3b5f-334f-431e-99fd-1c5a26473642"), 4603, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31813a0b-b12f-4aa8-80fb-9a892b6869cb"), 4416, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("319f7db1-e99b-487d-a314-2a31ed494b7b"), 4529, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31cd7f15-22b7-401d-9993-cdc479310f53"), 4446, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31def33b-04fb-40b6-8d10-c5876bdab7e1"), 4441, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31f22dbe-a09c-4f2f-bfe7-284eb9938e4b"), 4010, 8, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("31f48e1a-c222-4b61-8e19-4c4871ab7823"), 4611, 1, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32122b64-e999-4d19-9320-fa85846cabd8"), 4315, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("321c5eb9-69df-4c71-8286-dd2caad70b29"), 4406, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3227ec12-85ad-4eb4-9f18-64ef2874cac3"), 4312, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("322e4a86-c295-438f-a8dd-e9928835b3ac"), 4850, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("322fd043-3386-4b65-a1e7-21b8e11ef483"), 4650, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("323b442f-2a19-47ee-b42a-68311a98bc30"), 4404, 1, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3248069f-ac1f-4fd2-ba1d-05171c321450"), 4530, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3259dbb6-028e-4751-b7b2-9bfc2dc9b448"), 4405, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("326cb022-f275-4adb-b7bf-d79752f04ae7"), 4660, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3272c5fb-5d92-4dd9-a1c0-ea8e4a5227b4"), 4257, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("327f2c2f-4d3e-421b-b5b7-23bee2e8e45a"), 4537, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("328dab6e-a955-4dea-8755-86f2a5b90979"), 4523, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32a0efa3-c1af-4e3c-8136-8aa42474020e"), 4001, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32ae18a2-d544-48ac-a464-e147dee8104e"), 4024, 7, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32b95328-53ba-4a0f-92a3-1ae4fa73fba5"), 4436, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32ba680b-df0c-42eb-8411-73f300b804ca"), 4426, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32bedcc3-f5dd-4849-b86b-d5298cd74ebe"), 4806, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32c8796f-46b4-4155-a2f4-5d73bbc47e3e"), 4101, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32db1fdb-90c9-4c20-8608-de7ddffd8134"), 4214, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32e2883e-c270-4f6b-9a8c-cbb7775745e7"), 4805, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("32f2714a-3d92-426e-8388-cfc99336ef23"), 4555, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3306b875-ccd9-433b-8809-d94986dfc50e"), 4516, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("330f5b5f-e798-43a9-9d9e-8bfa9138640c"), 4433, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3322dc48-187b-4817-aff8-73188a83e946"), 4810, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33558039-c36b-40ce-b5ee-8e8b01c99de4"), 4244, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("335cb48a-5f54-423f-9575-58e577bacdc1"), 4638, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3383e563-47b9-46f5-8533-6e56835326f8"), 4267, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("339c0ff3-fdbe-44b4-bb04-8dfa63e76b2e"), 4272, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33bae408-1957-4eae-92ba-e445ff7b7346"), 4002, 5, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33c63e80-3789-48f6-9635-c258e7842fca"), 4565, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33d85a9d-9f4f-4108-8820-7f2343d74bdf"), 4563, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33dd5561-e0c6-46d9-b7f6-81a2e637fb3c"), 4851, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33e1be94-bc9f-4cd5-b837-ddd836754beb"), 4115, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33e3cbd7-77e2-4a83-b380-d7e669619573"), 4258, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33e8426f-43b5-4d93-a982-1023c1564180"), 4224, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33edbba5-bad5-4cd0-b2fc-df964249a977"), 4247, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33ee6af3-4b5f-430b-8e73-e5752b8b625b"), 4247, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33f83fb7-1a2d-4d6c-8481-65354fe3030e"), 4434, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33fa1978-41dd-454f-b75c-1528a5ca8ee5"), 4235, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("33fcc37c-295a-4169-bb73-13ea9c661a8f"), 4235, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3410f056-c2a8-4581-b364-3d21f6305bc9"), 4608, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("341b524a-0e1a-4537-9d02-9f9ba89c3879"), 4037, 5, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3447fcb2-221f-4762-9179-e5a0c5e07442"), 4540, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("345cd4f1-51cf-4b4b-a7cf-b40334adddbc"), 4101, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("345dc829-6444-40fb-a480-0a31cfd2d08e"), 4239, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34616b5d-890a-4bfe-8f4b-006bdf1d39d3"), 4302, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34700201-a4c0-4967-85df-9594f2413e1d"), 4805, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3470af50-6626-4737-9e5f-8781e0d32224"), 4653, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3485e6eb-e407-4ff1-8a62-5fb1bc379210"), 4534, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("349a3921-f00f-4765-86ea-2f64e6702f46"), 4114, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34a2c32d-62cf-4869-a35a-d0a03507e05a"), 4617, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34a356ec-4be5-42be-aed7-76f976e8de20"), 4229, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34c2ae35-6186-4979-8acb-9cd5db1e4c26"), 4102, 10, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("34d3c437-9b4e-41ea-825a-e3d189a0ca44"), 4014, 7, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("350050e1-79ef-4054-a5dd-841a3bca47ad"), 4108, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35291463-5f40-49bd-9b35-11e3827b5176"), 4434, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("353db2fd-73bc-43e8-a1b2-3d4d310c75a5"), 4614, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("353f261c-2dc5-4134-93be-5f0f24a0e6e1"), 4014, 6, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35400a07-2e80-4e93-b253-2e237ff5ca2f"), 4710, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("354c7295-3141-47d3-815e-67eab17168d4"), 4640, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35501cf8-675c-4caf-b881-dc56615ae6f9"), 4248, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3557dab1-f4f3-4fc7-aeac-6ea8557decab"), 4650, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("355f49a1-c66b-4875-b64e-b0d7483a4121"), 4660, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35629a59-0b97-4e9f-9892-2819f1ccb1af"), 4718, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("356cc5e0-6850-49f5-a55a-9d9c1005f621"), 4656, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("358943be-71e6-4717-8e78-094ca1aab7b3"), 4414, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35a37f91-9ac0-47f0-bba0-3eeec515ad4d"), 4306, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35b43c59-1757-4350-b6fb-69283d8fe0d1"), 4634, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35bc6e70-eaf6-4edd-810d-0a2258a55125"), 4269, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("35d01743-2cc7-475c-8765-b1bfa7b73ceb"), 4632, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("360b83f9-685a-4704-9cff-6ea05098986a"), 4655, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("361035a7-9351-42f0-abbd-9a3b657afa0f"), 4537, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("362eaaef-535a-4311-ac0c-6f762ae552c5"), 4450, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("363bb4ff-c657-4b64-9035-973fb5fb7780"), 4029, 10, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3642d21d-48a9-489a-80e6-853f709491f2"), 4457, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("364b92a2-1336-4224-b184-e0d08f714521"), 4454, 5, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3662f7f7-4478-4a6a-92a7-6b2ccbe40cbc"), 4809, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("366500c1-4962-48d6-9367-10f213e591ad"), 4407, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3674464b-8081-4023-927b-d360ca88b94e"), 4709, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("369a6e91-1840-4219-a866-d665b873c85f"), 4409, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36ca2c44-dd0d-45d8-86aa-5282732cd78b"), 4702, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("36d67989-e230-448f-8599-7455de3a37a0"), 4268, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37360e3b-0627-4628-982d-f7b505b1f8d3"), 4406, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("377df84b-2043-4645-9cc5-cb8395470a17"), 4026, 2, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("378d9883-448e-40ed-a827-e8b166c7bcb2"), 4432, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("378f45b0-d10a-4ce5-9de3-9a743eba1b1d"), 4440, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3791030f-db43-48b7-8303-b3611760e639"), 4317, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3792e9b2-1803-46a3-af02-685ae3c0eebd"), 4314, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("379b2d94-c2b7-428a-bd6c-729eacc7c440"), 4108, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("379b47f5-a6e4-4d76-82d6-5edcccee56a0"), 4638, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37a56946-5782-432a-ae7d-72e41b09cef2"), 4465, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37aa62e6-f8bc-4449-870c-866ec245b0c5"), 4304, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37ba1efe-e66a-4f25-9f69-834efb11723b"), 4704, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37bc0cc1-d074-4358-aae0-b4772ac5dde9"), 4027, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37ced424-d824-48c2-aec6-0cd0859e6a66"), 4601, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37d0057b-a4f9-479f-8cea-a8aa36fda1ff"), 4458, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("37e23148-31f8-404f-b4f3-db7012b705ad"), 4252, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3801352c-a656-4b95-85bc-44797eed9dce"), 4308, 5, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("380201d6-afc9-41f7-9fca-9949ded98d67"), 4707, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("380b5b60-995b-4edf-b7aa-88981196c7e7"), 4507, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("380f5c40-7266-4db4-a1d9-de1f7ad2f37d"), 4405, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("381890ca-2a08-46c4-8a62-1e24660aeab6"), 4214, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("381bf5c8-bdca-46c1-8971-5ce20a6ada97"), 4308, 1, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("381d0142-7a2b-4885-9fc1-384c8f343f6e"), 4713, 5, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3829f789-570f-422a-acd3-77a85ea40a89"), 4554, 7, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3833207b-66fa-44d3-879c-216ef59c57e3"), 4003, 10, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38450169-78dd-4446-9893-d23c5103cd0f"), 4805, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("386c1f56-8084-48ad-820f-221347f70e36"), 4113, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38a22ab5-b8fc-4313-a295-ba6219ceba79"), 4403, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38bb5905-e9b8-4e4b-a659-38789d1fe28a"), 4001, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38d0d395-2040-4c5b-a349-9ddffe85c413"), 4711, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38d63d5e-42ae-4f7c-bee8-b8eb05b16ea6"), 4851, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38dbaf33-f7b6-474d-b012-7442d758a200"), 4220, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("38edb53c-9d24-415a-b3da-0982b925b8b9"), 4636, 8, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("391afd20-8b5e-421f-ad47-c37215928e5b"), 4615, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("392b277d-a0e2-490a-8db7-aa7ed3d3f2be"), 4852, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("393284b8-ae61-40fb-a470-9dba6d99eaaf"), 4512, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("393a86d7-43ec-422d-90a6-3ddf82a51dcc"), 4539, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("394487b2-8c18-46e8-8916-bdac244436eb"), 4263, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3946668d-4289-4c99-91fc-66d733e6a1a1"), 4004, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("395e8730-3a21-4df3-a8b6-aee4212e2074"), 4704, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("396272b2-e61e-4e33-8443-f403f93280d3"), 4557, 6, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("397e1d20-7936-4fce-86fb-27b19db79700"), 4530, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("398dae09-9526-407e-8042-fc6a870523dc"), 4216, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39a3db95-b3bf-455c-995e-2b106339c6ad"), 4403, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("39e5953a-c7d0-47af-8817-fc24ab0a7ba2"), 4012, 9, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a21a5ef-9434-4a35-8f60-992f1520b63f"), 4530, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a321152-6199-456d-9126-1079f90e5748"), 4557, 9, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a4ee0d3-0449-4325-a732-6bec44a1f572"), 4545, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a4fcff5-e356-4a13-abf0-5917591aa2b6"), 4230, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a5a01e6-e7d0-4862-bde7-9aef5c344a49"), 4627, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a5ec183-53db-4c86-9b09-c17a4b770361"), 4714, 4, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3a84386a-f1ac-46a5-abaa-6c05acade166"), 4535, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ab64590-1981-4803-99e2-93c6c1712b33"), 4437, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3abd528c-f3cd-4981-bee4-e3966f106961"), 4103, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ac8cf17-0e6e-43f2-b40e-20c82c533e2f"), 4415, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ad2db21-3071-41ef-aca0-6b7dbe5e376b"), 4700, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ad42dc4-6800-4a84-926f-678ab7b97bad"), 4538, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ad46d11-4adf-4022-811f-fed567117e98"), 4318, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ae09dcd-0a7e-4eaa-afe4-9e0edc46afb7"), 4536, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ae77be9-d0a9-4ded-a24b-25dd423e2f7d"), 4224, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b028583-61c3-49d9-84e0-9d70078f105b"), 4804, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b095cc1-e6d2-4bbe-8303-e33bb202f8dd"), 4113, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b117f33-97ee-4c12-add8-b9bf869fb2bc"), 4265, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b28a066-8028-4ced-9f07-1b09780253a4"), 4533, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b310256-c5c2-408e-9820-c606081ede71"), 4256, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b505580-2806-4d87-b61d-7a0dd2b2368f"), 4655, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b73c75b-5a30-49f6-b357-e711f95ad0bb"), 4209, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b7d2281-7dad-4aa7-9834-95a5844663fd"), 4611, 5, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b7d4ef9-920a-4b3c-9dbd-8cfd3469f53b"), 4031, 5, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b805c47-52a3-47b3-959e-a4f2db16c0fc"), 4234, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3b81d273-a4bf-4e63-a20c-5c683661b7e8"), 4238, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bac980c-c669-43fb-b758-568320d45a2d"), 4265, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bd72751-9d13-4615-9e8e-198f31b7d61d"), 4514, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bd9fa9c-b1d2-458f-aab2-959176bc6e2e"), 4653, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3be11db0-4569-4e3d-aeb4-5a9abddff129"), 4525, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3bf90c7b-4341-48d2-af96-2936cf1ad2ea"), 4407, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c05d364-2e93-4f43-bab6-4560801aebb9"), 4021, 2, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c09a496-1a97-4bfb-9067-d39761ee24d0"), 4430, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c1254ed-bf54-49fd-bb50-f01d1f02ddf6"), 4204, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c16c662-e24d-4bda-96fe-b3373fd7195d"), 4801, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c27e699-c707-4b3c-9813-1b6a789d1a05"), 4516, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c39faaa-d0a2-4e84-8c2a-a9b08e7142a3"), 4617, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c45559a-8ab1-4893-9fe2-18e1bf7afade"), 4252, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c4c73e3-2f76-47c7-b2d5-1c4b5195d0db"), 4515, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c73dc36-1a65-4119-9913-76bae2a1c244"), 4514, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c8a50f7-af74-4b21-8bfb-fabd48703b25"), 4705, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3c906397-5418-4985-a181-0f2767f3a0ab"), 4620, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cbcb719-d4f5-4388-b131-98a003107886"), 4604, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cc3559b-c8a8-4609-a3be-f55d17d018fa"), 4640, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3cd2279b-c34d-401d-9023-414754050c62"), 4531, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d0d1b61-f985-458b-bac3-e5aaaecad913"), 4026, 3, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d36193e-cb18-4eda-81b3-30166d19c688"), 4542, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d3b0b6d-e3e9-419f-ae13-292b39241a33"), 4639, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d49af15-44c1-430e-8201-6ba80259c4c4"), 4249, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d5e0631-f934-4a33-861b-14529703f08c"), 4721, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d745e0c-3793-4afc-b782-77a9f80badfd"), 4700, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d80c231-8c47-48c4-bed9-95a23e1af02d"), 4641, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d91be34-230f-486b-8f58-ebd8ea8e2c21"), 4603, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d9b8b69-9682-4b17-bf63-8b24422a4aad"), 4242, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3d9ea288-1511-47cb-8639-c4e0ba17b981"), 4453, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3dd02260-5278-44f6-b3e4-19596f023a0b"), 4004, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3dd5ed2a-9c27-4591-9f9b-794ae00e0a67"), 4320, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e01f1f3-17ad-46c8-91d6-5e1cf1c0a8c3"), 4446, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e1bbdde-2544-4b56-b05e-15de59005daf"), 4410, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e31cdc7-7147-493b-9a66-a8f999b54276"), 4626, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e31dd24-8267-4503-865b-a7bb0bd6b398"), 4213, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e58f40b-59b7-419a-9866-0d9a2f259206"), 4030, 4, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e5902df-e90d-47ad-95a1-84d73c4dd542"), 4319, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e6fa4c5-d5b1-40df-a067-60574aed0421"), 4250, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3e8f994e-3f24-457c-afd5-30d0a77f3033"), 4405, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3eb1ec67-2a91-4504-80d3-309bb9e316e4"), 4400, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ee1d70a-1aee-4c52-a2f5-2b0956ea44b8"), 4512, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f0948fe-a822-4b4e-a62d-016409b7a0ca"), 4007, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f24d148-8126-462d-9146-7e8576e60545"), 4855, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f4c5811-ed9b-4544-8c05-a5d6a57f20aa"), 4411, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f5c5ddd-d2dc-4e74-8106-d7f8753e4335"), 4415, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f7161a9-56d2-4042-8956-f5d503a02aa4"), 4425, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f73e8ed-3c97-4691-af61-eb073d8bd525"), 4460, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f83f9e7-0e13-4b8f-9d33-9867b73fc595"), 4619, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3f9a5fdc-a5c8-4969-a4ad-1768eb31aa29"), 4703, 8, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fa0695d-9c8d-48f4-b723-fd88ec125833"), 4200, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fa5f4eb-7de0-4a5a-be87-212d0ba4a907"), 4636, 7, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fb4dc32-5d1e-4dc9-a5f6-733e3028e74d"), 4703, 10, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fb587e8-b656-4da1-a449-054a7164cae6"), 4508, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fb8703f-a61c-4539-bbec-86297ff1a138"), 4561, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fc59cad-bfcc-4f2c-ad45-3a5f2d22e603"), 4661, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3fd47c16-bf84-4a28-8c29-dd4a5d9f47e8"), 4656, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3feb6194-3e0e-42e7-b638-fbb281f2177f"), 4419, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("3ffcc1ac-6e91-4dca-a158-8e7b474eeede"), 4636, 4, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40138912-5c47-47c4-bf41-7822daecb54e"), 4314, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40182efa-fe3f-44f0-bf74-392a5d246e8a"), 4804, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("402f46ba-760f-45e5-ae8e-e4f982dd85d7"), 4543, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40549c29-73b2-45fe-b4a9-9a31fb61ade1"), 4310, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40591462-336d-4e7d-9212-3027ac1c99db"), 4210, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("406c7759-616e-4bbe-b74d-dc9736a26795"), 4025, 6, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("406e50d4-beb5-4a9d-90b7-7c8243f40b3e"), 4021, 10, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("406fdcb4-a191-4fdb-9dd8-8cd96e80f2ed"), 4522, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4078e5ac-45ad-4b45-9619-8d5ad1e512fb"), 4547, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("407aca8e-b226-4eb3-89b3-94676250d2ae"), 4261, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("407ba63f-42a6-4fb9-b6cc-595747a6ece3"), 4400, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("407e66e9-e247-447b-abf1-910d7c366827"), 4108, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("407e9c6c-dc82-43d8-8b94-f859a45077b2"), 4462, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("409b07d1-30f1-4e94-af48-0a61b6286de5"), 4245, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("409caa32-5a19-4b6e-8a39-023c3e17e34c"), 4015, 1, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40b2be8c-cfdb-42cd-bcea-aee63179cbe3"), 4447, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40b96644-0166-4565-8e23-33951b6b04b6"), 4208, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40cf7ba4-9ec1-49bb-a444-a094d091a023"), 4310, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40d356f2-dafa-4993-a3c5-d1ce6ae191e1"), 4636, 1, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40eab891-7892-4ae5-a900-ce15a8437318"), 4640, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("40faf3cf-b3bf-4921-9201-5a8854358649"), 4418, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4104d16c-8689-48f6-a34e-9ba2b6f5495d"), 4235, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41110c0c-dc43-410b-9cde-2eac54bd07a2"), 4205, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4125d863-aa27-434a-9da1-031f281ad648"), 4406, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41335990-2c42-4195-8e82-11de8ba3d1f8"), 4215, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41359111-eac4-483e-a6a9-f4ff702e1abe"), 4026, 9, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("417389e9-6064-4657-ba55-962e0c519a30"), 4013, 4, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4187b00f-f28d-4150-a289-9abda9d35668"), 4265, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41882eb9-a89f-40cd-97b5-48a578f65634"), 4209, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4194a5c9-ca6f-45ab-961e-0b784afd6e99"), 4856, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41992953-28e3-43e8-b968-608580993a8d"), 4234, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41a6dd9b-cccf-42bc-af26-a60520dd235f"), 4250, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41b76bef-1d73-4cf1-9af7-03c39014fe6f"), 4218, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41b8b11f-ba34-48b8-a839-721e80b920e5"), 4262, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41cff54a-83aa-449c-885d-e73b75ccdcb3"), 4016, 9, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("41ec1f68-1e33-4ec2-9358-2892a3f1b98e"), 4302, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4263e62f-805b-4f94-87c6-e047dde36843"), 4707, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("426878d5-81e4-4d3f-b062-64409d694b07"), 4535, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("427f7422-4a71-4168-aef9-ce6b85e0f899"), 4033, 10, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42836696-c6c3-4c6b-b228-a2cdc875cdd2"), 4520, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42913ae2-080b-4460-96f0-4f55704f79e7"), 4255, 7, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42afcc85-a3be-4e04-b9ff-a3d11ec906b3"), 4220, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42b3cd7e-a4fd-428c-8021-fb50c2badf7b"), 4203, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42c075f3-2193-48f7-a4e7-fdeb18d14465"), 4309, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42f7f720-3ab6-4743-9f55-0661f82cf08b"), 4652, 2, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42fce5f0-657b-48d7-8328-6f6b157bc6aa"), 4454, 6, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("42fd6c61-cb73-49e0-a057-24b4747934bf"), 4235, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43070f6c-7e6c-4bf0-a061-bf9eb56b1aaf"), 4720, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("432a8705-51a9-4da9-a925-ba8c7d641784"), 4413, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("433cbfe0-d629-4754-8821-6235ca5033fb"), 4442, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("434938cd-1980-4821-aa12-d05182880201"), 4262, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4378d698-72ee-46e4-86a3-34f68b84fce5"), 4463, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43a054e1-8236-4d02-bd05-ac479377c417"), 4564, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("43dc98c2-4de8-41ad-b6b2-09cfe3b6ca7a"), 4653, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44303825-6f46-4b26-a3b1-e7a8b2ca4bf0"), 4109, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4444bc3d-1a57-4f5d-afc8-34b8b040ba02"), 4650, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44563002-0232-4b41-961e-704d3c3f4431"), 4618, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("445d59d1-2199-4409-9f44-20ff9d88f92a"), 4505, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("446f984f-9fb7-41e9-bf1d-82df391ca0a7"), 4027, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("447b7966-4e02-43fb-921a-b729c888b89e"), 4515, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44a035a5-93d7-448b-8be8-776e1402115f"), 4559, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44b23dae-d8d1-4daa-93bb-7c11702ffaa3"), 4024, 5, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44c2f27b-2412-48a0-9a9e-e6cff55a7c3b"), 4624, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44d610cb-97ba-4373-812c-a2c0434a882a"), 4025, 2, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("44ee125f-ba90-44bd-9e35-f5a4e9e6ec21"), 4534, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45494446-68d8-4fe5-8ad8-a7b8a2fb3b27"), 4304, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4551db30-6760-4046-a679-f3a9b78e6fff"), 4301, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("455755c3-9b9b-4f39-9cf8-3783d5e857d1"), 4114, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45704c2f-98bb-451e-8983-44c11e4e8a98"), 4100, 1, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("457ccb21-39fe-4eba-941e-4f005c65a1a2"), 4102, 6, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4597e64b-2b5c-4465-900f-c88e52c5b9b2"), 4502, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45a0b037-d259-45e0-9ed0-ce9eec076809"), 4610, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45a2c63f-9a7b-49a4-805b-0b5a4a964fd0"), 4611, 10, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45d5e713-863d-4f26-b5f8-1cbe5edf0683"), 4704, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45d931c0-0986-43cc-a469-d6da4889ee81"), 4214, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45e6b1d0-e6e2-4032-8cd6-99896ba93a24"), 4452, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45fd3429-179a-4b30-8a9e-f120f18f8d36"), 4629, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("45ff8b75-b257-4627-a8a5-396370460f93"), 4501, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46112113-b761-4dab-b9fd-95f10a2bcca2"), 4213, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4627baf5-d139-48b0-96dc-ad5c2cde5f7c"), 4501, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("462e4f0c-4446-4ef4-a0af-69f36b08a9d5"), 4535, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("464505e0-8eb8-4d2b-95aa-6cd394848ea5"), 4322, 3, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("466a04ad-b272-4e45-813f-a22521431d25"), 4805, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46a50988-1a1c-4ba5-9b5b-bd89bcf94b86"), 4856, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46a76336-2354-459c-85ff-4a7d47349cee"), 4506, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46b566ec-9f11-4b96-aea5-1bafcc29fcab"), 4000, 3, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46d97ffa-f1e8-469b-a64e-4c09b694133a"), 4110, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46dd7ac5-d405-450a-bf56-089f38e561a1"), 4401, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46e2a4c5-6216-425f-be0e-7652571f3d41"), 4521, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46e6a3c0-8e18-4a71-977e-a9a382d68723"), 4706, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("46f89b0f-dadd-41bb-ba4c-e91fffda5fb0"), 4442, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47168f6d-e8bc-4abd-8712-4a2bfcbe8758"), 4610, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4717838b-869a-4dc0-a183-fcf06bf86747"), 4264, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("471a99c0-c4e3-4697-a421-78e5d430af6a"), 4247, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("471e5933-3084-46f5-9762-3226fe6e0edc"), 4512, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47226c08-103c-4285-851c-cf7909725cbb"), 4505, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("472b0874-5dc7-4ff4-b59b-c8190af4a375"), 4005, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4760c8d0-a53a-4e79-9b40-059a3b72641b"), 4301, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("476c70af-1580-4df5-9b73-ca41c71d1aaf"), 4003, 7, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4784b357-5f21-4809-bfcf-d2f1becd4111"), 4434, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4786c53d-3d26-42c4-adcd-064f9cd1f81f"), 4438, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4794b8b5-1099-4828-9cd0-3fcc6a094847"), 4030, 9, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47999cca-e36f-4f9c-8eac-ad92968c90ef"), 4464, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47a5ad1e-aab2-45d2-832a-f1689114580b"), 4204, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47b78c21-72db-4adc-875f-575150ac7fac"), 4216, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47cc56ea-ea6c-49f9-a02a-8e52b6d9acd8"), 4540, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47e5cea1-6d94-4095-9106-dbafc2e0054a"), 4266, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("47fd7370-b8e6-40c7-aedc-e4e5754e6a8b"), 4663, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("481a7d16-8cfc-41f5-a70a-5865ca3b96ee"), 4016, 8, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4846b93a-d164-4271-9881-d84ea87d0fff"), 4523, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4852c56f-b9cd-482b-9ddd-57f1aec90ac1"), 4316, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4866acad-a619-4759-917d-eb40f6c5af50"), 4510, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("487112c6-a67a-43cf-ad0e-582547933341"), 4810, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48729e64-9fbf-48c4-870b-5ebb9d58de86"), 4714, 2, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4873502d-7b28-46f6-9056-9e08d0dcb37d"), 4531, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48758843-3091-4855-8f6d-bfad3f8405f7"), 4802, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4899f644-f9bc-4230-baca-ad3e23da68cd"), 4609, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48a05e4a-60d3-469e-bff5-7e1790c80961"), 4638, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48a1c392-d1e0-4965-9ea7-99437eb657c2"), 4234, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48a904ca-f4d5-4d3f-ba5c-f5fc3d9b668e"), 4651, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48c50ac7-ab42-4ddd-9789-75a5a34cf7c9"), 4628, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48c5f5f8-70a4-49b7-8f6c-356104cea93d"), 4637, 10, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48d631a0-1f91-4c71-ba54-5771d81f2381"), 4526, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48deedaa-9179-4f1b-bbcb-df05b91b71fe"), 4806, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48e24bef-f897-4520-9b0a-ec9ba91a3c81"), 4564, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48e4378d-fd02-4af5-9379-ad855bf097b0"), 4101, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("48e6ec98-f255-45d8-9e16-e1871ad237b7"), 4260, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("491d7286-0469-4cf3-bae4-2da9d6b4e78c"), 4271, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("492ce647-d42f-453d-b6a6-7bc499f4c9ae"), 4226, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4930dbe5-57d7-44c6-bdc4-2a2f93f63fd2"), 4021, 5, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49453c07-9d54-4229-81b3-96eb3ed85243"), 4702, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("494c07a3-ae0a-4fa2-884e-80eda0beb41c"), 4856, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49501138-e813-4cbc-84cc-67a659a808fb"), 4321, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("496157f9-faac-4fef-ab2d-de1aed407289"), 4532, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4967106d-cdce-429f-a228-6d471a51cdbd"), 4021, 9, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49a77a6e-dd8b-4542-8190-84197c991e28"), 4307, 4, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49a791eb-79f0-48ba-bdb2-b839e545f6d9"), 4304, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49aa8fcd-4643-4144-90a1-59323dac5b27"), 4306, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49be5d82-38cb-46de-9b04-291f7b314ce5"), 4455, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49c669df-4c8a-4374-b872-e0f205790056"), 4805, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49c751f7-5900-470f-9d33-f0c588963524"), 4251, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49caa0cc-bc02-473c-bed8-f49cec9e8ce6"), 4624, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49cbb2a8-acea-4618-9c87-b38da54d9882"), 4723, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49cbe0ce-942c-4c35-936a-a7fb18d5c9e9"), 4254, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49d46bff-f150-4e1c-8e9c-7a88f6353bcc"), 4623, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49d892a9-02b5-4641-965b-8c3792513504"), 4211, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49d8c2d6-3c1d-46d4-9709-1ccd8b442a1f"), 4111, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49ddb65e-05a1-4b44-99ee-7157bf5aee0a"), 4013, 6, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("49fe1b02-817a-4cc6-9e3b-c44851d53bf7"), 4656, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a3054be-1f3f-4f6a-9778-e2326b49bc79"), 4231, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a34b6c3-7192-467a-b66e-36c317f2b001"), 4464, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a3aefad-132c-4a58-9468-26b005e0bb86"), 4618, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a5df114-0963-44ef-806c-aec757f5f8a6"), 4228, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a66ad0e-341c-47a6-9dfe-a4680897bf7b"), 4804, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a9975da-9271-43d2-a29b-7b2c60830f5e"), 4855, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4a9f37f1-ea39-4f90-8319-56c1ad297a31"), 4408, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ab17b8c-0bb9-49a0-9235-69ea13ef9d84"), 4015, 10, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ad368bf-595f-47e8-b3aa-096ef2448c89"), 4613, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ada754c-3ede-493b-a3b8-e19c36dc0043"), 4253, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4adc779d-d59c-4d1f-ab76-aa4c7ef6a809"), 4231, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b04ef6b-bd43-4d0c-ac4e-83f9f80f7b68"), 4459, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b0a324c-9c7d-4a7d-bc1a-92066de215e9"), 4639, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b23ad3f-1ccf-408a-b294-8946624375ad"), 4444, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b23eba2-729f-49c4-85d5-8358ca875db7"), 4444, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b2574d0-e589-468c-8408-57e04e94fa11"), 4605, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b3c66bc-8b86-407d-a789-36fc49e8e360"), 4710, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b3c71ce-a5e5-46f5-8704-f437650bcb6e"), 4242, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b3cd7fb-dbfb-48c9-9a8c-30617980870d"), 4402, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b42eece-f61f-4220-a23d-7a92857233a9"), 4622, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b464362-cbbd-4261-922b-da9ca79c13d6"), 4111, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b47f6eb-096e-4ca5-8f7c-00bbd59da5ed"), 4430, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b49d0c3-d556-41ce-91fa-f61a7af59179"), 4440, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b579ba5-c519-4c6b-9dbf-2c9bdad6c9bb"), 4100, 5, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b5c855e-363b-413a-9804-e7097db8fa7f"), 4602, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b60465f-0ff5-40da-8760-fc727f236997"), 4555, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b613d46-0e68-40b0-815e-886ce1833f13"), 4705, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b6911df-43b1-4356-bc61-d1aa7f601cd5"), 4403, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b6a53f2-d0a9-43f0-8801-31fed448b04e"), 4245, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b6e6826-aab1-4c90-a71c-fec49ccf97d0"), 4263, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b864697-a254-4160-897e-929cba6e6c73"), 4258, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b8729ff-ff4f-4c62-8086-cac585f10bd8"), 4273, 6, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b96c86b-9630-4cba-94e1-adaef15c6d8a"), 4274, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4b9c1441-d1d3-4b08-a322-cba97c513540"), 4320, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bb17c77-a94e-4c69-b77e-f8fce11ea2e4"), 4540, 6, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bd50fbc-ae5e-497d-af38-c228ba663db3"), 4255, 2, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bdadae8-78d7-4c54-85a2-eb424d67994e"), 4105, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bde110d-d67c-41ef-b4df-920ec45cbb23"), 4406, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bf8dfb7-3580-4009-82f9-8868458f74e5"), 4301, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4bfd0ca7-4d95-4aac-a95f-48db89127668"), 4421, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c064ffb-1c32-460e-ac99-31c7c0f9c2cd"), 4445, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c09b11b-7216-44a3-9436-2f69cd71b3e0"), 4414, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c12f638-bb32-4963-afee-6f5563509529"), 4308, 3, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c20181a-9214-40a9-ab18-e5ea680af7eb"), 4626, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c2f8cb6-9540-4df0-8d3c-f7b783ac0a20"), 4807, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c31dec3-7cad-4f8b-9a4d-b324f1e41f30"), 4628, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c516d38-4fff-4cc7-9352-923d30a898d1"), 4311, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c59a049-4903-4ac4-a951-ab41c12297e2"), 4321, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c6cac16-5a8b-4454-a2e5-79db573acf11"), 4262, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c755758-28e2-4920-b89f-6427f01658f0"), 4406, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c8166e6-1b5f-45ad-8f60-a1e0b4cd9018"), 4257, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4c830082-aedc-4724-9e10-0c450108dcdd"), 4223, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ca1beb9-5014-4cc2-a96b-fd84fea423f5"), 4609, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4caaffda-75e8-4653-b3b2-617aab8c28db"), 4529, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cb47ac0-7339-43cd-be78-267a0786d178"), 4254, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cb9b73d-6ede-4f35-9b71-7b28eaca35cb"), 4211, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cccdbb1-1311-4c69-9431-d905a8d3ab0a"), 4451, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cd50624-215f-426f-ad40-6cf90736e67f"), 4402, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4cdfcaf8-ec43-44c9-a1fa-4859979a01fa"), 4114, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ce54ab7-3180-4ab6-9053-6b1038118f51"), 4555, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d1463a0-7db2-4649-adf7-233b0d98abd9"), 4608, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d348b70-c163-41f3-abc1-47634ef0a5bb"), 4538, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d4061a6-cfb4-4865-b1a6-99cc173ffc2e"), 4018, 10, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d4fe49f-b034-418e-92a9-8dc4e73e51e9"), 4702, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d583771-322e-4d6d-8f14-28b5c270ab0f"), 4012, 7, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d60ada8-869b-4989-a621-392b5ec760a6"), 4029, 5, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d677685-1602-4cf5-9d11-05cf909b07c5"), 4428, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d6f1e2a-0d3c-4d50-b915-448078d7dba3"), 4603, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d85b829-fab9-471b-818d-b7e71ba70b8d"), 4322, 1, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4d8d15a4-15c3-4d40-b92f-af53b414c415"), 4303, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4db00c8c-ec3e-4b0d-8259-05a056e3537d"), 4802, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e0b5360-cb4b-4ac3-87ba-908a5e298c1a"), 4401, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e1dd9e2-017b-4a1a-a95c-940c38ce99e7"), 4561, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e338a25-707a-46a6-ba0c-97d58d37466e"), 4546, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e3f2c89-d122-4405-8ff3-43ecbdf93183"), 4225, 3, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e40c858-bca4-4bb1-8041-da169cc66b24"), 4540, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e527bd3-5a59-483e-b680-9794a5b56368"), 4324, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e7578b3-2e87-4e3c-97e8-d741aae770c5"), 4321, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4e79e269-030b-4b04-b575-ca275c7e1efa"), 4437, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ea3cd51-6aaf-47eb-b4df-09bd9169a7f2"), 4500, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eb83ea5-7bbb-4050-b0b2-d619034a5a88"), 4722, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4eec05bd-d583-4d38-be8e-2dde879fc7a7"), 4319, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f0c6efc-a361-4a2a-b1b4-9679c006d37a"), 4659, 10, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f0cdaa3-82fe-4fa8-8a57-8d790de3218a"), 4632, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f0d1ec5-5376-42ed-a39b-b7d312d9a9ed"), 4016, 7, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f1f0498-e7f1-4e6b-8a3d-f31c27284b6b"), 4452, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f35dd2b-9421-47cb-96a3-c72efab5aeb2"), 4443, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f37ddcf-5c7c-4a8c-94aa-9c18b9838981"), 4215, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f55e4d8-55f5-4e33-8c95-b7b97e32237e"), 4631, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f5e1334-5e0e-457a-b760-4472ab3ab0a0"), 4002, 6, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f815685-73c1-4b81-ad2c-326604b3402d"), 4619, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f863b86-caa3-4da2-860d-224783eab332"), 4412, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4f966f5b-5001-4d1c-aef7-5ea015ecaf0b"), 4404, 10, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4face042-ec55-40e0-92f6-13f2accaaed5"), 4025, 8, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fc2f2b1-f37b-470f-8f6b-fbe4ea6b479b"), 4256, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fc9ed31-01cd-4a3c-89d0-17b647deb3a5"), 4406, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fcf3c82-32ab-42a0-b48e-eed513360021"), 4502, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fd0d8ba-7c5d-4ee6-b9b4-4a296078fb1d"), 4104, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fd57136-337c-4f8e-aefe-59e65669cf0d"), 4235, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fdacb1c-8efa-434e-9e31-9bef5da5eae5"), 4454, 10, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fe1f247-fdca-4f54-bfa4-be6ac3c08ea0"), 4103, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4fe3d37f-e385-46de-ad1f-1424252584c0"), 4523, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("4ffbaa3d-c4d0-4a0b-9673-36600ccfacee"), 4018, 2, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50177f33-fc83-4174-b5fa-d8af4e0a82d6"), 4452, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50254d9c-76fd-41f2-b51b-db3bf9fd38fd"), 4241, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50456839-6a4f-4f14-aff9-d0b6d7e0a5a1"), 4004, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("504aead9-e217-464f-b66a-d4cc347d4b8c"), 4037, 1, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("504cbbde-3599-48cf-a36e-128906949611"), 4429, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("506a878f-da57-4fdc-8798-c6ecb1a052b5"), 4522, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5082254a-6406-4efa-8241-1129bee3dcfd"), 4207, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("508b32d5-3fef-4999-bc77-2a8990c70b23"), 4430, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("509d4f3e-607f-4e21-90c8-6bd143580ddd"), 4556, 1, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("509d5100-b81f-497f-8378-aae0ff3e3fef"), 4316, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("509e99ff-3b9d-46c2-9ea4-ede3dda609d3"), 4415, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50b2c14f-b473-4c3f-bbea-2b8f5426b2cd"), 4545, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50d26279-64bf-4f9e-8fa8-67fd6f381f5d"), 4410, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50d7ec34-56a6-4346-8dc2-5fe5fc6038bb"), 4556, 9, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("50e5b58f-d823-4437-9a09-6c7167ef8e56"), 4218, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5101185f-f961-4f56-8b3a-ed3e5fcc386e"), 4301, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("510b74eb-4be3-4eb0-9a6c-ae8a84869b3c"), 4853, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("510d34e6-0768-4de1-b643-1b0e8f0fdd9a"), 4018, 8, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5114aaf6-cfe6-478d-8a21-06257d339b1f"), 4009, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5114e3fa-ba35-47cc-82db-d48dc0223d19"), 4620, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("512ec17a-2974-4d85-8c57-e6abeb17b16b"), 4310, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51438681-7a8a-4f46-bd44-b74b404e83c0"), 4606, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51457304-3eba-4ab7-97a1-3deba51dcff1"), 4314, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("515efc23-218f-464a-b343-3a8eb4e11e07"), 4437, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("516bc469-b7f4-4912-b8a0-6ab4fc43f99e"), 4708, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5174ee7c-1b15-4f23-a6af-8b01694fca19"), 4562, 6, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5178386d-a6b8-4e40-b2fd-78b0e07050af"), 4533, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("518b6720-b99a-4668-b8a8-65deea15ee8e"), 4850, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51b511e3-5d74-42b3-adf0-445bab192f6b"), 4106, 7, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51caa5b4-361b-4186-aae2-5d297e6c8bd2"), 4201, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51eefaf1-fbc6-42ba-be9b-06dda9affb7f"), 4556, 8, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("51fd08f6-efe2-44e5-b186-39cb73c188f0"), 4621, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("520fa1d8-84d1-45d8-bdda-54570f9993c4"), 4264, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5224efdd-de08-4884-82a9-a81b078b6b59"), 4519, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52258fa7-8acb-48a9-9481-0ffc55ac8d44"), 4238, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52288924-5d53-4082-9c9d-189cb7c93453"), 4452, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("522ee518-9b64-4332-8e44-2791019a80f0"), 4500, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52369529-e943-4b7b-a70e-1845f82c76bb"), 4320, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5266aa15-1471-45c6-b256-808cd8698bee"), 4234, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("526b557b-66c2-4dd3-a5d2-41b95bd80f09"), 4523, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("529ba549-dea1-4f8f-955b-9fa825415fe7"), 4606, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52c296a2-3ea9-4743-8a8d-fb4218318e55"), 4513, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52c650ef-dae7-41a0-98c1-c5d145727180"), 4435, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52d552a2-b831-442c-882a-813be7582b79"), 4451, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52ebfb5f-8c2b-41b7-b9d7-405795d176b3"), 4300, 8, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("52f0ae86-62ee-4eff-a236-e32bd0da5aa5"), 4271, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("530d6148-85a3-4d3d-b503-4b0e26997a17"), 4641, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5349bbf2-edf2-467b-8de4-2c0472a8a1a1"), 4604, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("535001b7-b2ba-4988-8ac8-1e2b60ae5c4b"), 4558, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53557b91-207e-4c61-a1d4-169de95d3bac"), 4033, 3, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5359ae71-11e3-43ee-9e4d-3f17e92e2c92"), 4464, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5366c7ca-f0fa-48b1-b6e9-769e30b556a7"), 4809, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5382ba77-d42f-4beb-bb55-9da446a94c54"), 4455, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("538ffa10-d830-4277-8b64-6589a3b73f70"), 4004, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53a0abed-6e20-43d1-aa7f-c1c7c99d2a6b"), 4244, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53b105b3-08b1-441d-9b99-b657d937a476"), 4810, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53c03643-3f87-498a-b134-364c3a55e37f"), 4453, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("53f0bfe8-1ca5-40bf-a8e8-a38ff5aedc40"), 4420, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54155947-a6ac-41a6-b512-097bf02082eb"), 4305, 9, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5415a86d-2f26-4a37-b8d9-3c2a2848016b"), 4709, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5450fa84-ff48-4c8e-9ce6-610d8cf54eca"), 4553, 2, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("547ac966-4887-439b-bb8d-6e761dcda238"), 4024, 10, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("547d88ca-7541-43ef-a06f-efaf0e9b5615"), 4707, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("547ef01f-0c95-45d2-8605-bd91047d3dc3"), 4542, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("548ba372-47ec-47e5-abd7-85eb45654e53"), 4246, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("548ccf8f-89db-4ccf-945a-7d584772642c"), 4705, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5499e662-b9db-4e5a-a730-6146b4ae7143"), 4405, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54a5c40a-b922-4ff6-84ae-a4ac329f11e8"), 4239, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54a950a8-736c-41b8-ac0d-1981be3062fa"), 4243, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54d297b0-b833-4bf5-9d43-55c642bdd4ec"), 4453, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54dad43f-cb8c-4bda-85a9-bbad5c889ce1"), 4639, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54e62a60-aae0-4b84-8ca9-aee85ae3dac8"), 4011, 1, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("54ecb0ac-8c28-4653-a398-0871037f2262"), 4653, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5500337a-0f52-402e-b88b-e3dde2cdd0ca"), 4322, 4, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("550c3b76-fa10-4b1c-b91f-5705fed7a346"), 4246, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("550f893f-3493-4425-abb1-6a8eb895b351"), 4701, 4, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("551e7072-3702-45cf-a0f0-c276d27d36d4"), 4030, 1, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5523d5d3-df7c-4ff1-bdae-e1b7a4a2bd17"), 4513, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("552b8675-8397-4794-b89a-bf5aa33e2aaf"), 4204, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("554960eb-99e5-467c-abd0-b7a2012836e5"), 4510, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("555a95b6-b1bb-4ec5-8624-8548a3deb9a3"), 4528, 2, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("556be33d-6ac4-4c61-a227-421edc4d2fdc"), 4312, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("557e2a96-86a5-40a4-9f70-b6d82477888e"), 4613, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55ae2d74-63cb-4bb8-881d-e9a911bc13a6"), 4706, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55c9377d-68ab-4ba5-bf2f-6417dae491e1"), 4703, 7, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55cd4060-fbe4-473f-b44b-ea6a82f0977d"), 4637, 6, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55e690b4-055a-4a66-9508-110e523751af"), 4444, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55e9cebc-c9eb-4090-84d0-b12d804c7297"), 4013, 3, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("55f48d1f-01ab-4aeb-b639-afd6aa205d02"), 4013, 10, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5612c579-2d44-4cad-9c73-0779b717fd87"), 4854, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("561b2a40-b83e-4183-881b-82e20b1bd13e"), 4656, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("564a06f0-1e77-4286-b961-cd37114e6815"), 4429, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("564b05c9-41b0-43d2-8360-bd090bb00376"), 4616, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("568a456d-ce77-427b-bc89-d272cfb8e6aa"), 4306, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57053954-b1b9-4963-b0bd-b87227eab882"), 4803, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("571bc606-cf75-4727-9492-35b68a56018c"), 4442, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("573cf0fa-42ea-4205-998f-85c4d5e12ee6"), 4851, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57407e24-d143-48be-82da-71a640ead4f4"), 4317, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5776284d-b086-4884-a2a4-22db5343ede8"), 4722, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("577aede9-9542-499a-9ec9-ce3a6826a1d6"), 4602, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("578438bf-24a6-45cb-9f99-db250ada9e71"), 4300, 2, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57871ca1-7658-4c99-b4fd-78f8c93c8416"), 4029, 7, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5792558f-0caf-4440-a5a6-8268932061cb"), 4465, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5797933b-4b1e-49f4-8a4a-dee8b39a6c80"), 4630, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("579a3551-fe7a-436a-8214-89f7a913dfe3"), 4323, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57aaca49-bada-41ad-bd20-54f7abac7a5f"), 4267, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57ab07f0-1e6d-4711-9ffd-7f6e35540919"), 4533, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57b2117b-9eb4-42dc-a82d-e7ab5c5cb611"), 4546, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57bf5b81-b431-4fba-b64c-9a77cb800fc6"), 4240, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57c82d02-7036-4683-a63b-97b894ed28f2"), 4250, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57c9a65d-afd7-44cb-a70e-68bff1472f2d"), 4440, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("57df3747-2104-47c2-896f-e44166cfa01a"), 4531, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5819d1e4-2b36-4d5a-b880-91a4137909de"), 4713, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58306082-f40e-4b28-a64d-bfa68e2c61a0"), 4100, 7, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("583b3379-2037-4ae9-9dd9-61dd2aeea0f1"), 4009, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58581ec1-08ca-435e-9214-389254576f68"), 4023, 4, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("586ac93c-9e51-47f5-8de3-940b345647d9"), 4300, 1, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("587e9f85-3d40-4deb-9bba-5e74a42cdf5d"), 4462, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5880c251-616d-4fba-a12f-1eeee7432836"), 4411, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58900cc8-b209-42d1-98ca-21bb973f1f02"), 4628, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("589597e1-9e36-49a5-aa93-d33136b1e619"), 4002, 7, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58a3470d-e88a-4ae9-99d5-b13dabd6705d"), 4719, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58a8574b-0710-49ce-9195-2f71a046a835"), 4423, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58b8dd85-a73d-4fae-b2b5-4af05ab0bdd3"), 4613, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58d58ecf-97c5-482a-b282-cb1867638259"), 4246, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58d80939-df27-47a8-819d-1d9c6fc491a7"), 4226, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58e7a27f-eceb-4bce-9e93-98a99a40b4e9"), 4109, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58ebf650-7247-4ccf-af8d-2147c9b61570"), 4414, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58f1b307-7c04-47f3-b966-fcc42a66a037"), 4313, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58f344d0-7fc8-4bf7-a48d-4faae6fbeefe"), 4219, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("58fce6af-4000-49f7-8527-0014c188423a"), 4720, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("596ccd9f-dd21-475b-8491-10a57fd68a96"), 4627, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5973b662-76dd-47f3-97bf-4001f1deef6a"), 4551, 4, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("597d1b8e-7a33-466b-a880-6a863bd9fa6f"), 4426, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("598886f6-c24d-4d17-b515-bab6e16c0b9c"), 4564, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59b2d78d-c22c-4245-8c9a-2ec53ea87235"), 4302, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59c001e4-ad93-46a3-ac8a-bc8aa37f2b70"), 4409, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59c6b6c0-b31c-44dd-9676-00361ddcb930"), 4010, 6, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59e56774-6b9c-49b8-a327-179458351f3e"), 4526, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59faf69f-587e-4e1f-a0b2-af14648c9faa"), 4304, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("59fbf052-6fec-47a5-ab33-be3add7e3f43"), 4411, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a06b415-a841-4a4a-88e7-65628d7fdbeb"), 4414, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a3b1109-cd00-4740-80aa-523306467b89"), 4655, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a4957db-5451-4293-a5d6-16d342e31977"), 4217, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a55fabd-5532-4427-bd3e-f13e89d26bae"), 4719, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a7fdb19-2a6c-4d08-a090-5eb7a2a5900d"), 4001, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5a90b7fa-6486-4f77-bb64-640fa0a9458c"), 4702, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ab6f5c4-feab-48bf-a15f-748616b140ee"), 4631, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b0aea44-43df-44cb-90da-84b2a8b9ffaa"), 4723, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b156538-d8d8-4c52-a114-c1e7338d0423"), 4546, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b196d8a-87dc-4abe-b8f6-08a9e5fb7ec4"), 4707, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b1b33e8-16fa-4fea-8726-68fb1243486d"), 4654, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b3658cf-0716-4459-b0b7-589b7b7d4147"), 4607, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b45980b-02a0-49af-b323-7a523a429d39"), 4000, 8, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b54e61e-5219-4289-bb7d-e18b90d933c4"), 4550, 5, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b777c11-a3f4-4c5c-a3ac-559610706f88"), 4271, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b8dccdf-e5ad-4462-86a1-bbdd089d866a"), 4604, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5b912498-a418-471c-9518-d7c9c6dc5359"), 4444, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5bd9c7d8-8b75-441c-b143-822e7ed58ba9"), 4412, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5be8fdfb-afcb-4d90-8ab1-cb264a7f2938"), 4412, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c1958ec-3225-44c9-bab4-9b0cfd34fd7f"), 4257, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c386a50-aaca-429e-9c36-cf913bda3a76"), 4519, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c3b5b59-a835-41d7-ad9a-3d6bac1800d6"), 4715, 2, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c4b1961-d782-4ed7-9be1-b76b7587a770"), 4108, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c559437-b016-4d01-8406-6c0e6f744345"), 4013, 7, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c58654a-71c7-49e5-9dc3-423338f7ad35"), 4249, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c5be0dd-4df3-48a6-8b36-7d80d880bc73"), 4600, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c6810a9-4c4c-4160-ae7d-9ebf0e6d0705"), 4557, 2, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c6d864b-a2cc-4835-a3f1-b7a4f49e9917"), 4613, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c750f81-005e-4a82-9b14-6eba512bd26f"), 4604, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c87aeb4-acab-4d24-b45b-2070f030ee29"), 4526, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c8f48d9-d238-4a3d-8863-9a311ef3560d"), 4215, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5c9b7219-00d7-47da-b7c2-220f2a2ac45f"), 4550, 9, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ca18b79-c9a2-49cd-84e9-4af6537e2bd6"), 4442, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ca3d194-41d5-4164-ad3e-adbf93683750"), 4317, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cbd7a5d-7956-46ae-b033-cd0d4ca59603"), 4003, 1, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cbe14f6-a3e8-46b4-a3d3-0a2194e4bd6c"), 4034, 3, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cbe637b-1ef8-49e2-ad08-c204295368fc"), 4621, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ccaf6bf-8973-49c9-a6e3-6ddac30f4815"), 4455, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ccc90c9-8687-4102-9825-77f8f10e97de"), 4313, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cd58fae-0e47-4e63-8dbe-b5804cb4ffac"), 4312, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cdafbc2-8a8a-424f-a099-1815bf487093"), 4661, 9, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ceb664f-ecfa-495d-ab23-13d90e5c8974"), 4507, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5cf24f2e-13c4-44ca-9048-6245aad44ef6"), 4261, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d184971-9372-47b7-9b88-1a50647f4f06"), 4809, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d1d6bcb-68d3-44f2-8200-6263c64f37b1"), 4517, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d54010a-531c-4808-a5db-5e8ac7210ffc"), 4805, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d54b69b-aa64-4e54-97e1-5d9d8a10d0af"), 4421, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d58db01-a711-43cb-9321-b178127c3f89"), 4719, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d7b4300-2321-43c6-a686-431bd9eaefe9"), 4250, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5d96adda-4a08-4b5e-b24d-f4aefb07ec64"), 4454, 1, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5daa027f-b5f9-4b66-bd26-0f0f50709cdd"), 4536, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5daa804b-7e41-4c23-9974-ec1fb084b956"), 4500, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dac3cc6-60bf-4ead-bd13-d38840fd2db9"), 4520, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5db044a9-fcfd-4bbf-b3c1-13edc218d043"), 4605, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5dcec0b9-6ff4-40a5-85eb-769463bb2116"), 4855, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ddbf359-295c-4924-9f75-abb1e5fbd778"), 4207, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5de5b1a4-4c80-437b-bd04-0d281486ac5f"), 4209, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5df4782f-5fb0-4505-904d-23d33e325d6e"), 4554, 3, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e22fda9-f52f-436a-a0c6-5f218f4b5a4a"), 4215, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e3c1bdd-c4df-43d0-82d9-72439071627f"), 4423, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e431402-13b8-49fc-98b4-7cb503c119fa"), 4521, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e45a30f-14e1-4f96-95b3-b54bc9cd6b21"), 4703, 1, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e4ac019-343c-4e4a-bb0b-c570b19751f3"), 4650, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e59241b-5dc0-431c-a736-9020f02be89d"), 4804, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e5dd1c7-e81f-43ce-971a-a4904718f090"), 4405, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e6fc634-43fc-408c-9d0f-db5c1b879662"), 4035, 5, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e7eb845-39f9-4fc2-860a-5cb33a8342fd"), 4225, 8, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e8390fd-6ce9-4639-94b7-7891c7bfeb2d"), 4606, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e8721c0-0938-4db7-b61f-83c17c0f7d9f"), 4418, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5e933a4f-25c3-47c5-9891-31b8fb2616fc"), 4432, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eaab2f0-7e7e-4a4f-9945-c7e88f9ee8e2"), 4404, 9, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5eb9ac7a-adf3-4a52-bad4-c4bbc0ea4959"), 4618, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ec82f5b-adb0-4bf9-8205-80b74f4a5d7d"), 4557, 5, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ed22626-2af4-4af7-b79f-28d67dcf9c93"), 4425, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f012378-9bcd-4876-8d33-7ea57729f473"), 4110, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f0176c3-9605-4cde-9593-377741213dc0"), 4612, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f1d69c8-9cb0-4bf9-b90a-19bcf5e6ccd0"), 4005, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f204dea-9ac0-4681-8bc7-6ab8ad279e39"), 4030, 7, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f34a47e-46b2-4044-91f5-7630d73f5844"), 4550, 4, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f3a845c-4366-4973-b7a2-dfaecec90185"), 4220, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f4bb167-1837-4225-acfd-1bea9cff99af"), 4441, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f4cf809-35d1-476f-98cb-52183848f864"), 4428, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f55c075-21a8-43d0-a90e-c8078749c997"), 4264, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f578e08-2e6f-4472-9e82-e06779d568e1"), 4513, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f628968-6018-4bf0-b7f2-6cc3ba016f51"), 4218, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f65224a-d79a-4e8f-a528-d3d305f81d00"), 4719, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f7ce265-fed3-4a4f-a2b0-1002d7f6182d"), 4005, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f8ad5a5-2058-41e1-b6d4-52819c12c1a5"), 4659, 5, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5f9c2abe-21db-4598-9742-0a993f9a1065"), 4461, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fb7a513-46e1-4695-8a5a-d53c2cc55526"), 4437, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fe9a5c6-3e0f-498c-ab8f-2495b010f794"), 4661, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5fefcc09-e7cd-46f8-8379-bd5ca25634c1"), 4324, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("5ff73616-9597-468c-85df-11c41c40e006"), 4617, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("600782fa-2b6f-4770-8afa-01de8c563318"), 4000, 5, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60146a3e-56b6-4953-a31f-ee7b5c813364"), 4622, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60186081-2b9f-44b3-8712-a18146f474a7"), 4103, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60225d43-de1a-4bdf-b03d-a8cb87d0e516"), 4534, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60231988-9822-4463-a3e0-bb6f9c1299de"), 4305, 10, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60304efa-d2c7-41e1-b982-7c1072076b22"), 4553, 4, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6034926c-9326-4410-9550-f694d57ee3f2"), 4107, 6, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60459b54-bbd0-43fc-b817-fe945d87b4f0"), 4605, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("604d991c-beb3-4a7d-b5ee-1cedafd16afa"), 4025, 7, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("604f70d4-c4ab-4804-a55f-55e45e44961f"), 4232, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("606060f4-920f-421a-ad61-6d0b54d9d14b"), 4010, 4, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60708aee-78d0-491e-8ea6-8928f51d29f9"), 4020, 3, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60718b8c-9bb9-4884-b442-e23df142d29b"), 4311, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6079ee8d-70bd-4355-bc13-9511353c821b"), 4628, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6097b625-e032-4886-90ce-cdc42b5d22ec"), 4253, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("609fdb98-dbc0-4fd2-9c24-ae3da6270688"), 4241, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60c9ac82-0d78-4b63-962e-cbb0b4b6b515"), 4217, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60d4fd38-b4db-4d9d-84a6-b8cc6589e1b4"), 4108, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60f69178-bea9-47df-873d-882663351a16"), 4663, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("60f9c7cc-0ab4-4fbf-8c1b-a408dc682ba5"), 4032, 2, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6108dbb5-a032-4314-a355-d629b2c0e5dd"), 4702, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61152b16-cbb5-45ee-b8d5-9aed562eb585"), 4615, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("612faf09-e51b-46d2-8979-4f109e9d82b4"), 4701, 1, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6145e342-4e2b-4b64-a075-61fcdb0e1479"), 4609, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6149dd69-1818-4dbe-a1ab-03772e0f382f"), 4258, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("614df648-4704-4d75-ad0d-f7f7264afa84"), 4216, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("616be5a8-3b3a-4d24-a8a4-b0732e03d250"), 4239, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("618a1387-d9f3-41d5-ae41-040f41cad673"), 4267, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("619d2550-adfe-41a6-8eac-b2dc928dad54"), 4501, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61efaaf6-b052-4d1b-9e78-8a61e09e1f5f"), 4436, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("61f88df3-14a3-4143-9e8a-2d83c39f9bf3"), 4603, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62161d30-8a70-452c-b6fc-52a335d48e01"), 4504, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6228fb53-c634-4bf5-af12-299870a12598"), 4260, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("624034bc-9d04-4044-8904-8441d1a57196"), 4422, 3, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62791035-d3ba-46c5-aa4a-dfe9e9992d81"), 4103, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62852565-4a26-46cc-b51c-398f85912052"), 4454, 3, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62892b14-f880-4adf-832b-695c1a1bc341"), 4321, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62921b5d-5d4c-4d26-8277-8235ba04170a"), 4209, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62974a35-2560-41b8-9035-dd167aaeab9f"), 4415, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6299e601-d877-409d-8ce8-405cbdcaeb43"), 4465, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62ad569a-3ef6-472a-a8fa-4d921001828e"), 4439, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b0f7f7-72f5-457d-a2fa-4eb464b49348"), 4460, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b1d10d-dc3a-400c-b714-ba51eebf6f7e"), 4710, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b32fcd-542f-4622-a3a2-44dfb4177715"), 4531, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62b8f6d0-e188-4014-a4d1-0aebdde95caa"), 4608, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62d62115-b7aa-4aea-85b4-ff3a649dbca8"), 4236, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62dad4c4-a6d0-4fb3-b80e-499159034f7e"), 4031, 1, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62e192dc-080e-4092-8e6e-4216ee87ac21"), 4451, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("62ffba41-19be-4adb-b567-e5a0debcf616"), 4317, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63080a29-234b-47d2-b6ee-6093bf0ff0c0"), 4204, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63108816-a7aa-4429-83ca-b19883b82899"), 4544, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6329c616-40a1-4cfe-b743-361b0d2f0d72"), 4243, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("632b6953-82f5-427d-ae69-9922ab6e565b"), 4655, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("633ba9e1-34b3-477b-9726-65116b807069"), 4205, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("634d6947-43cc-454e-8e89-8e15255e5e6c"), 4019, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6351741d-c1f9-460d-b287-305516744856"), 4852, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6372f378-3075-440d-afed-e25fe28a4ccb"), 4202, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63845ee3-d525-4fee-b9c3-da27790703d9"), 4229, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("638b9d51-aae8-406d-b9aa-1ce195db3d7c"), 4424, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63a61c8e-2f83-49ef-aba5-2304b3a2197a"), 4309, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63b74a90-9c0a-47f8-9348-468301842124"), 4702, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63db0c43-c5ff-4d04-97a8-9bb53c075d8d"), 4515, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63e200d3-9ce7-47d8-aaff-f763134b6003"), 4423, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63e42ea8-0eec-4726-aa61-9dd294d959c6"), 4209, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("63fa5446-8bf9-4898-b990-6d122bdfd14f"), 4237, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("640a8b12-1904-419c-8a53-3ad3fe04080e"), 4547, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("640b0077-90a4-4bd7-882e-5145eb37dcb6"), 4606, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("641f43b9-6ec2-4b14-82fd-68f5901ad6dd"), 4803, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("643addd5-7a39-465d-94c8-a6c0ce1febb9"), 4031, 9, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("643edb7c-7dbf-4a96-ac83-355e4f9b14a9"), 4424, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64438f4d-b9e2-42de-a053-5d3ccbc71dab"), 4663, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6446debd-b0fb-4469-a62a-6b1d428571fc"), 4263, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("645d06d7-019c-42f8-bc07-d41387c6945e"), 4808, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64674f3e-7db6-420c-a1a4-1557244c264c"), 4617, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6467ddf7-d384-45bb-85c3-d67479ffe54f"), 4717, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("646c3710-16c5-4c53-818c-eb39d5cc22c0"), 4204, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("649bf367-e73a-453b-901d-7546a52dc6ae"), 4605, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("649d8ba0-6eeb-4340-a63b-9a663b667e30"), 4621, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64b2fe0d-76fa-4742-a145-bd21226fbe85"), 4230, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64be622e-f441-40c9-92b8-6d2f719290fe"), 4661, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64d8bb56-8b59-4e2a-875e-9ba541a1a960"), 4715, 4, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64e21db0-f65e-4382-8520-6bc13523ddb2"), 4203, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64e975d5-361b-4909-a129-4e0f455d8df9"), 4273, 8, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("64eafee3-d6fa-467a-bc89-d0d8d409f3e4"), 4100, 4, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65252877-d343-4204-922d-874bd39b17ac"), 4008, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65502cfc-90e6-491d-93a3-8737baebbf6b"), 4322, 7, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65549dff-b5b2-48aa-9d89-0c12b290454e"), 4658, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("655533c7-5d96-4264-abe7-2133af1ac9fc"), 4536, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("655af4f8-42ce-4134-9640-d84fbc503e5c"), 4717, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("656b803b-6f9a-497e-bf1d-40eff96de5d2"), 4701, 7, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("656d8cc2-c720-4e93-850e-4603a30ed361"), 4211, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("658b479f-7222-4854-aca8-a29c3cf51222"), 4022, 6, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("658b6ebb-6e17-48e0-b22c-c8c4f071d91e"), 4432, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("658e61c4-02d8-4e6f-9e54-ee53caffd716"), 4420, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("659d1dc1-4770-4345-9f4c-81a7ca741ffe"), 4554, 2, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65a21b57-4e42-4cde-8cde-40a1ce698fe6"), 4207, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65c2b185-e039-4ece-ba28-e2987cf16937"), 4203, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65e7961e-d7c7-4b75-a02c-f305933f7ac2"), 4553, 7, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65f3fb3c-bee6-4123-8345-457936ee295b"), 4453, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("65f89370-02c7-41bb-8110-65e1677fed95"), 4248, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6600cfa7-0978-417f-a2ec-f0e4ae24e3de"), 4554, 10, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6616841c-3789-4577-b419-c91f39a776a2"), 4500, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66176f4c-2960-4290-9f04-4fcc2b7c70e3"), 4610, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66310fe5-e98d-4228-a37b-b987cfe4b5d9"), 4436, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("663f0316-5953-425d-80a3-84a9ccdb9271"), 4321, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("663f3d8e-2f57-4294-aa20-919baa7bb88f"), 4217, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("664f3f22-80cb-467c-ab46-8ff78d826568"), 4203, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66510e73-b92d-47bd-a4d0-9d143c4dadf2"), 4317, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6656a3d5-56bb-49d0-905b-9312c06737c2"), 4429, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("668f7197-767c-4af4-9a39-8df4fc747cdc"), 4103, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("66b906eb-84cb-48d8-8e73-ea54e82d94ea"), 4236, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("670aa6a2-bd6d-403c-997b-fd6c778c873d"), 4256, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("671672be-c226-4a33-8516-74f6143c6116"), 4505, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("671f2d68-03dd-430f-b991-c0973665c9e3"), 4630, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6734b860-cc84-43bd-a107-064eb715d397"), 4037, 7, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("673969bd-c620-446a-b4de-867b2bc7fa64"), 4111, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6753dcdb-aa6c-4b35-9cf4-b5edc0fbaddd"), 4655, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("676dda98-fc7b-4bb8-98c6-d738e079beae"), 4632, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("676e509d-9a3c-43ec-b42c-23f093a1746b"), 4709, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6770f581-ff37-494d-a281-4bbd7ef2c58f"), 4422, 8, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("677b375d-53ea-42b6-87a0-f8a538cecbfd"), 4223, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67a4e12e-fc72-460c-bf32-2a46fe7e9d9f"), 4205, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67b74e59-2e5d-4752-b276-57f89c61ca99"), 4451, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67b928aa-5d9a-455f-b5c4-fdff393a1238"), 4563, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67c83b9e-1bb7-484a-b495-7d150776a666"), 4411, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67d33c01-c9bd-4f34-b90d-78a7ce3b7a41"), 4202, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67e1b5c4-7bd2-48f8-a49d-6863b0115d75"), 4600, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67e6b336-3e76-4dc7-a7f6-fa2e5f6199a2"), 4703, 9, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67ebc21a-da13-47fd-a48f-9779be17558d"), 4036, 7, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("67efee79-84ed-421c-a470-749745ecad6c"), 4204, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6828673a-4d97-4d2d-b674-5f998580f16e"), 4620, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("682e59f0-e852-47ae-bc86-386e2ddad52d"), 4619, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6894093f-6877-4f8c-9bc8-2ffc31b59e18"), 4026, 1, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("689d7831-fbc7-4ea9-9570-12aff61b4651"), 4426, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68ace428-4825-42e0-a1d5-425ad087c490"), 4263, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68bbd540-ed47-4216-bd91-3a759397238d"), 4519, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("68fb9bbb-ab95-4b34-8053-ad08ad82346d"), 4538, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6900984a-47a4-41d7-919d-a0c0dba0258f"), 4523, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6907fce9-68d1-4805-aa29-eac48bc89182"), 4540, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69084e0b-dff0-4368-891b-f5abbe21d6b2"), 4701, 2, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("692df1b2-8b35-4cee-83ec-0fdfccc69a74"), 4718, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69339c3a-bbf6-460a-ab45-92bd175399a1"), 4020, 8, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6958e55e-846a-4428-b1ac-b413f433faf4"), 4022, 4, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("695f9f9f-98ff-4170-a258-d116b72a3701"), 4418, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69710ac9-bcbd-4083-95ee-5885e230845e"), 4433, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("698f8f1d-f196-4000-b38e-8c6b079d10f4"), 4007, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6991336b-7090-4162-8d5d-0c8290c40696"), 4104, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69b6f472-2588-462a-9a44-4a16ab7c2d44"), 4723, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69c12a97-03c8-44bb-94ab-d0a511034eec"), 4255, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69ca7d99-6bbc-4f12-a74c-6942cb467b14"), 4705, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69cb111c-aa3f-45f9-9535-a2c6ab453119"), 4446, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69cd4b2e-0792-42b2-85a1-c724990c8577"), 4663, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69ce80b1-126f-4b5c-b6e7-036cc575a67e"), 4231, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("69df83d2-e103-4b65-81db-33d54182fcbf"), 4565, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a06d6c3-3f6f-439b-8915-ea3135fa9f69"), 4029, 4, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a1a7136-e41c-4760-97a2-7b125421839e"), 4630, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a23b9c3-c3ed-49ff-a7f4-d833c560e583"), 4231, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a2f218b-2beb-4101-990c-7913ecf021fc"), 4428, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a41d376-d2cc-455d-922d-c615febb74de"), 4409, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a59dbaa-2fa6-452b-85ba-51331618c3c3"), 4544, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6a6a254f-0593-4bc3-b115-ca7fa870cece"), 4438, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6aa2e3ba-2522-4239-90e7-16009a558d0d"), 4505, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ac168a5-4365-4575-89df-6cb12ec8e03e"), 4236, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ae8eafc-057b-4968-83c9-d1f9361df4ff"), 4246, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b0589bb-6b5c-4e13-8784-3ef2a6935094"), 4312, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b06b4b4-5bb6-446b-a234-9212d9d5539e"), 4226, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b079186-7301-4152-9114-56ac0ca48414"), 4560, 6, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b19145e-cbd1-4b96-90d3-3b0aa2383981"), 4235, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b226956-018a-41a8-9242-cde214fa0612"), 4641, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b337eb4-bcec-406f-b640-62bb29ddfad0"), 4252, 10, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b398f46-7ddf-4061-a7d9-a0f426a1aa1e"), 4526, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b3a8bdb-5d35-453f-a793-70181d5af7b3"), 4114, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b64e67b-d5dc-404c-b40b-28d672ce37a1"), 4526, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b79db38-7a6a-4a01-b1a8-42f841114b30"), 4445, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b7e10ef-d2ad-4928-8b79-3f73973c41f4"), 4214, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6b858496-3fdd-4122-a65d-6aa3a04b41a0"), 4711, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bdc8d11-cacf-4fb5-89ec-9da40a8104fb"), 4210, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bdff13a-ca0c-44e5-9d72-d2e3b769533b"), 4634, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6bf1370f-d8b7-48c5-85e2-3684b84e64db"), 4248, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c12340d-0f5a-4147-8932-3bc99ff11f75"), 4005, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c2338e3-c143-450c-8d4a-fbd3266db6ed"), 4112, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c257874-94a9-40c9-a821-ada6f35e7c2e"), 4429, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c37f476-c8c7-4c6e-8dc2-68ccbc295058"), 4705, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c3aafdf-738e-4c94-9b45-95f6046aa1fd"), 4723, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c3b7656-91ac-418f-ad3f-5bd721a2ef2d"), 4460, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c6048c2-8f57-4ec9-9ddd-5702fd105601"), 4106, 3, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6c70f623-d034-42ac-a401-d39f431a3ce7"), 4224, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cb80c53-eeb4-4f90-914c-1ac03697cd4d"), 4558, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cba0812-b114-4e10-807e-a81ad9b62a14"), 4636, 10, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cc4ed63-efba-42a3-aef7-914652d39bc0"), 4036, 10, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6cca6ce0-f6a6-46fb-8787-c496a6ed6a38"), 4205, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ceb3377-5cf3-4386-ad9f-2ea1714328e0"), 4605, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d04e295-ae9a-4519-b554-47d5b377c4f0"), 4808, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d0621db-4269-4379-a44f-4bd7e195b175"), 4454, 8, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d067395-76c8-4cf7-b169-5824aece273f"), 4210, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d3b8853-fc80-4cec-97ac-2d096e83d3b6"), 4445, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d3c6de8-767b-4ed1-adcf-c872b7c56aa2"), 4709, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d65f473-e8a0-45e7-8070-01f65bedf705"), 4541, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6d85a3ba-8e88-4895-9577-b03fe8128552"), 4201, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6db360c8-5f17-455b-91eb-15b9129d61a3"), 4459, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6db4fa0c-afbf-4957-a72e-b6415a64ff85"), 4035, 4, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6db8e6d7-924f-4f96-a336-7d35994f04c6"), 4204, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6dbbd6de-6de1-4212-bbd1-bbb21a4d3711"), 4317, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6dc5dc16-faaf-4085-a974-8a6b3240c4fe"), 4536, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ddc22d9-cf63-4238-a09f-5a0aad5acbf1"), 4562, 2, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6df940d2-a158-40bb-8432-7dc13e5f7f6c"), 4510, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e1afc02-a6ba-4dbc-ac0b-01da185c4d06"), 4439, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e1d02be-c32f-43e9-8277-ce5a23a3e6f4"), 4613, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e4f5d38-6aec-4379-a495-c67a2b6db256"), 4616, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6e7339be-e0a4-4feb-89d4-da92d0841e38"), 4807, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6eac377f-6ac8-4e57-a5b0-f837ea61abbb"), 4269, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6eb07774-e11c-4434-a859-cd3368d8345f"), 4425, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ecf5dfe-91d6-4286-8955-db6053db0011"), 4801, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ed18678-9515-4521-a412-da3033becf64"), 4424, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ed672a7-1643-4380-8f19-9cfe51366ea6"), 4625, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6ee50223-8f57-43cf-8724-330b06903096"), 4632, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6eeb1430-c5bc-471a-919f-cf72300c66d8"), 4263, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6efa5836-5b13-418f-afbf-2023b84cb5d2"), 4215, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f022e8c-1d14-44fd-9da7-5657c50e4084"), 4270, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f151d99-d825-4604-b8f7-c031713d0884"), 4248, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f2c9c1f-323c-4b18-879a-c251626b28d8"), 4318, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f34df20-fac9-46e5-92a9-4ab7619aca02"), 4808, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f6c9b2d-163a-479a-a6ec-210b64c96136"), 4452, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f720771-9a42-457d-a819-3846e7d50b11"), 4512, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f7398b4-8009-4e53-8f16-3a7c896368c3"), 4400, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6f9da159-c9f1-4e54-834c-9ab515fe2f60"), 4456, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fa16770-947a-4f7f-9cb9-3007f27df2f3"), 4014, 1, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fa6285a-68f1-4da4-a3e3-2dee6cca5849"), 4419, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fc2b495-d1f5-4fbc-bcfc-bff407326b2e"), 4620, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fdc86c1-989d-4817-87d8-d93a6419141a"), 4522, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("6fe3f30c-ce83-41a7-becb-5284e1f0c297"), 4320, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70282fb9-d9a9-4e81-b5ec-ec4a45492131"), 4239, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("702ded50-202e-4af7-a6b4-ee7fbdba6b38"), 4208, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70459f72-edd3-4064-9ce3-0cf88f9708a4"), 4521, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("704cc16e-0ec7-42ee-95a2-eb7089537d43"), 4528, 7, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7064762e-a107-4f39-9bf7-9506e1c16afc"), 4715, 10, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("706627a7-0eba-4eee-8e01-36a60653a073"), 4006, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70762da0-ab75-4056-9a1d-2021dcca82c3"), 4541, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("708097e7-bcb5-47cc-abbc-67c2bbd19d8a"), 4320, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70813451-2c4c-46c3-a611-d8d2f2c988c0"), 4015, 2, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70967036-11c1-4336-ab2d-5176ceafeb37"), 4447, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("709c01b6-2491-43c7-a4ef-3f7efbe7b350"), 4524, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("709e3ef8-dad6-4407-9f67-bee820903a82"), 4511, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70ca65a0-11af-472a-b4f6-17fddea92029"), 4461, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70cfb55e-ed58-4978-9f0c-de6fa449be81"), 4318, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70e50b10-df54-40c9-a3d0-a979d399a915"), 4442, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70f90887-3960-4265-b641-a0137c651e2f"), 4213, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70fe7074-b6d3-4a91-95fc-9209a1348caa"), 4720, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("70ffda81-3567-425b-b119-63006b23458d"), 4451, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7103c03e-8575-4546-8354-653e1eeedb5a"), 4541, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71283d61-8b9d-4ef9-aab5-bfcef322f880"), 4304, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("712911b8-6ff9-41d9-afa3-fddaca70e06a"), 4262, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("713490da-09ae-4f2c-8668-90e7ef20eb2c"), 4508, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("714afd22-4b18-42d3-8190-18c3fa7489a3"), 4439, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("715a992f-8750-40df-aabf-4a64666a6f9d"), 4101, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("716ca161-4c86-4d30-9aa8-c5f819e53fd7"), 4464, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("716dbdda-cdc3-4326-a4d9-ddb2440033d5"), 4212, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("716f731b-8a19-49a6-ab6d-3f54a68924e2"), 4456, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("718cfd3b-d47e-4f0e-bba6-b5719d2715dc"), 4658, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71954c43-718d-47c1-bbc4-260d407ca9e3"), 4303, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71a49887-938f-48cc-986a-f7909f593a29"), 4256, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71c0131a-e849-4968-ac4f-ed69dea9f387"), 4266, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71d70e3a-60b9-48ad-bd5d-c33bd64b2e46"), 4431, 7, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71d732fb-d09b-4512-b09c-72f51d283aa7"), 4215, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("71f042e1-46f7-4211-9a9a-d7f5dfef1125"), 4520, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7219aa97-d920-4d06-9a6c-dff68cd6ceee"), 4808, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72262bcf-2f93-4592-9bc0-b5a13c923ccf"), 4712, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7243a8c5-0a45-439b-81c5-e3009b10620b"), 4558, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("727ce608-f82b-45ff-9c6c-020ab73bd3b8"), 4016, 1, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72af3847-f176-484a-ac11-3a8807c21969"), 4407, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72bb74cd-14f2-417e-97a5-5233b5fad53f"), 4007, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72cd09da-e113-4c6b-8395-62a6de328297"), 4302, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72cdc336-f269-4245-a09d-f45acbf337a5"), 4266, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72d2bbda-19de-4c29-bed7-d3c84696778f"), 4532, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72dfe981-7b01-4322-9f89-534bcadff0ec"), 4315, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72e07048-5511-4f9a-b611-c07b6bbe56a4"), 4420, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("72f81092-9511-4d0c-8521-c59d9c2b8826"), 4547, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("730b0add-fbf4-4849-8da0-fbade53cc220"), 4214, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7348cc48-d5b0-4407-bc61-5151d921fe40"), 4650, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7370649b-2a56-4611-8fd6-8580ad70d50b"), 4626, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("737611bd-6051-4d38-a06f-a36baab50aa8"), 4600, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7384323b-8620-4790-a373-fa17df179bb1"), 4201, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7401bde9-c20c-4715-aaa2-2f816e5ff8f5"), 4115, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7412816a-8915-4ccc-87bc-38a1b4ef0b64"), 4213, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74137fd3-b797-4c90-acff-b822bde744aa"), 4516, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("741db115-238f-4fac-92d5-000aca235ec4"), 4462, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74250e47-2327-46dd-a7cf-909d8bd11687"), 4530, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74a5e05b-71e4-424f-8352-f476661c8259"), 4269, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74c5e1f9-14e8-4c51-a210-45fb03dd463f"), 4457, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("74e022a3-1335-4199-9c35-de0e47fbca7d"), 4601, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("750411a3-6ee4-470e-8dfe-665610058937"), 4223, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7511b968-8df5-4154-926e-748cffb84224"), 4662, 2, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("751e0931-c0c4-414a-a7d4-7f6089c22931"), 4212, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7538432a-d6a2-4873-bd2a-af909f6a45cd"), 4015, 3, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("753c68eb-ed6c-4f97-953e-61a157c7df0d"), 4436, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("753f4632-55e1-4565-8d33-4a921687c19f"), 4274, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("756d394f-f146-420c-89f9-6282f63823c8"), 4303, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7589c98c-fbc0-405b-a971-a3cae9ce3c7d"), 4850, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("758cbac5-7660-4ae3-baf1-bad29610e9a7"), 4418, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("759bf9f2-903d-4532-9ac2-c707164fcd66"), 4015, 4, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75ae5999-560a-4c10-a5b8-e65cc313f876"), 4443, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75b6aa27-7fe5-4641-a8e4-b720d3debe61"), 4408, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75b8bdc1-4901-44de-a825-72f66f12a4a1"), 4430, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75e153e3-720c-478f-98ca-9eada0fc1db1"), 4201, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("75e1d3d5-9d5e-44dd-8ad7-b16f7c36bbac"), 4712, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76300251-fbf3-4231-b101-f4663ce680f2"), 4800, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76ac02c6-14a4-47d5-9878-525e74326a53"), 4445, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76b3b700-a5d9-474b-a096-82fb67fd33f0"), 4411, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76c47242-dc31-421b-b26e-593f3ed2d302"), 4536, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76ca3ef4-9b6e-4f2d-8945-0a8212f36764"), 4003, 3, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76cff6a3-7567-4dfa-9ed0-89be1a050df3"), 4253, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("76ddd5ca-29eb-4466-abf5-d5b606f4a40b"), 4453, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7712b052-e7f0-4c2c-983f-7864fb2bbff9"), 4016, 5, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("771b4355-df12-47e6-9032-73ad66d07801"), 4420, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("771e289c-ba04-4caa-bc76-92c761458314"), 4662, 3, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7737c338-588c-4c5c-b20d-3c600746fe17"), 4312, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77591fba-6f4a-4fcf-b609-878afa03e355"), 4530, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("775ad441-0985-4bc3-b618-71d176eacb1f"), 4542, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("776bb6e1-820b-436c-8ce9-8b2beffa531f"), 4251, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("777b9792-acd5-4af1-bcb9-42bad0e0fa7b"), 4544, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7791533a-5f74-4050-a9e7-ba15bc5e606c"), 4558, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7794ffb1-3cc4-4d7a-86ce-80b7be9f5628"), 4026, 7, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77a11c9f-4a96-458a-b56a-aa824be34ae5"), 4617, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77cb2971-8fbe-4841-a1f8-d02427d52ec6"), 4550, 7, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("77d0f9b2-5d44-435f-ae47-88b2cb59ba93"), 4431, 5, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78052996-dd9e-4360-8272-09aae26b7672"), 4022, 8, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("781fdfa2-25cf-4a8a-ba7c-ca39add7c9f3"), 4801, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("787c451e-d70d-4bfc-805f-872147147dc0"), 4000, 9, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78ab55e8-f5fd-407a-b3c9-80e1c99585f1"), 4616, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78d4482c-2a18-43c2-92fb-afbd6a7f1dac"), 4553, 6, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78fb353a-3e7e-45c3-bc9d-2126aedf0002"), 4211, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("78fc8c9f-bab4-4f41-ab7e-ff0131b471f2"), 4315, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("790ddb5f-74dc-4a9a-9cb2-418e7b1024af"), 4524, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7919e7f0-1710-4022-a275-7574290d4078"), 4662, 7, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7928c499-6926-44b9-be0f-a00a417817b1"), 4111, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7936d63d-5735-4bf9-bfda-92a75937d25e"), 4639, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79452518-e7d4-4889-8a93-a403305c2fd3"), 4246, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79587616-b3c3-46b9-a4ad-9079d67281c3"), 4505, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7966c4b5-1688-4ea4-b753-e6e73112ca04"), 4315, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("797791b8-aae7-40f7-8c91-f671af171285"), 4854, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79b35216-f7f8-4621-a20e-249d8860e496"), 4247, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79bdd536-4718-4f1a-a242-c7b5011163eb"), 4540, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79dfa45e-a5f7-4b52-a253-f88feb700507"), 4450, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79e20cab-38f6-453e-a166-9d3b425f9ae4"), 4600, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79e40268-13be-49e7-b7f2-a6afedf89a33"), 4564, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("79ed72d1-fd05-4b1e-bef0-776a8a3d5a4b"), 4243, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a05134b-e776-46f1-a170-a0fc2d5fb111"), 4552, 9, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a09461a-fecc-4a9c-aeae-fa12cbb3d4a9"), 4533, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a1195e5-6b91-40aa-b3c4-8b311983bae1"), 4659, 2, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a16649f-16e9-4dc9-90ce-92fa5da9b186"), 4018, 4, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a2b3844-9083-4066-a491-8a1545a756ca"), 4268, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a2e57b8-b9a6-4182-8dcb-b88923fcb515"), 4851, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a318f4e-3cca-4802-bb86-48b3fbfea448"), 4231, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a4e953d-4649-4f20-a8d8-d34a9a864683"), 4323, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a549588-04e9-450b-8fbd-6351490f51ac"), 4717, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a5c771d-fd87-402e-96cc-5f5538510e83"), 4452, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a6f868b-487e-4f09-a747-665001b430b2"), 4707, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a76142b-5019-4b53-b758-84ce77c722a9"), 4716, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a882561-d2c3-45c2-b2ce-9e0c022b77a9"), 4100, 8, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a8be352-57fc-4680-9aba-dd2fc4b1e7ed"), 4413, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a8e0cb8-c486-4895-820f-066e54fa9470"), 4301, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a9d5f42-7593-4ca8-bc46-bd3693740a95"), 4021, 7, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7a9e0235-1e7d-4dfe-89ab-29e4becbf5b3"), 4230, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ac62788-0cbb-4edb-9b65-b8d031a24690"), 4850, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7acae07a-c410-4850-8fa2-47390c7df663"), 4622, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ad0a5cb-14a6-42cf-98ab-9377e1fd4418"), 4427, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ae8d4e5-0074-4668-9318-85279d299810"), 4230, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7af0d404-351b-498b-bc09-0c1693f3b95d"), 4269, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b08012e-e17c-4501-8b0a-37b58da326ea"), 4464, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b115dee-62de-4394-9753-609699d2e1f7"), 4111, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b14a121-6157-4d2c-9543-99f825303cc9"), 4551, 6, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b1c6dda-68f8-4380-8a08-ca4ed32179cb"), 4440, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b4f3548-7a1a-4c43-84e6-df7fcae05f3c"), 4854, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b6068b5-89c4-401e-b40f-2348daf8baad"), 4545, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b7b4160-831e-4f19-9600-29c48a4d48d6"), 4701, 8, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b8cb2a9-2aa5-4027-90c0-2a5e044ae47e"), 4608, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b9d7faf-cc76-494e-80cc-cfc7180c6096"), 4511, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7b9ee968-be92-463e-b6cb-061d6eac2ab7"), 4552, 8, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bb5f499-9a05-42cc-86d5-91df1c6ba9f2"), 4234, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bd314c1-ed43-4478-8543-6caf9e4f2cd0"), 4027, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bdc3008-b377-4d7a-9208-cf0bfd3285e2"), 4441, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7be1127f-63e8-488a-b89a-95c0bc0c95ce"), 4309, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bf1cdf6-a759-48fe-a9fb-c1880cecc5e8"), 4223, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bf34bd9-9f4b-48ff-b532-f7f715df8049"), 4539, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7bfbb74b-bec7-4ecd-a3f7-2db2b48e20d9"), 4019, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c0c8899-011e-4eb7-9df3-b41e148e92e7"), 4807, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c46c787-97ad-44cb-bd99-c6a3c5879d3f"), 4402, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c50b657-44dc-4ebd-b044-86d30848e9d8"), 4525, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c5b3d51-2196-455e-901e-a61276b65513"), 4801, 5, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c60b440-43a2-4bb1-aa97-051abf639398"), 4113, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c6bbbd1-c6ea-41e8-bff2-cfd65bd2dd8e"), 4522, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7c8b9773-af17-4c08-bfea-23ce9528ff29"), 4711, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cc8a2bf-117e-418d-b5c5-9d85ef787b70"), 4564, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ccaac16-6a79-4cc6-be43-6e1d3ce051e9"), 4410, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ccedbd4-86f4-424b-a0c3-aa82f1f155dc"), 4253, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ce8a955-0e6f-4779-bec3-42ded3b391e2"), 4516, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7cebd1b9-0989-43a6-9156-771b6a83db0c"), 4272, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d032368-edd3-44e2-afb4-a8deb2098ca0"), 4856, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d1c701e-ce44-4fd6-8e54-e95a4cdfa970"), 4561, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d24efaa-f4fa-413c-94b0-b40015de48ad"), 4257, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d274f3c-2c08-483d-bf8c-236e3f05780e"), 4224, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d28888d-a564-42d1-9a74-78ad4ae029da"), 4324, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d2cfae7-e1db-4fdb-9220-8ac654dae8a4"), 4605, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d31c843-dd23-4519-b93f-26c59f39afa2"), 4018, 7, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d477abe-3a7d-48f1-9859-c5c0800f2cc7"), 4030, 8, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d633208-1acc-4852-a721-d39dc89abea4"), 4543, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d77936c-ff36-43dc-b532-b448b57ce9af"), 4708, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7d7bccf4-9748-436a-9b81-61f96c4afdf5"), 4855, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dbb64c5-4a31-4f6d-836a-c79f14be387c"), 4211, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dc38a95-8a2c-4745-b0a6-abb6f6fdbff1"), 4609, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7dd76989-a4d3-4a7c-8e25-abf8de8ac086"), 4316, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ddbd512-8245-401f-8fac-f4d9dcdc257c"), 4515, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ddf0fa6-0c4f-4544-94bb-b38605433606"), 4251, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7de12494-46b3-4421-b267-dc32df19cacd"), 4108, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7deb6446-7596-4b66-8d59-9c8181ae43fd"), 4214, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e1b371a-ef1c-4c50-94df-66caac8045b2"), 4271, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e1bbbd7-f1ea-41d4-8b72-281be0f9e44e"), 4424, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e1ce989-dbbf-4b6e-a2b0-68c9732da189"), 4803, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e35b024-5b1f-4d5f-9c28-033dbe340f2a"), 4659, 7, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e4741fd-605f-42af-ab47-284aad75aefa"), 4219, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e729122-50ba-40e0-86f5-4b2f33346f0e"), 4531, 3, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e79d59c-e616-4044-9e03-3beb3b43649a"), 4233, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e7b0241-6ad7-4f21-b73d-933e3ec2b2d1"), 4657, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7e7bf7c4-ebf5-4a81-b0ba-5c40f6562c95"), 4535, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ec85f69-5ad3-4a80-810c-1b317efd270c"), 4401, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ecfb7f9-75d1-4725-8a4b-6e0655667703"), 4427, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7ef443ec-0484-4a23-afba-601c8a61f0ec"), 4453, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7efa5ddf-4dd8-499f-b7c3-2e7233f34e27"), 4607, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f0f7380-ae62-4139-b70b-c5d57a8e9242"), 4264, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f15e2a0-1173-4d86-9212-82136eae6363"), 4713, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f4e902e-15bb-4b3e-9782-06741b985026"), 4411, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f6d86e8-4942-49be-9f9b-39f242f2e562"), 4262, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7f74f2bc-5926-461f-b36f-5a53f33aa8e4"), 4506, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fa61231-d0fe-49d6-b7f5-c0c827a25fd3"), 4626, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fbf5cd1-1a01-405a-9333-06c00c5cb44a"), 4553, 5, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fbfbf2e-6d47-4cf7-8942-14e7fd69df37"), 4024, 6, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fbfc585-73b0-49a7-9f35-f768fe655904"), 4205, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fd00bca-7e34-4ced-b823-cf8040cf7fa0"), 4657, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fd0280b-18a6-478c-a42a-e4d0c48fcfbe"), 4662, 6, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("7fe8205e-e148-4876-b19e-9148b91b8fac"), 4224, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("800976c7-93c8-41d3-8517-e5ed909efb68"), 4512, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8009d850-8cdc-4e42-a9b8-772ae35a7645"), 4266, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("800b2a5e-b821-4a1f-9608-4b6d92184531"), 4417, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("801a8754-16bd-4f27-aae3-e2dd9e0b0e07"), 4261, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80234e61-08fe-4b94-8607-8927d68e617c"), 4802, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80308554-1217-48ba-8452-395dc9744f30"), 4550, 1, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8033424c-0663-49ff-b016-6d6d364c5860"), 4239, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("806fc206-9aa8-4038-9541-e2e62351e560"), 4463, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("807470b6-fb93-48a4-aa6f-733235f4f6bd"), 4452, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("807a1556-34fa-448c-8eb7-cdad3c0e08e9"), 4201, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8089328d-6664-4438-b881-76f038789e59"), 4850, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("809587a1-9419-4615-bc74-aa377ffe4677"), 4227, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80ae1028-bd44-4105-9532-4b998868c398"), 4718, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80b6dac7-c1aa-4497-b108-12e4dbbac580"), 4008, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80cad8fe-4174-450d-98da-ac93448834cf"), 4110, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80cd1c17-e92f-4c62-b8ac-42b44b7d7416"), 4454, 2, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80e17975-b318-4a51-b261-3f3ae11bab3b"), 4224, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80e8aa2b-9a35-46bd-9d1c-27a672cda040"), 4322, 9, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80efa4c3-b897-4ae8-a5ca-63781a26de3d"), 4808, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("80f782f2-dddb-42f2-88f8-6654eb326846"), 4504, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8103513b-22bf-459c-a482-e4d4c9cc0028"), 4011, 4, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81115cb5-506f-4a42-8068-fff4e1ba85f4"), 4855, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8149acb9-69d7-43a3-859a-ade7649d3900"), 4427, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("814cf1fb-d001-4933-9640-196eb62082d4"), 4272, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81582095-5fec-43b7-bf8a-a6c65b5a55e7"), 4405, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81656c17-6b85-4fba-a762-df3717941990"), 4032, 6, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8178bbbd-a3b5-4753-9c3d-fa35a4f050a9"), 4274, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81948153-8a11-45df-b8f6-40c8732a2adf"), 4452, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("819773bf-a8b7-467c-8156-dda7baf3eb39"), 4524, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8197a39b-5cee-4ead-a714-145a7f2eecee"), 4560, 3, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81b0dcff-4ca7-4e96-98c2-804e02c96c2b"), 4241, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81c0cdf4-f48d-403d-b6cc-c46d35c6b3fe"), 4307, 7, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81c97c31-26f0-4577-bc5d-0e94b0686206"), 4551, 7, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81d62927-df68-4bcd-a271-8a22d76e1aa5"), 4534, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81d8af27-93ba-4268-95d0-47ba5f5a2f70"), 4256, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81ea0f2a-3d15-4dba-afd2-926a9e66bb04"), 4459, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81f318ba-75ff-40e2-bc6d-ea55a860bb2a"), 4007, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("81f9c457-f46a-4c23-a504-d387248dc59c"), 4410, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("821a6794-8d39-46fc-b726-f3c526a40222"), 4106, 9, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82230e92-8a64-43e4-982a-b57cf8b83dd7"), 4435, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("822a0771-8f88-40ce-aeab-4ff3490af87a"), 4104, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82366759-9dd2-44c6-8786-dfc10a81fd3c"), 4505, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8242d7b6-1e07-4e23-8bbc-bca5fe2b73a1"), 4703, 6, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("824fed2f-ce2b-4777-b953-350159b27125"), 4706, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8257a7cb-0fa4-4adf-b9f8-374e9e5e3594"), 4510, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("825bfe2f-8e62-47dc-a015-2504bef8b9a6"), 4025, 9, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82714b40-1087-494c-ba0a-0da36e34a38c"), 4300, 3, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8276520a-bb32-42d3-b70b-c90d1f6957e9"), 4237, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82849118-a339-4228-af65-56a4f8d8ca25"), 4601, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82995a21-765a-4372-8e1a-1b8909d985a0"), 4320, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82a519f0-ce33-483e-a292-0d0039f57ebb"), 4233, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82ada87f-aa7d-4000-b256-515daaae38c6"), 4547, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82bac6d8-14d2-476c-888a-19d5488ab703"), 4716, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82be839b-3f38-4f8c-9d7d-75555ad2f97f"), 4110, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82c28ff5-1c37-46fe-b435-207128b2a61d"), 4464, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("82fe8a14-e141-4ea8-aff2-4b84d1c46ff7"), 4612, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83057fb8-e94c-475a-8824-26b785109211"), 4427, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("830cfbd5-bddf-408c-978d-908b3364742c"), 4253, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83170f12-d062-414c-b883-b9d217c38635"), 4014, 5, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8324ec51-fad6-4934-95f5-b57d4dec2947"), 4002, 3, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("834cc568-7369-43b5-9327-127c5b80b3c6"), 4115, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8368bb3b-9b8c-4cc1-92cb-cc7cf85a209c"), 4465, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8371bc83-ee58-42c0-b8f5-3c8d7b5f97bc"), 4533, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("839926f7-ec99-4ece-b535-f2d3d3c8791b"), 4212, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("839ada93-eb40-4e24-a3a6-67bfc6e7c1c2"), 4215, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("839be1fa-881a-4e27-b16c-86428ed7a10f"), 4024, 2, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83a47e30-f7b8-43a2-813b-935be03d88e1"), 4434, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83ab2df4-5cb9-405b-91e6-2416b2733805"), 4556, 10, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83da38c5-8cd2-4d33-becb-e657d087981d"), 4020, 9, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83e6eb3b-332b-4cfc-a86a-dd0cf50cdf32"), 4266, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83eec67e-2134-4ad5-92f1-ed6377f76716"), 4110, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83f3bdff-4df7-4e09-8ade-5282eeaa86f7"), 4462, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("83fa7f7f-5d30-48c7-99c0-76a17a253ef5"), 4434, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("840ebea3-dd86-4161-a6ce-9ddbd820bc6f"), 4717, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("840ec979-1742-44ad-9d9d-e73b4939307d"), 4501, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("842d6314-a94c-4d35-a91e-c31aa8da89c6"), 4720, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84373de9-f406-4be9-8162-fe55f146699c"), 4456, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84401921-63ba-4756-bb66-107973d7f96a"), 4262, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("844eb763-8a15-4624-aa2f-33c4ef41428b"), 4247, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("845dd64b-2e2f-4ba8-95d6-1f1e6e01dcb2"), 4711, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84683f05-9045-43ec-9115-e50ad4efe24a"), 4436, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("847d23c2-8b79-49d2-808b-8821e7427dc3"), 4269, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84864f36-d843-4320-90f6-5edee714a096"), 4660, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("848e52b4-d8ec-4454-9780-cdd151db70fd"), 4436, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84941136-432c-4f55-9922-abcac6ce80fe"), 4430, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8496fb67-68f6-4151-a289-ac12abc5ea96"), 4659, 9, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84a57e65-fe15-4e84-8286-4d1585a6737d"), 4608, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84b0697a-82e8-4ece-ad14-58d21486b336"), 4540, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84b488aa-ba34-4d7e-af51-ce013d4e62d9"), 4855, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84cfe505-50d5-4d7b-b124-da61d4967f59"), 4432, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84eac5e9-9cb4-4c89-804a-d0547b314fc8"), 4258, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84ecd2f9-b659-40f0-96bc-30211b0721e6"), 4422, 7, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("84fd3ecc-f283-4e8d-8f62-e7041c133557"), 4506, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("850925d5-c00c-4b62-ae59-980d19df1930"), 4563, 1, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("850c47a0-1f08-4114-a9d0-80fa3c998b83"), 4653, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("851861b4-024b-4b61-a08b-7da12dd03955"), 4652, 7, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("851c4afb-22a8-4f79-98cc-33ffc22701ce"), 4319, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8553c360-5921-432d-beeb-5dda46b17af9"), 4516, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8565c260-ecd2-4eca-93b5-7ac819b4b6fc"), 4221, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("858f7e38-16cc-41a3-a399-5a653d7dffbd"), 4034, 2, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85901138-dc5a-4ff3-b3a1-e1508faa1f00"), 4707, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85a2f8ca-7687-4eea-8904-8614b4a987be"), 4023, 7, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85a8ad56-9a56-411a-b5eb-9f867943c2ea"), 4534, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85ab3edb-38a9-4411-adbb-397eb092b341"), 4704, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85b19462-c1f2-42a4-a180-81da9099781b"), 4409, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85cb5bce-23c0-4d62-b1fb-7bb2d29d1bab"), 4441, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("85fb0925-599d-4c2e-826c-471245ad1d30"), 4629, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("860b38dd-2e43-4aff-a2c3-26498f34acc5"), 4627, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("860f0498-d9ef-49d6-98af-d52d912bb8bb"), 4516, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("866f4c08-e116-42b6-a54a-9ee5f81d8a47"), 4532, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8677171d-42e7-4ab0-a5c6-054e02a86994"), 4534, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86c04109-3e43-4ee8-8c99-226b4d0744f0"), 4255, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86c632b4-ce1d-44df-a069-65c856e77775"), 4617, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86c66f37-4009-48ff-875a-89bf7127834e"), 4012, 4, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86c87e0e-95e3-46cc-9fc6-114234fa81b3"), 4207, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86d6b32c-63a5-4634-b2c5-35b7e39e526c"), 4243, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("86f29447-9c6e-4cf6-bf7f-3276c29968e4"), 4461, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("872793ed-ce62-49d1-976f-e3710a4bdb7c"), 4104, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8727c871-8ca5-4979-9106-ca4c82ee13f1"), 4518, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8727da08-5e79-423a-88a9-819c452e24ca"), 4250, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("873c7ebe-c42b-4a9c-a297-5a966b3f3827"), 4270, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8757e95a-a1be-4039-b062-78a203d42239"), 4422, 10, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8758c824-0d87-4fd7-adf9-7c794b2e75d3"), 4546, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8759b7e1-87cc-4f09-b4c7-2a002d2a48e1"), 4440, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8759dd86-2a8e-4338-919e-212d521618d0"), 4300, 4, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87618d43-838a-47c0-a7d3-8a8b9face11b"), 4323, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("877fcbfa-c308-4930-ba6d-075a9796b04d"), 4655, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8780704b-a4e1-4794-813a-1aaa7d416970"), 4258, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87875ea9-9926-4e32-ac91-e84982c55da6"), 4257, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("878c8480-2660-4c53-84b2-a1a8127d7145"), 4252, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("879ef73f-fb94-42fa-a6bd-c52b933514c5"), 4618, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87baf1c0-b8da-458e-b2c7-c02017509428"), 4242, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87c3422a-9418-4ccd-ac29-4ddcf8c07b45"), 4207, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87c60084-5a48-4154-b98c-16ad1128cb13"), 4431, 2, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87c6165c-6c34-4355-82f2-ae6e0003cdf1"), 4220, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87e5ef10-450b-46f1-9b86-6d61fb164bf9"), 4451, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87e81987-0c23-4579-b902-e1a8ec5f237b"), 4237, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87f5071b-bcc9-4192-844a-d4905fd26955"), 4456, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("87f5cbb4-40f4-4145-a17f-2500ba622227"), 4014, 8, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("880dd552-ba02-44ca-bf47-e482d34f6870"), 4414, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("882da04f-9390-4ab3-b7fc-3c6061c8b183"), 4502, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("884eac82-0c5e-4398-9df5-7b8883e5022e"), 4509, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("885414ae-9811-4d93-bd33-72bdac7d6314"), 4462, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88549566-4525-4f37-b50c-b3ea58123d3d"), 4313, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("885bae1f-25a9-478e-bf06-edbc7b1f7806"), 4533, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("886cd2f4-cb55-4390-9bf4-d66dd1169414"), 4036, 9, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88bcf623-5060-4af9-b25c-8be1f71936b0"), 4526, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88c1c339-3d2f-4319-9b67-2a837e06ffcd"), 4525, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88d5c326-00ac-40bf-8e50-87e72366fbbf"), 4204, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88d68457-9db3-42bb-8f19-e0f7143542e0"), 4615, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("88ea4940-c180-4d81-a20c-55bc4ae8b6b8"), 4626, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89053a66-5991-4760-9214-97971a1774b4"), 4662, 4, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89206c5e-07c0-471a-a328-e035837df069"), 4511, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89242b51-2587-458c-80ff-afea94aa715a"), 4009, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("892b0840-1555-421b-a69b-f163658cbc82"), 4656, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8948f664-7282-46ab-ba02-ca9d03513408"), 4640, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8965bf99-6482-48d5-899a-e8fe013e0aee"), 4253, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8987bb77-f8e4-4e7d-b0af-8f5cbf601f1a"), 4662, 1, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89a6cad0-f857-4842-824c-8c5674ad01ad"), 4023, 8, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89b14ec1-4ced-4210-8a32-7b9389ab3a61"), 4314, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89b32944-e704-4631-9f97-fbbb5bfe2c1d"), 4321, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89c280e6-f4e4-4ec5-bbd7-86eb3c481aef"), 4538, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89ccd1a2-319d-4326-b988-b272d307ee58"), 4420, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("89f57020-fb26-4b68-a646-993fe59c5ac0"), 4517, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a0913f8-8d95-45e2-b348-81a158f24a72"), 4310, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a1e8b80-52e8-433b-9df5-2a8716529587"), 4301, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a2b51fc-5f07-49b2-a1af-0bb840d793b5"), 4013, 8, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a3c27d4-40a8-4b90-8506-6305a2a660c8"), 4618, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a4a8de9-cad8-4356-a0b5-a526c7e15895"), 4553, 1, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a943534-c372-4c70-be49-16c67092a9fd"), 4023, 1, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8a9cd076-664c-4af0-a40f-c87ba294b53e"), 4017, 5, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8aaf5cb0-f80f-491e-87d4-14ea445ea2c3"), 4637, 7, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ab0b07a-6fc4-4385-9573-f53b857a0faa"), 4237, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ac35854-7e42-47f0-94f9-ca9ba4b9b0f0"), 4509, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ad8af50-0b6e-481f-9dda-53fffb295bde"), 4459, 1, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ad92007-2279-41a0-a60b-18c7b2cf0ad2"), 4236, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8aeaca37-7be4-4ac7-930d-72c036fc8b4c"), 4262, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8af473a5-48cd-4320-90a4-6b27a5dd7b01"), 4000, 1, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b29e9e7-0136-48d2-8b9e-554f7332a8de"), 4851, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b337834-6fc8-41ff-a1bd-b834678265f8"), 4236, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b36f531-0ffe-4040-b62e-2e1705ecb601"), 4272, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b61d935-41f0-409d-89ed-ba9b156eabb9"), 4012, 2, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b6d70a0-7a06-43af-a176-42bb9f172cdd"), 4655, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b9bb79f-f8f3-49df-9307-59484096e09f"), 4539, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8b9e2dfd-9738-40b1-90a2-139246cfccb9"), 4417, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ba2ef41-53cb-4b40-9c9e-d399b9a9f1bc"), 4005, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ba55449-9f6c-4ace-8f1e-ef181e9264db"), 4632, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8baa1385-a80b-400e-a0c1-e54d9c027b69"), 4638, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bada775-0225-4372-bb64-a71f33dabb3f"), 4211, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bb57865-c2c4-4f2a-9e78-77ee6a7409ab"), 4409, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8be123a4-f8b7-4d48-8308-5ac6f68a3c2a"), 4606, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8be678f4-9cac-473f-af47-c3e5ec738180"), 4226, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bf52566-1f92-4d1e-9a86-5f5b0d4e88c4"), 4007, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8bfc93ed-9f78-4a3f-ac9a-a4a38bcce70e"), 4550, 3, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c1777f0-db94-42bf-b604-844d25e2ce21"), 4309, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c1ba458-2b96-4ce6-8b34-2f9b87ca31fc"), 4033, 1, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c1ef32e-0a11-454c-a8cd-85d171373c8a"), 4230, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c5565e3-b46d-4ee4-b6c7-d205e55a4229"), 4528, 9, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c5d99d0-0f80-4558-a9ff-f50908ecf121"), 4562, 8, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c659df5-2e85-4d21-9ead-e1022c188b4b"), 4108, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c757df3-a050-4b52-993e-ff93ca62b291"), 4809, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c75cc67-208e-4b15-8ba5-9d1dff79ef15"), 4803, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c774d6b-54d4-434c-8eaa-78d7b41fe3a1"), 4541, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c939e39-f26e-40c0-be38-bc8379fd7483"), 4301, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c93fb4f-3820-4ca5-9852-de9cfc56d02a"), 4717, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8c9d7a41-1a20-49df-8a31-4152d37d08ef"), 4630, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cb19dbc-5d3d-4709-9871-cd496021e6ab"), 4419, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cc2ebfe-728f-436a-9787-1a3addc9cb47"), 4503, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8cd042a4-9b4c-49fb-a626-9b586a4b0c5d"), 4520, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ceeb3fc-5dd1-4cfb-a5de-231c19f8d1f3"), 4634, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d1ce83e-1319-4f99-ace4-d700fc53d7d8"), 4419, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d33a29d-0a81-4d5b-88c8-b15877d0084f"), 4601, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d45e78b-18d2-4cac-9d77-d2c7734d894a"), 4245, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d517d23-c69a-43a1-99b4-0170c8c3235e"), 4226, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d565fa7-2a29-424c-9461-a9faafb4ede2"), 4228, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d65636c-358c-4df7-8fa5-321b566acce9"), 4310, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d7c9f27-b106-4d1a-a78d-7395b1b490d8"), 4244, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8d88cc89-ad81-49b3-b402-9d889706ef69"), 4419, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8da21177-5605-4902-8a2b-a07a55b96360"), 4220, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8daa46bd-3159-488e-8e3e-82456c1930dc"), 4557, 3, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dac9b19-34be-4a6e-9888-f55d596ee518"), 4559, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dddaa37-1fe4-400f-a0ad-bac4eb8fc356"), 4615, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8df572c5-c46f-4c43-8d9c-35e603e1bd97"), 4206, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8df63c0c-1f86-4460-b16c-564c54649640"), 4555, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8dfefc02-82f1-417d-9018-066f6465eeae"), 4721, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e2b37cc-9cdb-4279-9b1d-762452ece991"), 4029, 1, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e2f06f6-b2c3-4440-87a1-da35a27f32b7"), 4517, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e30d15c-a4d9-41aa-8469-eff2e8173b9f"), 4715, 5, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e601e35-aa7a-4067-819d-7a1f5067ee80"), 4103, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e6189a4-2c61-4b6d-a5a6-3d4f1416e507"), 4559, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e6b1d2c-0cf4-4f6d-a93f-9fc3355a79c8"), 4501, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8e8020c9-2c96-4ebc-be4f-ebdd4ccf5fad"), 4614, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8ee6abdf-77a4-465c-b6bf-abed909b886f"), 4022, 5, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8efa1b06-e09b-4fc9-a2d2-7b6708cdd8b9"), 4301, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8eff8291-2e97-486f-b9d6-4a67e5ea5fb0"), 4513, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f0b56e7-16a6-483f-9223-07e438f811f0"), 4459, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f1f2fc4-7e49-4dd8-8773-16b1337c37bf"), 4503, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f4924e6-dd5b-4695-a8bd-9325212f186a"), 4417, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f49c2a7-ad3c-411a-ab6f-fe5b8a0232b9"), 4303, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f614fc7-7713-4445-b252-3709310af14e"), 4623, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f875971-33a4-409b-b4d8-d6e087092b37"), 4110, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f91f884-6b2f-480a-8ac0-b8f077b4e3dd"), 4513, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8f9c30cf-5e65-4b04-b2de-7cd6b4d0c0bd"), 4445, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fabf025-f265-47ac-97be-221a1cf4e8ba"), 4001, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fbebfd7-dcd9-4082-ba76-6804042d0996"), 4700, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fc1434f-ed45-47b0-94cb-c88c9456fd7f"), 4651, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("8fef8b16-eb12-48e8-a309-b8c3bffd6696"), 4241, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90092f52-7498-404b-9e4c-6f5c0cdbf45d"), 4409, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9017d1bb-b27b-449f-a9b6-edb471e00dd0"), 4002, 10, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("902beb9a-234d-4fba-a2bb-9b35579597fd"), 4442, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("902d172d-45f9-42ef-8cbd-9d9d5c238be0"), 4546, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("903f738b-74da-4ec0-a32e-b2653f66e5e1"), 4804, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90529bbc-1482-429d-af57-7a61d4110af3"), 4403, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90584612-3506-4e1b-a898-c5258696feeb"), 4212, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90ab2db6-7c55-4e78-ac94-a2db2823bb17"), 4224, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90b16305-6e10-4a83-bb32-fc4be1953f7c"), 4208, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90c245ac-3fa6-4aef-97be-1cb35a7c850e"), 4274, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90d76b16-9e19-4363-ae80-e42d4bb35e3b"), 4107, 10, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("90d97305-f14f-4038-839a-8b417b254939"), 4108, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9111a5f1-e042-4dab-a83b-6a8183a3ec0e"), 4217, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9115ce34-a3f3-4e29-a76d-cf4e5cbf35f8"), 4629, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9116de7a-28c6-44c2-888f-797bfb5f6c42"), 4232, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91291d75-eb73-4d4b-b951-740802f4a45f"), 4529, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91350612-da46-491e-a2b2-cb9f3b41f3af"), 4607, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("916c5022-769c-457d-b15e-a2c2ce89877c"), 4614, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("916e1501-545e-40ec-a5e3-6254cdc23bfc"), 4271, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("91765d36-56b1-4862-b224-f1df806a5714"), 4410, 9, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9179283a-92c0-4c90-9373-3a36843cf1bf"), 4031, 10, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("917e9842-dd56-451e-83fe-7e122a30e195"), 4538, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9198e87a-64b6-423f-942b-252847461d75"), 4017, 4, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9224cf01-e57b-4472-81fb-6cc4d070616d"), 4657, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("923d90df-3f26-41d1-bd80-c379ec1cc327"), 4637, 1, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92414b74-b03d-4bd4-91fc-0230fddd9316"), 4428, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("924b1cbf-d7d3-461c-b8f4-96dc9456a63d"), 4809, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("924efbd1-bff6-4eeb-bd71-48de1f8c3b41"), 4245, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92581806-608e-458a-9c0f-d35e2a40efde"), 4462, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("925a344e-bc73-4d94-9d2d-90d2c5675030"), 4305, 2, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92875256-4821-438e-830d-02dc008123b6"), 4520, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92a70f08-3a91-4376-81e2-63d9e8150ac2"), 4017, 7, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92b62147-7b3a-406f-bf9f-ddefac1ff07c"), 4514, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92d395f9-2492-445c-a89f-43fa1c7296be"), 4110, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92d48a1c-c4c1-46f7-889b-de1514affbc4"), 4719, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92e3d0c7-42d0-4fa9-90c8-766ae8bd4f7d"), 4255, 9, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("92fa0710-4efb-410a-b411-459e55b97621"), 4233, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9307fa3b-b577-4a17-aa10-6029cde4fa8b"), 4623, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93151df3-6eb8-4b15-be46-dbf05dbc7690"), 4420, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("934c5a19-2d48-4e0e-90d0-9cf0a0fb7f69"), 4226, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9351dfa1-67c0-4a86-8a76-c5d17f9131cb"), 4563, 9, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9371c1be-4756-4a36-bb63-5151a7fa9cde"), 4104, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9377094f-4f6c-481a-9f0d-8fc1d14bb0c1"), 4717, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93814dca-d1ac-4208-a08d-8cdb53636d42"), 4614, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93a31a77-68b8-4eca-8363-d76349272bbd"), 4260, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93a7c38e-12eb-4050-99a8-097c4bb9f1ec"), 4019, 4, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93b33627-a26c-4024-bb5c-a8f9288e8c31"), 4557, 8, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93c2f67b-cdcc-400e-a8ea-b4dc707e9bce"), 4533, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93d4b6b3-e152-4d84-a27b-7c650f1d4cb9"), 4445, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("93df905f-587d-434c-9214-8b6e3d08c601"), 4433, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("940d8e5f-61c3-4d6b-80fd-d2ec03617e36"), 4546, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("942e4ca7-58bf-4d82-b066-68c12b9bfb9b"), 4002, 9, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("943768d8-5181-468d-9e90-a730e9f7b966"), 4534, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("944623c1-b5e7-4c34-b7fa-e740a4db8201"), 4401, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("944ad86e-1ac1-40e8-9e3d-65be0b9d97f1"), 4010, 5, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("944c6a23-39fa-45f2-beb3-60ed87869077"), 4512, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("945837fc-2624-4dea-a3fa-b7d871e3ef51"), 4628, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("946fdf62-a507-4875-af0d-1a389cb2c26d"), 4657, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94994ab2-46ba-4163-8f5e-6a172e0b2cef"), 4248, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94aa4785-c69e-4bbc-a2a3-aedc9ba412f6"), 4115, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94c3cae3-b786-437a-8b7d-b158a70bdee8"), 4259, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94c9f06a-06ad-40fd-9373-99344f787521"), 4400, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94cb079e-eeed-4b29-93ad-ce19f75c2456"), 4565, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94e6f38e-cdbb-408d-a940-5b36ca00d02d"), 4460, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94f22fd7-3d5d-4490-8786-70364db7deb4"), 4552, 4, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("94f5ce13-1ae0-4f6c-922e-282b0f2c5b14"), 4511, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95002691-80c0-41f0-b709-bfe3e7421f45"), 4802, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("950aeee9-a33f-45fe-ac4a-6302ceccf9c9"), 4421, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("950e70bb-e334-4a39-96d5-dd982efb5fe1"), 4245, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9519cebc-166b-46fe-a080-3c57cf8fa8f0"), 4801, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("952defc5-1193-4163-b749-5e91f91f1a25"), 4515, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9532ba04-eff7-43cb-9560-2b085a190808"), 4256, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9538e3c0-449b-472c-833e-4cc348ddd0b6"), 4217, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95699cbf-3d96-416d-aac0-523a8f7b81ae"), 4713, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("957f2593-c1d6-43fe-89f0-7f68f8ebfd5f"), 4008, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9585d143-3756-4b93-aaf7-89b33b87e2b7"), 4259, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95952ddc-4875-41ed-87e6-12aba223a46c"), 4504, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95a0abeb-7636-409a-abec-a7c52ae3fe60"), 4516, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95ad80b0-f51f-4913-b308-092279453b9c"), 4431, 10, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95bc9ef7-e77f-41cb-b609-10df7f19914b"), 4242, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95e35804-13c3-4afa-9751-83e758cffd8f"), 4233, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("95e5872e-9d96-4e0a-b047-86edb5c93acc"), 4444, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9601de86-b955-4d44-ac11-d43b1248f5f0"), 4219, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("960616dc-ef14-4ad3-b37e-58843b6bb021"), 4805, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("960a51d9-fc13-4cf3-a879-8845f48091f5"), 4437, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9616137f-30fb-48ad-b0c4-7dc9ff90d905"), 4459, 2, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("961fa4fb-e066-4c96-a65d-83bb81add858"), 4716, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96211075-c04d-4c09-9132-c59581455cad"), 4307, 3, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96286324-4f9c-4df7-97b4-bd8aee4ecfaa"), 4804, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9630620e-37f0-4b12-9c42-c9b17c7fc837"), 4035, 3, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9638fb3e-2f8a-4e1c-a09e-8a27114e036b"), 4633, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96449657-6857-4b0e-84fc-909ea20adf75"), 4305, 4, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("964b3ea3-774f-4510-8cab-34b509bcca3f"), 4426, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96571232-5c4b-48a9-8f65-8375f4a7f534"), 4624, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96633399-d580-4f87-9aa1-b8e9b488e6c3"), 4512, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96711504-7ef9-471d-b4db-aaf1f1f0aa7a"), 4564, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9686109c-4ded-424a-a23e-1f02d9b7c0cb"), 4457, 10, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("968c7a99-453a-41dc-a1cf-dc1370e7f132"), 4806, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9693c896-b7a2-4262-868f-78013800310e"), 4416, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9695e982-cd19-47b0-852e-6582c43128aa"), 4654, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96bab773-920b-41fb-9bbc-3303e07c89fd"), 4213, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96bebd86-0a2b-4ab7-b3ff-c26c87021b5b"), 4536, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96bf320d-a123-4ea1-807a-9771267c060d"), 4424, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96c6bd98-6b3c-478e-a37c-a84197da2e07"), 4028, 3, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96d48a1f-8db6-45ec-b4f1-8de1bf8e5468"), 4313, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("96ef1cd5-5de8-4c60-b7e4-8c75fe3aff3e"), 4454, 7, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9714ef2b-cee4-4b7a-a8f9-6a06ffcb5fa8"), 4203, 6, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("971be79e-2105-4290-b88b-1870acb12d64"), 4264, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9722f086-6f00-4d03-b92f-521a3c234e76"), 4429, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97377f70-18bc-4cc1-acd3-d36d7ac05222"), 4557, 4, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9745c85b-ca5c-4d6c-8f99-8904b2aaab93"), 4432, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9788790b-42d0-459f-8087-4133e63e6525"), 4308, 2, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9790e8b0-2d99-4875-9c05-bfcb326d76d8"), 4271, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97916d56-6122-4212-8e01-d2d222e9aa2d"), 4450, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97a5c757-1adc-4466-bf97-5f6286c1babf"), 4718, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97b33d9b-29a2-440c-bce6-85ac762fb386"), 4623, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("97b40926-19a3-4b3b-87ad-3f58ae00be0b"), 4268, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98123620-b2e7-4081-b76b-484372e062c4"), 4244, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("981ac444-3086-48d1-95d2-ce2e1f85063a"), 4617, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("982a0d3c-fbe4-4a5d-8ba6-e5ba5b5c7ab6"), 4613, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("983c7554-cb7a-445f-98c6-98e5606325bd"), 4810, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("985c9fc9-25ac-44a5-acdc-8cad96b47bd3"), 4423, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("985d83cd-2a21-4482-b478-6655d0e545cd"), 4721, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98603f4b-ddb6-4fdf-bd78-660bf7158861"), 4650, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98669cc6-e055-4bd3-b8e5-bafc79acd86d"), 4524, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9878a93b-3068-4202-8d71-435f958521db"), 4303, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("987d53fc-999b-4d4c-a7da-accd4d6f3993"), 4551, 2, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("987fad75-07ce-4ce5-b95e-d05df9d949e5"), 4313, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98847e8a-913e-443c-a463-a32ee2421568"), 4241, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9893f605-c621-4b40-b578-022f2ee0d003"), 4235, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98a174da-a3c8-4720-b90b-1218f18a25c0"), 4272, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98a3c397-4794-4145-823a-efc878731e32"), 4715, 9, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98c88162-5204-447c-9118-1a399f5afc32"), 4545, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("98d6bc09-d160-48be-8fd9-352992d47e47"), 4552, 2, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99087bb6-7460-4ff4-a355-aaafc1156916"), 4453, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("992309e1-1412-43a1-a964-2b5aeb96a8e5"), 4009, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9930a22d-0500-4cb2-94ba-1e18d0842c2e"), 4400, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99378f85-8bca-4dbd-a810-2c602b9ea615"), 4608, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99678cfe-d1a5-492a-9f31-e259e93aac2b"), 4850, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99848a6b-f474-4bc9-8762-1dbe1911af36"), 4012, 6, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99c76dbf-8c78-4c69-97db-d791f1013d26"), 4710, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99d64336-f44a-47a7-9085-e1514c306bf2"), 4500, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99e13520-1366-4018-8bff-b007b790bc79"), 4441, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99e61e2f-6e53-4837-ba9f-6e465d19a45b"), 4529, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99e85ee7-e4b0-4e8d-885d-7d437d22882b"), 4712, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("99fed3dc-1a95-4d40-bcab-bc5ab130c18f"), 4621, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a04a2ea-492c-4053-a0b7-553e9ed323e4"), 4511, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a4a4983-454b-4305-afa3-ec2ed348b7c6"), 4411, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a4cb9d5-c485-43cc-b572-b9fbdf6a5a76"), 4004, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9a58a77c-0491-45c7-95b1-70201e3def01"), 4712, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ac8676f-b85e-4f71-a367-ca7c1613be53"), 4003, 6, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ad8977d-97b3-4bb3-9180-ad86757a71f9"), 4531, 5, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b07ae75-cb9b-404e-aab1-5a91ed43fff1"), 4274, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b08a16f-64d3-4a16-a791-c5b1ff271f2a"), 4271, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b0d2a3b-8047-4d99-a351-d4041d944550"), 4506, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b1a5d15-a153-4aba-8e51-844fdd7fa850"), 4417, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b23d64c-985c-4f4d-b763-0131d78ed661"), 4209, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b246754-66f6-4dac-96f2-f0c9f679dadb"), 4007, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b260790-540d-4ef5-89f3-a6c1e5bd8458"), 4259, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b351069-3873-4c61-b8ea-c2dd45ce1dbb"), 4222, 8, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b3c3a7b-81c2-4c5e-85e6-0f6a6f4fa614"), 4625, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b3fb19a-e51b-4be0-a1f7-1608c2d0af7f"), 4435, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b4c60d8-5590-49b2-bf82-83133c890e88"), 4606, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b59af75-d1c8-4421-90ba-409834eb661a"), 4414, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b7dc0cd-9f40-4ed8-936e-95e53d87a940"), 4309, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b8675cc-9b6d-4b6a-895f-8ff892189f97"), 4022, 9, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b925a94-2c47-407b-b7b9-1c861494d22a"), 4107, 5, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b93fba3-4822-4ee0-9e3e-b59960289154"), 4722, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9b9ca224-33ca-44d2-affa-7538a3407158"), 4253, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bb863f7-6955-4f0e-80eb-e488a0df45ca"), 4455, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bcc06cc-b36f-480c-9ae6-2a55edd57b93"), 4019, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9bdd7b8f-6d45-4ccf-b7a0-8b00e278168d"), 4803, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9be6d478-12dc-4f71-8cae-fe056e50769c"), 4607, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c03142a-f607-4003-9389-87f7167f77a3"), 4556, 5, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c0633bc-8dae-49ee-8dd9-a381bab6b7a6"), 4852, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c087015-999c-4112-9c66-bed846f3cfbb"), 4851, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c13ffa8-2b83-4020-be9e-7e021bae2944"), 4229, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c1785bc-948f-42d3-a51b-ca88c6c841cc"), 4720, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c2ca8bd-438e-48f8-b9e4-aaf53bc263ee"), 4028, 6, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c44a7c3-51c0-4157-89a0-a20918c74602"), 4309, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c82505b-844b-4e59-9571-7e323ae42629"), 4212, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c965cbc-b849-4865-8093-b309bbe72fa8"), 4219, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c9d51e3-3cbb-4969-9e2f-88e45e77e6d1"), 4722, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9c9f0aa6-d497-436f-9710-92fb8e266abb"), 4263, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ca763e7-5b2d-4460-aceb-a3fd6417cc60"), 4509, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cc76b00-ceb9-41fe-a7fe-a474f888daab"), 4429, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cccbaff-d8d4-4d3a-bfc0-a0c21ac4a003"), 4245, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cd44707-9b06-44d0-9733-182f3c697cfc"), 4319, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cf41ea8-c409-457a-b853-18356b342b9d"), 4704, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9cfebdf3-eb23-4cca-8691-75f71da46d29"), 4311, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d0196f9-5571-4816-aa33-10ce32f50cc5"), 4401, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d11840b-1733-42b2-a5ea-4eb37551b6a6"), 4427, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d47fdae-0d4e-43e8-a2bc-b98edd0d5414"), 4263, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d5ddd0b-ffba-488b-99b7-9ac0ec004935"), 4237, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d7b8a52-7f03-4f6c-98a6-1d2629f6cce2"), 4450, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d8b147d-3549-446d-a879-cd16003ce185"), 4010, 2, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9d92f9a7-6825-4170-ab6a-d09cebc78a60"), 4565, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dc33c17-1c70-42ea-8ae0-94c3d5fdffab"), 4220, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dd3c919-8c07-4798-ba2a-15c67ce7f4d9"), 4461, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ddaddd1-1a7b-430e-8ad1-ccdad164c92d"), 4555, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dee347c-f54a-4c3a-bfe5-8ebd591cbb19"), 4464, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9dfabc82-a904-43ba-b4b0-b667098292d7"), 4458, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e280686-3ae0-41c1-8f5c-91956c08fab0"), 4267, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e2cf66b-0a24-4ead-b2b9-12339ff42195"), 4244, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e3e6b0d-d375-4b88-aeeb-9796bd5c8766"), 4300, 9, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e552ce5-f6e8-436d-861a-4d6440ba4bb1"), 4720, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e5881c9-4530-4474-ba6c-d436604290d8"), 4661, 1, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e5c60ec-a1f6-4489-8f52-d6e3d0f36105"), 4723, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e5fbb73-85fb-41ad-a672-c2aba8199f7e"), 4720, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e61b987-c56b-422d-b944-b8c1929560f4"), 4035, 10, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e635c92-e866-440e-a4c7-69b0a520068d"), 4654, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e728f03-e80d-4cfa-aa1b-6f57421d9d7b"), 4320, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e733394-eb83-44f6-8b05-35d24a7c499c"), 4203, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e84bba0-3ff3-4f44-92e4-e2ab77f03cfd"), 4534, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9e8685b9-333c-4dd1-aa3c-83c584551c2d"), 4242, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ea05d1c-120d-4508-b3d4-18d5a479b188"), 4552, 6, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ed10209-1d88-4fb2-94bc-8059273f5f6b"), 4225, 6, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ef9dc78-aee0-4f24-8654-f2349a6239ed"), 4238, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9efae3fa-f941-4f0e-8ea2-bf1bb6aaec62"), 4514, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f1aa74d-f526-4633-86f6-74f7d6af653c"), 4206, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f3cf8c8-f56c-4233-9ba1-f027446f4de6"), 4809, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f3d864c-81b3-4702-9240-4e0df641ea94"), 4542, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f420c38-337c-43bf-8957-a92a58cbe886"), 4500, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f53b894-03d3-4628-9fae-3443dd1015fd"), 4257, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f594c93-b140-4a8a-a4c5-2d57284a7ed2"), 4708, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f6a33e8-a16b-4762-b980-e0f0b26f7d14"), 4552, 7, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f6ec52d-a961-4e26-903d-6599ce914bc7"), 4633, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f7fd1aa-6716-4e1b-b9ce-bec47e4ced73"), 4424, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f871f45-2267-4ddf-984a-8e70da202acc"), 4032, 3, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f874f55-904c-4b8c-b2b5-951d59e2671f"), 4233, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f9a3b75-a14c-4c11-9942-aa8426224efa"), 4711, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f9c0f41-4bb0-45cf-9390-f03cc44e515e"), 4604, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f9f79ab-0037-4b3e-ab88-359835c44ab4"), 4630, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9f9f91cd-0951-4c0d-8f7b-f06d40858bc7"), 4029, 9, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fa6aa88-49d6-4937-9488-72f3c3cc1e8b"), 4019, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9fd79260-0f92-42d0-92c7-ce84a7e7f45f"), 4213, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("9ff11aaa-6bd6-47d1-a3a2-aad625d9de40"), 4558, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a001eba5-db2c-4796-a257-04fb8fa2dda7"), 4273, 2, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a00aee7c-e9b1-44fb-9bc5-643ec6cb8b9c"), 4234, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0367233-f4b4-4732-9675-5be37995ff44"), 4303, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a03c03da-516a-46a1-96f4-c87293aadb19"), 4810, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a04fdd7c-bd50-406c-8c25-3eadb406ff39"), 4701, 6, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a05a88b5-f9bc-4238-a70c-494ec0cdd429"), 4852, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0925875-5d54-46ae-a12b-fe933ce22d43"), 4010, 7, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0dfc9e1-b8f6-4d60-a9ab-8af9b1fbbc47"), 4552, 5, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0e44c8f-0d55-4f8a-ac8e-7e5514118f1d"), 4227, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0e8805c-330f-4ee8-853b-9239565f6ff5"), 4555, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a0e8e388-f0bf-46e7-92c4-edf7279d336d"), 4521, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a11ed35b-1394-4121-90fb-1be18d94290b"), 4255, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a14b2612-3576-4b05-92a1-8954ba8b99e9"), 4524, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a15e30f7-bc32-489b-bab0-fd1f4c98db29"), 4608, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a15f234f-e8fd-4d2a-bc0a-de55a4e17583"), 4268, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a193cafa-d11b-4bf8-81e8-d079177ffd1a"), 4265, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a19435ae-580e-4085-98ce-c372d34d9e6c"), 4303, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1a6f047-29bb-467d-a112-8445736c4926"), 4633, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a1de2192-5308-4d29-b683-cddfe6160dfe"), 4619, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a206f56d-5f3c-47e0-a37f-dffc0cd1784a"), 4109, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a214e160-55c7-4dd6-886e-be23e4cb5780"), 4212, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2390e83-1bba-45d1-be39-f85b096d65fb"), 4650, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a239104c-9eb5-4218-8a12-cdbd3fdc1ce2"), 4238, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a241beb1-b5f6-4836-b22a-490a08bfd09e"), 4656, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a243d433-9a0b-4abb-88f7-adcd3ffc8ffa"), 4800, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a25dfc9c-3328-43b4-8531-b50925346c3a"), 4853, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a27ff8f3-d3b7-464d-86e0-f43f6eaa9b04"), 4419, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a291bf05-2a03-43a8-ae2b-ea8a7906376f"), 4446, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2ac130a-930e-4e57-b77f-334e9a75ec73"), 4658, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2c3a809-7479-4bf8-b0d4-cd723e03e7f8"), 4514, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2cbd12c-cd0b-4aa1-9e2f-bc9d09143fa1"), 4413, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2d64cbb-7478-41be-ada0-2bd09db793e6"), 4522, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2d73593-b555-498b-841d-497ab9fa74f0"), 4637, 9, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2e6215a-7833-402e-9834-342983bfe195"), 4011, 3, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2e77d95-8fec-429e-bd75-b8a11cb73468"), 4213, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2eee08a-c067-4387-ab49-a0ffcf63fd97"), 4804, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a2fe1e23-2b34-4648-9822-2645c1a9d3be"), 4008, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a300a3d9-3cd8-4d22-8748-c475b5b89bbd"), 4424, 10, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3134614-44cc-4b51-9167-10bbc945b061"), 4011, 10, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3166b7d-2fbe-4dd3-9661-ff2e286bbb8b"), 4527, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a32c42b2-d066-4645-b17a-ffdf0a9027be"), 4314, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a33abb1f-6d6b-4549-874d-249f9fdddfc1"), 4259, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3774095-8b88-49aa-9c6a-8313601f6bef"), 4264, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a37ab4b5-6c32-4753-be01-c6ac9133b792"), 4502, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a39eb501-c768-4631-a75a-7c2f081100d1"), 4416, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3ab5a18-6563-4d79-8dbd-4ff6724382c8"), 4508, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3cad843-238a-4b37-9beb-156966535ad1"), 4714, 6, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a3ea3c43-e6e6-4020-8ead-879b134a9264"), 4613, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a40db30e-8326-4f32-af7e-b01def9385d1"), 4433, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a41ce4be-1e23-4b50-9346-1d45ad5c2786"), 4037, 6, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a428066b-3ba8-46d3-8d93-66652db1050a"), 4458, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4340002-b52a-458e-8cdb-5998b388bd17"), 4713, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a436e562-0815-44e7-9a3e-c03920157848"), 4311, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a439b239-790f-47a8-bfc6-2dfa49244302"), 4212, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a43b6bc3-2162-4419-b1de-277ab8479d2d"), 4556, 7, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a45d1da2-d2a3-4495-a7ad-692f9cdc131a"), 4425, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4688b63-774c-4249-a88a-e1bd2930684a"), 4507, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a46b981d-6611-47b8-bfe8-98b738c8047d"), 4437, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a470d644-f6f3-4f87-b8e8-dcd29fbf190b"), 4111, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a47fe302-3237-448f-8f8c-fc26a1d31b4a"), 4302, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a489c90c-cf80-4877-a4e9-19ff53540e44"), 4403, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a48dca64-f681-4b46-92e9-3f2a080cffc9"), 4654, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4921b3e-2dfb-4baf-b092-866b41e244dd"), 4806, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4963ca6-976f-47ce-be6e-f0ea9da34782"), 4006, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a49e0b62-6f75-4668-97bf-35910192a1b6"), 4323, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4a5d2bb-5add-4828-9691-243283fcb67f"), 4705, 10, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4af023d-20d4-49cc-9f11-d116a5f32a89"), 4407, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4b5ab36-a777-4ce3-86e8-70eafbd80c29"), 4659, 3, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4c3954c-400f-473f-b288-922984c8f5fa"), 4201, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4df3de6-39f4-47f3-9a90-43fd30aeb90b"), 4562, 5, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4e550a9-3d31-46d3-9779-c1f12b6545f3"), 4314, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a4fe100d-b6c8-48a7-a4ff-1cc306978ce3"), 4640, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a511953c-8efe-413d-9aa2-668544202f4d"), 4526, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5176ca6-9e68-451a-8422-510e7a42b3af"), 4444, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a51c2efe-83b8-4a85-882a-262a79709ea0"), 4216, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a52e18a1-8245-41f6-b735-cd6637a0bac4"), 4103, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5321566-6a91-4a94-b663-e173f89609a7"), 4211, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5334976-b0e1-47fd-b4d7-2f900eeacaa6"), 4547, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a54f7328-6eb1-4477-8ea1-10df0c4896bc"), 4503, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5581eec-9419-4e0b-b347-9c13fee591d0"), 4805, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5ab7b5c-da93-4da1-95e4-9fba34bb4e67"), 4465, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5b59a2a-f949-459e-bde3-9900cf15e0e6"), 4465, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a5d498f9-c1d0-4b82-be63-8f9e6403faa8"), 4851, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a619887b-1123-4dd2-9601-f5f65d9e178e"), 4223, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a61cb8e9-dd02-4549-b4eb-103734a32a0b"), 4565, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6224ffd-2c06-497c-bcc5-63916961f56d"), 4522, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a62db1a2-5526-458a-9d22-05ee3a2d9f17"), 4640, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a64ae7ce-761a-4b82-b63f-c174de5deea4"), 4631, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a65743d4-7dd9-4d99-9b94-1894ccb0475f"), 4850, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a68af0be-1ea6-4f8a-ad8e-ef722fac17c2"), 4018, 3, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a69460fc-a574-4d93-8394-2676f0607582"), 4218, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a69d9938-f9dc-4c25-81ec-66fa7218eb32"), 4105, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6ae818f-8d7e-4f43-8443-4c89d578552a"), 4632, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6dc49d3-5480-4788-ab73-d33c0006c861"), 4029, 3, 22 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a6e95255-684f-4674-8cbe-89e69fc77c09"), 4709, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a717eda4-2128-4e23-929b-cfc9b4a9ee44"), 4205, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a71a628f-5dca-491f-9cc4-4affcb402c50"), 4545, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a73e1186-725f-4ef0-9f11-794d4fb64a19"), 4852, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7494c15-1cef-4870-a7e6-0e3b45f3e648"), 4221, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a74bbf19-e2e4-423d-8304-42b9b7ecd559"), 4856, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a766220e-2917-48c9-9631-21014785bcc7"), 4634, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a772439e-f391-4517-aafb-6b497374a5db"), 4035, 2, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7770746-9e26-4b8c-8ab0-1f3e44f1abb0"), 4635, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a78a0bff-b9e2-44a0-ba72-943b9c497bd7"), 4715, 6, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a78dcfcc-b0cf-40cc-ac09-9131fe24fd5d"), 4509, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7a10080-e046-4909-b7b4-7e2dbee5acf1"), 4413, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7a90024-4afa-49a3-9af9-f30e5b32fa2b"), 4248, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7ada878-187e-44f4-a7c2-01fa77c79f5c"), 4407, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7b84b95-0397-48cd-b0ce-337077a3cd9c"), 4270, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7b9081a-27c1-486b-bb73-c5f22a8b9594"), 4221, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7bf21ca-b0fb-49e0-be12-76c1b1ad64b4"), 4254, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7da7bf4-355b-4e89-9231-366bebb2444f"), 4305, 1, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7e087c2-ba7b-40bd-ac14-a829af1eacb8"), 4021, 4, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7e7b5e2-6103-41c9-a60a-abe7c79bee50"), 4446, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7ecb30c-8067-446a-859f-87725d4be72b"), 4525, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a7facc48-0226-473f-a25b-ac9228dadb4e"), 4423, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8316ab8-aeaa-43c3-a458-d39354029982"), 4720, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8385320-26f0-4c30-a439-c4b01c8918bd"), 4536, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a83d8039-023e-4649-accd-066273539403"), 4800, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a840877d-e224-4975-a33b-15407afc6adf"), 4530, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a84178ed-fa51-44eb-8587-e2987f237522"), 4013, 1, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a84dbd9a-da8a-4462-8218-0c9e326c2fc9"), 4702, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a856b826-89be-42fe-b1c1-4450ba0703a5"), 4024, 3, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a87f2061-e229-4c5b-b563-f16ed3c6691a"), 4563, 4, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8a19b91-07af-401d-865e-ab27d48f842a"), 4216, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8d77c21-8745-43a8-9982-a72ef9039b84"), 4539, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a8de1ee3-6887-467a-80ec-590139375945"), 4211, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a945a730-664e-48b4-a661-e1c4025f25a8"), 4441, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a94ff0ec-6915-45ae-98b4-afe486fe0f14"), 4635, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a95ada42-1d30-42af-a23f-dd0ce400e956"), 4625, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a95cf726-b866-4e73-9eb2-d9268fd08b8c"), 4259, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a99c800a-f5c9-4bc9-8da5-94993403f9ca"), 4465, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9a45a98-00e7-4eaf-a2d3-f7d6501f9541"), 4717, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9b9835e-f090-4ba0-a9db-6657e30ff518"), 4504, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9cdb94e-f020-42aa-ae35-85a9d1a39743"), 4723, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9d8bd4c-52d9-449b-9789-a390f0bde644"), 4535, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("a9fe0552-5a29-4ad3-ab4d-8ad96e6ef1f0"), 4419, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa359a20-d2bb-4b3f-8248-4bcbad7056f1"), 4101, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa3c58c2-985e-422d-9766-3de63acdafb5"), 4716, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa444de5-d7b8-4edb-963b-629af1d7bd2d"), 4460, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa76d053-662d-4888-8949-213080a3f7d1"), 4504, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa7c54f5-727c-4b32-baad-12851e263df2"), 4202, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa834594-f0bd-4fb1-8e42-a2759c79121d"), 4536, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aa9979b2-b358-4a4b-b5d9-6d6f25032339"), 4437, 7, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaa1bc42-d446-4913-93f0-c18805a62b85"), 4658, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aab74c6a-bb48-4f14-9231-0b788d50fab9"), 4411, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aabc1ea5-0bbe-4ee4-ba3e-55f50fa6de79"), 4259, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aac33d47-b681-41b2-83b1-150fb6636e8c"), 4222, 3, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aaf86219-08e5-4f49-bceb-4dedc0f3db06"), 4311, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab0b32a5-f2d6-4c1f-be21-49df5f2f1bb3"), 4112, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab23c6f2-cf39-41c3-91dd-26b78d8a7fe3"), 4262, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab4486ce-0abc-4a22-8a10-4c06e52825e0"), 4807, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab626fa1-7d9f-4697-8c0d-9a44d48db88d"), 4563, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab742090-c39f-4b60-b19d-87f1f27155ac"), 4507, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab944ffc-4efa-4a18-9f44-2aad154fa07a"), 4458, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ab9500d4-5b71-4440-a396-9d4a46ebd3fe"), 4612, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abd77e47-285f-41f5-ad01-64015d0b907b"), 4856, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abd876c5-d1e1-4adc-b6a7-da2022c02959"), 4541, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("abe9b9e3-a6da-46f3-b91f-c7a05e5e76e4"), 4458, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac06564e-ea49-48ae-a2ef-9a0a4e1fcf13"), 4557, 1, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac0bbc87-91d8-4a60-a7e5-90167f2c08ac"), 4003, 4, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac15c1b3-3719-4e1b-a663-a841fc95a975"), 4509, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac17188e-080a-46e6-93b0-984ebfccafa2"), 4248, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac205610-0848-487d-98c8-c2a780a39a89"), 4031, 2, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac207acc-eb3a-4cef-9009-0e1b13ba4307"), 4716, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac55cc11-369a-456f-825f-fedf6bf55754"), 4713, 3, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac586642-9e44-494b-a1b3-1ff2e1e8bc82"), 4264, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac6b3ce8-2ec8-488b-b816-b549ca506226"), 4542, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac736d6c-cf74-4214-a528-1ba9b8d8e3ab"), 4463, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac7a98a1-8cc4-4514-b5b1-f1b61e667d0a"), 4611, 8, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac7e2cf0-b36c-4658-8cbe-974eb510c043"), 4507, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ac89c85f-d810-40be-9fac-888e4c34a711"), 4657, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acb1c410-b4eb-4ef9-a458-5358c63a7e7e"), 4216, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("acc792a6-42c8-4ce7-957c-405441781596"), 4213, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad1b07e3-a328-41b9-a75c-853a0dd46bab"), 4719, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad2bf92c-2527-4016-a70c-98672b23449b"), 4455, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad3469fb-a52b-4ab2-9b9e-c598439b5ac2"), 4242, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad474c12-653d-4828-8cd2-87a4ef3833ca"), 4526, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad566b34-c9f5-4f3e-a15d-e1e0b3a85c99"), 4547, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad6d3834-754d-41d0-b11e-b37989c06229"), 4436, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad8a7d0e-b894-4b96-845d-0e6a2af1418c"), 4622, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad9003a1-6d23-41cd-90e2-bf53b269e510"), 4027, 2, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ad94ac75-eff4-495e-8b99-b1e647103cb7"), 4553, 10, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada323bc-1fb9-4f67-a088-38648871a99b"), 4535, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada32d5b-2526-418c-8217-43452c3eb7d7"), 4247, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada6908b-cf5a-44fd-b06d-76df8f88f81e"), 4805, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ada7912e-6b77-46aa-89f7-02db5c95e23b"), 4020, 4, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adb3a1ef-c277-4efe-9eed-b61d8690351d"), 4446, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add1057f-434e-468c-bc08-9c62ac982cec"), 4202, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add26894-ae78-4078-bf71-c162ada349f3"), 4023, 3, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("add5411b-df00-4ec3-bb58-fb3f01ada3ca"), 4210, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adda6542-2c35-4235-8df7-b323c32c9631"), 4318, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("addaf50f-1811-4da1-be39-e3c2a3d62056"), 4323, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("addcb286-b46e-4090-a449-c7f0837916a7"), 4016, 2, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adf3659e-9e9a-4057-9bf8-afea0cfefdc1"), 4429, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("adfdf934-d954-4eaa-b0dd-58c7e8ff9dbd"), 4560, 9, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae0028ff-7438-4b63-8aef-142af08f2fcb"), 4627, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae0ac50e-30a5-4a67-94e1-c7e9cc6a34a2"), 4519, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae1bde9d-2c13-44ee-9775-a9682bb45423"), 4539, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae2e1048-ecd7-4f79-9879-dce4a15450d8"), 4269, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae379d41-cefa-443b-9656-a35253d4c337"), 4451, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae53b19b-8a1f-4bf7-baf5-aa0bee85082b"), 4503, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae54570f-d260-4770-80a1-1e3445b2ccb0"), 4219, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae663433-f5b3-4257-a8fa-dc319214690d"), 4600, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae68b9ff-ca7a-43e5-a5c2-1a4464616a92"), 4033, 7, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae693a90-2112-4da9-bee1-92b3bc0a2cb1"), 4408, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae702a13-f1c0-4ef0-9060-fc6be3969402"), 4610, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ae7bcdc8-628b-473c-9ad1-dc60444098f1"), 4408, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aea8fc06-3ce0-4852-9776-9c6aacc4e1fb"), 4809, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aefb4ff5-722e-4596-bf71-59aa70c6715c"), 4456, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aefc32cf-4ead-4853-aad4-d93a34e436df"), 4027, 1, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aefcaddb-f2a2-4419-8706-1aa4c9d83d01"), 4540, 7, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af189893-96ef-476a-aae6-18d07a502865"), 4640, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af291057-0398-4ddf-8fd8-ba03c270c511"), 4714, 3, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af675178-340a-4161-9ca9-29f5992d819e"), 4208, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("af96f63e-c326-4f7b-8c5f-f1fdbe07549d"), 4402, 7, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afa2556a-3c54-4bb9-867e-2a30310ee696"), 4560, 8, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("afa78829-6593-4de7-9c2a-f63d04a8ba63"), 4415, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("aff2aae2-d141-48ca-aa72-71cf61014097"), 4030, 2, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b00146c9-e2b8-476f-a22b-73666f55bd32"), 4625, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b00cea2f-e86e-4326-a9af-bccdd99a0ec8"), 4446, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b00f49cf-a213-401d-a0e2-db0f41dd92de"), 4527, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b07d412c-4459-4948-a987-a1177328be7c"), 4016, 10, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b09740b7-7ead-4288-abd1-53c48690f383"), 4719, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0d18d9a-7295-4c6d-b156-db5df330fb50"), 4037, 8, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0e5ffc1-52f8-43a2-99ec-841525023d49"), 4641, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0ea10ac-e6d2-4f85-9402-086ae96144dd"), 4109, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0ed7404-7f67-4961-b80e-bf4d7bf8388a"), 4432, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0edf125-f46c-499c-8eb4-c73d3e5e4b61"), 4600, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0f75546-3f5b-41ec-a32e-1a035b52035d"), 4515, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b0f95482-d3e9-4139-8860-2ddb995cdc2d"), 4654, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b10b98e1-96cc-4d77-85cb-e1c0908d74d8"), 4247, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b11cdbf8-94ba-4a8d-b854-33db838eea16"), 4510, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b167d70c-5805-4258-8bae-e63b7b8ad756"), 4637, 2, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b17927b4-94de-42b4-9b7f-e3f6b6fbe210"), 4400, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1991f66-e14a-49d4-9d21-05c9fa288d1a"), 4562, 7, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b19c7823-18f0-45bc-8870-3d5d289798b2"), 4219, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1b45d76-dda1-4385-b8fe-5662f038f198"), 4610, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1da8447-228e-46de-aa69-62aeda29181f"), 4246, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1f4f15a-cdfe-4e98-ae7f-617fcab8c541"), 4409, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1f688c5-c10d-4ea0-ac8c-6eeaf894a8b4"), 4034, 7, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b1fdfb59-c6bd-45fc-8eb0-b67e4666909a"), 4533, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2017684-c643-46bf-9a22-682594ce696a"), 4804, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b217d6ab-c725-46fe-8b30-d31bb08d257a"), 4306, 1, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b23adabf-cbdd-46f9-b0a9-85612a13461a"), 4101, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b250fb1d-0087-4f41-afa5-a185c8bca296"), 4630, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b261c6fe-ccec-45c6-8bfb-6f63d1c61fb1"), 4441, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b26f8b7b-2cd2-4e9a-b93f-aefafcbdf161"), 4621, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2bd9086-5dae-4dd3-9fb7-37f902f868a9"), 4005, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2cb019c-7671-439d-80ab-58b1a286e344"), 4401, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2cc9c16-75a6-46f1-b58a-c34c375afbb4"), 4503, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2d35919-8c2d-4870-9588-c2bf6f1c1025"), 4856, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2e1f283-7944-4e9c-a1e2-d07a7d6d2c69"), 4616, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2f02229-d190-400a-85dd-277cbf8c38a0"), 4313, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2f4bfbd-c0af-4f0d-a833-7abd15361ce7"), 4445, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b2feb1d3-d879-4d5a-a5db-0516fa319f32"), 4438, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3171289-8f9c-4f2e-a2fb-3da39862229d"), 4019, 9, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b317e35d-94b7-426d-8c90-9a01f62e3988"), 4318, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b320e280-233e-4082-873e-2472cd1de822"), 4455, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b32fc34b-50ce-472a-b375-21dd11a4a0aa"), 4401, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b34d86ac-1323-43b5-a187-d63d9e712623"), 4109, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b355716e-29cb-4c31-a3a8-ca9628a6d0ee"), 4001, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b36a98cc-1201-4b34-afab-49be31a14184"), 4624, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3876472-ac28-4792-83dc-5b44ddf9f0ca"), 4501, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b39b7e34-deeb-4a2f-b177-dbcc0455d909"), 4462, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3a93c40-f5ad-4c40-bbf4-c9de9784f1f0"), 4008, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3b56c3e-5f93-4dd3-9c25-d01151a7e1d8"), 4659, 6, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3b77353-b850-401a-bae1-9ce8a933c52d"), 4715, 1, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3b908ac-c19f-4e8c-8295-7b9c850273d9"), 4023, 9, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3d7e436-ef56-49af-8ac8-9c0ff867177b"), 4249, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3df598d-2aa6-4dcf-91e1-9a2ffef2ebb8"), 4417, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3e3a481-7518-42c2-98c2-6c35c1c257d9"), 4311, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3e83f79-d659-4575-8d88-b9d727087c92"), 4406, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b3f92e2b-1800-4579-aa5c-04b021b779d6"), 4307, 2, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b400646e-40b5-4c4f-8600-3f22f9b2635f"), 4537, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b408a5c6-122c-491a-8a06-a3b8785ec757"), 4208, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b40cbf91-c853-4ebe-990a-26d12db7c9eb"), 4272, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b40d9ad5-a55a-440c-a5b6-965676287fe0"), 4321, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b40ef997-0f4f-415b-9d9c-54801bf25d2e"), 4256, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b41252ae-b463-4162-8176-ef2019a2b4ff"), 4559, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b42e6f26-3d08-430d-89d7-bbcb7d155bdf"), 4227, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b42fe4b2-718b-49ed-b6a3-eb7b8c95e96f"), 4018, 5, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b43059c3-99c9-463c-9908-9815e5d4b7df"), 4256, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b46bf064-fde4-4021-9178-d2d75109a895"), 4255, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4b0f2ab-f3bb-4d79-92fb-1e66d8c6553d"), 4209, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4b2987a-ccf6-42da-b61e-d5769cba7d5d"), 4555, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4b6740c-1743-467b-82ad-3785d52c4af6"), 4713, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b4f4d81b-6e42-4c6f-a4d4-54c73eb889ec"), 4261, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b50e6c6a-40d9-4657-a86b-7284fdaa49ac"), 4317, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b51bdd9c-9a2d-4a6d-8cb6-44672127d415"), 4612, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5319a56-b343-4344-9914-9572a55a3d70"), 4440, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b53a74e8-ddda-4b00-a247-6218c999bb3f"), 4458, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b53fa8ef-78fc-49f1-b2b2-b226bf860fe2"), 4851, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b54de921-f9f6-45fb-80d5-0d45f3157890"), 4706, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5a23573-2cc9-4a3b-951d-5a51f0bc3578"), 4807, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b5b7f727-1b0a-4158-a0eb-4262eef785e4"), 4621, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6248d72-70b3-46ae-b615-b8fc2752783b"), 4661, 6, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b62bbd7a-4bb2-48fc-a713-6d7cfcb4b660"), 4617, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b632f1d3-3b34-45a4-8853-1187706e38b5"), 4413, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b63b638a-08f6-45d3-b12f-e6416e6f68f9"), 4006, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b67f63df-782c-4837-93af-57894aeb604a"), 4655, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b67f86af-2840-436e-91f7-35fb303717db"), 4022, 10, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b68b08c1-dc45-492c-a5d0-3460b59bbf3c"), 4561, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b68e1bfa-12de-40ff-a702-b8bfb95353d3"), 4111, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6e02486-a5d9-4a16-aef9-b75e1d194922"), 4024, 8, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6e4eece-fd5a-4d77-a6c8-dbac90e8706b"), 4529, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6e8dd00-40e6-4398-9155-59b5fb390369"), 4270, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6fa1bca-f566-4545-a05f-fd7a8d9dc475"), 4001, 5, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b6faa7c3-37a2-4f85-a0a9-37cbaa534e72"), 4457, 8, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b72451ba-1965-444c-af1f-6d6399958510"), 4629, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b748e08e-3187-4427-a273-0ef51d9ef32e"), 4652, 6, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b74b3d46-4af6-425e-ba39-5a747bbaf0c1"), 4249, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b752c337-1872-4c40-8d27-c084b9b37eb9"), 4709, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b77b043a-3f86-4b5d-944d-5238bf8c2d79"), 4635, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7876ea7-5e6b-48a3-a695-f1c56697ccc4"), 4563, 2, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b78faebe-34b4-4ff9-9997-545e88477217"), 4319, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7a4415d-040b-4900-a471-0d3494f2e407"), 4806, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7e5fa54-3558-4511-bfea-ff1eadf3876e"), 4316, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7e74724-54b2-4644-9ae5-ad1242131517"), 4509, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7f0a886-a446-4320-9422-488b39402ca0"), 4712, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7f38649-6ea5-45e6-87fc-eaff9d83dbfc"), 4464, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b7ff1f21-ac4b-484e-893d-3a5efa0f6ae1"), 4035, 8, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b85103f7-17f7-4097-906b-494ad2ac4314"), 4514, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8604eab-8e19-4feb-99b5-0dc92b47e0d3"), 4852, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b863eb01-d3a6-4955-a9ca-3eac74227db4"), 4551, 8, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b865624c-27dc-45a9-a479-03443e4ad9be"), 4106, 5, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b897b565-8cbe-4366-987f-386fbfeca3b4"), 4445, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8cb1fff-db4f-49f2-a006-8dba0f3beab9"), 4273, 5, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8cca82a-7cd3-4167-9100-487a631728c5"), 4264, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8e93f22-8455-4ace-855f-e435b2eabad8"), 4542, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8f7398e-9dde-4aa5-b5a3-fb685ce9d1c5"), 4518, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b8fc479e-68ac-4897-903e-7797cf554cd6"), 4714, 8, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b90dc893-330f-4fb4-950d-0185ed4a4cf5"), 4722, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9152da1-beed-4ff0-b605-514286ab1449"), 4230, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b92ad732-529b-43d8-b41d-80acd65db6b3"), 4012, 8, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b92f3130-a919-46ae-a9f0-5d599866bf6b"), 4700, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b932e39a-44f7-41a8-882e-b1c5250f77d8"), 4639, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b939747a-fe25-4067-b9d3-9149825ae95d"), 4307, 8, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b954628d-7a96-402d-9e55-f3e20a9e58f7"), 4426, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b958b9f3-3273-4743-ae6a-a3cd0d69a554"), 4308, 8, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b95de47c-1108-4908-9be1-07faedef04e0"), 4447, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b96d5401-fbef-4fc8-b582-ce2991a999f5"), 4854, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b97f7986-1a74-4c0e-81aa-79ee36dbc97a"), 4434, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9b5c6c1-7757-4293-a9c4-7b5f5c0204cf"), 4320, 5, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9c13666-5974-43de-a47a-f5f57225a6a0"), 4239, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9f0cfea-f59f-45e2-8ef1-96b3a7ea0b2f"), 4265, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9fa2f5d-e75a-4670-9737-b95761c8fb6d"), 4457, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("b9feaca0-8f59-48f7-aba9-a9ef6014f1b9"), 4017, 10, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba0ad1ee-46b4-4686-8e5f-180a861a6654"), 4457, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba0c9878-a011-4519-8fc7-7c355b3f9493"), 4438, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba116a65-6b8e-4336-967d-5ffa27554b80"), 4201, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba13beb5-b15e-437f-87e8-a01b46317381"), 4536, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba14f42b-66f3-4cf7-ab35-d99c968b46f6"), 4109, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba18512f-8fe2-498a-b4fc-8db7eb7ce53e"), 4802, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba3603d3-cd57-40c6-937c-68341ca98fdd"), 4264, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba41ed04-9b1d-4ffb-be03-3542b564676d"), 4457, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba67e7c5-d610-4bb3-8dab-39be3a935b78"), 4034, 6, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba726a80-2efc-4929-879e-f14143f5682c"), 4611, 7, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba776049-17c6-4f3d-806f-c408f4529d40"), 4105, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ba7c676b-8031-4b60-8d8e-7bd323d506ba"), 4216, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baa8de05-b43d-4f80-85ac-85103a320b97"), 4402, 5, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bab2c362-67b4-48e3-81c4-e8263426f956"), 4541, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baddb2ea-d793-460e-a649-db6424926a10"), 4709, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("baf17d87-5786-44e7-bfa4-52c7b423d660"), 4230, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bafb52f7-38a0-4f01-93a3-90c49223c291"), 4238, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb1cb187-54c4-437e-a293-22fdf39f7ceb"), 4205, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb3563b2-9073-45e5-b29a-da62bed71962"), 4435, 1, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bb881f7d-1a45-4e5c-8509-f3750dddcf05"), 4104, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbadcac2-839f-4964-a9d4-8f4fd7233ed7"), 4547, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbb4d244-10b4-4ae9-99d4-29e3802258c9"), 4614, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbdef160-999f-4311-9713-fc6b6c7b69ea"), 4267, 10, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbe29c3e-0887-45a6-8053-4bba0952faa5"), 4615, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbe2c290-604b-4712-ab3e-16c04a16b58f"), 4504, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbeca1a6-9609-4192-985b-3609f0c82881"), 4032, 9, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbee7868-b303-4880-9b2d-5eadb7e6241d"), 4314, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbf61821-bc8a-4770-8b3c-d832be95fa3a"), 4809, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bbfb4e55-784a-4938-803b-df9173aa7bbb"), 4533, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc005610-aa38-409e-8bde-47e15b95072c"), 4704, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc109a7d-17bf-4d16-9aae-6f48dfa3fc31"), 4720, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc123c6a-025a-467f-a5c2-61197dd23285"), 4714, 10, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc1ff0ed-985c-47b9-a8c4-d1e78c99f986"), 4274, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc23177f-43b6-496a-85b3-5425bf0e2e97"), 4404, 2, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc23af05-7fdf-4eec-8b16-8297e4728b1e"), 4425, 9, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc328fa2-e9f0-49bc-9349-c3e26e4b420b"), 4441, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc3d6a67-55f0-4c7d-a0cf-78f874050ce3"), 4229, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc4a5ee9-a788-4487-80aa-c29249791b5b"), 4508, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc5d2c81-8b14-48bc-880f-7d3f2debe6fd"), 4261, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bc6e8292-85c6-416b-8438-ccfdd0340369"), 4461, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcac7baf-2725-4e5e-b6a0-3ef56e738860"), 4443, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bccef89a-af57-4db2-8176-1c0dc71d016b"), 4604, 5, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcd8886a-9f9b-4fb7-84bc-9b32636a36fa"), 4430, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcde598f-eaa8-414b-95f8-8ecf0d25780b"), 4412, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bce8eb60-55bf-4f3a-a41f-b46d8e7c7ace"), 4663, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bcebc137-ff59-4176-aef1-cb8e47dd6fec"), 4507, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd003b70-5907-4fe1-a8c0-b0f0a505959a"), 4228, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd01aff3-1b74-4418-b408-96ae87dbdbc3"), 4546, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd0537e1-bc0a-4d1d-9eb5-6cedaea0a334"), 4601, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd124fc5-27ce-458e-a146-7fa32b95589b"), 4006, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd1638c4-74c7-4b0e-a918-229ffbbeb696"), 4010, 10, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd168ccb-888f-4b83-992a-70242851d8b7"), 4023, 5, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd4c1c71-384f-4747-8e45-f89c175c8ede"), 4714, 7, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd5ce287-6077-4a44-b8b6-85718ab0d314"), 4260, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd6834fc-0f32-46e9-9cc2-0e82965e8aa0"), 4443, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd6eca2c-0102-4d44-be92-94d734d6e885"), 4544, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd7ffdba-3445-41a0-be51-a867de137199"), 4307, 5, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bd854fd7-93af-495b-8efd-610f4b0706c5"), 4809, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bda6de86-de31-4124-97b7-b78e38b28066"), 4553, 3, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdb7f47a-88c2-4125-9977-f85d38008cf9"), 4559, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdbd5ed3-2e21-4489-acc7-e4ee5ac7bd71"), 4623, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdc0e706-df93-46b9-963a-b9ff6c1488fa"), 4447, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdd8e84d-5743-4b6d-9934-6c0703200652"), 4215, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdde4edb-fb4a-4649-b3f8-dbda3bff1fa3"), 4201, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bde6167d-dc44-46f7-ae56-0e134254f413"), 4250, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bde7d0fc-8ad0-4a71-9abc-aa6b0332cfc9"), 4639, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bdfbe5cc-eaed-4a98-99c5-171ab8856e2c"), 4542, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be054e88-a0cc-4954-b01f-dd973c0bdf13"), 4242, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be14ec1f-c369-4fdb-8efb-7fb247437f88"), 4563, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be25941d-87fb-4670-aa42-02d3925d9ef1"), 4034, 4, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be27ae55-742c-438f-ba39-04c1fde8342e"), 4247, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be2aecdd-797b-4562-b879-39aa0eb6d188"), 4208, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be449116-1d33-4662-8658-0520b0e9ee4d"), 4856, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be49abae-d678-483f-bc7f-8957ac9fabcf"), 4112, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be5aeb95-5eb9-478a-8575-f5ea5bfe6c42"), 4428, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be5c1a43-bc8a-4121-944f-e4abeec9aba1"), 4314, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be62cb01-a458-4333-aeb7-46f2ebbff93d"), 4436, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be75f536-3e80-423a-abda-f08184c22146"), 4008, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("be9488a2-56cc-4519-98c7-48a31220bb6b"), 4527, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("beba19eb-5be9-47dd-99c1-c8ba0f2a6107"), 4024, 1, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bec4f44c-bf09-49eb-a04c-4ec9e2b688eb"), 4440, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bec97ed2-ccb3-4583-b431-1d306848b215"), 4231, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bed19287-f808-4343-86c3-6811f37c216a"), 4413, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf0d97b0-6c62-45a3-a5c5-2bb4d9ee6163"), 4250, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf19ee00-4713-4a1e-b19d-396becfd8c79"), 4232, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf25d8ce-fb15-42b9-a470-0e9a82062229"), 4637, 5, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf30b580-ea21-4849-b20d-1e56b250cc89"), 4102, 9, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf36c05b-1d04-4722-88cf-f6074610ed5a"), 4652, 8, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf3ddb38-1801-4a76-9dc8-d9f7aeb25da9"), 4027, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf41ae2b-7b63-4701-9dfe-cbec8bf1b56e"), 4658, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf4fea5f-7483-4d07-a5f8-4b8ed401fe42"), 4653, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf50b55b-e0b0-4c3e-946b-1799553ea090"), 4106, 10, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf7f902c-6fad-426d-96a3-3348c05f4bc8"), 4309, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf8f6500-d3d1-4c80-8aae-bc7327496ec2"), 4113, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bf91bbe2-53a8-474e-b834-c65c19223b90"), 4022, 2, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfa2dacd-9770-4480-9ef7-f243cb32f6f0"), 4607, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfb34949-0793-4130-ac89-56f0e47702fa"), 4253, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfe29956-7b9d-4c4b-b9b5-b43fcf5dbacf"), 4205, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bfe43ecd-8157-4dbc-962e-534f069317ee"), 4605, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("bffe05af-fbc6-4444-b791-e51019bafbd5"), 4808, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c00d07d0-82bd-48d3-b752-2c77e6734045"), 4545, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c018a571-5f21-407a-9ec7-dd1076c04416"), 4266, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c020d169-2431-454a-81ca-c4a06e93fbc2"), 4604, 8, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c022b3a9-4489-48d7-8e49-ac30e86b2e06"), 4000, 2, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c04f8278-310e-43e3-99af-8446244cbf18"), 4251, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c05af02d-736d-40c5-afdf-deaf135f147b"), 4106, 1, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c06cf18e-abbf-4855-a327-ac8182ab3a2b"), 4447, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c08881a4-02f2-4c5f-a635-98a018b1999b"), 4551, 3, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0927b9e-47ed-4974-8534-a437ee62baea"), 4432, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0a471e3-17d7-4bba-9034-9039d2c9955c"), 4435, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0bfdcce-898f-413e-b487-f5f0602dd338"), 4305, 7, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0cb3e58-8475-40f1-a2b1-b34956b030d5"), 4855, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0d2eee3-18ae-429e-81ec-82de29b3b8fd"), 4241, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0e2439c-3600-4082-b8af-987f0aca474f"), 4422, 2, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c0f47aa3-0b87-4242-8dc2-d497413b6e15"), 4641, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c11aab4f-9023-4f03-87d7-135f344e04bf"), 4537, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c12195bc-8662-49e9-a427-38e5604b1885"), 4107, 2, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c122ce4e-6a60-4a82-bc7e-1c4946a5712a"), 4711, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1310ee0-41bc-46bd-bcb3-f06bcf636769"), 4852, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c13c0ae8-edb5-4cc3-8b22-4ad227d8e955"), 4271, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c13d4857-c27b-4d37-9411-1bbd57b74bf8"), 4615, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c171ecf2-6fa3-4eb6-bd5a-7787f372f773"), 4404, 5, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c176fb4e-5593-4e01-bd60-1e667113142f"), 4463, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c180ac8c-6d53-47ed-965a-9b4f5ecc7708"), 4320, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1852aca-2b12-4b88-a99b-0c4c8f26ea68"), 4028, 2, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1b03f38-b144-4080-be8c-165017e52a2a"), 4320, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1b661a0-c187-43de-b015-9e6b826a80d6"), 4703, 5, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1db7e22-6ad5-423b-a144-5ca13540b6ee"), 4633, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c1f44783-23de-4b9b-b491-9e81e02fb79a"), 4439, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c215aabb-d2a7-4fb9-89d5-1ced4c4482ae"), 4620, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c21d4737-0242-47bd-b745-d68f9f5386f8"), 4505, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c228b5d2-ee30-4912-9a33-ca4368a0edec"), 4102, 3, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2362313-f80c-4f45-9e55-6f2fc1ccec1f"), 4000, 7, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c23749d8-d45f-4065-a69f-8de62480828d"), 4427, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c28a442b-0d64-43bc-81db-b3efcada211b"), 4030, 10, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2b1848c-6310-4bd2-9d7b-f0f747d5c254"), 4114, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2b2bc53-3a24-42fc-857d-2feea28567a8"), 4200, 1, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2b8c017-09f2-4293-8213-55450d5bfedb"), 4650, 3, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2b981d4-4f7e-45f4-909a-e134a097b965"), 4108, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2c881e5-8290-48b0-ac36-f0ad8d3c7a50"), 4227, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2caff4b-ebfd-45cd-8030-6c4b1456c239"), 4609, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2cb5b21-4d3a-404f-973b-33caf1e87257"), 4404, 6, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2e0e733-867a-48ad-8d96-78ee491626f9"), 4501, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c2f61189-09aa-4077-89d3-e5ba3bd1b11e"), 4037, 3, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c341d8bf-4fc0-4ec0-ae89-bfc16edd88af"), 4618, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c36efd1d-7195-4a18-bb6d-67fa6c16b5cc"), 4529, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c370c9c1-fa32-4035-9a3c-8239487d0651"), 4234, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3726908-8beb-4538-af03-5aa6f59af503"), 4465, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c37f8715-92ff-466a-8915-b5f289a9f620"), 4801, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c38985f8-3c0e-4802-a3b9-4d9bdf5da3af"), 4323, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c394d6b2-7ba2-4325-8114-392330b23fd2"), 4654, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c396c81c-a964-4db4-a4bd-1b0239cdb583"), 4538, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3abbfdf-e553-48c8-a732-abd4e2c07104"), 4244, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3b1370f-4885-43a8-914f-e89c0eaef14b"), 4259, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3b57177-7c97-4f4b-a93c-4d98bdc2eb69"), 4651, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3da2e84-94f7-44a6-a5bc-ebe3e04d5b8f"), 4610, 5, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3e05b5c-0683-4b11-870f-f41973d8533c"), 4658, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3ea81e4-1f50-4859-9533-70261f1a53a5"), 4603, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c3f1b7cd-2b6f-4427-8e37-f5657353b862"), 4450, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4076351-24cc-42e7-8395-8fa2a2f77736"), 4662, 8, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c41f94f0-abf4-4981-a1f9-6e9ae5674b59"), 4030, 3, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4530022-8ac4-4f55-bd16-3262d7366e92"), 4517, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4533c21-719b-418f-a804-8a53af0f1bcb"), 4310, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c460bdb5-4003-48fe-9bc0-4b0ae22b71a2"), 4709, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c46480e0-dd91-42c4-8ee3-cb4c8981b87b"), 4110, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c466ae1a-dcf0-4b14-a624-28c69aef4cfe"), 4311, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4693236-284f-4625-9537-768b5a030bcc"), 4243, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c472ede1-60e5-4f75-8d81-bd667d12bf36"), 4660, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c47b265a-df43-4bc1-82ce-b676a7927d8c"), 4301, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c49b3bc9-c699-47d1-9840-0731fb7b7601"), 4218, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4a7083f-d4e8-4d1e-8f22-b78497cdb3bb"), 4315, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4aadf81-8a6d-4503-a007-a2b1cfa06aa1"), 4631, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4af22a8-1b7c-44f6-a0de-23e452d9ffdd"), 4447, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4ca2a52-e913-40f5-9a89-f6e8b1a9faea"), 4721, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c4ee9a51-64a4-4c5a-a2ff-f78f2f269587"), 4620, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c56c4e3a-78fb-4e8e-ae75-6a957e0c96ee"), 4564, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5a70385-d9a9-48e9-a7a9-a14ca8848be9"), 4653, 10, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5a82810-885f-4b3f-8b09-50009cde41d9"), 4272, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5ae2acd-55ed-499b-ae15-758209acf32b"), 4101, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5c86318-da3f-4ab5-ae97-c7fc71f1ffbb"), 4114, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5cc22a1-6f32-4d11-9581-2173200387a9"), 4513, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5de1e85-7997-4d70-a7cb-d1eb6c1218ea"), 4015, 6, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5e06557-dcdd-4570-821f-82e20ee96923"), 4462, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5e51277-40b5-45d9-bca1-782e6b27a479"), 4459, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5ea4804-4dd6-4d0d-9a60-eed4936d2104"), 4229, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5f3b27e-20aa-4066-9cc6-0e3da905ec5a"), 4557, 10, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c5ff2770-ecb2-4e89-b2ff-7445b6f5b6b8"), 4304, 4, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c613f976-601e-49dd-be1c-3bdb521eaad3"), 4551, 9, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c623ca10-0c87-4702-b169-1eaa4b51f01e"), 4627, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6362002-4594-4fa9-94db-301f9e99ff46"), 4115, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c648e1cd-e2c9-4336-a36b-e6faaa35ea86"), 4507, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c64eb44d-a963-4971-af62-7a242ea7f7ae"), 4037, 2, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c65f7fb0-4f59-4ac7-81ee-bd9d50d449d4"), 4239, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c66c4260-ab14-455c-a74e-96335e970bbf"), 4630, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6825244-3ab3-427f-bd78-7452bfc507d2"), 4233, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c696e5bc-bafc-4a13-941f-4178b3c4f4a3"), 4202, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6a00e95-b1a2-484c-96fb-84afed9f2dd9"), 4714, 1, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6a1979c-687f-4f61-b6bd-f529c28fcfec"), 4108, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6b11ac1-f37d-437e-950c-71250bdd1f40"), 4220, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6bf1388-324e-41e0-9ce4-d9e97b883d7b"), 4508, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6c010ea-f2b5-4a6a-950d-6c26200f6746"), 4501, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c6c328b1-0744-4edf-a179-d187ef133cc7"), 4015, 5, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c70a0493-5e73-4784-928c-e018e24d0ad2"), 4537, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c719cfb9-30ad-446d-8bc9-7e51c2742883"), 4007, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7422739-031e-426a-bbd8-e0b2e65cb85b"), 4403, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c755d97d-677e-4785-8319-24bae65279ff"), 4653, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c75c1a1e-c00f-444c-9935-9f74ce859b5f"), 4562, 1, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c772c0c7-059d-4113-97ca-f542fb17babe"), 4631, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7828ffb-eec7-456a-b3b2-0a571c4b790a"), 4603, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c784f470-fb7e-433d-bd96-79401528f834"), 4002, 4, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c78a8c07-e817-49a6-b876-89db40ab8f24"), 4653, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c7d80074-6f50-449a-a3c6-a8f6cef14b00"), 4631, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c812d7ae-5a43-4f19-998e-bcfbc5177537"), 4631, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c81cd03a-fc0d-494e-af50-75e0d9742710"), 4651, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c81f51c3-298c-48ad-9787-8786558bbb3b"), 4503, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c821aea6-5da2-4299-aa20-432e91143294"), 4439, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c84572cd-a7ae-417f-aea4-8194730fdf6d"), 4105, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c853bd2d-a13d-453d-b456-e2202df913fe"), 4406, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8612de4-d88a-4113-9d5c-3e9f50ff5c43"), 4216, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c872081c-e70e-450f-bf81-1b21f102897b"), 4524, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8734228-94c2-41f1-b409-0c095782ff5a"), 4622, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8821de9-40c7-4644-93d9-98ca3fb1555d"), 4420, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8a1dde7-0a85-4882-825c-532c685aaa67"), 4559, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8a9b394-61a0-4b6b-a989-c592642cb838"), 4202, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8bdbda9-2fb5-47a3-953e-62b87fcd645b"), 4226, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8cc7633-63eb-45ee-b024-de4ef5f5fb6f"), 4711, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c8cf40d0-fba0-4150-b4a6-1e25e7831276"), 4632, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c904d9fd-42e1-467f-8d22-f660484dae56"), 4704, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c930c315-b52e-4718-9798-7bd0edcb66e0"), 4433, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9355925-545a-4032-9474-be8b37ec6812"), 4222, 2, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c93787ad-8705-4bec-9d32-63027acc88c1"), 4011, 5, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c93ee3dd-bb40-46d5-aeaa-2f8d01c1cc3c"), 4525, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c941a370-e9e4-402a-8264-530188df4f0c"), 4605, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c960252b-3f0e-4c02-b4fd-a5774f303801"), 4458, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9613b3a-8ccd-4cc7-b640-a748292ac45d"), 4712, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9622aa7-0ad6-444e-b8d9-b722c7481165"), 4518, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c97a61d4-1db5-4671-b1a7-db64b59519e0"), 4522, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c97d926f-e9f1-44fb-bf46-c8128a5f6d2d"), 4442, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9805416-2eee-4b88-8f44-434886661e34"), 4626, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9a20db8-2040-4a65-927a-5fbb317fea00"), 4255, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9a9a4e5-1a60-4d33-a985-d42de27aba99"), 4260, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9b55db8-3e8e-471f-99e7-aa05b06fb848"), 4617, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9be7ee8-79e8-427f-ac50-db573b91afd6"), 4100, 2, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9c5554a-ebbc-471a-b234-f2abfa31cabd"), 4423, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9c9f99c-9cbe-4c51-bfad-49a7450a3fbc"), 4001, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9ce8bd2-0625-4fd7-b5ad-2603b7bc45ce"), 4611, 4, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9e1ad43-c9ea-4327-97ec-a3daa32a35aa"), 4006, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("c9fefee9-2685-4dbb-8bd1-d5cf9b3c2b1f"), 4808, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca054674-3eb9-48f9-aae0-4da045821aa7"), 4545, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca0ba22d-0386-4baa-9ea7-f9db185f5229"), 4457, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca21e31e-649a-421b-a698-56aedabba37a"), 4237, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca2e01cb-1937-4a91-a7be-b82f0273fcca"), 4561, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca4a008e-5cd7-455b-8560-630e90224ed9"), 4550, 2, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca69bbb4-3846-483a-b385-b935c4770494"), 4316, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ca6d6f79-f2c7-497c-b70d-4fecae7232f9"), 4233, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cab92066-fd77-414d-bdaa-e9b2786ab1c5"), 4423, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cac31035-239c-428a-a322-04de139a2927"), 4661, 4, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb0df299-e030-4f85-b9ef-d2166ed5b39d"), 4428, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb100ba7-a6e7-4ebd-946e-1979880bbbdd"), 4802, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb1acc31-8db9-42be-910e-0e58e92f5f35"), 4628, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb5352a6-209f-43db-9909-75e61f68dca7"), 4000, 4, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb54edd9-aac8-416f-b3a2-9b606a9add3a"), 4105, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb5e8b02-8237-45f6-8350-259b8de39f0a"), 4850, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cb8604db-fc76-426e-972f-cadc051e5a08"), 4802, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cba27753-cbc8-4d22-90a3-3bfbca12873c"), 4805, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbb0d61c-a32f-45af-addf-939d3a09e6eb"), 4265, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbb1d194-db9f-467c-a170-68c289e7a843"), 4708, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbbfc516-d608-45e4-904e-05e06e7e63bb"), 4303, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbc2ba1b-1d54-4aab-98a0-2aa0882ca417"), 4221, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbc8dd23-84dd-4d5d-bcfd-aa9ea8faac9d"), 4513, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbca0fd3-03fc-4ee5-93cd-5e44f26c2d4d"), 4663, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbcb31e9-f5c0-4d6a-9a34-44b97e2303a8"), 4527, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbd51f6a-6d46-46db-aba7-59833ca51841"), 4602, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbfcbd79-2ebf-4a99-92f7-98185d769641"), 4206, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cbff4432-f58d-4b5e-8f79-d1a6c3d4a75b"), 4012, 10, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc0a1609-6aa3-4ab4-b84f-c36245292b6d"), 4637, 4, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc13e310-1ccc-4dea-a66c-818b6896c30c"), 4114, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc19175f-6574-412f-8cf6-0be5ab23eeff"), 4308, 10, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc20b350-4b33-4698-8290-16854980f89a"), 4210, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc2bcbd6-0a91-4dab-a271-c13abd88cfa2"), 4514, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc428891-17f4-43de-98a8-0fe267ea19f9"), 4511, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc4b9e39-f11a-4531-bc60-e2bb9daeaf7a"), 4627, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc4e5a8b-3ab2-4046-a968-6d268b325f26"), 4527, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc50416c-afcc-44f2-babf-fec4f02b3716"), 4503, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc57eacf-2fe4-48bd-ba66-929eb7a6247d"), 4443, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc668945-e918-46e2-9008-99afb92b0b58"), 4602, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc745aef-08c6-4e8e-a0ca-c8805d5a5f12"), 4621, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc7c5e33-8245-47d0-8f49-6515e1766a1c"), 4607, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cc9de4b3-42cb-4827-834e-6f7f3cba8f3a"), 4231, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cca4bc41-e9d9-436c-86cc-a777a270f8a4"), 4620, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cca5339e-e846-4fb2-b5a1-e6af4f63d265"), 4207, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccbd4a2e-783f-4010-8a5c-5004d85b7c8e"), 4034, 9, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccbe01b9-c664-4384-8bec-c0eb77fa1aee"), 4438, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccbe20c5-8d5d-4672-a110-2a9b20905566"), 4254, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccdd4184-8ceb-4f19-9d0d-bf2973127d2c"), 4112, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cced4bd9-42f9-43e1-8f8b-dc7d23dafb8e"), 4022, 1, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ccfd8b34-06cc-4204-ab36-60d5ff03a39a"), 4535, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd15806b-f076-4b5e-9c50-a40fbdd9b50e"), 4651, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd19148c-810d-4cd7-ad4e-cc1ff45832a0"), 4609, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd2ec6df-e8f1-435d-87a5-3e2efbd0ce3a"), 4510, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd3c9b26-11af-4a3c-8f0d-b50ba070dae1"), 4422, 9, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd46fea6-5d69-4ffd-bcdb-73f33fe18ac8"), 4600, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd58f7c8-9db3-423f-bda4-6febc7083bec"), 4033, 4, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd5bc001-bddf-4928-b86c-4126e687f40b"), 4723, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd6086f6-a640-46c7-93ad-3b3c46a95990"), 4440, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd641d07-dd60-4ce9-bda5-74c352b51861"), 4801, 4, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd65b6be-97a1-4159-83bf-1476f092dfe0"), 4702, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd71200b-2ff2-4f5c-b33f-b2b5d89b6d99"), 4319, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cd7dffc9-f569-43bf-ad64-bcecaf83ef21"), 4113, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdadefd2-892b-4262-81a7-b3ec99da1e39"), 4602, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdb962b7-c2f8-4a30-82b1-b3dd9f86e8ab"), 4303, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdbbbc6e-1769-499b-9305-78b4a9954e23"), 4632, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdc2d942-c01f-49b0-b092-d1014543b0e7"), 4711, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdc608a3-993a-4d3d-9bfe-6bd8d4f7acc4"), 4401, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdc86bdf-34e0-4a37-8c4d-7e28a4b6f078"), 4020, 5, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdd03b94-6330-4cce-a06e-eead6aa92464"), 4810, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdd3750b-7172-4469-851d-f2577e91bd1a"), 4213, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdda7943-9ed5-4cbc-bbb2-8d9b58faf420"), 4626, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cddca448-4b6d-4ebf-9a9e-5094a40e7bf0"), 4319, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdf9ef33-057f-40fc-9e88-9eb16f25d0f8"), 4203, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdfa55e1-42f8-471c-9503-ec2d70bc0f82"), 4603, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cdfeec0d-aa36-44e3-8ffd-098c3104319f"), 4219, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce2643d9-6400-4e41-a20b-7fc543d59385"), 4317, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce2d53e1-0c94-4d82-998e-358ad0fe027f"), 4000, 6, 264 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce33fdc3-f0d3-4b3c-8155-2ec5b46b383d"), 4560, 2, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce3e2ba6-d28d-4789-a3ab-63d26d906bf5"), 4104, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce449ed0-c63d-438c-8f3f-c567f44cd807"), 4206, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce4ba078-5642-4709-8b07-43da0538325c"), 4403, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce53c89d-6f12-4cf5-949c-40a7d8b4bb63"), 4228, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce6ba5c0-577e-44bd-934d-7fe9027f6d34"), 4202, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce849e2a-2b91-44bc-9004-0851229c0a3c"), 4308, 9, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ce894269-1951-448a-902d-55eb5d0d25c6"), 4717, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ceaae759-f827-4698-9411-92668b68a92f"), 4428, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cece1f81-a4d2-42f1-84f9-23e0397ba734"), 4223, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ced0d084-cd21-4e1c-b7c5-c8a7ab6b84ad"), 4316, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cef7a810-db8e-4ea7-8a7f-e6f082a8fc41"), 4101, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf13167e-73c1-4843-9bbf-8801132f0606"), 4238, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf18cf79-9b95-491c-8be2-678886ace011"), 4410, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cf87fcbe-2eba-42d7-89dd-210c5373beaf"), 4531, 4, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfa40019-3d18-46c4-a16c-92569aa8808e"), 4519, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfa6e159-e918-4972-ac64-ad660a2fdc1b"), 4612, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfabd90e-14c0-4f11-b244-ac5981e4c9f2"), 4235, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfb0085c-5153-4453-8d2f-7daee2465c9f"), 4252, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfc5bd5f-9bc9-41be-aa8c-0abc4a620b3d"), 4520, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfc96258-bfe4-4d21-a7e4-7f82bbc09c78"), 4634, 1, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("cfe2eb0a-97ac-4692-8d46-457d5575e833"), 4018, 6, 4450 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d02d624c-c6d8-4ba3-a286-c513d8318d36"), 4200, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d03410fb-8d8c-4dcf-99a5-f9bcdccd0c5a"), 4462, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d06637db-e0e5-423f-9cca-113cce8c0fae"), 4230, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d067ff7f-0eba-44e1-9fc7-519d462ccbc0"), 4543, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d06c2f64-a9eb-4193-b5bc-16d3afd23d4d"), 4025, 3, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d08213d4-fb11-4d57-b886-ea16cc5a6426"), 4306, 2, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0885f9c-c964-4d20-879e-d8c7187d3bb2"), 4035, 1, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d09b5e24-d3e7-451e-a9cf-9eef2b4d1744"), 4241, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0a0e9c5-d9d9-4e3d-9570-5cfb5a47f3ca"), 4611, 6, 250 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0a14671-6d2a-41b8-96b7-3ccd986752d0"), 4450, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0b41b53-bfe6-452b-9fad-afbd2806956d"), 4537, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0d470bc-382a-4c61-a261-5be1b20966bb"), 4028, 4, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0e53551-f694-45a5-a2c3-ad31666b483d"), 4617, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0ea8e7a-0dbc-4aa3-8f59-f5e5e06bdfcf"), 4003, 2, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0ec7bc1-7249-471b-8870-5e1aa0cb785d"), 4412, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d0f5de33-3695-4eb4-9281-151189315044"), 4530, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1077d84-582e-4a4c-8c90-b49bd744958f"), 4457, 4, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d10cdb5e-89fd-440d-a09f-efddc30170e2"), 4201, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d10d07f6-2c24-4559-85a4-2da60a43a2aa"), 4460, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1173ca9-40e1-433b-9f95-d00a09d00681"), 4544, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d14d4560-8157-4426-9304-f0a052f4014b"), 4305, 3, 4000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d156106b-c806-4961-8457-6b81f91c3abc"), 4429, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d16b3dc6-cc61-4d71-8067-73eea50989b1"), 4558, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d182ac5b-20b0-45eb-a8f1-6cefdea5f18b"), 4249, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1bf8c06-ce46-422d-9a1d-a65f2a181fef"), 4105, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1c04e30-d50c-42e4-9269-f99af5ce6ab8"), 4718, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1e76c31-d81c-46ef-a288-e9cdd1d55534"), 4434, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1e88d4d-1412-4700-8913-cd313ca5f85d"), 4532, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d1f117cf-b425-473e-b241-56389d12773a"), 4655, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d20e3a31-c642-41b8-a9e0-8a9440501f65"), 4246, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d213fdea-859d-499e-bd8f-61374582e885"), 4258, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d22c0eb4-7108-494e-a103-4f992d9939be"), 4629, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d251cf06-89d2-4136-8ee1-40d5f881a99d"), 4265, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d25bfece-b0fd-4c8e-8ed9-826a5a38c109"), 4638, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d25cbd94-0990-4adc-a872-c5dfe16b19f5"), 4254, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d26bab02-2bab-4583-87c1-9c62eeb1c5f5"), 4560, 4, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2722d8d-1499-4d08-aafb-05703f8dd430"), 4113, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d27c3547-dd4b-4638-922c-4ad99ce19c54"), 4003, 5, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2b24fd5-0188-49b5-b984-8182dfabe25d"), 4223, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d2eeb058-22ce-49fa-a7c2-c30fc4d91bb5"), 4614, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3055bc8-c05d-4cbd-8af4-c34b9a1f57ca"), 4537, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d310748d-8d95-4497-ba9a-845e1dc59533"), 4706, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d329e622-f6e2-4a83-84fb-45f642d21370"), 4546, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3565170-6f38-4fd6-b7a6-f58703f87d05"), 4518, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d35e302b-5bc9-4e7a-b99a-4af808db473e"), 4700, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d368eea9-0614-4f35-9c80-872b135d307a"), 4544, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d36c0db1-f9c1-485b-8e40-0db1c59708b3"), 4221, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d37841bc-47b0-48cb-9fce-66c87cd12818"), 4853, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d382441e-a854-46f6-8209-302c66fbd31e"), 4656, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d38fe6f9-d9d4-4f29-aae9-df7732dd7d39"), 4626, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3a36a82-c39b-45c3-bd0d-77ec03403d52"), 4507, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3cba8a3-cf6c-4cda-8672-8c2dcce92af0"), 4625, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3d09904-a51d-4281-98e5-977a69a4205b"), 4315, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3e01081-2eba-4fdd-b6c0-5599dcbc36ec"), 4433, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d3e2240f-7475-4923-ba5d-8e30251cd168"), 4613, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d411f4dd-da0f-4219-9190-e699c0e52f06"), 4456, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d42010e6-0f9b-4fb4-8a0b-f00165a71625"), 4807, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d424f8b4-52c5-4602-ab79-6f4e0a60fa4b"), 4004, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d431b0e9-936f-4544-8ab0-4ce7173801e2"), 4641, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d43af87a-3b3b-460e-8e23-02198f944c07"), 4615, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d45ad760-8d2f-48ab-85ad-c7f8e173facc"), 4514, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d465f977-6f39-4e09-acee-a68077502ff6"), 4223, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4665813-f38d-4ed3-95f3-2e3b5833dda9"), 4257, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d46ad367-e16e-434f-bd8e-4391b4e65c1e"), 4228, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d46de949-e0e3-42f0-900a-889b3065bb54"), 4252, 1, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d46e0c23-7509-4a83-8b18-766ee55359f4"), 4406, 6, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4839fb2-5553-4ecc-8ca6-ae221a89f512"), 4437, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d48a473a-118f-44d4-a55c-d6e36d670a83"), 4240, 10, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4c233ff-954a-48ba-8258-53855f7255d4"), 4206, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4d66b39-2fd7-487a-ae5b-66a773972f98"), 4310, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4d95147-ca08-4d4a-8b9f-bdeae542c8e4"), 4235, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4e194c9-aaa9-48a2-9c6b-2be76f0c3505"), 4638, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d4e544f1-758e-4de0-8cfd-d0c8f61173fe"), 4532, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d50570ce-1a13-4bf0-87df-79b5a4821c2f"), 4721, 1, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d50a4400-d86f-46bb-8c5a-1e65c8c05760"), 4618, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d51a24fd-f74a-441c-8f9d-543a54d22705"), 4312, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5221ca9-40a1-40e2-a6af-5f8389f66a9c"), 4423, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d57eb22f-40fa-409b-92a3-53e75c7ac2a9"), 4238, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d57f0616-3354-47a4-9b05-0c50a46a70a5"), 4651, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d59d46eb-3d84-4551-a18a-f64dd0f83bbd"), 4455, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5bc1f96-1784-44a6-8c38-67e996f8cbd8"), 4244, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d5d86f64-e73b-4b3a-97bb-4a08f9f20af4"), 4562, 4, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d61579f2-3817-47a1-8296-257787afce64"), 4427, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d61f3584-8a17-4c41-8a6f-93cbea1152a5"), 4232, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d646ed3b-0c4f-4242-ad9d-3afddee44dc4"), 4440, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d665e1a8-c1ce-4f0d-8695-ad3ad01f7566"), 4459, 3, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d666ccd9-8355-4046-84a2-391734dd6998"), 4854, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d66cc7e0-a959-48e0-976e-d2cf03145d2b"), 4426, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d67b11df-86ca-47b8-9880-fb3ae4caacb8"), 4442, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d69400a8-ef79-4e68-8f5d-db26de141fef"), 4415, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d699058f-ed4a-4e81-928d-d302ed9de7d0"), 4011, 9, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d69a94ac-6236-4601-9f9f-1a677ceb0853"), 4246, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d69c04e6-fa7a-4671-ad17-06c27204ec8a"), 4249, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d69f2a15-03e3-461a-89db-9cb17f19415a"), 4502, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6abe6a7-6054-4231-bcde-2a6400db3b40"), 4008, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6c1d180-bef6-4626-a9bb-c8797ae10adb"), 4710, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6c66a88-1108-4e69-b4f7-bb0f56c1f7ae"), 4252, 8, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6f36718-8e34-4349-8b4c-6aaf3d09c074"), 4407, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d6f48892-4390-4553-b3ea-e9727dc73426"), 4657, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7088db9-c431-4219-9fbb-e88d3367f2fc"), 4618, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7140fb0-979d-4fcd-87ef-afe10198c53e"), 4614, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d72422b1-b387-4399-9581-92f3592fcd53"), 4707, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d72fb677-62c5-4198-8155-89bcb85c2e47"), 4201, 4, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d733168a-6308-41bc-a0bc-d3bfad471b95"), 4602, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7364e7a-a44f-4722-a558-30889c0e0893"), 4025, 4, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7488180-e1b9-437a-85fd-68f3bf3c0aed"), 4304, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d75d0561-a5d0-4c91-8da0-7499a8520bed"), 4408, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d79c25e6-542b-4eab-ac71-f5202866cf91"), 4551, 10, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d79c47cd-f9ee-4306-b62f-45bc51f2be75"), 4324, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d79ff8eb-696a-47d8-bfbb-6d507258d129"), 4710, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7a767c2-919d-46d9-89d8-5928b4878c2b"), 4625, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7a8b4bc-5879-4e54-b61e-416bd7402647"), 4419, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7aad662-9d43-4ace-8847-289bc908fd2e"), 4412, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7c9244b-c4de-4682-b22f-8ad01cad2a26"), 4222, 7, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d7e2fc71-8ac7-4031-a903-c73e37f53f49"), 4011, 8, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d800334d-64ea-4acb-ba60-7c8246345972"), 4700, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8250652-84d8-45a3-85b6-374c4cb97dd1"), 4528, 8, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d826e7e8-bb97-4a08-846c-95b6ddcc46a5"), 4100, 6, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d837c231-1c63-4804-8361-0aede6390851"), 4433, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d83b6edb-15ba-4aeb-ba71-71b0372d277c"), 4012, 1, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d83ca99a-099f-437a-97b7-b5c576aab723"), 4854, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8433eac-3544-4a6d-8476-8e6d074f5277"), 4313, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d84f2196-3aea-418f-bdb8-5d423362a804"), 4634, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8788eee-32ca-4237-bbad-377a855563c1"), 4322, 2, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d88493f2-271f-4f2c-8142-ba2ef680be64"), 4807, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d88ffb93-831f-4c35-b148-9d66261f7fb9"), 4543, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8c5bdbe-aa1b-4186-8cd3-65d8cefb28ab"), 4237, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ca946d-3072-4b3c-b767-73d908ba4d25"), 4258, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8ce648e-6c9a-486e-ac6b-9aeb52230162"), 4661, 2, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d8d637d8-4fe3-4a6a-9391-9ef81f7138e5"), 4002, 8, 256 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d92000f6-6136-4121-99a1-517409bf7456"), 4636, 2, 1200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d920348f-d212-4685-9e6f-72e5a2a37e86"), 4506, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9435432-eeb3-4611-b6eb-4341a728611d"), 4529, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d94ebacb-320e-44cb-8058-49d92784ed7c"), 4703, 3, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d958e383-c8cd-40c3-9d47-d7ba6484c915"), 4402, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d959ddf5-7b19-47f0-b1d9-c8b67bb160e3"), 4445, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d95b4caa-5b50-4336-890f-b04c02c90eb3"), 4512, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d964d64d-1eb4-46bf-a1f3-52b9d5221539"), 4324, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d969eae6-3be7-4209-91a8-18f7dcbd5230"), 4317, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d97585da-fa5e-4bad-8e04-c7969dbbfc2e"), 4319, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9847a44-9b5a-427e-80b9-fa5a2905835a"), 4021, 1, 48 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d98a9aa5-33c9-4fbe-b19f-3480ada61862"), 4318, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9b5de3c-e8c8-4ec0-a470-5a31c320d2ae"), 4808, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9bbc126-a3a7-4e75-a620-cd1918f78084"), 4629, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("d9ce3798-bae2-49b6-af75-dbbd0074e8b9"), 4268, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da106b85-c267-415e-9c05-9d3620d1b6ad"), 4704, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da40c0a3-8c0b-44f5-839e-b81df3400882"), 4013, 5, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da552a72-69ee-4686-afd2-3b4d83a6c6d5"), 4251, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da914fd8-784c-4b13-b934-4c3fe23090a2"), 4502, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("da9993c0-802c-4d4c-8141-bfea7e8985d4"), 4416, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dac97ba1-0222-4e2d-989e-fc4c5c7c2dab"), 4527, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dacf7022-391b-409c-a0b2-1718fa081634"), 4253, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db08e41e-b192-4f3c-86ce-f8e342fac9ed"), 4658, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db245c06-3f3c-4f5b-bfba-6f4babffe8c5"), 4274, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db2fa9b3-b539-4ed3-b884-6e9930fafc76"), 4012, 3, 4200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db463f7a-d20a-497e-80c9-b3f42ce4f8a5"), 4627, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db604ed8-7564-4dee-9824-3079784f9f37"), 4721, 2, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("db69c276-80a2-4e50-bde5-fccb2c960612"), 4723, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dba76af8-58a6-4365-a861-e691eb51f9fa"), 4234, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbe5256e-7e7b-4934-9f11-b168dffb9436"), 4432, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dbe7012e-48ac-4c26-a156-c72bde5ef56f"), 4524, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc02db4b-ced5-40f0-a69c-a15c138b112e"), 4800, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc03512c-4c68-4a47-a971-14d5d1fc0a87"), 4318, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc060006-1de4-4eca-942e-3e8a3e0561ee"), 4635, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc0ab394-be42-4a93-b2be-859e1d24c77e"), 4307, 9, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc6eb501-29d5-48af-98e8-9ec5e120a31b"), 4420, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc733cfe-3db1-4300-914a-2c79b6bda5fe"), 4541, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc8fbdfe-e517-4381-89a1-e21ca38cebbf"), 4302, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc91df64-5d41-4b7e-a645-30d4e7dced0c"), 4224, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc9b9b61-437d-443b-be2a-b54d8ed31d34"), 4616, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dc9fd867-07bf-456a-95e4-5d35659fc3c8"), 4657, 10, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dca80092-e3e6-40bf-aead-283e208c7a85"), 4032, 4, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcbdd43d-f2c0-48b1-8cc6-165155295ee8"), 4628, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcc50cf4-2643-41a4-b29a-00b854a98643"), 4508, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcc592e7-9dc2-4ce1-b006-89f509cec389"), 4610, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dccc13ff-c435-4072-a49f-41fe74481d92"), 4036, 4, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcdf65c8-54f1-4b90-8bae-1d2aa6c86ee2"), 4801, 6, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcdf8fb4-336c-499c-977f-2f448f6ed1c7"), 4451, 7, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dce4998b-21bf-46be-b1d7-2e22cf3e1c8a"), 4558, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dce521cb-2ee2-4eb5-8d22-da461cb835cb"), 4410, 8, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcebfd05-63ba-44e7-84e4-db69c8054ede"), 4806, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcf2bb82-08c4-4019-b59e-ea3692663154"), 4405, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcf7518f-05ef-4361-9098-0b9bdb030591"), 4262, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dcfe51b8-3255-4cec-a26e-819cfce300bd"), 4308, 6, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd1f968d-b4cd-4461-8eb6-83c7dda46dda"), 4026, 10, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd23dbf8-26db-4d11-923f-89958a298402"), 4200, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd2acb85-f910-427a-b57b-8a67f3bcb5b0"), 4807, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd682279-f417-4377-ad23-90d00315071e"), 4014, 4, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd6be666-6e9c-4b5c-af0a-ee09a350036d"), 4266, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dd95a361-8a25-4d2c-b2e1-aa42b5a42ca6"), 4854, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddbd3595-e7ac-4ee1-a944-e6c29d9f2571"), 4663, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddbf3375-6185-49eb-ada5-2d4e8c1b62a5"), 4564, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddd98f0b-c4ff-43ea-bb9e-45bd9b041e7c"), 4400, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddf59249-36c9-482d-ab91-52b3e34efaad"), 4034, 10, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ddf7b47f-a71a-4d3e-aef4-2370b4d7c543"), 4034, 5, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de08f6a7-d99b-42ea-a9c4-a051fec3ab8c"), 4272, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de1850ef-db46-4dec-8ac9-e2edb5a066e6"), 4517, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de2a78e2-a88c-409d-a971-9a7531a58ae8"), 4026, 5, 4650 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de3d7239-c26c-4345-a05a-7608e4e5200f"), 4100, 9, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de3e8362-0da8-46e8-bbac-87d5332eb144"), 4708, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de4b1447-6fd0-4211-a765-e2afdaa854b9"), 4619, 5, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de598738-513c-4e9c-ae38-b2012aeb2104"), 4463, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de6fb64c-3084-4304-bc90-3fbed71f3fa0"), 4241, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de77e997-06aa-4177-ba9c-31376c2a4c2d"), 4322, 6, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de817ab7-909a-40b1-8bc4-587c1c6b0b0a"), 4554, 8, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de81c78a-8593-48b6-ae8e-5f2ac94f1743"), 4307, 10, 1500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("de8c78f0-1ad9-41ea-bd15-e2cbe9f72dcf"), 4008, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dec1e60a-9e55-4dc4-9949-8954167164ed"), 4239, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("deef812d-f411-48ea-978a-1aeb4d8c1b7a"), 4272, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("defda894-f32e-4400-a67a-48616aefae41"), 4654, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df158c67-51d5-4ee4-bdb7-d5e88af07610"), 4025, 10, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df16fb2e-eb3f-4eaf-a68d-75eaf4017677"), 4547, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df26d662-9255-4e9c-97e6-e188b015a6e9"), 4623, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df3483d2-7276-4487-96b0-6cdb8d551ee9"), 4633, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df5793d5-0f07-477b-a5b6-c128b9cf175d"), 4635, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df5a7997-8457-49e0-a448-37c788101e56"), 4438, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df65b84a-a6dd-4270-8731-99bd655e1ba7"), 4240, 3, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df783f4d-f648-4790-93b1-b6174f6aab3e"), 4412, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df7ac85d-9941-4bfe-a462-9ba0efcfe521"), 4102, 1, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df81eb21-1331-4156-a017-989012544ef5"), 4001, 6, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df8de706-1b09-4d44-ae74-da0ec0d66e38"), 4521, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("df9ca2b7-5897-4411-a34d-dedb5985f3e7"), 4855, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfb1c0ee-98a2-4a9c-bce8-dbd4bea51bcc"), 4418, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfdc71ae-f8dc-452c-826c-4443ccdaca3d"), 4701, 10, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("dfea02eb-f468-470d-806c-82dac4b93b7e"), 4706, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e01f214a-444b-4a2a-814f-469ad966991a"), 4853, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e01f408e-9715-499f-9702-c279828804a7"), 4562, 9, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e04a02a5-2bad-48f3-863e-84b42a7d5c85"), 4722, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e06fcbd9-b9c1-4601-91be-8458e6985cf4"), 4200, 4, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e07e98b7-e8e7-4842-85e9-e09f54b32d94"), 4561, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0909e59-ec9b-40ff-b8e9-3d41179da8fc"), 4432, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0adc922-4a51-49c8-9d52-2298f0da82b7"), 4221, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0af1e3d-1dfe-4924-9e8f-f6b531a6256d"), 4521, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0b2dea1-f7dd-4cd1-a8c7-945c11c3d7fe"), 4652, 3, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0c1ce57-bb02-4724-9dfc-100dd742631e"), 4438, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0c6555e-3e81-4604-beb3-8492ec7b44c7"), 4013, 2, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e0e1bd89-4b04-4e6b-a18f-fe3ebd3ffb17"), 4005, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e10df052-b905-45af-b049-6752ad4e9164"), 4416, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1231906-3101-437e-8f25-432e80215cc1"), 4102, 5, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e12f4142-d0d0-4343-9e19-98ec728b6d4e"), 4034, 1, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e142ca9c-b3bb-4406-b6b6-ac97d7bebce1"), 4505, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e164c081-905b-4ead-b467-b4b393162650"), 4463, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1764bbe-859c-42bb-a344-72e8a34084b6"), 4700, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e19d177b-01b7-4009-bcfa-1ddb92e4e7ea"), 4508, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1d1c5de-739e-4ee6-9b4f-355b953ac371"), 4321, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e1e07c1f-576a-4f87-a9ee-4d19763f1c8e"), 4550, 6, 90 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e23380e8-30c4-4341-999a-2eeea972f46a"), 4603, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e23af693-7555-43a8-8444-2c97559350a0"), 4528, 3, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e23d51ee-9640-40b2-b2de-f64e6e9e3f73"), 4110, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2558c23-7899-4e4b-9836-7992d23c5add"), 4607, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e25a43f8-36e7-45a3-aa82-aae5df9a3085"), 4228, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e26db22a-21ce-4f65-833e-5ef6c7b60449"), 4464, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e284eac9-e12f-49e7-b0d2-8e6a5109e119"), 4705, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e290f3f2-7e05-472f-9cd9-0b3ffc70433a"), 4431, 9, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2a8cd6c-db66-4ff3-a0db-c365798aa691"), 4015, 9, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2c5e168-8309-44ce-b3e0-bd37d63a8479"), 4518, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2f48edd-b52f-4149-ac1e-93256f704c7d"), 4202, 9, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e2f534c0-fd24-4bac-955d-b39c76dc5646"), 4037, 10, 9 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3088fc4-ea1f-451b-abc0-0ca2e2f7ce24"), 4716, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3281818-dc2d-49bc-a889-4b9baa75006d"), 4556, 4, 43 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e336d548-5cc7-48f1-93a4-641b92509a04"), 4508, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e34ca5ad-60e6-4c4b-ad9d-f7e38965ea12"), 4443, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e34e3082-e092-4c0a-b581-cca75c176782"), 4500, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e356ae5c-f6b4-4757-9434-151144209539"), 4641, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3704024-64cb-4388-87a4-891d4f2823a3"), 4225, 1, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3724eca-6149-4876-b807-e60ca5fe2a23"), 4554, 4, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3788ea5-7505-41bf-8a84-add898240ec9"), 4610, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e38e3c65-ff4a-4d7b-abad-3f7ca9d2d35c"), 4655, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3a0b6f3-c82a-4b14-985c-7eea97a08154"), 4709, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3cc1d04-268f-4ab9-b732-ac8b5e668445"), 4419, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3d24830-eb61-412e-98c2-1605a0bec878"), 4020, 10, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3d4c91a-fa27-4fb1-ac72-3cbc89b48ac2"), 4447, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3e17897-fb3d-4a0a-a95e-d31416be75f2"), 4523, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3f005c9-5631-4b53-8681-93ae63f4805a"), 4500, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e3f4d4a5-aae6-4e31-9857-4dc78e624faa"), 4244, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e40156ff-6877-48a7-9b6d-619aa1b66d13"), 4227, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e40874c8-a5f8-4eaf-bb2d-3ffa52c276a1"), 4801, 8, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e432b52b-9f40-41c0-b7ab-529fb7648441"), 4234, 1, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e44af5b3-53e2-4f9d-aef3-192670bff18d"), 4606, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4544e7c-d74f-4bab-90e3-57cf36876c03"), 4401, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e47441eb-7754-4135-850b-87f5d124032c"), 4722, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e4c97542-473b-4a50-b7c5-32f777171db5"), 4657, 8, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5174bb8-30c3-4cf0-acf3-195d172b721f"), 4318, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e51a16a0-4210-486d-a4ff-8427af36a08c"), 4033, 6, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e52ccfd7-b6de-44c6-b341-3220240128a0"), 4105, 6, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e569f0fe-c7be-4d4b-8d06-bbe748907105"), 4107, 7, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e589bb12-e09d-4b60-85a5-293129972d65"), 4324, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5aba0f1-b485-471b-9244-01573c79d966"), 4109, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5d77d56-5229-4c25-95ea-22264ee437c1"), 4616, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5df3f3e-3d01-4768-9e30-4e31c0ddc79c"), 4218, 1, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5e8d4bd-656d-4e20-8ff3-e554e6287734"), 4517, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5fb0e6b-9cb9-466e-99d8-87efa570e6ba"), 4319, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e5fb8aac-8b0a-4674-9e5d-997b599b0fd0"), 4257, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e62e8e41-d7ef-46fe-b8c1-1ceed77b2265"), 4214, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e639a92c-39a9-4f31-a152-ced8e700204a"), 4439, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6474e0c-640d-44b8-b294-6e72dcd9d3bd"), 4565, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e66205f0-6795-406a-b69a-be49ca3f4615"), 4431, 1, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6751f7d-b4e2-414b-9a45-02f1897feef8"), 4461, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e68442e9-09e6-4b91-a889-ca4fa8eb7efd"), 4853, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6908772-7b37-48bb-8442-214961cd77ae"), 4450, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e694fd7a-1d53-4bfd-b620-3f767450a803"), 4517, 10, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e69f616e-706e-4321-a11e-ced54b183539"), 4460, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6a20bf2-7add-4421-91ac-e22fb8b3aa18"), 4033, 8, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6b5591a-995d-432b-a618-704ef5619b4f"), 4439, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6c246ae-0ab5-4683-a65e-b376b09c0492"), 4635, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e6d2180e-76d2-4c50-9ca4-5610abb99d86"), 4428, 4, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e714848c-aa04-4ce2-b2bc-8c16ef62f91d"), 4309, 1, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e71d9c35-a669-46f8-bde7-fc3e546d2672"), 4662, 5, 1400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e72901b8-1929-465f-a07c-869c957bbeef"), 4230, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e73f75cd-bbe0-4d4b-a5e4-6f1aebcae7c0"), 4619, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e74b503a-4b4c-4672-af72-f6a15af46ff2"), 4609, 3, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e75d0ef0-6f3d-4ad0-9dfc-e01946a85c10"), 4014, 3, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7600601-ae99-4821-8208-657fd96d4dee"), 4020, 7, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e764acb6-8939-4f7f-a987-7e8ff56025f4"), 4212, 10, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e76c46cd-f193-424b-9b84-3650679a6687"), 4236, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7786806-853e-42e3-9e89-337390788e5e"), 4027, 10, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e781f4d3-a9e0-4bc0-b821-1b2b30721e41"), 4239, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e785e747-27c5-4b31-a7f1-d3cbfe836818"), 4701, 3, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7874d76-607e-42d0-82af-55d533638067"), 4205, 4, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e78d8ed0-cfe3-441f-84e3-5ec0824384d8"), 4513, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7b57fc2-27f6-4b41-95c4-00d3a3c4453e"), 4601, 9, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7cacc8c-da2c-4154-a969-66caa437a6d6"), 4518, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7d6f6a5-870d-4c91-8bff-cddfb9c88212"), 4716, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e7ec66d0-9494-47a3-af0c-b2a41b16a069"), 4623, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e805f03b-fe2c-4afd-84c5-5bb3909987be"), 4525, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e80e22d8-c7be-4888-bcd3-354f2bd5eb6b"), 4623, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e81950b2-bce4-42ea-a168-9793bfab6d33"), 4631, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e81b481c-d36b-42d8-8e41-78cde8bde59e"), 4402, 9, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e81d1386-37b1-4a05-a5c9-e87b91370c36"), 4414, 5, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8286189-9969-4b1b-a26c-2ab7c2f9c6a1"), 4433, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e843ac69-6765-41e4-a776-00f206b633db"), 4027, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e890c702-ef71-468f-8ea5-20b16b44e813"), 4707, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e898b075-d3a5-4e8d-82bb-fa4a68f12dee"), 4319, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e89a847a-d0d0-42c5-bd01-154468219b99"), 4405, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8a42685-1750-4aa4-97f0-61a333f5befc"), 4506, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8a5b186-20df-49a3-831b-03e57fba1eb8"), 4312, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8ac1d19-2b4e-4a0f-aedb-6a6383cbd394"), 4261, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8b5791c-e15e-4d2d-9ef8-06031e374e2c"), 4418, 5, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8c0278d-d871-47e2-8733-f13a44338caf"), 4265, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8c06c43-3068-4f27-ab8e-51218e1cee43"), 4270, 2, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8e085df-c0cb-4517-b7d8-a58a9a794713"), 4268, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8e32d34-edb7-4ba5-8daa-f8f48289bd8f"), 4632, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e8f20c66-e8ea-459b-9806-cb8cfd94cca3"), 4539, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e91f4c4c-dde6-497f-bb64-c69b745d7ba9"), 4437, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e92abba5-433f-49cf-ad97-6f854775bca4"), 4601, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e944aae0-307d-4d1d-b68c-fd0ba4f1f5ee"), 4515, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e948cf80-6436-4055-9e4d-ef0fde88fa90"), 4539, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e94b2daf-fe97-4cdf-84d7-9af821f0fc20"), 4718, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e94c8558-b74a-4339-86b2-54312289ea1e"), 4711, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e969c309-9ac6-4981-9870-06dae2acb0a1"), 4622, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e96b435f-acc6-4d3f-8020-9132b5c83f56"), 4223, 1, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e96c2810-fd51-4078-b607-cdd3c90cc842"), 4023, 2, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e97e0a41-ca5b-44c6-adc7-38df95256a19"), 4313, 6, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e98ab0fc-a697-4656-baad-ed7b693dae76"), 4019, 8, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9a42301-7195-4cc1-9f18-51fdd7b6353f"), 4100, 3, 35653 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9c2f5be-a508-42cb-bdad-50b6ab184e9f"), 4607, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9dba506-8382-4944-8150-cbab6efce910"), 4502, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9dda789-6ef8-46d3-8e04-75c914982fb5"), 4211, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("e9e9e74f-1327-4912-b32b-87475fb15d3d"), 4652, 5, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea0f9955-3249-432b-a41d-5996b0d046eb"), 4522, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea103f9f-6fa6-41fd-90d3-2dc54b5076bc"), 4712, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea178df8-9ff5-4ab5-b9b2-defbf5164300"), 4240, 7, 3000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea1f20e5-a3e6-4f05-b68f-bb65c75231e2"), 4014, 2, 4300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea331223-2b6f-4287-9cb6-a573a643e322"), 4208, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea384a7b-0981-45d8-935e-67626c806a07"), 4206, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea44b98d-73ed-4a90-8ba5-13c8e7608913"), 4035, 7, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea648293-027f-4663-a504-ca90a57eaaca"), 4563, 10, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea78658b-1de9-4c24-b5e2-57b9f7d23409"), 4521, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea7dbfff-77db-4191-925b-984306792f46"), 4406, 4, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea83d0ee-d2ee-4392-8b08-d8757e33b5ba"), 4624, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea999bfb-1b4b-444b-b84e-28c9b7a5559b"), 4209, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ea9c287d-7b51-4f1c-bdd2-9d63c1a570b4"), 4200, 8, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaa1eec9-ffb7-47b5-b5db-24aa35858f97"), 4422, 6, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eab34094-67ff-4394-9682-f07fddcc8686"), 4306, 8, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaca7ce5-8709-4d1f-9bb6-cb05b392fd3f"), 4023, 10, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaca86a0-465b-4002-a3d3-3999d363be3d"), 4237, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eace6f36-a4d2-4f6f-b216-46802891fb75"), 4536, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eadd01eb-627b-4812-a521-288e620dff01"), 4531, 6, 30 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaee7b67-b442-4c77-a12e-12fb956ce8bc"), 4408, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaef350f-6bdd-43e2-bfa8-48958500b865"), 4435, 6, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaf2ee24-0271-4368-826c-659ba020bbae"), 4602, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eaf7a64b-c4b9-433a-8fc2-8cb5a146fdb0"), 4624, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb075da2-f94a-4439-a1ff-06bf5073704d"), 4241, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb189d39-6243-4642-82f4-42bff93db2da"), 4527, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb421870-7d6e-4e99-8d87-daf0f0a1d333"), 4411, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb54f5b7-8ab4-40a4-a744-39824612639b"), 4222, 5, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb999a00-122c-4b80-8de6-6c4750846b2e"), 4263, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eb9bf35e-214a-4cbb-ad3f-fa57708e0bad"), 4613, 1, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebacb803-17f1-4bbe-8423-581834892cb5"), 4452, 9, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebb0af72-a544-421c-a28c-5fdcd2856268"), 4711, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebb71aa5-5919-435a-b7b6-a8eff83f1bf9"), 4008, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebbba715-2e44-4603-98d0-c155c9aa9a72"), 4206, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebc308d1-8377-43c8-b9f2-4567be5aaefa"), 4420, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebc6c9bb-1a58-4da2-a303-2672aa37d581"), 4407, 3, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebdcdd48-8477-48f7-9c8a-7d2ffd3c8866"), 4538, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebe1bfd4-afc9-4e4d-8f3e-16b68ca9fc19"), 4408, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebf17047-d60c-4bf7-90b5-5587817b5b46"), 4423, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ebf525ef-1f65-47da-8b88-95d868966f02"), 4506, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec32e6eb-ed52-4030-9e62-75e61f064f55"), 4105, 3, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec34f24c-24b2-49de-8691-1f47475adb52"), 4502, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec4dc8c0-c31c-42d0-88eb-6687d4a85cae"), 4237, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec4e41ee-74bc-483e-a476-ec94674a9812"), 4425, 1, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec7b9955-81ff-4f2a-a08f-b981cf57fe6e"), 4650, 1, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ec828ef0-033c-4e07-9d2b-384fc224b087"), 4512, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eca2a6cf-1283-485c-9063-0f0810a093ef"), 4723, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecc2380c-919b-409c-afc4-8296709c9fcf"), 4628, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecc3cc58-b81c-43dd-aac3-df5e88ffc40c"), 4708, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecde967b-fdd7-4887-a87f-e4b67a3c7b1e"), 4551, 1, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ece7b55a-5753-4a83-9052-af368b024fe6"), 4238, 8, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecf150e5-3bbf-4507-9c49-b7dd74b5f677"), 4710, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ecf7bbce-6b8d-4bf6-accb-510d8e5da8aa"), 4007, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed0631ec-bedd-4b46-9d58-6724d1ff9c54"), 4306, 6, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed0dd061-9af3-46d4-929e-ca08d01b2ecf"), 4551, 5, 45 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed225a63-a019-4f34-8496-417fb6f1e0cd"), 4425, 8, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed316eac-319b-41e5-807d-bf11fd060711"), 4004, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed51185a-5245-4656-a5a9-60f560f9acbf"), 4270, 3, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed6498c4-0d1a-4809-9db6-240ac2e8053b"), 4005, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed7813c1-92da-436c-9db5-01ea4691c969"), 4504, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed79cf2b-a24d-4112-abb7-8af1e8a73195"), 4312, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed9169f6-9f1f-49d6-a0de-a38578f0acf4"), 4017, 8, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ed92743d-0fc8-4af1-b4fc-924ce920c28c"), 4558, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eda61d80-0e68-43c2-adbb-bae3fe6e725d"), 4508, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edbd478e-9f59-48e0-9e64-1e43ae45332e"), 4532, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edd21568-f7fe-4ad5-9204-193b6da7c693"), 4707, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ede03783-65f2-4e53-a93e-6764e4701470"), 4256, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("edf52a16-36ae-440e-aea7-f43e7f4bdcbf"), 4112, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee02007a-41af-4940-9d8f-99960fdc27ec"), 4602, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee0ea6a8-8326-4325-a79e-d3888d9910ae"), 4458, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee14501b-dbaf-40c3-be01-e2dc18a99f88"), 4616, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee1b173d-db00-4aa4-8bc9-66475dbb0e4e"), 4535, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee1f6e9b-d2ee-413f-a373-17026e0c7619"), 4220, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee24c193-4ab9-4d63-bc0c-128243edf2fb"), 4032, 10, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee664cab-fc4a-4fc6-b866-d734e52d9999"), 4633, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee77e0c4-fbb2-4eb8-b6c6-6d6143158ba4"), 4400, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee7f6c98-00ef-47e2-9477-bf0f94751992"), 4254, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ee9eab58-ed64-4119-98f9-e55313175b3e"), 4714, 9, 239 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eea404fc-bc14-4fc7-b4ee-2bba88a3e1c9"), 4207, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eebe3d8f-9eb6-4e46-aed2-21f86856b7ab"), 4416, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eec4b31e-8fe9-4b31-b11b-547c72c07249"), 4546, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eec8d3ba-78b2-477a-9d55-376261f01a07"), 4409, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eec8fa64-6908-4ded-a5a9-c26bea5c1fcb"), 4321, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("eedf00ea-cab3-41ec-889f-184c1b9c6fdc"), 4216, 6, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef18858d-6edb-422f-95f2-b03032b39f0b"), 4614, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef295664-5e0c-49f0-8084-3b3c7bdd2f23"), 4243, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef3e787d-ba4f-4e73-9aec-fcd2568a7467"), 4022, 7, 4550 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef4cc881-8567-4417-bd47-155db3fb78bd"), 4700, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef688d49-3f7d-41de-9303-0470b0e3d240"), 4209, 8, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef6a891f-8279-43cc-8e20-134489ddca29"), 4229, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef6d6f6b-3666-43b7-898b-1ce96723c7e3"), 4431, 6, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef7d2fa3-eb24-41d1-a4ed-573f9576a5c4"), 4543, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef8b4e30-da96-4b17-a64b-5abb001c1044"), 4243, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ef8fcf4f-5ab6-48da-9e50-6b6ff5f0e8a3"), 4438, 10, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efa0b6e2-f2ec-4171-a024-3abaf9957379"), 4634, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efaed430-9bb4-4d76-9dc1-09b19f0d110e"), 4434, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efb1eff2-b214-4fb6-a864-5077d0adc85c"), 4005, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("efcf7645-c03c-424b-ba7c-746aa765d735"), 4718, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("effeed86-fae3-4683-8ac9-0bda5580804d"), 4209, 7, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f02ab06d-2fda-4894-bed5-1869e03e6b19"), 4439, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f02f6d55-ab96-4488-9e97-f7ad11e865f3"), 4230, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f03010dc-b090-454e-bf80-3c152d7bdaa9"), 4226, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f06dcf10-5dbb-46ab-85f9-6f84b8c0fb5d"), 4660, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f071dc61-b79e-4f37-b82c-527b80db01df"), 4803, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0777a67-eed8-4b2b-801c-9b4098303fc2"), 4323, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0796908-6d8f-4079-a6af-8a3213da1d9a"), 4426, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f07fe0cf-bb66-4294-b603-67120af176b8"), 4407, 4, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f086f03b-917a-45b6-b20c-bf6b40d6e64a"), 4554, 1, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f08d4289-b754-4746-af78-11003a8f9ba4"), 4622, 3, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0a2a943-b1ce-492a-ba54-45f492ee1b2d"), 4852, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0b1984b-f4e6-4acd-9bde-31f430601b3c"), 4502, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0b511fb-da01-488b-9935-08cd8b9947a6"), 4801, 9, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0cdd10f-2f81-461e-bce1-3057e92cd2d6"), 4322, 8, 460 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0d5ae86-860f-4502-a9c1-a2cd83dc88b6"), 4114, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0de69a6-44d9-47c7-8500-b0576585a2d4"), 4557, 7, 95 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0df03be-6465-4053-9c76-c8ebf87feccf"), 4443, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0ece60f-aa18-4fb9-b5d9-d818871d8626"), 4707, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0edc559-420f-4fb0-b13b-261f5be8b6e4"), 4453, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f0f0f718-d940-4ce8-8758-285b87034e26"), 4229, 7, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f101b6f8-3a99-44f5-b12a-77ba72ca2709"), 4015, 7, 24 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f103624b-5f18-447b-bad4-28d984cbbf71"), 4721, 5, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f112ebd5-ba93-40b9-913c-cfda59d5c253"), 4444, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1145bdc-da49-4d40-a058-faf4f1fc86f1"), 4552, 3, 65 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1289131-bf9e-4b58-9f38-900b87b385d6"), 4808, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f13eff52-1e5d-4f82-870f-02fa3a0b0149"), 4501, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f15f8bc7-124b-4744-a94b-7fb0776d0a4f"), 4718, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1778f5e-3f5d-4970-9428-87521dd71f52"), 4028, 9, 4700 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f17d5d5f-b9fb-4891-82c5-c119ae6eb20b"), 4274, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f18681e3-a348-4679-aa70-7a0c26eec1a8"), 4615, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f18b6975-df1d-4cdf-bf6b-de1fc3469e6b"), 4537, 10, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1a088de-955d-4a47-b078-9ca294de6b9e"), 4506, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1a2ffff-5279-4923-b76d-4cb7d8a39661"), 4503, 5, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1a7af1d-eda5-435c-90b8-68bb8e8f21d6"), 4718, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1b126c9-bf4b-4b78-adc5-52ecb5c9265d"), 4035, 9, 69 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1b15add-f7a6-4158-beec-e77935abce73"), 4011, 2, 16 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1b173d9-05c4-4d33-b53e-07a076274f45"), 4242, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1cd3dd0-806d-4725-90e2-01784be49c16"), 4210, 9, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1e912ed-9740-4d4b-944e-cfac5f93bf08"), 4653, 7, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1eb348d-8d1d-4c2d-a0f1-85d488b30803"), 4520, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1f9e0ae-d32f-4abe-9d5a-798b5ca91259"), 4224, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1fa914e-16c4-4936-a144-a1ef1b61d5f0"), 4528, 5, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1fbad9a-0a79-4e6d-8d6d-95f2b9c7ff0f"), 4238, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f1fc4a61-a758-40f6-8ecf-856b2a23542f"), 4306, 5, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2035251-df8a-4663-b153-de62b7d1e3f3"), 4706, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f230f23b-b4fa-47f7-8e39-59728827d2f2"), 4719, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f25dffbe-c0a4-45fd-81d7-3128dcce1caf"), 4619, 9, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f25e646f-5b82-4843-af17-c2d8d5a0c1ad"), 4414, 7, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f264b969-7ea3-4e58-81e5-0cac8f55033e"), 4447, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f26ec634-9c9c-4be1-8290-8b0cbeb2e3d5"), 4271, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2881072-a5f0-4c43-822b-2ffe4d96911e"), 4523, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f29f78c7-6e71-42cd-8f41-c9b9307a06e0"), 4634, 8, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2bbaff9-445e-4b75-927f-e4deafd55a27"), 4853, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2be365c-4294-4450-842a-7d4da67d85de"), 4249, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2cbe3c0-93fb-4838-898f-34a21089aa94"), 4456, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2d5f2a6-ecb8-4485-ab67-0dc1c73b85d7"), 4422, 1, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2de395d-19f4-434e-a3a9-87e2c793cd7e"), 4459, 4, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f2f0cc43-c771-484c-b5ca-302fd61771dd"), 4416, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f337329b-7844-40b4-9f50-1a1df9011d79"), 4421, 5, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f33f956a-68c1-4b70-a3f9-a9b6e4a93625"), 4518, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3445370-edb2-4589-90ab-94b64c24dea6"), 4559, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f35d189d-2091-49af-8ee6-a85626968aa2"), 4253, 9, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f372c686-d3c1-4a5e-afb0-fe9a7d518153"), 4429, 8, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f38f4ba6-2fd5-4c25-93df-6bf6ea309343"), 4111, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3aa5040-f96e-4fc6-9c6c-d3cf763b0fa6"), 4601, 2, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3d1c93a-a7ae-41fc-85b9-e1f7a4602e1a"), 4030, 6, 4800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f3e5034a-38db-49ff-9c79-750bf70e4384"), 4627, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f404e38d-e4ed-4a46-835e-8f1c87343078"), 4115, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f40c91ca-7800-4520-b53c-045e635e6e87"), 4612, 2, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f427278f-d9d1-4869-81eb-6d1dfca1170d"), 4530, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4353ad9-38c3-47a4-beb2-ca2854edfa88"), 4652, 1, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f44948e8-8fc6-4e69-9131-1b7e6f33b1cd"), 4412, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4541566-07e3-4c39-ba19-6b58d60a01a1"), 4020, 2, 4500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4582ab1-6bfc-42fd-bfa4-6aeeeaddc915"), 4615, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f459e423-298d-430a-bf85-99dc7a9f435e"), 4651, 4, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f45bb35a-25b4-45ff-b5cb-6ed1c0f2e555"), 4712, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4633f8e-53bc-4610-9e3b-d5cb37a37ee9"), 4421, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f478480c-91f5-4c1b-bbc6-935f2e0b488e"), 4245, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f49db5ca-3493-4565-830b-d43dced5cb27"), 4708, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4c4aaea-1cfa-4daf-a615-9954050efab8"), 4852, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4c781f9-ba96-49cf-bba7-b3e0fce6af5d"), 4608, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4c99e84-96cb-4507-9ca9-2ea67bcb6354"), 4634, 7, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4cbb003-01b6-4979-a684-94cf4d2b773f"), 4856, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4cbce83-400f-4bef-a44b-37bd729c2fc4"), 4613, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4f3bd0c-a95f-4e38-82d3-8057ad8c17e3"), 4113, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f4fb414e-4764-441c-b575-0356180a6068"), 4564, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5224bf3-2a6f-4a93-982d-a2d5580a16aa"), 4403, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5245c2c-09b0-4763-97a0-94237b371d0e"), 4259, 8, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f525537a-b268-45a1-85ba-dba8bd4be3c4"), 4723, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5779a0e-94a8-423a-8e55-1e832edc108a"), 4513, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f57fcdf0-05f8-46e1-91a3-511f891726f3"), 4205, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5829ebc-1f5f-4185-af6b-79d3da4df71d"), 4620, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f589e266-7c0b-4771-a6cf-167c63a457e6"), 4300, 10, 80 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5b584ee-ee44-42dc-8598-d36b9a14837c"), 4524, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5c1f57d-399c-48c5-914c-972a3af99509"), 4234, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5cb08b6-34fc-470c-883c-3a89c5a7033f"), 4102, 4, 12345 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5da2a17-c279-4ada-a118-f5269b74ff1f"), 4261, 2, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5da4119-a336-40c7-90d3-038912eb5abb"), 4324, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5db4f50-07b7-4b4d-a235-963774a0f608"), 4245, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f5df431f-791c-4850-9bff-b9b3ac5d330f"), 4614, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f601cf85-ced0-48d7-b012-9843c00363d0"), 4616, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f613915f-9f82-430c-897d-8e84f8f73e9b"), 4545, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f61c1c9f-28c8-4640-b1e0-c941de6f5078"), 4554, 5, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f62967b6-038f-4191-95a6-21d705362f30"), 4261, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f63acabc-6413-4260-84bd-63b9a3cc2313"), 4715, 7, 241 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f660d2c1-60a6-4406-8f9b-2c260454ad08"), 4605, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f67ae043-818a-48af-8ade-6bf89d18222d"), 4850, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f697ad6a-ff5c-4fd3-9717-a9c7ecf59527"), 4633, 3, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f69a1aae-1a4e-4ae0-947e-972a441773d7"), 4204, 2, 500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6a1f8d3-4fb1-4146-b433-72e199ae8af4"), 4510, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6bc03d3-957c-4f5b-9294-2de9754c37e1"), 4458, 7, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6bcfc45-bcaa-41dc-b85f-8f4bea3dff78"), 4324, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6c53b86-6b93-4444-9bbc-403c49e736ac"), 4430, 9, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6c63aba-d2fe-4d00-994e-94b85add99a2"), 4425, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6cc90d2-d789-4f14-aa21-ccd2004cb4cf"), 4455, 5, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6d42fec-a5fe-4f72-a1e3-854b9802f878"), 4603, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6d8e6f1-754d-4470-96f6-36cf944849e7"), 4245, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6dbc849-f509-4442-872a-030ec43569fc"), 4031, 8, 11 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f6e9b3f6-eced-4226-bc2e-51f716be6596"), 4416, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7135e50-ba27-4ef3-9787-0ead9b049292"), 4107, 3, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7268fd8-6085-49fa-a66e-caf699d05bae"), 4306, 9, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f727dc6d-0bc5-4acb-871f-9e55074f8753"), 4268, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f737b580-1640-4389-8f96-9ce020b19ea3"), 4264, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7386c0c-1715-44c8-a190-ec86aae33ba5"), 4227, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f77ba76c-8fd7-4eac-8e0e-cac6eeaf7afa"), 4004, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f782ddec-4438-4651-8683-f83df35dbb85"), 4637, 3, 1800 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7914213-4683-439e-bfcd-0be213085f37"), 4660, 8, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7cabd2b-d1ef-4974-aa3a-ed7cd5249173"), 4625, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7ccaad5-0c01-4c01-869c-56b7a3c232b4"), 4640, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7d9a646-1cfc-4772-886e-282a8c3a9725"), 4708, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f7e00978-3fd1-49f8-af7b-a03827b76624"), 4523, 3, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f812f5c3-0ca7-43ed-8407-edb4b14d6738"), 4308, 4, 6000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f830fb9d-37a2-42ab-820f-6fa3e95363c4"), 4700, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f83769bc-deb8-4da1-b299-47dbc8fb53f8"), 4006, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f845397c-cee9-4e74-a572-b96dec40c91d"), 4500, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8604e7a-400a-4c34-95c3-130bf4deb2ff"), 4104, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8605a23-169f-409b-b01d-989e242334ef"), 4260, 10, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8799c3a-fdb7-4af3-9e45-e8566c06fd09"), 4424, 8, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f89d7fbe-5347-4997-927f-3ccabb728bdd"), 4419, 5, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8a2b4b1-ba05-4bc0-b8db-750b0ab74f2b"), 4855, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8a3039c-f6bf-4b99-9af1-4a04a734890d"), 4027, 7, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8a8e3be-79a0-4242-af49-719ab19118d1"), 4229, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8c959f8-6440-4fbf-b1f2-65b7d81a0101"), 4612, 3, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8d351c3-7c62-4e9c-a2ea-dd663dca047d"), 4271, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8d84bf2-6622-4637-b003-a1d29bc7c413"), 4259, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8da8b2c-d0b5-4207-a199-e70178d59dd4"), 4444, 7, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8ea0f12-89a5-4e92-9c0c-40f5c2668623"), 4529, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8f80b61-3910-4b9b-a2b1-b335b5bf0dcd"), 4535, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f8fde0fb-30aa-4406-bd4f-c6df2e900fa2"), 4311, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f913a479-8c7a-4a1c-bd01-0d4a8e7cf74a"), 4461, 10, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9311508-c7ba-4561-95b9-2babc3676c9d"), 4254, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9346fdb-4c71-4323-b5e4-cae44e3509ea"), 4006, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9347e45-c532-4818-b344-54c1f7812093"), 4001, 3, 14 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9478098-1097-4ebb-a075-a35c2fa5240c"), 4651, 6, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f95aaf2e-fbbf-41b5-a261-a8a0f994ebcd"), 4544, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f95ce735-1a4e-45b5-9d4f-8d7774b47496"), 4802, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f96cce2d-136a-447b-80a0-61b1c010dc7a"), 4853, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f978ff3d-1c59-46d0-90b7-befe20bd177d"), 4435, 3, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f97eac62-d914-44a0-96c0-9b688b099ffa"), 4268, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9813179-f299-4017-833e-95589643261b"), 4263, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f99ec3c3-b5cd-4ee4-bf15-0cf180a6c309"), 4273, 7, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9a8fd8e-e9cf-4241-8e49-e28f9a60f84c"), 4451, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9b90c79-9f1b-4330-8aa4-6798c1314266"), 4254, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9c4abd0-a4fe-4a91-a32a-154176c1ead4"), 4652, 4, 7 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9cde30b-345e-462f-93cb-d27188002692"), 4273, 10, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9e35c34-e5e2-4e68-abb1-cdf6b595eeda"), 4539, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9e4ecaf-7158-4c73-89f4-899b62453ee1"), 4431, 4, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("f9f2443b-aba4-40cb-8dbc-c4e1a047ce18"), 4659, 1, 3200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa2b73c2-65ac-4544-9a4f-ac2ba473ed4f"), 4017, 2, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa4363d5-3201-46f8-b6d1-a0d731ac2b2e"), 4226, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fa58e0b7-c8df-41db-9b56-0055b61a8c17"), 4115, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("faacad91-d3e4-4439-a8f7-86a70df984c8"), 4025, 5, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fad2f451-4dc8-4c74-a299-7a52ce0d3d14"), 4705, 2, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fad5eaae-53ca-4f83-9172-40f84de28fa2"), 4229, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("faf5a6d6-05e5-4be8-b2e2-e59440d189bf"), 4502, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fafcfce0-6522-4e1d-b09b-dd473d084f8e"), 4439, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb00b8a0-debf-4072-999b-490df646d7ba"), 4211, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb10dd9d-60d8-40a8-b202-239e598843e5"), 4619, 3, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb258369-ed79-4327-8ea6-848133c87c42"), 4404, 8, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb3dfe2d-0882-42ae-afd9-ff9b1a94c4db"), 4009, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb42cfe2-3ffd-490c-86e4-05f799adcd25"), 4528, 4, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb4410e6-3e83-4e87-b16c-18a8bdc956a7"), 4545, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb4c8294-9677-4304-bb64-a4797fb4ecab"), 4504, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb50a2b5-19cf-41a9-b872-35debc1f34f2"), 4810, 7, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb56c06c-c0a3-42f6-a623-bc3a6378fa47"), 4231, 5, 1000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb743675-7dfa-4494-b70d-a90dfd585544"), 4702, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb79f94e-228d-4478-a5d7-306ae4f2916c"), 4227, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb81fb29-b3a6-472d-862c-b1f6df317d61"), 4629, 6, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb882dd0-0bb1-4b8e-ad8c-8844025c5f64"), 4713, 8, 240 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb91d1c6-2e82-48c0-b249-999611f28ef8"), 4554, 9, 35 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fb9e18e7-308c-484a-b569-a7c8964c7775"), 4534, 4, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbadd05b-951e-4e45-8ee4-8f44dfe1c3c6"), 4251, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbb7d99d-d385-4d0e-bd2f-f9dac155ab99"), 4036, 1, 6100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbc0de8b-bf0d-4f66-8971-6172eaad3243"), 4217, 2, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbcd26cd-947f-46a1-984e-f6a430c0ae1c"), 4626, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbe5b86a-0b51-4ea5-8f25-f107fd2650a3"), 4701, 9, 2369 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbe6547b-cc5b-41a8-b285-8961680a101b"), 4456, 9, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbf019e9-7874-4c24-aa17-88bb8e145931"), 4304, 3, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbf4e5ae-1f62-4b5a-ad3f-36a361b642e1"), 4422, 5, 3 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fbfd80e2-61d6-41bf-8279-078c4624db3a"), 4854, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc158536-1ac8-44c5-b9a5-d2c1912b30b2"), 4528, 1, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc27f4dd-a193-483b-9212-a7a71b506344"), 4542, 5, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc5b8392-4384-4351-a561-598b64b6cd45"), 4010, 9, 4100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc627225-b3f8-4f31-8d84-287e86d76a85"), 4302, 1, 50 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc82e8d3-ea93-4192-8dcc-06484fb97ef7"), 4721, 9, 2 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fc8f49b5-61a2-4625-a34d-34c33e41c003"), 4460, 5, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcb30935-6783-4df9-a0e6-77db09e846ff"), 4226, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcbea2ab-224d-4771-90e9-365aa31bb942"), 4462, 6, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcc785d2-c8dc-49e1-8e9d-6891160f5353"), 4258, 1, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fccbd4dc-f975-41d9-ba26-75153c6e8c55"), 4301, 2, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fcf7abad-ac3e-483f-8e56-50ac1e2db6e1"), 4539, 2, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd154937-ac15-427b-8619-9fa02d3dac7c"), 4561, 2, 5 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd329cb6-1c50-4333-ac0e-f746d7a96aba"), 4003, 9, 65000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd5560eb-948e-4aa4-9a06-9ba2f5e5ee8a"), 4663, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd6d7330-3125-4054-8239-e6438bcf65c4"), 4703, 2, 64 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd87c4e5-2df9-4cd1-afbc-d8424f5f38a3"), 4313, 4, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd8a8184-6fc3-4db0-aa75-0b3e5373b012"), 4217, 6, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd9c5cd8-23b0-4578-86a6-eea0fb6b73e9"), 4007, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fd9f5906-20c4-4359-a2cf-32f42b415e2a"), 4605, 8, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdb0ab40-6f65-4f3c-944a-ab02d2968dad"), 4232, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdb46295-9166-4c1c-88a7-0063535691b2"), 4032, 8, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdc12681-9c9d-4579-b8d7-e723e3766f35"), 4503, 4, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdc19ff9-17a2-4371-9896-fcb0991d4f37"), 4562, 3, 2500 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fde20666-4494-4998-b136-1c2dfb1046d7"), 4107, 9, 9430 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fdf8d521-c920-4d9e-a5cd-8da7406b3537"), 4241, 10, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe10f209-6c4e-4167-b0b2-545fe60be647"), 4437, 10, 150 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe1edd1d-9918-4bc5-903e-645c5d61f515"), 4225, 5, 10000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe3a84e4-b8de-47bb-9cf2-7a57cfdce184"), 4217, 9, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe54132e-b2d8-49fb-989e-8abacb9ccc57"), 4623, 3, 10 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe5bd238-514c-4401-b038-1cc9f93c4ee2"), 4407, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe5e2ca9-a128-478c-b3f5-9309e26672c0"), 4717, 4, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe6931b9-b3b7-48af-bf7e-42c9f97e6103"), 4518, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe7d3139-c6b9-4e36-8a25-19628df48e26"), 4619, 6, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe833357-c810-42e9-b96c-4b5e83035e07"), 4402, 6, 25 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe9114f0-1693-437d-b716-f48c10707a78"), 4453, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe9cdcf1-46c0-435d-8e1e-a705b491f408"), 4616, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fe9fa18c-aa63-45be-a006-bd5aaf26f806"), 4314, 9, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fea17ccd-f7c2-42e1-95f6-d410b0ef221e"), 4017, 1, 42 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feab45ab-f967-46aa-bfeb-2f52e163c25c"), 4601, 3, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fec52ad5-c7e6-4e0a-87b2-c7b6b5df51e2"), 4705, 7, 4 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fed74bf5-56b3-4938-bc50-bebba379c42e"), 4260, 7, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fee71e88-9e01-4c74-93d8-8768dfd17362"), 4111, 1, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fee7bd65-6468-4ffd-9cb0-38a716f834d2"), 4200, 7, 20 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("feef9a74-d9af-4280-9ada-451fd30ab569"), 4032, 7, 4850 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fef03f86-a946-4b0d-8b0f-a320679e059b"), 4608, 6, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff10856a-d0ce-4214-b773-e18e87353228"), 4431, 3, 300 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff15730a-1f12-49de-82d7-2e34b6b234c6"), 4807, 10, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff4d1c21-b989-414f-91bc-44750f94f55c"), 4634, 2, 5000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff53e855-d1da-4ffb-bd39-964675a9c41e"), 4024, 4, 4600 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff6222fb-ee13-471c-8070-dab4c7ed3082"), 4273, 1, 65535 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff6969ea-f3dc-4834-8fd1-9d6f897b3033"), 4719, 8, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff7a94e4-ccc3-4973-a994-b8c3b47f074a"), 4016, 6, 4400 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff7b136a-225a-4c3c-b96b-44ca6597a757"), 4528, 10, 20000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff82e032-6bea-4083-88d5-4d7b799dd4ab"), 4267, 7, 2000 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff8536fc-56a2-4ebf-93b9-86442fb439aa"), 4639, 3, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff91e3db-104a-48df-9ef9-839736ac81cc"), 4514, 2, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff9c27a9-8e79-47a4-b045-4857956c45aa"), 4446, 4, 1 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ff9d1d94-b503-4ad0-9f3d-db49531981e8"), 4460, 10, 100 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffa50efe-6102-4bf8-a1bf-1bddd0508204"), 4013, 9, 72 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffa5218c-7cdb-4c07-a0b9-906ad30adcd0"), 4806, 6, 0 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("ffd7cae7-f926-4d9a-9d70-d556bbe7d43c"), 4310, 2, 200 });

            migrationBuilder.InsertData(
                table: "APCDefaultDatas",
                columns: new[] { "Id", "Address", "Device", "Value" },
                values: new object[] { new Guid("fffff791-fced-49a9-83be-faf45fba8c97"), 4507, 7, 100 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("00d799df-51fc-4533-9e68-def9710aa481"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("0f493f9e-9961-4650-b055-45296b15a1aa"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("7a7298fa-64ae-4a85-b0f6-6456fb9252c3"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("87ddf7a0-db01-45c7-8555-34bb0eea48b4"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("8e6f2a3d-09c7-4d73-bc4e-2b969e5464a5"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ac462482-0c19-4903-876d-2dbde8e989a4"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("bde8fffe-80b0-4301-8621-b25519a267a5"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c28eb506-8057-449c-911d-c8af2c9f1186"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("fa1d5d46-3cba-48e5-9ada-226cf35cefec"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("fdf1a12b-b7cc-44ae-a854-808df59c578a"), "APCDevice_8", 8 });

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
