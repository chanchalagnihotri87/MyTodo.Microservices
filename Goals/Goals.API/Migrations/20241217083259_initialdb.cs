using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Goals.API.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Plan = table.Column<string>(type: "TEXT", nullable: true),
                    ProblemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TwentyPercent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "Completed", "Index", "Plan", "ProblemId", "Text", "TwentyPercent", "UserId" },
                values: new object[,]
                {
                    { 1, true, 0, null, 1, "Correct in english", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") },
                    { 2, true, 0, null, 1, "Confidence in english", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") },
                    { 3, true, 0, null, 1, "Speaking fast", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") },
                    { 4, false, 0, null, 1, "Fluent in english", false, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
