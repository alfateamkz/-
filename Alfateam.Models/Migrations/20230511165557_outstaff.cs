using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.Database.Migrations
{
    public partial class outstaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TranslationItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TranslationItems",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TranslationItems",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Teammates",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Teammates",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teammates",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TeammateLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TeammateLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TeammateLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SiteFrontends",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SiteFrontends",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SiteFrontends",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SharedLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SharedLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SharedLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ServicesPageLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ServicesPageLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ServicesPageLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Promotions",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Promotions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PromotionLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PromotionLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PromotionLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "PromotionDescriptionItems",
                keyColumn: "Text",
                keyValue: null,
                column: "Text",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "PromotionDescriptionItems",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PromotionDescriptionItems",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PromotionDescriptionItems",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PromotionDescriptionItems",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PromotionDescriptionItemLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PromotionDescriptionItemLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PromotionDescriptionItemLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PrivacyPageLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PrivacyPageLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PrivacyPageLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostVideos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PostVideos",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostVideos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostSliders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PostSliders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostSliders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Posts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostParagraphs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PostParagraphs",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostParagraphs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PostImages",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostImages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PostHeadings",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PostHeadings",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PostHeadings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Portfolios",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Portfolios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsHidden",
            //    table: "Portfolios",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PortfolioPopupLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PortfolioPopupLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PortfolioPopupLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PortfolioPageLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PortfolioPageLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PortfolioPageLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PortfolioLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PortfolioLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PortfolioLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PortfolioImages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PortfolioImages",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PortfolioImages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PortfolioCategoryLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PortfolioCategoryLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PortfolioCategoryLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PortfolioCategories",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PortfolioCategories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Partners",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Partners",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Partners",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PartnerLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PartnerLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PartnerLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NewsPageLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "NewsPageLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NewsPageLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "NewPosts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MapBlockLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MapBlockLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MapBlockLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MainPageLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MainPageLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MainPageLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Languages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Languages",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Languages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "LandingTexts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "LandingTexts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LandingTexts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GeneralTexts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "GeneralTexts",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GeneralTexts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ErrorPagesLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ErrorPagesLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ErrorPagesLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ErrorPages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ErrorPages",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ErrorPages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContactsPopupLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ContactsPopupLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ContactsPopupLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CallRequests",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CallRequests",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CallPopupLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CallPopupLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CallPopupLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CalculatorLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CalculatorLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CalculatorLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AcceptOrderPopupLocalizations",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AcceptOrderPopupLocalizations",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AcceptOrderPopupLocalizations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OutstaffEmployeeInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FIO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HourlyRate = table.Column<double>(type: "double", nullable: false),
                    HourlyRateInternal = table.Column<double>(type: "double", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffEmployeeInfos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutstaffEmployeeInfos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TranslationItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Teammates");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Teammates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teammates");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TeammateLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TeammateLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TeammateLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SiteFrontends");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SiteFrontends");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SiteFrontends");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SharedLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SharedLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SharedLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ServicesPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ServicesPageLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ServicesPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PromotionLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PromotionLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PromotionLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PromotionDescriptionItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PromotionDescriptionItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PromotionDescriptionItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PromotionDescriptionItemLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PromotionDescriptionItemLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PromotionDescriptionItemLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PrivacyPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PrivacyPageLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PrivacyPageLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostVideos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostSliders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PostSliders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostSliders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostParagraphs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostImages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PostHeadings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PostHeadings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PostHeadings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Portfolios");

            //migrationBuilder.DropColumn(
            //    name: "IsHidden",
            //    table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PortfolioPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PortfolioPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PortfolioPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PortfolioPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PortfolioPageLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PortfolioPageLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PortfolioLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PortfolioLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PortfolioLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PortfolioImages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PortfolioImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PortfolioImages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PortfolioCategoryLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PortfolioCategoryLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PortfolioCategoryLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PortfolioCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PortfolioCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PartnerLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PartnerLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PartnerLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NewsPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "NewsPageLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NewsPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "NewPosts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MapBlockLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MapBlockLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MapBlockLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MainPageLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MainPageLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MainPageLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "LandingTexts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "LandingTexts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LandingTexts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GeneralTexts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "GeneralTexts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GeneralTexts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ErrorPagesLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ErrorPagesLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ErrorPagesLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ErrorPages");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ErrorPages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ErrorPages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContactsPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ContactsPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ContactsPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CallRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CallRequests");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CallPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CallPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CallPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CalculatorLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CalculatorLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CalculatorLocalizations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AcceptOrderPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AcceptOrderPopupLocalizations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AcceptOrderPopupLocalizations");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "PromotionDescriptionItems",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
