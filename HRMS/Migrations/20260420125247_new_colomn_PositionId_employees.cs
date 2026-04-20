using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class new_colomn_PositionId_employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "Employees");

            migrationBuilder.AddColumn<long>(
                name: "positionId",
                table: "Employees",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_positionId",
                table: "Employees",
                column: "positionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Lookups_positionId",
                table: "Employees",
                column: "positionId",
                principalTable: "Lookups",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Lookups_positionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_positionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "positionId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
