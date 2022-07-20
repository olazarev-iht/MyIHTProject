using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardwareMock
{
    public partial class Create_Schema_AndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APCDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Num = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APCDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Min = table.Column<int>(type: "INTEGER", nullable: false),
                    Max = table.Column<int>(type: "INTEGER", nullable: false),
                    Step = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConstParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynParams_ConstParams_ConstParamsId",
                        column: x => x.ConstParamsId,
                        principalTable: "ConstParams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParameterDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamName = table.Column<string>(type: "TEXT", nullable: false),
                    APCDeviceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    DynParamsId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterDatas_APCDevices_APCDeviceId",
                        column: x => x.APCDeviceId,
                        principalTable: "APCDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterDatas_DynParams_DynParamsId",
                        column: x => x.DynParamsId,
                        principalTable: "DynParams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("03e9f638-349f-44f5-a588-0fbe73aa0150"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0c1ed86a-d804-4090-bbad-ceab2a9bf0b9"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0d1e055a-ff3b-4fa8-972d-e642de99f46f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("0d962aaa-28c7-4d99-b007-c1362a8ca2c0"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1dc3b7af-4055-4d62-b2fb-ca4ff12e3a82"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2054f92f-2c55-443e-92cd-b64608e9c09f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("43523308-5b49-4b80-837a-c23184c95b40"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("47a566a9-da0b-45ae-84fd-37a366bc7614"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4d741698-c3b0-4a4f-adf1-46ef21db08c3"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4e5e0a23-55a5-43c4-a129-fe9657f80336"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("504e5797-efcc-4a55-b51a-36220fd11508"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("552a21be-2661-47bb-9a55-8e30247d8b9e"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("563bafc1-a50b-441b-a9ad-3247a8d1ce5d"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("62bd0fb7-6e76-4481-a87b-ea1aea0af720"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("62c56d64-b145-46ee-8b46-5f6df3d58e69"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("69f918b6-065a-45c2-839d-c5c447c03ad3"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6dcdfbbe-e354-4a3b-881c-cfa7505c324b"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("72413078-9783-419f-9516-9f1ff6886cdb"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7e4cc05b-ba84-4be5-84a0-0b9ca55efcdc"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("90c880c2-f07a-43e4-8eff-87bd9d628834"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("94d8bfed-98ff-41ee-804c-49d39d9ca3db"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("984f827a-e820-48c2-9a4a-6583a51aceaa"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9cb1ec54-5dc9-4a4c-8487-26cbbaa407b6"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a0074996-c3c5-45c6-a7c8-4b0e22e39f27"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a469fe05-3639-4ece-bab0-ebb176458efa"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a8f750f1-d448-4ee0-a058-19b4d0fbf84a"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("abe3b509-71c8-4874-9b0f-9f6c325bf2e9"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cd8373c1-6eb6-4d0a-89de-c37615daca66"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d3f8405b-8141-42b9-97c2-76bf3c671e32"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("da1e9240-a838-4963-a213-7600a2d76de9"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ddde57ea-71d4-40ec-929c-c50d40d5fc08"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e03fdc3c-89db-433d-a465-93cca0e72748"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f7615931-8fcb-4557-bc56-0625c46e83d8"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0216d19a-7de1-45a7-8959-9566ff0a9618"), new Guid("abe3b509-71c8-4874-9b0f-9f6c325bf2e9"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("030d27ef-3c5a-42fe-b4d3-f127300d2c0b"), new Guid("d3f8405b-8141-42b9-97c2-76bf3c671e32"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0d817c2d-c4c3-4f42-a55e-dae0683c56e2"), new Guid("4d741698-c3b0-4a4f-adf1-46ef21db08c3"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0eb4ede2-ca7c-445f-9372-a7630c4e59c8"), new Guid("552a21be-2661-47bb-9a55-8e30247d8b9e"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0f3ce576-aa76-4980-b5e9-5116dcefd2f7"), new Guid("69f918b6-065a-45c2-839d-c5c447c03ad3"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("233f998a-5633-4e6f-9609-fdeb26d4ae6f"), new Guid("0d962aaa-28c7-4d99-b007-c1362a8ca2c0"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("29508dea-0197-4858-82b2-c8e436432d56"), new Guid("4e5e0a23-55a5-43c4-a129-fe9657f80336"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("35d690c7-9be7-42fd-bba7-5d383d733776"), new Guid("e03fdc3c-89db-433d-a465-93cca0e72748"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3658048c-6857-42bc-85e1-dadc2d933071"), new Guid("2054f92f-2c55-443e-92cd-b64608e9c09f"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("37bbee94-23d9-459a-896f-215b3deb2097"), new Guid("90c880c2-f07a-43e4-8eff-87bd9d628834"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("432c000f-dfe3-480b-b608-ae3141c0bf56"), new Guid("a8f750f1-d448-4ee0-a058-19b4d0fbf84a"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("43675b2c-e557-4cfa-b9f4-a657d2d6b6d6"), new Guid("a0074996-c3c5-45c6-a7c8-4b0e22e39f27"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("482d3367-ed3d-481d-bf74-e0fc3914653b"), new Guid("da1e9240-a838-4963-a213-7600a2d76de9"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4e1dc348-2239-4edd-a4c5-a65789fc01cd"), new Guid("43523308-5b49-4b80-837a-c23184c95b40"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5ee48f34-3072-4bdc-9131-24aa427d3ab8"), new Guid("a469fe05-3639-4ece-bab0-ebb176458efa"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("653a5a6f-4fa9-445b-af36-07c9101035b2"), new Guid("563bafc1-a50b-441b-a9ad-3247a8d1ce5d"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6725c5d9-480b-4a29-8fe9-b330b88e319c"), new Guid("7e4cc05b-ba84-4be5-84a0-0b9ca55efcdc"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6a0c77af-1b20-4d46-a8a1-dca3a9056749"), new Guid("72413078-9783-419f-9516-9f1ff6886cdb"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("81123ad4-ef60-46fb-8e26-ab37097e96a0"), new Guid("cd8373c1-6eb6-4d0a-89de-c37615daca66"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8e2b2533-5980-4306-bdac-4f4229d5c661"), new Guid("9cb1ec54-5dc9-4a4c-8487-26cbbaa407b6"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("94213c91-bf1f-4e5e-80f4-9e5b56bf4e59"), new Guid("f7615931-8fcb-4557-bc56-0625c46e83d8"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a287551b-651d-4f7f-b906-6fce27be935f"), new Guid("6dcdfbbe-e354-4a3b-881c-cfa7505c324b"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("be331c0b-3abd-4665-bc0c-13c2af6f9388"), new Guid("504e5797-efcc-4a55-b51a-36220fd11508"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c68d26f8-a4de-434c-808d-4a68fff15e2a"), new Guid("62bd0fb7-6e76-4481-a87b-ea1aea0af720"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c8fadc4d-fae5-4f4e-a4cd-13bae35e91c6"), new Guid("0c1ed86a-d804-4090-bbad-ceab2a9bf0b9"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d0183358-6cae-48c6-96ad-a7d77f70b737"), new Guid("47a566a9-da0b-45ae-84fd-37a366bc7614"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d50ae695-893b-4f78-999d-48de0a0ccf9d"), new Guid("62c56d64-b145-46ee-8b46-5f6df3d58e69"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e04948ea-6627-4c9c-af51-b8a039353649"), new Guid("1dc3b7af-4055-4d62-b2fb-ca4ff12e3a82"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e41779da-3890-415d-b712-2cafe048fe66"), new Guid("984f827a-e820-48c2-9a4a-6583a51aceaa"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e7876a08-2e26-48e5-ac74-9a92eca20f0b"), new Guid("0d1e055a-ff3b-4fa8-972d-e642de99f46f"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("ed38c685-0858-419a-aa12-e7d2521fa7cc"), new Guid("03e9f638-349f-44f5-a588-0fbe73aa0150"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fb28dd63-6913-4e5e-a5bf-17e6900efa6e"), new Guid("94d8bfed-98ff-41ee-804c-49d39d9ca3db"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fb2d0622-75f6-4333-b211-e438f01bc2a7"), new Guid("ddde57ea-71d4-40ec-929c-c50d40d5fc08"), 11, 200 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0d665550-a1b7-468e-9742-88c6d6a2a59a"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("d0183358-6cae-48c6-96ad-a7d77f70b737"), 1, "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("29d306b1-cf04-46ad-b071-357ae7091afa"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("3658048c-6857-42bc-85e1-dadc2d933071"), 1, "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("31d35e8b-b7e2-45fa-a3eb-335c23b9ee0b"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("e04948ea-6627-4c9c-af51-b8a039353649"), 1, "Device1_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3ae808a1-2227-4742-b410-938ff49e32dc"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("35d690c7-9be7-42fd-bba7-5d383d733776"), 1, "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3bbfe3a2-d504-4df4-a265-9e85c81cfdb9"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("fb28dd63-6913-4e5e-a5bf-17e6900efa6e"), 1, "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3c5bd048-a269-4072-86a5-f072a8d126e8"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("43675b2c-e557-4cfa-b9f4-a657d2d6b6d6"), 1, "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("51277f9f-6843-42a4-8f63-cb83c251abde"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("e7876a08-2e26-48e5-ac74-9a92eca20f0b"), 1, "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5247dfcd-179c-4517-a53c-4e509189d154"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("a287551b-651d-4f7f-b906-6fce27be935f"), 1, "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5411e8d8-a7b5-4500-bc1c-fcdeca5b3a86"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("6725c5d9-480b-4a29-8fe9-b330b88e319c"), 1, "Device3_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("54b1b6ab-cec0-4e50-a7ba-c0e895e4b61a"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("0eb4ede2-ca7c-445f-9372-a7630c4e59c8"), 1, "Device1_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5ef71c84-dda4-4a40-a05d-406035729cf9"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("482d3367-ed3d-481d-bf74-e0fc3914653b"), 1, "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6b8d7efc-53f4-416c-93d6-e274a0531283"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("0216d19a-7de1-45a7-8959-9566ff0a9618"), 1, "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6c5cac17-6964-4b0b-a0bf-18322f2b3041"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("29508dea-0197-4858-82b2-c8e436432d56"), 1, "Device3_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("74cf10a6-ec2c-499d-b944-dde339d09879"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("37bbee94-23d9-459a-896f-215b3deb2097"), 1, "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("76d84c5b-fc9b-45a4-b6f5-441223ba4394"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("653a5a6f-4fa9-445b-af36-07c9101035b2"), 1, "Device2_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("822ff9d8-c95d-42ff-8cc5-183527335353"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("e41779da-3890-415d-b712-2cafe048fe66"), 1, "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8f2012ac-656b-49af-bb94-810ec222c297"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("4e1dc348-2239-4edd-a4c5-a65789fc01cd"), 1, "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9f54fd82-efe7-4376-94c8-dff6cf598143"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("432c000f-dfe3-480b-b608-ae3141c0bf56"), 1, "Device2_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a1b94e5b-a2f6-4f9d-82f2-6b740a3e2820"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("8e2b2533-5980-4306-bdac-4f4229d5c661"), 1, "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("bdd5b5b4-a09b-4167-8226-c80f2013ff33"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("d50ae695-893b-4f78-999d-48de0a0ccf9d"), 1, "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c0cb5040-ee58-44f9-abe2-de6c89a7cfb7"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("fb2d0622-75f6-4333-b211-e438f01bc2a7"), 1, "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c1a98c4b-1755-433b-85c3-51153a737283"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("94213c91-bf1f-4e5e-80f4-9e5b56bf4e59"), 1, "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c24bc3de-29ba-4d88-b3e3-3583a7fdc134"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("030d27ef-3c5a-42fe-b4d3-f127300d2c0b"), 1, "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cd0c372e-8fa4-499e-b9f3-04a0ff2a9e7d"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("0d817c2d-c4c3-4f42-a55e-dae0683c56e2"), 1, "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d2b9e2b0-fda2-4ed5-9868-f091ec7a3aae"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("0f3ce576-aa76-4980-b5e9-5116dcefd2f7"), 1, "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d52a1bd6-951a-44ba-899a-15d0a1c74da7"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("5ee48f34-3072-4bdc-9131-24aa427d3ab8"), 1, "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d98f4ea8-12d6-4131-8dfa-29cba56b9915"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("81123ad4-ef60-46fb-8e26-ab37097e96a0"), 1, "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("db777392-dcfa-4279-8f60-6b3e33c2fa3c"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("c8fadc4d-fae5-4f4e-a4cd-13bae35e91c6"), 1, "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e2b66348-6b7f-4ca7-b8b8-fc5630f15f06"), new Guid("5bc7d5fd-4635-47b1-b0d5-f51579cdccec"), new Guid("ed38c685-0858-419a-aa12-e7d2521fa7cc"), 1, "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e61c16ff-7ee7-4063-afbe-5130f9d1a384"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("233f998a-5633-4e6f-9609-fdeb26d4ae6f"), 1, "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e8e23abb-8cbd-487e-a781-e0465265562b"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("6a0c77af-1b20-4d46-a8a1-dca3a9056749"), 1, "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ff210a5e-6c6b-46bf-9e5d-ecf1d269b1c5"), new Guid("117db698-fbe1-4cdf-98d1-26f66f783683"), new Guid("be331c0b-3abd-4665-bc0c-13c2af6f9388"), 1, "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ff7e51a7-cbc5-4eb7-a168-754e6199aad9"), new Guid("7e1d54b4-2474-4cd3-8950-1e1536355e6c"), new Guid("c68d26f8-a4de-434c-808d-4a68fff15e2a"), 1, "Device2_HeatO2PreHeat" });

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ConstParamsId",
                table: "DynParams",
                column: "ConstParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDatas_APCDeviceId",
                table: "ParameterDatas",
                column: "APCDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDatas_DynParamsId",
                table: "ParameterDatas",
                column: "DynParamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiveParams");

            migrationBuilder.DropTable(
                name: "ParameterDatas");

            migrationBuilder.DropTable(
                name: "APCDevices");

            migrationBuilder.DropTable(
                name: "DynParams");

            migrationBuilder.DropTable(
                name: "ConstParams");
        }
    }
}
