using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.DB._MigrationsWebsiteDBContext
{
    /// <inheritdoc />
    public partial class AddTeamStructTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TeamStructures",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TeamStructures");
        }
    }
}
