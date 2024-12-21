using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Objectives.API.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Plan = table.Column<string>(type: "TEXT", nullable: true),
                    GoalId = table.Column<int>(type: "INTEGER", nullable: false),
                    TwentyPercent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Completed", "GoalId", "Index", "Plan", "Text", "TwentyPercent", "UserId" },
                values: new object[] { 1, true, 1, 0, null, "Think about correctness", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objectives");
        }
    }
}
