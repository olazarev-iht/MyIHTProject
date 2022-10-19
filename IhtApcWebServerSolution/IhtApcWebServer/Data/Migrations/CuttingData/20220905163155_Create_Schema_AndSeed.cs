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
                    PreHeatHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    PreHeatHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceHeight = table.Column<int>(type: "INTEGER", nullable: false),
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
                    CutHeight = table.Column<int>(type: "INTEGER", nullable: false),
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
                    Ids = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
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
                    PreHeatHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    PreHeatHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PreHeatTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceHeatingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceCuttingOxygenPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceFuelGasPressure = table.Column<float>(type: "REAL", nullable: false),
                    PierceCuttingSpeedChange = table.Column<int>(type: "INTEGER", nullable: false),
                    PierceTime = table.Column<float>(type: "REAL", nullable: false),
                    CutHeight = table.Column<int>(type: "INTEGER", nullable: false),
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
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("0a47c070-14c2-4b41-a0ae-17f252a59ec0"), 2, "NaturalGas" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("0b308f5f-4a5f-4b05-b984-7e7d71a59427"), 0, "Propan" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("b3bd2527-f662-45f3-8253-14a9c4ed7dba"), 1, "Acetylene" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("474ff776-f1a0-4360-af07-a43e9a0bb4da"), "Mild Steel" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("0d27f707-bb73-49a7-82a7-6bf1a32bcd7c"), "", "", "PSF 15-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("16fe64a1-b634-4d9b-ab1d-fe162aca6c3d"), "", "", "ARC 3-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("1ab52a1a-6d49-4559-9e82-6a919f2fba15"), "", "", "ASF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("1fd87b73-09ba-40b1-b21f-7a33bcb29f4d"), "", "", "ASF 3-5" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("26f51de0-61b7-417b-90d4-b034395b6040"), "", "", "ASF 10-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("3584be73-4d68-4106-ac40-f92f01828edb"), "", "", "ASF 150-230" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("3a768ddc-34eb-4394-8cdf-7d5813a4c895"), "", "", "ASF 230-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("4f51f31b-39f2-44ce-89e6-206bf2ea5dbf"), "", "", "ASF 6-10" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6786a9bf-1e8c-4a6f-b13a-3705da73469e"), "", "", "PSF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6bf0fc51-cf29-47ee-89aa-c4e56361ee4a"), "", "", "PRC 5-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7305f4b0-7515-41a8-bf1a-7f3ad03cf715"), "", "", "PSF 150-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("73add5e2-3cef-4d25-b124-06bbf2881089"), "", "", "PSF 100-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("83e71cc5-ac88-45ee-933d-73aa45a00e49"), "", "", "PRC 5-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("8998c991-1bf9-4728-8eb8-c1fc538a39e2"), "", "", "PSF 7-15" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("8ad4c91d-d28a-4483-aa11-2851508bc71b"), "", "", "ASF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("a778b0f5-66c7-4a01-b340-b5b5843b6d5c"), "", "", "PSF 200-250" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("c480bc52-e55e-4be1-9cc3-9566c9ecc01e"), "", "", "PSF 3-6" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("c87ab98e-2c5e-491d-8e4d-181f356d0df6"), "", "", "ARC 3-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("d615c277-bb82-470a-aa8a-5cdb4bd63424"), "", "", "ASF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("db9cae5b-113b-467e-b52c-e3d9b61f948c"), "", "", "PSF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("e3fe9592-3e0c-4eac-95b8-6cab078a9a1e"), "", "", "PSF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ef462061-71a2-4b64-8b76-e60ebb41cbe6"), "", "", "PSF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("efc1fb0b-3533-4c17-949b-605a5fc4d43c"), "", "", "PSF 250-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("f8f1c2ba-3ab5-4820-a237-b419c071aff4"), "", "", "ASF 100-150" });

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
