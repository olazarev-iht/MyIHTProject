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
                values: new object[] { new Guid("0653794a-605f-442d-806f-fd89a21e25de"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("22626995-b63b-4db1-9cf6-675d6e404ec4"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("2a1757ce-28f3-4e08-bd18-93d9655cde54"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("37ed50aa-1727-4452-a9ba-5010ffef7022"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("3d28fffe-75de-4c57-a0c7-6875bb5c194d"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("43705179-4ded-4e83-ab08-5b07f9be7d18"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("6bb6db92-1437-4589-88ec-732cfbf95d45"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c651eb10-d55d-4d57-b988-f46b08cac2b8"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ed4f3796-4014-4fda-9ec0-df7504211fb8"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("f50a2da8-ccb8-4c81-8b4f-50cdc77eca69"), "APCDevice_6", 6 });

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
                values: new object[] { new Guid("016acbc3-9815-4ee7-a3bf-b58cfe7401c0"), "default", "CurrCutO2BlowoutTime", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0906f877-9585-4c15-99a5-e303c9592237"), "default", "CutO2Blowout", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("41533e36-8086-428c-8a72-8f50bed16b2a"), "default", "LinearDrivePosition", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("42a0a4cd-2a9e-44b7-b0fb-728c6bad9cbd"), "default", "SlagPostTime", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4753ab56-0c52-4e01-81a1-1ffdd4182b14"), "default", "RetractHeight", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5048591c-45b1-4416-bc10-e347600d7f92"), "default", "CutO2BlowOutTimeOut", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("50a252be-f1a6-4ab0-9ed4-761b228fdaa7"), "default", "SlagCuttingSpeedReduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("567dd708-54fb-4b85-8033-24de14ddf987"), "default", "SlagSensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5d27decf-299f-4eeb-971f-e7501ec3d076"), "default", "CutO2BlowOutPressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("78a0b97d-4d10-49b5-8dac-b043b317049e"), "default", "RetractPosAtProcessEnd", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7e1f3074-1bf2-4bae-b647-b4c517d3bf42"), "default", "StatusHeightControl", 4, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7e5ff5b2-be04-4423-82bf-1fae6d8de0bf"), "default", "CutO2BlowOutTime", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8085b058-c035-44a7-b9b0-1223d37dcafb"), "default", "DistanceCalibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("82d16433-c6fd-422b-a883-f27c03fd9c21"), "default", "CutO2BlowoutBreak", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8faafff5-c347-4785-9d7f-e64e165ddc8b"), "default", "TactileInitialPosFinding", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("904fe0da-e749-4460-81c1-cc4ee515b9e5"), "default", "HeightControlActive", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9087461b-ddf6-41d4-a9cd-70e0c9778bb3"), "default", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b1000d57-8488-473b-aa00-c6ae6fcd4cf1"), "default", "PiercingSensorMode", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c5868d13-a3e4-4afc-b15c-d7d3cffb492e"), "default", "LinearDrivePosition", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c761a14c-d898-40d6-aefc-3af860d713c7"), "default", "CalibrationActive", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cadce021-4f0d-4a13-ab73-c80ae659ead3"), "default", "CalibrationValid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cb74206e-817d-41f8-8792-7ba864150bee"), "default", "CutO2BlowoutActive", 3, "PreFlow", 0 });

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
                keyValue: new Guid("0653794a-605f-442d-806f-fd89a21e25de"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("22626995-b63b-4db1-9cf6-675d6e404ec4"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("2a1757ce-28f3-4e08-bd18-93d9655cde54"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("37ed50aa-1727-4452-a9ba-5010ffef7022"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("3d28fffe-75de-4c57-a0c7-6875bb5c194d"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("43705179-4ded-4e83-ab08-5b07f9be7d18"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("6bb6db92-1437-4589-88ec-732cfbf95d45"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c651eb10-d55d-4d57-b988-f46b08cac2b8"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("ed4f3796-4014-4fda-9ec0-df7504211fb8"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("f50a2da8-ccb8-4c81-8b4f-50cdc77eca69"));
        }
    }
}
