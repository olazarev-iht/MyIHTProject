using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.CuttingData
{
    public partial class Create_Schema_AndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APCCuttingParametersIHT",
                columns: table => new
                {
                    Material = table.Column<string>(type: "TEXT", nullable: true),
                    Remark = table.Column<string>(type: "TEXT", nullable: true),
                    Thickness = table.Column<int>(type: "INTEGER", nullable: false),
                    Nozzle = table.Column<string>(type: "TEXT", nullable: true),
                    LeadInLength = table.Column<int>(type: "INTEGER", nullable: false),
                    Kerf = table.Column<float>(type: "REAL", nullable: false),
                    idGas = table.Column<int>(type: "INTEGER", nullable: false),
                    CuttingSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    IgnitionFlameAdjustment = table.Column<int>(type: "INTEGER", nullable: false),
                    PI0 = table.Column<float>(type: "REAL", nullable: false),
                    PI1 = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatHeight = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceHeight = table.Column<float>(type: "REAL", nullable: false),
                    PierceHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceCuttingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceCuttingSpeedChange = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceTime = table.Column<float>(type: "REAL", nullable: false),
                    PP0 = table.Column<int>(type: "INTEGER", nullable: false),
                    PP1 = table.Column<float>(type: "REAL", nullable: false),
                    PP2 = table.Column<float>(type: "REAL", nullable: false),
                    PP3 = table.Column<float>(type: "REAL", nullable: false),
                    PP4 = table.Column<float>(type: "REAL", nullable: false),
                    CutHeight = table.Column<float>(type: "REAL", nullable: false),
                    CutHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    CutCuttingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    CutFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    ExtKey = table.Column<string>(type: "TEXT", nullable: true),
                    ControlBits = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CustomCounter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CounterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCounter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GasId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nozzle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImgPathBegin = table.Column<string>(type: "TEXT", nullable: false),
                    ImgPathEnd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nozzle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuttingData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: true),
                    NozzleId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Thickness = table.Column<float>(type: "REAL", nullable: false),
                    Kerf = table.Column<float>(type: "REAL", nullable: false),
                    LeadInLength = table.Column<int>(type: "INTEGER", nullable: false),
                    CuttingSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    IgnitionFlameAdjustment = table.Column<int>(type: "INTEGER", nullable: false),
                    PreHeatHeight = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceHeight = table.Column<float>(type: "REAL", nullable: false),
                    PierceHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceCuttingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceCuttingSpeedChange = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceTime = table.Column<float>(type: "REAL", nullable: false),
                    CutHeight = table.Column<float>(type: "REAL", nullable: false),
                    CutHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    CutCuttingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    CutFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PI0 = table.Column<float>(type: "REAL", nullable: false),
                    PI1 = table.Column<float>(type: "REAL", nullable: false),
                    PP0 = table.Column<float>(type: "REAL", nullable: false),
                    PP1 = table.Column<float>(type: "REAL", nullable: false),
                    PP2 = table.Column<float>(type: "REAL", nullable: false),
                    PP3 = table.Column<float>(type: "REAL", nullable: false),
                    PP4 = table.Column<float>(type: "REAL", nullable: false),
                    Remark = table.Column<string>(type: "TEXT", nullable: true),
                    ExtKey = table.Column<string>(type: "TEXT", nullable: true),
                    idCutDataParent = table.Column<int>(type: "INTEGER", nullable: true),
                    Controlbits = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuttingData_Gas_GasId",
                        column: x => x.GasId,
                        principalTable: "Gas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuttingData_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuttingData_Nozzle_NozzleId",
                        column: x => x.NozzleId,
                        principalTable: "Nozzle",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CustomCounter",
                columns: new[] { "Id", "CounterId" },
                values: new object[] { new Guid("13f7ddb1-8c5b-451a-88aa-fcf4d533f248"), 1 });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("802c73c5-3f52-4a26-93bc-bc3d563c21d9"), 1, "Acetylene" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("923cebc8-875c-4338-8f5f-c22c65c6250c"), 0, "Propan" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("99d29128-13cb-43f9-8673-eec1b63cd2ca"), 2, "NaturalGas" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2804e2dd-8d12-45a4-afed-8135b0d5baeb"), "Mild Steel" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("00f6723c-6751-4c0a-850b-91f5123f3f9f"), "", "", "ARC 3-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("2046354b-b947-4d87-9df8-4b7680d568c3"), "", "", "ASF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("268ad2e6-43fd-44a0-a033-d3713f7bfbd3"), "", "", "PSF 200-250" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("5344150e-2246-4602-a229-c158e4f7d54c"), "", "", "PRC 5-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("5cc58760-30ec-45af-8a71-584c4ac08e48"), "", "", "PSF 250-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("5e4c638a-fad9-480e-aced-7bc6457f5350"), "", "", "PSF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("72ed1788-e054-494a-b251-30c3f935df01"), "", "", "ASF 230-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7a5606f6-b0f6-41f1-a326-2751eca5d197"), "", "", "PSF 7-15" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7e21120a-121c-4e2a-b178-53a2f17042ae"), "", "", "ASF 3-5" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7f064bd9-e4b0-4204-9029-8c57368385c5"), "", "", "PSF 3-6" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("8619e07c-0aad-4f5c-83f8-617a540c60ea"), "", "", "ASF 150-230" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("86328427-e118-4e54-a5c4-b6cc1aaa148d"), "", "", "PSF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("8bf5cc67-20fe-4ffe-afc6-0a2bd99cc113"), "", "", "ASF 10-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("949d52e0-d402-4fa7-a71d-198f933641b8"), "", "", "ARC 3-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("97e161d7-9b8b-4b93-91c8-d7d8e9ae0916"), "", "", "ASF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("a8cec474-9f1f-44e2-b3f1-66747c8b999a"), "", "", "PSF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("bdba6362-64fc-46ef-8e98-281f770f5604"), "", "", "ASF 6-10" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("c4fa937c-a651-4d13-8dac-e7f2163f92ce"), "", "", "ASF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("cb690669-1be4-4095-91c7-93464e27dff8"), "", "", "PSF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ce62d117-0db2-4517-9264-226962239743"), "", "", "PSF 15-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("eeb32e69-a0e5-4be9-a100-b5bee88e89c7"), "", "", "ASF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("f1f19d2c-7f2c-42c6-a4bb-c9d9186fc513"), "", "", "PSF 150-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("fb126650-287d-471f-8b11-ee865bba15fe"), "", "", "PSF 100-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("fe9a5e46-8ce4-4995-8392-be2548fca1c4"), "", "", "PRC 5-40" });

            migrationBuilder.CreateIndex(
                name: "IX_CuttingData_GasId",
                table: "CuttingData",
                column: "GasId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingData_MaterialId",
                table: "CuttingData",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingData_NozzleId",
                table: "CuttingData",
                column: "NozzleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APCCuttingParametersIHT");

            migrationBuilder.DropTable(
                name: "CustomCounter");

            migrationBuilder.DropTable(
                name: "CuttingData");

            migrationBuilder.DropTable(
                name: "Gas");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Nozzle");
        }
    }
}
