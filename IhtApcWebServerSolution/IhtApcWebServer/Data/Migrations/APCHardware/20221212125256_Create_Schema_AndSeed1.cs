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
                    ParamGroup = table.Column<int>(type: "INTEGER", nullable: true),
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
                values: new object[] { new Guid("0b1e66de-32de-4beb-b35f-798fadbcef05"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("1716dd08-6b3b-44ce-8abc-74e8e4cc3978"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("54c90287-987e-48c5-a2e6-031bd6920266"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a30a8b96-3da3-40b1-8c77-74711cd25109"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("bb87bc57-9f1e-44e7-ac97-defda44b3409"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("bf24045c-6121-48bd-a9fc-4213c6d83193"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c3ff3362-29a1-44f4-b4e4-ed7722e7439a"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e3bd12aa-bfe5-4e9b-844a-6b5744e02ecb"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e3c2b2c7-bdbb-4d5c-8b2d-bb5dbfb016de"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ef6e4c43-4e9b-43e1-82d8-d5e93134c7b8"), "APCDevice_7", 7 });

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
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0378de61-3818-4fe1-b481-6a0e3f3b8ebc"), "default", "PreFlow Timeout", "{ 'Name':'PreFlow Timeout', 'Mode':'Slider' }", 3, "CutO2BlowOutTimeOut", "CutO2BlowOutTimeOut", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("09283348-0814-4161-a79a-970bca038386"), "client1", "Height Control Active", "{ 'Name':'Height Control Active', 'Mode':'NoYes', 'Values': ['No','Yes'] }", null, "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0a9474a3-7a95-4e4a-a69a-b558b1ccfba9"), "client1", "Retract Position", "{ 'Name':'Retract Position', 'Mode':'Slider' }", null, "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0f6c7d17-fe67-465f-93b2-7666bede9e9d"), "client1", "Slag Sensitivity", "{ 'Name':'Slag Sensitivity', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", null, "SlagSensitivity", "SlagSensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("121d36d9-c094-42bb-afbb-1b0063378688"), "default", "Retract Position", "{ 'Name':'Retract Position', 'Mode':'Slider' }", 2, "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1cffd581-c29e-448f-8bdf-fcbb7f70d025"), "default", "Preflow active", "", null, "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1d735604-82d3-486f-9d29-dc2d8831fb97"), "client1", "Height Calibration Active", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", null, "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("29b78fde-7979-43d9-85cb-3d89a6821c9a"), "client1", "Dynamic", "{ 'Name':'Dynamic', 'Mode':'Slider' }", null, "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2a689576-84af-4460-9fb8-8329fc6b1200"), "client1", "Slag Cutting Speed Reduction", "{ 'Name':'Slag Cutting Speed Reduction', 'Mode':'Slider' }", null, "SlagCuttingSpeedReduction", "SlagCuttingSpeedReduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("332316b3-075d-4064-82fd-34475f8ac6d6"), "client1", "Preflow active", "", null, "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3a804707-0c9c-4de7-9cae-bdecbb3da41e"), "client1", "Piercing with Height Control", "", null, "PiercingSensorMode", "PiercingSensorMode", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3d6a20ed-f3a4-4d21-a560-7a2e735d69a2"), "client1", "Manual Height Calibration", "{ 'Name':'Manual Height Calibration', 'Mode':'Slider', 'Unit' : true }", null, "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("43862ed9-7219-406c-8d11-fa924fba3139"), "client1", "Automatic Height Calibration", "{ 'Name':'Automatic Height Calibration', 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", null, "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("487c0bd9-94f2-4cc3-92f1-55ab7c11a24d"), "default", "Preflow active time", "", 5, "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4c6854e8-1156-4462-8c73-5bac960e3f3b"), "client1", "PreFlow Timeout", "{ 'Name':'PreFlow Timeout', 'Mode':'Slider' }", null, "CutO2BlowOutTimeOut", "CutO2BlowOutTimeOut", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4f82c303-27d5-48d3-bac4-acc9a3e3a3ca"), "client1", "Preflow active time", "", null, "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4fcd83bc-2c93-4b29-b750-79c0e56e67bd"), "default", "Dynamic", "{ 'Name':'Dynamic', 'Mode':'Slider' }", 3, "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("511d7091-84e8-4e3c-ab00-5332123e3af6"), "client1", "Slag Post Time", "{ 'Name':'Slag Post Time', 'Mode':'Slider' }", null, "SlagPostTime", "SlagPostTime", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("51b4c7ff-4b08-4c16-9b1f-cc13c3be24bf"), "default", "Slag Cutting Speed Reduction", "{ 'Name':'Slag Cutting Speed Reduction', 'Mode':'Slider' }", 4, "SlagCuttingSpeedReduction", "SlagCuttingSpeedReduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("530bbbfe-558c-409b-a834-d201ef737423"), "client1", "Position", "{ 'Unit' : true }", null, "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5a1cdf68-13cb-46f7-98f8-ec6a04fedf85"), "default", "Position", "{ 'Unit' : true }", null, "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5fbef7a4-91f0-4410-9d99-b0170f2d1726"), "default", "Slag Post Time", "{ 'Name':'Slag Post Time', 'Mode':'Slider' }", 2, "SlagPostTime", "SlagPostTime", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("61da2226-84c3-44bd-900b-a7ceba491134"), "client1", "Position", "{ 'Unit' : true }", null, "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("64425f80-a3f0-43a5-9b03-bca5250dfd36"), "default", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", null, "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("659f7a5a-9c47-4f8d-bf0f-9c67daec54bb"), "default", "Start Preflow", "{ 'Name':'Start Preflow', 'Mode':'NoYes', 'Values': ['No','Yes'] }", null, "CutO2Blowout", "CutO2Blowout", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("70cf171f-6116-49d4-a0d2-2c19e35578b4"), "default", "Automatic Height Calibration", "{ 'Name':'Automatic Height Calibration', 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", 3, "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("798026df-73be-41e3-a7c8-1ebd434091e6"), "default", "Break Preflow", "", null, "CutO2BlowoutBreak", "CutO2BlowoutBreak", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8778da37-58a7-4a21-a60f-3619132fd800"), "default", "Slag Sensitivity", "{ 'Name':'Slag Sensitivity', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", 2, "SlagSensitivity", "SlagSensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("90fbdf25-83f7-4549-82a1-6e88378d0b7b"), "client1", "Retract Position enable", "", null, "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("925f054d-7305-4c95-aadb-c6261c3f170c"), "default", "PreFlow Pressure", "{ 'Name':'PreFlow Pressure', 'Mode':'Slider' }", 3, "CutO2BlowOutPressure", "CutO2BlowOutPressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9b83801a-4c2d-4dd6-8c6e-6d6d4ccce668"), "client1", "Height Calibration Valid", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", null, "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a69a750b-bd2c-42af-b2ec-00eb8407159c"), "default", "Position", "{ 'Unit' : true }", 5, "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ab630f47-9c83-456f-9b99-e85d618356d5"), "default", "Retract Position enable", "", null, "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("acad84dd-fe38-4921-83ab-45d8955a4774"), "default", "Height Control Active", "{ 'Name':'Height Control Active', 'Mode':'NoYes', 'Values': ['No','Yes'] }", null, "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("bb00bf55-78d8-4e8e-9e49-711832191825"), "client1", "Start Preflow", "{ 'Name':'Start Preflow', 'Mode':'NoYes', 'Values': ['No','Yes'] }", null, "CutO2Blowout", "CutO2Blowout", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c0f26b74-6065-465b-a394-3c9515958257"), "client1", "PreFlow Pressure", "{ 'Name':'PreFlow Pressure', 'Mode':'Slider' }", null, "CutO2BlowOutPressure", "CutO2BlowOutPressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c17a45a8-6724-431d-a230-bc50d0b1adcb"), "default", "Manual Height Calibration", "{ 'Name':'Manual Height Calibration', 'Mode':'Slider', 'Unit' : true }", 3, "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c81beb4b-d939-4774-ba03-00665bd738b7"), "client1", "Break Preflow", "", null, "CutO2BlowoutBreak", "CutO2BlowoutBreak", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d26ca615-e02a-4ab2-bc81-68aa6423b702"), "default", "Height Calibration Valid", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", null, "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d5651cf0-f638-44f9-925c-13f3ac9e1b5e"), "default", "PreFlow Time", "{ 'Name':'PreFlow Time', 'Mode':'Slider' }", 3, "CutO2BlowOutTime", "CutO2BlowOutTime", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("daaa28a9-77a4-4edd-9a24-d1fd5d2bd7dc"), "default", "Height Calibration Active", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", null, "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e6a57274-458f-425b-8c09-b9d09b2435b2"), "default", "Piercing with Height Control", "", 2, "PiercingSensorMode", "PiercingSensorMode", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f7fbf46c-6b15-41ea-b1fb-4ea4f83c82c2"), "client1", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", null, "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamGroup", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fdab6276-6c8e-4e01-a2d5-1d49e162f559"), "client1", "PreFlow Time", "{ 'Name':'PreFlow Time', 'Mode':'Slider' }", null, "CutO2BlowOutTime", "CutO2BlowOutTime", 5, "", "PreFlow", 1 });

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
                keyValue: new Guid("0b1e66de-32de-4beb-b35f-798fadbcef05"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("1716dd08-6b3b-44ce-8abc-74e8e4cc3978"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("54c90287-987e-48c5-a2e6-031bd6920266"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("a30a8b96-3da3-40b1-8c77-74711cd25109"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("bb87bc57-9f1e-44e7-ac97-defda44b3409"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("bf24045c-6121-48bd-a9fc-4213c6d83193"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c3ff3362-29a1-44f4-b4e4-ed7722e7439a"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e3bd12aa-bfe5-4e9b-844a-6b5744e02ecb"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e3c2b2c7-bdbb-4d5c-8b2d-bb5dbfb016de"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("ef6e4c43-4e9b-43e1-82d8-d5e93134c7b8"));
        }
    }
}
