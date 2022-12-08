using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    public partial class Create_Schema_AndSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ParamType = table.Column<string>(type: "TEXT", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    ParamViewGroupId = table.Column<string>(type: "TEXT", nullable: true),
                    ParamOrder = table.Column<int>(type: "INTEGER", nullable: false)
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
                values: new object[] { new Guid("1af10384-d68d-433f-9b05-cdb7f486493a"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("279c286c-a72b-49c8-befe-789c22700603"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("559fa930-4305-4a54-80fb-9324ad369946"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("6aa188e1-d117-4ec8-87ef-be8c42274865"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("93094d3c-f207-42ce-8c2a-f8b200bdaeed"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b02308d0-01be-4a7a-b4fc-7fa01f6a3c50"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b078bb1f-ade0-4559-884e-6ec5e31921a1"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("d7215d1b-d13c-4ad8-9ae3-22e034c547ae"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e7c63021-95c4-439e-9c62-42fe7081a9fc"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e891bb40-93e8-4014-b53c-ceb73f3d84d6"), "APCDevice_2", 2 });

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
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0367b4ad-0876-48cb-90d2-281b4e3c9ceb"), "client1", "Retract Position", "{ 'Name':'Retract Position', 'Mode':'Slider' }", "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0dbf0724-5ae7-4dc8-934d-cbdee1c8eec7"), "default", "Retract Position enable", "", "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("12beab6d-04f8-424d-964f-4de7b08c1822"), "default", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("13958bad-03ea-4c1f-bc3c-e0392302c97d"), "client1", "Height Calibration Valid", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1618b4e0-5b8d-4348-a2f5-06b4a63949f4"), "default", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("162fd825-ebfd-4061-a932-a532c9435f43"), "default", "Start Preflow", "{ 'Name':'Start Preflow', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "CutO2Blowout", "CutO2Blowout", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("19c73840-fa97-4fe7-b114-dcba2c1efd08"), "client1", "Start Preflow", "{ 'Name':'Start Preflow', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "CutO2Blowout", "CutO2Blowout", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2b3a4d6e-7e1d-4b5e-8682-389220b513b3"), "default", "PreFlow Timeout", "{ 'Name':'PreFlow Timeout', 'Mode':'Slider' }", "CutO2BlowOutTimeOut", "CutO2BlowOutTimeOut", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2d285458-7abd-4d9f-bfca-52e5338c1556"), "client1", "Slag Cutting Speed Reduction", "{ 'Name':'Slag Cutting Speed Reduction', 'Mode':'Slider' }", "SlagCuttingSpeedReduction", "SlagCuttingSpeedReduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("308c47f6-3be6-4926-ba68-9ba2957d143c"), "client1", "Slag Sensitivity", "{ 'Name':'Slag Sensitivity', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", "SlagSensitivity", "SlagSensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3d6c4bba-a427-4193-a212-cb1ca71ab8f3"), "default", "Piercing with Height Control", "", "PiercingSensorMode", "PiercingSensorMode", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("498e10d9-92a3-4df1-8392-ac266c543d5c"), "default", "Height Calibration Valid", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("50ccda05-c035-4538-becf-883e1c78852e"), "client1", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5ab417cd-2d15-46b6-bfb7-e11012f4a7e0"), "client1", "Retract Position enable", "", "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5ac0ac86-06dd-4c2a-81d3-1587516c2b88"), "default", "Break Preflow", "", "CutO2BlowoutBreak", "CutO2BlowoutBreak", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5bc6b834-f959-4637-8e7f-f26185d4ee50"), "client1", "Preflow active", "", "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5e72f5af-5047-4bfc-b962-1f093253c15a"), "client1", "Piercing with Height Control", "", "PiercingSensorMode", "PiercingSensorMode", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5f12f4c3-ae36-4b15-868f-fdc35fa7456b"), "default", "PreFlow Pressure", "{ 'Name':'PreFlow Pressure', 'Mode':'Slider' }", "CutO2BlowOutPressure", "CutO2BlowOutPressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5f29ffac-4833-40a4-a0ce-e12c9aa526b3"), "client1", "Slag Post Time", "{ 'Name':'Slag Post Time', 'Mode':'Slider' }", "SlagPostTime", "SlagPostTime", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("61c52adc-aaaa-4335-8591-8180f495ab33"), "client1", "Height Calibration Active", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6c3af5ec-95ff-45ef-bc4a-16d4088634ad"), "client1", "Dynamic", "{ 'Name':'Dynamic', 'Mode':'Slider' }", "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6f608bb2-c946-409c-883d-922bdd8fc474"), "client1", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6fc1a888-af62-416c-a2b7-f12cb204bb5b"), "client1", "PreFlow Time", "{ 'Name':'PreFlow Time', 'Mode':'Slider' }", "CutO2BlowOutTime", "CutO2BlowOutTime", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7de4ce8a-9db0-4189-9847-2bf9db8769b4"), "default", "PreFlow Time", "{ 'Name':'PreFlow Time', 'Mode':'Slider' }", "CutO2BlowOutTime", "CutO2BlowOutTime", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("84ce1ec1-9f40-4d9a-973c-ded7a1941d43"), "client1", "Manual Height Calibration", "{ 'Name':'Manual Height Calibration', 'Mode':'Slider', 'Unit' : true }", "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("96d5b4cd-5c37-4532-b875-db5c64c362d1"), "default", "Slag Cutting Speed Reduction", "{ 'Name':'Slag Cutting Speed Reduction', 'Mode':'Slider' }", "SlagCuttingSpeedReduction", "SlagCuttingSpeedReduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a0d039c6-9d4c-466d-8e32-73041de16829"), "default", "Slag Sensitivity", "{ 'Name':'Slag Sensitivity', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", "SlagSensitivity", "SlagSensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a15fdfbf-fb87-4937-b979-46e1ed82ed0a"), "default", "Height Control Active", "{ 'Name':'Height Control Active', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a936744a-64ec-4bb5-ba1a-16c9f79f5219"), "client1", "Height Control Active", "{ 'Name':'Height Control Active', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ab42d8d6-f752-435b-99f1-4fc32f5b02ae"), "client1", "Automatic Height Calibration", "{ 'Name':'Automatic Height Calibration', 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b1dc5880-ec74-4ee9-9d8c-74098a6d0657"), "default", "Preflow active time", "", "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b4570ff6-a110-49b4-944c-dc95036bc881"), "client1", "Break Preflow", "", "CutO2BlowoutBreak", "CutO2BlowoutBreak", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b4851fcd-a30c-4011-927d-5ec1749e4d33"), "client1", "PreFlow Pressure", "{ 'Name':'PreFlow Pressure', 'Mode':'Slider' }", "CutO2BlowOutPressure", "CutO2BlowOutPressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b9d86967-8f50-4a2c-9bc5-e7e01c51b0c2"), "default", "Height Calibration Active", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("badc6839-4774-43e9-a5f7-13d8b735052e"), "default", "Automatic Height Calibration", "{ 'Name':'Automatic Height Calibration', 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cc7592a8-2ee6-4fd7-b84d-0c3d2f7afe82"), "client1", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d3cee498-a8a2-419a-a99b-6174692ba678"), "default", "Slag Post Time", "{ 'Name':'Slag Post Time', 'Mode':'Slider' }", "SlagPostTime", "SlagPostTime", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d89d0e22-78d1-413a-b04e-c5924a5e85cf"), "client1", "PreFlow Timeout", "{ 'Name':'PreFlow Timeout', 'Mode':'Slider' }", "CutO2BlowOutTimeOut", "CutO2BlowOutTimeOut", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d93c322c-d017-465e-8cd8-6bf567627c4a"), "default", "Dynamic", "{ 'Name':'Dynamic', 'Mode':'Slider' }", "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e4479e4b-67c0-4fb5-ba7b-d75c50cf5040"), "default", "Preflow active", "", "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e5cee410-3551-4a9e-80d0-8d1b07c95c89"), "default", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f0a1d408-620e-4533-a659-b9d6dab0f37a"), "default", "Retract Position", "{ 'Name':'Retract Position', 'Mode':'Slider' }", "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f697e6ff-3e4c-4970-b892-7d4c503e6447"), "default", "Manual Height Calibration", "{ 'Name':'Manual Height Calibration', 'Mode':'Slider', 'Unit' : true }", "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fc0c00ad-61ef-4981-aa61-edf5f3aafda9"), "client1", "Preflow active time", "", "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ParamSettings_ParamViewGroupId",
                table: "ParamSettings",
                column: "ParamViewGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParamSettings");

            migrationBuilder.DropTable(
                name: "ParamViewGroups");

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("1af10384-d68d-433f-9b05-cdb7f486493a"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("279c286c-a72b-49c8-befe-789c22700603"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("559fa930-4305-4a54-80fb-9324ad369946"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("6aa188e1-d117-4ec8-87ef-be8c42274865"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("93094d3c-f207-42ce-8c2a-f8b200bdaeed"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b02308d0-01be-4a7a-b4fc-7fa01f6a3c50"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b078bb1f-ade0-4559-884e-6ec5e31921a1"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("d7215d1b-d13c-4ad8-9ae3-22e034c547ae"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e7c63021-95c4-439e-9c62-42fe7081a9fc"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e891bb40-93e8-4014-b53c-ceb73f3d84d6"));
        }
    }
}
