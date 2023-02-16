using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    public partial class Create_ConfigSettings : Migration
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
                values: new object[] { new Guid("0d86da89-cb67-4fa3-a4a4-3e48bdb3c427"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("15ebd362-dbda-434f-b14e-04e3f2cfc4a6"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("198b12bd-9f42-41c4-a526-4d4b487f9ac3"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("1ceeb1b3-6f62-4653-820b-7ce1a1139fc3"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("24d515a1-cb91-4314-a7db-f1c007e40e75"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("38983e9f-6ffa-46f9-bf81-22fa2ebe98a6"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("4a562c31-79bf-4bcf-937c-b1a9d3f763ae"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("8bee6017-ca82-4eb3-a8d4-6f2a1316e8e2"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ab1d393b-f220-4230-a6a1-b7f4082238f2"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e7923f55-433c-46ea-a75c-651e016ab89d"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "ConfigSettings",
                columns: new[] { "Id", "Baudrate", "ComPort", "ComPortLast", "CultureStr", "DataBaseGuid", "DataBaseMaterialSelectedIndex", "DataBaseNozzleSelectedIndex", "DataBaseThicknessSelectedIndex", "DataBits", "ExecReset", "Identifier", "IpAddr", "LengthUnit", "Mode", "Parity", "PressureUnit", "StopBits", "TcpPort", "TorchEnabled_01", "TorchEnabled_02", "TorchEnabled_03", "TorchEnabled_04", "TorchEnabled_05", "TorchEnabled_06", "TorchEnabled_07", "TorchEnabled_08", "TorchEnabled_09", "TorchEnabled_10", "TorchInstalled_01", "TorchInstalled_02", "TorchInstalled_03", "TorchInstalled_04", "TorchInstalled_05", "TorchInstalled_06", "TorchInstalled_07", "TorchInstalled_08", "TorchInstalled_09", "TorchInstalled_10", "TorchType" },
                values: new object[] { new Guid("8d9f5e97-adb8-4e0e-a68f-a1eb10c5f906"), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

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
                values: new object[] { new Guid("048ca680-088b-4b97-8cf9-97fe59c6def3"), "default", "StatusHeightControl", 4, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0a959710-5d5d-43f5-a217-b92bf052c5cc"), "default", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("14a96817-f228-416e-8c68-60b31ed6e6fc"), "default", "LinearDrivePosition", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("36bebf5f-d789-4ae7-9dac-dec631f6460f"), "default", "CurrCutO2BlowoutTime", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("37635de6-17a5-4aa8-b70e-8161768b86bb"), "default", "RetractHeight", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3784114e-3887-4dff-89b2-a6f4b767bc52"), "default", "CutO2BlowOutTime", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4779aa90-aa21-4c0d-a4f4-2e55cf5b1bb3"), "default", "CalibrationActive", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("502c0604-d13e-497a-92e7-d730ee5506b3"), "default", "RetractPosAtProcessEnd", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("640b4b66-1975-4760-a27c-fcd2045f2d87"), "default", "HeightControlActive", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("737a2fa0-ce94-4c98-9e25-1750dc016e0e"), "default", "CutO2BlowoutBreak", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8bc0182f-d820-45cd-a63b-a0f438461936"), "default", "PiercingSensorMode", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("974821f5-0d6b-4e02-80c6-3da4b21a256c"), "default", "CalibrationValid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("999f44f7-caa7-437d-90cc-f8e82bdf186f"), "default", "DistanceCalibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("99b8ba95-b022-4b96-94ed-d8f9eeb0ba02"), "default", "CutO2Blowout", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9be972e1-d9c1-4ec1-9662-c4c8f0549cc1"), "default", "LinearDrivePosition", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ac41e042-cb79-4d6a-a55b-63e1744b5938"), "default", "SlagSensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b268811c-63b4-4f51-ab79-a5c34dfd6666"), "default", "SlagCuttingSpeedReduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c4cd2976-00f8-479a-b657-16afe3e54a35"), "default", "SlagPostTime", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d2c2d827-5e79-424c-9be6-27d0744b288c"), "default", "CutO2BlowOutPressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e514a400-3133-4d3d-83d9-a6bef8dbfaea"), "default", "CutO2BlowoutActive", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fae0c09c-1974-4a18-a974-dbb10bfda892"), "default", "CutO2BlowOutTimeOut", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fc8e4894-2455-4900-97c2-21bcf1492557"), "default", "TactileInitialPosFinding", 1, "HeightCalibration", 0 });

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
                name: "ParamSettings");

            migrationBuilder.DropTable(
                name: "ParamViewGroups");

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("0d86da89-cb67-4fa3-a4a4-3e48bdb3c427"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("15ebd362-dbda-434f-b14e-04e3f2cfc4a6"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("198b12bd-9f42-41c4-a526-4d4b487f9ac3"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("1ceeb1b3-6f62-4653-820b-7ce1a1139fc3"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("24d515a1-cb91-4314-a7db-f1c007e40e75"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("38983e9f-6ffa-46f9-bf81-22fa2ebe98a6"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("4a562c31-79bf-4bcf-937c-b1a9d3f763ae"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("8bee6017-ca82-4eb3-a8d4-6f2a1316e8e2"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("ab1d393b-f220-4230-a6a1-b7f4082238f2"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e7923f55-433c-46ea-a75c-651e016ab89d"));
        }
    }
}
