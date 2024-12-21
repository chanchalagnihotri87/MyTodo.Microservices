using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Problems.API.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Plan = table.Column<string>(type: "TEXT", nullable: true),
                    LifeAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TwentyPercent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    User_Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "Id", "Completed", "Index", "LifeAreaId", "Plan", "Text", "TwentyPercent", "User_Id" },
                values: new object[,]
                {
                    { 1, true, 1, 1, null, "Not able to speak in english", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") },
                    { 2, true, 2, 1, null, "Lack of sales man skill", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") },
                    { 3, true, 3, 1, null, "Build product from scratch", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") },
                    { 4, true, 1, 1, null, "Business mindset", true, new Guid("16591e7e-c974-4512-88aa-af31e5230c93") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problems");
        }
    }
}
