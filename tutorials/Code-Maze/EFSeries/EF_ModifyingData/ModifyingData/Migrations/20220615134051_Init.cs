using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModifyingData.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    IsRegularStudent = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

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
                name: "Evaluation",
                columns: table => new
                {
                    EvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    AdditionalExplanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.EvaluationId);
                    table.ForeignKey(
                        name: "FK_Evaluation_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentDetailsId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "StudentId",
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
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"), 25, "Jane Doe" },
                    { new Guid("4addc421-0937-45cb-b55c-200b45c6caca"), 28, "Mike Miles" },
                    { new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"), 30, "John Doe" }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8"), "Math" },
                    { new Guid("89fc9e5d-74f6-4d2e-ae82-76f2b1decce7"), "English" },
                    { new Guid("9e5f12c2-0aa2-49b0-9db2-7df40fecf9ad"), "History" },
                    { new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f"), "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("08717890-80b8-4e92-8bc0-832fb35754b0"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("693556a1-d2af-4c3a-8f59-520fbefaae0a"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") },
                    { new Guid("de7b0628-da77-4555-bd69-9caf3a84df44"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("f41281f9-0261-4d52-97a8-085dbe0164ac"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") }
                });

            migrationBuilder.InsertData(
                table: "StudentSubject",
                columns: new[] { "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"), new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8") },
                    { new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac"), new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f") },
                    { new Guid("4addc421-0937-45cb-b55c-200b45c6caca"), new Guid("fee204f4-a51d-44bb-a3d7-dcc2b5ee5d4f") },
                    { new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"), new Guid("7e69e207-5131-4791-9064-57f6d3c47fc8") },
                    { new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"), new Guid("89fc9e5d-74f6-4d2e-ae82-76f2b1decce7") },
                    { new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"), new Guid("9e5f12c2-0aa2-49b0-9db2-7df40fecf9ad") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_StudentId",
                table: "Evaluation",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
