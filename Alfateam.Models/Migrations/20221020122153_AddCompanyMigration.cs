using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.Database.Migrations
{
    public partial class AddCompanyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.CreateTable(
                name: "NewPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Watches = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewPosts_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");



            migrationBuilder.CreateTable(
                name: "PostHeadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewPostId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHeadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostHeadings_NewPosts_NewPostId",
                        column: x => x.NewPostId,
                        principalTable: "NewPosts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostParagraphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewPostId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostParagraphs_NewPosts_NewPostId",
                        column: x => x.NewPostId,
                        principalTable: "NewPosts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NewPostId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostSliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostSliders_NewPosts_NewPostId",
                        column: x => x.NewPostId,
                        principalTable: "NewPosts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewPostId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostVideos_NewPosts_NewPostId",
                        column: x => x.NewPostId,
                        principalTable: "NewPosts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");


          

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewPostId = table.Column<int>(type: "int", nullable: true),
                    PostSliderId = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImages_NewPosts_NewPostId",
                        column: x => x.NewPostId,
                        principalTable: "NewPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostImages_PostSliders_PostSliderId",
                        column: x => x.PostSliderId,
                        principalTable: "PostSliders",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NewPosts_LanguageId",
                table: "NewPosts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHeadings_NewPostId",
                table: "PostHeadings",
                column: "NewPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_NewPostId",
                table: "PostImages",
                column: "NewPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostSliderId",
                table: "PostImages",
                column: "PostSliderId");

            migrationBuilder.CreateIndex(
                name: "IX_PostParagraphs_NewPostId",
                table: "PostParagraphs",
                column: "NewPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSliders_NewPostId",
                table: "PostSliders",
                column: "NewPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostVideos_NewPostId",
                table: "PostVideos",
                column: "NewPostId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PortfolioImages");

            migrationBuilder.DropTable(
                name: "PostHeadings");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "PostParagraphs");

            migrationBuilder.DropTable(
                name: "PostVideos");

            migrationBuilder.DropTable(
                name: "SiteFrontends");

            migrationBuilder.DropTable(
                name: "TranslationItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PostSliders");

            migrationBuilder.DropTable(
                name: "ErrorPages");

            migrationBuilder.DropTable(
                name: "GeneralTexts");

            migrationBuilder.DropTable(
                name: "LandingTexts");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PromotionDescriptionItems");

            migrationBuilder.DropTable(
                name: "Teammates");

            migrationBuilder.DropTable(
                name: "NewPosts");

            migrationBuilder.DropTable(
                name: "PortfolioCategories");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
