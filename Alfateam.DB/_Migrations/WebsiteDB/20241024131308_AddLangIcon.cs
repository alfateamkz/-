using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.DB._Migrations.WebsiteDB
{
    /// <inheritdoc />
    public partial class AddLangIcon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "LanguageEntities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "LanguageEntities");
        }
    }
}
