using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.DB._Migrations.WebsiteDB
{
    /// <inheritdoc />
    public partial class JobVacancyCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimezoneLocalizations_TimeZones_TimeZoneId",
                table: "TimezoneLocalizations");

            migrationBuilder.AlterColumn<int>(
                name: "TimeZoneId",
                table: "TimezoneLocalizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JobVacancies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobVacancyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVacancyCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobVacancyCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobVacancyCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVacancyCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobVacancyCategoryLocalizations_JobVacancyCategories_JobVaca~",
                        column: x => x.JobVacancyCategoryId,
                        principalTable: "JobVacancyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancyCategoryLocalizations_LanguageEntities_LanguageEnt~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_CategoryId",
                table: "JobVacancies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancyCategoryLocalizations_JobVacancyCategoryId",
                table: "JobVacancyCategoryLocalizations",
                column: "JobVacancyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancyCategoryLocalizations_LanguageEntityId",
                table: "JobVacancyCategoryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobVacancies_JobVacancyCategories_CategoryId",
                table: "JobVacancies",
                column: "CategoryId",
                principalTable: "JobVacancyCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimezoneLocalizations_TimeZones_TimeZoneId",
                table: "TimezoneLocalizations",
                column: "TimeZoneId",
                principalTable: "TimeZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobVacancies_JobVacancyCategories_CategoryId",
                table: "JobVacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_TimezoneLocalizations_TimeZones_TimeZoneId",
                table: "TimezoneLocalizations");

            migrationBuilder.DropTable(
                name: "JobVacancyCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "JobVacancyCategories");

            migrationBuilder.DropIndex(
                name: "IX_JobVacancies_CategoryId",
                table: "JobVacancies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobVacancies");

            migrationBuilder.AlterColumn<int>(
                name: "TimeZoneId",
                table: "TimezoneLocalizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TimezoneLocalizations_TimeZones_TimeZoneId",
                table: "TimezoneLocalizations",
                column: "TimeZoneId",
                principalTable: "TimeZones",
                principalColumn: "Id");
        }
    }
}
