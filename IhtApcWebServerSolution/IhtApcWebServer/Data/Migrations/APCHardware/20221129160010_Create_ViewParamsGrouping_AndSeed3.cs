using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    public partial class Create_ViewParamsGrouping_AndSeed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("01406338-2398-4548-9101-c3c2cd3f2540"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("04e502b4-fa2f-40f3-aeca-f1070d98d35e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("0725e0fe-72d3-4663-bcbe-9e3924ed2290"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("4d3390ff-a8c5-43df-ae69-12455bf7ef2f"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5f26916e-fd7a-4b67-9b3d-ee406d63b41e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("89044ff4-8dec-4684-be7f-79091200be89"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b538dd00-79d5-4372-869b-f07fa4a9c307"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("de554c33-f016-46b0-8f61-7823668d63b7"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e61d8d0a-db1a-4d7d-b6c0-c329d6de4eda"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("ebaba5d0-6dd5-47ae-b449-6aa288d1ff2a"));

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
                values: new object[] { new Guid("0572e3db-896b-4be1-ad6a-a1ff1b5933b3"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("19144c05-333e-43c9-8a91-e2e2f2a6f12e"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("415f264c-f945-4516-93d6-45834fe8b968"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5c3ea349-360b-44d5-aab9-ebacb93aae66"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("618339f8-1388-4710-a232-298cc550417f"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("7f3c78af-1a4b-422b-9154-6193876898b1"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("bd0a2346-c831-4fe6-80f0-c8a9ee1348eb"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c12f911d-8ffe-4d2c-af22-47b7e3eae2a5"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("f24f7f79-84ad-4cc3-9055-868c57d84902"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("fe6d78b4-7dda-49f5-870c-0c647d4617bd"), "APCDevice_10", 10 });

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
                values: new object[] { new Guid("02254cf8-1c56-44c0-b5a9-0e3748adb885"), "default", "CutO2BlowOutPressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("063baf51-65c6-4d96-a312-9236cdc72bed"), "client1", "Off", 4, "HeightControl_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("06761a39-a77e-4c7c-a518-150557b26b4b"), "client1", "HeightPierce", 6, "HeightControl_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0b477875-de81-449e-829f-edb924f22e1a"), "client1", "HeightPierce", 1, "Piercing_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0cc968d4-ba01-43a6-b36c-c90270bcda4c"), "client1", "SlagPostTime", 2, "Slag_client1", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("10c0d854-8f51-430b-b6b6-ddda660942fd"), "client1", "CalibrationValid", 4, "HeightCalibration_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("117371e7-0b62-445f-b5d0-fa779107e1e3"), "default", "LinearDrivePosition", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("117804b8-b738-44b3-8b4f-1551045a6132"), "default", "CalibrationValid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("11a82885-4680-4fc2-9577-58e5ab1fef10"), "default", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("14af81fe-3240-40e7-82bc-9cd8b2878705"), "default", "DistanceCalibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1786f359-ff2c-4580-b3a4-6da57a112bd1"), "client1", "CutO2BlowOutTime", 5, "PreFlow_client1", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1da3ec73-1a5a-4a63-b64f-b0e8f37ecfea"), "default", "HeightPreHeat", 4, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1eb11fbf-05d0-4624-97b4-24acc488e97c"), "default", "PiercingDetection", 2, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("23a1b0b2-401e-43aa-8e0d-dbe34be07b2b"), "client1", "CalibrationActive", 5, "HeightCalibration_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("24280c20-00bb-46e5-af0b-3da60ae20bc1"), "client1", "SlagCuttingSpeedReduction", 3, "Slag_client1", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2697ed76-c2b4-49d6-896f-7ce64734b61b"), "client1", "RetractHeight", 1, "HeightCalibration_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("27717c11-aff2-4437-8d3c-a127b91d57ff"), "default", "CalibrationActive", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2dd92cd4-02bc-4315-9aa3-01e4368bb1bc"), "client1", "CutO2BlowOutPressure", 6, "PreFlow_client1", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("2f6a828d-f171-490c-8758-8f5e06db79f7"), "default", "CutO2BlowoutBreak", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("416b23bb-1adb-400a-bc95-9c9fa8c53e23"), "default", "CutO2Blowout", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("44ba350b-96a0-48ba-9a91-595dccf6954f"), "client1", "CurrCutO2BlowoutTime", 4, "PreFlow_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4b3a37cc-ad3a-4731-8826-4a9bf5437419"), "client1", "CutO2Blowout", 3, "PreFlow_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("558fa33c-d724-4a2b-8212-86c0f37cbe42"), "default", "HeightCut", 6, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5c96c2b8-8462-4932-b5a2-34b7e874cd54"), "default", "SlagCuttingSpeedReduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("5fae095b-0b7f-415d-948e-09fefb15c951"), "default", "CutO2BlowoutActive", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7258cc8a-bdea-4033-bb5d-63839b28f157"), "default", "SlagSensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("75748008-018e-426d-8b8a-2c026dc79ad0"), "client1", "HeightCut", 7, "HeightControl_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("76a0a83e-ef90-4014-b179-4dfdb67f0b85"), "default", "HeightPierce", 5, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("81724529-3da8-41b6-9c95-4ddfeb99e942"), "client1", "CutO2BlowOutTimeOut", 7, "PreFlow_client1", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8c6169b9-d955-46b8-b258-75e830f4e584"), "client1", "LinearDrivePosition", 3, "HeightCalibration_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9055bd4a-9394-4201-917c-37c16eb36755"), "client1", "CutO2BlowoutBreak", 2, "PreFlow_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9387aff9-751c-440b-abc0-dd6cb198312a"), "client1", "Dynamic", 1, "HeightControl_client1", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("968362d9-57ce-481b-a18c-7cc7314efa80"), "default", "CutO2BlowOutTimeOut", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9a480e74-9fda-4b86-8be5-88989b439b75"), "client1", "HeightPreHeat", 5, "HeightControl_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a81075c1-26c1-43e9-b6ac-6aac327e84f6"), "default", "RetractPosAtProcessEnd", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a87a53ce-872c-4358-bacd-7d33e1842bf0"), "default", "CutO2BlowOutTime", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ae00399e-3a08-405d-9ded-5aff2bc7a076"), "client1", "CutO2BlowoutActive", 1, "PreFlow_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b00afc5d-857c-4af8-80f9-2eae26fbb622"), "client1", "TactileInitialPosFinding", 1, "RetractPosition_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c45ee6e8-f110-416d-b879-cbcbe7c60909"), "default", "ClearanceCtrlOff", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c4bc70ec-86b8-4418-9402-691e22676276"), "default", "SlagPostTime", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c872b435-bd93-42f2-93f1-8c1739d1a289"), "default", "TactileInitialPosFinding", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ca1fc0d8-1115-409b-b684-67a912f545c4"), "client1", "DistanceCalibration", 2, "HeightCalibration_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d7420414-2542-482f-9838-27d01dc147a8"), "client1", "RetractPosAtProcessEnd", 2, "RetractPosition_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("d9b1c00f-3761-45f9-9e33-573edca6a4b3"), "default", "RetractHeight", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("db3505d7-8aa4-4676-9350-c73df6b9a711"), "default", "HeightPierce", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("df177e54-5952-456b-9f34-6076c1d8f897"), "default", "Off", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e0c6eb11-c3da-4e18-81a4-66535f6d5539"), "default", "CurrCutO2BlowoutTime", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f12a0fa3-6247-4c92-b840-844a0bde8c52"), "client1", "ClearanceCtrlOff", 2, "HeightControl_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f1bbc391-a3cb-4882-adcf-14b114658778"), "client1", "LinearDrivePosition", 3, "HeightCalibration_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fdca6f47-14d5-466f-99e0-6a47dcb799aa"), "client1", "PiercingDetection", 2, "Piercing_client1", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ff8ad0e0-b11c-411c-a227-436b152f9387"), "client1", "SlagSensitivity", 1, "Slag_client1", 0 });

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
                keyValue: new Guid("0572e3db-896b-4be1-ad6a-a1ff1b5933b3"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("19144c05-333e-43c9-8a91-e2e2f2a6f12e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("415f264c-f945-4516-93d6-45834fe8b968"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5c3ea349-360b-44d5-aab9-ebacb93aae66"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("618339f8-1388-4710-a232-298cc550417f"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("7f3c78af-1a4b-422b-9154-6193876898b1"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("bd0a2346-c831-4fe6-80f0-c8a9ee1348eb"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c12f911d-8ffe-4d2c-af22-47b7e3eae2a5"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("f24f7f79-84ad-4cc3-9055-868c57d84902"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("fe6d78b4-7dda-49f5-870c-0c647d4617bd"));

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("01406338-2398-4548-9101-c3c2cd3f2540"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("04e502b4-fa2f-40f3-aeca-f1070d98d35e"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("0725e0fe-72d3-4663-bcbe-9e3924ed2290"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("4d3390ff-a8c5-43df-ae69-12455bf7ef2f"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5f26916e-fd7a-4b67-9b3d-ee406d63b41e"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("89044ff4-8dec-4684-be7f-79091200be89"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b538dd00-79d5-4372-869b-f07fa4a9c307"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("de554c33-f016-46b0-8f61-7823668d63b7"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e61d8d0a-db1a-4d7d-b6c0-c329d6de4eda"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ebaba5d0-6dd5-47ae-b449-6aa288d1ff2a"), "APCDevice_1", 1 });
        }
    }
}
