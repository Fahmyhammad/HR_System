using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class add_HourlyPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HourlyPrice",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyPrice",
                table: "Employees");
        }
    }
}
