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
                values: new object[] { new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("015f75e7-3239-4eec-b0e3-9866adab5923"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("080bb143-bf62-48c5-b58b-401df4d0775f"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("12e53b06-29bb-4148-a28b-722a7a8a1f7e"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("16a81554-1be4-45d3-9acc-241790c70b8b"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("174e5a26-4848-446f-a9e4-0b66828f4e64"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1777f3d7-c4a4-4075-bc1d-3ecbf37a3a8c"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1b1fe8f0-1b87-4333-a886-1ba1a1ed6d0c"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1d0c0caa-91db-4983-8874-7a95c9d319d1"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1dd37650-c51a-4db1-bafa-3ddd72ea90bb"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1f62a3e9-e4e3-43fc-b92e-a3e8e906ec74"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("1fd0c2b6-34ed-45f5-97c7-a6009bf06b37"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("24bb7f5f-a0a9-4b1d-93cc-57841e8848c9"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("27f084a7-17c7-4bb9-8864-a737159b1f02"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("2c7ec3c2-a14a-4128-874a-d3f84c6420e3"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("34465fc5-ea54-4d69-ac33-0a88920176be"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3632eba4-ad0c-402a-8bfa-6b9300c05923"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("36a7c20e-0017-4ecd-a7dc-df50ab3ce26c"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3763227d-7996-467c-bc33-4ecb0fba8273"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("39ed7daf-7c4f-4203-8665-5deac6017b5e"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3acf21b4-61d9-4d52-8262-5ecfe361f3f8"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("3f925a14-cfae-4698-948d-f5b5db7aebff"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4006d73e-28d3-4c83-b4b9-8252ef514199"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("446d93c7-7dbd-472e-b767-5b802a6320b4"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("47e35d0d-b19f-4427-9add-973094fadc27"), 5000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("486f7baf-b479-47b1-9856-c68787520aef"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4b298862-2502-44af-ab05-e800ec9b601a"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4b55ed46-bebf-4eb4-b6da-9fe6306cef43"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4d942299-0b94-4761-843c-64e0df523582"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("4f281854-0948-4ddc-a7b9-53ee7588e519"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5854dce6-1915-4aba-8cc1-115f349ec331"), 240, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5942809e-75aa-4d26-a2f4-a2fbcfa1b37f"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5a5cd164-0bbb-4b55-b44e-edaade1b951f"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("5e165c66-c617-47d2-a82b-e46482e02033"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("64f1d1bd-e207-4ad6-9cb1-6cb94dcaf2e8"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("682ee4e2-113c-4bdd-b4a6-ad13ce1921c5"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("696b21bc-ae00-4d72-8903-d0a6b81b29c7"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("69c23f15-209f-449e-b349-c5c5dfc827b4"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("69fb627c-ac6a-49de-bf2e-c1a1bfbbd19b"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6dc43775-c0f4-474e-831a-db80dee79e93"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("6df1f8ff-6b31-4054-a41c-a08b2c44dd75"), 30, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("700e7410-0595-4626-bf83-e239cb7fd41c"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7894cf26-3341-4b07-b126-af626802e49b"), 30, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7950708d-ddce-4343-81c0-4d7128253d8d"), 500, 0, 25 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7d660dae-ce10-4fc7-992c-ff810043169c"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("7f301150-78f3-41c3-ad4d-ca2103e5d537"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("816ea79f-7a2f-494a-afb8-e629c75c691c"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("83d655ab-0085-4676-ada2-4b81ae88bd5c"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("852628cf-c976-419c-a1d7-b523562f4a53"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("87765229-6fd0-410b-a403-412196a43c41"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8b6294c0-9404-432f-a5ff-4c6368ba435c"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8d2c0504-e1a1-4e52-901d-2e431896a580"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8eff1e6f-a0f1-4520-a223-cc6f4e1d98ba"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("8f1f0b6d-cd1f-489a-b9c5-c921e726a130"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("92e9e4cd-7d7f-40ee-8734-178cd695ad6e"), 3, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("95cedf93-7fd2-4659-b414-ae5c817c41ad"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("95d4869c-253c-49b6-89e5-65bc6c67a07a"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9b5e4c10-22b2-4dfa-8013-185e11798041"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("9d837030-c7a6-45c6-a974-070c0dc3ddd3"), 240, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a25e6991-ec04-44e6-b8d4-2548fe6b93e4"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a4b9c51a-e42c-4c16-8fe9-5ceaec2edf04"), 1000, 200, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("a5c15526-ffa9-4bc5-bf96-5ecf010518e8"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("aa174572-8d49-49be-af2a-8d8c11ec4de5"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ac7ed64c-020b-478c-b768-8f522f89e833"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ae2345cb-6df0-4349-a8f7-400b80f9de93"), 5000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("aeb1da64-348c-401c-8948-cbd8fb6e9b7c"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b7547fc2-8b7c-4d0f-948b-54508190c261"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("b759ba69-b9c1-4d47-a96e-be0f5a2f0f91"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bbbc5517-2b59-4661-b413-31cd8200c7fd"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("bd82786a-d1a1-4334-ad75-1f85a6b256ea"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("be8131bb-50a0-40d5-9250-db05561defba"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c14eadcf-d207-4ccf-95e4-d899666003e6"), 30, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c2f7f590-9383-44df-8b3d-0b724215acfb"), 5000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c6506f37-bb65-473c-a967-bf8ea7bba27a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("c8565beb-1982-4885-b6fc-e857fa7cf776"), 100, 10, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("cc9de870-abe2-4987-853f-d80b69a3f6e1"), 100, 50, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ce4e32fd-85a1-468c-8c9a-df0696fd6339"), 240, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d2eddf49-df49-4126-8b94-b3f63f39cbab"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d2fe8361-b48d-4d49-8be6-90b072eb1656"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d40eb744-1cfe-4271-ba71-ac084d72f4d1"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d5dfb622-0e5b-4187-8007-bfaba1b7ef9c"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d74b919d-1164-496c-9cae-e96a8814e331"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d89b9a2c-8cc5-42f8-89da-d47961cf6c6a"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("d8deeaed-9779-4ba9-bde2-4975182ebb37"), 5000, 500, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("da1cabab-a4eb-4db8-9dba-6ba7245f44a0"), 100, 0, 5 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e1cb3734-dc87-4840-b424-7e45a2f625a1"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e1d1d091-3454-46a8-ae2e-3dd1c34243fc"), 1000, 0, 10 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("e7ad2afb-b84b-430f-af7e-9497bd180233"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("ee03b543-e4d1-4107-8d83-fc2eebdb400e"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("eef6f09f-33c6-430d-a047-4ec40e9b55d0"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("efe2193d-bc0e-43c0-84ed-0cc6354028a1"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f12b060f-42c0-4866-8d0e-636b8a1f5500"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("f75d0462-e974-45bf-a7bd-61e014e145b5"), 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "Max", "Min", "Step" },
                values: new object[] { new Guid("fe49b8d1-b065-46e4-a56a-c0e1464f9bc7"), 100, 0, 10 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("00cbf28c-da5e-416e-94be-7b9e4b660e33"), new Guid("bbbc5517-2b59-4661-b413-31cd8200c7fd"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("038c26b9-1a32-4a63-b85d-08894fd57763"), new Guid("aeb1da64-348c-401c-8948-cbd8fb6e9b7c"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("056e309e-27e5-4f61-bffb-7a60233b72ec"), new Guid("1d0c0caa-91db-4983-8874-7a95c9d319d1"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0801686f-4470-4860-ad17-f4d41a82b175"), new Guid("4d942299-0b94-4761-843c-64e0df523582"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0a1cab80-57ba-432a-a54f-6f18c3efed4d"), new Guid("b7547fc2-8b7c-4d0f-948b-54508190c261"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0aa7a444-6ad4-42b1-8f5e-bf91d9d95d94"), new Guid("8f1f0b6d-cd1f-489a-b9c5-c921e726a130"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0c64afd0-9ff5-4a8d-85b2-70c93ff1f0ba"), new Guid("015f75e7-3239-4eec-b0e3-9866adab5923"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("0ce20c56-7ce6-4c36-a0c5-a8517300bb42"), new Guid("e7ad2afb-b84b-430f-af7e-9497bd180233"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("106620dd-05bd-4ed7-82e7-4100060fc324"), new Guid("a5c15526-ffa9-4bc5-bf96-5ecf010518e8"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("15e7e2cb-1bc1-4903-8ffc-d9c9dfe56169"), new Guid("6df1f8ff-6b31-4054-a41c-a08b2c44dd75"), 11, 5 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("20e8d7e3-bab1-4b5d-b8c0-6bc2ea8f8b5d"), new Guid("d8deeaed-9779-4ba9-bde2-4975182ebb37"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("216c6b17-1f13-4fc1-9b76-4eda70ebec7a"), new Guid("3acf21b4-61d9-4d52-8262-5ecfe361f3f8"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("2dd1cfba-c7ef-4039-b827-4629e1ddcdd1"), new Guid("8d2c0504-e1a1-4e52-901d-2e431896a580"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("344dce43-e4b1-478c-8f9c-e15322a2e34f"), new Guid("1fd0c2b6-34ed-45f5-97c7-a6009bf06b37"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("35728bfe-29f1-43f7-a093-1ee0fcc11624"), new Guid("d2fe8361-b48d-4d49-8be6-90b072eb1656"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("384d4064-9fce-4b42-9829-cb38d66055a6"), new Guid("69fb627c-ac6a-49de-bf2e-c1a1bfbbd19b"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("399b3712-5f46-4eca-a926-b549b971de15"), new Guid("92e9e4cd-7d7f-40ee-8734-178cd695ad6e"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3ca3b7c8-3c48-4f72-8506-05a60bda5baa"), new Guid("3763227d-7996-467c-bc33-4ecb0fba8273"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("3e8ac099-c324-4398-87cc-2e8e404a821c"), new Guid("e1d1d091-3454-46a8-ae2e-3dd1c34243fc"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("40d8b3eb-d6fa-4676-a0e9-b82cf08c3708"), new Guid("c8565beb-1982-4885-b6fc-e857fa7cf776"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4678a731-2caa-45de-8469-5bfbf2e60dfc"), new Guid("f75d0462-e974-45bf-a7bd-61e014e145b5"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4a3593b2-49b7-4dc0-8673-769ebdb3a0e6"), new Guid("be8131bb-50a0-40d5-9250-db05561defba"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4a83438d-0355-4acb-95e0-a52b1dda7684"), new Guid("7950708d-ddce-4343-81c0-4d7128253d8d"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4c0c2b08-dcae-42e1-94c8-821b8a71b030"), new Guid("3f925a14-cfae-4698-948d-f5b5db7aebff"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4ce4662b-dfc5-4f42-91a7-7eb458a7994e"), new Guid("f12b060f-42c0-4866-8d0e-636b8a1f5500"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("4d10262a-1a35-4046-82e4-b918869ca029"), new Guid("486f7baf-b479-47b1-9856-c68787520aef"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("581ee744-e163-4a03-b42d-1938ac44b129"), new Guid("83d655ab-0085-4676-ada2-4b81ae88bd5c"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5953e909-4305-415f-a0ff-461db0522630"), new Guid("ce4e32fd-85a1-468c-8c9a-df0696fd6339"), 13, 240 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5b457625-53f4-4e8d-967c-ac4ed3de5e37"), new Guid("682ee4e2-113c-4bdd-b4a6-ad13ce1921c5"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5d125212-ca1e-42d2-8bf6-5e1001c5a43a"), new Guid("95cedf93-7fd2-4659-b414-ae5c817c41ad"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("5d64f737-602d-4623-8a5d-09224c9c2d41"), new Guid("bd82786a-d1a1-4334-ad75-1f85a6b256ea"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6848b99b-47e6-47d5-9605-f79c7eec65fb"), new Guid("a25e6991-ec04-44e6-b8d4-2548fe6b93e4"), 12, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6ae584c0-73f8-4f90-a6d2-d7d996b93e9d"), new Guid("efe2193d-bc0e-43c0-84ed-0cc6354028a1"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6b3c4726-f19f-49da-ae69-fcf4e7590592"), new Guid("4b55ed46-bebf-4eb4-b6da-9fe6306cef43"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6bd4650b-7baa-46a3-9dad-61f468c95a4c"), new Guid("5a5cd164-0bbb-4b55-b44e-edaade1b951f"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6e2557d9-d45a-42ef-a79a-84172af5ddb2"), new Guid("c14eadcf-d207-4ccf-95e4-d899666003e6"), 11, 5 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("6ecb2922-0b64-41cb-bb65-9e1cfdc89a51"), new Guid("696b21bc-ae00-4d72-8903-d0a6b81b29c7"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("7b57c945-dc24-49d9-accb-bf1009934711"), new Guid("eef6f09f-33c6-430d-a047-4ec40e9b55d0"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("7cb7cde4-5105-4c33-beae-616ec2fe9d16"), new Guid("174e5a26-4848-446f-a9e4-0b66828f4e64"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8049bd9e-0d8f-4449-9741-c0f5ede04873"), new Guid("d2eddf49-df49-4126-8b94-b3f63f39cbab"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("852089c5-f956-4c33-97d3-7366db88b97a"), new Guid("d40eb744-1cfe-4271-ba71-ac084d72f4d1"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("86ea5726-9321-4d5b-94c3-68d9441dccbe"), new Guid("ee03b543-e4d1-4107-8d83-fc2eebdb400e"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8862e680-9dea-476f-b59c-fa9b07261dad"), new Guid("1dd37650-c51a-4db1-bafa-3ddd72ea90bb"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("89520bc1-9fac-4828-a8ed-222fadf49231"), new Guid("4006d73e-28d3-4c83-b4b9-8252ef514199"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("8ba96993-9e34-432c-8365-dfbfe5721823"), new Guid("69c23f15-209f-449e-b349-c5c5dfc827b4"), 0, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("93832056-cf89-4a5e-8f04-d9c808c17bdf"), new Guid("5e165c66-c617-47d2-a82b-e46482e02033"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("960dd254-c969-4978-8098-1c50f43b1e8d"), new Guid("700e7410-0595-4626-bf83-e239cb7fd41c"), 6, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("967f8102-83a9-4a66-a33e-ffb47acc06e2"), new Guid("27f084a7-17c7-4bb9-8864-a737159b1f02"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("97d1e11e-992a-4769-904c-b17019ce207a"), new Guid("36a7c20e-0017-4ecd-a7dc-df50ab3ce26c"), 3, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9b99dbfe-9706-4c5a-bdb5-8906deb9cfef"), new Guid("64f1d1bd-e207-4ad6-9cb1-6cb94dcaf2e8"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9e59f070-03d0-4e71-bace-2d2855d1203f"), new Guid("852628cf-c976-419c-a1d7-b523562f4a53"), 8, 6000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("9e64a4f5-4a8e-48b6-9954-96d0e73fbba5"), new Guid("1777f3d7-c4a4-4075-bc1d-3ecbf37a3a8c"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a6c369b2-9389-45bd-b202-aa3713900ce3"), new Guid("da1cabab-a4eb-4db8-9dba-6ba7245f44a0"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("a7fcbe69-2c80-41ef-9483-516a6d7f5945"), new Guid("446d93c7-7dbd-472e-b767-5b802a6320b4"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("aa7ee897-78cc-487f-b2ee-400a7b7edaed"), new Guid("aa174572-8d49-49be-af2a-8d8c11ec4de5"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("adb3fad4-ff45-44f9-bd2a-222daa1c44d9"), new Guid("47e35d0d-b19f-4427-9add-973094fadc27"), 12, 2500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("af6ac1df-3cef-4511-84cc-db292be95105"), new Guid("7f301150-78f3-41c3-ad4d-ca2103e5d537"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b0843623-472b-4a73-ba3e-f13ba4b125dd"), new Guid("cc9de870-abe2-4987-853f-d80b69a3f6e1"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("b7d745da-be26-445c-a12f-65ee7c97a217"), new Guid("ae2345cb-6df0-4349-a8f7-400b80f9de93"), 12, 2500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bb198785-e768-4716-b042-3346fedaa4da"), new Guid("080bb143-bf62-48c5-b58b-401df4d0775f"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bb596e91-aba5-45f6-a0b6-b4eef1ff4dc6"), new Guid("87765229-6fd0-410b-a403-412196a43c41"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bbfea148-27ff-41ac-a810-818b4e03f197"), new Guid("24bb7f5f-a0a9-4b1d-93cc-57841e8848c9"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bd707f77-a5ce-4c41-9818-7cf96f0a183c"), new Guid("7894cf26-3341-4b07-b126-af626802e49b"), 11, 5 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("be523bb1-eb6e-4705-9aed-e8ed34b6f0c7"), new Guid("4f281854-0948-4ddc-a7b9-53ee7588e519"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("bfea08eb-42d1-4cc9-9bda-a3a55b447663"), new Guid("3632eba4-ad0c-402a-8bfa-6b9300c05923"), 4, 100 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c22833a7-cde1-4449-a601-b9f0a020c2aa"), new Guid("b759ba69-b9c1-4d47-a96e-be0f5a2f0f91"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c4f63195-5f1d-49d0-9b9b-c3b44355d342"), new Guid("34465fc5-ea54-4d69-ac33-0a88920176be"), 1, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c6345a23-a41c-4297-936a-657d2138cf28"), new Guid("12e53b06-29bb-4148-a28b-722a7a8a1f7e"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c6d5c88e-de52-49fe-9f4b-2f14df3e3e3d"), new Guid("1f62a3e9-e4e3-43fc-b92e-a3e8e906ec74"), 11, 20 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("c7bb3a40-3124-4c3b-967e-dcf4ada46357"), new Guid("7d660dae-ce10-4fc7-992c-ff810043169c"), 4, 35 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("cc80badf-5c13-4bfa-86a6-dadf46e7d12a"), new Guid("6dc43775-c0f4-474e-831a-db80dee79e93"), 10, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("cec42a4a-a3b4-4de9-9f38-ff6eae6a910f"), new Guid("39ed7daf-7c4f-4203-8665-5deac6017b5e"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d0876a85-cd25-423f-afe4-993397b80c2c"), new Guid("816ea79f-7a2f-494a-afb8-e629c75c691c"), 2, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d14df38a-1660-4419-bff7-645b34090207"), new Guid("a4b9c51a-e42c-4c16-8fe9-5ceaec2edf04"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d17f7b50-d4da-4e45-8a2f-639223063eaf"), new Guid("ac7ed64c-020b-478c-b768-8f522f89e833"), 4, 2000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d321bfcd-89ef-4a01-8b2d-3fe7fc5e5478"), new Guid("8eff1e6f-a0f1-4520-a223-cc6f4e1d98ba"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d3b1499c-f915-4164-ba07-28d0bdbeb88c"), new Guid("c6506f37-bb65-473c-a967-bf8ea7bba27a"), 8, 1 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d5b776a0-2035-4c57-9caa-b03db963635e"), new Guid("4b298862-2502-44af-ab05-e800ec9b601a"), 1, 2 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d5c259cd-a721-4906-965a-4cb69c1ba56a"), new Guid("e1cb3734-dc87-4840-b424-7e45a2f625a1"), 7, 1500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("d86cf351-b55f-4366-9fd8-b0df12c8c1a1"), new Guid("d89b9a2c-8cc5-42f8-89da-d47961cf6c6a"), 3, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("dbafe9c7-611d-4d86-8ad7-b9d2bb811342"), new Guid("16a81554-1be4-45d3-9acc-241790c70b8b"), 20, 500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("dd0e158b-9de5-417c-b253-c9229e37adf6"), new Guid("5942809e-75aa-4d26-a2f4-a2fbcfa1b37f"), 9, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("decdb1bc-e37a-42c5-9823-7710c301fc68"), new Guid("95d4869c-253c-49b6-89e5-65bc6c67a07a"), 5, 4000 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("dfef9e52-b87a-4499-b019-212f3efdde89"), new Guid("9b5e4c10-22b2-4dfa-8013-185e11798041"), 4, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e647cba2-9bba-4d92-81b6-7c12b47dfcee"), new Guid("d74b919d-1164-496c-9cae-e96a8814e331"), 5, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e789bb84-af88-4e9b-9a9e-9927336cb2c6"), new Guid("1b1fe8f0-1b87-4333-a886-1ba1a1ed6d0c"), 0, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e843bda3-34c6-4d30-a4ac-7db0686b05f3"), new Guid("fe49b8d1-b065-46e4-a56a-c0e1464f9bc7"), 9, 0 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("e96e9df3-ae85-4e8e-a1a8-40351307a4cd"), new Guid("d5dfb622-0e5b-4187-8007-bfaba1b7ef9c"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("edf103bd-36fd-497c-8d99-228817bbeea8"), new Guid("c2f7f590-9383-44df-8b3d-0b724215acfb"), 12, 2500 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f2170697-a22d-4caa-99e3-dcbe895ceca0"), new Guid("5854dce6-1915-4aba-8cc1-115f349ec331"), 13, 240 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f99fd258-f0df-46e8-9886-87b55f7da852"), new Guid("9d837030-c7a6-45c6-a974-070c0dc3ddd3"), 13, 240 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("f9f73d2f-02b2-411d-9a87-c6bee503efb3"), new Guid("2c7ec3c2-a14a-4128-874a-d3f84c6420e3"), 11, 200 });

            migrationBuilder.InsertData(
                table: "DynParams",
                columns: new[] { "Id", "ConstParamsId", "ParamId", "Value" },
                values: new object[] { new Guid("fadfd514-9169-4e12-a56c-6f6cd4210eab"), new Guid("8b6294c0-9404-432f-a5ff-4c6368ba435c"), 2, 0 });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("064629fb-e2bb-4edf-aa5d-e87d0f2b42aa"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("216c6b17-1f13-4fc1-9b76-4eda70ebec7a"), 1, "Device3_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("07d1315a-8816-493d-baac-2e75c7b26c7b"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("adb3fad4-ff45-44f9-bd2a-222daa1c44d9"), 3, "Device1_CutO2BlowOutPressure" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("0959c331-b168-420a-9a82-9dd7a55ff6cd"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("6ecb2922-0b64-41cb-bb65-9e1cfdc89a51"), 1, "Device3_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1085c4db-4ad4-4dd5-801d-4286db73518b"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("3ca3b7c8-3c48-4f72-8506-05a60bda5baa"), 1, "Device3_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("11a02b3c-793a-4db6-b377-5456eabe529c"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("d0876a85-cd25-423f-afe4-993397b80c2c"), 9, "Device1_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("14f7675d-ffcc-48fe-9dc4-85fffc7f73a8"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("852089c5-f956-4c33-97d3-7366db88b97a"), 1, "Device3_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("181341e3-251b-42cb-952d-1f650393eb3c"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("97d1e11e-992a-4769-904c-b17019ce207a"), 1, "Device2_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("18afba7a-138d-4a07-972b-c1c3dd50f58b"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("c22833a7-cde1-4449-a601-b9f0a020c2aa"), 9, "Device2_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1d9ab807-4ac8-42c4-929b-0aff96720f16"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("e96e9df3-ae85-4e8e-a1a8-40351307a4cd"), 1, "Device3_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("1f91b7ae-93c3-4dcb-9495-da2016f83c79"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("edf103bd-36fd-497c-8d99-228817bbeea8"), 3, "Device2_CutO2BlowOutPressure" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("22406e64-a435-4b7e-85cf-552406f86ccc"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("4d10262a-1a35-4046-82e4-b918869ca029"), 1, "Device2_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("24f3cc28-e906-474a-98d3-49c39f6d20ec"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("d321bfcd-89ef-4a01-8b2d-3fe7fc5e5478"), 3, "Device2_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("31e7bb63-4020-4675-92fd-e364233620ce"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("f99fd258-f0df-46e8-9886-87b55f7da852"), 3, "Device1_CutO2BlowOutTimeOut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3563df0a-aa16-45ec-8590-ab1e5253bd72"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("0a1cab80-57ba-432a-a54f-6f18c3efed4d"), 9, "Device3_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("388b89e3-4673-4471-add2-ec7e9b94f707"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("5953e909-4305-415f-a0ff-461db0522630"), 3, "Device2_CutO2BlowOutTimeOut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3c2d4f5a-879a-402a-b037-cfc16e4e5ccf"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("d17f7b50-d4da-4e45-8a2f-639223063eaf"), 1, "Device1_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3d9bffa2-3814-4c4b-8058-3545adab7560"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("5d125212-ca1e-42d2-8bf6-5e1001c5a43a"), 1, "Device1_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3dcaf010-24e7-40bb-8bc1-c2fb96576b67"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("dbafe9c7-611d-4d86-8ad7-b9d2bb811342"), 1, "Device1_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3ddbcab6-7dae-4196-ab71-19f2ae933335"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("c6345a23-a41c-4297-936a-657d2138cf28"), 2, "Device3_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("3df1ce25-e8e8-4784-80ac-1bbdb77e0012"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("4ce4662b-dfc5-4f42-91a7-7eb458a7994e"), 8, "Device1_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("42f90e83-ca3d-491c-ab87-613620d4e4e0"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("35728bfe-29f1-43f7-a093-1ee0fcc11624"), 1, "Device1_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("44354e23-3452-403c-a33e-f64bfb397ae6"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("7cb7cde4-5105-4c33-beae-616ec2fe9d16"), 1, "Device3_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("4bf1faa4-35a1-4df2-bad2-fa06396dabe1"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("9e64a4f5-4a8e-48b6-9954-96d0e73fbba5"), 9, "Device1_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("514ae60b-e9f6-4f0c-b070-4bdc8663ed47"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("056e309e-27e5-4f61-bffb-7a60233b72ec"), 1, "Device2_HeatO2PreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("55456a8a-449a-412f-9274-18a6438ea059"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("5b457625-53f4-4e8d-967c-ac4ed3de5e37"), 8, "Device3_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5ad09577-f4b7-4915-8ce7-929341fdf8b8"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("89520bc1-9fac-4828-a8ed-222fadf49231"), 1, "Device2_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("5d967fe6-38ee-4ef1-8e23-b46ea7850793"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("c4f63195-5f1d-49d0-9b9b-c3b44355d342"), 8, "Device1_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("61dc5070-c7d4-4d5f-93b7-bfa11443a752"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("384d4064-9fce-4b42-9829-cb38d66055a6"), 8, "Device3_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("62e0d169-ef16-4ab5-b1ee-c7f0e25c7471"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("3e8ac099-c324-4398-87cc-2e8e404a821c"), 1, "Device1_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("62e5ba65-59d4-49b9-9451-786bfadaf23e"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("decdb1bc-e37a-42c5-9823-7710c301fc68"), 1, "Device2_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("63bdbcdf-62a9-4952-ac1e-2fcd5cf11df3"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("af6ac1df-3cef-4511-84cc-db292be95105"), 9, "Device3_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("642d38a4-7638-4bb4-97d3-db69110eecae"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("dd0e158b-9de5-417c-b253-c9229e37adf6"), 1, "Device1_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("644db18a-d1ce-4cd2-b360-a2dea0a4c580"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("7b57c945-dc24-49d9-accb-bf1009934711"), 8, "Device2_HeightPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6571491a-d429-483c-99c4-f3eef11ec974"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("93832056-cf89-4a5e-8f04-d9c808c17bdf"), 2, "Device3_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6a7188ed-6a7d-41df-a5aa-01cfccaedc01"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("b0843623-472b-4a73-ba3e-f13ba4b125dd"), 4, "Device3_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("6bec9957-4cc0-4dca-8f0e-b162c0dbb5b8"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("399b3712-5f46-4eca-a926-b549b971de15"), 2, "Device1_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("715fa413-5735-4817-ac1a-93b2400022cd"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("a7fcbe69-2c80-41ef-9483-516a6d7f5945"), 8, "Device2_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("71cce343-82e1-4a29-91ba-bd8b9316efc7"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("f2170697-a22d-4caa-99e3-dcbe895ceca0"), 3, "Device3_CutO2BlowOutTimeOut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("75b2cf2c-c4c0-4543-ba18-87999945390b"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("967f8102-83a9-4a66-a33e-ffb47acc06e2"), 9, "Device2_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("76ba4fce-a306-4ac4-93a6-0a67d707f55f"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("9b99dbfe-9706-4c5a-bdb5-8906deb9cfef"), 4, "Device2_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("79a84189-61af-4798-a817-7ea496310bdf"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("cc80badf-5c13-4bfa-86a6-dadf46e7d12a"), 1, "Device2_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("79e5d7b8-387b-4113-9d55-033cbd7e6ccd"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("e843bda3-34c6-4d30-a4ac-7db0686b05f3"), 3, "Device3_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("7cbb6428-a19c-4104-b6e9-196e89590da2"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("960dd254-c969-4978-8098-1c50f43b1e8d"), 1, "Device1_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("7dcaf051-c8c7-400d-b61e-2bd6ff989149"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("4678a731-2caa-45de-8469-5bfbf2e60dfc"), 9, "Device2_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("831b23be-6066-427e-b71f-6d196ab16a00"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("8ba96993-9e34-432c-8365-dfbfe5721823"), 2, "Device2_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8bcdd78c-f7d3-478e-aa0c-02cfbed7396c"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("0801686f-4470-4860-ad17-f4d41a82b175"), 3, "Device1_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8f5e6a1c-2043-44b8-bd7e-a61c77e95c3e"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("0c64afd0-9ff5-4a8d-85b2-70c93ff1f0ba"), 1, "Device1_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("8fef4c94-3319-4b3f-809c-3e7a9bd84288"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("c6d5c88e-de52-49fe-9f4b-2f14df3e3e3d"), 2, "Device2_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("949fbc73-e4e9-4064-a7ec-f9a98f4b8c9d"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("9e59f070-03d0-4e71-bace-2d2855d1203f"), 1, "Device2_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("94ee1c0c-d248-487b-8ec4-b77fe23131b6"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("106620dd-05bd-4ed7-82e7-4100060fc324"), 8, "Device2_Off" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("98be7b62-f98e-4a97-afdb-04a84a9ac207"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("4a3593b2-49b7-4dc0-8673-769ebdb3a0e6"), 3, "Device2_DistanceCalibration" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9a1dc79d-497c-4ce3-adbf-9cd857c20ffb"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("bb596e91-aba5-45f6-a0b6-b4eef1ff4dc6"), 8, "Device3_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9b8f9dbd-ced2-4d8d-8274-ebde6ca6e158"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("8049bd9e-0d8f-4449-9741-c0f5ede04873"), 1, "Device1_HeatO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9e225a75-120f-4c5e-b00b-e5645b79c6e1"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("344dce43-e4b1-478c-8f9c-e15322a2e34f"), 2, "Device1_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("9fd44ebf-55d0-49a9-9474-66e22df3bcd1"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("6848b99b-47e6-47d5-9605-f79c7eec65fb"), 1, "Device2_FuelGasCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a1bbc15a-38a2-4c61-be01-8285a205a34a"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("6ae584c0-73f8-4f90-a6d2-d7d996b93e9d"), 8, "Device1_HeightPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a25a16e6-c0c1-4489-a0ce-e3f7c93bacbc"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("5d64f737-602d-4623-8a5d-09224c9c2d41"), 8, "Device1_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a54e59be-f015-4b77-8ab0-46d2488e05ae"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("a6c369b2-9389-45bd-b202-aa3713900ce3"), 2, "Device1_SlagPostTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a7fcf6d0-d3fc-4ece-8258-8e9ac5fc604c"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("aa7ee897-78cc-487f-b2ee-400a7b7edaed"), 9, "Device3_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("a8c62738-fecd-4689-aa8b-c1d01bda2662"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("f9f73d2f-02b2-411d-9a87-c6bee503efb3"), 1, "Device1_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("af50e459-01fa-4ec4-b592-f66e8e564cf0"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("bbfea148-27ff-41ac-a810-818b4e03f197"), 9, "Device1_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("afb1cc96-6abe-4e3e-a13e-e34497f43334"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("bd707f77-a5ce-4c41-9818-7cf96f0a183c"), 3, "Device1_CutO2BlowOutTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b0b4de65-ed29-4b13-8c4c-1a5d6fdeec9d"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("d86cf351-b55f-4366-9fd8-b0df12c8c1a1"), 8, "Device2_HeightCut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b1ad6f40-e79b-40a9-ae4d-22dce2e95934"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("0aa7a444-6ad4-42b1-8f5e-bf91d9d95d94"), 9, "Device2_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b20a6a0f-ae5f-4675-854a-0c4cc89f87a2"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("6bd4650b-7baa-46a3-9dad-61f468c95a4c"), 9, "Device1_RetractPosition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b47223b5-191f-4b81-bd3e-dff5da433b58"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("bb198785-e768-4716-b042-3346fedaa4da"), 9, "Device3_StartPreflow" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("b7df818f-57e5-4c5c-bc0f-2fbde95431de"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("40d8b3eb-d6fa-4676-a0e9-b82cf08c3708"), 3, "Device2_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("bbef5c6b-0d5a-4271-a5c5-2d14f337ce29"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("e647cba2-9bba-4d92-81b6-7c12b47dfcee"), 9, "Device1_HeightControlActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("bc9f4ca7-23fd-4202-a5db-e8ab34d7c05d"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("4c0c2b08-dcae-42e1-94c8-821b8a71b030"), 3, "Device1_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c2b3a58d-0592-4efc-ad0c-a1eb210ecb74"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("dfef9e52-b87a-4499-b019-212f3efdde89"), 9, "Device1_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c67f574a-13a3-4366-b4e6-561635e55450"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("b7d745da-be26-445c-a12f-65ee7c97a217"), 3, "Device3_CutO2BlowOutPressure" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("c82199ba-ea1c-4243-8bdf-c1d46e57846d"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("2dd1cfba-c7ef-4039-b827-4629e1ddcdd1"), 1, "Device3_CutO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("caacfe99-966a-4d24-b199-898d6d0a147e"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("20e8d7e3-bab1-4b5d-b8c0-6bc2ea8f8b5d"), 1, "Device1_HeatO2Ignition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cbaa54be-1464-4061-aa74-5bb2e32847ef"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("d5c259cd-a721-4906-965a-4cb69c1ba56a"), 1, "Device2_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cd5253e6-5db8-4119-bafa-ed67ebeac0e5"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("d5b776a0-2035-4c57-9caa-b03db963635e"), 2, "Device2_SlagSensitivity" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("cd7dd133-1b29-4775-8397-2570f82a32a4"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("86ea5726-9321-4d5b-94c3-68d9441dccbe"), 9, "Device3_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d2988c74-4dee-4f8c-af5d-d0474ac55e50"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("15e7e2cb-1bc1-4903-8ffc-d9c9dfe56169"), 3, "Device3_CutO2BlowOutTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d3704b6a-d0e0-4a08-90da-2201b8a95422"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("0ce20c56-7ce6-4c36-a0c5-a8517300bb42"), 9, "Device3_PiercingDetection" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d3f42498-b221-46e9-ac21-126a687800df"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("8862e680-9dea-476f-b59c-fa9b07261dad"), 1, "Device2_FuelGasIgnition" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("d54bf7f9-1c0a-4d58-8cd2-83387230a494"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("038c26b9-1a32-4a63-b85d-08894fd57763"), 3, "Device3_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e318d8dc-a642-406b-b9ba-8a5657d28719"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("cec42a4a-a3b4-4de9-9f38-ff6eae6a910f"), 9, "Device2_PiercingHeightControl" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e4f20c7e-638d-42a8-b244-c8fb8b20b840"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("6b3c4726-f19f-49da-ae69-fcf4e7590592"), 1, "Device3_HeatO2Cut" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e62a518d-0d45-4854-b3a5-f839e2ba1375"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("c7bb3a40-3124-4c3b-967e-dcf4ada46357"), 3, "Device3_Dynamic" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e79310da-f4d3-4c88-8481-2daadbeb3985"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("4a83438d-0355-4acb-95e0-a52b1dda7684"), 2, "Device3_RetractHeight" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("e88b3fbb-0c10-4a96-9af1-0a18b34d3e95"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("581ee744-e163-4a03-b42d-1938ac44b129"), 1, "Device2_FuelGasPierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ea1b5cf3-5cd5-4ad4-a011-46e04326ec31"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("bfea08eb-42d1-4cc9-9bda-a3a55b447663"), 4, "Device1_SlagCuttingSpeedReduction" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("ef643ada-2aab-47bb-9c97-310d7db56da3"), new Guid("a67c5fbe-5f1c-4da5-8a07-7953e71bdebe"), new Guid("d3b1499c-f915-4164-ba07-28d0bdbeb88c"), 3, "Device1_TactileInitialPosFinding" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f466bee8-9fa0-41b4-8e5e-546c508e97e4"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("be523bb1-eb6e-4705-9aed-e8ed34b6f0c7"), 1, "Device3_CutO2Pierce" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f6da0e2a-f787-449d-a314-c339a9dd46e3"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("d14df38a-1660-4419-bff7-645b34090207"), 1, "Device3_IgnitionFlameAdjust" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f9029e63-2a83-4f01-b8b2-80e6d694d802"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("00cbf28c-da5e-416e-94be-7b9e4b660e33"), 1, "Device3_FuelGasPreHeat" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f9989851-cec4-4d97-badc-5e672f16a463"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("6e2557d9-d45a-42ef-a79a-84172af5ddb2"), 3, "Device2_CutO2BlowOutTime" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("f9c99106-89cf-480b-9173-8c3e57ea1f9b"), new Guid("798dc1e0-47ff-4ee7-9867-665681c55762"), new Guid("fadfd514-9169-4e12-a56c-6f6cd4210eab"), 9, "Device2_PreflowActive" });

            migrationBuilder.InsertData(
                table: "ParameterDatas",
                columns: new[] { "Id", "APCDeviceId", "DynParamsId", "ParamGroupId", "ParamName" },
                values: new object[] { new Guid("fcee5c4a-147a-4433-bb18-71a0af93007b"), new Guid("12ef6801-10cb-454b-9153-a2db7bebc559"), new Guid("e789bb84-af88-4e9b-9a9e-9927336cb2c6"), 8, "Device3_Off" });

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
