using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IhtApcWebServer.Data.Migrations.APCHardware
{
    public partial class Create_Schema_AndSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("01406338-2398-4548-9101-c3c2cd3f2540"), "APCDevice_5", 5 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("04e502b4-fa2f-40f3-aeca-f1070d98d35e"), "APCDevice_9", 9 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("0725e0fe-72d3-4663-bcbe-9e3924ed2290"), "APCDevice_6", 6 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("4d3390ff-a8c5-43df-ae69-12455bf7ef2f"), "APCDevice_7", 7 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("5f26916e-fd7a-4b67-9b3d-ee406d63b41e"), "APCDevice_8", 8 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("89044ff4-8dec-4684-be7f-79091200be89"), "APCDevice_2", 2 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("b538dd00-79d5-4372-869b-f07fa4a9c307"), "APCDevice_3", 3 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("de554c33-f016-46b0-8f61-7823668d63b7"), "APCDevice_4", 4 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("e61d8d0a-db1a-4d7d-b6c0-c329d6de4eda"), "APCDevice_10", 10 });

            migrationBuilder.InsertData(
                table: "APCDevices",
                columns: new[] { "Id", "Name", "Num" },
                values: new object[] { new Guid("ebaba5d0-6dd5-47ae-b449-6aa288d1ff2a"), "APCDevice_1", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("01406338-2398-4548-9101-c3c2cd3f2540"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("04e502b4-fa2f-40f3-aeca-f1070d98d35e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("0725e0fe-72d3-4663-bcbe-9e3924ed2290"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("4d3390ff-a8c5-43df-ae69-12455bf7ef2f"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("5f26916e-fd7a-4b67-9b3d-ee406d63b41e"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("89044ff4-8dec-4684-be7f-79091200be89"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("b538dd00-79d5-4372-869b-f07fa4a9c307"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("de554c33-f016-46b0-8f61-7823668d63b7"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("e61d8d0a-db1a-4d7d-b6c0-c329d6de4eda"));

            migrationBuilder.DeleteData(
                table: "APCDevices",
                keyColumn: "Id",
                keyValue: new Guid("ebaba5d0-6dd5-47ae-b449-6aa288d1ff2a"));
        }
    }
}
