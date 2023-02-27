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
                    Descritpion = table.Column<string>(type: "TEXT", nullable: true),
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
                values: new object[] { new Guid("4a51f634-c0ca-403c-a5dd-aeb6e91127cc"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5173aead-908c-4a37-a657-0a152eee03c0"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5c557b78-3819-4a79-894a-a521933eecf0"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("6a8ee60d-c93b-4328-a005-2eb4c729f277"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("9ebd6178-83f1-41c2-af83-e823296cf082"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a16e83c2-a5d0-4105-8470-e44692e4e0b9"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a6175539-dd66-4fc2-9e94-2e5224b3113d"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("bb6f7249-7496-488a-9bcc-c07855856583"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c1c34d26-e850-4c9f-b59c-a60a71518b3b"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c26ba7d2-c55d-4ae0-9555-e6caa4935421"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "ConfigSettings",
                columns: new[] { "Id", "Baudrate", "ComPort", "ComPortLast", "CultureStr", "DataBaseGuid", "DataBaseMaterialSelectedIndex", "DataBaseNozzleSelectedIndex", "DataBaseThicknessSelectedIndex", "DataBits", "ExecReset", "Identifier", "IpAddr", "LengthUnit", "Mode", "Parity", "PressureUnit", "StopBits", "TcpPort", "TorchEnabled_01", "TorchEnabled_02", "TorchEnabled_03", "TorchEnabled_04", "TorchEnabled_05", "TorchEnabled_06", "TorchEnabled_07", "TorchEnabled_08", "TorchEnabled_09", "TorchEnabled_10", "TorchInstalled_01", "TorchInstalled_02", "TorchInstalled_03", "TorchInstalled_04", "TorchInstalled_05", "TorchInstalled_06", "TorchInstalled_07", "TorchInstalled_08", "TorchInstalled_09", "TorchInstalled_10", "TorchType" },
                values: new object[] { new Guid("4639e49e-a4ee-4a05-82ce-c7de620d5a19"), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

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
                values: new object[] { new Guid("2413adb7-eb0f-4d69-a80c-9050c4640c8f"), "default", "CalibrationActive", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3aed02df-b189-4a64-b559-6f707b3fd15d"), "default", "DistanceCalibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3f1a09a1-dda3-4f38-8e23-6cf34464c7ad"), "default", "CutO2BlowoutBreak", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("40b62111-cb5d-4a4b-a941-625b6c8c0be3"), "default", "RetractHeight", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4518498a-39a3-4b60-8295-910e86811794"), "default", "CutO2BlowOutPressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4d845ea8-f35e-4a34-ac9a-fde03dbde40a"), "default", "HeightControlActive", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6079dfcb-a9e1-4257-90ec-5e3aafc81b1c"), "default", "CutO2BlowoutActive", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6bfb70f3-9a15-4a12-8842-786322949fd1"), "default", "PiercingSensorMode", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("71537cd2-fdd9-464e-83cd-bcdf55366c48"), "default", "LinearDrivePosition", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("79650d85-cc84-4181-9943-71c819290cf4"), "default", "RetractPosAtProcessEnd", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8200a742-41af-4711-9129-b338f639a8ac"), "default", "SlagPostTime", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8f1be1af-03c7-4711-96eb-06ff260c659b"), "default", "LinearDrivePosition", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9080daa6-5857-4a73-a72e-ae669ff65751"), "default", "CutO2Blowout", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b3fd7726-87e3-4cbe-9871-1b971caac13f"), "default", "TactileInitialPosFinding", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b810546d-abfb-4918-8872-40d4731aa3e1"), "default", "SlagSensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b9c4db38-0f85-4163-84e4-008a50dea3a5"), "default", "CalibrationValid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c74494c0-2624-4d3a-92ab-48d47ed0db57"), "default", "CurrCutO2BlowoutTime", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("dfe0aa68-e923-41ef-a0a4-0825dd120105"), "default", "CutO2BlowOutTime", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e1209413-22d3-4c22-bd26-990d8e188a12"), "default", "SlagCuttingSpeedReduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e940891a-da1c-4c0a-939e-0f8ec9934c1b"), "default", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f652db60-b994-4e76-b837-5fa965e35cf4"), "default", "CutO2BlowOutTimeOut", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fc0ac9a0-58d6-43e0-91e4-982b430b67e8"), "default", "StatusHeightControl", 4, "HeightControl", 0 });

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
                keyValue: new Guid("4a51f634-c0ca-403c-a5dd-aeb6e91127cc"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5173aead-908c-4a37-a657-0a152eee03c0"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5c557b78-3819-4a79-894a-a521933eecf0"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("6a8ee60d-c93b-4328-a005-2eb4c729f277"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("9ebd6178-83f1-41c2-af83-e823296cf082"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("a16e83c2-a5d0-4105-8470-e44692e4e0b9"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("a6175539-dd66-4fc2-9e94-2e5224b3113d"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("bb6f7249-7496-488a-9bcc-c07855856583"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c1c34d26-e850-4c9f-b59c-a60a71518b3b"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c26ba7d2-c55d-4ae0-9555-e6caa4935421"));
        }
    }
}
