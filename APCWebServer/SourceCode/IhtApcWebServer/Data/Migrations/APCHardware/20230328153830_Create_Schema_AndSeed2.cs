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
                    DataBaseId = table.Column<int>(type: "INTEGER", nullable: true),
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
                    Params = table.Column<string>(type: "TEXT", nullable: true),
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
                values: new object[] { new Guid("13a3b1ce-59b6-4ef2-a7d2-5e071bde172c"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("26c71ba3-b449-45b4-8c13-2559b6579baf"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("52862abc-88bf-4207-94d6-228a211a85e1"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("62d17612-ec74-4c41-a3bc-c70b51a65813"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("7d59bcf7-c0f2-467d-9a93-02e1e5ee7395"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("7d96047a-d2d6-45d7-96a1-bdb2fd585ac4"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("bcf8822c-3d4d-41fd-9031-7709f8cd24ba"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("cbaa8871-7051-4277-895c-e4aab0c895e7"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("dc81a4d9-7ea3-4ee8-a53e-0caec295b57a"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("fd3f0c49-68fa-40ad-ba9f-23e31798b6d2"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "ConfigSettings",
                columns: new[] { "Id", "Baudrate", "ComPort", "ComPortLast", "CultureStr", "DataBaseGuid", "DataBaseId", "DataBaseMaterialSelectedIndex", "DataBaseNozzleSelectedIndex", "DataBaseThicknessSelectedIndex", "DataBits", "ExecReset", "Identifier", "IpAddr", "LengthUnit", "Mode", "Parity", "PressureUnit", "StopBits", "TcpPort", "TorchEnabled_01", "TorchEnabled_02", "TorchEnabled_03", "TorchEnabled_04", "TorchEnabled_05", "TorchEnabled_06", "TorchEnabled_07", "TorchEnabled_08", "TorchEnabled_09", "TorchEnabled_10", "TorchInstalled_01", "TorchInstalled_02", "TorchInstalled_03", "TorchInstalled_04", "TorchInstalled_05", "TorchInstalled_06", "TorchInstalled_07", "TorchInstalled_08", "TorchInstalled_09", "TorchInstalled_10", "TorchType" },
                values: new object[] { new Guid("48f8a717-1fbb-425e-81dc-cd5402319134"), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "Flashback", "Flashback", 8 });

            migrationBuilder.InsertData(
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "GasController", "Gas Controller", 10 });

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
                values: new object[] { "Ignition", "Ignition", 7 });

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
                table: "ParamViewGroups",
                columns: new[] { "Id", "GroupName", "GroupOrder" },
                values: new object[] { "Torch", "Torch", 9 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0635d04d-9891-46ed-b0cd-f838240798d5"), "default", "HeightControlActive", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0cc6bc0d-397b-49f1-863c-dfd9190f8ad6"), "default", "SlagCuttingSpeedReduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0cc9ba85-4fff-4593-8364-54fbfe717293"), "default", "CutO2BlowOutPressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0ed77424-6645-43bb-8525-eea49161fe39"), "default", "StatusHeightControl", 4, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("141ffbbc-d8b4-4989-9c90-94c9dbb3dc7d"), "default", "SlagPostTime", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("25e2445b-b804-42f1-880c-7eafd56acab8"), "default", "LinearDriveUpSpeedSlow", 8, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("290ddfff-ae11-4eee-b631-3e42350242b3"), "default", "IgnitionDetectionEnable", 1, "Ignition", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2c808f68-84b9-4b4a-92d4-2c4805e8a535"), "default", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2fba09d1-527c-4e08-bef3-7bd37dc61d7d"), "default", "ToleranceInPosition", 14, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("305b9dfa-6804-4219-9aae-716c0a66e41e"), "default", "DistanceCalibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("386fdfec-1fa4-424e-9094-c4aca2c11739"), "default", "LinearDrivePosition", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3abb77d0-52bc-468b-bd11-0bfba77e2474"), "default", "SensorCollisionDelay", 1, "Torch", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("47f7a72b-1ac6-4180-86bf-21afc8ad444b"), "default", "HeatO2PostFlowPressure", 2, "GasController", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5a25deeb-20c6-404b-a21b-46aeb9a363a9"), "default", "LinearDriveDnSpeedFast", 7, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6413b227-3401-461d-a9c7-6a7217b45272"), "default", "CutO2BlowoutBreak", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("66b83d99-77e9-487b-8cc7-4c903f67c077"), "default", "LinearDriveManualPosSpeed", 11, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6d05b800-c2f1-44dd-bd93-ecb7c388fa5c"), "default", "LinearDriveUpSpeedFast", 5, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6d7cc6cc-f486-4da3-a87b-3df01b500cec"), "default", "CalibrationValid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6f1f41db-be39-4fd1-9be8-78dd58f78cf7"), "default", "CurrCutO2BlowoutTime", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6f6be26b-b12c-4b20-8418-1693052c42a8"), "default", "HeatO2PostFlowMultiplier", 1, "GasController", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("81b0329d-fa5c-4036-991d-f1b22d0ace62"), "default", "SlagSensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("923f06c9-3e24-40a8-ae85-49bc03876622"), "default", "CutO2Blowout", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("962d116d-0efc-442c-b2ee-42d1317e0601"), "default", "SensorCollisionOutputDisable", 15, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a8fe85e0-8fb3-4ab5-b4a3-dac06d09bab1"), "default", "IgnitionOnDurationTime", 3, "Ignition", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a9789dd7-17de-4bcc-8295-5af305c1c72d"), "default", "LinearDriveDnSpeedSlow", 6, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b6cdcbfc-631f-48ab-9611-e1a3ce3de6be"), "default", "TactileInitialPosFinding", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b8521074-2e20-4836-9bb4-cb97a73ded51"), "default", "LinearDrivePosSpeed", 10, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("bb124774-fa1e-4bed-bf5e-c97902366f1a"), "default", "PiercingSensorMode", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c0d583db-6982-499d-9365-0e07f53510c1"), "default", "LinearDrivePosition", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c336e563-e5dc-432d-a31b-82b9b1adbaad"), "default", "CalibrationActive", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c7a31309-e463-4722-9b3a-b8f1d3811851"), "default", "IgnitionPreFlowMultiplier", 2, "Ignition", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c801a462-9a41-4939-b9bc-0d553a67afc3"), "default", "FlashbackSensivitity", 1, "Flashback", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c8926dc7-d4e4-49b8-8596-8fa9d85e0a41"), "default", "CutO2BlowOutTimeOut", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cab16d5b-4b59-4841-bcdb-07aea0e317ed"), "default", "CapSetpointFlameOffs", 13, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cafd7f59-ff91-433f-aa63-7d71e1e45470"), "default", "RetractHeight", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cb043ec4-f8d9-405f-b592-3d2dd8db3bd3"), "default", "CutO2BlowOutTime", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ceb8a62a-75c8-4ab3-a38d-eafc1977c257"), "default", "HoseLength", 2, "Torch", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cf93ce3d-cfe8-41ce-b006-a7c3d0b70652"), "default", "RetractPosAtProcessEnd", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("dc07f05c-f202-4eca-b8a5-b1df4f8abc86"), "default", "PidErrorThresholdDelay", 12, "HeightControl", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fa593295-4a8a-4501-9b43-473ac0cc9ac8"), "default", "CutO2BlowoutActive", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fc00f9d8-1727-41f4-9da1-91f171410ae6"), "default", "LinearDriveRefSpeed", 9, "HeightControl", 1 });

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
                keyValue: new Guid("13a3b1ce-59b6-4ef2-a7d2-5e071bde172c"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("26c71ba3-b449-45b4-8c13-2559b6579baf"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("52862abc-88bf-4207-94d6-228a211a85e1"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("62d17612-ec74-4c41-a3bc-c70b51a65813"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("7d59bcf7-c0f2-467d-9a93-02e1e5ee7395"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("7d96047a-d2d6-45d7-96a1-bdb2fd585ac4"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("bcf8822c-3d4d-41fd-9031-7709f8cd24ba"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("cbaa8871-7051-4277-895c-e4aab0c895e7"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("dc81a4d9-7ea3-4ee8-a53e-0caec295b57a"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("fd3f0c49-68fa-40ad-ba9f-23e31798b6d2"));
        }
    }
}
