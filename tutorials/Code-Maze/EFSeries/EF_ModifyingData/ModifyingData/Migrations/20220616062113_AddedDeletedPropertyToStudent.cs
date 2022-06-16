using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModifyingData.Migrations
{
    public partial class AddedDeletedPropertyToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("160814db-d1bf-44f5-a0ae-33227dae235a"), "First test...", 3, new Guid("410c14e3-e6df-45b8-8c6f-1e19aed675ac") },
                    { new Guid("2cceb395-84f0-4b43-8384-9343afcffa4b"), "Last test...", 2, new Guid("4addc421-0937-45cb-b55c-200b45c6caca") },
                    { new Guid("2e6cc1bd-1f15-4778-936a-b77d30e14e12"), "First test...", 5, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("7cc99fa3-fb98-403e-a57b-f56cb24ce3be"), "Second test...", 4, new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("160814db-d1bf-44f5-a0ae-33227dae235a"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("2cceb395-84f0-4b43-8384-9343afcffa4b"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("2e6cc1bd-1f15-4778-936a-b77d30e14e12"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("7cc99fa3-fb98-403e-a57b-f56cb24ce3be"));

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Student");

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
    }
}
