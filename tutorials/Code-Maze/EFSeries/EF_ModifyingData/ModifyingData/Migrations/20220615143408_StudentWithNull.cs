using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModifyingData.Migrations
{
    public partial class StudentWithNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("08717890-80b8-4e92-8bc0-832fb35754b0"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("693556a1-d2af-4c3a-8f59-520fbefaae0a"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("de7b0628-da77-4555-bd69-9caf3a84df44"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("f41281f9-0261-4d52-97a8-085dbe0164ac"));

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("063833cd-5074-4af1-a1f0-fa5cd94d3c49"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("259a9a5c-0296-41c1-a9d2-8fb98c55eed8"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("5197b887-9e72-4ff4-afef-2909ecb208a1"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") },
                    { new Guid("c1a71d7c-c61a-451e-8603-554659071f31"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("063833cd-5074-4af1-a1f0-fa5cd94d3c49"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("259a9a5c-0296-41c1-a9d2-8fb98c55eed8"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("5197b887-9e72-4ff4-afef-2909ecb208a1"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("c1a71d7c-c61a-451e-8603-554659071f31"));

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
        }
    }
}
