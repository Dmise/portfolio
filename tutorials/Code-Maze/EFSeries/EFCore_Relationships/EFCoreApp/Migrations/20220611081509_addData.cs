using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAPI_1.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("26441d35-2510-4099-bc0d-dbd4ef4b2005"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("6ff4bced-57d1-43f0-ace9-347fe8516549"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("97bac3b4-47c4-4cf5-80d7-50eb2360677a"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("e6ccc5f7-b59a-44a2-acb5-ac3c5d71ab49"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("20271321-0153-440e-8eea-e76e9268d5d9"), 100, "TEST Name" },
                    { new Guid("39e2e36a-ce79-493e-8e46-3edb92cfa70d"), 28, "Mike Miles" },
                    { new Guid("76406080-23f0-4023-96fa-c06c56b95b22"), 25, "Jane Doe" },
                    { new Guid("ac4e1004-7ebe-459b-8cce-59847524882c"), 30, "John Doe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("20271321-0153-440e-8eea-e76e9268d5d9"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("39e2e36a-ce79-493e-8e46-3edb92cfa70d"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("76406080-23f0-4023-96fa-c06c56b95b22"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("ac4e1004-7ebe-459b-8cce-59847524882c"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "IsRegularStudent", "Name" },
                values: new object[,]
                {
                    { new Guid("26441d35-2510-4099-bc0d-dbd4ef4b2005"), 25, false, "Jane Doe" },
                    { new Guid("6ff4bced-57d1-43f0-ace9-347fe8516549"), 30, false, "John Doe" },
                    { new Guid("97bac3b4-47c4-4cf5-80d7-50eb2360677a"), 100, false, "TEST Name" },
                    { new Guid("e6ccc5f7-b59a-44a2-acb5-ac3c5d71ab49"), 28, false, "Mike Miles" }
                });
        }
    }
}
