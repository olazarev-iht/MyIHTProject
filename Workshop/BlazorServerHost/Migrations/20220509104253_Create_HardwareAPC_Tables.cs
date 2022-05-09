using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Migrations
{
    public partial class Create_HardwareAPC_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConstParam1 = table.Column<double>(type: "REAL", nullable: false),
                    ConstParam2 = table.Column<double>(type: "REAL", nullable: false),
                    ConstParam3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DynamicParam1 = table.Column<double>(type: "REAL", nullable: false),
                    DynamicParam2 = table.Column<double>(type: "REAL", nullable: false),
                    DynamicParam3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveParams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LiveParam1 = table.Column<double>(type: "REAL", nullable: false),
                    LiveParam2 = table.Column<double>(type: "REAL", nullable: false),
                    LiveParam3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveParams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareAPCModel",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", nullable: true),
                    DynamicParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LiveParamsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ConstParamsId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareAPCModel", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_HardwareAPCModel_ConstParams_ConstParamsId",
                        column: x => x.ConstParamsId,
                        principalTable: "ConstParams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HardwareAPCModel_DynamicParams_DynamicParamsId",
                        column: x => x.DynamicParamsId,
                        principalTable: "DynamicParams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HardwareAPCModel_LiveParams_LiveParamsId",
                        column: x => x.LiveParamsId,
                        principalTable: "LiveParams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "ConstParam1", "ConstParam2", "ConstParam3" },
                values: new object[] { new Guid("6cd18a28-8b9c-48fe-a7b8-c0e4d56c5328"), 3.0, 3.0, 3.0 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "ConstParam1", "ConstParam2", "ConstParam3" },
                values: new object[] { new Guid("7fb18342-6d7d-4a6b-90e0-ba3936592291"), 1.0, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "ConstParams",
                columns: new[] { "Id", "ConstParam1", "ConstParam2", "ConstParam3" },
                values: new object[] { new Guid("d8126533-d7ec-4cad-94de-0472f4a6423c"), 2.0, 2.0, 2.0 });

            migrationBuilder.InsertData(
                table: "DynamicParams",
                columns: new[] { "Id", "DynamicParam1", "DynamicParam2", "DynamicParam3" },
                values: new object[] { new Guid("094d2b09-8dff-4df8-8fbf-581e48d4d766"), 2.0, 2.0, 2.0 });

            migrationBuilder.InsertData(
                table: "DynamicParams",
                columns: new[] { "Id", "DynamicParam1", "DynamicParam2", "DynamicParam3" },
                values: new object[] { new Guid("1bb6a3ce-5aca-4423-a98b-7834d44f6f28"), 1.0, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "DynamicParams",
                columns: new[] { "Id", "DynamicParam1", "DynamicParam2", "DynamicParam3" },
                values: new object[] { new Guid("2f251f3d-0343-4bd6-bda9-019b5107c1df"), 3.0, 3.0, 3.0 });

            migrationBuilder.InsertData(
                table: "LiveParams",
                columns: new[] { "Id", "LiveParam1", "LiveParam2", "LiveParam3" },
                values: new object[] { new Guid("ac695904-692f-4299-ae97-2988016b96a3"), 1.0, 1.0, 1.0 });

            migrationBuilder.InsertData(
                table: "LiveParams",
                columns: new[] { "Id", "LiveParam1", "LiveParam2", "LiveParam3" },
                values: new object[] { new Guid("ded9b16f-6f65-4871-9adc-568e1d16d669"), 3.0, 3.0, 3.0 });

            migrationBuilder.InsertData(
                table: "LiveParams",
                columns: new[] { "Id", "LiveParam1", "LiveParam2", "LiveParam3" },
                values: new object[] { new Guid("fc9dfc38-6ef6-4e18-9843-9e2facfc1da4"), 2.0, 2.0, 2.0 });

            migrationBuilder.InsertData(
                table: "HardwareAPCModel",
                columns: new[] { "DeviceId", "ConstParamsId", "DeviceName", "DynamicParamsId", "LiveParamsId" },
                values: new object[] { new Guid("497d1dd6-e384-4017-baf9-0452c28493d5"), new Guid("d8126533-d7ec-4cad-94de-0472f4a6423c"), "Device2", new Guid("094d2b09-8dff-4df8-8fbf-581e48d4d766"), new Guid("fc9dfc38-6ef6-4e18-9843-9e2facfc1da4") });

            migrationBuilder.InsertData(
                table: "HardwareAPCModel",
                columns: new[] { "DeviceId", "ConstParamsId", "DeviceName", "DynamicParamsId", "LiveParamsId" },
                values: new object[] { new Guid("79392430-d2ab-4987-9914-04cd189298b5"), new Guid("6cd18a28-8b9c-48fe-a7b8-c0e4d56c5328"), "Device3", new Guid("2f251f3d-0343-4bd6-bda9-019b5107c1df"), new Guid("ded9b16f-6f65-4871-9adc-568e1d16d669") });

            migrationBuilder.InsertData(
                table: "HardwareAPCModel",
                columns: new[] { "DeviceId", "ConstParamsId", "DeviceName", "DynamicParamsId", "LiveParamsId" },
                values: new object[] { new Guid("8ea36520-9bcf-4a0a-965b-9551fdfb2e81"), new Guid("7fb18342-6d7d-4a6b-90e0-ba3936592291"), "Device1", new Guid("1bb6a3ce-5aca-4423-a98b-7834d44f6f28"), new Guid("ac695904-692f-4299-ae97-2988016b96a3") });

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAPCModel_ConstParamsId",
                table: "HardwareAPCModel",
                column: "ConstParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAPCModel_DynamicParamsId",
                table: "HardwareAPCModel",
                column: "DynamicParamsId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAPCModel_LiveParamsId",
                table: "HardwareAPCModel",
                column: "LiveParamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareAPCModel");

            migrationBuilder.DropTable(
                name: "ConstParams");

            migrationBuilder.DropTable(
                name: "DynamicParams");

            migrationBuilder.DropTable(
                name: "LiveParams");
        }
    }
}
