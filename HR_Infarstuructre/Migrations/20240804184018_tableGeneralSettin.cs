using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR_Infarstuructre.Migrations
{
    /// <inheritdoc />
    public partial class tableGeneralSettin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Extra = table.Column<int>(type: "int", nullable: false),
                    Rival = table.Column<int>(type: "int", nullable: false),
                    OfficialLeave1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialLeave2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralSettings_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSettings_employeeId",
                table: "GeneralSettings",
                column: "employeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralSettings");
        }
    }
}
