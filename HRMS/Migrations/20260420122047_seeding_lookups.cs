using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class seeding_lookups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "id", "magerCode", "minerCode", "name" },
                values: new object[,]
                {
                    { 1L, 0, 0, "Employees position" },
                    { 2L, 0, 0, "Manager" },
                    { 3L, 0, 1, "Developer" },
                    { 4L, 0, 2, "HR" },
                    { 5L, 1, 0, "Department name" },
                    { 6L, 1, 1, "Finance" },
                    { 7L, 1, 2, "Adminstrative" },
                    { 8L, 1, 3, "Technical" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Lookups",
                keyColumn: "id",
                keyValue: 8L);
        }
    }
}
