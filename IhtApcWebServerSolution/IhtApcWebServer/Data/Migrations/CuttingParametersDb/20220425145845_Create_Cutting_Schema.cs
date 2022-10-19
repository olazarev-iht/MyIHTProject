using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.CuttingParametersDb
{
    public partial class Create_Cutting_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuttingParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Thickness = table.Column<float>(type: "REAL", nullable: false),
                    HeatingHeight = table.Column<float>(type: "REAL", nullable: false),
                    CuttingHeight = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingParameters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuttingParameters");
        }
    }
}
