using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    public partial class Create_Schema_AndSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Mode = table.Column<int>(type: "INTEGER", nullable: true),
                    TcpPort = table.Column<string>(type: "TEXT", nullable: true),
                    IpAddr = table.Column<string>(type: "TEXT", nullable: true),
                    ComPort = table.Column<string>(type: "TEXT", nullable: true),
                    Baudrate = table.Column<string>(type: "TEXT", nullable: true),
                    DataBits = table.Column<string>(type: "TEXT", nullable: true),
                    StopBits = table.Column<string>(type: "TEXT", nullable: true),
                    Parity = table.Column<string>(type: "TEXT", nullable: true),
                    Identifier = table.Column<string>(type: "TEXT", nullable: true),
                    TorchEnabled_01 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_02 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_03 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_04 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_05 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_06 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_07 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_08 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_09 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchEnabled_10 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_01 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_02 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_03 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_04 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_05 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_06 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_07 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_08 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_09 = table.Column<bool>(type: "INTEGER", nullable: true),
                    TorchInstalled_10 = table.Column<bool>(type: "INTEGER", nullable: true),
                    DataBaseMaterialSelectedIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    DataBaseThicknessSelectedIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    DataBaseNozzleSelectedIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    DataBaseGuid = table.Column<Guid>(type: "TEXT", nullable: true),
                    TorchType = table.Column<int>(type: "INTEGER", nullable: true),
                    PressureUnit = table.Column<int>(type: "INTEGER", nullable: true),
                    LengthUnit = table.Column<int>(type: "INTEGER", nullable: true),
                    CultureStr = table.Column<string>(type: "TEXT", nullable: true),
                    ComPortLast = table.Column<string>(type: "TEXT", nullable: true),
                    ExecReset = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SlaveId = table.Column<int>(type: "INTEGER", nullable: true),
                    ErrorCode = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParamViewGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    GroupName = table.Column<string>(type: "TEXT", nullable: false),
                    GroupOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamViewGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParamSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamViewGroupId = table.Column<string>(type: "TEXT", nullable: true),
                    ParamOrder = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParamSettings_ParamViewGroups_ParamViewGroupId",
                        column: x => x.ParamViewGroupId,
                        principalTable: "ParamViewGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("36eacfb6-4c78-4526-ace5-9b737a666f7b"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("3ef3736e-043c-4f2a-8bbb-b4e14d40834b"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5882e015-0e00-4886-bbd7-14409179be72"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("642fb882-0c86-4a4a-944d-ffd5834c3086"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("92f25aea-1fb7-42ed-9fe1-b6b9d507c6d2"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("9a0f66a9-cc37-4f5b-9260-afa01f9dc15a"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c97a004a-0ed2-44d3-8508-8d4bde2e82ff"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("d6ff3b4f-90bc-4ba4-a7c9-9e6386e0c0f1"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("df240c04-f835-4c40-bf90-0015e5b800ac"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e96a0b60-7208-4a96-89f9-ec593e348dde"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "ConfigSettings",
                columns: new[] { "Id", "Baudrate", "ComPort", "ComPortLast", "CultureStr", "DataBaseGuid", "DataBaseMaterialSelectedIndex", "DataBaseNozzleSelectedIndex", "DataBaseThicknessSelectedIndex", "DataBits", "ExecReset", "Identifier", "IpAddr", "LengthUnit", "Mode", "Parity", "PressureUnit", "StopBits", "TcpPort", "TorchEnabled_01", "TorchEnabled_02", "TorchEnabled_03", "TorchEnabled_04", "TorchEnabled_05", "TorchEnabled_06", "TorchEnabled_07", "TorchEnabled_08", "TorchEnabled_09", "TorchEnabled_10", "TorchInstalled_01", "TorchInstalled_02", "TorchInstalled_03", "TorchInstalled_04", "TorchInstalled_05", "TorchInstalled_06", "TorchInstalled_07", "TorchInstalled_08", "TorchInstalled_09", "TorchInstalled_10", "TorchType" },
                values: new object[] { new Guid("9284ceac-cd85-4e17-ac8c-9afa89b2c7aa"), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "HeightCalibration", "Height Calibration", 1 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "HeightCalibration_client1", "Height Calibration", 1 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "HeightControl", "Height Control", 6 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "HeightControl_client1", "Height Control", 6 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "Piercing", "Piercing", 5 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "Piercing_client1", "Piercing", 5 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "PreFlow", "Pre Flow", 4 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "PreFlow_client1", "Pre Flow", 4 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "RetractPosition", "Retract Position", 2 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "RetractPosition_client1", "Retract Position", 3 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "Slag", "Slag", 3 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "Slag_client1", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("116f5aab-e152-40b4-b788-efd95bee8ecd"), "default", "TactileInitialPosFinding", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("25aacfa8-896a-401a-b589-a25cbae11bd0"), "default", "CutO2BlowoutActive", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("289c483a-bfd2-4d9a-b8a7-cc9c80658ef0"), "default", "CalibrationActive", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("36486215-7551-4fef-82cd-5563de1d4256"), "default", "SlagCuttingSpeedReduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3cd0b84e-425a-4eaa-bf2f-0590d9f8ed8e"), "default", "CutO2BlowOutPressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("411f5c68-8d0b-4a96-87e1-9644b3f387be"), "default", "StatusHeightControl", 4, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("44b4d814-f712-48da-930a-ba8a8635bcb8"), "default", "SlagSensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("44cbb3e9-c857-44be-9457-1d592d816f51"), "default", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("44d559c5-293f-4657-86e7-3726b28c638c"), "default", "CurrCutO2BlowoutTime", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5bb4942b-4c11-4a8a-8515-7a6d82bacdfb"), "default", "LinearDrivePosition", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("61b9ff05-3d50-48e1-832c-ccae45a6393a"), "default", "RetractHeight", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("696b6887-5b82-4f4e-8af0-4769a9b97a39"), "default", "CutO2Blowout", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7e8e6531-8765-4086-bf24-3bc5da617890"), "default", "DistanceCalibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8badad1e-0973-48a7-bb27-37bfb6161cb8"), "default", "CutO2BlowoutBreak", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("955a49fe-2dae-455d-bb9f-a015e5f5993a"), "default", "LinearDrivePosition", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b1f91122-40c6-4197-aaa8-4c3fe67f63d2"), "default", "CutO2BlowOutTime", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("bc048a9f-2026-46df-99f3-24b99c5207a4"), "default", "PiercingSensorMode", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c9fa3db4-71cd-4e55-901e-aa9a902878ef"), "default", "RetractPosAtProcessEnd", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("dae757c8-e72d-477c-bae5-629c31b0a546"), "default", "SlagPostTime", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e0b8203e-771f-4998-98d9-191f5692293a"), "default", "CutO2BlowOutTimeOut", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e3686cd0-e089-4dc4-8f43-9405bccbabfc"), "default", "HeightControlActive", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f64816bf-1bbb-4f4c-98f5-2cb6f83abd6b"), "default", "CalibrationValid", 4, "HeightCalibration", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ParamSettings_ParamViewGroupId",
                table: "ParamSettings",
                column: "ParamViewGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigSettings");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "ParamSettings");

            migrationBuilder.DropTable(
                name: "ParamViewGroups");

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("36eacfb6-4c78-4526-ace5-9b737a666f7b"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("3ef3736e-043c-4f2a-8bbb-b4e14d40834b"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5882e015-0e00-4886-bbd7-14409179be72"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("642fb882-0c86-4a4a-944d-ffd5834c3086"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("92f25aea-1fb7-42ed-9fe1-b6b9d507c6d2"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("9a0f66a9-cc37-4f5b-9260-afa01f9dc15a"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c97a004a-0ed2-44d3-8508-8d4bde2e82ff"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("d6ff3b4f-90bc-4ba4-a7c9-9e6386e0c0f1"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("df240c04-f835-4c40-bf90-0015e5b800ac"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e96a0b60-7208-4a96-89f9-ec593e348dde"));
        }
    }
}
