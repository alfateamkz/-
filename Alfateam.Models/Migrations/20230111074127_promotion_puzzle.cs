using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.Database.Migrations
{
    public partial class promotion_puzzle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Partners_PartnerId",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Partners_PartnerId1",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_PortfolioCategories_PortfolioCategoryId",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Portfolios_PortfolioId",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Portfolios_PortfolioId1",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_PromotionDescriptionItems_PromotionDescript~",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Promotions_PromotionId",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Promotions_PromotionId1",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Teammates_TeammateId",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Teammates_TeammateId1",
                table: "TranslationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationItems_Teammates_TeammateId2",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PartnerId",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PartnerId1",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PortfolioCategoryId",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PortfolioId",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PortfolioId1",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PromotionDescriptionItemId",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PromotionId",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_PromotionId1",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_TeammateId",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_TeammateId1",
                table: "TranslationItems");

            migrationBuilder.DropIndex(
                name: "IX_TranslationItems_TeammateId2",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PartnerId1",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PortfolioCategoryId",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PortfolioId1",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PromotionDescriptionItemId",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "PromotionId1",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "TeammateId",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "TeammateId1",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "TeammateId2",
                table: "TranslationItems");

            migrationBuilder.AddColumn<int>(
                name: "PromotionPuzzleType",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionPuzzleType",
                table: "Promotions");

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartnerId1",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioCategoryId",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId1",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromotionDescriptionItemId",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromotionId1",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeammateId",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeammateId1",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeammateId2",
                table: "TranslationItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PartnerId",
                table: "TranslationItems",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PartnerId1",
                table: "TranslationItems",
                column: "PartnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PortfolioCategoryId",
                table: "TranslationItems",
                column: "PortfolioCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PortfolioId",
                table: "TranslationItems",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PortfolioId1",
                table: "TranslationItems",
                column: "PortfolioId1");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PromotionDescriptionItemId",
                table: "TranslationItems",
                column: "PromotionDescriptionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PromotionId",
                table: "TranslationItems",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_PromotionId1",
                table: "TranslationItems",
                column: "PromotionId1");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_TeammateId",
                table: "TranslationItems",
                column: "TeammateId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_TeammateId1",
                table: "TranslationItems",
                column: "TeammateId1");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationItems_TeammateId2",
                table: "TranslationItems",
                column: "TeammateId2");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Partners_PartnerId",
                table: "TranslationItems",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Partners_PartnerId1",
                table: "TranslationItems",
                column: "PartnerId1",
                principalTable: "Partners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_PortfolioCategories_PortfolioCategoryId",
                table: "TranslationItems",
                column: "PortfolioCategoryId",
                principalTable: "PortfolioCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Portfolios_PortfolioId",
                table: "TranslationItems",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Portfolios_PortfolioId1",
                table: "TranslationItems",
                column: "PortfolioId1",
                principalTable: "Portfolios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_PromotionDescriptionItems_PromotionDescript~",
                table: "TranslationItems",
                column: "PromotionDescriptionItemId",
                principalTable: "PromotionDescriptionItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Promotions_PromotionId",
                table: "TranslationItems",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Promotions_PromotionId1",
                table: "TranslationItems",
                column: "PromotionId1",
                principalTable: "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Teammates_TeammateId",
                table: "TranslationItems",
                column: "TeammateId",
                principalTable: "Teammates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Teammates_TeammateId1",
                table: "TranslationItems",
                column: "TeammateId1",
                principalTable: "Teammates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationItems_Teammates_TeammateId2",
                table: "TranslationItems",
                column: "TeammateId2",
                principalTable: "Teammates",
                principalColumn: "Id");
        }
    }
}
