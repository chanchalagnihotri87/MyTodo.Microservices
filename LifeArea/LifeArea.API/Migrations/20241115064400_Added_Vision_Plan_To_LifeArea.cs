using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeArea.API.Migrations
{
    /// <inheritdoc />
    public partial class Added_Vision_Plan_To_LifeArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "LifeAreas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vision",
                table: "LifeAreas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LifeAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Plan", "Vision" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LifeAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Plan", "Vision" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LifeAreas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Plan", "Vision" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LifeAreas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Plan", "Vision" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LifeAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Plan", "Vision" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LifeAreas",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Plan", "Vision" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan",
                table: "LifeAreas");

            migrationBuilder.DropColumn(
                name: "Vision",
                table: "LifeAreas");
        }
    }
}
