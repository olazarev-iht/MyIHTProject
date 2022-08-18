using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.APCHardware
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
                name: "ParameterDataInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: true),
                    Format = table.Column<string>(type: "TEXT", nullable: true),
                    MinDescription = table.Column<string>(type: "TEXT", nullable: true),
                    MaxDescription = table.Column<string>(type: "TEXT", nullable: true),
                    StepDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ValueDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Multiplier = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterDataInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConstParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParameterDataInfoId = table.Column<Guid>(type: "TEXT", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_DynParams_ParameterDataInfos_ParameterDataInfoId",
                        column: x => x.ParameterDataInfoId,
                        principalTable: "ParameterDataInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LiveParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParamId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParameterDataInfoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveParams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiveParams_ParameterDataInfos_ParameterDataInfoId",
                        column: x => x.ParameterDataInfoId,
                        principalTable: "ParameterDataInfos",
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
                values: new object[] { new Guid("0c364bd4-12fb-4332-a7da-d16944b49506"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("0f1a31b8-c77d-4d76-bccc-f5769c9a87e6"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("2f7f42b5-862b-4f3f-afb7-58c3542ef56a"), "APCDevice_1", 1 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5b2999a8-c84b-4435-8359-c90e06ceb6e4"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("86bacfd9-7702-4cdc-9982-9981e12514dc"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("8ca2bef1-83bc-411a-987b-eaf646146335"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("a055e2e7-e8a1-45e5-ad6b-606a8feb19c8"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b32feba9-eb73-43a0-a048-82afccef1c8a"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("db0fc6ba-2d1b-49a2-84d1-f2b0e0844df6"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ebe4c304-de25-4c75-9590-efe3e8599e17"), "APCDevice_4", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ConstParamsId",
                table: "DynParams",
                column: "ConstParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_DynParams_ParameterDataInfoId",
                table: "DynParams",
                column: "ParameterDataInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveParams_ParameterDataInfoId",
                table: "LiveParams",
                column: "ParameterDataInfoId");

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

            migrationBuilder.DropTable(
                name: "ParameterDataInfos");
        }
    }
}
