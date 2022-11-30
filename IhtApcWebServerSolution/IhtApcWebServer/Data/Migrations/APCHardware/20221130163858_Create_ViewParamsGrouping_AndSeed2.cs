using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    public partial class Create_ViewParamsGrouping_AndSeed2 : Migration
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
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
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
                values: new object[] { new Guid("29cd85aa-c94d-44b3-ad78-41d3615fe092"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("2ae7e626-1575-4c87-8e0d-2d5434da0687"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("740504cd-bb12-49ac-aab1-4f0703663958"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("97f891c3-c4ea-4f05-b334-e4309c8f02b3"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c0a3cc50-c28d-4548-ad16-d88b632722f2"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c22a835a-3dba-4ba5-ae52-e9ef27548c0c"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("c496f802-defb-4603-9837-6c25ede93d30"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("cd96bdb6-a49c-41d6-9d3e-75e7c6ffc32d"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("dc6b6981-4a33-4518-8c7a-8dced1a1b527"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("f8ac0435-1338-4e10-9b1f-ce7a0d3068ee"), "APCDevice_7", 7 });

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
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("03063d5f-c92b-4556-8783-19aa85c7ed01"), "default", "HeightPierce", "Piercing with Height Control", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("035aaed8-d15a-4e26-9344-8dd1e9fb3c1b"), "client1", "TactileInitialPosFinding", "Automatic Height Calibration", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("06b24411-1563-451d-82ba-71eec4e812ea"), "default", "CutO2Blowout", "Start Preflow", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("08300fc0-cad4-4d17-99f5-de5e1c504a1d"), "default", "LinearDrivePosition", "Position", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("09f8881a-c38a-4c24-b016-64e15d31484f"), "default", "ClearanceCtrlOff", "Height Control Active", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("0b30661f-2ba8-4207-a4c5-d6d397200886"), "client1", "LinearDrivePosition", "Position", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("10d63731-3f9b-47f6-962b-e256a39e9588"), "default", "RetractHeight", "Retract Position", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("12f02e2a-13a5-42cd-a96b-92bc0e5d1d5f"), "client1", "CutO2BlowOutTimeOut", "PreFlow Timeout", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("13c79f1d-9a6b-4ecc-9a74-a1ca61141a97"), "client1", "CutO2BlowOutPressure", "PreFlow Pressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("1f9aae96-7c03-401d-8d06-c696f74cd5b7"), "client1", "CurrCutO2BlowoutTime", "Preflow active time", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("24951852-7db6-405f-9e60-7d6f99f560f1"), "client1", "SlagSensitivity", "Slag Sensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("26d65d9c-35b5-401f-a827-bb179eea57d1"), "client1", "CutO2Blowout", "Start Preflow", 1, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("29bf0b2a-784d-4459-91c7-61643e16620c"), "default", "CutO2BlowOutTime", "PreFlow Time", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3f5ea5ef-9942-440f-a025-6ce87e0a88be"), "client1", "CalibrationActive", "Height Calibration Active", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("3fca3b41-4110-4635-8472-22d764d3a8a4"), "default", "CalibrationValid", "Height Calibration Valid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("481866da-39b6-44b6-86a2-eba5dbd67a7b"), "client1", "HeightPierce", "Piercing", 6, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("4c1a6e1b-9ae8-4d65-8ef0-ff17d503f58d"), "default", "RetractPosAtProcessEnd", "Retract Position Enable", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("57584ddd-57ee-4c67-92ab-821f58bdf9e1"), "default", "CutO2BlowOutPressure", "PreFlow Pressure", 6, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("579445b8-5132-4e8e-87dc-80e36c424fe0"), "default", "CutO2BlowOutTimeOut", "PreFlow Timeout", 7, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("663f9a7d-1d20-4852-910b-63e265070731"), "client1", "CalibrationValid", "Height Calibration Valid", 4, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("6784375a-c4c0-4378-b7dd-4bc51faba4b5"), "default", "TactileInitialPosFinding", "Automatic Height Calibration", 1, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("77fd5e16-26ba-41b3-984b-77a2f19316ad"), "client1", "ClearanceCtrlOff", "Height Control Active", 2, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("7a51f64b-66d3-4dfe-98a3-811042c60a80"), "client1", "LinearDrivePosition", "Position", 3, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("81b8f4cc-b234-47f6-ab97-b0a2275713f2"), "default", "CutO2BlowoutBreak", "Break Preflow", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("85059407-2db9-425b-b81b-73d44a4ee0b4"), "default", "SlagCuttingSpeedReduction", "Slag Cutting Speed Reduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8dd8a7c6-755a-46ab-890d-5a185fcf6af9"), "client1", "PiercingDetection", "Piercing detection", 2, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("8ddfe0c7-b4be-4646-8a24-8fee7ea56852"), "default", "CutO2BlowoutActive", "Preflow active", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("90fc142a-a2b2-43e2-9f9f-bec27560bcf0"), "default", "HeightCut", "Cutting", 7, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("933d23e6-21a2-4fdd-9898-467fa491879f"), "client1", "SlagCuttingSpeedReduction", "Slag Cutting Speed Reduction", 3, "Slag", 2 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("95055160-cb86-4fc4-9f93-f3e71e40cfbe"), "client1", "HeightPreHeat", "Preheating", 5, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9692e2a6-a027-4a33-bece-71307283d762"), "default", "HeightPierce", "Piercing", 6, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9a218e58-7134-4301-b217-d68cd4e42554"), "client1", "Dynamic", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9b982a83-6a1f-4702-990d-47bdb641c8c3"), "client1", "CutO2BlowoutBreak", "Break Preflow", 2, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("9dd468bf-90c3-4ebb-a8a2-84245106a9a6"), "default", "SlagPostTime", "Slag Post Time", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a025322e-ca13-4c82-a2e6-5938f6fd53f6"), "client1", "CutO2BlowoutActive", "Preflow active", 3, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a24bbd3c-c235-4893-bf8f-6c78924cab2a"), "default", "LinearDrivePosition", "Position", 3, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a2ef24e9-2901-4bbb-95a2-c4544ae914fd"), "default", "Off", "Off", 4, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a4820e8b-9d10-4611-92b3-201170d86c29"), "client1", "SlagPostTime", "Slag Post Time", 2, "Slag", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a6003575-9178-4ab9-9e4b-9e7d1aea050e"), "default", "CurrCutO2BlowoutTime", "Preflow active time", 4, "PreFlow", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("a6d21455-a576-42b0-a8a8-6457b49ecd16"), "client1", "HeightPierce", "Piercing with Height Control", 1, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("aa44396e-f588-4693-b2ac-496b38050ba2"), "client1", "RetractHeight", "Retract Position", 1, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("b3225e2d-fd79-4ef8-b770-bd95c0bf1c08"), "default", "CalibrationActive", "Height Calibration Active", 5, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ba3d2c34-2600-4466-8ba2-2ac39f663298"), "client1", "HeightCut", "Cutting", 7, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("bfbe294b-1f35-489e-8a3f-45745034bd30"), "client1", "CutO2BlowOutTime", "PreFlow Time", 5, "PreFlow", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c7cd06ed-266e-4a5c-bc1b-916ce63b822c"), "default", "PiercingDetection", "Piercing detection", 2, "Piercing", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("c8826180-77ea-452f-ab6b-5015bfdfc6fb"), "default", "SlagSensitivity", "Slag Sensitivity", 1, "Slag", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("cb0d1c09-7862-411a-af11-1b9ece29e9cc"), "client1", "RetractPosAtProcessEnd", "Retract Position Enable", 2, "RetractPosition", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("ce158e16-db35-445a-a494-7b6b186b5721"), "default", "HeightPreHeat", "Preheating", 5, "HeightControl", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("de7ac0aa-b451-4a0f-98fa-a1335eeaa3c5"), "default", "Dynamic", "Dynamic", 1, "HeightControl", 1 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("e02463f1-ad03-4ffe-94c8-9ec381809bdd"), "default", "DistanceCalibration", "Manual Height Calibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("f18cbdc5-b2ab-4671-8bc8-25a5eb129f46"), "client1", "DistanceCalibration", "Manual Height Calibration", 2, "HeightCalibration", 0 });

            migrationBuilder.InsertData(
                table: "ParamSettings",
                columns: new[] { "Id", "ClientId", "ParamId", "ParamName", "ParamOrder", "ParamViewGroupId", "PasswordLevel" },
                values: new object[] { new Guid("fa3ef184-1815-482f-8aa0-89169a33be84"), "client1", "Off", "Off", 4, "HeightControl", 0 });

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
                keyValue: new Guid("29cd85aa-c94d-44b3-ad78-41d3615fe092"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("2ae7e626-1575-4c87-8e0d-2d5434da0687"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("740504cd-bb12-49ac-aab1-4f0703663958"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("97f891c3-c4ea-4f05-b334-e4309c8f02b3"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c0a3cc50-c28d-4548-ad16-d88b632722f2"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c22a835a-3dba-4ba5-ae52-e9ef27548c0c"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("c496f802-defb-4603-9837-6c25ede93d30"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("cd96bdb6-a49c-41d6-9d3e-75e7c6ffc32d"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("dc6b6981-4a33-4518-8c7a-8dced1a1b527"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("f8ac0435-1338-4e10-9b1f-ce7a0d3068ee"));
        }
    }
}
