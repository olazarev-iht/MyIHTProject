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
                values: new object[] { new Guid("07b6a150-baa3-4678-a1d4-b10f09753cb1"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("0ada8cb3-3494-45fb-ab04-12103da47f88"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("4427941c-9fb1-4fb1-9600-0df5764f14b7"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("51b94736-fb36-4514-be33-047f1354169e"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5b9cd653-299c-4e87-a2ce-be4fcf1856c6"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("72e34c7c-b75f-49b2-ab97-630a7362c5bc"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("9345db91-5274-4b58-ada9-f05c626c764e"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("956f804f-7f7d-4b9b-910a-2830dce80162"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b852b056-a29d-4d80-ba7a-6db5e0b69045"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ea67cc0c-1f24-4e6e-a8be-d45a38f33744"), "APCDevice_1", 1 });

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
                values: new object[] { new Guid("0693452c-2282-44b5-b920-3ebb0e81fad0"), "client1", "", "{ 'Name':'Slag Post Time', 'Mode':'Slider' }", "SlagPostTime", "Slag Post Time", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("06f7d51e-5c93-4e1e-bb5a-34f4e7d26d32"), "default", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("15aaeb13-b0f5-4d6a-b509-bcf93257304e"), "default", "", "{ 'Name':'Start Preflow', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "CutO2Blowout", "Start Preflow", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("15bf4602-b563-40f8-bd4a-47b26c3097ac"), "default", "Height Calibration Active", "", "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("17a0a7a7-2816-4c09-a9a7-9d434d3f11b6"), "default", "", "{ 'Name':'Slag Sensitivity', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", "SlagSensitivity", "Slag Sensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1f86f88d-a1ec-4818-ba1a-cbf5bd60e436"), "client1", "Height Control Active", "{ 'Name':'Height Control Active', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("228a8b7e-388b-42b0-b74a-fbe3b05c9cac"), "default", "", "{ 'Name':'Slag Cutting Speed Reduction', 'Mode':'Slider' }", "SlagCuttingSpeedReduction", "Slag Cutting Speed Reduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2fe03687-8506-4a3f-91d1-78ad28cb28cc"), "client1", "", "", "PiercingSensorMode", "Piercing with Height Control", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("314e9b5c-f873-44cd-b8ac-442801206ffa"), "default", "", "{ 'Name':'PreFlow Timeout', 'Mode':'Slider' }", "CutO2BlowOutTimeOut", "PreFlow Timeout", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("35cac32d-ae85-4a0d-b4ef-39548d27b5ec"), "client1", "Preflow active time", "", "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4b0d1cbe-17d7-4775-a015-7474c49dc0d0"), "client1", "", "{ 'Name':'Start Preflow', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "CutO2Blowout", "Start Preflow", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4c67fb77-bea9-4761-9932-6e02417146ae"), "default", "Preflow active time", "", "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5102891f-6257-47c9-bbb5-4c06ea99afef"), "default", "", "{ 'Name':'PreFlow Time', 'Mode':'Slider' }", "CutO2BlowOutTime", "PreFlow Time", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("54ce2dd9-16e0-41a7-b4fb-eba0c7ca3c48"), "client1", "", "{ 'Name':'Slag Sensitivity', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", "SlagSensitivity", "Slag Sensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("55981a3e-c058-422d-8149-c4ee8982e586"), "client1", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("60c102fc-d83a-48ae-a93f-7a42dcf52cf9"), "client1", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("60dc1f09-b513-4682-9143-8e07cc48c1dc"), "client1", "Height Calibration Valid", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6955d318-4dbe-47b1-b054-5d01eee83587"), "client1", "", "{ 'Name':'PreFlow Timeout', 'Mode':'Slider' }", "CutO2BlowOutTimeOut", "PreFlow Timeout", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("70a7130e-2b3d-434b-ae57-3b8680ed6ed2"), "default", "", "{ 'Name':'PreFlow Pressure', 'Mode':'Slider' }", "CutO2BlowOutPressure", "PreFlow Pressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("71669672-17f9-4a86-b485-ff2d065aa0b2"), "default", "Preflow active", "", "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("75835acd-4103-4690-8b4b-702d7098f459"), "default", "Manual Height Calibration", "{ 'Name':'Manual Height Calibration', 'Mode':'Slider', 'Unit' : true }", "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("842ff115-598d-4333-a151-7c6155dea986"), "client1", "Height Calibration Active", "", "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8f564224-0fb9-4ccb-a4eb-a8f1672b7381"), "client1", "Retract Position enable", "", "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("92d0a136-29c1-4dd0-9430-5776247c9c7e"), "default", "Retract Position enable", "", "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9645dbef-dcd0-43a7-bd0e-f06aca4e907a"), "default", "", "{ 'Name':'Slag Post Time', 'Mode':'Slider' }", "SlagPostTime", "Slag Post Time", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("98484d0e-6999-4670-aee5-09efbf4b24d8"), "client1", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a0a41d32-2349-4ea9-86cc-90f431a0c03e"), "client1", "Manual Height Calibration", "{ 'Name':'Manual Height Calibration', 'Mode':'Slider', 'Unit' : true }", "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a1074dd5-67fa-4e7a-a2ae-7571e015859f"), "client1", "", "{ 'Name':'Dynamic', 'Mode':'Slider' }", "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a6d2befd-1fa5-4996-a422-d7383e86d27a"), "default", "", "", "CutO2BlowoutBreak", "Break Preflow", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b0ff30ee-83e0-4829-a534-97c385f4297a"), "client1", "", "{ 'Name':'PreFlow Pressure', 'Mode':'Slider' }", "CutO2BlowOutPressure", "PreFlow Pressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b7c5d36e-2b42-4d2c-9a75-79ee0515235f"), "default", "Height Calibration Valid", "{ 'Name':'Height Calibration Valid', 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ba055367-ee67-4d0e-982a-bcbb96ace35d"), "client1", "Retract Position", "{ 'Name':'Retract Position', 'Mode':'Slider' }", "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ba802c23-dd98-4ec0-9b27-33ba8dd3422a"), "default", "Position", "{ 'Unit' : true }", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("bb764ff2-5f33-4ce4-af9e-01d63689714e"), "default", "", "{ 'Name':'Dynamic', 'Mode':'Slider' }", "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cb7d8c0e-222f-4f1e-bf4e-3912d0ccbda6"), "default", "Retract Position", "{ 'Name':'Retract Position', 'Mode':'Slider' }", "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d08f4edb-afe4-4fcd-ba30-420a1c89a311"), "default", "Automatic Height Calibration", "{ 'Name':'Automatic Height Calibration', 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d20008f6-0a76-4364-b5ba-256c15a96d20"), "client1", "", "", "CutO2BlowoutBreak", "Break Preflow", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("da3a736b-023c-42ae-9553-049738a31545"), "client1", "", "{ 'Name':'Slag Cutting Speed Reduction', 'Mode':'Slider' }", "SlagCuttingSpeedReduction", "Slag Cutting Speed Reduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e23000f9-daa6-4ab0-a3e2-45ddef046f4e"), "client1", "Automatic Height Calibration", "{ 'Name':'Automatic Height Calibration', 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e862b7a2-13bc-493e-9d04-c27a5c7d288f"), "default", "", "", "PiercingSensorMode", "Piercing with Height Control", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("eee524de-9ddc-412d-91e2-1cd4e8d91738"), "client1", "", "{ 'Name':'PreFlow Time', 'Mode':'Slider' }", "CutO2BlowOutTime", "PreFlow Time", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f212a976-2188-4ed7-ace9-d483d535e790"), "default", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f5dc9b02-eea3-4e72-a97d-a3323d6b4351"), "client1", "Preflow active", "", "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("faf04a79-0f43-40cb-beb3-040bfafe4510"), "default", "Height Control Active", "{ 'Name':'Height Control Active', 'Mode':'NoYes', 'Values': ['No','Yes'] }", "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

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
                keyValue: new Guid("07b6a150-baa3-4678-a1d4-b10f09753cb1"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("0ada8cb3-3494-45fb-ab04-12103da47f88"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("4427941c-9fb1-4fb1-9600-0df5764f14b7"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("51b94736-fb36-4514-be33-047f1354169e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5b9cd653-299c-4e87-a2ce-be4fcf1856c6"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("72e34c7c-b75f-49b2-ab97-630a7362c5bc"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("9345db91-5274-4b58-ada9-f05c626c764e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("956f804f-7f7d-4b9b-910a-2830dce80162"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b852b056-a29d-4d80-ba7a-6db5e0b69045"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("ea67cc0c-1f24-4e6e-a8be-d45a38f33744"));
        }
    }
}
