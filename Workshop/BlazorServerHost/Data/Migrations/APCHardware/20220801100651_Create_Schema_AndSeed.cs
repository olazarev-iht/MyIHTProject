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
                    ViewParamGroupId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ViewItemOrder = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_ParameterDatas_ViewGroups_ViewParamGroupId",
                        column: x => x.ViewParamGroupId,
                        principalTable: "ViewGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("25e18de0-70dc-4f99-aa5a-3740e7b93518"), "Height Calibration", 1 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("873a1786-4393-4d2f-ab1f-d842ed92e03a"), "Retract Position", 2 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("99c27f84-e212-494e-8b57-ceeddff712d8"), "Pre Flow", 4 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("bde14a4a-32e0-4c3b-8c09-f2ec6cee3385"), "Slag", 3 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("bf5ac7d9-a663-4c5e-9b28-9a422464fa28"), "Piercing", 5 });

            migrationBuilder.InsertData(
                table: "ViewGroups",
                columns: new[] { "Id", "Name", "ViewOrder" },
                values: new object[] { new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742"), "Height Control", 6 });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("062ec58b-e366-4f35-8160-cf83fde54efc"), "RetractPosition", 2, new Guid("873a1786-4393-4d2f-ab1f-d842ed92e03a") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("0858ee1e-bac5-45b0-abec-88466e47f9af"), "SlagSensitivity", 1, new Guid("bde14a4a-32e0-4c3b-8c09-f2ec6cee3385") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("0daed1f1-53e6-4c47-a180-47b0cecb0a3f"), "Off", 3, new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("1d185725-e330-4acd-ba13-1b41866e0fb5"), "StartPreflow", 1, new Guid("99c27f84-e212-494e-8b57-ceeddff712d8") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("2b61d633-0a94-434c-b879-f272c55aca1a"), "CutO2BlowOutTime", 3, new Guid("99c27f84-e212-494e-8b57-ceeddff712d8") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("2d78eef9-c5f0-45ac-9440-4b431f824f25"), "DistanceCalibration", 2, new Guid("25e18de0-70dc-4f99-aa5a-3740e7b93518") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("3980d18f-4700-4061-aec4-492b6de7b66d"), "PiercingHeightControl", 1, new Guid("bf5ac7d9-a663-4c5e-9b28-9a422464fa28") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("76be0d1a-ba3f-4a39-a802-d98ec1d999d2"), "PreflowActive", 2, new Guid("99c27f84-e212-494e-8b57-ceeddff712d8") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("8141a08b-be92-416f-a582-ff8ba631b664"), "RetractHeight", 1, new Guid("873a1786-4393-4d2f-ab1f-d842ed92e03a") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("8db61eed-1906-4bdd-9731-d5900028e005"), "Dynamic", 1, new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("8e25b7a7-61c3-4fa6-825c-f4a6b7362a8d"), "HeightCut", 6, new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("902327fb-4173-4084-9ede-bdec8de982db"), "CutO2BlowOutPressure", 4, new Guid("99c27f84-e212-494e-8b57-ceeddff712d8") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("92d93678-5baf-4f34-b1bb-665765a1346e"), "HeightPierce", 5, new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("aa87f8ef-48b7-4354-91eb-b184da45239b"), "HeightControlActive", 2, new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("b5e9c99a-4bd2-4f52-b05c-65fd33f39b0f"), "CutO2BlowOutTimeOut", 5, new Guid("99c27f84-e212-494e-8b57-ceeddff712d8") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("be11e649-9dd6-4b7c-b22f-9b724562a5bf"), "SlagCuttingSpeedReduction", 3, new Guid("bde14a4a-32e0-4c3b-8c09-f2ec6cee3385") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("c0b7defd-70a1-49c3-85fc-7fe5e940923a"), "SlagPostTime", 2, new Guid("bde14a4a-32e0-4c3b-8c09-f2ec6cee3385") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("d0eaae8a-22e8-4b0b-b628-84eb14ca50a4"), "HeightPreHeat", 4, new Guid("f58caf59-f142-4cb5-84d5-2f70bf618742") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("d8a4c8fd-2868-4e4f-9f1b-d62207870d31"), "TactileInitialPosFinding", 1, new Guid("25e18de0-70dc-4f99-aa5a-3740e7b93518") });

            migrationBuilder.InsertData(
                table: "ViewParamOrders",
                columns: new[] { "Id", "ParamName", "ViewItemOrder", "ViewParamGroupId" },
                values: new object[] { new Guid("da9a7d1c-75e3-4531-9a9b-a7f96c61e31f"), "PiercingDetection", 2, new Guid("bf5ac7d9-a663-4c5e-9b28-9a422464fa28") });

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
                name: "IX_ParameterDatas_ViewParamGroupId",
                table: "ParameterDatas",
                column: "ViewParamGroupId");

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
                name: "ViewParamOrders");

            migrationBuilder.DropTable(
                name: "APCDevices");

            migrationBuilder.DropTable(
                name: "DynParams");

            migrationBuilder.DropTable(
                name: "ViewGroups");

            migrationBuilder.DropTable(
                name: "ConstParams");

            migrationBuilder.DropTable(
                name: "ParameterDataInfos");
        }
    }
}
