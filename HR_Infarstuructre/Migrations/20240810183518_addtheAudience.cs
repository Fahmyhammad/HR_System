using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class addtheAudience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "theAudience",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "theAudience",
                table: "Absences");
        }
    }
}
