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
                table: "CustomCounter",
                columns: new[] { "Id", "CounterId" },
                values: new object[] { new Guid("144b41f7-64d1-4d28-a1b9-4aed7f94a6b9"), 1 });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("0612c322-c0c2-46ad-b832-b1a54988be2a"), 2, "NaturalGas" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("d2640602-8975-4ba9-a77a-d39d9adf569f"), 0, "Propan" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("f4a41b2c-6af0-4831-bc6f-e1413a43d4c9"), 1, "Acetylene" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4c2ad9a1-9c3e-4932-a3bd-17eb93ad0c09"), "Mild Steel" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("0f565018-afd1-41ae-95e0-32708df00dd1"), "", "", "PSF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("1475e10e-4363-45ca-a06b-0da0f38f622c"), "", "", "ASF 6-10" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("167ba134-cfff-4d24-a5bb-333d7209b4a4"), "", "", "ASF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("2c1b57ed-8eb2-48db-aead-e6704e05b007"), "", "", "PSF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("2d70f786-db08-48e2-9934-e9827e05e913"), "", "", "ASF 150-230" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("2d9e20a1-0151-47fd-9ecb-6a107fb03b41"), "", "", "ASF 3-5" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("3c995426-49cb-457f-a9f5-7ab3a8234e5e"), "", "", "PSF 250-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("436e048e-7fd8-4704-b2db-70749fd70393"), "", "", "ASF 10-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("45926932-9fa5-4639-a043-9764aa7d062b"), "", "", "PSF 200-250" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("45bf6661-0e40-4be1-9448-1372ebfbb59e"), "", "", "ASF 230-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("465889f7-a1dc-4a54-93e9-7ce7b7e26ca8"), "", "", "PSF 7-15" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("4963a699-1abd-415b-8a9c-c711985f42d7"), "", "", "ARC 3-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("53106f95-084f-45a5-80a1-16e9934ce44a"), "", "", "ASF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("78b18562-694e-46b4-a24c-a601d3a5c773"), "", "", "PSF 100-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7dd82824-986d-4ee1-bc1a-5523572efe70"), "", "", "ASF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("b4fb431e-faa6-4614-a36d-b1265b60aadd"), "", "", "PRC 5-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("b86c11e1-b53f-4980-9c31-c6ec3b2b0f5a"), "", "", "ASF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("c34094ae-c9e5-446a-90ba-424eded2325b"), "", "", "PSF 15-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("c84b055a-b876-4d30-ae51-fdba16594078"), "", "", "ARC 3-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("d810c12b-69d1-45a4-9817-ad39679f4dd0"), "", "", "PSF 150-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ddb4881e-9843-4f30-8479-f5df99f865d5"), "", "", "PSF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("de04c785-83f7-421b-89eb-13be7897204d"), "", "", "PRC 5-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("dfad8b3c-79c2-4512-87d4-1be600baf665"), "", "", "PSF 3-6" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ebcdcf9f-e4cf-413f-a671-c1382ebd64f9"), "", "", "PSF 40-60" });

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
