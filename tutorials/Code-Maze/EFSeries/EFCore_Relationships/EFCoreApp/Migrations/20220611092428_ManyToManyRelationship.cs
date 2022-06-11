using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAPI_1.Migrations
{
    public partial class ManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("0e4b2f4d-79d2-4e13-a274-b4ea9f636394"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("90576a9a-a7a6-460b-abb0-bb3fa3a73565"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("95f8c18e-b5e1-4f49-942f-280fffa8c893"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("aebd57d3-deb0-47fc-beec-59cea7d82d5c"));

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentID", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("077f6aec-39c0-4a7c-80c5-735e2e891677"), 30, "John Doe" },
                    { new Guid("31962ba6-f7db-43fe-a7fa-9f9244d3a667"), 100, "TEST Name" },
                    { new Guid("465e0cb5-e795-4730-b793-86362dd36d97"), 28, "Mike Miles" },
                    { new Guid("c4115797-8ff7-4e3b-8628-650fd527dcff"), 25, "Jane Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("077f6aec-39c0-4a7c-80c5-735e2e891677"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("31962ba6-f7db-43fe-a7fa-9f9244d3a667"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("465e0cb5-e795-4730-b793-86362dd36d97"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentID",
                keyValue: new Guid("c4115797-8ff7-4e3b-8628-650fd527dcff"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentID", "Age", "IsRegularStudent", "Name" },
                values: new object[,]
                {
                    { new Guid("0e4b2f4d-79d2-4e13-a274-b4ea9f636394"), 30, false, "John Doe" },
                    { new Guid("90576a9a-a7a6-460b-abb0-bb3fa3a73565"), 25, false, "Jane Doe" },
                    { new Guid("95f8c18e-b5e1-4f49-942f-280fffa8c893"), 28, false, "Mike Miles" },
                    { new Guid("aebd57d3-deb0-47fc-beec-59cea7d82d5c"), 100, false, "TEST Name" }
                });
        }
    }
}
