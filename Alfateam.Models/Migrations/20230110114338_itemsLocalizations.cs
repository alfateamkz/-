using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.Database.Migrations
{
    public partial class itemsLocalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "PortfolioPopupLocalizations");

            migrationBuilder.AddColumn<string>(
                name: "MiddleDescription",
                table: "Teammates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Teammates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Teammates",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Promotions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Promotions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "PromotionDescriptionItems",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Portfolios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Portfolios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "PortfolioCategories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Partners",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Partners",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartnerLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerLocalizations_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PortfolioCategoryId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioCategoryLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioCategoryLocalizations_PortfolioCategories_Portfolio~",
                        column: x => x.PortfolioCategoryId,
                        principalTable: "PortfolioCategories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PortfolioId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizations_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PromotionDescriptionItemLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PromotionDescriptionItemId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDescriptionItemLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionDescriptionItemLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionDescriptionItemLocalizations_PromotionDescriptionIt~",
                        column: x => x.PromotionDescriptionItemId,
                        principalTable: "PromotionDescriptionItems",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PromotionLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PromotionId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionLocalizations_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeammateLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeammateId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeammateLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeammateLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeammateLocalizations_Teammates_TeammateId",
                        column: x => x.TeammateId,
                        principalTable: "Teammates",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerLocalizations_LanguageId",
                table: "PartnerLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerLocalizations_PartnerId",
                table: "PartnerLocalizations",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategoryLocalizations_LanguageId",
                table: "PortfolioCategoryLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategoryLocalizations_PortfolioCategoryId",
                table: "PortfolioCategoryLocalizations",
                column: "PortfolioCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizations_LanguageId",
                table: "PortfolioLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizations_PortfolioId",
                table: "PortfolioLocalizations",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDescriptionItemLocalizations_LanguageId",
                table: "PromotionDescriptionItemLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDescriptionItemLocalizations_PromotionDescriptionIt~",
                table: "PromotionDescriptionItemLocalizations",
                column: "PromotionDescriptionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionLocalizations_LanguageId",
                table: "PromotionLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionLocalizations_PromotionId",
                table: "PromotionLocalizations",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeammateLocalizations_LanguageId",
                table: "TeammateLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeammateLocalizations_TeammateId",
                table: "TeammateLocalizations",
                column: "TeammateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerLocalizations");

            migrationBuilder.DropTable(
                name: "PortfolioCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "PortfolioLocalizations");

            migrationBuilder.DropTable(
                name: "PromotionDescriptionItemLocalizations");

            migrationBuilder.DropTable(
                name: "PromotionLocalizations");

            migrationBuilder.DropTable(
                name: "TeammateLocalizations");

            migrationBuilder.DropColumn(
                name: "MiddleDescription",
                table: "Teammates");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teammates");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Teammates");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "PromotionDescriptionItems");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Caption",
                table: "PortfolioCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Partners");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "PortfolioPopupLocalizations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
