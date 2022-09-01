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
                values: new object[] { new Guid("1cc5e035-f66d-4a20-b398-5f77314cb1a7"), 0, "Propan" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("493a1c7f-a291-4d58-92aa-77174f83b676"), 2, "NaturalGas" });

            migrationBuilder.InsertData(
                table: "Gas",
                columns: new[] { "Id", "GasId", "Name" },
                values: new object[] { new Guid("78eb87d8-9348-4546-8888-0fa9b40758a2"), 1, "Acetylene" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("48572777-e81b-4b9f-ade7-a04a63838fbf"), "Mild Steel" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("01f2562d-a871-4bc2-ae42-6850aad10dc4"), "", "", "ASF 100-150" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("130a9f6b-257f-43b2-9df7-aa1c40b85b8b"), "", "", "PRC 5-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("2164ec4b-d449-4b39-8a78-1252daf125be"), "", "", "ASF 10-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("21772aa1-f93d-4059-bd77-07abc42a6d7d"), "", "", "ASF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("2efc5fec-2fb8-44e6-b3f2-2c7b77715d3a"), "", "", "PRC 5-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("3fb1cda4-2472-4baa-95a8-5b43ced19a3f"), "", "", "ASF 6-10" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("4870a16c-d70d-4a31-aee8-0747e2819be4"), "", "", "ASF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("50333815-3f76-4e3b-824f-cc8921048398"), "", "", "PSF 60-100" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("55d2d908-ef74-4640-a1c4-8d9761d01fe2"), "", "", "PSF 150-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("57e041e1-25d2-4b75-8f73-917cb8c6959c"), "", "", "ASF 3-5" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6921c3c4-a74d-44c6-8d02-10533d97295c"), "", "", "PSF 7-15" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("6b3e0e3a-5af8-46cb-8b53-d3320ea782d1"), "", "", "ARC 3-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7238f412-e053-472f-ae0f-5c46ffcd298f"), "", "", "ASF 150-230" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("7eb6c257-8d0e-4fca-bfec-1761e3d296f9"), "", "", "ARC 3-70" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("87c00c4d-eebf-46f8-abac-f34ea2fa902b"), "", "", "PSF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("981144ca-e835-49f9-b3c4-fa566eb2c9af"), "", "", "PSF 100-200" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("a04b9d1a-e2cf-4b05-b967-f04e7cba2730"), "", "", "ASF 230-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("a1fa74c3-f8e1-4e78-989f-309e729b4b75"), "", "", "PSF 3-6" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("a9e636fc-f227-4ba1-95fe-707298990163"), "", "", "PSF 250-300" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("bb436ec3-8975-4919-8124-42bc5c50ba5e"), "", "", "PSF 25-40" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("ce2f8d33-087d-4b95-a3eb-e3a8b1cd3e3c"), "", "", "ASF 40-60" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("d1ce5e52-780d-4add-bb63-018681932286"), "", "", "PSF 200-250" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("e2b88477-b228-4663-bcf3-8e595b19d715"), "", "", "PSF 15-25" });

            migrationBuilder.InsertData(
                table: "Nozzle",
                columns: new[] { "Id", "ImgPathBegin", "ImgPathEnd", "Name" },
                values: new object[] { new Guid("e3f8079b-3ac2-4d85-b1f1-d92cbb8be7a1"), "", "", "PSF 100-150" });

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
