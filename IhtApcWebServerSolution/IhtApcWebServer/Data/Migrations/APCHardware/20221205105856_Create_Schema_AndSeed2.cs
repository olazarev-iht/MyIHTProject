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
                values: new object[] { new Guid("0e91a587-80cd-443b-9cc5-550987e021ae"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("1e82c7d0-bc74-45dc-977e-11c446e8d9c7"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("27bf2a81-83eb-487e-a331-b553c1734829"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("3d31b2b2-2a21-43f7-abc3-b748705d046c"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("4062d96e-8dcf-4e6a-bfd2-c31cefc6bd30"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("88b6b637-69ef-448a-80e2-dcd5a9ee5bec"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("9b99b32e-2ae1-4d4e-bad2-e5d7303d82a2"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b3703fd8-116a-42e3-80aa-e26c641d3ce5"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b45e6177-1c98-4067-96bf-8e193ef3af2b"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c3d4cf33-c1bb-49f7-bd78-e0139c26329d"), "APCDevice_1", 1 });

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
                values: new object[] { new Guid("000eef62-74a0-41bf-ae86-d6d2d757afbd"), "client1", "", "", "CutO2BlowoutBreak", "Break Preflow", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0db6a864-02ee-443b-af45-df4b8a164167"), "client1", "", "", "SlagCuttingSpeedReduction", "Slag Cutting Speed Reduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("10619308-db63-45d4-a490-7821aa81df32"), "default", "", "", "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("18c66cbb-8274-41bc-976f-a236723b94e9"), "client1", "", "", "CutO2BlowOutTime", "PreFlow Time", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1ddafcc6-2c3f-4bdb-8eb5-85b434ed9d93"), "client1", "", "", "HeightPierce", "Piercing with Height Control", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("220b749b-1b3c-46b9-952f-8dfb27e359e4"), "default", "", "", "LinearDrivePosition", "Position", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("24c7f58f-cfb4-4bdb-8254-a8820fcf7342"), "default", "", "", "CutO2Blowout", "Start Preflow", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2a51ae39-1191-4861-b26f-ea93bc66db05"), "default", "Preflow active", "", "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2b36698b-c5bd-4bb3-bed1-847334cc70bf"), "default", "", "", "CutO2BlowOutPressure", "PreFlow Pressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2f1e9425-a2d6-4424-9e0b-0073db63bc66"), "default", "Retract Position", "", "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("334d5d69-1188-457c-83ae-a87b185f81e0"), "client1", "", "", "PiercingDetection", "Piercing detection", 2, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("38570e3c-3323-4dee-ad7d-92d73bc0e015"), "default", "Retract Position enable", "", "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3b155c53-84e8-4223-8fd4-1d5b909b5197"), "default", "", "", "HeightPierce", "Piercing with Height Control", 1, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3e8c6962-d015-4e6a-9596-0aed6c3ec859"), "default", "Manual Height Calibration", "", "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("41f76fd6-8903-48e6-98ea-91e5231dfe41"), "default", "", "", "SlagPostTime", "Slag Post Time", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("449429eb-8514-4d3b-8c5c-04bd4e4f3409"), "client1", "Preflow active time", "", "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("46344d21-0a0e-4e50-b521-e06aefaa7873"), "client1", "", "", "SlagSensitivity", "Slag Sensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4d03839d-bafc-4b5b-b7c8-c47857afc39e"), "default", "Height Calibration Valid", "", "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("62b30c3c-bc25-41ac-9f85-091c11fcf869"), "client1", "Height Calibration Valid", "", "CalibrationValid", "IsCalibrationValid", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6f1929ab-826e-4f9f-b791-fb3efc552d44"), "default", "Height Calibration Active", "", "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7145f9c6-db72-4627-a76a-be72a92a666b"), "client1", "", "", "CutO2BlowOutPressure", "PreFlow Pressure", 6, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("76fe1552-8ae6-48ec-8e37-86d2422fa84c"), "client1", "", "", "CutO2BlowOutTimeOut", "PreFlow Timeout", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("78ddad54-cd2a-47c9-95ef-1bdff5463579"), "default", "", "", "SlagCuttingSpeedReduction", "Slag Cutting Speed Reduction", 3, "", "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8094597c-3d0f-4dda-a7bf-c68c917fd68a"), "client1", "Manual Height Calibration", "", "DistanceCalibration", "DistanceCalibration", 2, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8cbdc067-aa84-46e8-85f9-815d96201b0d"), "client1", "", "", "SlagPostTime", "Slag Post Time", 2, "", "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("934be894-b253-466a-9482-e4696713f210"), "client1", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("98107d21-ce75-46d0-87b8-5c59bb38d3cb"), "default", "Automatic Height Calibration", "", "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("988d50e4-da71-460e-b9c8-53d7f58c436b"), "default", "", "", "PiercingDetection", "Piercing detection", 2, "", "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a0156951-bc10-4c97-a482-195363adcc82"), "default", "Preflow active time", "", "CurrCutO2BlowoutTime", "CurrCutO2BlowoutTime", 4, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a2ab2311-bcda-4f11-90f1-e55499c77dc5"), "default", "", "", "SlagSensitivity", "Slag Sensitivity", 1, "", "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a2c19306-5d10-46df-b4eb-e36ba241a7c1"), "default", "Status Height Control", "{ 'Name':'Status Height Control', 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", "StatusHeightControl", "StatusHeightControl", 4, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a320c3e1-2298-445f-8ac0-3808bd3b620f"), "default", "", "", "CutO2BlowOutTime", "PreFlow Time", 5, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a688c3db-57e1-4c18-8bfd-f24df64af5e8"), "client1", "", "", "CutO2Blowout", "Start Preflow", 1, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a8e4493b-103f-4bc6-835f-befa2385ab90"), "client1", "Height Calibration Active", "", "CalibrationActive", "IsCalibrationActive", 5, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("af74d2da-8db6-41a2-8332-bad99f28c781"), "default", "", "", "CutO2BlowoutBreak", "Break Preflow", 2, "", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b3ed1735-7fe1-4c8d-9c3e-9d879a6f44c9"), "client1", "Position", "", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ba3acd74-d1ae-48e4-9bbc-e9f7ea736180"), "client1", "Retract Position", "", "RetractHeight", "RetractHeight", 1, "", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("bd4f9433-71d4-4e7e-b96e-5b912c67a136"), "default", "Position", "", "LinearDrivePosition", "LinearDrivePosition", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("be24d791-1cec-4017-9fc5-7da1d90b6ebc"), "client1", "Retract Position enable", "", "RetractPosAtProcessEnd", "IsRetractPosAtProcessEnd", 2, "SharedComponents.IhtData.DataCmdExecution", "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c25dd20d-5509-4086-a04c-9a7f2ca90d77"), "client1", "Preflow active", "", "CutO2BlowoutActive", "IsCutO2BlowoutActive", 3, "SharedComponents.IhtData.DataProcessInfo", "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cffc74db-3b62-478b-a7ec-73d9a907a4d2"), "client1", "", "", "LinearDrivePosition", "Position", 3, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d7b2c2eb-2e8e-4d6e-83de-709d66eae866"), "client1", "Height Control Active", "", "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d9926fde-7458-4623-aa0f-0f5e23fba8ae"), "client1", "", "", "Dynamic", "Dynamic", 1, "", "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e6e3bea5-b23d-4ad8-bddb-589e998747a4"), "default", "Height Control Active", "", "ClearanceCtrlOff", "IsHeightControlActive", 2, "SharedComponents.IhtData.DataProcessInfo", "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f72457be-aa05-4c37-af52-d4597f00ac16"), "default", "", "", "CutO2BlowOutTimeOut", "PreFlow Timeout", 7, "", "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "DisplayName", "Format", "ParamId", "ParamName", "ParamOrder", "ParamType", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ffc9f3df-8aea-4194-be45-3c5fc41ba9d9"), "client1", "Automatic Height Calibration", "", "TactileInitialPosFinding", "TactileInitialPosFinding", 1, "", "HeightCalibration", 0 });

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
                keyValue: new Guid("0e91a587-80cd-443b-9cc5-550987e021ae"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("1e82c7d0-bc74-45dc-977e-11c446e8d9c7"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("27bf2a81-83eb-487e-a331-b553c1734829"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("3d31b2b2-2a21-43f7-abc3-b748705d046c"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("4062d96e-8dcf-4e6a-bfd2-c31cefc6bd30"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("88b6b637-69ef-448a-80e2-dcd5a9ee5bec"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("9b99b32e-2ae1-4d4e-bad2-e5d7303d82a2"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b3703fd8-116a-42e3-80aa-e26c641d3ce5"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b45e6177-1c98-4067-96bf-8e193ef3af2b"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c3d4cf33-c1bb-49f7-bd78-e0139c26329d"));
        }
    }
}
