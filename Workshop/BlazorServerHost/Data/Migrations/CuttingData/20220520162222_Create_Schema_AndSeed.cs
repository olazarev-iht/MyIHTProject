using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerHost.Data.Migrations.CuttingData
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "(lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-4' || substr(lower(hex(randomblob(2))),2) || '-' || substr('89ab',abs(random()) % 4 + 1, 1) || substr(lower(hex(randomblob(2))),2) || '-' || lower(hex(randomblob(6))))"),
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
                    idCutDataParent = table.Column<Guid>(type: "TEXT", nullable: true),
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
                values: new object[] { new Guid("2954fb92-ba01-43ee-9f49-37f74870a5bf"), 0, "Propan" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("324929b4-cc09-4a9c-a766-af62cd9e8dc3"), 1, "Acetylene" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("d9b6ac85-21e1-4eaa-8c4b-1ea325488592"), 2, "NaturalGas" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7bec44e6-f1a6-4351-9d8e-83110c12ed47"), "Mild Steel" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("0d01574b-51b9-4d75-9e17-a6a3c30da53a"), "", "", "ASF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("0f772844-faae-418f-9da6-ed08a43c5893"), "", "", "PSF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("16bdec60-b332-4990-89be-6d298bd33248"), "", "", "PRC 5-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("240a7084-18a6-46f6-b64b-6564edde0948"), "", "", "PSF 15-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("282d6eb3-b05d-498b-a4b4-5eb48e32db10"), "", "", "PSF 3-6" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("3c192581-5a28-4b30-b28f-5d26ae83fc98"), "", "", "ASF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("48d71e0e-eb05-455d-bfc3-01d472f4691b"), "", "", "ASF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("49bf3360-33ec-49e8-860a-51663cb4fe60"), "", "", "ASF 10-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("5186f845-a0cf-4141-b090-6b8614331b9c"), "", "", "PSF 7-15" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6049d13d-14ab-4104-a0a3-ea8bdccbea7d"), "", "", "ARC 3-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("63e6bde7-d079-4439-85be-c586f2506963"), "", "", "PSF 250-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("65cc1e77-6971-4c93-a08a-a4303e324018"), "", "", "PSF 100-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6626573c-e195-4a1c-987c-64861b9a9f1f"), "", "", "PSF 150-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6f9d6e4b-0b74-4f4b-86dc-c5f06d497c8d"), "", "", "PRC 5-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7a0cfbdd-d9a2-41bc-b510-1e614c7d34ba"), "", "", "PSF 200-250" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7fe3388c-8739-4f8c-9252-7abe83249571"), "", "", "PSF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("83fdb324-00fd-480d-b11b-3dfc9274f3c8"), "", "", "ASF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("a5d53216-522a-478e-ba8c-72466306adbd"), "", "", "ASF 6-10" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ca396626-2734-459b-bdce-ffcee3358910"), "", "", "ASF 230-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("e4fe487c-69d8-42a5-975f-c2cadf0a61ea"), "", "", "PSF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ef11c212-e58b-402b-9b80-d82aaa33a09c"), "", "", "ASF 150-230" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("f3073d90-aa2a-4615-9d6c-678c4d3d67ca"), "", "", "ARC 3-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("f76245f5-be8a-4679-86c2-16ccab10a47f"), "", "", "ASF 3-5" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("fd943b93-4da2-458f-9e3d-fb952e2599a4"), "", "", "PSF 25-40" });

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
