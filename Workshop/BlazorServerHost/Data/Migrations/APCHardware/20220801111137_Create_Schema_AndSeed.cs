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
                name: "ViewGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ViewOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewGroups", x => x.Id);
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
                name: "ViewParamOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
                    ViewParamGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ViewItemOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewParamOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewParamOrders_ViewGroups_ViewParamGroupId",
                        column: x => x.ViewParamGroupId,
                        principalTable: "ViewGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
                    APCDeviceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    DynParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ViewParamOrderId = table.Column<Guid>(type: "TEXT", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_ParameterDatas_ViewParamOrders_ViewParamOrderId",
                        column: x => x.ViewParamOrderId,
                        principalTable: "ViewParamOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("07a083fe-c04a-4bb7-9629-d5544ed58b37"), "Slag", 3 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("0f6d7685-9754-460c-8c73-32e906a4ee8b"), "Retract Position", 2 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("16aa6c33-0b5b-4054-9e6f-8137b50b90b5"), "Height Calibration", 1 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("a0896d16-6e51-4389-9b78-41bcfafc5a9e"), "Pre Flow", 4 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("d9aaa2b1-a8a3-4890-8e49-278a7bb0772f"), "Piercing", 5 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4"), "Height Control", 6 });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("0103fad1-84e3-4fa9-85fb-34d5bdc5d278"), "HeightPierce", 5, new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("36a28d85-477a-4d7c-937b-782f9e2c7d80"), "HeightCut", 6, new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("413d32f9-b7ae-4b51-8aa9-f5bc2b6f025a"), "SlagPostTime", 2, new Guid("07a083fe-c04a-4bb7-9629-d5544ed58b37") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("4678a33a-4cba-4b70-9f03-5ffce867953b"), "CutO2BlowOutTime", 3, new Guid("a0896d16-6e51-4389-9b78-41bcfafc5a9e") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("5014cec9-f067-4756-951f-dfcab8ec18e7"), "TactileInitialPosFinding", 1, new Guid("16aa6c33-0b5b-4054-9e6f-8137b50b90b5") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("5e7f2eab-536f-4668-99e9-ded5b9205076"), "DistanceCalibration", 2, new Guid("16aa6c33-0b5b-4054-9e6f-8137b50b90b5") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("63ac32ea-3e27-434d-9819-85b7eab25a90"), "PiercingDetection", 2, new Guid("d9aaa2b1-a8a3-4890-8e49-278a7bb0772f") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("66158424-fdee-43db-bcdc-3db3c562afd6"), "HeightControlActive", 2, new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("67ccb136-8352-4c80-9647-2eaddd87f302"), "RetractPosition", 2, new Guid("0f6d7685-9754-460c-8c73-32e906a4ee8b") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("6cccae39-d009-4c03-b8dd-e7e2fd14db24"), "RetractHeight", 1, new Guid("0f6d7685-9754-460c-8c73-32e906a4ee8b") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("83604e4f-5ffa-442b-ac2c-b9017ea5e8ad"), "SlagCuttingSpeedReduction", 3, new Guid("07a083fe-c04a-4bb7-9629-d5544ed58b37") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("89caf727-fe8c-463a-b355-180524d33402"), "CutO2BlowOutPressure", 4, new Guid("a0896d16-6e51-4389-9b78-41bcfafc5a9e") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("944d1a7c-8f72-41fd-94db-e5cae46bb692"), "Off", 3, new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("bcf35aed-7489-495b-8849-b8fdd372b525"), "CutO2BlowOutTimeOut", 5, new Guid("a0896d16-6e51-4389-9b78-41bcfafc5a9e") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("c1c2193f-7669-4ed5-9770-f3fe87ca7439"), "Dynamic", 1, new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("e03d04bd-932a-45bf-9a99-d0a33d67b8a6"), "SlagSensitivity", 1, new Guid("07a083fe-c04a-4bb7-9629-d5544ed58b37") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("e848e7d7-13bc-4cb6-b7c3-f923394bb93c"), "PiercingHeightControl", 1, new Guid("d9aaa2b1-a8a3-4890-8e49-278a7bb0772f") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("ed248f89-b09d-4217-adba-efa0cbdd78e5"), "PreflowActive", 2, new Guid("a0896d16-6e51-4389-9b78-41bcfafc5a9e") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("ef0183ef-e08d-468c-99bd-8a834c96d604"), "StartPreflow", 1, new Guid("a0896d16-6e51-4389-9b78-41bcfafc5a9e") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("f47c348e-47fa-4f03-96da-2fa5e218d233"), "HeightPreHeat", 4, new Guid("fffb0a71-f69a-4a74-96c2-7d151ddf85a4") });

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

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDatas_ViewParamOrderId",
                table: "ParameterDatas",
                column: "ViewParamOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewParamOrders_ViewParamGroupId",
                table: "ViewParamOrders",
                column: "ViewParamGroupId");
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
                name: "ViewParamOrders");

            migrationBuilder.DropTable(
                name: "ConstParams");

            migrationBuilder.DropTable(
                name: "ParameterDataInfos");

            migrationBuilder.DropTable(
                name: "ViewGroups");
        }
    }
}
