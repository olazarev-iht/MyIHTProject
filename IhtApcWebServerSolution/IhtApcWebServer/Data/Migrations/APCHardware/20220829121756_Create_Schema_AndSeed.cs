using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
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
                    Address = table.Column<int>(type: "INTEGER", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DynParams_ParameterDataInfos_ParameterDataInfoId",
                        column: x => x.ParameterDataInfoId,
                        principalTable: "ParameterDataInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
