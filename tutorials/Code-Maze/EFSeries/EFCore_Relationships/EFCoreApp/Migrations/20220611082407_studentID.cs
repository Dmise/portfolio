using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAPI_1.Migrations
{
    public partial class studentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "StudentID");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Student",
                newName: "Id");


        }
    }
}
